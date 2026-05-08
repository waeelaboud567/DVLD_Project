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
using static System.Net.Mime.MediaTypeNames;

namespace presntion_DVLD.UserConrol
{
    public partial class ApplicationNewLicenseInfo_usercontrol : UserControl
    {
        
        public ApplicationNewLicenseInfo_usercontrol()
        {
            InitializeComponent();
        }

        private void ApplicationNewLicenseInfo_usercontrol_Load(object sender, EventArgs e)
        {
            labresultApplicationDate.Text=DateTime.Now.ToShortDateString();
            labresultIssueDate.Text=DateTime.Now.ToShortDateString();
            labresualtApplicationFees.Text = clsApplicationTypes.GetFeesfroApplicationType(2).ToString();
            labresultIsCreatedBy.Text = LoginScreen.username;
            labresultExpirationDate.Text=clsLicenseClasses.GetExpirationDate(2).ToShortDateString();
            
        }
        public string GetNotes()
        {
            return TextBox1.Text;
        }

        public void SetNewLicenseID(int newLicenseID)
        {
            labresultRenewLicenseID.Text= newLicenseID.ToString();
        }
        public void SetOldLicenseID(int oldLicenseID)
        {
            labresultOldLicenseID.Text = oldLicenseID.ToString();
        }
        public void SetLicenseFees(int licenseFees)
        {
            labresultLicenseFees.Text = licenseFees.ToString();
            labresultTotalFees.Text=( licenseFees +Convert.ToInt32(labresualtApplicationFees.Text) ).ToString();
        }
        public void SetRLApplication(int RLApplication)
        {
            labresualtRLApplication.Text = RLApplication.ToString();
        }
    }
}
