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
using System.Windows.Forms.VisualStyles;

namespace presntion_DVLD
{
    
    public partial class MainScreen : Form
    {
        private int _UID;
        public MainScreen(int userid)
        {
            InitializeComponent();
            _UID = userid;
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagerPeople f =new ManagerPeople();
            
            f.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
             ManagerUsers f=new ManagerUsers();
            
            f.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personid=clsUser.GetPIDbyUID(_UID);
            person_DetailsAndUserInfo f=new person_DetailsAndUserInfo(personid);
            f.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personid = clsUser.GetPIDbyUID(_UID);
            ChangePasswod_Screen f = new ChangePasswod_Screen(personid);
            f.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageApplicationTypes_Screen f= new ManageApplicationTypes_Screen();
            f.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageTsetTypes_Screen f=new ManageTsetTypes_Screen();
            f.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewLocalDrivingLicenseApplication_Screen f=new NewLocalDrivingLicenseApplication_Screen();
            f.ShowDialog();
        }

        private void localDrivingLicenseApplicatioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalDrivingLicenseApplication_Screen f=new LocalDrivingLicenseApplication_Screen();
            f.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageDrivers_screen f=new ManageDrivers_screen();
            f.Show();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewInternationalLicenseApplication_screen f = new NewInternationalLicenseApplication_screen();
            f.Show();
        }

        private void internationalLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_International_License f=new Manage_International_License();
            f.Show();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Renew_License_Application f=new Renew_License_Application();
            f.Show();
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Replacement_For_Damaged_License f = new Replacement_For_Damaged_License();
            f.Show();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetainLicense_screen f=new DetainLicense_screen();
            f.Show();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicense_screen f= new ReleaseDetainedLicense_screen();
            f.Show();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageDetainedLicense_screen f=new ManageDetainedLicense_screen();
            f.ShowDialog();
        }
    }
}
