using Business_DVLD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presntion_DVLD
{
    public partial class DriverLicense_Info : Form
    {
        private int LicenseID;
       
        public DriverLicense_Info(int LicenseID)
        {
            InitializeComponent();
            this.LicenseID = LicenseID;
            driverLicenseInfo_usercontrol.LicenseID = LicenseID;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void DriverLicense_Info_Load(object sender, EventArgs e)
        {

        }
    }
}
