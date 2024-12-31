namespace Dcmotor
{
    partial class Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chartOhm = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartRadian = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartNewton = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartWatt = new System.Windows.Forms.DataVisualization.Charting.Chart();
            labelRPM = new Label();
            buttonStart = new Button();
            buttonStop = new Button();
            labelLoad = new Label();
            labelEfficiency = new Label();
            ((System.ComponentModel.ISupportInitialize)chartOhm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartRadian).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartNewton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartWatt).BeginInit();
            SuspendLayout();
            // 
            // chartOhm
            // 
            chartArea1.Name = "ChartArea1";
            chartOhm.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartOhm.Legends.Add(legend1);
            chartOhm.Location = new Point(635, 409);
            chartOhm.Name = "chartOhm";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartOhm.Series.Add(series1);
            chartOhm.Size = new Size(579, 438);
            chartOhm.TabIndex = 0;
            chartOhm.Text = "chartOhmic";
            // 
            // chartRadian
            // 
            chartArea2.Name = "ChartArea1";
            chartRadian.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chartRadian.Legends.Add(legend2);
            chartRadian.Location = new Point(635, 4);
            chartRadian.Name = "chartRadian";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chartRadian.Series.Add(series2);
            chartRadian.Size = new Size(579, 370);
            chartRadian.TabIndex = 1;
            chartRadian.Text = "chartNewton";
            // 
            // chartNewton
            // 
            chartArea3.Name = "ChartArea1";
            chartNewton.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chartNewton.Legends.Add(legend3);
            chartNewton.Location = new Point(2, 409);
            chartNewton.Name = "chartNewton";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            chartNewton.Series.Add(series3);
            chartNewton.Size = new Size(627, 438);
            chartNewton.TabIndex = 2;
            chartNewton.Text = "chartOhmic";
            // 
            // chartWatt
            // 
            chartArea4.Name = "ChartArea1";
            chartWatt.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            chartWatt.Legends.Add(legend4);
            chartWatt.Location = new Point(2, 4);
            chartWatt.Name = "chartWatt";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            chartWatt.Series.Add(series4);
            chartWatt.Size = new Size(627, 370);
            chartWatt.TabIndex = 3;
            chartWatt.Text = "chartNewton";
            // 
            // labelRPM
            // 
            labelRPM.AutoSize = true;
            labelRPM.Location = new Point(645, 386);
            labelRPM.Name = "labelRPM";
            labelRPM.Size = new Size(75, 15);
            labelRPM.TabIndex = 4;
            labelRPM.Text = "Speed [RPM]";
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(467, 380);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(75, 23);
            buttonStart.TabIndex = 5;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // buttonStop
            // 
            buttonStop.Location = new Point(548, 380);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(75, 23);
            buttonStop.TabIndex = 6;
            buttonStop.Text = "Stop";
            buttonStop.UseVisualStyleBackColor = true;
            buttonStop.Click += buttonStop_Click;
            // 
            // labelLoad
            // 
            labelLoad.AutoSize = true;
            labelLoad.Location = new Point(745, 386);
            labelLoad.Name = "labelLoad";
            labelLoad.Size = new Size(64, 15);
            labelLoad.TabIndex = 7;
            labelLoad.Text = "Load [Nm]";
            // 
            // labelEfficiency
            // 
            labelEfficiency.AutoSize = true;
            labelEfficiency.Location = new Point(831, 388);
            labelEfficiency.Name = "labelEfficiency";
            labelEfficiency.Size = new Size(16, 15);
            labelEfficiency.TabIndex = 8;
            labelEfficiency.Text = "N";
            // 
            // Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1228, 856);
            Controls.Add(labelEfficiency);
            Controls.Add(labelLoad);
            Controls.Add(buttonStop);
            Controls.Add(buttonStart);
            Controls.Add(labelRPM);
            Controls.Add(chartWatt);
            Controls.Add(chartNewton);
            Controls.Add(chartRadian);
            Controls.Add(chartOhm);
            Name = "Form";
            Text = "DAT461";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)chartOhm).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartRadian).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartNewton).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartWatt).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartOhm;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRadian;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNewton;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartWatt;
        private Label labelRPM;
        private Button buttonStart;
        private Button buttonStop;
        private Label labelLoad;
        private Label labelEfficiency;
    }
}
