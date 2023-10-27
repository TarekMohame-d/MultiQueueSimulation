using MultiQueueModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiQueueSimulation
{
    public partial class PerformanceMeasuresForm : Form
    {



        SimulationSystem oursystem = CalculationsForm.oursystem;

        public PerformanceMeasuresForm()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(PerformanceMeasuresForm_FormClosing);
            for (int i = 0; i < oursystem.NumberOfServers; i++)
            {
                decimal average = oursystem.Servers[i].AverageServiceTime;
                average = Math.Round(average, 3);

                decimal prob = oursystem.Servers[i].IdleProbability;
                prob = Math.Round(prob, 3);

                decimal util = oursystem.Servers[i].Utilization;
                util = Math.Round(util, 3);

                int id = oursystem.Servers[i].ID;

                generatePanel(average, prob, util, id);
            }
            

        }

        private void PerformanceMeasuresForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void PerformanceMeasuresForm_Load(object sender, EventArgs e)
        {
            AvgWait_textbox.Text = oursystem.PerformanceMeasures.AverageWaitingTime.ToString();
            probWait_textbox.Text = oursystem.PerformanceMeasures.WaitingProbability.ToString();
            maxLength_textbox.Text = oursystem.PerformanceMeasures.MaxQueueLength.ToString();
        }

        private int x = 0;
        private int y = 0;

        private void generatePanel(decimal avgService, decimal ProbIdle, decimal util, int ID)
        {
            Label header = new Label();
            header.Text = $"Performance Measure of Server {ID}";
            header.AutoSize = true;
            header.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            header.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            header.Location = new System.Drawing.Point(63 + (x * 750), 400 + (y * 400));
            header.Name = "label2";
            header.Size = new System.Drawing.Size(581, 42);
            header.TabIndex = 16;
            this.Controls.Add(header);



            Panel newPanel = new Panel();
            newPanel.BackColor = System.Drawing.Color.DeepPink;
            newPanel.Location = new System.Drawing.Point(63 + (x * 750), 448 + (y*400));
            newPanel.Name = "panel2";
            newPanel.Size = new System.Drawing.Size(600, 200);
            newPanel.TabIndex = 25;
            if (x % 1 == 0 && x > 0)
            {
                y += 1;
                x = -1;

            }
            x += 1;
            this.Controls.Add(newPanel);

            // Create labels and textboxes

            //Label 1
            Label label1 = new Label();
            label1.BackColor = System.Drawing.Color.Black;
            label1.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(32, 31);
            label1.Name = "label3";
            label1.Size = new System.Drawing.Size(200, 30);
            label1.TabIndex = 22;
            label1.Text = "Probability of Idle: ";
            newPanel.Controls.Add(label1);

            // Create Label 2
            Label label2 = new Label();
            label2.BackColor = System.Drawing.Color.Black;
            label2.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(32, 95);
            label2.Name = "StoppingCriteria_label";
            label2.Size = new System.Drawing.Size(200, 30);
            label2.TabIndex = 20;
            label2.Text = "Average Service Time: ";
            newPanel.Controls.Add(label2);

            // Create Label 3
            Label label3 = new Label();
            label3.BackColor = System.Drawing.Color.Black;
            label3.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(32, 150);
            label3.Name = "SelectionMethod_label";
            label3.Size = new System.Drawing.Size(150, 30);
            label3.TabIndex = 18;
            label3.Text = "Utilization: ";
            newPanel.Controls.Add(label3);

            //create TextBox 1
            TextBox text1 = new TextBox();
            text1.BackColor = System.Drawing.Color.White;
            text1.Enabled = false;
            text1.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            text1.ForeColor = System.Drawing.Color.Gray;
            text1.Location = new System.Drawing.Point(350, 29);
            text1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            text1.Name = "AvgWait_textbox";
            text1.Text = ProbIdle.ToString();
            text1.Size = new System.Drawing.Size(150, 31);
            text1.TabIndex = 21;
            newPanel.Controls.Add(text1);

            //create textBox 2
            TextBox text2 = new TextBox();
            text2.BackColor = System.Drawing.Color.White;
            text2.Enabled = false;
            text2.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            text2.ForeColor = System.Drawing.Color.Gray;
            text2.Location = new System.Drawing.Point(350, 92);
            text2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            text2.Name = "probWait_textbox";
            text2.Text = avgService.ToString();
            text2.Size = new System.Drawing.Size(150, 31);
            text2.TabIndex = 19;
            newPanel.Controls.Add(text2);

            //create TextBox 3
            TextBox text3 = new TextBox();
            text3.BackColor = System.Drawing.Color.White;
            text3.Enabled = false;
            text3.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            text3.ForeColor = System.Drawing.Color.Gray;
            text3.Location = new System.Drawing.Point(350, 150);
            text3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            text3.Text= util.ToString();
            text3.Name = "maxLength_textbox";
            text3.Size = new System.Drawing.Size(150, 31);
            text3.TabIndex = 17;
            newPanel.Controls.Add(text3);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Graphs().Show();

        }
    }
}
