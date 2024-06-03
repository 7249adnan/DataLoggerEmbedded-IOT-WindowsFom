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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.IO.Ports;
using Org.BouncyCastle.Ocsp;

using ClosedXML.Excel;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Drawing;


namespace myNavbar.UserControls
{
    public partial class UC_Data : UserControl
    {
        public UC_Data()
        {
            InitializeComponent();
            this.AutoScroll = true;           
        }

        private void UC_Data_Load(object sender, EventArgs e)
        {
            Global.control = this;
            if (Global._serialPort.IsOpen)
            {
                TimerFetchData.Start();
                startProcess.Text = " Stop Process";
                startProcess.BackColor = Color.Red;
            }
           
        }

        private void startProcess_Click(object sender, EventArgs e)
        {
            if (Global._serialPort.IsOpen)
            {
                Global.StopPortReading();
                TimerFetchData.Stop();
                startProcess.Text = " Start Process";
                startProcess.BackColor = Color.FromArgb(13, 110, 253); 
                Global.StartProcess = false;

                DialogResult result = MessageBox.Show(" Do you Want to Export Current Channel Data ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ExportLastChannelData();
                }

            }
            else if (!Global._serialPort.IsOpen)
            {
                Form formBackground = new Form();
                try
                {
                    using (StartProcessModalForm uu = new StartProcessModalForm())
                    {
                        formBackground.StartPosition = FormStartPosition.CenterScreen;
                        formBackground.FormBorderStyle = FormBorderStyle.None;
                        formBackground.Opacity = .50d;
                        formBackground.BackColor = Color.Black;
                        formBackground.WindowState = FormWindowState.Maximized;
                        formBackground.TopMost = true;
                        formBackground.Location = this.Location;
                        formBackground.ShowInTaskbar = false;
                        formBackground.Show();

                        uu.Owner = formBackground;
                        uu.ShowDialog();

                        if (Global.StartProcess == true)
                        {                            
                            TimerFetchData.Start();
                            startProcess.Text = " Stop Process";
                            startProcess.BackColor = Color.Red;
                        }
                        /*if (Global.StartProcess == false)
                        {
                            MessageBox.Show("Check the Step up");
                        }*/
                        formBackground.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    Global.AppendTextToFile("ErrorLog", " [ " + DateTime.Now + " ]  Error : " + ex.Message);
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    formBackground.Dispose();
                }
            }
        }


        

        /*  private void StartProcess()
          {          

              string connectionString = $"Data Source=datalogger.db;Version=3;";
              string[] headers = Global.FetchHeaders(connectionString);

              dataGridView1.Columns.Add("No.", "No.");
              dataGridView1.Columns.Add("TimeStamp", "TimeStamp");

              dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
              dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

              dataGridView1.EnableHeadersVisualStyles = false;

              headerLength = headers.Length;
              Global.headerLength= headers.Length;
              for (int i = 0; i < headers.Length; i++)
              {
                  dataGridView1.Columns.Add(headers[i], headers[i]);
              }

          }

          private void InsertData()
          {
              string connectionString = $"Data Source=datalogger.db;Version=3;";

              try
              {
                  using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                  {
                      conn.Open();

                      string queryStr1 = "INSERT INTO ChannelData (Name, Age, Email) VALUES (@name, @age, @Email)";
                      string queryStr = $"INSERT INTO ChannelData ( ";


                      Random random = new Random();

                      String columnNameStr = "";
                      columnNameStr = columnNameStr + "Timestamp ,";
                      for (int i = 0; i < headerLength-1; i++)
                      {
                          //stringArray[i] = random.Next(10000, 100000).ToString();
                          columnNameStr = columnNameStr + "channel" + i + ",";
                      }
                      columnNameStr = columnNameStr + "channel" + (headerLength - 1) ;

                      queryStr = queryStr+ columnNameStr + ") VALUES ( ";

                      String columnValueStr = "";
                      String dateTime = DateTime.Now.ToString();
                      columnValueStr = columnValueStr +"'"+ dateTime +"'"+ ",";

                      for (int i = 0; i < headerLength-1; i++)
                      {
                          columnValueStr = columnValueStr + random.Next(10000, 100000).ToString()+",";
                         // columnNameStr = columnNameStr + "channel" + i + ",";
                      }
                      columnValueStr = columnValueStr + random.Next(10000, 100000).ToString();
                      queryStr = queryStr + columnValueStr + ")";

                      MessageBox.Show(queryStr);

                      using (SQLiteCommand cmd = new SQLiteCommand(queryStr, conn))
                      {
                          cmd.ExecuteNonQuery();
                      }

                      conn.Close();
                  }

                  MessageBox.Show("Data inserted successfully!");
              }
              catch (Exception ex)
              {
                  MessageBox.Show("Error: " + ex.Message);
              }
          }*/

        private void TimerFetchData_Tick(object sender, EventArgs e)
        {
            FetchAndDisplayLast20Records();
        }

        private void FetchAndDisplayLast20Records()
        {
            string connectionString = $"Data Source=datalogger.db;Version=3;";

            string selectQuery = $" SELECT * FROM ChannelData" +
                $" WHERE BatchId = '{Global.BatchId}'" +
                $" ORDER BY TimeStamp DESC  LIMIT 20";
            
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                    RenameHeaders();
                }
                connection.Close();
            }
        }

