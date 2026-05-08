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

namespace presntion_DVLD.UserConrol
{
    public partial class InfoApplicationForInternationalLicense_usercontrol : UserControl
    {
        
        public int ApplicationInternationalID;
        public int LicenseInternationalID;
        public InfoApplicationForInternationalLicense_usercontrol()
        {
            InitializeComponent();
        }

        private void InfoApplicationForInternationalLicense_usercontrol_Load(object sender, EventArgs e)
        {
            labresultApplicationDate.Text=DateTime.Now.ToShortDateString();
            labresultIssueDate.Text=DateTime.Now.ToShortDateString();
            labresultIsCreatedBy.Text=LoginScreen.username;
            labresualtFees.Text =clsApplicationTypes.GetFeesfroApplicationType(6).ToString();
            labresultExpirationDate.Text = clsLicenseClasses.GetExpirationDate(3).ToShortDateString();
        }

        public void SetLocalLicenseID(int localLicenseID)
        {
            labresultLocalLicenseID.Text = localLicenseID.ToString();
        }
        public void SetLicenseID_International(int InternationalLicenseID)
        {
            labresualtILAID.Text= InternationalLicenseID.ToString();
        }
        public void SetApplicationID_International(int InternationalApplicationID)
        {
            labresualtILAID.Text = InternationalApplicationID.ToString();
        }

        public void SetApplicationInternationalID_And_LicenseInternationalID(int applicationInternationalID,int licenseInternationalID)
        {
            ApplicationInternationalID = applicationInternationalID;
            LicenseInternationalID = licenseInternationalID;
            labresualtILAID.Text= ApplicationInternationalID.ToString();
            labresultILLIcenseID.Text = LicenseInternationalID.ToString();
        }
    }
}
