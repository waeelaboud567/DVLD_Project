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
    public partial class AddUserPartUserInfo_usercontrol : UserControl
    {
        public enum Mode { Add=0,Update=1};
        public int personid;
        public int uid;
        public event Action<string,string,bool> finsh;
        private bool _change_photo_iconeye;
        public Mode mod;
        public AddUserPartUserInfo_usercontrol()
        {
            InitializeComponent();
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "plase enter the Name");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtUserName, "");

        }

        private void txtCPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtCPassword.Text != txtPassword.Text)
            {
                errorProvider1.SetError(txtCPassword, "Error");
            }
            else
            {
                errorProvider1.SetError(txtCPassword,"");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if(txtPassword.Text.Length!=4)
            {
                errorProvider1.SetError(txtPassword, "password must be consits 4 character");
                e.Cancel= true;

            }
            else
            {
                errorProvider1.SetError(txtPassword,"");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if(txtUserName.Text!="" && txtCPassword.Text!="" && txtPassword.Text!="")
            {
                finsh?.Invoke(txtUserName.Text, txtPassword.Text, checkBox1.Checked);
                btnFinsh.Enabled = false;
                
            }

        }
        public void ShowUserID(int userid)
        {
            labresultUserID.Text = userid.ToString();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            _changephoto();
            if (_change_photo_iconeye)
            {
                guna2CircleButton1.Image = Image.FromFile("C:\\Users\\hp\\Pictures\\pic_DVLD\\eye_open.png");
                txtPassword.UseSystemPasswordChar = false;

            }
            else
            {
                guna2CircleButton1.Image = Image.FromFile("C:\\Users\\hp\\Pictures\\pic_DVLD\\eye_close (2).png");
                txtPassword.UseSystemPasswordChar = true;

            }
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            _changephoto();
            if (_change_photo_iconeye)
            {
                guna2CircleButton2.Image = Image.FromFile("C:\\Users\\hp\\Pictures\\pic_DVLD\\eye_open.png");
                txtCPassword.UseSystemPasswordChar = false;

            }
            else
            {
                guna2CircleButton2.Image = Image.FromFile("C:\\Users\\hp\\Pictures\\pic_DVLD\\eye_close (2).png");
                txtCPassword.UseSystemPasswordChar = true;
            }
        }

        private void AddUserPartUserInfo_usercontrol_Load(object sender, EventArgs e)
        {
            _change_photo_iconeye = true;
            uid = -1;
            if (mod == Mode.Update)
            {
                GetInfoUserByPersonId();
            }
        }
        private void GetInfoUserByPersonId()
        {
            DataView dv = clsUser.GetInfoUserByPersonId(personid);
            txtUserName.Text = dv[0][2].ToString();
            txtPassword.Text = dv[0][3].ToString();
            txtCPassword.Text = txtPassword.Text;
            txtPassword.UseSystemPasswordChar=true;
            txtCPassword.UseSystemPasswordChar = true;
            if (Convert.ToBoolean(dv[0][4])==true)
            {
                checkBox1.Checked= true;
            }
            else
            {
                checkBox1.Checked= false;
            }
            ShowUserID(Convert.ToInt32(dv[0][0]));
            uid=Convert.ToInt32(dv[0][0]);
        }
        private void _changephoto()
        {
            if (_change_photo_iconeye == true)
                _change_photo_iconeye = false;
            else
                _change_photo_iconeye = true;
        }
    }
}
