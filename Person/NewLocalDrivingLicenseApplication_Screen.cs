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
    public partial class NewLocalDrivingLicenseApplication_Screen : Form
    {
        public int personid;
        public NewLocalDrivingLicenseApplication_Screen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedIndex = 1;
        }

        private void NewLocalDrivingLicenseApplication_Screen_Load(object sender, EventArgs e)
        {   
            DataView dv= clsLicenseClasses.GetLicenseClasses();
            comboBox1.DataSource = dv;
            comboBox1.DisplayMember = "ClassName";

            labApplicationDate.Text = DateTime.Now.ToShortDateString();
            labusername.Text = LoginScreen.username;
            labApplicationFees.Text = clsApplicationTypes.GetFeesfroApplicationType(1).ToString();

            comboBox1.SelectedIndex = 2;
        }
        public int GetIDLicenseClass()
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    return 1;
                    break;
                case 1:
                    return 2;
                    break;
                case 2:
                    return 3;
                    break;
                case 3:
                    return 4;
                    break;
                case 4:
                    return 5;
                    break;
                case 5:
                    return 6;
                    break;
                case 6:
                    return 7;
                    break;

                default:
                    return 3;
                    break;
            }
            
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            personid = addUser_usercontrol1.personid;
            clsApplication app = new clsApplication();
            if(personid!=-1)
            {
                app.pid= personid;
                app.paidFees=Convert.ToDouble(labApplicationFees.Text);
                app.CreatedByUserID = LoginScreen.userid;
                app.ApplicationTypeId = 1;
                app.ApplicationStatus = 1;
                app.LicenseClassID = GetIDLicenseClass();

                if (clsLicense.IsLicenseExistByPersonID(app.pid, app.LicenseClassID))
                {

                    MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!app.isPersonHasApplicationWithSameLicenseClass())
                {

                    if (app.Save())
                    {
                        MessageBox.Show("Added Application Successfully", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                        labApplicationID.Text = app.GetAppID().ToString();
                        
                        app.AddLocalDrivingLicenseApplications(app.GetAppID(), app.LicenseClassID);
                        btnSave.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Faild Added Application ", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show($"There is a similar request pending for person : {app.pid}", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("There is on specific person", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            
        }
    }
}
