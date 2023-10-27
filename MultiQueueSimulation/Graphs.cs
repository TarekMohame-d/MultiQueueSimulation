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
using static System.Windows.Forms.MonthCalendar;

namespace MultiQueueSimulation
{
    public partial class Graphs : Form
    {
        public Graphs()
        {
            InitializeComponent();
        }

        private void Graphs_Load(object sender, EventArgs e)
        {
            ChartArea chartArea = new ChartArea();
            chart1.ChartAreas.Add(chartArea);
            chartArea.AxisX.Title = "Time";
            chartArea.AxisX.TitleForeColor = System.Drawing.Color.Black;
            chartArea.AxisY.Title = "Busy";
            chartArea.AxisY.TitleForeColor = System.Drawing.Color.Black;
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.IntervalType = DateTimeIntervalType.Number;
            chartArea.AxisX.IntervalOffset = 1;
            chartArea.AxisY.Interval = 0.2;
            chartArea.AxisX.IntervalType = DateTimeIntervalType.Number;
            chart1.Series["Server Busy Time"]["PointWidth"] = "1";
            for (int i = 1; i <= 20; i++)
            {
                double value = (i >= 2 && i <= 6) || (i >= 10 && i <= 20) ? 1.0 : 0.0;
                chart1.Series["Server Busy Time"].Points.AddXY(i, value);
            }  
        }

        private void Graphs_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
