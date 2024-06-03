using myNavbar.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Web.Configuration;

namespace myNavbar
{
    public partial class Form1 : Form
    {
      

        public Form1()
        {
            InitializeComponent();
            UC_Settings uc = new UC_Settings();
            addUserControl(uc);
            SetActive(lblSettings);
            this.AutoScroll = true;

          
            /*rgb(13, 110, 253)*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void ResetActive()
        {
            lblAboutUs.ForeColor = Color.Black;
            lblExportData.ForeColor = Color.Black;
            lblSettings.ForeColor = Color.Black;
            lblAnalytics.ForeColor = Color.Black;
            lblData.ForeColor = Color.Black;
            lblDashboard.ForeColor = Color.Black;

        } 
        private void SetActive(Label lbl)
        {
            ResetActive();

            int red = int.Parse(WebConfigurationManager.AppSettings["NavButtonCheckedStateForeColorRed"]);
            int green = int.Parse(WebConfigurationManager.AppSettings["NavButtonCheckedStateForeColorGreen"]);
            int blue = int.Parse(WebConfigurationManager.AppSettings["NavButtonCheckedStateForeColorBlue"]);

            lbl.ForeColor = Color.FromArgb(red,green,blue);
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock= DockStyle.Fill;     
            panelContainer.Controls.Clear();
            
            panelContainer.Controls.Add(userControl);            
            userControl.BringToFront(); 
        }

    

        private void lblAboutUs_Click(object sender, EventArgs e)
        {
            UC_AboutUs uc = new UC_AboutUs();
            addUserControl(uc);            
            SetActive(lblAboutUs);

        }

        private void lblSupport_Click(object sender, EventArgs e)
        {
            UC_ExportData uc = new UC_ExportData();
            addUserControl(uc);
            SetActive(lblExportData);
        }

        private void lblSettings_Click(object sender, EventArgs e)
        {
            UC_Settings uc = new UC_Settings();
            addUserControl(uc);
            SetActive(lblSettings);
        }

        private void lblAnalytics_Click(object sender, EventArgs e)
        {
            UC_Analytics uc = new UC_Analytics();
            addUserControl(uc);
            SetActive(lblAnalytics);
        }

        private void lblData_Click(object sender, EventArgs e)
        {
            UC_Data uc = new UC_Data();
            addUserControl (uc);
            SetActive (lblData);
        }

        private void lblDashboard_Click(object sender, EventArgs e)
        {
            UC_Dashboard uc = new UC_Dashboard();
            addUserControl(uc);
            SetActive(lblDashboard);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
