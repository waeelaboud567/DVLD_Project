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

    public partial class AddNew_UpdateUser : Form
    {
        

        private int _pid;
        private string _username;
        private string _password;
        private bool _active;
        private clsUser _user;
        

        public AddNew_UpdateUser()
        {
            InitializeComponent();
        }
        public AddNew_UpdateUser(int personid)
        {
            InitializeComponent();
            label1.Text = "Update User";
            _pid = personid;
            addUser_usercontrol1.personid = _pid;
            addUserPartUserInfo_usercontrol1.mod = AddUserPartUserInfo_usercontrol.Mode.Update;


        }

        private void AddNewUser_Load(object sender, EventArgs e)
        {
            
                addUser_usercontrol1.Next += _GetPersonID;
                addUserPartUserInfo_usercontrol1.finsh += _GetInfoUser;
                _pid = -1;
                _username = "";
                _password = "";
              
        }

        private void _GetPersonID(int id)
        {
            _pid = id;
            addUserPartUserInfo_usercontrol1.personid = _pid;
            tabcontrol1.SelectedIndex += 1;
        }
        private void _GetInfoUser(string username,string password,bool active)
        {
            _username = username;
            _password = password;
            _active   = active;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (_username != "" && _password != "" && _pid != -1)
            {
                if (addUserPartUserInfo_usercontrol1.uid == -1)
                {
                    _user = new clsUser();
                    _user.PersonID = _pid;
                    _user.UserName = _username;
                    _user.Password = _password;
                    _user.IsActive = _active;
                }
                else
                {
                    _user=new clsUser(addUserPartUserInfo_usercontrol1.uid,_username,_pid,_password,_active);
                }

                if(_user.Save())
                {
                    MessageBox.Show(" successfully", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    addUserPartUserInfo_usercontrol1.ShowUserID(_user.UserID);
                }
                else
                {
                    MessageBox.Show("Failed", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                }
            }
        }

        private void addUserPartUserInfo_usercontrol1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
