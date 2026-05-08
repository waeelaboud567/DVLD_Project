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
    public partial class ApplicationInfoForReleaseDetainedLicense_usercontrol : UserControl
    {
        public ApplicationInfoForReleaseDetainedLicense_usercontrol()
        {
            InitializeComponent();
        }

        private void ApplicationInfoForReleaseDetainedLicense_usercontrol_Load(object sender, EventArgs e)
        {
            labresultApplicationDate.Text = DateTime.Now.ToShortDateString();
            labresultDetainDate.Text= DateTime.Now.ToShortDateString();
            labresultCreatedBy.Text = LoginScreen.username;
            
        }
        public void SetLicenseID(int  licenseID)
        {
            labresultLicenseID.Text = licenseID.ToString();
            labresultFineFees.Text = (clsDetainedLicenses.GetFineFees(licenseID)).ToString();
            labresultApplicationFees.Text = clsApplicationTypes.GetFeesfroApplicationType(5).ToString();
            labresultTotalFees.Text = (Convert.ToInt32(labresultFineFees.Text) + Convert.ToInt32(labresultApplicationFees.Text)).ToString();
            labresualtDetainID.Text = clsDetainedLicenses.GetDetaiID(licenseID).ToString();
        }
        
    }
}
