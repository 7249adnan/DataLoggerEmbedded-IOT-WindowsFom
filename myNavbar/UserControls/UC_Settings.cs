using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Configuration;
using System.Xml.Linq;
using System.IO.Ports;
using System.Management;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using LibUsbDotNet.Main;
using System.Security.Cryptography;
using LibUsbDotNet;
using System.Text.RegularExpressions;
using System.Data.Entity.Infrastructure;
using System.IO;

namespace myNavbar.UserControls
{

    public partial class UC_Settings : UserControl
    {
        int previous_btn_Count = 0;
        int ChannelsTextBoxMaxLength = 0;
        int ChannelsTextBoxMinCount = 0;
        int ChannelsTextBoxMaxCount = 0;
        String Lic_Key = "abcd1234";
        bool channelTableExists = false;
        string connectionString = $"Data Source=datalogger.db;Version=3;";        
        string[] arrPortNumber = new string[20];

        bool LogoImageLoaded=false;
        string loadedFileName = "";
        byte[] loadedFileData = null;
        private void disabled_Setting()
        {
            panel_Basic.Enabled = false;
            panel_Channels.Enabled = false;
            panel_Channels_Ctrl.Enabled = false;
        }
        private void enabled_Setting()
        {
            panel_Basic.Enabled = true;
            panel_Channels.Enabled = true;
            panel_Channels_Ctrl.Enabled = true;
        }

        public UC_Settings()
        {
            InitializeComponent();
            ReadHardwareData();
            ChannelsTextBoxMaxLength = int.Parse(WebConfigurationManager.AppSettings["ChannelsTextBoxMaxLength"]);
            ChannelsTextBoxMinCount = int.Parse(WebConfigurationManager.AppSettings["ChannelsTextBoxMinCount"]);
            ChannelsTextBoxMaxCount = int.Parse(WebConfigurationManager.AppSettings["ChannelsTextBoxMaxCount"]);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font; // Optional, for DPI scaling
            this.AutoScroll = true;

            panel_Channels.AutoScroll = true;

            comboBoxCommType.SelectedIndex = 0;
            comboBoxBoudRate.SelectedIndex = 6;
            comboBoxBitSize.SelectedIndex = 3;
            comboBoxParity.SelectedIndex = 0;
            comboBoxStopBit.SelectedIndex = 1;

            if (checkTableExists("ChannelData"))
            {
                channelTableExists = true;
                createExsistChannelTable();
            }
            UpdateSettingsOnload();
            disabled_Setting();

        }
        
