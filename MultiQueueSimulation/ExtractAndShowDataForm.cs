using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiQueueModels;
using MultiQueueTesting;
using static MultiQueueModels.Enums;

namespace MultiQueueSimulation
{
    public partial class ExtractAndShowDataForm : Form
    {
        public ExtractAndShowDataForm()
        {
            InitializeComponent();
            stoppingUnit_label.Visible = false;
        }

        private void importFile_button_Click(object sender, EventArgs e)
        {
            ClearDataGridViewRows(Interarrival_dataGridView);
            ClearDataGridViewRows(server1_dataGridView);
            ClearDataGridViewRows(server2_dataGridView);

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExtraxtData.filePath = openFileDialog.FileName;
                    ExtraxtData.extractFileData();

                    if (ExtraxtData.data.ContainsKey("Interarrival_Time"))
                    {
                        for (int i = 0; i < ExtraxtData.data["Interarrival_Time"].Count; i++)
                        {
                            Interarrival_dataGridView.Rows.Add(ExtraxtData.data["Interarrival_Time"][i], ExtraxtData.data["Interarrival_Probability"][i]);
                        }
                    }
                    if (ExtraxtData.data.ContainsKey("Server1_Time"))
                    {
                        for (int i = 0; i < ExtraxtData.data["Server1_Time"].Count; i++)
                        {
                            server1_dataGridView.Rows.Add(ExtraxtData.data["Server1_Time"][i], ExtraxtData.data["Server1_Probability"][i]);
                        }
                    }
                    if (ExtraxtData.data.ContainsKey("Server2_Time"))
                    {
                        for (int i = 0; i < ExtraxtData.data["Server2_Time"].Count; i++)
                        {
                            server2_dataGridView.Rows.Add(ExtraxtData.data["Server2_Time"][i], ExtraxtData.data["Server2_Probability"][i]);
                        }
                    }

                    NumberOfServers_textBox.Text = ExtraxtData.data["NumberOfServers"][0].ToString();
                    StoppingNumber_textBox.Text = ExtraxtData.data["StoppingNumber"][0].ToString();
                    if (ExtraxtData.data["StoppingCriteria"][0] == 1)
                    {
                        StoppingCriteria_textBox.Text = Enums.StoppingCriteria.NumberOfCustomers.ToString();
                        stoppingUnit_label.Text = "Units";
                        stoppingUnit_label.Visible = true;
                    }
                    else
                    {
                        StoppingCriteria_textBox.Text = Enums.StoppingCriteria.SimulationEndTime.ToString();
                        stoppingUnit_label.Text = "Unit of time";
                        stoppingUnit_label.Visible = true;
                    }
                    if (ExtraxtData.data["SelectionMethod"][0] == 1)
                    {
                        SelectionMethod_textBox.Text = Enums.SelectionMethod.HighestPriority.ToString();
                    }
                    else if (ExtraxtData.data["SelectionMethod"][0] == 2)
                    {
                        SelectionMethod_textBox.Text = Enums.SelectionMethod.Random.ToString();
                    }
                    else
                    {
                        SelectionMethod_textBox.Text = Enums.SelectionMethod.LeastUtilization.ToString();
                    }
                }
            }
        }

        private void continue_button_Click(object sender, EventArgs e)
        {
            if (SelectionMethod_textBox.Text != "" && StoppingCriteria_textBox.Text != ""
                && StoppingNumber_textBox.Text != "" && NumberOfServers_textBox.Text != "")
            {
                new CalculationsForm().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Fields mustn\'t be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void GridDesign()
        {
            Interarrival_dataGridView.Columns.Add("interarrivalTime", "Interarrival Time");
            Interarrival_dataGridView.Columns.Add("probability", "Probability");
            Interarrival_dataGridView.Columns[0].Width = 122;
            Interarrival_dataGridView.Columns[1].Width = 122;

            server1_dataGridView.Columns.Add("serviceTime", "Service Time");
            server1_dataGridView.Columns.Add("probability", "Probability");
            server1_dataGridView.Columns[0].Width = 122;
            server1_dataGridView.Columns[1].Width = 122;

            server2_dataGridView.Columns.Add("serviceTime", "Service Time");
            server2_dataGridView.Columns.Add("probability", "Probability");
            server2_dataGridView.Columns[0].Width = 122;
            server2_dataGridView.Columns[1].Width = 122;
        }

        private void ExtractAndShowDataForm_Load(object sender, EventArgs e)
        {
            GridDesign();
        }

        private void ExtractAndShowDataForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public static void ClearDataGridViewRows(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                dataGridView.Rows.Clear();
            }

        }
    }
}
