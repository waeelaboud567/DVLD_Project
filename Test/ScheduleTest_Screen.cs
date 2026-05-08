using Business_DVLD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presntion_DVLD
{
    public partial class ScheduleTest_Screen : Form
    {
        clsTset_Appointments TA;
        enum mode { Add=1,Update=2}
        private int localid;
        private int StatusAppointment;
        private int TestTypeid;

        private DateTime AppointmentDate=DateTime.Now.Date;
        private int PaidFees;
        private int AppointmentID;
        private mode mod;
        public ScheduleTest_Screen()
        {
            InitializeComponent();
        }
        public ScheduleTest_Screen(int appointmentID, int statusAppointment)
        {
            InitializeComponent();
            if (!DesignMode)
            {
                AppointmentID = appointmentID;
                mod = mode.Update;
                TA=clsTset_Appointments.GetTest_AppointmentBy_AppointmentID(appointmentID);
                localid = TA.LocalID;
                appointment_usercontrol1.localid = localid;
                StatusAppointment = statusAppointment;
                TestTypeid = TA.TestTypeID;
                appointment_usercontrol1.send_DateAppointment += SetAppointmentDate;
                appointment_usercontrol1.testTypeID = TestTypeid;
                appointment_usercontrol1.SetAppointmentDate_ForUpdate(TA.AppointmentDate);
                appointmentInfoRetakeTest_usercontrol1.TestTypeID = TestTypeid;
            }
        }

        public ScheduleTest_Screen(int localid,int TestTypeid, int statusAppointment)
        {
            InitializeComponent();
            if (!DesignMode)
            {
                mod = mode.Add;
                this.localid = localid;
                appointment_usercontrol1.localid = localid;
                StatusAppointment = statusAppointment;
                this.TestTypeid = TestTypeid;
                appointment_usercontrol1.send_DateAppointment += SetAppointmentDate;
                appointment_usercontrol1.testTypeID = TestTypeid;
                appointmentInfoRetakeTest_usercontrol1.TestTypeID = TestTypeid;
                TA = new clsTset_Appointments();
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

        private void ScheduleTest_Screen_Load(object sender, EventArgs e)
        {
            if (StatusAppointment == 1)
            {
                appointmentInfoRetakeTest_usercontrol1.Enabled = false;
                PaidFees = appointment_usercontrol1.paidFees;
            }
            else if (StatusAppointment == 2)
            {
                appointmentInfoRetakeTest_usercontrol1.Enabled = true;
                PaidFees = appointmentInfoRetakeTest_usercontrol1.GetFeesForRetakeTest();

            }
            else if (StatusAppointment == 3)
            {
                btnSave.Enabled=false;
                appointment_usercontrol1.Pass();
            }
        }

        
        private void btnSave_Click(object sender, EventArgs e)
        {   
            
            TA.LocalID = localid;
            TA.PaidFees = PaidFees;
            TA.TestTypeID = TestTypeid;
            TA.CreatedByUserID = LoginScreen.userid;
            TA.AppointmentDate = AppointmentDate;
            TA.IsLoaked = 0;
            if(TA.Save())
            {
                MessageBox.Show("An appointment has been succefully booked","Message",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
                btnSave.Enabled=false;
                if(StatusAppointment==2)
                appointmentInfoRetakeTest_usercontrol1.SetRLocalID(TA.LocalID);
            }
            else
            {
                MessageBox.Show("Appointment booking failed", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }
        }
        
        public void SetAppointmentDate(DateTime date)
        {
            AppointmentDate = date;
            PaidFees = clsApplication.GetFeesTest(TestTypeid);    
        }
    }
}
