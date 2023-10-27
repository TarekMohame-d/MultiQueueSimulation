using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MultiQueueModels;

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
            List<DataGridView> dataGridViewList = new List<DataGridView>
            {
                Interarrival_dataGridView,
                server1_dataGridView,
                server2_dataGridView
            };
            ClearDataGridViewRows(dataGridViewList);

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExtraxtData.filePath = openFileDialog.FileName;
                    ExtraxtData.extractFileData();
                    RawData rawData = ExtraxtData.rawData;

                    for (int i = 0; i < rawData.interarrivalTime.Count; i++)
                    {
                        Interarrival_dataGridView.Rows.Add(rawData.interarrivalTime[i], rawData.interarrivalProbability[i]);
                    }
                    for (int i = 0; i < rawData.serviceDistributions.Count; i++)
                    {
                        for (int j = 0; j < rawData.serviceDistributions[i].serverProbability.Count; j++)
                        {

                            if (i == 0)
                            {
                                server1_dataGridView.Rows.Add(rawData.serviceDistributions[i].serverTime[j], rawData.serviceDistributions[i].serverProbability[j]);
                            }
                            else if(i == 1)
                            {
                                server2_dataGridView.Rows.Add(rawData.serviceDistributions[i].serverTime[j], rawData.serviceDistributions[i].serverProbability[j]);
                            }
                        }
                    }

                    NumberOfServers_textBox.Text = rawData.numberOfServers.ToString();
                    StoppingNumber_textBox.Text = rawData.stoppingNumber.ToString();
                    SelectionMethod_textBox.Text = rawData.selectionMethod;
                    StoppingCriteria_textBox.Text = rawData.stoppingCriteria;
                    if (rawData.stoppingCriteria == "NumberOfCustomers")
                    {
                        stoppingUnit_label.Text = "Units";
                        stoppingUnit_label.Visible = true;
                    }
                    else
                    {               
                        stoppingUnit_label.Text = "Unit of time";
                        stoppingUnit_label.Visible = true;
                    }
                }
            }
        }

        private void continue_button_Click(object sender, EventArgs e)
        {
            if (SelectionMethod_textBox.Text != "" && StoppingCriteria_textBox.Text != ""
                && StoppingNumber_textBox.Text != "" && NumberOfServers_textBox.Text != "")
            {
                this.Hide();
                new CalculationsForm().Show();

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

        public static void ClearDataGridViewRows(List<DataGridView> dataGridViewList)
        {
            foreach (DataGridView dataGridView in dataGridViewList)
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    dataGridView.Rows.Clear();
                }
            }
        }

        private void Interarrival_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void NumberOfServers_textBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
