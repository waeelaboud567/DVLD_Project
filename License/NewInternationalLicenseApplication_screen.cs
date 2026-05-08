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
    public partial class NewInternationalLicenseApplication_screen : Form
    {
        public int LocalLicenseID;
        public int ApplicationInternationalID;
        public int LicenseInternationalID;
        public NewInternationalLicenseApplication_screen()
        {
            InitializeComponent();
            filterLicense_usercontrol1.GetLocalLicenseID += SetLocalLicenseID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void SetLocalLicenseID(int localLicenseID)
        {
            LocalLicenseID=localLicenseID;
            infoApplicationForInternationalLicense_usercontrol1.SetLocalLicenseID(localLicenseID);
        }
        private void filterLicense_usercontrol1_Load(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IssueLicenseInternational();
        }

        private void IssueLicenseInternational()
        {
            if (!clsInternationalLicense.IsActiveInternationalLicense(LocalLicenseID))
            {
                if (clsLicense.CheckLocalLicensIDForIsActiveAnd(LocalLicenseID) == 1)
                {
                clsApplication app = new clsApplication();
                app.pid = clsLicense.GetPersonIDByLicenseID(LocalLicenseID);
                app.paidFees = clsApplicationTypes.GetFeesfroApplicationType(6);
                app.CreatedByUserID = LoginScreen.userid;
                app.ApplicationTypeId = 1;
                app.ApplicationStatus = 1;
                app.LicenseClassID = clsLicenseClasses.GetClassID("Class 3 - Ordinary driving license");
                app.ApplicationDate = DateTime.Now;
                app.LastStatusDate = DateTime.Now;

               
                    //insert Application 
                    if (app.Save())
                    {
                        MessageBox.Show("Added Application Successfully", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                        ApplicationInternationalID = app.GetAppID();


                        clsInternationalLicense licenseInternational = new clsInternationalLicense();

                        licenseInternational.ApplicationID = ApplicationInternationalID;
                        licenseInternational.IssueDate = DateTime.Now;
                        licenseInternational.ExpirationDate = clsLicenseClasses.GetExpirationDate(3);
                        licenseInternational.DriverID = clsDriver.GetDriverID(app.pid);
                        licenseInternational.CreatedByUserID = LoginScreen.userid;
                        licenseInternational.IsActive = 1;
                        licenseInternational.IssuedUsingLocalLicenseID = LocalLicenseID;

                        if (licenseInternational.Save())
                        {
                            MessageBox.Show("Added License Successfully", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
                            LicenseInternationalID = licenseInternational.GetInternationalLicenseID();
                            infoApplicationForInternationalLicense_usercontrol1.SetApplicationInternationalID_And_LicenseInternationalID(ApplicationInternationalID, LicenseInternationalID);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Faild Added Application", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("The License must be active and not expired", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("There is a currently active license a new license can only be issued if the license expires or if it is inactive", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { int personID = clsLicense.GetPersonIDByLicenseID(LocalLicenseID);
            string nationalNo = clspeople.GetNationalNoByPersonID(personID);
            LicenseHistory_Screen f=new LicenseHistory_Screen(nationalNo , LocalLicenseID);
            f.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DriverLicense_Info f=new DriverLicense_Info(LocalLicenseID);
            f.Show();
        }
    }
}
