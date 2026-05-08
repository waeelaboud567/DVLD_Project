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
    public partial class personDetailsAndUserInfo_UserControl : UserControl
    {
        public int PID;
        public personDetailsAndUserInfo_UserControl()
        {

            InitializeComponent();

        }

        private void person_details_usercontrol1_Load(object sender, EventArgs e)
        {

        }
        public void GivePID(int personid)
        {
            PID= personid;
            person_details_usercontrol1.id = PID.ToString();

        }
        private void personDetailsAndUserInfo_UserControl_Load(object sender, EventArgs e)
        {
            _GetUserInfo();
        }
        private void _GetUserInfo()
        {
            DataView dv = clsUser.FindPersonID(PID);
            if (dv != null && dv.Count > 0)
            {
                labResultUserID.Text = dv[0][0].ToString();
                labResultUserName.Text = dv[0][3].ToString();
                if (Convert.ToBoolean(dv[0][4]) == true)
                {
                    labResultIsActive.Text = "Yes";
                }
                else
                {
                    labResultIsActive.Text = "No";
                }
            }
        }

        }
    }
