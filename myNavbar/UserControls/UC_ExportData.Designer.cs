namespace myNavbar.UserControls
{
    partial class UC_ExportData
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFindBatch = new System.Windows.Forms.Button();
            this.DateFindBy = new System.Windows.Forms.DateTimePicker();
            this.txtFindBy = new System.Windows.Forms.TextBox();
            this.comboBoxFindBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.existingPanel = new System.Windows.Forms.Panel();
            this.btnBackup = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnBackup);
            this.panel1.Controls.Add(this.btnFindBatch);
            this.panel1.Controls.Add(this.DateFindBy);
            this.panel1.Controls.Add(this.txtFindBy);
            this.panel1.Controls.Add(this.comboBoxFindBy);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(44, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1006, 93);
            this.panel1.TabIndex = 1;
            // 
            // btnFindBatch
            // 
            this.btnFindBatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnFindBatch.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindBatch.ForeColor = System.Drawing.Color.White;
            this.btnFindBatch.Location = new System.Drawing.Point(713, 24);
            this.btnFindBatch.Name = "btnFindBatch";
            this.btnFindBatch.Size = new System.Drawing.Size(118, 42);
            this.btnFindBatch.TabIndex = 5;
            this.btnFindBatch.Text = "Search";
            this.btnFindBatch.UseVisualStyleBackColor = false;
            this.btnFindBatch.Click += new System.EventHandler(this.btnFindBatch_Click);
            // 
            // DateFindBy
            // 
            this.DateFindBy.CustomFormat = "  dd / MM / yyyy";
            this.DateFindBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateFindBy.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateFindBy.Location = new System.Drawing.Point(450, 34);
            this.DateFindBy.Name = "DateFindBy";
            this.DateFindBy.Size = new System.Drawing.Size(238, 26);
            this.DateFindBy.TabIndex = 30;
            this.DateFindBy.ValueChanged += new System.EventHandler(this.DateFindBy_ValueChanged);
            // 
            // txtFindBy
            // 
            this.txtFindBy.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFindBy.Location = new System.Drawing.Point(450, 32);
            this.txtFindBy.Name = "txtFindBy";
            this.txtFindBy.Size = new System.Drawing.Size(238, 27);
            this.txtFindBy.TabIndex = 2;
            this.txtFindBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFindBy_KeyDown);
            this.txtFindBy.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFindBy_KeyUp);
            // 
            // comboBoxFindBy
            // 
            this.comboBoxFindBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFindBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFindBy.FormattingEnabled = true;
            this.comboBoxFindBy.ItemHeight = 20;
            this.comboBoxFindBy.Items.AddRange(new object[] {
            "Batch Number",
            "Batch Name",
            "Start Date"});
            this.comboBoxFindBy.Location = new System.Drawing.Point(223, 32);
            this.comboBoxFindBy.Name = "comboBoxFindBy";
            this.comboBoxFindBy.Size = new System.Drawing.Size(205, 28);
            this.comboBoxFindBy.TabIndex = 1;
            this.comboBoxFindBy.SelectedIndexChanged += new System.EventHandler(this.comboBoxFindBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Find Channel Data  By  :  ";
            // 
            // existingPanel
            // 
            this.existingPanel.AutoScroll = true;
            this.existingPanel.BackColor = System.Drawing.Color.White;
            this.existingPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.existingPanel.Location = new System.Drawing.Point(44, 137);
            this.existingPanel.Name = "existingPanel";
            this.existingPanel.Size = new System.Drawing.Size(1006, 760);
            this.existingPanel.TabIndex = 3;
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.Color.Red;
            this.btnBackup.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup.ForeColor = System.Drawing.Color.White;
            this.btnBackup.Location = new System.Drawing.Point(855, 24);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(118, 42);
            this.btnBackup.TabIndex = 31;
            this.btnBackup.Text = "BACK UP";
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // UC_ExportData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.existingPanel);
            this.Controls.Add(this.panel1);
            this.Name = "UC_ExportData";
            this.Size = new System.Drawing.Size(1489, 900);
            this.Load += new System.EventHandler(this.UC_ExportData_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxFindBy;
        private System.Windows.Forms.TextBox txtFindBy;
        private System.Windows.Forms.Button btnFindBatch;
        private System.Windows.Forms.DateTimePicker DateFindBy;
        private System.Windows.Forms.Panel existingPanel;
        private System.Windows.Forms.Button btnBackup;
    }
}
