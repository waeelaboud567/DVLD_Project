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
    public partial class ChangePasswod_Screen : Form
    {
        private int    _PID;
        private string _CurrentPassword;
        private string _NewPassword;
        public ChangePasswod_Screen()
        {
            InitializeComponent();

        }

        public ChangePasswod_Screen(int personid)
        {
            InitializeComponent();
            _PID= personid;
            personDetailsAndUserInfo_UserControl1.GivePID(_PID);
            change_Password_usercontrol1.sendNewPassword += GetNewPasswordAndCurrentPassword;

        }

        private void GetNewPasswordAndCurrentPassword(string CurrentPassword,string NewPassword)
        {
            _CurrentPassword = CurrentPassword;
            _NewPassword = NewPassword;
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            change_Password_usercontrol1.SendNewPasswordAndCurrentPasswordToForm();
            if(_CurrentPassword!="" && _NewPassword!="")
            {
                if(clsUser.ChangePassword(_PID,_CurrentPassword,_NewPassword))
                {
                    MessageBox.Show("Change Password successfully","Message",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Change Password faild Check CurrentPassword", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Fill All Field To Change User", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
        }

        private void ChangePasswod_Screen_Load(object sender, EventArgs e)
        {

        }

        private void change_Password_usercontrol1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
