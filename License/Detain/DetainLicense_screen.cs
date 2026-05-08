using Business_DVLD;
using presntion_DVLD.UserConrol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static presntion_DVLD.LocalDrivingLicenseApplication_Screen;

namespace presntion_DVLD
{
    public partial class DetainLicense_screen : Form
    {
        public int LocalLicenseID;        
        
        public DetainLicense_screen()
        {
            InitializeComponent();
            filterLicense_usercontrol1.GetLocalLicenseID += getLocalLicenseID;

        }
        public DetainLicense_screen(int licenseID)
        {
            InitializeComponent();
            filterLicense_usercontrol1.GetLocalLicenseID += getLocalLicenseID;
            filterLicense_usercontrol1.SetLicenseID(licenseID);


        }
        public void getLocalLicenseID(int localLicenseID)
        {
            LocalLicenseID = localLicenseID;
            applicationInfoForDetainLicense_usercontrol1.SetLicenseID(LocalLicenseID);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DetainLicense()
        {
            if (!clsDetainedLicenses.IsDetain(LocalLicenseID))
            {
                if (applicationInfoForDetainLicense_usercontrol1.IsValueForFeesInTextBox())
                {

                    if (clsLicense.CheckLocalLicensIDForIsActive(LocalLicenseID) == 1)
                    {
                        clsDetainedLicenses dl = new clsDetainedLicenses();
                        dl.LicenseID = LocalLicenseID;
                        dl.LicenseDetainFees = applicationInfoForDetainLicense_usercontrol1.GetFeesForDetain();
                        dl.IsReleased = 0;
                        dl.CreatedByUserID = LoginScreen.userid;
                        dl.DetainDate = DateTime.Now;
                        dl.ReleaseDate = DateTime.MinValue;
                        dl.ReleaseApplicationID = -1;
                        dl.ReleasedByUserID = -1;





                        //insert DetainLicense

                        if (dl.Save())
                        {
                            MessageBox.Show("Detain License Sccussfilly", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                            clsLicense.changeActiveLicense(0, LocalLicenseID);
                            applicationInfoForDetainLicense_usercontrol1.SetDetainID(dl.DetainID);
                            btnIssue.Enabled = false;

                        }
                        else
                        {
                            MessageBox.Show("Field Detain Licence", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        }


                    }
                    else
                    {
                        MessageBox.Show("The License must be active ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Enter value For Fine", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("it's already booked", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            DetainLicense();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DriverLicense_Info f = new DriverLicense_Info(LocalLicenseID);
            f.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int personID = clsLicense.GetPersonIDByLicenseID(LocalLicenseID);
            string nationalNo = clspeople.GetNationalNoByPersonID(personID);
            LicenseHistory_Screen f = new LicenseHistory_Screen(nationalNo , LocalLicenseID);
            f.Show();
        }
    }
}
