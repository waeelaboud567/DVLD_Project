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

namespace presntion_DVLD.UserConrol
{
    public partial class UserControl1 : UserControl
    {
        public int LocalID;
        public int LicenseID;
        public UserControl1()
        {
            InitializeComponent();
        }
        private void _LoadData()
        {   
            
            
            DataView dv = clsLicense.GetDataForDrivingLicenceInfo(LicenseID);
            if (dv.Count > 0)
            {
                labresualtClass.Text = dv[0][0].ToString();
                labresultName.Text = dv[0][1].ToString();
                labresultLicenseID.Text = dv[0][2].ToString();
                labresultNN.Text = dv[0][3].ToString();

                if (dv[0][4].ToString() == "0")
                    labresultGendar.Text = "Male";
                else
                    labresultGendar.Text = "Female";

                labresultIssueDate.Text = Convert.ToDateTime(dv[0][5]).ToShortDateString();

                labresualtIssueReason.Text = IssueReasonOptions(Convert.ToInt32(dv[0][6].ToString()));

                if (dv[0][7].ToString() == "")
                    labresultNotes.Text = "No Notes";
                else
                    labresultNotes.Text = dv[0][7].ToString();

                labresultDOB.Text = Convert.ToDateTime(dv[0][9]).ToShortDateString();
                labresultIsActive.Text = dv[0][8].ToString();
                labresultDriverID.Text = dv[0][10].ToString();
                labresultExpDate.Text = Convert.ToDateTime(dv[0][11]).ToShortDateString();
                if(clsDetainedLicenses.IsDetain(LicenseID))
                    labresualtIsDetained.Text = "Yes";
                else
                    labresualtIsDetained.Text = "No";


                if (dv[0][12].ToString() != "")
                    pictureBox1.Image = Image.FromFile(dv[0][12].ToString());
            }
            
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        public void LoadDaraByLicensesID(int licensesID)
        {
            LicenseID = licensesID;
            //LocalID = clsLicense.BackLocalIDByLicensesID(LicenseID);
            if(LicenseID == -1)
            {
                MessageBox.Show("He does not possess local class 3 license", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                _LoadData();
            }
        }
        private string IssueReasonOptions(int IssueReasonID)
        {
            
            switch(IssueReasonID)
            {
                case 1:
                    return "First Time";
                    break;
                case 2:
                    return "Renew";
                    break;
                default:
                    return "No Reason";
            }
        }
    }
}
