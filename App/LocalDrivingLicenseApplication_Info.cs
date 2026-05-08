using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presntion_DVLD.Application
{
    public partial class LocalDrivingLicenseApplication_Info : Form
    {
        public LocalDrivingLicenseApplication_Info(int appID, int localDrivingLicenseApplicationInfo_ID)
        {
            InitializeComponent();
            infoApplication_usercontrol1.appid= appID;
            infoApplication_usercontrol1.localid = localDrivingLicenseApplicationInfo_ID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
