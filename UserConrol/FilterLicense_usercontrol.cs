using Guna.UI2.WinForms;
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
    public partial class FilterLicense_usercontrol : UserControl
    {
        public int LocalLicenseID=0;
        public event Action<int> GetLocalLicenseID;
        public event Action IsExsitsLicense;
        public FilterLicense_usercontrol()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _LoadData();
        }
        
        public void SetLicenseID(int licenseID)
        {
            TextBox1.Text = licenseID.ToString();
            _LoadData();
            TextBox1.Enabled = false;
            button1 .Enabled = false;
        }
        private void _LoadData()
        {
            if (TextBox1.Text != "")
            {
                LocalLicenseID = Convert.ToInt32(TextBox1.Text);
                userControl11.LoadDaraByLicensesID(LocalLicenseID);
                if (LocalLicenseID != 0)
                {
                    GetLocalLicenseID?.Invoke(LocalLicenseID);
                    IsExsitsLicense?.Invoke();
                }
                else
                {
                    MessageBox.Show("not have Local License", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Enter LicensesID !!!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

    }
}
