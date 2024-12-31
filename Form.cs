using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;
using System.Windows.Forms.DataVisualization.Charting;

namespace Dcmotor
{
    /// <summary>
    /// Simple windows forms plotting program to simulate DC motor behaviour.
    /// </summary>
    public partial class Form : System.Windows.Forms.Form
    {
        private bool Stop = true;
        // Class-level fields for series, assign values here if you want to add more series, then "AddChartSeries" in "InitializeCharts"
        private Series angularVelocitySeries;
        private Series armatureCurrentSeries;
        private Series armatureVoltageSeries;
        private Series backEmfSeries;
        private Series inputPowerSeries;
        private Series electricalLossesSeries;
        private Series frictionLossSeries;
        private Series electromagneticTorqueSeries;
        private Series tfrictionSeries;
        private Series tshaftSeries;
        private Series loadTorqueSeries;

        public Form()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            ConfigureChart(chartOhm, "MainArea1", "Time(s)", "V/A/EM");
            ConfigureChart(chartRadian, "MainArea2", "Time(s)", "Rad/s");
            ConfigureChart(chartWatt, "MainArea3", "Time(s)", "Watt");
            ConfigureChart(chartNewton, "MainArea4", "Time(s)", "Nm");
            InitializeCharts();

        }

        /// <summary>
        /// Instantiate chart object and legend object
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="chartAreaName"></param>
        /// <param name="xAxisTitle"></param>
        /// <param name="yAxisTitle"></param>
        private void ConfigureChart(Chart chart, string chartAreaName, string xAxisTitle, string yAxisTitle)
        {

            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Legends.Clear();

            ChartArea chartArea = new ChartArea(chartAreaName)
            {
                AxisX = { Title = xAxisTitle },
                AxisY = { Title = yAxisTitle }
            };
            chart.ChartAreas.Add(chartArea);

            Legend legend = new Legend
            {
                Name = "Default",
                Font = new Font("Arial", 10),
                Docking = Docking.Top
            };
            chart.Legends.Add(legend);
        }

        private void AddChartSeries(Chart chart, string name, SeriesChartType chartType, string colorName)
        {
            Series series = new Series(name)
            {
                ChartType = chartType,
                Legend = "Default",
                IsVisibleInLegend = true,
                Color = System.Drawing.Color.FromName(colorName),
                BorderWidth = 4

            };
            chart.Series.Add(series);
        }


