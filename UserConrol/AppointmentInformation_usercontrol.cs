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
    public partial class AppointmentInformation_usercontrol : UserControl
    {
        public int localid;
        public int testTypeID;
        public int paidFees;
        public event Action<DateTime> send_DateAppointment;
        
        public AppointmentInformation_usercontrol()
        {
            InitializeComponent();

        }

        private void Appointment_usercontrol_Load(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = DateTime.Now.Date;
            _LoadData();
            
        }

        private void _LoadData()
        {
            DataView dv = clsApplication.LoadData_ToAppointmentInfo_UserControl(localid);
            if (dv != null && dv.Count > 0)
            {
                labresultID.Text = dv[0][0].ToString();
                labresultDClass.Text = dv[0][1].ToString();
                labresultName.Text = dv[0][2].ToString();
                paidFees = clsApplication.GetFeesTest(testTypeID);
                labresultFees.Text = paidFees.ToString();
            }
        }
        public void Pass()
        {
            dateTimePicker2.Enabled = false;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {   
          
            send_DateAppointment?.Invoke(dateTimePicker2.Value);
        }
        public void SetAppointmentDate_ForUpdate(DateTime date)
        {
            dateTimePicker2.Value = date;
        }
    }
}
