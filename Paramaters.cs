using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dcmotor
{
    /// <summary>
    /// Parameters of DC Motor (Maxon RE65-353296-36V) in SI-units.
    /// </summary>
    public class Parameters
    {
        public double NominalVoltage { get; }
        public double NoLoadSpeed { get; }
        public double NoLoadVelocity { get; }
        public double NoLoadCurrent { get; }
        public double NominalSpeed { get; }
        public double NominalTorque { get; }
        public double NominalCurrent { get; }
        public double StallTorque { get; }
        public double StartingCurrent { get; }
        public double MaxEfficiency { get; }
        public double TerminalResistance { get; }
        public double TerminalInductance { get; }
        public double TorqueConstant { get; }
        public double SpeedConstant { get; }
        public double SpeedTorqueGradient { get; }
        public double MechanicalTimeConstant { get; }
        public double RotorInertia { get; }
        public double BackEmfConstant { get; }
        public double NominalVelocity { get; }
        public double VelocityConstant { get; }
        public double J { get; }

        /// <summary>
        /// Constructor for parameters of MAXON RE65 DC motor
        /// </summary>
        public Parameters()
        {
            NominalVoltage = 36;  // V                 Va
            NoLoadSpeed = 3770; //   RPM
            NoLoadCurrent = 0.407; // A                iA
            NominalSpeed = 3550; //   RPM
            NominalTorque = 0.654; // Nm               Tshaft_nom
            NominalCurrent = 7.74; // A
            StallTorque = 18.6; // Nm                  Tstall
            StartingCurrent = 0.208; // A
            MaxEfficiency = 0.873; // %                N
            TerminalResistance = 0.173; // Ohm
            TerminalInductance = 0.848; // mH
            TorqueConstant = 0.0891; // Nm/Ampere       Kt
            SpeedConstant = 107; // rpm/V
            VelocityConstant = 11.202; // rad/s/v
            SpeedTorqueGradient = 0.208; // rpm/mNm
            MechanicalTimeConstant = 3; // ms
            RotorInertia = 0.000138; // kgm^2
            BackEmfConstant = 0.0891; // v/rad/s     Kemf
            NominalVelocity = 371.755131; // rad/s
            NoLoadVelocity = 394.793477; // rad/s
            StallTorque = 18.6; // Nm
            J = (StallTorque * 0.3) / NominalVelocity; // Unused..
        }
    }
}
