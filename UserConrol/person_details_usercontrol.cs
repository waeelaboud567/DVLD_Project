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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace presntion_DVLD
{
    public partial class person_details_usercontrol : UserControl
    {
        public string id { get; set; }
        public person_details_usercontrol()
        {
            InitializeComponent();
            
        }

        private void person_details_usercontrol_Load(object sender, EventArgs e)
        {
            linkLabel1.Enabled = false;
            SetID(id);
            LoadDataPerson();
        }
        public void SetID(string pid)
        {
            id = pid;
            labw.Text = id;
            LoadDataPerson();
        }
        private void LoadDataPerson()
        {
            DataView dv = clspeople.FindPersonIDForAllColumn(Convert.ToInt32(id));
            if (dv.Count > 0 && dv!=null)
            {
                labresultName.Text = dv[0][2].ToString() + " " + dv[0][3].ToString() + " " + dv[0][4].ToString() + " " + dv[0][5].ToString();
                DateTime dt = DateTime.Now.Date;
                dt = Convert.ToDateTime(dv[0][6]);
                labresultDOB.Text = dt.ToShortDateString();
                if (dv[0][7].ToString() == "1")
                {
                    labresultGendar.Text = "Female";
                    pictureBox1.Image = Properties.Resources.woman;
                }
                else
                {
                    labresultGendar.Text = "Male";

                }
                labresultCountry.Text = clspeople.GetCountryName(Convert.ToInt32(dv[0][11]));
                labresultAddress.Text = dv[0][8].ToString();
                labresultNN.Text = dv[0][1].ToString();
                labresultPhone.Text = dv[0][9].ToString();
                labresultEmail.Text = dv[0][10].ToString();
                if (dv[0][12].ToString() == DBNull.Value.ToString())
                {
                    TheImageReqiuredBefourRemoveImage();
                }
                else
                {
                    pictureBox1.Image = Image.FromFile(dv[0][12].ToString());
                }
                linkLabel1.Enabled = true;

            }

        }
        private void TheImageReqiuredBefourRemoveImage()
        {
            if (labresultGendar.Text=="Male")
            {
                pictureBox1.Image = Properties.Resources.man;

            }
            else
            {
                pictureBox1.Image = Properties.Resources.woman;

            }
        }

        private void labw_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {   
            AddOrUpdatePersonInfo f=new AddOrUpdatePersonInfo(Convert.ToInt32(id));
            f.Show();


        }
    }
}
