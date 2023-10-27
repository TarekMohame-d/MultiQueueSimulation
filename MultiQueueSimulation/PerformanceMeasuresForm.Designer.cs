namespace MultiQueueSimulation
{
    partial class PerformanceMeasuresForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.AvgWait_textbox = new System.Windows.Forms.TextBox();
            this.StoppingCriteria_label = new System.Windows.Forms.Label();
            this.probWait_textbox = new System.Windows.Forms.TextBox();
            this.SelectionMethod_label = new System.Windows.Forms.Label();
            this.maxLength_textbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(289, 30);
            this.label3.TabIndex = 22;
            this.label3.Text = "Average Waiting Time:";
            // 
            // AvgWait_textbox
            // 
            this.AvgWait_textbox.BackColor = System.Drawing.Color.White;
            this.AvgWait_textbox.Enabled = false;
            this.AvgWait_textbox.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvgWait_textbox.ForeColor = System.Drawing.Color.Gray;
            this.AvgWait_textbox.Location = new System.Drawing.Point(450, 29);
            this.AvgWait_textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AvgWait_textbox.Name = "AvgWait_textbox";
            this.AvgWait_textbox.Size = new System.Drawing.Size(220, 31);
            this.AvgWait_textbox.TabIndex = 21;
            // 
            // StoppingCriteria_label
            // 
            this.StoppingCriteria_label.BackColor = System.Drawing.Color.Black;
            this.StoppingCriteria_label.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StoppingCriteria_label.Location = new System.Drawing.Point(32, 95);
            this.StoppingCriteria_label.Name = "StoppingCriteria_label";
            this.StoppingCriteria_label.Size = new System.Drawing.Size(289, 30);
            this.StoppingCriteria_label.TabIndex = 20;
            this.StoppingCriteria_label.Text = "Probability of Wait:";
            // 
            // probWait_textbox
            // 
            this.probWait_textbox.BackColor = System.Drawing.Color.White;
            this.probWait_textbox.Enabled = false;
            this.probWait_textbox.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.probWait_textbox.ForeColor = System.Drawing.Color.Gray;
            this.probWait_textbox.Location = new System.Drawing.Point(450, 92);
            this.probWait_textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.probWait_textbox.Name = "probWait_textbox";
            this.probWait_textbox.Size = new System.Drawing.Size(220, 31);
            this.probWait_textbox.TabIndex = 19;
            // 
            // SelectionMethod_label
            // 
            this.SelectionMethod_label.BackColor = System.Drawing.Color.Black;
            this.SelectionMethod_label.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectionMethod_label.Location = new System.Drawing.Point(32, 166);
            this.SelectionMethod_label.Name = "SelectionMethod_label";
            this.SelectionMethod_label.Size = new System.Drawing.Size(468, 30);
            this.SelectionMethod_label.TabIndex = 18;
            this.SelectionMethod_label.Text = "Maximum Queue length during Runtime:";
            // 
            // maxLength_textbox
            // 
            this.maxLength_textbox.BackColor = System.Drawing.Color.White;
            this.maxLength_textbox.Enabled = false;
            this.maxLength_textbox.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxLength_textbox.ForeColor = System.Drawing.Color.Gray;
            this.maxLength_textbox.Location = new System.Drawing.Point(594, 164);
            this.maxLength_textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maxLength_textbox.Name = "maxLength_textbox";
            this.maxLength_textbox.Size = new System.Drawing.Size(220, 31);
            this.maxLength_textbox.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(56, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(581, 42);
            this.label2.TabIndex = 16;
            this.label2.Text = "Performance Measures of System";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepPink;
            this.panel1.Controls.Add(this.StoppingCriteria_label);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.maxLength_textbox);
            this.panel1.Controls.Add(this.AvgWait_textbox);
            this.panel1.Controls.Add(this.SelectionMethod_label);
            this.panel1.Controls.Add(this.probWait_textbox);
            this.panel1.Location = new System.Drawing.Point(63, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(828, 243);
            this.panel1.TabIndex = 23;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(1482, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(237, 49);
            this.button1.TabIndex = 24;
            this.button1.Text = "Show Graphs";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PerformanceMeasuresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(1849, 790);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PerformanceMeasuresForm";
            this.Text = "PerformanceMeasuresForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PerformanceMeasuresForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox AvgWait_textbox;
        private System.Windows.Forms.Label StoppingCriteria_label;
        private System.Windows.Forms.TextBox probWait_textbox;
        private System.Windows.Forms.Label SelectionMethod_label;
        private System.Windows.Forms.TextBox maxLength_textbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
    }
}