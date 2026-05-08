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
    public partial class ApplicationInfoForReplecment_usercontrol : UserControl
    {
        public ApplicationInfoForReplecment_usercontrol()
        {
            InitializeComponent();
        }

        private void ApplicationInfoForReplecment_usercontrol_Load(object sender, EventArgs e)
        {
            labresultIsCreatedBy.Text = LoginScreen.username;
            labresualtFees.Text = clsApplicationTypes.GetFeesfroApplicationType(3).ToString();
            labresultApplicationDate.Text=DateTime.Now.ToShortDateString();
        }

        public void SetRLApplication(int RLApplication)
        {
            labresualtIRAID.Text = RLApplication.ToString();
        }
        
        public void SetOldLicenseID(int OldLicenseID)
        {
            labresultOldLicenseID.Text = OldLicenseID.ToString();
        }
        
        public void SetNewLicenseID(int OldLicenseID)
        {
            labresultNewLicenseID.Text = OldLicenseID.ToString();
        }
    }
   
}
