namespace myNavbar.UserControls
{
    partial class UC_Settings
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Settings));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLicValidate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLicKey = new System.Windows.Forms.TextBox();
            this.panel_Basic = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxParity = new System.Windows.Forms.ComboBox();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBoxBitSize = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBoxStopBit = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxBoudRate = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCompanyEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCompanyPhone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRemoveLogo = new System.Windows.Forms.Button();
            this.btnChooseLogo = new System.Windows.Forms.Button();
            this.comboBoxCommType = new System.Windows.Forms.ComboBox();
            this.refresh = new System.Windows.Forms.ImageList(this.components);
            this.ChooseLogoFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel_Channels = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.btnCreateChannels = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtChannelsCount = new System.Windows.Forms.TextBox();
            this.btnSaveChannels = new System.Windows.Forms.Button();
            this.panel_Channels_Ctrl = new System.Windows.Forms.Panel();
            this.btnCancelChanels = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel_Basic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel_Channels.SuspendLayout();
            this.panel_Channels_Ctrl.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Settings";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnLicValidate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtLicKey);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(40, 16);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 182);
            this.panel1.TabIndex = 1;
            // 
            // btnLicValidate
            // 
            this.btnLicValidate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnLicValidate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLicValidate.ForeColor = System.Drawing.Color.White;
            this.btnLicValidate.Location = new System.Drawing.Point(269, 135);
            this.btnLicValidate.Name = "btnLicValidate";
            this.btnLicValidate.Size = new System.Drawing.Size(112, 34);
            this.btnLicValidate.TabIndex = 3;
            this.btnLicValidate.Text = "Validate";
            this.btnLicValidate.UseVisualStyleBackColor = false;
            this.btnLicValidate.Click += new System.EventHandler(this.btnLicValidate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter Licence Key ";
            // 
            // txtLicKey
            // 
            this.txtLicKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.txtLicKey.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLicKey.Location = new System.Drawing.Point(41, 97);
            this.txtLicKey.Name = "txtLicKey";
            this.txtLicKey.PasswordChar = '*';
            this.txtLicKey.Size = new System.Drawing.Size(314, 23);
            this.txtLicKey.TabIndex = 2;
            this.txtLicKey.Text = "abcd1234";
            // 
            // panel_Basic
            // 
            this.panel_Basic.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel_Basic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Basic.Controls.Add(this.label8);
            this.panel_Basic.Controls.Add(this.comboBoxParity);
            this.panel_Basic.Controls.Add(this.btnSaveSettings);
            this.panel_Basic.Controls.Add(this.label14);
            this.panel_Basic.Controls.Add(this.comboBoxBitSize);
            this.panel_Basic.Controls.Add(this.label13);
            this.panel_Basic.Controls.Add(this.comboBoxStopBit);
            this.panel_Basic.Controls.Add(this.label12);
            this.panel_Basic.Controls.Add(this.comboBoxBoudRate);
            this.panel_Basic.Controls.Add(this.label10);
            this.panel_Basic.Controls.Add(this.label9);
            this.panel_Basic.Controls.Add(this.label7);
            this.panel_Basic.Controls.Add(this.txtCompanyEmail);
            this.panel_Basic.Controls.Add(this.label6);
            this.panel_Basic.Controls.Add(this.txtCompanyPhone);
            this.panel_Basic.Controls.Add(this.label5);
            this.panel_Basic.Controls.Add(this.txtCompanyName);
            this.panel_Basic.Controls.Add(this.label4);
            this.panel_Basic.Controls.Add(this.label3);
            this.panel_Basic.Controls.Add(this.pictureBox1);
            this.panel_Basic.Controls.Add(this.btnRemoveLogo);
            this.panel_Basic.Controls.Add(this.btnChooseLogo);
            this.panel_Basic.Controls.Add(this.comboBoxCommType);
            this.panel_Basic.Location = new System.Drawing.Point(40, 221);
            this.panel_Basic.Name = "panel_Basic";
            this.panel_Basic.Size = new System.Drawing.Size(402, 660);
            this.panel_Basic.TabIndex = 2;
            this.panel_Basic.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(201, 440);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 14);
            this.label8.TabIndex = 27;
            this.label8.Text = "Parity Check";
            // 
            // comboBoxParity
            // 
            this.comboBoxParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParity.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxParity.FormattingEnabled = true;
            this.comboBoxParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.comboBoxParity.Location = new System.Drawing.Point(205, 466);
            this.comboBoxParity.Name = "comboBoxParity";
            this.comboBoxParity.Size = new System.Drawing.Size(122, 24);
            this.comboBoxParity.TabIndex = 26;
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnSaveSettings.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveSettings.ForeColor = System.Drawing.Color.White;
            this.btnSaveSettings.Location = new System.Drawing.Point(132, 590);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(91, 33);
            this.btnSaveSettings.TabIndex = 4;
            this.btnSaveSettings.Text = "Save";
            this.btnSaveSettings.UseVisualStyleBackColor = false;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(25, 508);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 14);
            this.label14.TabIndex = 24;
            this.label14.Text = "DataBits Size";
            // 
            // comboBoxBitSize
            // 
            this.comboBoxBitSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBitSize.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxBitSize.FormattingEnabled = true;
            this.comboBoxBitSize.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBoxBitSize.Location = new System.Drawing.Point(28, 534);
            this.comboBoxBitSize.Name = "comboBoxBitSize";
            this.comboBoxBitSize.Size = new System.Drawing.Size(132, 24);
            this.comboBoxBitSize.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(201, 508);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 14);
            this.label13.TabIndex = 22;
            this.label13.Text = "Stop Bits";
            // 
            // comboBoxStopBit
            // 
            this.comboBoxStopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStopBit.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxStopBit.FormattingEnabled = true;
            this.comboBoxStopBit.Items.AddRange(new object[] {
            "None ",
            "1",
            "1.5",
            "2"});
            this.comboBoxStopBit.Location = new System.Drawing.Point(205, 534);
            this.comboBoxStopBit.Name = "comboBoxStopBit";
            this.comboBoxStopBit.Size = new System.Drawing.Size(122, 24);
            this.comboBoxStopBit.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(25, 440);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 14);
            this.label12.TabIndex = 20;
            this.label12.Text = "Baud Rate";
            // 
            // comboBoxBoudRate
            // 
            this.comboBoxBoudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBoudRate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxBoudRate.FormattingEnabled = true;
            this.comboBoxBoudRate.Items.AddRange(new object[] {
            "110",
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "128000",
            "256000"});
            this.comboBoxBoudRate.Location = new System.Drawing.Point(29, 466);
            this.comboBoxBoudRate.Name = "comboBoxBoudRate";
            this.comboBoxBoudRate.Size = new System.Drawing.Size(131, 24);
            this.comboBoxBoudRate.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(15, 367);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(144, 14);
            this.label10.TabIndex = 16;
            this.label10.Text = "Communication Type";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(41, 334);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(267, 3);
            this.label9.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 254);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 14);
            this.label7.TabIndex = 10;
            this.label7.Text = "Company Email";
            // 
            // txtCompanyEmail
            // 
            this.txtCompanyEmail.BackColor = System.Drawing.Color.White;
            this.txtCompanyEmail.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompanyEmail.Location = new System.Drawing.Point(19, 278);
            this.txtCompanyEmail.Name = "txtCompanyEmail";
            this.txtCompanyEmail.Size = new System.Drawing.Size(314, 23);
            this.txtCompanyEmail.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 193);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "Company Phone";
            // 
            // txtCompanyPhone
            // 
            this.txtCompanyPhone.BackColor = System.Drawing.Color.White;
            this.txtCompanyPhone.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompanyPhone.Location = new System.Drawing.Point(18, 217);
            this.txtCompanyPhone.Name = "txtCompanyPhone";
            this.txtCompanyPhone.Size = new System.Drawing.Size(314, 23);
            this.txtCompanyPhone.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 131);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "Company Name";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.BackColor = System.Drawing.Color.White;
            this.txtCompanyName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompanyName.Location = new System.Drawing.Point(18, 155);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(314, 23);
            this.txtCompanyName.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(149, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(217, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Your Photo Should  be in .jpg , .bmp or .png";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(148, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Upload Logo";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(18, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnRemoveLogo
            // 
            this.btnRemoveLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnRemoveLogo.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveLogo.ForeColor = System.Drawing.Color.White;
            this.btnRemoveLogo.Location = new System.Drawing.Point(242, 75);
            this.btnRemoveLogo.Name = "btnRemoveLogo";
            this.btnRemoveLogo.Size = new System.Drawing.Size(85, 34);
            this.btnRemoveLogo.TabIndex = 5;
            this.btnRemoveLogo.Text = "Remove Logo";
            this.btnRemoveLogo.UseVisualStyleBackColor = false;
            this.btnRemoveLogo.Click += new System.EventHandler(this.btnRemoveLogo_Click);
            // 
            // btnChooseLogo
            // 
            this.btnChooseLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(175)))), ((int)(((byte)(102)))));
            this.btnChooseLogo.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseLogo.ForeColor = System.Drawing.Color.White;
            this.btnChooseLogo.Location = new System.Drawing.Point(151, 75);
            this.btnChooseLogo.Name = "btnChooseLogo";
            this.btnChooseLogo.Size = new System.Drawing.Size(85, 34);
            this.btnChooseLogo.TabIndex = 4;
            this.btnChooseLogo.Text = "Choose Logo";
            this.btnChooseLogo.UseVisualStyleBackColor = false;
            this.btnChooseLogo.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBoxCommType
            // 
            this.comboBoxCommType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCommType.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCommType.FormattingEnabled = true;
            this.comboBoxCommType.Items.AddRange(new object[] {
            "USB"});
            this.comboBoxCommType.Location = new System.Drawing.Point(18, 393);
            this.comboBoxCommType.Name = "comboBoxCommType";
            this.comboBoxCommType.Size = new System.Drawing.Size(309, 24);
            this.comboBoxCommType.TabIndex = 15;
            this.comboBoxCommType.SelectedIndexChanged += new System.EventHandler(this.comboBoxCommType_SelectedIndexChanged);
            // 
            // refresh
            // 
            this.refresh.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("refresh.ImageStream")));
            this.refresh.TransparentColor = System.Drawing.Color.Transparent;
            this.refresh.Images.SetKeyName(0, "refresh.png");
            // 
            // ChooseLogoFileDialog
            // 
            this.ChooseLogoFileDialog.FileName = "openFileDialog1";
            // 
            // panel_Channels
            // 
            this.panel_Channels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.panel_Channels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Channels.Controls.Add(this.label16);
            this.panel_Channels.Controls.Add(this.btnCreateChannels);
            this.panel_Channels.Controls.Add(this.label15);
            this.panel_Channels.Controls.Add(this.txtChannelsCount);
            this.panel_Channels.Location = new System.Drawing.Point(576, 37);
            this.panel_Channels.Name = "panel_Channels";
            this.panel_Channels.Size = new System.Drawing.Size(829, 792);
            this.panel_Channels.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Black;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Location = new System.Drawing.Point(49, 100);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(725, 3);
            this.label16.TabIndex = 25;
            // 
            // btnCreateChannels
            // 
            this.btnCreateChannels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnCreateChannels.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateChannels.ForeColor = System.Drawing.Color.White;
            this.btnCreateChannels.Location = new System.Drawing.Point(547, 34);
            this.btnCreateChannels.Name = "btnCreateChannels";
            this.btnCreateChannels.Size = new System.Drawing.Size(116, 33);
            this.btnCreateChannels.TabIndex = 4;
            this.btnCreateChannels.Text = "Create";
            this.btnCreateChannels.UseVisualStyleBackColor = false;
            this.btnCreateChannels.Click += new System.EventHandler(this.btnCreateChannels_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(153, 38);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(203, 23);
            this.label15.TabIndex = 25;
            this.label15.Text = "Channels Count : ";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // txtChannelsCount
            // 
            this.txtChannelsCount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtChannelsCount.BackColor = System.Drawing.Color.White;
            this.txtChannelsCount.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChannelsCount.Location = new System.Drawing.Point(351, 35);
            this.txtChannelsCount.MaxLength = 5;
            this.txtChannelsCount.Name = "txtChannelsCount";
            this.txtChannelsCount.Size = new System.Drawing.Size(190, 31);
            this.txtChannelsCount.TabIndex = 26;
            this.txtChannelsCount.Tag = "";
            this.txtChannelsCount.Text = "8";
            this.txtChannelsCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChannelsCount_KeyPress);
            this.txtChannelsCount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtChannelsCount_KeyUp);
            // 
            // btnSaveChannels
            // 
            this.btnSaveChannels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnSaveChannels.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveChannels.ForeColor = System.Drawing.Color.White;
            this.btnSaveChannels.Location = new System.Drawing.Point(697, 7);
            this.btnSaveChannels.Name = "btnSaveChannels";
            this.btnSaveChannels.Size = new System.Drawing.Size(91, 33);
            this.btnSaveChannels.TabIndex = 25;
            this.btnSaveChannels.Text = "Save";
            this.btnSaveChannels.UseVisualStyleBackColor = false;
            this.btnSaveChannels.Click += new System.EventHandler(this.btnSaveChannels_Click);
            // 
            // panel_Channels_Ctrl
            // 
            this.panel_Channels_Ctrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Channels_Ctrl.Controls.Add(this.btnCancelChanels);
            this.panel_Channels_Ctrl.Controls.Add(this.btnSaveChannels);
            this.panel_Channels_Ctrl.Location = new System.Drawing.Point(576, 827);
            this.panel_Channels_Ctrl.Name = "panel_Channels_Ctrl";
            this.panel_Channels_Ctrl.Size = new System.Drawing.Size(829, 54);
            this.panel_Channels_Ctrl.TabIndex = 4;
            // 
            // btnCancelChanels
            // 
            this.btnCancelChanels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnCancelChanels.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelChanels.ForeColor = System.Drawing.Color.White;
            this.btnCancelChanels.Location = new System.Drawing.Point(586, 7);
            this.btnCancelChanels.Name = "btnCancelChanels";
            this.btnCancelChanels.Size = new System.Drawing.Size(91, 33);
            this.btnCancelChanels.TabIndex = 26;
            this.btnCancelChanels.Text = "Delete";
            this.btnCancelChanels.UseVisualStyleBackColor = false;
            this.btnCancelChanels.Click += new System.EventHandler(this.btnCancelChanels_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // UC_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel_Channels_Ctrl);
            this.Controls.Add(this.panel_Channels);
            this.Controls.Add(this.panel_Basic);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "UC_Settings";
            this.Size = new System.Drawing.Size(1489, 900);
            this.Load += new System.EventHandler(this.UC_Settings_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_Basic.ResumeLayout(false);
            this.panel_Basic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel_Channels.ResumeLayout(false);
            this.panel_Channels.PerformLayout();
            this.panel_Channels_Ctrl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLicKey;
        private System.Windows.Forms.Button btnLicValidate;
        private System.Windows.Forms.Panel panel_Basic;
        private System.Windows.Forms.Button btnChooseLogo;
        private System.Windows.Forms.OpenFileDialog ChooseLogoFileDialog;
        private System.Windows.Forms.Button btnRemoveLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCompanyEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCompanyPhone;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxCommType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBoxBitSize;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBoxStopBit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxBoudRate;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Panel panel_Channels;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtChannelsCount;
        private System.Windows.Forms.Button btnCreateChannels;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnSaveChannels;
        private System.Windows.Forms.Panel panel_Channels_Ctrl;
        private System.Windows.Forms.Button btnCancelChanels;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ImageList refresh;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxParity;
    }
}
