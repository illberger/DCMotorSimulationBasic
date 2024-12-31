using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Dcmotor
{
    /// <summary>
    /// Simulates armature voltage drop, back EMF, Torque, angular velocity, transient effects -
    /// assuming motor parameters are correctly applied in SI units.
    /// </summary>
    public class Simulator
    {
        // --- CLASS ESSENTIAL FIELDS --- //
        private Parameters motor;
        private double inputVoltage;
        private double loadTorque;
        private double timeStep;
        private int steps;

        Queue<double> efficiencyWindow = new Queue<double>();

        // --- STORES RESULTS FOR PLOTTING IN INSTANTIATED OBJECT --- //
        // initialized with max duration of total iteration. You can  //
        // reduce "maxTime" or "tmax" in form.cs if you want to optim-//
        // -ize memory
        public double[] Time { get; private set; }
        public double[] AngularVelocity { get; private set; }
        public double[] ArmatureCurrent { get; private set; }
        public double[] BackEmf { get; private set; }
        public double[] Voltage { get; private set; }
        public double[] Tfriction { get; private set; }
        public double[] Frictionloss { get; private set; }
        public double[] InputPower { get; private set; }
        public double[] ElectricalLosses { get; private set; }
        public double[] ElectroDynamicTorque { get; private set; }
        public double[] NetTorque { get; private set; }
        public double[] Efficiency { get; private set; }
        public Simulator(Parameters motor, double inputVoltage, double loadTorque, double timeStep, double maxTime)
        {
            this.motor = motor;
            this.inputVoltage = inputVoltage;
            this.loadTorque = loadTorque;
            this.timeStep = timeStep;
            this.steps = (int)(maxTime / timeStep);

            Time = new double[steps];
            AngularVelocity = new double[steps];
            Voltage = new double[steps];
            ArmatureCurrent = new double[steps];
            BackEmf = new double[steps];
            Tfriction = new double[steps];
            Frictionloss = new double[steps];
            InputPower = new double[steps];
            ElectricalLosses = new double[steps];
            ElectroDynamicTorque = new double[steps];
            NetTorque = new double[steps];
            Efficiency = new double[steps];
        }

        /// <summary>
        /// Continuous function. This is designed, assuming torque constant and back emf constant are correct etc,
        /// to approach steady state after some oscillation. Note that if external load (load torque) is too great,
        /// nominal values will be exceeded for an extended period.
        /// </summary>
        public void RunSimulation()
        {
            double I_a = motor.StartingCurrent;
            double omega = 0;
            double B = (motor.TorqueConstant * motor.NoLoadCurrent) / motor.NoLoadVelocity; // Viscous friction coefficient
            double dI_a_dt = 0;

            for (int step = 0; step < steps; step++)
            {
                double t = step * timeStep;
                Time[step] = t;

                double E_m = motor.BackEmfConstant * omega;
                BackEmf[step] = E_m;

                double V_a = inputVoltage - E_m - (I_a * motor.TerminalResistance);
                Voltage[step] = V_a;

                dI_a_dt = V_a / motor.TerminalInductance;
                I_a += dI_a_dt * timeStep;
                ArmatureCurrent[step] = I_a;

                double T_e = motor.TorqueConstant * I_a;
                ElectroDynamicTorque[step] = T_e;

                double tfriction = B * omega;
                Tfriction[step] = tfriction;

                double Tshaft = T_e - tfriction - loadTorque;
                NetTorque[step] = Tshaft;

                double dOmega_dt = Tshaft / motor.RotorInertia;
                omega += dOmega_dt * timeStep;
                omega = Math.Max(0, omega);
                AngularVelocity[step] = omega;

                double N = (Tshaft * omega) / (V_a * I_a);
                N = (Math.Max(0, Math.Min(N, 1.0)));

                efficiencyWindow.Enqueue(N);
                if (efficiencyWindow.Count > 10) efficiencyWindow.Dequeue();
                Efficiency[step] = efficiencyWindow.Average();

                double inputPower = (Math.Max(inputVoltage, V_a)) * I_a;
                InputPower[step] = inputPower;

                double electricalLoss = Math.Pow(I_a, 2) * motor.TerminalResistance;
                ElectricalLosses[step] = electricalLoss;

                double frictionLoss = tfriction * omega;
                Frictionloss[step] = frictionLoss;
            }
        }

    }
}

