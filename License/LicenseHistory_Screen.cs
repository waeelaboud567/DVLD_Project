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
    public partial class LicenseHistory_Screen : Form
    {
        private int LicenseID;
        private string NationalNo;
        public LicenseHistory_Screen(int LocalDrivingLicenseApplicationID, string NationalNo)
        {
            InitializeComponent();
            LicenseID = clsLicense.GetLicenseIDByLocalID(LocalDrivingLicenseApplicationID);
            this.NationalNo = NationalNo;
            
            person_details_usercontrol1.id = clsLicense.GetPersonIDByLicenseID(LicenseID).ToString();


        }
        public LicenseHistory_Screen( string NationalNo ,int licenseID)
        {
            InitializeComponent();
            LicenseID = licenseID;
            this.NationalNo = NationalNo;

            person_details_usercontrol1.id = clsLicense.GetPersonIDByLicenseID(LicenseID).ToString();


        }
        private void LicenseHistory_Screen_Load(object sender, EventArgs e)
        {           
            _LoadData();
        }

        private void _LoadData()
        {
            dataGridView1.DataSource= clsLicense.GetAllLicensesForDrivers(LicenseID);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView2.DataSource = clsLicense.GetAllInternationalLicensesForDrivers(NationalNo);
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            labresultCountRecord.Text=(dataGridView1.Rows.Count+dataGridView2.Rows.Count).ToString();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