        private async void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            await PlotMotorData();
        }


        /// <summary>
        /// 
        /// 
        /// Va = Ra*Ia + Em = Ra*Ia+Ke*angularV
        /// 
        /// Ia = Va - Em / Ra
        /// 
        /// Em = Ke*Angularv
        /// Te = kt*Ia
        /// 
        /// (Te - Tfriction) - Tload = Tshaft - Tload
        /// (Te - Tfriction) = Tshaft
        /// 
        /// J * angularVAcceleration = (Te - Tfriction) - Tload = Tshaft - Tload
        /// J * angularVAcceleration = Te - Tfriction = Tshaft
        /// 
        /// Pmech frict loss = Tfriction * angularV
        /// 
        /// Tfriction = kt * I_no_load
        /// 
        /// Elec Loss = R * Ia^2
        /// 
        /// Efficiency = (Tshaft * angularV) / Va * Ia
        /// 
        /// Ke = Kb = Vpeak / angularV_Noload = 1/Kv    //     [V/rad/s] // back emf constant
        /// 
        /// Ia = Te / Kt
        /// 
        /// Kt = Te / Ia
        /// </summary>
        private async Task PlotMotorData()
        {
            Parameters motor = new Parameters();
            double inputVoltage = 36; // [V] V_applied to commutators/terminals +-.
            double loadTorque = 0.59; // [Nm].  External Load
            double timeStep = 0.0003; // dt
            double maxTime = 7.5; // tmax

            // Instantiate simulator and run simulation
            Simulator simulator = await Task.Run(() =>
            {
                var sim = new Simulator(motor, inputVoltage, loadTorque, timeStep, maxTime);
                sim.RunSimulation();
                return sim;
            });

            // Retrieve simulation results
            double[] time = simulator.Time;
            double[] angularVelocity = simulator.AngularVelocity;
            double[] armatureCurrent = simulator.ArmatureCurrent;
            double[] backEmf = simulator.BackEmf;
            double[] voltage = simulator.Voltage;
            double[] tfriction = simulator.Tfriction;
            double[] frictionloss = simulator.Frictionloss;
            double[] inputPower = simulator.InputPower;
            double[] electricalLosses = simulator.ElectricalLosses;
            double[] electromagneticTorque = simulator.ElectroDynamicTorque;
            double[] netTorque = simulator.NetTorque;
            double[] efficiency = simulator.Efficiency;

            
            
            for (int i = 0; i < time.Length; i++)
            {
                if (Stop)
                {
                    if (i % 10 == 0 || i == time.Length - 1)
                    {
                        // Update series data
                        angularVelocitySeries.Points.AddXY(time[i], angularVelocity[i]);
                        armatureCurrentSeries.Points.AddXY(time[i], armatureCurrent[i]);
                        armatureVoltageSeries.Points.AddXY(time[i], voltage[i]);
                        backEmfSeries.Points.AddXY(time[i], backEmf[i]);
                        inputPowerSeries.Points.AddXY(time[i], inputPower[i]);
                        electricalLossesSeries.Points.AddXY(time[i], electricalLosses[i]);
                        frictionLossSeries.Points.AddXY(time[i], frictionloss[i]);
                        electromagneticTorqueSeries.Points.AddXY(time[i], electromagneticTorque[i]);
                        tfrictionSeries.Points.AddXY(time[i], tfriction[i]);
                        tshaftSeries.Points.AddXY(time[i], netTorque[i]);
                        loadTorqueSeries.Points.AddXY(time[i], loadTorque);

                        // Update RPM label
                        double rpm = (angularVelocity[i] * 60) / (2 * Math.PI);
                        double N = simulator.Efficiency[i];
                        labelRPM.Text = $"RPM: {rpm:F2}";
                        labelLoad.Text = $"Load: {loadTorque:F2} Nm";
                        labelEfficiency.Text = $"Efficiency: {N:F2}";
                    }

                    // Delay adjustment. increase milliSecondsDelay for slower more "real-time" simulation
                    await Task.Delay(1);
                }
                else
                {
                    return;
                }
            }                                
        }


        /// <summary>
        /// add series to chart centralized.
        /// </summary>
        private void InitializeCharts()
        {
            // Angular velocity chart
            AddChartSeries(chartRadian, "Angular Velocity (Rad/s)", SeriesChartType.Line, "Orange");
            angularVelocitySeries = chartRadian.Series["Angular Velocity (Rad/s)"];

            // Armature current, voltage, and Back EMF
            AddChartSeries(chartOhm, "Armature Current (A)", SeriesChartType.Line, "Blue");
            AddChartSeries(chartOhm, "Armature Voltage (V)", SeriesChartType.Line, "Red");
            AddChartSeries(chartOhm, "Back EMF (V)", SeriesChartType.Line, "Green");
            armatureCurrentSeries = chartOhm.Series["Armature Current (A)"];
            armatureVoltageSeries = chartOhm.Series["Armature Voltage (V)"];
            backEmfSeries = chartOhm.Series["Back EMF (V)"];

            // Power-related losses
            AddChartSeries(chartWatt, "Input Power (W)", SeriesChartType.Line, "Purple");
            AddChartSeries(chartWatt, "Electrical Losses (W)", SeriesChartType.Line, "Red");
            AddChartSeries(chartWatt, "Mech Friction Loss (W)", SeriesChartType.Line, "Green");
            inputPowerSeries = chartWatt.Series["Input Power (W)"];
            electricalLossesSeries = chartWatt.Series["Electrical Losses (W)"];
            frictionLossSeries = chartWatt.Series["Mech Friction Loss (W)"];

            // Torque-related series
            AddChartSeries(chartNewton, "Electromagnetic Torque (Nm)", SeriesChartType.Line, "Blue");
            AddChartSeries(chartNewton, "Friction Torque (Nm)", SeriesChartType.Line, "Red");
            AddChartSeries(chartNewton, "Net Torque (Nm)", SeriesChartType.Line, "Green");
            AddChartSeries(chartNewton, "Load Torque (Nm)", SeriesChartType.Line, "Orange");
            tshaftSeries = chartNewton.Series["Net Torque (Nm)"];
            electromagneticTorqueSeries = chartNewton.Series["Electromagnetic Torque (Nm)"];
            tfrictionSeries = chartNewton.Series["Friction Torque (Nm)"];
            loadTorqueSeries = chartNewton.Series["Load Torque (Nm)"];

            
        }




        /// <summary>
        /// Finish the current time sequence, and save result for analyze
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStop_Click(object sender, EventArgs e)
        {
            Stop = false;
        }
    }

}
