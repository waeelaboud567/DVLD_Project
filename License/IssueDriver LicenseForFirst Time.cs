using Business_DVLD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Internal;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static presntion_DVLD.LocalDrivingLicenseApplication_Screen;

namespace presntion_DVLD
{
    public partial class IssueDriver_LicenseForFirst_Time : Form
    {
        private int appid;
        private int localid;
        private int personid;
        private int classLicenseID;
        public IssueDriver_LicenseForFirst_Time(int appid,int localid,int classLID)
        {
            InitializeComponent();
            this.appid = appid;
            this.localid = localid;
            infoApplication_usercontrol1.appid = appid;
            infoApplication_usercontrol1.localid = localid;
            classLicenseID = classLID;
            infoApplication_usercontrol1.GetPersonID_Event += GetPersonID;

        }
        private void GetPersonID(int pid)
        {
            personid=pid;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Person_Details f = new Person_Details(Convert.ToString(personid));
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int CreatedByUserID = LoginScreen.userid;
            int DriverID = clsDriver.GetDriverID(personid);
            DateTime CreatedDate = DateTime.Now;
            DateTime ExpirationDate = clsLicenseClasses.GetExpirationDate(classLicenseID);
            string notes=textBox1.Text;
            int paidFees = clsLicenseClasses.GetPaidFees(classLicenseID);
            int isActive = 1;
            int issueReason = 1;


            if (DriverID==-1)
            {
                 DriverID=clsDriver.AddDriver(personid,CreatedByUserID);
                if (DriverID != -1)
                {
                    int LicenseID = clsLicense.AddLicense(appid, DriverID, classLicenseID, CreatedDate, ExpirationDate, notes, paidFees, isActive, issueReason, CreatedByUserID);
                    if(LicenseID != -1)
                    {
                        MessageBox.Show("Added Driver Sccussfilly", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        clsApplication.ChangeStatus(Convert.ToInt32(StatusApplication.Complete), appid);
                        btnIssue.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Field Added Licence", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Field Added Driver","Error",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                }
            }
            else
            {
                int LicenseID = clsLicense.AddLicense(appid, DriverID, classLicenseID, CreatedDate, ExpirationDate, notes, paidFees, isActive, issueReason, CreatedByUserID);
                if (LicenseID != -1)
                {
                    MessageBox.Show("Added Licence Sccussfilly", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    clsApplication.ChangeStatus(Convert.ToInt32(StatusApplication.Complete), appid);
                    btnIssue.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Field Added Licence", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                }
            }
        }
    }
}