        private void RenameHeaders()
        {
            // Access the DataGridView control
            DataGridView dataGridView = this.Controls["dataGridView1"] as DataGridView;

             string[] arrHead = Global.FetchHeaders();

            if (dataGridView != null)
            {
                for(int i = 0;i < arrHead.Length; i++)
                {
                    dataGridView.Columns[i+3].HeaderText = arrHead[i];
                }
            }
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UC_Data_Leave(object sender, EventArgs e)
        {
           // MessageBox.Show(" in Leaved ");
        }

        
        private void ExportLastChannelData()
        {
            try {

                // Connection string to your SQLite database
                string connectionString = $"Data Source=datalogger.db;Version=3;";

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    string[] arrHead = Global.FetchHeaders();
                    string[] arrCompany = Global.GetLastRow("CommSettings");
                    string[] arrBatchInfo = Global.GetLastRow("BatchInfo");
                    string batchId = arrBatchInfo[0];

                    connection.Open();

                    // Query to fetch data from your SQLite table
                    string query = "SELECT * FROM ChannelData where BatchId = " + batchId;

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            for (int i = 0; i < arrHead.Length; i++)
                            {
                                dataTable.Columns["channel" + i].ColumnName = arrHead[i];
                            }


                            // Create a new Excel workbook
                            using (XLWorkbook workbook = new XLWorkbook())
                            {
                                // Add a DataTable as a worksheet
                                var worksheet = workbook.Worksheets.Add("Sheet1");

                                // Insert company details at the top
                                worksheet.Cell(1, 1).Value = "Name : ";
                                worksheet.Cell(1, 2).Value = arrCompany[1];

                                for (int col = 1; col <= 20; col++)
                                {
                                    worksheet.Cell(1, col).Style.Font.Bold = true;
                                    worksheet.Cell(1, col).Style.Font.FontSize = 16;
                                    worksheet.Cell(1, col).Style.Fill.BackgroundColor = XLColor.Green;
                                    worksheet.Cell(1, col).Style.Font.FontColor = XLColor.White;
                                }


                                for (int col = 1; col <= 20; col++)
                                {
                                    worksheet.Cell(3, col).Style.Font.Bold = true;
                                    worksheet.Cell(3, col).Style.Font.FontSize = 14;
                                    worksheet.Cell(3, col).Style.Fill.BackgroundColor = XLColor.GoldenYellow;
                                    worksheet.Cell(3, col).Style.Font.FontColor = XLColor.Red;
                                }

                                worksheet.Cell(1, 4).Value = "Phone No : ";
                                worksheet.Cell(1, 5).Value = arrCompany[2];

                                worksheet.Cell(1, 7).Value = "Email : ";
                                worksheet.Cell(1, 8).Value = arrCompany[3];

                                worksheet.Cell(1, 10).Value = " File Downloaded Date Time : ";
                                worksheet.Cell(1, 11).Value = DateTime.Now;

                                // Insert Batch details at the top

                                worksheet.Cell(3, 1).Value = "Batch Id : ";
                                worksheet.Cell(3, 2).Value = arrBatchInfo[0];

                                worksheet.Cell(3, 4).Value = "Batch Name : ";
                                worksheet.Cell(3, 5).Value = arrBatchInfo[1];

                                worksheet.Cell(3, 7).Value = "Batch Number : ";
                                worksheet.Cell(3, 8).Value = arrBatchInfo[2];

                                worksheet.Cell(3, 10).Value = "Supervisor Name : ";
                                worksheet.Cell(3, 11).Value = arrBatchInfo[4];

                                worksheet.Cell(3, 13).Value = "Port No : ";
                                worksheet.Cell(3, 14).Value = arrBatchInfo[5];

                                worksheet.Cell(3, 16).Value = "Process Start Time : ";
                                worksheet.Cell(3, 17).Value = arrBatchInfo[3];

                                // Insert table starting from the second row
                                worksheet.Cell(5, 1).InsertTable(dataTable.AsEnumerable());

                                // Loop through columns to set date format for DateTime columns
                                foreach (DataColumn column in dataTable.Columns)
                                {
                                    if (column.DataType == typeof(DateTime))
                                    {
                                        int columnIndex = dataTable.Columns.IndexOf(column) + 1;
                                        var excelColumn = worksheet.Column(columnIndex);
                                        excelColumn.Style.DateFormat.Format = "dd-MMM-yy h:mm AM/PM";
                                    }
                                }

                                // Prompt user to select folder for saving the file
                                using (var folderDialog = new FolderBrowserDialog())
                                {
                                    if (folderDialog.ShowDialog() == DialogResult.OK)
                                    {
                                        // Get the selected folder path
                                        string folderPath = folderDialog.SelectedPath;
                                        // Construct the full file path
                                        string filePath = System.IO.Path.Combine(folderPath, "ChannelData_" + arrBatchInfo[1]+"_"+ arrBatchInfo[2] + ".xlsx");
                                        // Save the workbook to the selected folder
                                        worksheet.Columns().AdjustToContents();
                                        workbook.SaveAs(filePath);
                                        MessageBox.Show($"Data exported to Excel successfully at {filePath}"," Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                      DialogResult result=  MessageBox.Show("No folder selected. Operation cancelled.", " Abort ", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                                        if(result == DialogResult.Retry) {
                                            ExportLastChannelData();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }


            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);

            }
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            // Connection string to your SQLite database
            string connectionString = $"Data Source=datalogger.db;Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                string[] arrHead = Global.FetchHeaders();
                string[] arrCompany = Global.GetLastRow("CommSettings");
                string[] arrBatchInfo = Global.GetLastRow("BatchInfo");
                string batchId = arrBatchInfo[0];

                connection.Open();

                // Query to fetch data from your SQLite table
                string query = "SELECT * FROM ChannelData where BatchId = " + batchId;

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        for (int i = 0; i < arrHead.Length; i++)
                        {
                            dataTable.Columns["channel" + i].ColumnName = arrHead[i];
                        }


                        // Create a new Excel workbook
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            // Add a DataTable as a worksheet
                            var worksheet = workbook.Worksheets.Add("Sheet1");

                            // Insert company details at the top
                            worksheet.Cell(1, 1).Value = "Name : ";
                            worksheet.Cell(1, 2).Value = arrCompany[1];

                            for (int col = 1; col <= 20; col++)
                            {
                                worksheet.Cell(1, col).Style.Font.Bold = true;
                                worksheet.Cell(1, col).Style.Font.FontSize = 16;
                                worksheet.Cell(1, col).Style.Fill.BackgroundColor = XLColor.Green;
                                worksheet.Cell(1, col).Style.Font.FontColor = XLColor.White;
                            }


                            for (int col = 1; col <= 20; col++)
                            {
                                worksheet.Cell(3, col).Style.Font.Bold = true;
                                worksheet.Cell(3, col).Style.Font.FontSize = 14;
                                worksheet.Cell(3, col).Style.Fill.BackgroundColor = XLColor.GoldenYellow;
                                worksheet.Cell(3, col).Style.Font.FontColor = XLColor.Red;
                            }

                            worksheet.Cell(1, 4).Value = "Phone No : ";
                            worksheet.Cell(1, 5).Value = arrCompany[2];

                            worksheet.Cell(1, 7).Value = "Email : ";
                            worksheet.Cell(1, 8).Value = arrCompany[3];

                            worksheet.Cell(1, 10).Value = " File Downloaded Date Time : ";
                            worksheet.Cell(1, 11).Value = DateTime.Now;

                            // Insert Batch details at the top

                            worksheet.Cell(3, 1).Value = "Batch Id : ";
                            worksheet.Cell(3, 2).Value = arrBatchInfo[0];

                            worksheet.Cell(3, 4).Value = "Batch Name : ";
                            worksheet.Cell(3, 5).Value = arrBatchInfo[1];

                            worksheet.Cell(3, 7).Value = "Batch Number : ";
                            worksheet.Cell(3, 8).Value = arrBatchInfo[2];

                            worksheet.Cell(3, 10).Value = "Supervisor Name : ";
                            worksheet.Cell(3, 11).Value = arrBatchInfo[4];

                            worksheet.Cell(3, 13).Value = "Port No : ";
                            worksheet.Cell(3, 14).Value = arrBatchInfo[5];

                            worksheet.Cell(3, 16).Value = "Process Start Time : ";
                            worksheet.Cell(3, 17).Value = arrBatchInfo[3];

                            // Insert table starting from the second row
                            worksheet.Cell(5, 1).InsertTable(dataTable.AsEnumerable());

                            // Loop through columns to set date format for DateTime columns
                            foreach (DataColumn column in dataTable.Columns)
                            {
                                if (column.DataType == typeof(DateTime))
                                {
                                    int columnIndex = dataTable.Columns.IndexOf(column) + 1;
                                    var excelColumn = worksheet.Column(columnIndex);
                                    excelColumn.Style.DateFormat.Format = "dd-MMM-yy h:mm AM/PM";
                                }
                            }

                            // Prompt user to select folder for saving the file
                            using (var folderDialog = new FolderBrowserDialog())
                            {
                                if (folderDialog.ShowDialog() == DialogResult.OK)
                                {
                                    // Get the selected folder path
                                    string folderPath = folderDialog.SelectedPath;
                                    // Construct the full file path
                                    string filePath = System.IO.Path.Combine(folderPath, "output.xlsx");
                                    // Save the workbook to the selected folder
                                    worksheet.Columns().AdjustToContents();
                                    workbook.SaveAs(filePath);
                                    MessageBox.Show($"Data exported to Excel successfully at {filePath}");
                                }
                                else
                                {
                                    MessageBox.Show("No folder selected. Operation cancelled.");
                                }
                            }
                        }
                    }
                }
            }

        }
    }
}
