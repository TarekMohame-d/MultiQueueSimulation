using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MultiQueueSimulation
{
    public partial class Graphs : Form
    {
        private int paddingStep = 0;

        public Graphs()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Graphs_FormClosing);
            GenerateChart(1);

        }

        private void Graphs_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Graphs_Load(object sender, EventArgs e)
        {
            

        }

        private void GenerateChart(int ID)
        {
            Label header = new Label();
            header.Text = $"Server Busy Time - Server {ID}";
            header.AutoSize = true;
            header.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            header.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            header.Location = new System.Drawing.Point(63, 150 + (paddingStep * 400));
            header.Name = "label2";
            header.Size = new System.Drawing.Size(100, 42);
            header.TabIndex = 16;
            this.Controls.Add(header);



            Chart chart = new Chart();
            Series series = new Series("MySeries");
            chart.Dock = DockStyle.None;
            int width = 0;



            // Create a ChartArea.
            ChartArea chartArea = new ChartArea("MyChartArea");
            
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = 20;
            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Maximum = width = 1;

            chartArea.AxisY.IsReversed = true;

            chartArea.Name = "ChartArea1";
            chart.Location = new System.Drawing.Point(63, 200 + (paddingStep * 400));

            paddingStep++;

            chart.Name = "chart1";
            chart.Size = new System.Drawing.Size(500, 500);
            chart.TabIndex = 1;
            chart.Text = "chart1";

            chart.ChartAreas.Add(chartArea);

            // Create a Series for the bar graph.
            series.ChartArea = "ChartArea1";
            series.Name = "Series1";
            series.ChartType = SeriesChartType.Bar;

            series.Points.AddXY(1, 4);

            chart.Series.Add(series);

            // Add the chart to the form.

            this.Controls.Add(chart);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
