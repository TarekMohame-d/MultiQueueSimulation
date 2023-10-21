using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiQueueModels;

namespace MultiQueueSimulation
{
    public partial class CalculationsForm : Form
    {
        public CalculationsForm()
        {
            InitializeComponent();
        }

        private void CalculationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void CalculationsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
