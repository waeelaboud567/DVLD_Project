using Business_DVLD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presntion_DVLD
{
    public partial class LoginScreen : Form
    {
       public static string username;
       public static int userid;
       private string password;
        public LoginScreen()
        {
            InitializeComponent();
            username = "";
            password = "";
           RemmberMeBack();
        }

       
        private bool CheckeUserNameAndPassword()
        {
             username = txtusername.Text;
             password = txtpassword.Text;
            bool flag=false;
            if (clsUser.CheckeUserNameAndPassword(username, password))
            {
                if (clsUser.isActive(username, password))
                {
                    flag = true;
                }
                else
                {
                    MessageBox.Show("User is Not Active", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                }

            }
            else
            {
                MessageBox.Show("UserName or Password is not exsits","Error",MessageBoxButtons.OKCancel,MessageBoxIcon.Stop);
            }
             return flag;
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            if(CheckeUserNameAndPassword())
            {
                userid = clsUser.GetUserID(username, password);
                RemmberMeSave();
                MainScreen f=new MainScreen(userid);
                f.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void RemmberMeSave()
        {


            if (checkBox1.Checked)
            {
                if (clsUser.RemmberMeSave(username, password))
                {
                    MessageBox.Show("Save Successfully", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                }
                else
                {
                    MessageBox.Show("Save Faield", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                }
            }
            else
            {
                RemmberMeDelete();
            }
        }

        public void RemmberMeBack()
        {
            DataView dv = clsUser.RemmbeMeBack();
            if (dv!=null && dv.Count>0)
            {
                txtusername.Text = dv[0][1].ToString();
                txtpassword.Text = dv[0][2].ToString();
            }
        }
        public void RemmberMeDelete()
        {
            clsUser.RemmberMeDelete();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (CheckeUserNameAndPassword())
            {
                userid = clsUser.GetUserID(username, password);
                RemmberMeSave();
                MainScreen f = new MainScreen(userid);
                f.Show();
            }
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {
            checkBox1.Checked= true;
        }
    }
}
