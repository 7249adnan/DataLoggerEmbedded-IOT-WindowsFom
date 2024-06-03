using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using Org.BouncyCastle.Ocsp;
using System.Runtime.CompilerServices;
using System.Data.SQLite;
using System.Xml.Linq;
using Org.BouncyCastle.Asn1.X509;

namespace myNavbar
{

    public static class Global
    {
        public static bool StartProcess { get; set; } = false;
        public static bool PortOpen { get; set; } = false;
        public static int headerLength { get; set; }
        public static string BatchId { get; set; }
        public static String PortNumber { get; set; } = "";

        public static SerialPort serialPort = new SerialPort();

        public static SerialPort _serialPort;
        public static Thread _readThread;
        public static volatile bool _keepReading;
        public static volatile bool _errorShown;

        public static Control control;
        static Global()
        {          
            _serialPort = new SerialPort
            {
                PortName = "COM5", // Set your COM port here
                BaudRate = 9600,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
                Handshake = Handshake.None,
                ReadTimeout = 500,
                WriteTimeout = 500
            };
        }

        private static int inc = 0;
        public static int StatusStartPortReading = 0;      
        public static int StartPortReading()
        {
            
            if (!_serialPort.IsOpen)
            {
                try
                {
                   
                    _serialPort.Open();                    
                    _keepReading = true;
                    _readThread = new Thread(ReadData);
                    _errorShown = false; // Reset error flag
                    _readThread.Start();

                    StatusStartPortReading = 1;
                    //MessageBox.Show("Reading Started From serial Port");

                    return 1;
                }
                catch (Exception ex)
                {
                    StatusStartPortReading = 0;
                    MessageBox.Show($"Error opening serial port : {ex.Message}");
                    AppendTextToFile("ErrorLog", " [ " + DateTime.Now + " ]  Error : " + ex.Message);
                } 
            }
            return 0;
        }

        public static int StopPortReading()
        {
            _keepReading = false;
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
                //MessageBox.Show("Reading Closed From USB Port");
                MessageBox.Show("Reading Closed From USB Port", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return 1;
            }
            return 0;
        }

        private static void ReadData()
        {    
            while (_keepReading)
            {
                try
                {
                    string message = _serialPort.ReadLine();                    
                    control.Invoke(new MethodInvoker(delegate { GetData(message); }));                  
                }
                catch (TimeoutException) { }
                catch (Exception ex)
                {
                  
                    AppendTextToFile("ErrorLog"," [ "+ DateTime.Now+" ]  Error : "  + ex.Message);
                    if (!_errorShown)
                    {
                        _errorShown = true; // Set error flag
                        if (ex.Message != "The I/O operation has been aborted because of either a thread exit or an application request.\r\n" )
                        {
                            if (ex.Message != "Index was outside the bounds of the array.\r\n")
                            {
                                control.Invoke(new MethodInvoker(delegate { MessageBox.Show($"Error reading serial port: {ex.Message}"); }));
                            }
                        }                           
                        else
                        {
                            continue;
                        }
                    }
                }               
            }          
        }

        public static void GetData(String DataLine)
        {
            AppendTextToFile("portdata.txt", DateTime.Now  +" -- " + DataLine);
            string[] strArr= filterByCommaSeprating(DataLine);
            InsertUser(strArr);
           // AppendTextToFile("portdata.txt", strArr[0] + " " +strArr[1] + " " + strArr[2] + " " + strArr[3] );
        }

