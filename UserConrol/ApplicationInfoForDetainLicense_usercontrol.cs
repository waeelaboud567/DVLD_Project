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
    public partial class ApplicationInfoForDetainLicense_usercontrol : UserControl
    {

        public ApplicationInfoForDetainLicense_usercontrol()
        {
            InitializeComponent();
        }

        public int GetFeesForDetain()
        {
            return Convert.ToInt32(textBox1.Text);
        }

        private void ApplicationInfoForDetainLicense_usercontrol_Load(object sender, EventArgs e)
        {
            labresultDetainDate.Text = DateTime.Now.ToShortDateString();
            labresultCreatedBy.Text = LoginScreen.username;
        }
        public void SetDetainID(int detainID)
        {
            labresualtDetainID.Text = detainID.ToString();
        }
        public void SetLicenseID(int LicenseID)
        {
            labresultLicenseID.Text = LicenseID.ToString();
        }
        public bool IsValueForFeesInTextBox()
        {
            if (textBox1.Text != "")
            {
                if (Convert.ToInt32(textBox1.Text) > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