        private void UpdateSettingsOnload()
        {
            if (checkTableExists("CommSettings"))
            {
                string[] Data= Global.GetLastRow("CommSettings");

                txtCompanyName.Text = Data[1]; 
                txtCompanyPhone.Text = Data[2];
                txtCompanyEmail.Text = Data[3];
                comboBoxCommType.SelectedItem= Data[6]; 
                comboBoxBoudRate.SelectedItem= Data[7]; 
                comboBoxParity.SelectedItem= Data[8]; 
                comboBoxBitSize.SelectedItem= Data[9]; 
                comboBoxStopBit.SelectedItem= Data[10]; 

                loadedFileName = Data[4];
                loadedFileData = null;

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand("SELECT FileData FROM CommSettings WHERE FileName = @FileName", connection))
                    {
                        command.Parameters.AddWithValue("@FileName", loadedFileName);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                loadedFileData = reader["FileData"] as byte[];
                               
                            }
                        }
                    }
                }

                if (loadedFileData != null)
                {
                    using (MemoryStream ms = new MemoryStream(loadedFileData))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                        LogoImageLoaded = true;
                    }
                }
                else
                {
                    MessageBox.Show("Image not found in database.");
                    LogoImageLoaded=false;
                }

            }
        }
        string imagePath="";
        private void button2_Click(object sender, EventArgs e)
        {
           // OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set filter options and filter index
            ChooseLogoFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.gif;*.png)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG";
            ChooseLogoFileDialog.FilterIndex = 1;

            // Enable multiselect
             ChooseLogoFileDialog.Multiselect = false;

            // Set initial directory
             ChooseLogoFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            // Show the dialog and check if the user selected a file
            if ( ChooseLogoFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                imagePath =  ChooseLogoFileDialog.FileName;                

                // Display the selected image in a PictureBox or perform other operations with the image
                // For example, if you have a PictureBox named pictureBox1:
                pictureBox1.ImageLocation = imagePath;
            }
        }

        private void btnRemoveLogo_Click(object sender, EventArgs e)
        {
            pictureBox1.Image= null;
            LogoImageLoaded=false ;
        }

        /*static string GetPortFullName(string portName)
        {
            string fullName = "Unknown";
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%" + portName + "%'");
                foreach (ManagementObject obj in searcher.Get())
                {                   
                    fullName = obj["Name"].ToString();
                    break;
                }

                // UsbDeviceFinder usbFinder = FindUsbDevice(fullName);
                //MessageBox.Show(usbFinder.Vid.ToString());
              //  MessageBox.Show(fullName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving full name 44 : " + ex.Message);
            }
            return fullName;
        }

        static (string,string) FindUsbDevice(string deviceName)
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%" + deviceName + "%'");
                foreach (ManagementObject obj in searcher.Get())
                {
                    if (obj["HardwareID"] == null)
                        continue;                    

                    string[] hardwareIds = (string[])obj["HardwareID"];

                    // Check if the device is a USB device based on hardware IDs
                    foreach (string hardwareId in hardwareIds)
                    {
                        if (hardwareId.Contains("USB\\"))
                        {
                           
                            // Extract VID and PID from the hardware ID
                            string[] idParts = hardwareId.Split('&');
                            if (idParts.Length > 1)
                            {
                               
                                string[] vidPid = idParts[1].Split('_');
                                if (vidPid.Length > 1)
                                {
                                    //// solve and get vid and pid directly



                                    string vidPart = GetSubstringAfterWord(hardwareId, "VID_", 4); // Extracts "1234"
                                    string pidPart = GetSubstringAfterWord(hardwareId, "PID_", 4); // Extracts "5678"
                                                                    

                                    // Create UsbDeviceFinder
                                    return (vidPart, pidPart);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving USB device: " + ex.Message);
            }

            return (null,null); // USB device not found
        
    }*/

     /*   static string GetSubstringAfterWord(string input, string word, int length)
        {
            int index = input.IndexOf(word);
            if (index != -1)
            {
                int startIndex = index + word.Length;
                if (startIndex + length <= input.Length)
                {
                    return input.Substring(startIndex, length);
                }
            }
            return null; // Return null if the word is not found or if there are not enough characters after the word
        }*/

     /*   private void getPortNumber()
        {
            string[] ports = SerialPort.GetPortNames();

            comboBoxPortNumber.Items.Clear();

            if (ports.Length == 0)
            {               
                comboBoxPortNumber.Items.Add("No Ports are Available");
                comboBoxPortNumber.SelectedIndex = 0;
            }
            else
            { int i = 0;
                foreach (string port in ports)
                {
                    

                    string fullName = GetPortFullName(port);

                     var result = FindUsbDevice(fullName);

                   

                    // ReadHardwareData(result.Item1, result.Item2);

                    *//* MessageBox.Show( usbFinder.SerialNumber);*//*
                    arrPortNumber[i] = port; 
                    i++;

                    comboBoxPortNumber.Items.Add(fullName);
                    comboBoxPortNumber.SelectedIndex = 0;
                }
            }           
           
        }
*/
       /* static string FindComNumber(string text)
        {
            string pattern = @"COM(\d{1,3})\)";
            Match match = Regex.Match(text, pattern, RegexOptions.IgnoreCase);

            if (match.Success)
            {
                return ("COM"+match.Groups[1].Value);
            }
            else
            {
                return null;
            }
        }*/

        private void UC_Settings_Load(object sender, EventArgs e)
        {
          //  getPortNumber();
            
        }

        SerialPort serialPort;
        private void ReadHardwareData()
        {
            timer1.Interval = 2000;
            timer1.Start();
            int st = 1;
            serialPort = new SerialPort {
                PortName = "COM5",
                BaudRate = 9600,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = st==0? StopBits.None : 
                            st == 1? StopBits.One:
                            st == 2? StopBits.Two:
                            StopBits.OnePointFive
            };

            try
            {
               
                if( ! serialPort.IsOpen )
                {
                    serialPort.Close();
                }
                else
                {
                    serialPort.Open();
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine("Unable to open COM port - check it's not in use.");
            }

            /*  UsbDeviceFinder usbFinder = new UsbDeviceFinder(1234, 5678); // Example vendor and product IDs
              UsbDevice usbDevice = UsbDevice.OpenUsbDevice(usbFinder);

              if (usbDevice == null)
              {
                  Console.WriteLine("USB device not found.");
                  return;
              }

              // Open endpoint for reading
              UsbEndpointReader reader = usbDevice.OpenEndpointReader(ReadEndpointID.Ep01);

              // Read data
              byte[] readBuffer = new byte[1024];
              int bytesRead;

              reader.Read(readBuffer, 1000, out bytesRead);

              Console.WriteLine($"Read {bytesRead} bytes.");

              // Close USB device
              usbDevice.Close();*/
        }

        String demoStr = "";

        private void timer1_Tick(object sender, EventArgs e)
        {

           /* textTest.Text = " adadasd";
           
            bool haveTemperature = false;
            string temperature = string.Empty;
           
            while (!haveTemperature)
            {
                temperature = serialPort.ReadLine();
                if (!string.IsNullOrEmpty(temperature))
                {
                    haveTemperature = true;
                }
            }

            if (haveTemperature)
            {
                demoStr = demoStr + "Data : " + temperature + Environment.NewLine;
                textTest.Text = demoStr;
            }*/

        }


       /* private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string inData = sp.ReadExisting();
            Console.WriteLine("Data Received:");
            Console.Write(inData);
        }*/


        private void comboBoxCommType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void deleteCreatedChannels()
        {
            for (int i = 0; i < previous_btn_Count; i++)
            {
                string labelName = "Channel" + i;
                Control labelToRemove = panel_Channels.Controls.Find(labelName, true).FirstOrDefault();
                panel_Channels.Controls.Remove(labelToRemove);
                labelToRemove.Dispose();

                string textBoxName = "textBox" + i;
                Control textBoxToRemove = panel_Channels.Controls.Find(textBoxName, true).FirstOrDefault();
                panel_Channels.Controls.Remove(textBoxToRemove);
                textBoxToRemove.Dispose();

            }
            previous_btn_Count = 0;
        }
         
        private void createDynamicChannels()
        {
            int btn_count;

            if (txtChannelsCount.Text != "")
            {
                btn_count = int.Parse(txtChannelsCount.Text);

                if (btn_count >= ChannelsTextBoxMinCount && btn_count <= ChannelsTextBoxMaxCount)
                {
                    if (previous_btn_Count != 0)
                    {
                        deleteCreatedChannels();
                    }

                    for (int i = 0, j = 0; i < btn_count; i++)
                    {
                        Label label = new Label();
                        TextBox textBox = new TextBox();

                        if (i % 3 == 0)
                        {
                            label.Location = new System.Drawing.Point(20, 150 + j * 90);
                            textBox.Location = new System.Drawing.Point(30, 180 + j * 90);
                        }
                        else if (i % 3 == 1)
                        {
                            label.Location = new System.Drawing.Point(270, 150 + j * 90);
                            textBox.Location = new System.Drawing.Point(280, 180 + j * 90);
                        }
                        else if (i % 3 == 2)
                        {
                            label.Location = new System.Drawing.Point(520, 150 + j * 90);
                            textBox.Location = new System.Drawing.Point(530, 180 + j * 90);
                            j++;
                        }

                        label.Text = "Channel " + (i + 1) + " Name :";
                        label.Name = "Channel" + i;
                        label.Font = new Font(label.Font.FontFamily, 11);
                        label.AutoSize = true;
                        panel_Channels.Controls.Add(label);

                        textBox.Size = new System.Drawing.Size(200, 30);
                        textBox.Name = "textBox" + i;
                        textBox.Font = new Font(textBox.Font.FontFamily, 14);
                        textBox.MaxLength = ChannelsTextBoxMaxLength;
                        panel_Channels.Controls.Add(textBox);

                        previous_btn_Count++;
                    }
                }
                else
                {
                    MessageBox.Show(" Count of Channels Should be Min is " + ChannelsTextBoxMinCount + " and Max is " + ChannelsTextBoxMaxCount, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show(" Plzz Enter a Channel Count  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void btnCreateChannels_Click(object sender, EventArgs e)
        {

            if (channelTableExists)
            {

                DialogResult result = MessageBox.Show(" Do you Want to delete Exsisting channels  and Create New one ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DialogResult resultIn = MessageBox.Show(" Are You Sure ? \n Take All Data Backup by Exporting . \n Once Data Deleted Cannot be Recover !!!  ", "Final Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if(resultIn== DialogResult.Yes)
                    {
                        string connectionString = $"Data Source=datalogger.db;Version=3;";
                        DropTable(connectionString, "ChannelData");
                        DropTable(connectionString, "ChannelHeader");
                        deleteCreatedChannels();
                        createDynamicChannels();
                        channelTableExists = false;
                    }                    
                }
            }
            else
            {
                createDynamicChannels();
            }


        }

        private void txtChannelsCount_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtChannelsCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnCreateChannels_Click(sender, e);
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {                
                e.Handled = true;
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void createNewChannel()
        {
            int check = 0;

            if (previous_btn_Count > 0)
            {
                for (int i = 0; i < previous_btn_Count; i++)
                {
                    string textBoxName = "textBox" + i;
                    string labelName = "Channel" + i;

                    Control[] foundControls = this.Controls.Find(textBoxName, true);
                    Control[] foundControlsLabel = this.Controls.Find(labelName, true);

                    TextBox textBox = (TextBox)foundControls[0];
                    string textBoxText = textBox.Text;

                    Label label = (Label)foundControlsLabel[0];
                    string labelText = label.Text;

                    if (textBoxText == "")
                    {
                        MessageBox.Show(labelText + " Is Empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    check++;
                }

                if (check == previous_btn_Count)
                {
                    createDatabase();
                    channelTableExists = true;

                    MessageBox.Show(" Data Inserted !! ", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(" Please Create Channels First ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void UpdateHeaderById(string connectionString, int id, string newHeaderValue)
        {
            // SQL query to update the header column by ID
            string updateQuery = "UPDATE ChannelHeader SET Header = @NewHeaderValue WHERE Id = @Id";

            try
            {
                // Create a connection to the SQLite database
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Create a command to execute the query
                    using (SQLiteCommand command = new SQLiteCommand(updateQuery, connection))
                    {
                        // Add parameters for the new header value and ID
                        command.Parameters.AddWithValue("@NewHeaderValue", newHeaderValue);
                        command.Parameters.AddWithValue("@Id", id);

                        // Execute the UPDATE query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"Header updated successfully for ID {id}.");
                        }
                        else
                        {
                            Console.WriteLine($"No rows were updated for ID {id}.");
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Global.AppendTextToFile("ErrorLog", " [ " + DateTime.Now + " ]  Error : " + ex.Message);
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void updateExistingChannel()
        {
            int check = 0;

            for (int i = 0; i < previous_btn_Count; i++)
            {
                string textBoxName = "textBox" + i;
                string labelName = "Channel" + i;

                Control[] foundControls = this.Controls.Find(textBoxName, true);
                Control[] foundControlsLabel = this.Controls.Find(labelName, true);

                TextBox textBox = (TextBox)foundControls[0];
                string textBoxText = textBox.Text;

                Label label = (Label)foundControlsLabel[0];
                string labelText = label.Text;

                if (textBoxText == "")
                {
                    MessageBox.Show(labelText + " Is Empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                check++;
            }

            if (check == previous_btn_Count)
            {
                
                for (int i = 1; i <= previous_btn_Count; i++)
                {
                    string textBoxName = "textBox" + (i-1);  
                    Control[] foundControls = this.Controls.Find(textBoxName, true);  
                    TextBox textBox = (TextBox)foundControls[0];                    

                    UpdateHeaderById($"Data Source=datalogger.db;Version=3;", i, textBox.Text);
                }
                MessageBox.Show(" Data Inserted !! ", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSaveChannels_Click(object sender, EventArgs e)
        {
            if (channelTableExists)
            {
                updateExistingChannel();
            }
            else
            {
                createNewChannel();
            }


        }

        private void DropTable(string connectionString, string tableName)
        {
            // SQL query to drop the table
            string dropTableQuery = $"DROP TABLE IF EXISTS {tableName}";

            try
            {
                // Create a connection to the SQLite database
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Create a command to execute the query
                    using (SQLiteCommand command = new SQLiteCommand(dropTableQuery, connection))
                    {
                        // Execute the DROP TABLE query
                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }

                Console.WriteLine($"Table '{tableName}' dropped successfully.");
            }
            catch (Exception ex)
            {
                Global.AppendTextToFile("ErrorLog", " [ " + DateTime.Now + " ]  Error : " + ex.Message);
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void btnCancelChanels_Click(object sender, EventArgs e)
        {
           DialogResult result= MessageBox.Show(" Do you Want to delete All Created channels ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(result== DialogResult.Yes)
            {
                if (channelTableExists)
                {
                    string connectionString = $"Data Source=datalogger.db;Version=3;";
                    DropTable(connectionString, "ChannelData");
                    DropTable(connectionString, "ChannelHeader");
                    deleteCreatedChannels();
                    channelTableExists = false;
                }
                else
                {
                    deleteCreatedChannels();
                }
                
            }

        }

        private void createDatabase()
        {
            try
            {              
                string connectionString = $"Data Source=datalogger.db;Version=3;";

                String channelCountStr = "";

                for (int i = 0; i < previous_btn_Count; i++)
                {
                    channelCountStr = channelCountStr + "channel" + i+ ",";  
                }

                
                
                string createTableQueryBatchInfo = @"CREATE TABLE IF NOT EXISTS BatchInfo (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                BatchName Text,
                                BatchNumber TEXT,
                                StartTime DATETIME,
                                SupervisorName TEXT,
                                PortNumber TEXT
                            );";


                string createTableQueryChannelData = $@"CREATE TABLE IF NOT EXISTS ChannelData (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                TimeStamp DATETIME DEFAULT CURRENT_TIMESTAMP,
                                BatchId INTEGER, 
                                {channelCountStr}
                                FOREIGN KEY(BatchId) REFERENCES BatchInfo(Id)
                            );";

                string createTableQueryChannelHeader = $@"CREATE TABLE IF NOT EXISTS ChannelHeader  (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                 Header Text
                            );";

                string insertHeaderQuery = @"INSERT INTO ChannelHeader (Header) VALUES (@Header)";



                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();                   

                    using (SQLiteCommand command = new SQLiteCommand(createTableQueryBatchInfo, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    using (SQLiteCommand command = new SQLiteCommand(createTableQueryChannelData, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    using (SQLiteCommand command = new SQLiteCommand(createTableQueryChannelHeader, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                   

                    for (int i = 0; i < previous_btn_Count; i++) {

                        string textBoxName = "textBox" + i;
                        Control textBox = panel_Channels.Controls.Find(textBoxName, true).FirstOrDefault();
                      
                        using (SQLiteCommand command = new SQLiteCommand(insertHeaderQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Header", textBox.Text);
                            command.ExecuteNonQuery();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Global.AppendTextToFile("ErrorLog", " [ " + DateTime.Now + " ]  Error : " + ex.Message);
                MessageBox.Show("Error2: " + ex.Message);
            }

        }

        private string[] FetchHeaders(string connectionString)
        {
            // SQL query to select all data from the Header column
            string selectDataQuery = "SELECT Header FROM ChannelHeader";

            try
            {
                List<string> headers = new List<string>();

                // Create a connection to the SQLite database
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Create a command to execute the query
                    using (SQLiteCommand command = new SQLiteCommand(selectDataQuery, connection))
                    {
                        // Execute the query and read the result
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            // Iterate through the result set and add headers to the list
                            while (reader.Read())
                            {
                                string header = reader.GetString(0);
                                headers.Add(header);
                            }
                        }
                    }

                    connection.Close();
                }

                // Convert list to array and return
                return headers.ToArray();
            }
            catch (Exception ex)
            {
                Global.AppendTextToFile("ErrorLog", " [ " + DateTime.Now + " ]  Error : " + ex.Message);
                Console.WriteLine("Error: " + ex.Message);
                return new string[0]; // Return an empty array in case of an error
            }
        }

        private void createExsistChannelTable()
        {
            string connectionString = $"Data Source=datalogger.db;Version=3;";
            string[] headers = FetchHeaders(connectionString); 


            // read last code from chatgpt to read string header array 
            previous_btn_Count = 0;
            int count=headers.Length;

            for (int i = 0, j = 0; i < count; i++)
            {
                Label label = new Label();
                TextBox textBox = new TextBox();

                if (i % 3 == 0)
                {
                    label.Location = new System.Drawing.Point(20, 150 + j * 90);
                    textBox.Location = new System.Drawing.Point(30, 180 + j * 90);
                }
                else if (i % 3 == 1)
                {
                    label.Location = new System.Drawing.Point(270, 150 + j * 90);
                    textBox.Location = new System.Drawing.Point(280, 180 + j * 90);
                }
                else if (i % 3 == 2)
                {
                    label.Location = new System.Drawing.Point(520, 150 + j * 90);
                    textBox.Location = new System.Drawing.Point(530, 180 + j * 90);
                    j++;
                }

                label.Text = "Channel " + (i + 1) + " Name :";
                label.Name = "Channel" + i;
                label.Font = new Font(label.Font.FontFamily, 11);
                label.AutoSize = true;
                panel_Channels.Controls.Add(label);

                textBox.Size = new System.Drawing.Size(200, 30);
                textBox.Name = "textBox" + i;
                textBox.Text = headers[i];
                textBox.Font = new Font(textBox.Font.FontFamily, 14);
                textBox.MaxLength = ChannelsTextBoxMaxLength;
                panel_Channels.Controls.Add(textBox);

                previous_btn_Count++;
            }

        }



        private Boolean checkTableExists(string tableName) {

            //string tableName = "ChannelData";          
            
            int count = 0;

            string query = "SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name=@TableName";

            try
            {                
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {                       
                        command.Parameters.AddWithValue("@TableName", tableName);                       
                        count = Convert.ToInt32(command.ExecuteScalar());
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Global.AppendTextToFile("ErrorLog", " [ " + DateTime.Now + " ]  Error : " + ex.Message);
                Console.WriteLine("Error: " + ex.Message);
            }
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void btnLicValidate_Click(object sender, EventArgs e)
        {
            
            if (Lic_Key == txtLicKey.Text)
            {
               enabled_Setting();
               MessageBox.Show("Verification :  Valid License Key ", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show(" Invalid License Key ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshPortNumber_Click(object sender, EventArgs e)
        {
           // getPortNumber();
        }

        private void comboBoxPortNumber_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void InsertCommSettings()
        {
            int val = 1;

            byte[] fileData= { };
            string fileName = "";

            string filePath = imagePath;            
            
            
            if(imagePath!="" || !LogoImageLoaded)
            {

                if (File.Exists(filePath))
                {
                    loadedFileData = File.ReadAllBytes(filePath);
                    loadedFileName = Path.GetFileName(filePath);
                }
                else
                {                   
                    MessageBox.Show("Choose Image File Properly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    val = 0;
                }
            }
            else if (txtCompanyName.Text == string.Empty)
            {
                MessageBox.Show("Enter Company Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                val = 0;
            }
            else if (txtCompanyPhone.Text == string.Empty)
            {
                MessageBox.Show("Enter Company Mobile No ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                val = 0;
            }
            else if (txtCompanyEmail.Text == string.Empty)
            {
                MessageBox.Show("Enter Company Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                val = 0;
            }


            //MIS INNOVATE PVT LTD
            //+91 2345678340  / +91 2345678388
            //misinnovate@gmail.com

            if (val == 1) {

                try {                     

                string companyName=txtCompanyName.Text;
                string companyPhone = txtCompanyPhone.Text;
                string companyEmail = txtCompanyEmail.Text;
                string commType= comboBoxCommType.SelectedItem.ToString();
                string baudRate= comboBoxBoudRate.SelectedItem.ToString(); 
                string parity= comboBoxParity.SelectedItem.ToString();
                string dataBits = comboBoxBitSize.SelectedItem.ToString();
                string stopBits = comboBoxStopBit.SelectedItem.ToString();

               // MessageBox.Show(commType+baudRate+parity+dataBits+stopBits);    

                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string dropCommSettings = "DROP TABLE IF EXISTS CommSettings";
                    using (SQLiteCommand command = new SQLiteCommand(dropCommSettings, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    string createTableCommSettings = @"CREATE TABLE IF NOT EXISTS CommSettings (
                                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    CompanyName TEXT, 
                                    CompanyPhone TEXT,
                                    CompanyEmail TEXT,
                                    FileName TEXT,
                                    FileData BLOB,
                                    CommType TEXT,                                                       
                                    BaudRate TEXT,
                                    ParityCheck TEXT,
                                    DataBits TEXT,
                                    StopBits TEXT
                                );";
                    using (SQLiteCommand command = new SQLiteCommand(createTableCommSettings, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    string insertCommSettingsQuery = @"INSERT INTO CommSettings (
                    CompanyName,
                    CompanyPhone,
                    CompanyEmail,
                    FileName,
                    FileData,
                    CommType,                             
                    BaudRate,
                    ParityCheck,
                    DataBits,
                    StopBits
                ) VALUES (
                    @CompanyName,
                    @CompanyPhone,
                    @CompanyEmail,
                    @FileName,
                    @FileData,
                    @CommType,                            
                    @BaudRate,
                    @ParityCheck,
                    @DataBits,
                    @StopBits
                );";
                    using (var command = new SQLiteCommand(insertCommSettingsQuery, connection))
                    {

                        command.Parameters.AddWithValue("@CompanyName",companyName );
                        command.Parameters.AddWithValue("@CompanyPhone",companyPhone);
                        command.Parameters.AddWithValue("@CompanyEmail",companyEmail);
                        command.Parameters.AddWithValue("@FileName", loadedFileName);
                        command.Parameters.AddWithValue("@FileData", loadedFileData);
                        command.Parameters.AddWithValue("@CommType", commType);                                     
                        command.Parameters.AddWithValue("@BaudRate", baudRate);
                        command.Parameters.AddWithValue("@ParityCheck",parity);
                        command.Parameters.AddWithValue("@DataBits", dataBits);
                        command.Parameters.AddWithValue("@StopBits", stopBits);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show(" Settings Saved Succesfully ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (Exception ex) {

                    MessageBox.Show(ex.Message);
                }

            }

        }

        

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            InsertCommSettings();

        }
    }
    
}
