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
    public partial class Renew_License_Application : Form
    {
        public int LocalLicenseID;
        public int ApplicationlIDForRenewLicense;
        private string notes;
        private int LicenseFees;
        private int classLicenseID;
        public Renew_License_Application()
        {
            InitializeComponent();
            filterLicense_usercontrol1.GetLocalLicenseID += getLocalLicenseID;
            filterLicense_usercontrol1.IsExsitsLicense += getExists;


        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Renew_License_Application_Load(object sender, EventArgs e)
        {
            linkLabel1.Enabled = false;
            linkLabel2.Enabled = false;
        }
        public void getLocalLicenseID(int localLicenseID)
        {
            LocalLicenseID= localLicenseID;
            linkLabel1.Enabled= true;
            linkLabel2.Enabled= true;
        }

        public void getExists()
        {
            classLicenseID = clsLicense.GetClassLicenseID(LocalLicenseID);

            LicenseFees = clsLicenseClasses.GetPaidFees(classLicenseID);
            applicationNewLicenseInfo_usercontrol1.SetOldLicenseID(LocalLicenseID);
            applicationNewLicenseInfo_usercontrol1.SetLicenseFees(LicenseFees);


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
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

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IssueLicense();
        }
        private void IssueLicense()
        {
            
                if (clsLicense.CheckLocalLicensIDForIsActiveAnd(LocalLicenseID) ==1)
                {
                    clsApplication app = new clsApplication();
                    app.pid = clsLicense.GetPersonIDByLicenseID(LocalLicenseID);
                    app.paidFees = clsApplicationTypes.GetFeesfroApplicationType(2);
                    app.CreatedByUserID = LoginScreen.userid;
                    app.ApplicationTypeId = 2;
                    app.ApplicationStatus = 1;
                    app.LicenseClassID = clsLicenseClasses.GetClassID("Class 3 - Ordinary driving license");
                    app.ApplicationDate = DateTime.Now;
                    app.LastStatusDate = DateTime.Now;


                    //insert Application 
                    if (app.Save())
                    {
                        MessageBox.Show("Added Application Successfully", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                        ApplicationlIDForRenewLicense = app.GetAppID();
                        app.AddLocalDrivingLicenseApplications(ApplicationlIDForRenewLicense,classLicenseID);

                        int CreatedByUserID = LoginScreen.userid;
                        int DriverID = clsDriver.GetDriverID(app.pid);
                        DateTime CreatedDate = DateTime.Now;
                        DateTime ExpirationDate = clsLicenseClasses.GetExpirationDate(classLicenseID);
                        string notes =applicationNewLicenseInfo_usercontrol1.GetNotes();
                        LicenseFees = clsLicenseClasses.GetPaidFees(classLicenseID);
                        
                        int isActive = 1;
                        int issueReason = 2;
                        applicationNewLicenseInfo_usercontrol1.SetRLApplication(ApplicationlIDForRenewLicense);
                        applicationNewLicenseInfo_usercontrol1.SetOldLicenseID(LocalLicenseID);
                    

                    //insert License
                    int LicenseID = clsLicense.AddLicense(ApplicationlIDForRenewLicense, DriverID, classLicenseID, CreatedDate, ExpirationDate, notes, LicenseFees, isActive, issueReason, CreatedByUserID);
                        if (LicenseID != -1)
                        {
                            MessageBox.Show("Added License Sccussfilly", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            clsApplication.ChangeStatus(Convert.ToInt32(StatusApplication.Complete), ApplicationlIDForRenewLicense);
                            clsLicense.changeActiveLicense(0, LocalLicenseID);
                            btnIssue.Enabled = false;

                        //send values to ApplicationNewLicenseInfo_usercontrol
                        applicationNewLicenseInfo_usercontrol1.SetNewLicenseID(LicenseID);
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

        
    }
}