        static void InsertUser( string[] strData)
        {   
            string connectionString = $"Data Source=datalogger.db;Version=3;";

            string [] header= FetchHeaders();
            headerLength= header.Length;

            string insertQuery="";           

            if (strData.Length <= headerLength)
            {  
                 insertQuery = $"INSERT INTO ChannelData (BatchId";
            
                for (int i = 0; i < strData.Length; i++)
                {
                    insertQuery = insertQuery + ",channel" + i;
                }
                insertQuery = insertQuery + $") VALUES ( '{BatchId}',";

                for (int i = 0; i < strData.Length; i++)
                {
                    if (strData.Length-1 == i)
                    {
                        insertQuery = insertQuery + $"'{strData[i]}'";
                    }
                    else
                    {
                        insertQuery = insertQuery + $"'{strData[i]} ',";
                    }
                }

                insertQuery = insertQuery + ")";
            }
            else
            {
                insertQuery = $"INSERT INTO ChannelData (BatchId";

                for (int i = 0; i < headerLength; i++)
                {
                    insertQuery = insertQuery + ",channel" + i;
                }
                insertQuery = insertQuery + $") VALUES ( '{BatchId}',";

                for (int i = 0; i < headerLength; i++)
                {
                    if (headerLength - 1 == i)
                    {
                        insertQuery = insertQuery + $"'{strData[i]}'";
                    }
                    else
                    {
                        insertQuery = insertQuery + $"'{strData[i]} ',";
                    }
                }

                insertQuery = insertQuery + ")";
            }

            // MessageBox.Show("in hear er : " + insertQuery);

            using (var connection = new SQLiteConnection(connectionString))
            {

                connection.Open();
                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public static string[] GetLastRow(string tableName)
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

        public static string[] FetchHeaders()
        {
            // SQL query to select all data from the Header column
            string selectDataQuery = "SELECT Header FROM ChannelHeader";

            string connectionString = $"Data Source=datalogger.db;Version=3;";

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
                MessageBox.Show("Error " + ex.Message);
                AppendTextToFile("ErrorLog", " [ " + DateTime.Now + " ]  Error : " + ex.Message);
                return new string[0]; // Return an empty array in case of an error
            }
        }

        public static string[] ReadFromSerialPort()
        {
            try
            {
               
                int hl = 4;

                string[] stringArray = new string[hl + 2];

                stringArray[0] = inc.ToString();
                stringArray[1] = DateTime.Now.ToString();

               var portData = startReading();
                

                if (portData != null)
                {
                    inc++;
                    //String[] DataValue = {"123","456","789","101"};
                    String[] DataValue = filterByCommaSeprating(portData);

                    for (int i = 2; i < hl + 2; i++)
                    {
                        stringArray[i] = DataValue[i - 2];
                    }

                    AppendTextToFile("example.txt", inc.ToString() + "  " + stringArray[0] + "  " + stringArray[1] + "  " + stringArray[2] + "  " + stringArray[3] + "  " + stringArray[4] + "  " + stringArray[5]);
                    return stringArray;
                    
                    // dataGridView1.Rows.Insert(0, stringArray);
                }
            }
            catch (TimeoutException ex)
            {
                // Handle timeout exception if necessary
                MessageBox.Show("Error reading from serial TimeOut port rd 1: " + ex.Message);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error reading from serial port rd 1: " + ex.Message);

            }

             string[] arr = { "111", "222", "333", "444" };

            //return null;
            return arr;
        }

        public static void AppendTextToFile(string filePath, string text)
        {           
            try
            {
                // Check if the file exists
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, text);                   
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(filePath))
                    {
                        sw.WriteLine(text);
                    }                 
                }
            }
            catch (Exception)
            {                
                MessageBox.Show("Cannot Log the Error ");                
            }
        }

        private static String startReading()
        {
            if (serialPort.IsOpen)
            {
                bool havePortData = false;
                string PortData = string.Empty;

                while (!havePortData)
                {
                    PortData = serialPort.ReadLine();
                    AppendTextToFile("example.txt","Serial Port Data "+ inc.ToString() + "  " + PortData);

                    System.Threading.Thread.Sleep(5);
                    if (!string.IsNullOrEmpty(PortData))
                    {
                        havePortData = true;
                    }
                }

                if (havePortData)
                {
                    /*demoStr = demoStr + PortData + Environment.NewLine;
                    textTest.Text = demoStr;*/
                    return PortData;
                }

            }
            return null; // "ABCD1234:channel1=111,channel2=222,channel3=333,channel=444";

        }


        private static string[] filterByCommaSeprating(String rowData)
        {
            string input = rowData;
            string dataPart = input.Substring(input.IndexOf(':') + 1);
            string[] channelData = dataPart.Split(',');

            Dictionary<string, int> channelValues = new Dictionary<string, int>();

            string[] arrData = new string[channelData.Length];         

            foreach (string channel in channelData)
            {
                string[] parts = channel.Split('=');
                string channelName = parts[0].Trim();
                int channelValue = int.Parse(parts[1].Trim());
                channelValues[channelName] = channelValue;
            }

            int i = 0;
            foreach (var kvp in channelValues)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                arrData[i] = kvp.Value.ToString();
                i++;
            }
            return arrData; 

        }


    }
}
