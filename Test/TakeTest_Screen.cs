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
using static presntion_DVLD.LocalDrivingLicenseApplication_Screen;

namespace presntion_DVLD
{
    public partial class TakeTest_Screen : Form
    {
        public event Action<int> ResultTest;
        private clsTest test;
        private int AppointmentID;
        private int StatusAppointment;
        private int TestTypeid;
        private int appid;

        public TakeTest_Screen(int AppointmentID, int TestTypeid,int localID)
        {
            InitializeComponent();
            if(!DesignMode)
            {
                this.AppointmentID = AppointmentID;
                this.TestTypeid = TestTypeid;
                appointment_usercontrol1.localid = localID;
                appointment_usercontrol1.testTypeID = TestTypeid;
                this.appid= localID;
            }
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
            if(rbPass.Checked || rbFail.Checked)
            {
                if(rbPass.Checked)
                {
                    test.TestResult = 1;
                }
                else
                {
                    test.TestResult = 0;
                }
                test.Notes = textBox1.Text;
                test.TestAppointmentID = AppointmentID;
                test.createdByUserID = LoginScreen.userid;
                

                if(test.Save())
                {
                    if(clsTset_Appointments.ChangeLocked(AppointmentID))
                    MessageBox.Show("The test result was successfully determined", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    labresultTestID.Text =test.TestID.ToString();
                    btnSave.Enabled = false ;
                    ResultTest?.Invoke(test.TestResult);

                    
                }
                else
                {
                    MessageBox.Show("Failure to determine the result", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("The test result must be determined!", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void TakeTest_Screen_Load(object sender, EventArgs e)
        {
            test = new clsTest();
        }
        
    }
}
