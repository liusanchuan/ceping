namespace SharpGLWinformsApplication1
{
    partial class history_data_MDI_child
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(1, -2);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.MarkerColor = System.Drawing.Color.Black;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star10;
            series1.Name = "应力";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            series2.Legend = "Legend1";
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star10;
            series2.Name = "温度";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star10;
            series3.Name = "震动";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Legend = "Legend1";
            series4.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star10;
            series4.Name = "变形";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(769, 211);
            this.chart1.TabIndex = 52;
            this.chart1.Text = "chart1";
            // 
            // history_data_MDI_child
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 247);
            this.Controls.Add(this.chart1);
            this.Name = "history_data_MDI_child";
            this.Text = "子窗体";
            this.Load += new System.EventHandler(this.history_data_MDI_child_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.history_data_MDI_child_Paint);
            this.Resize += new System.EventHandler(this.history_data_MDI_child_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;


    }
}