using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Management;

namespace myNavbar.UserControls
{
    public partial class StartProcessModalForm : Form
    {
        public StartProcessModalForm()
        {
            InitializeComponent();
        }

        int selected = 0;

        private void btnCancelBatch_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string[] GetLastRow(string tableName)
        {
            string[] lastRow = null;
            string connectionString = $"Data Source=datalogger.db;Version=3;";

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT * FROM {tableName} ORDER BY ROWID DESC LIMIT 1;";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int fieldCount = reader.FieldCount;
                        lastRow = new string[fieldCount];

                        for (int i = 0; i < fieldCount; i++)
                        {
                            lastRow[i] = reader[i].ToString();
                        }
                    }
                }
            }

            return lastRow;
        }


        private void btnSaveBatch_Click(object sender, EventArgs e)
        {
            int test = 0;

           

            if (txtBatchName.Text.Length == 0)
            {
                MessageBox.Show(" Enter a Batch Name ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                test = 1;
            }
            else if (txtBatchNumber.Text.Length == 0)
            {
                MessageBox.Show(" Enter a Batch Number ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                test = 1;
            }
            else if (txtSupervisorName.Text.Length == 0)
            {
                MessageBox.Show(" Enter a Batch Supervisor Name ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                test = 1;
            }
            else if (comboBoxPortNumber.SelectedItem.ToString() == "No Ports are Available")
            {
                MessageBox.Show(" Please Connected and Select a Port Number ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                test = 1;
            }
            else if (comboBoxPortNumber.SelectedItem.ToString() != "No Ports are Available")
            {               
                try
                {
                    string[] arr = GetLastRow("CommSettings");

                    Global._serialPort.BaudRate = int.Parse(arr[7]);

                    Global._serialPort.Parity = arr[8] == "None" ? Parity.None :
                                                arr[8] == "Odd" ? Parity.Odd :
                                                arr[8] == "Even" ? Parity.Even :
                                                arr[8] == "Mark" ? Parity.Mark :
                                                arr[8] == "Space" ? Parity.Space :
                                                Parity.None;

                    Global._serialPort.DataBits = int.Parse(arr[9]);

                    Global._serialPort.StopBits = arr[10] == "None" ? StopBits.None :
                                                    arr[10] == "1" ? StopBits.One :
                                                    arr[10] == "1.5" ? StopBits.OnePointFive :
                                                    arr[10] == "2" ? StopBits.Two :
                                                    StopBits.None;

                  //  MessageBox.Show(Global._serialPort.BaudRate.ToString() + " " + Global._serialPort.Parity + " " + Global._serialPort.DataBits + " " + Global._serialPort.StopBits);

                    if (Global.StartPortReading() != 1)
                    {                        
                        test = 1;
                    }
                }
                catch (Exception ex)
                {
                    test = 1;
                    MessageBox.Show("ComPort Setting Error : " + ex.Message + "\n Go to --> Setting --> Change Serial Port Parameters ");
                    Global.AppendTextToFile("ErrorLog", " [ " + DateTime.Now + " ]  Error : " + ex.Message);

                }
            }
            

            


            if (test == 0)
            {
                
                try
                {
                    // Connection string for SQLite database
                    string connectionString = $"Data Source=datalogger.db;Version=3;";

                    // SQL command to insert data
                    string sql = "INSERT INTO BatchInfo (BatchName, BatchNumber, StartTime,SupervisorName,PortNumber) VALUES (@Value1, @Value2, @Value3 ,@Value4 , @PortNumber)";

                    DateTime startDateValue = DateTime.Parse(startDate.Text);
                    DateTime startTimeValue = DateTime.Parse(startTime.Text);
                    DateTime combinedDateTime = startDateValue.Date + startTimeValue.TimeOfDay;

                    // Values to insert
                    string value1 = txtBatchName.Text;
                    string value2 = txtBatchNumber.Text;
                    DateTime value3 = combinedDateTime;
                    string value4 = txtSupervisorName.Text;
                    string PortNumber = FindComNumber(comboBoxPortNumber.SelectedItem.ToString());


                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();
                        using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                        {
                            // Add parameters
                            command.Parameters.AddWithValue("@Value1", value1);
                            command.Parameters.AddWithValue("@Value2", value2);
                            command.Parameters.AddWithValue("@Value3", value3);
                            command.Parameters.AddWithValue("@Value4", value4);
                            command.Parameters.AddWithValue("@PortNumber", PortNumber);


                            // Execute the command
                            command.ExecuteNonQuery(); 
                        }                      
                        Global.BatchId= connection.LastInsertRowId.ToString();                     

                    }                   
                    this.Close();
                    MessageBox.Show(" Batch Details Saved And Reading Started ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   Global.StartProcess = true;

                    Global.PortNumber= PortNumber;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Global.AppendTextToFile("ErrorLog", " [ " + DateTime.Now + " ]  Error : " + ex.Message);

                    Console.WriteLine("An error occurred: " + ex.Message);
                }


            }
        }

        private void StartProcessModalForm_Load(object sender, EventArgs e)
        {
            getPortNumber();
            fillPortNumber();
            selected = 1;
        }

        private void fillPortNumber()
        {
            // Connection string to your SQLite database
            string connectionString = $"Data Source=datalogger.db;Version=3;";

            // SQL command to fetch the last row, assuming there's a column named 'id'
            string sqlCommand = "SELECT * FROM BatchInfo ORDER BY id DESC LIMIT 1";

            // Create a new SQLite connection
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create a new SQLite command
                    using (SQLiteCommand command = new SQLiteCommand(sqlCommand, connection))
                    {
                        // Execute the SQL command and read the result
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Assuming your table has columns named 'id', 'name', and 'value'
                              
                                string OldPortNumber = reader.GetString(reader.GetOrdinal("PortNumber"));
                                                              
                                string[] ports = SerialPort.GetPortNames();                                

                                if (ports.Length == 0)
                                {
                                    comboBoxPortNumber.Items.Add("No Ports are Available");
                                    comboBoxPortNumber.SelectedIndex = 0;
                                }
                                else
                                {
                                    //int i = 0;
                                    for ( int i=0;i< ports.Length;i++)
                                    {                                        
                                        if (ports[i] == OldPortNumber)
                                        {                                           
                                            lblStatus.Text = "Connected Successfully ";
                                            lblStatus.ForeColor = Color.Green;
                                            comboBoxPortNumber.SelectedIndex =i;
                                            Global._serialPort.PortName = ports[i] ;                                           
                                            i++;
                                            break;
                                        }
                                        else
                                        {
                                            lblStatus.Text = "Dissconnected ";
                                            lblStatus.ForeColor = Color.Red;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("No rows found.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Global.AppendTextToFile("ErrorLog", " [ " + DateTime.Now + " ]  Error : " + ex.Message);

                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    // Close the connection
                    connection.Close();
                }
            }

        }

        static string GetPortFullName(string portName)
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
                Global.AppendTextToFile("ErrorLog", " [ " + DateTime.Now + " ]  Error : " + ex.Message);

                MessageBox.Show("Error retrieving full name : " + ex.Message);
            }
            return fullName;
        }


        private void getPortNumber()
        {
            string[] ports = SerialPort.GetPortNames();

            comboBoxPortNumber.Items.Clear();

            if (ports.Length == 0)
            {
                comboBoxPortNumber.Items.Add("No Ports are Available");
                comboBoxPortNumber.SelectedIndex = 0;
            }
            else
            {             
                foreach (string port in ports)
                {
                    string fullName = GetPortFullName(port);                

                    comboBoxPortNumber.Items.Add(fullName);
                    comboBoxPortNumber.SelectedIndex = 0;
                }
                
            }

        }

        static string FindComNumber(string text)
        {
            string pattern = @"COM(\d{1,3})\)";
            Match match = Regex.Match(text, pattern, RegexOptions.IgnoreCase);

            if (match.Success)
            {
                return ("COM" + match.Groups[1].Value);
            }
            else
            {
                return null;
            }
        }

        private void btnRefreshPortNumber_Click(object sender, EventArgs e)
        {
            getPortNumber();
            fillPortNumber();
        }

        private void comboBoxPortNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(selected==1)
            {
                string selected = FindComNumber(comboBoxPortNumber.SelectedItem.ToString());
                Global._serialPort.PortName= selected;               
            }
            
        }

        private void btnTestConn_Click(object sender, EventArgs e)
        {
            if (comboBoxPortNumber.SelectedItem != null)
            {
                string selectedPort = comboBoxPortNumber.SelectedItem.ToString();
                if (IsPortConnected(FindComNumber(selectedPort)))
                {
                    MessageBox.Show($"Port {selectedPort} is connected.","Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblStatus.Text = "Connected Successfully ";
                    lblStatus.ForeColor = Color.Green;
                }
                else
                {
                    MessageBox.Show($"Port {selectedPort} is not connected.", " Failed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblStatus.Text = "Disconnected ";
                    lblStatus.ForeColor = Color.Red;
                }
            }
            else
            {
                MessageBox.Show("Please select a port.");
            }
        }
        private bool IsPortConnected(string portName)
        {
            try
            {
                using (SerialPort port = new SerialPort(portName))
                {
                    port.Open();
                    port.Close();
                    return true;
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
                Global.AppendTextToFile("ErrorLog", " [ " + DateTime.Now + " ]  Error : " + ex.Message);

                return false;
            }
        }
    }
}

