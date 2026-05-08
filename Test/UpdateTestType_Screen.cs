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
    public partial class UpdateTestType_Screen : Form
    {
        public int id;
        public UpdateTestType_Screen()
        {
            InitializeComponent();
        }
        public UpdateTestType_Screen(int ID)
        {
            InitializeComponent();
            id = ID;
        }
        public void GetTestType()
        {
            DataView dv = clsTestTypes.GetTestType(id);
            labID.Text =id.ToString();
            txtTitle.Text = dv[0][1].ToString();
            txtDESC.Text  = dv[0][2].ToString();
            txtFees.Text = dv[0][3].ToString();
        }
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateTestType_Screen_Load(object sender, EventArgs e)
        {
            GetTestType();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text != "" && txtFees.Text != "" && txtDESC.Text !="")
            {
                if (clsApplicationTypes.UpdateTestType(id, txtTitle.Text,txtDESC.Text, txtFees.Text))
                {
                    MessageBox.Show("Save Successfully", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                }
            }
            else
            {
                MessageBox.Show("Fill In All The Fields", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }
    }
}
