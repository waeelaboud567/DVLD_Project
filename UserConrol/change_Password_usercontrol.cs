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
    public partial class change_Password_usercontrol : UserControl
    {
        private bool _change_Photo;
        public event Action<string, string> sendNewPassword;

        public change_Password_usercontrol()
        {
            InitializeComponent();
        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            if (_change_Photo)
            {
                btnEyeCP.Image = Properties.Resources.eye_close;
                txtCurrentPassword.UseSystemPasswordChar = true;
                _change_Photo = false;
            }
            else
            {
                btnEyeCP.Image = Properties.Resources.eye_open;
                txtCurrentPassword.UseSystemPasswordChar = false;
                _change_Photo = true;
            }
        }

        private void btnEyeNP_Click(object sender, EventArgs e)
        {
            if (_change_Photo)
            {
                btnEyeNP.Image = Properties.Resources.eye_close;
                txtNewPassword.UseSystemPasswordChar = true;
                _change_Photo = false;
            }
            else
            {
                btnEyeNP.Image = Properties.Resources.eye_open;
                txtNewPassword.UseSystemPasswordChar = false;
                _change_Photo= true;
            }
        }

        private void btnEyeConP_Click(object sender, EventArgs e)
        {
            if (_change_Photo)
            {
                btnEyeConP.Image = Properties.Resources.eye_close;
                txtConfirmPassword.UseSystemPasswordChar = true;
                _change_Photo = false;
            }
            else
            {
                btnEyeConP.Image = Properties.Resources.eye_open;
                txtConfirmPassword.UseSystemPasswordChar = false;
                _change_Photo = true;
            }
        }

        private void txtCurrentPassword_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtCurrentPassword_Validated(object sender, CancelEventArgs e)
        {
            if (txtCurrentPassword.Text.Length != 4)
            {
                errorProvider1.SetError(txtCurrentPassword, "password must be consits 4 character");
                e.Cancel = true;

            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, "");
            }
        }

        private void txtConfirmPassword_Validated(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text != txtNewPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "Error");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, "");
            }
        }

        private void txtNewPassword_Validated(object sender, CancelEventArgs e)
        {
            if (txtNewPassword.Text.Length != 4)
            {
                errorProvider1.SetError(txtNewPassword, "password must be consits 4 character");
                e.Cancel = true;

            }
            else
            {
                errorProvider1.SetError(txtNewPassword, "");
            }
        }
        public void SendNewPasswordAndCurrentPasswordToForm()
        {
            sendNewPassword?.Invoke(txtCurrentPassword.Text,txtNewPassword.Text);
        }

        private void change_Password_usercontrol_Load(object sender, EventArgs e)
        {
            _change_Photo = true;
        }
    }
}
