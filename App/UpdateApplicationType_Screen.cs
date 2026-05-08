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
    public partial class UpdateApplicationType_Screen : Form
    {
        public string title;
        public string fees;
        public int ID;
        public UpdateApplicationType_Screen()
        {
            InitializeComponent();
        }

        public UpdateApplicationType_Screen(int id)
        {
            InitializeComponent();
            ID = id;
        }
        public void GetApplicationType()
        {
            DataView dv = clsApplicationTypes.GetApplicationType(ID);
            txtTitle.Text = dv[0][1].ToString();
            txtFees.Text  = dv[0][2].ToString();
            title= txtTitle.Text;
            fees= txtFees.Text;
            labID.Text=ID.ToString();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateApplicationType_Screen_Load(object sender, EventArgs e)
        {
            GetApplicationType();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtTitle.Text !="" && txtFees.Text !="")
            {
                if(clsApplicationTypes.UpdateApplicationType(ID,txtTitle.Text,txtFees.Text))
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
