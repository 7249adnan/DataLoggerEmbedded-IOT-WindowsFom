using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myNavbar.UserControls
{
    public partial class UC_ExportData : UserControl
    {
        public UC_ExportData()
        {
            InitializeComponent();

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font; // Optional, for DPI scaling
            this.AutoScroll = true;
        }

        private void UC_ExportData_Load(object sender, EventArgs e)
        {
            comboBoxFindBy.SelectedIndex = 0;
            FetchLast20Data();
        }

        string findText = "";
        string searchByText = "";       

        private void comboBoxFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFindBy.SelectedIndex == 0)
            {                
                txtFindBy.Visible = true;
                DateFindBy.Visible = false;
                searchByText = "BatchNumber";
            }
            else if (comboBoxFindBy.SelectedIndex == 1)
            {
                txtFindBy.Visible = true;
                DateFindBy.Visible = false;
                searchByText = "BatchName";
            }
            else if (comboBoxFindBy.SelectedIndex == 2)
            {
                txtFindBy.Visible = false;
                DateFindBy.Visible = true;
                searchByText = "StartTime";
            }

        }

        private void FetchLast20Data()
        {
            string connectionString = $"Data Source=datalogger.db;Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM BatchInfo ORDER BY Id DESC LIMIT 20";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        existingPanel.Controls.Clear();

                        if (!reader.HasRows)
                        {
                            MessageBox.Show("No results found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            int inc = 0;
                            while (reader.Read())
                            {
                                string Id = reader["Id"].ToString();
                                string batchNumber = reader["BatchNumber"].ToString();
                                string batchName = reader["BatchName"].ToString();
                                string SupervisorName = reader["SupervisorName"].ToString();
                                string StartTime = reader["StartTime"].ToString();
                                string PortNumber = reader["PortNumber"].ToString();

                                CreateDynamicPanels(inc, Id, batchName, batchNumber, SupervisorName, StartTime, PortNumber);
                                inc++;

                            }
                        }
                    }
                }
            }
        }

        private void FetchData(string ColumnName , string FindText){
           
            string connectionString = $"Data Source=datalogger.db;Version=3;";
            
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "";
                DateTime startDateValue = DateTime.Now;
                
                if (comboBoxFindBy.SelectedIndex == 0 || comboBoxFindBy.SelectedIndex == 1)
                {
                    query = "SELECT * FROM BatchInfo WHERE " + ColumnName + " LIKE '%" + FindText + "%'";
                }
                else if (comboBoxFindBy.SelectedIndex == 2)
                {
                    string dateToFind = FindText;
                    startDateValue = DateTime.ParseExact(dateToFind, "dd-MMM-yy", System.Globalization.CultureInfo.InvariantCulture);
                    query = $"SELECT * FROM BatchInfo WHERE DATE({ColumnName}) = DATE(@DateValue)";
                }                

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    if(comboBoxFindBy.SelectedIndex == 2)
                    {
                        command.Parameters.AddWithValue("@DateValue", startDateValue);
                    }
                                        
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        existingPanel.Controls.Clear();

                        if (!reader.HasRows)
                        {
                            MessageBox.Show("No results found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            int inc = 0;                            
                            while (reader.Read())
                            {
                                string Id = reader["Id"].ToString();
                                string batchNumber = reader["BatchNumber"].ToString();
                                string batchName = reader["BatchName"].ToString();
                                string SupervisorName = reader["SupervisorName"].ToString();
                                string StartTime = reader["StartTime"].ToString();
                                string PortNumber = reader["PortNumber"].ToString();

                                CreateDynamicPanels(inc, Id, batchName, batchNumber, SupervisorName, StartTime, PortNumber);
                                inc++;

                            }
                        }
                    }
                }
            }
        }

        private void CreateDynamicPanels(int inc ,string Id , string BatchName ,string BatchNumber ,string SupervisorName, string StartTime ,string PortNumber )
        {
            string[] BatchInfo = { Id,BatchName,BatchNumber,StartTime,SupervisorName,PortNumber };

            // Set the size and position of the existing panel
            /*existingPanel.Size = new Size(400, 500);
            existingPanel.Location = new Point(10, 10);*/

           /* for (int i = 0; i < 10; i++)*/
            {
                // Create a new panel
                Panel dynamicPanel = new Panel
                {
                    Size = new Size(950, 60),
                    Location = new Point(20, 20+ inc * 80),
                    AutoScroll = true, 
                    BorderStyle = BorderStyle.FixedSingle
                };

                // Create a new label
                Label label = new Label
                {
                    Text = $"[ {StartTime} ]     Batch Name  :  {BatchName}     Batch No : {BatchNumber}     Supervisor  :  {SupervisorName} ",
                    Location = new Point(70, 19),
                    Font = new System.Drawing.Font("Century Gothic", 12, FontStyle.Bold),
                    AutoSize = true,
                };


                // Create a new button
                Button button = new Button
                {
                    Text = "",
                    Location = new Point(15, 9),
                    Size = new Size(40, 40),
                    Tag = BatchInfo,
                    BackgroundImageLayout = ImageLayout.Stretch,
                   
                };

                Image originalImage = (Image)Properties.Resources.DownloadImage; // Replace DownloadImage with your image name
                Image resizedImage = new Bitmap(originalImage, button.Size);                
                button.BackgroundImage = resizedImage;

                button.Click += Button_Click;

                // Add the label, textbox, and button to the dynamic panel
                dynamicPanel.Controls.Add(label);
               
                dynamicPanel.Controls.Add(button);

                // Add the dynamic panel to the existing panel
                existingPanel.Controls.Add(dynamicPanel);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;           
            string [] BatchInfo = clickedButton?.Tag as string [] ;
            DownLoadExcel(BatchInfo);         
        }

        private void DownLoadExcel(string[] arrBatchInfo) {

            try
            {
                // Connection string to your SQLite database
                string connectionString = $"Data Source=datalogger.db;Version=3;";

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    string[] arrHead = Global.FetchHeaders();
                    string[] arrCompany = Global.GetLastRow("CommSettings");                   
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
                                        string filePath = System.IO.Path.Combine(folderPath, "ChannelData_" + arrBatchInfo[1] + "_" + arrBatchInfo[2] + ".xlsx");
                                        // Save the workbook to the selected folder
                                        worksheet.Columns().AdjustToContents();
                                        workbook.SaveAs(filePath);
                                        MessageBox.Show($"Data exported to Excel successfully at {filePath}", " Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        DialogResult result = MessageBox.Show("No folder selected. Operation cancelled.", " Abort ", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                                        if (result == DialogResult.Retry)
                                        {
                                            DownLoadExcel(arrBatchInfo);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

        }

        private void btnFindBatch_Click(object sender, EventArgs e)
        {
            if (comboBoxFindBy.SelectedIndex == 0 || comboBoxFindBy.SelectedIndex == 1)
            {
                findText = txtFindBy.Text;
            }
            else if (comboBoxFindBy.SelectedIndex == 2)
            {
                DateTime startDateValue = DateTime.Parse(DateFindBy.Text);
                findText = (startDateValue.Date).ToString("dd/MMM/yy");                
            }

            if (findText != "")
            {                         
                FetchData(searchByText, findText);
            }
            else
            {
                MessageBox.Show("Please Enter the Text in TextBox Or Select Date ","Input Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }            
        }

        private void txtFindBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {                
                btnFindBatch_Click(sender, e);
                e.Handled = true; // Prevents the beep sound when pressing Enter
                e.SuppressKeyPress = true; // Suppress the default behavior of the Enter key
            }

        }

        private void txtFindBy_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtFindBy.TextLength == 0)
            {
                FetchLast20Data();               
            }
        }

        private void DateFindBy_ValueChanged(object sender, EventArgs e)
        {
            btnFindBatch_Click(sender, e);
        }

        private void DownLoadBackupExcel() {

            try
            {
                // Connection string to your SQLite database
                string connectionString = $"Data Source=datalogger.db;Version=3;";

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    string[] arrHead = Global.FetchHeaders();
                    string[] arrCompany = Global.GetLastRow("CommSettings");
                    

                    connection.Open();

                    // Query to fetch data from your SQLite table
                    string query = "SELECT * FROM ChannelData";

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

                                worksheet.Cell(3, 1).Value = "ALL ";
                                worksheet.Cell(3, 2).Value = "Channel";
                                worksheet.Cell(3, 3).Value = "DATA ";
                                worksheet.Cell(3, 4).Value = "BACKUP ";
                                worksheet.Cell(3, 5).Value = "File ";                               

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
                                        string filePath = System.IO.Path.Combine(folderPath, "ChannelData_BACKUP_FILE.xlsx");
                                        // Save the workbook to the selected folder
                                        worksheet.Columns().AdjustToContents();
                                        workbook.SaveAs(filePath);
                                        MessageBox.Show($"Data exported to Excel successfully at {filePath}", " Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        DialogResult result = MessageBox.Show("No folder selected. Operation cancelled.", " Abort ", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                                        if (result == DialogResult.Retry)
                                        {
                                            DownLoadBackupExcel();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This Action Take All Backup of Channel Data \n Are you Sure ?? .", " Granting ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DownLoadBackupExcel();
            }
           
        }
    }
}
