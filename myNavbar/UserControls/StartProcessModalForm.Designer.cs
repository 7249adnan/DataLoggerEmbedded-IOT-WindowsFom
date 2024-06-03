namespace myNavbar.UserControls
{
    partial class StartProcessModalForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartProcessModalForm));
            this.lblBatchHeading = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBatchName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBatchNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSupervisorName = new System.Windows.Forms.TextBox();
            this.btnCancelBatch = new System.Windows.Forms.Button();
            this.btnSaveBatch = new System.Windows.Forms.Button();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.startTime = new System.Windows.Forms.DateTimePicker();
            this.btnRefreshPortNumber = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxPortNumber = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTestConn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBatchHeading
            // 
            this.lblBatchHeading.AutoSize = true;
            this.lblBatchHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatchHeading.Location = new System.Drawing.Point(224, 46);
            this.lblBatchHeading.Name = "lblBatchHeading";
            this.lblBatchHeading.Size = new System.Drawing.Size(260, 33);
            this.lblBatchHeading.TabIndex = 0;
            this.lblBatchHeading.Text = "Batch Information";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(76, 133);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 18);
            this.label5.TabIndex = 6;
            this.label5.Text = "Batch Name";
            // 
            // txtBatchName
            // 
            this.txtBatchName.BackColor = System.Drawing.Color.White;
            this.txtBatchName.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBatchName.Location = new System.Drawing.Point(79, 163);
            this.txtBatchName.MaxLength = 100;
            this.txtBatchName.Name = "txtBatchName";
            this.txtBatchName.Size = new System.Drawing.Size(254, 27);
            this.txtBatchName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(398, 133);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Batch Number";
            // 
            // txtBatchNumber
            // 
            this.txtBatchNumber.BackColor = System.Drawing.Color.White;
            this.txtBatchNumber.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBatchNumber.Location = new System.Drawing.Point(401, 163);
            this.txtBatchNumber.MaxLength = 100;
            this.txtBatchNumber.Name = "txtBatchNumber";
            this.txtBatchNumber.Size = new System.Drawing.Size(254, 27);
            this.txtBatchNumber.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(398, 217);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "Start :  Date / Time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(76, 217);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "Supervisor Name";
            // 
            // txtSupervisorName
            // 
            this.txtSupervisorName.BackColor = System.Drawing.Color.White;
            this.txtSupervisorName.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupervisorName.Location = new System.Drawing.Point(79, 247);
            this.txtSupervisorName.MaxLength = 100;
            this.txtSupervisorName.Name = "txtSupervisorName";
            this.txtSupervisorName.Size = new System.Drawing.Size(254, 27);
            this.txtSupervisorName.TabIndex = 13;
            // 
            // btnCancelBatch
            // 
            this.btnCancelBatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnCancelBatch.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelBatch.ForeColor = System.Drawing.Color.White;
            this.btnCancelBatch.Location = new System.Drawing.Point(253, 440);
            this.btnCancelBatch.Name = "btnCancelBatch";
            this.btnCancelBatch.Size = new System.Drawing.Size(112, 39);
            this.btnCancelBatch.TabIndex = 28;
            this.btnCancelBatch.Text = "Cancel";
            this.btnCancelBatch.UseVisualStyleBackColor = false;
            this.btnCancelBatch.Click += new System.EventHandler(this.btnCancelBatch_Click);
            // 
            // btnSaveBatch
            // 
            this.btnSaveBatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnSaveBatch.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveBatch.ForeColor = System.Drawing.Color.White;
            this.btnSaveBatch.Location = new System.Drawing.Point(381, 440);
            this.btnSaveBatch.Name = "btnSaveBatch";
            this.btnSaveBatch.Size = new System.Drawing.Size(120, 39);
            this.btnSaveBatch.TabIndex = 27;
            this.btnSaveBatch.Text = "Save";
            this.btnSaveBatch.UseVisualStyleBackColor = false;
            this.btnSaveBatch.Click += new System.EventHandler(this.btnSaveBatch_Click);
            // 
            // startDate
            // 
            this.startDate.CustomFormat = "  dd / MM / yyyy";
            this.startDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDate.Location = new System.Drawing.Point(401, 248);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(142, 26);
            this.startDate.TabIndex = 29;
            // 
            // startTime
            // 
            this.startTime.CustomFormat = "  hh : mm  tt";
            this.startTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startTime.Location = new System.Drawing.Point(549, 247);
            this.startTime.Name = "startTime";
            this.startTime.ShowUpDown = true;
            this.startTime.Size = new System.Drawing.Size(130, 26);
            this.startTime.TabIndex = 31;
            // 
            // btnRefreshPortNumber
            // 
            this.btnRefreshPortNumber.ImageIndex = 0;
            this.btnRefreshPortNumber.ImageList = this.imageList1;
            this.btnRefreshPortNumber.Location = new System.Drawing.Point(601, 325);
            this.btnRefreshPortNumber.Name = "btnRefreshPortNumber";
            this.btnRefreshPortNumber.Size = new System.Drawing.Size(33, 28);
            this.btnRefreshPortNumber.TabIndex = 34;
            this.btnRefreshPortNumber.UseVisualStyleBackColor = true;
            this.btnRefreshPortNumber.Click += new System.EventHandler(this.btnRefreshPortNumber_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "refresh.png");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(76, 295);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(168, 18);
            this.label11.TabIndex = 33;
            this.label11.Text = "Select Port Number";
            // 
            // comboBoxPortNumber
            // 
            this.comboBoxPortNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPortNumber.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPortNumber.FormattingEnabled = true;
            this.comboBoxPortNumber.Location = new System.Drawing.Point(79, 327);
            this.comboBoxPortNumber.Name = "comboBoxPortNumber";
            this.comboBoxPortNumber.Size = new System.Drawing.Size(504, 26);
            this.comboBoxPortNumber.TabIndex = 32;
            this.comboBoxPortNumber.SelectedIndexChanged += new System.EventHandler(this.comboBoxPortNumber_SelectedIndexChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(275, 377);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(105, 16);
            this.lblStatus.TabIndex = 35;
            this.lblStatus.Text = "Disconnected";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(220, 377);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 36;
            this.label1.Text = "Status :";
            // 
            // btnTestConn
            // 
            this.btnTestConn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestConn.Location = new System.Drawing.Point(80, 372);
            this.btnTestConn.Name = "btnTestConn";
            this.btnTestConn.Size = new System.Drawing.Size(134, 27);
            this.btnTestConn.TabIndex = 37;
            this.btnTestConn.Text = "Test Connection";
            this.btnTestConn.UseVisualStyleBackColor = true;
            this.btnTestConn.Click += new System.EventHandler(this.btnTestConn_Click);
            // 
            // StartProcessModalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 508);
            this.Controls.Add(this.btnTestConn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnRefreshPortNumber);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboBoxPortNumber);
            this.Controls.Add(this.startTime);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.btnCancelBatch);
            this.Controls.Add(this.btnSaveBatch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSupervisorName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBatchNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBatchName);
            this.Controls.Add(this.lblBatchHeading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartProcessModalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Basic Batch Information";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.StartProcessModalForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBatchHeading;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBatchName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBatchNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSupervisorName;
        private System.Windows.Forms.Button btnCancelBatch;
        private System.Windows.Forms.Button btnSaveBatch;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.DateTimePicker startTime;
        private System.Windows.Forms.Button btnRefreshPortNumber;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxPortNumber;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTestConn;
    }
}