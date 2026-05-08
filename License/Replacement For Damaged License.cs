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
    public partial class Replacement_For_Damaged_License : Form
    {
        public int LocalLicenseID;
        public int ApplicationlIDForRenewLicense;
        private int LicenseFees;
        private int classLicenseID;

        public Replacement_For_Damaged_License()
        {
            InitializeComponent();
            filterLicense_usercontrol1.GetLocalLicenseID += getLocalLicenseID;
            

        }
        public void getLocalLicenseID(int localLicenseID)
        {
            LocalLicenseID = localLicenseID;

            classLicenseID = clsLicense.GetClassLicenseID(LocalLicenseID);
            linkLabel1.Enabled = true;
            linkLabel2.Enabled = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnIssue_Click(object sender, EventArgs e)
        {
            IssueLicense();
        }
        private void IssueLicense()
        {

            if (clsLicense.CheckLocalLicensIDForIsActive(LocalLicenseID) == 1)
            {
                clsApplication app = new clsApplication();
                app.pid = clsLicense.GetPersonIDByLicenseID(LocalLicenseID);
                app.paidFees = clsApplicationTypes.GetFeesfroApplicationType(3);
                app.CreatedByUserID = LoginScreen.userid;
                app.ApplicationTypeId = 3;
                app.ApplicationStatus = 1;
                app.ApplicationDate = DateTime.Now;
                app.LastStatusDate = DateTime.Now;


                //insert Application 
                if (app.Save())
                {
                    MessageBox.Show("Added Application Successfully", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                    ApplicationlIDForRenewLicense = app.GetAppID();
                    app.AddLocalDrivingLicenseApplications(ApplicationlIDForRenewLicense, classLicenseID);

                    int CreatedByUserID = LoginScreen.userid;
                    int DriverID = clsDriver.GetDriverID(app.pid);
                    DateTime CreatedDate = DateTime.Now;
                    DateTime ExpirationDate = clsLicenseClasses.GetExpirationDate(classLicenseID);
                    string notes = "";
                    

                    int isActive = 1;
                    int issueReason = SelectReasonForReplacement();
                    applicationInfoForReplecment_usercontrol1.SetRLApplication(ApplicationlIDForRenewLicense);
                    applicationInfoForReplecment_usercontrol1.SetOldLicenseID(LocalLicenseID);


                    //insert License
                    int LicenseID = clsLicense.AddLicense(ApplicationlIDForRenewLicense, DriverID, classLicenseID, CreatedDate, ExpirationDate, notes, LicenseFees, isActive, issueReason, CreatedByUserID);
                    if (LicenseID != -1)
                    {
                        MessageBox.Show("Added License Sccussfilly", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        clsApplication.ChangeStatus(Convert.ToInt32(StatusApplication.Complete), ApplicationlIDForRenewLicense);
                        clsLicense.changeActiveLicense(0, LocalLicenseID);
                        btnIssue.Enabled = false;

                        //send values to ApplicationNewLicenseInfo_usercontrol
                        applicationInfoForReplecment_usercontrol1.SetNewLicenseID(LicenseID);
                    }
                    else
                    {
                        MessageBox.Show("Field Added Licence", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Faild Added Application", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("The License must be active and  expired", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }
        private int SelectReasonForReplacement()
        {
            if (rbLost.Checked)
                return 3;
            else if (rbDamaged.Checked)
                return 4;
            else
                return -1;
            
        }

        private void Replacement_For_Damaged_License_Load(object sender, EventArgs e)
        {
            linkLabel1.Enabled= false;
            linkLabel2.Enabled= false;
        }
    }
}
