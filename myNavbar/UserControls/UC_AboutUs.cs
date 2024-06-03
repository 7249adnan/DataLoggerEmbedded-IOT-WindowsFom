using Org.BouncyCastle.Tsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myNavbar.UserControls
{
    public partial class UC_AboutUs : UserControl
    {
        public UC_AboutUs()
        {
            InitializeComponent();

            label1.Text= "We Are the Initiators of the IT Revolution";

                        label2.Text = @"MIS Innovate has come into being to make a revolutionary impact in the industry
    of information technology. We have secured an intermediate position of infusing
    intricate technological advancements to resolve practical business issues. Our 
    team of IT experts absorbs an updated experience of years helpful enough to 
    figure out the rising need for authentic, personalized, and novel IT solutions. 

    Every passing year adds to our knowledge and experience which we convert into 
    offering dynamic services to our clients to their maximum satisfaction and 
    success levels. Counted as a leading IT service company, we put forward all our 
    commitment towards implementing powerful innovatory solutions that can 
    authorize businesses to prosper in this digital landscape. 


        Our company has stepped into the IT industry to revolutionize the 
        technological and digital background. As an IT service agency, we
        come into being to provide top-notch IT support to thriving businesses 
        longing for successful accomplishments within their domains.";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
