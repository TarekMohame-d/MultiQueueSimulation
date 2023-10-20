namespace MultiQueueSimulation
{
    partial class ExtractAndShowDataForm
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
            this.NumberOfServers_textBox = new System.Windows.Forms.TextBox();
            this.NumberOfServers_label = new System.Windows.Forms.Label();
            this.StoppingNumber_textBox = new System.Windows.Forms.TextBox();
            this.SelectionMethod_label = new System.Windows.Forms.Label();
            this.SelectionMethod_textBox = new System.Windows.Forms.TextBox();
            this.StoppingNumber_label = new System.Windows.Forms.Label();
            this.StoppingCriteria_label = new System.Windows.Forms.Label();
            this.StoppingCriteria_textBox = new System.Windows.Forms.TextBox();
            this.importFile_button = new System.Windows.Forms.Button();
            this.continue_button = new System.Windows.Forms.Button();
            this.stoppingUnit_label = new System.Windows.Forms.Label();
            this.Interarrival_dataGridView = new System.Windows.Forms.DataGridView();
            this.server2_dataGridView = new System.Windows.Forms.DataGridView();
            this.server1_dataGridView = new System.Windows.Forms.DataGridView();
            this.InterarrivalDistribution_label = new System.Windows.Forms.Label();
            this.Server2TimeDistribution_label = new System.Windows.Forms.Label();
            this.Server1TimeDistribution_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Interarrival_dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.server2_dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.server1_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // NumberOfServers_textBox
            // 
            this.NumberOfServers_textBox.BackColor = System.Drawing.Color.White;
            this.NumberOfServers_textBox.Enabled = false;
            this.NumberOfServers_textBox.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumberOfServers_textBox.ForeColor = System.Drawing.Color.Gray;
            this.NumberOfServers_textBox.Location = new System.Drawing.Point(270, 40);
            this.NumberOfServers_textBox.Name = "NumberOfServers_textBox";
            this.NumberOfServers_textBox.Size = new System.Drawing.Size(100, 31);
            this.NumberOfServers_textBox.TabIndex = 0;
            this.NumberOfServers_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NumberOfServers_label
            // 
            this.NumberOfServers_label.BackColor = System.Drawing.Color.White;
            this.NumberOfServers_label.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumberOfServers_label.Location = new System.Drawing.Point(40, 40);
            this.NumberOfServers_label.Name = "NumberOfServers_label";
            this.NumberOfServers_label.Size = new System.Drawing.Size(210, 30);
            this.NumberOfServers_label.TabIndex = 1;
            this.NumberOfServers_label.Text = "NumberOfServers:";
            // 
            // StoppingNumber_textBox
            // 
            this.StoppingNumber_textBox.BackColor = System.Drawing.Color.White;
            this.StoppingNumber_textBox.Enabled = false;
            this.StoppingNumber_textBox.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StoppingNumber_textBox.ForeColor = System.Drawing.Color.Gray;
            this.StoppingNumber_textBox.Location = new System.Drawing.Point(270, 110);
            this.StoppingNumber_textBox.Name = "StoppingNumber_textBox";
            this.StoppingNumber_textBox.Size = new System.Drawing.Size(100, 31);
            this.StoppingNumber_textBox.TabIndex = 2;
            this.StoppingNumber_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SelectionMethod_label
            // 
            this.SelectionMethod_label.BackColor = System.Drawing.Color.White;
            this.SelectionMethod_label.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectionMethod_label.Location = new System.Drawing.Point(500, 110);
            this.SelectionMethod_label.Name = "SelectionMethod_label";
            this.SelectionMethod_label.Size = new System.Drawing.Size(220, 30);
            this.SelectionMethod_label.TabIndex = 5;
            this.SelectionMethod_label.Text = "SelectionMethod:";
            // 
            // SelectionMethod_textBox
            // 
            this.SelectionMethod_textBox.BackColor = System.Drawing.Color.White;
            this.SelectionMethod_textBox.Enabled = false;
            this.SelectionMethod_textBox.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectionMethod_textBox.ForeColor = System.Drawing.Color.Gray;
            this.SelectionMethod_textBox.Location = new System.Drawing.Point(740, 110);
            this.SelectionMethod_textBox.Name = "SelectionMethod_textBox";
            this.SelectionMethod_textBox.Size = new System.Drawing.Size(220, 31);
            this.SelectionMethod_textBox.TabIndex = 4;
            // 
            // StoppingNumber_label
            // 
            this.StoppingNumber_label.BackColor = System.Drawing.Color.White;
            this.StoppingNumber_label.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StoppingNumber_label.Location = new System.Drawing.Point(40, 110);
            this.StoppingNumber_label.Name = "StoppingNumber_label";
            this.StoppingNumber_label.Size = new System.Drawing.Size(210, 30);
            this.StoppingNumber_label.TabIndex = 7;
            this.StoppingNumber_label.Text = "StoppingNumber:";
            // 
            // StoppingCriteria_label
            // 
            this.StoppingCriteria_label.BackColor = System.Drawing.Color.White;
            this.StoppingCriteria_label.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StoppingCriteria_label.Location = new System.Drawing.Point(500, 40);
            this.StoppingCriteria_label.Name = "StoppingCriteria_label";
            this.StoppingCriteria_label.Size = new System.Drawing.Size(220, 30);
            this.StoppingCriteria_label.TabIndex = 9;
            this.StoppingCriteria_label.Text = "StoppingCriteria:";
            // 
            // StoppingCriteria_textBox
            // 
            this.StoppingCriteria_textBox.BackColor = System.Drawing.Color.White;
            this.StoppingCriteria_textBox.Enabled = false;
            this.StoppingCriteria_textBox.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StoppingCriteria_textBox.ForeColor = System.Drawing.Color.Gray;
            this.StoppingCriteria_textBox.Location = new System.Drawing.Point(740, 40);
            this.StoppingCriteria_textBox.Name = "StoppingCriteria_textBox";
            this.StoppingCriteria_textBox.Size = new System.Drawing.Size(220, 31);
            this.StoppingCriteria_textBox.TabIndex = 8;
            // 
            // importFile_button
            // 
            this.importFile_button.BackColor = System.Drawing.Color.DarkGray;
            this.importFile_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.importFile_button.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importFile_button.Location = new System.Drawing.Point(1100, 40);
            this.importFile_button.Name = "importFile_button";
            this.importFile_button.Size = new System.Drawing.Size(200, 40);
            this.importFile_button.TabIndex = 10;
            this.importFile_button.Text = "Import File";
            this.importFile_button.UseVisualStyleBackColor = false;
            this.importFile_button.Click += new System.EventHandler(this.importFile_button_Click);
            // 
            // continue_button
            // 
            this.continue_button.BackColor = System.Drawing.Color.DarkGray;
            this.continue_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.continue_button.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continue_button.Location = new System.Drawing.Point(1100, 105);
            this.continue_button.Name = "continue_button";
            this.continue_button.Size = new System.Drawing.Size(200, 40);
            this.continue_button.TabIndex = 11;
            this.continue_button.Text = "Continue";
            this.continue_button.UseVisualStyleBackColor = false;
            this.continue_button.Click += new System.EventHandler(this.continue_button_Click);
            // 
            // stoppingUnit_label
            // 
            this.stoppingUnit_label.AutoSize = true;
            this.stoppingUnit_label.Font = new System.Drawing.Font("Cascadia Code SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stoppingUnit_label.ForeColor = System.Drawing.Color.Gray;
            this.stoppingUnit_label.Location = new System.Drawing.Point(376, 116);
            this.stoppingUnit_label.Name = "stoppingUnit_label";
            this.stoppingUnit_label.Size = new System.Drawing.Size(70, 22);
            this.stoppingUnit_label.TabIndex = 12;
            this.stoppingUnit_label.Text = "label1";
            // 
            // Interarrival_dataGridView
            // 
            this.Interarrival_dataGridView.AllowUserToAddRows = false;
            this.Interarrival_dataGridView.AllowUserToDeleteRows = false;
            this.Interarrival_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Interarrival_dataGridView.Location = new System.Drawing.Point(45, 267);
            this.Interarrival_dataGridView.Name = "Interarrival_dataGridView";
            this.Interarrival_dataGridView.ReadOnly = true;
            this.Interarrival_dataGridView.RowHeadersWidth = 51;
            this.Interarrival_dataGridView.RowTemplate.Height = 24;
            this.Interarrival_dataGridView.Size = new System.Drawing.Size(398, 220);
            this.Interarrival_dataGridView.TabIndex = 13;
            // 
            // server2_dataGridView
            // 
            this.server2_dataGridView.AllowUserToAddRows = false;
            this.server2_dataGridView.AllowUserToDeleteRows = false;
            this.server2_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.server2_dataGridView.Location = new System.Drawing.Point(961, 267);
            this.server2_dataGridView.Name = "server2_dataGridView";
            this.server2_dataGridView.ReadOnly = true;
            this.server2_dataGridView.RowHeadersWidth = 51;
            this.server2_dataGridView.RowTemplate.Height = 24;
            this.server2_dataGridView.Size = new System.Drawing.Size(398, 220);
            this.server2_dataGridView.TabIndex = 14;
            // 
            // server1_dataGridView
            // 
            this.server1_dataGridView.AllowUserToAddRows = false;
            this.server1_dataGridView.AllowUserToDeleteRows = false;
            this.server1_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.server1_dataGridView.Location = new System.Drawing.Point(505, 267);
            this.server1_dataGridView.Name = "server1_dataGridView";
            this.server1_dataGridView.ReadOnly = true;
            this.server1_dataGridView.RowHeadersWidth = 51;
            this.server1_dataGridView.RowTemplate.Height = 24;
            this.server1_dataGridView.Size = new System.Drawing.Size(398, 220);
            this.server1_dataGridView.TabIndex = 15;
            // 
            // InterarrivalDistribution_label
            // 
            this.InterarrivalDistribution_label.AutoSize = true;
            this.InterarrivalDistribution_label.Font = new System.Drawing.Font("Cascadia Code", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InterarrivalDistribution_label.Location = new System.Drawing.Point(40, 234);
            this.InterarrivalDistribution_label.Name = "InterarrivalDistribution_label";
            this.InterarrivalDistribution_label.Size = new System.Drawing.Size(338, 30);
            this.InterarrivalDistribution_label.TabIndex = 16;
            this.InterarrivalDistribution_label.Text = "Interarrival Distribution";
            // 
            // Server2TimeDistribution_label
            // 
            this.Server2TimeDistribution_label.AutoSize = true;
            this.Server2TimeDistribution_label.Font = new System.Drawing.Font("Cascadia Code", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Server2TimeDistribution_label.Location = new System.Drawing.Point(500, 234);
            this.Server2TimeDistribution_label.Name = "Server2TimeDistribution_label";
            this.Server2TimeDistribution_label.Size = new System.Drawing.Size(338, 30);
            this.Server2TimeDistribution_label.TabIndex = 17;
            this.Server2TimeDistribution_label.Text = "Server1 Time Distribution";
            // 
            // Server1TimeDistribution_label
            // 
            this.Server1TimeDistribution_label.AutoSize = true;
            this.Server1TimeDistribution_label.Font = new System.Drawing.Font("Cascadia Code", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Server1TimeDistribution_label.Location = new System.Drawing.Point(956, 234);
            this.Server1TimeDistribution_label.Name = "Server1TimeDistribution_label";
            this.Server1TimeDistribution_label.Size = new System.Drawing.Size(338, 30);
            this.Server1TimeDistribution_label.TabIndex = 18;
            this.Server1TimeDistribution_label.Text = "Server2 Time Distribution";
            // 
            // ExtractAndShowDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.Server1TimeDistribution_label);
            this.Controls.Add(this.Server2TimeDistribution_label);
            this.Controls.Add(this.InterarrivalDistribution_label);
            this.Controls.Add(this.server1_dataGridView);
            this.Controls.Add(this.server2_dataGridView);
            this.Controls.Add(this.Interarrival_dataGridView);
            this.Controls.Add(this.stoppingUnit_label);
            this.Controls.Add(this.continue_button);
            this.Controls.Add(this.importFile_button);
            this.Controls.Add(this.StoppingCriteria_label);
            this.Controls.Add(this.StoppingCriteria_textBox);
            this.Controls.Add(this.StoppingNumber_label);
            this.Controls.Add(this.SelectionMethod_label);
            this.Controls.Add(this.SelectionMethod_textBox);
            this.Controls.Add(this.StoppingNumber_textBox);
            this.Controls.Add(this.NumberOfServers_label);
            this.Controls.Add(this.NumberOfServers_textBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ExtractAndShowDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extract & Show Data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExtractAndShowDataForm_FormClosing);
            this.Load += new System.EventHandler(this.ExtractAndShowDataForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Interarrival_dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.server2_dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.server1_dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NumberOfServers_textBox;
        private System.Windows.Forms.Label NumberOfServers_label;
        private System.Windows.Forms.TextBox StoppingNumber_textBox;
        private System.Windows.Forms.Label SelectionMethod_label;
        private System.Windows.Forms.TextBox SelectionMethod_textBox;
        private System.Windows.Forms.Label StoppingNumber_label;
        private System.Windows.Forms.Label StoppingCriteria_label;
        private System.Windows.Forms.TextBox StoppingCriteria_textBox;
        private System.Windows.Forms.Button importFile_button;
        private System.Windows.Forms.Button continue_button;
        private System.Windows.Forms.Label stoppingUnit_label;
        private System.Windows.Forms.DataGridView Interarrival_dataGridView;
        private System.Windows.Forms.DataGridView server2_dataGridView;
        private System.Windows.Forms.DataGridView server1_dataGridView;
        private System.Windows.Forms.Label InterarrivalDistribution_label;
        private System.Windows.Forms.Label Server2TimeDistribution_label;
        private System.Windows.Forms.Label Server1TimeDistribution_label;
    }
}

