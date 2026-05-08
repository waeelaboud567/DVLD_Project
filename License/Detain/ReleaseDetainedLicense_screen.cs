using Business_DVLD;
using presntion_DVLD.UserConrol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static presntion_DVLD.LocalDrivingLicenseApplication_Screen;

namespace presntion_DVLD
{
    public partial class ReleaseDetainedLicense_screen : Form
    {
        public int LocalLicenseID;
        public int ApplicationlIDForReleaseLicense;
        private int LicenseFees;
        private int classLicenseID;
        public ReleaseDetainedLicense_screen()
        {
            InitializeComponent();
            filterLicense_usercontrol1.GetLocalLicenseID += getLocalLicenseID;
        }
        public ReleaseDetainedLicense_screen(int licenseID)
        {
            InitializeComponent();
            filterLicense_usercontrol1.GetLocalLicenseID += getLocalLicenseID;
            filterLicense_usercontrol1.SetLicenseID(licenseID);
            linkLabel1.Enabled = true;
            linkLabel2.Enabled = true;

        }
       
        public void getLocalLicenseID(int localLicenseID)
        {
            LocalLicenseID = localLicenseID;
            applicationInfoForReleaseDetainedLicense_usercontrol1.SetLicenseID(localLicenseID);
            linkLabel1.Enabled= true;
            linkLabel2.Enabled= true;
        }

        

            

        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int personID = clsLicense.GetPersonIDByLicenseID(LocalLicenseID);
            string nationalNo = clspeople.GetNationalNoByPersonID(personID);
            LicenseHistory_Screen f = new LicenseHistory_Screen(nationalNo , LocalLicenseID);
            f.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DriverLicense_Info f = new DriverLicense_Info(LocalLicenseID);
            f.Show();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            IssueLicense();
        }
        private void IssueLicense()
        {
            if (clsDetainedLicenses.IsDetain(LocalLicenseID))
            {

               
                    clsApplication app = new clsApplication();
                    app.pid = clsLicense.GetPersonIDByLicenseID(LocalLicenseID);
                    app.paidFees = clsApplicationTypes.GetFeesfroApplicationType(5);
                    app.CreatedByUserID = LoginScreen.userid;
                    app.ApplicationTypeId = 5;
                    app.ApplicationStatus = 1;
                    app.LicenseClassID = clsLicense.GetClassLicenseID(LocalLicenseID);

                    app.ApplicationDate = DateTime.Now;
                    app.LastStatusDate = DateTime.Now;


                    //insert Application 
                    if (app.Save())
                    {
                        MessageBox.Show("Added Application Successfully", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                        //Release License
                        DateTime RelaseDate = DateTime.Now;
                       if( clsDetainedLicenses.ReleaseLicense(LocalLicenseID, RelaseDate, app.GetAppID(), app.CreatedByUserID))
                       {
                        clsLicense.changeActiveLicense(1,LocalLicenseID);
                        MessageBox.Show("Release License Successfully", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.None);

                       }
                       else
                       {
                        MessageBox.Show("Faild Release License", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                       }

                }
                    else
                    {
                        MessageBox.Show("Faild Added Application", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                    }
                
            }
            else
            {
                MessageBox.Show("The License Is Not Detained", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReleaseDetainedLicense_screen_Load(object sender, EventArgs e)
        {
            linkLabel1.Enabled = false;
            linkLabel2.Enabled = false;
        }
    }
}
