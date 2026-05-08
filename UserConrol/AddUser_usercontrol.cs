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
    public partial class AddUser_usercontrol : UserControl
    {  
        private  enum Mode {Add=0, Update=1}
        public int personid = -1;
        public event Action<int> Next;
        Mode mode;

        
        public AddUser_usercontrol()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != "none")
                textBox1.Visible = true;
            else
                textBox1.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _Click_Serach_Person();
        }
        private void _Click_Serach_Person()
        {


            btnNext.Enabled = false;
            if (textBox1.Text != "")
            {
                DataView dv = new DataView();
                switch (comboBox1.SelectedItem)
                {
                    case "PersonID":
                        personid = Convert.ToInt32(textBox1.Text);
                        dv = clspeople.FindPersonID(personid);
                        if (dv != null && dv.Count > 0)
                        {
                            person_details_usercontrol1.SetID(personid.ToString());

                            btnNext.Enabled = true;

                            if (dv[0][1] != null)
                                personid = Convert.ToInt32(dv[0][0].ToString());
                            else
                                MessageBox.Show("noooooooooooooooooo");

                        }
                        else
                        {
                            MessageBox.Show("Person is not found", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        }
                        break;
                    case "NationalNO":
                        string NNO = textBox1.Text;
                        dv = clspeople.FindNationalNo(NNO);
                        if (dv != null && dv.Count > 0)
                        {
                            person_details_usercontrol1.SetID(dv[0][0].ToString());
                            btnNext.Enabled = true;
                            personid = Convert.ToInt32(dv[0][0].ToString());

                        }
                        else
                        {
                            MessageBox.Show("Person is not found", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        }
                        break;
                    default:

                        break;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            AddOrUpdatePersonInfo f=new AddOrUpdatePersonInfo();
            f.BackPersonID += BackPersonIDAfterAdded;
            f.ShowDialog();
        }
        private void BackPersonIDAfterAdded(string PID)
        {
            textBox1.Text = PID;
            comboBox1.SelectedItem = "PersonID";
            _Click_Serach_Person();

        }
        private void update_user_usercontrol_Load(object sender, EventArgs e)
        {    if (personid == -1)
            {
                btnNext.Enabled = false;
                comboBox1.SelectedItem = "none";
                mode = Mode.Add;
            }
        else
            {
                groupBox1.Enabled = false;
                person_details_usercontrol1.SetID(personid.ToString());
                btnNext.Enabled = true;
                mode = Mode.Update;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (mode == Mode.Update)
            {
                Next?.Invoke(personid);
            }
            else
            {
                if (clsUser.IsUser(personid))
                {
                    MessageBox.Show("He is already a user", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                else
                {
                    Next?.Invoke(personid);
                }
            }
            
        }
        
    }
}
