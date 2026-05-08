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
    public partial class AppointmentInfoRetakeTest_usercontrol : UserControl
    {
        public int RLocalID;
        public int TestTypeID;
        private int _FeesReTakeTest = 5;
        public AppointmentInfoRetakeTest_usercontrol()
        {
            InitializeComponent();
        }

        private void AppointmentInfoRetakeTest_usercontrol_Load(object sender, EventArgs e)
        {   
            
                
            
        }
        private void _LoadFeesForRetakeTest()
        {
            labresultTotalFees.Text = (clsApplication.GetFeesTest(TestTypeID) + _FeesReTakeTest).ToString();
            labresultRAppFees.Text = _FeesReTakeTest.ToString();
        }
        public int GetFeesForRetakeTest()
        {
            _LoadFeesForRetakeTest();
            return Convert.ToInt32(labresultTotalFees.Text) + Convert.ToInt32(_FeesReTakeTest.ToString());
        }
        public void SetRLocalID(int id)
        {
            RLocalID = id;
            labresultRTestAppI.Text= RLocalID.ToString();
        }
    }
}
