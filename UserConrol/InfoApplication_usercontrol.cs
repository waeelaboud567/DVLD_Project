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
    public partial class InfoApplication_usercontrol : UserControl
    {
        public int localid { set; get; }
        public int appid { set; get; }
        

        public event Action<int> GetPersonID_Event;
        
        public InfoApplication_usercontrol()
        {
            InitializeComponent();
        }

        private void InfoApplication_usercontrol_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {   
            DataView dv=clsApplication.LoadDataTo_InfoApplication_UserControl(localid, appid);
            if (dv != null && dv.Count > 0)
            {
                labresultLDLAppID.Text = dv[0][0].ToString();
                labresultAFL.Text= dv[0][1].ToString();
                labresultPassedTests.Text = dv[0][2].ToString() + "/3";
                labresultID.Text = dv[0][3].ToString();
                labresultStatus.Text = dv[0][4].ToString();
                labresultFees.Text = dv[0][5].ToString();
                labresultType.Text = dv[0][6].ToString();
                labresultApplicant.Text = dv[0][7].ToString();
                labresultDate.Text = dv[0][8].ToString();
                labresultStatusDate.Text = dv[0][9].ToString();
                labresultCreatedBy.Text = dv[0][10].ToString();

                GetPersonID_Event?.Invoke(Convert.ToInt32(dv[0][11].ToString()));                
            }
            else
            {
                MessageBox.Show("No Spcific Row", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
    }
}
