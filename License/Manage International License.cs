using Business_DVLD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace presntion_DVLD
{
    public partial class Manage_International_License : Form
    {
        public Manage_International_License()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Manage_International_License_Load(object sender, EventArgs e)
        {
            Refrach();
        }
        private void Refrach()
        {
            DataView dt = clsInternationalLicense.GetAllInternationalLicenses();
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            labresultCountRecord.Text = (dataGridView1.Rows.Count).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewInternationalLicenseApplication_screen f=new NewInternationalLicenseApplication_screen();
            f.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    if (textBox1.Text != "")
                    {
                        dataGridView1.DataSource = clsInternationalLicense.FindByInternationalLicenseID(Convert.ToInt32(textBox1.Text));
                    }
                    else
                    {
                        Refrach();
                    }
                    break;
                case 1:
                    if (textBox1.Text != "")
                    {
                        dataGridView1.DataSource = clsInternationalLicense.FindByApplicationID(Convert.ToInt32(textBox1.Text));
                    }
                    else
                    {
                        Refrach();

                    }
                    break;
                case 2:
                    if (textBox1.Text != "")
                    {
                        dataGridView1.DataSource = clsInternationalLicense.FindByDriverID(Convert.ToInt32(textBox1.Text));
                    }
                    else
                    {
                        Refrach();

                    }
                    break;
                case 3:
                    if (textBox1.Text != "")
                    {
                        dataGridView1.DataSource = clsInternationalLicense.FindByCreatedbyUserID(Convert.ToInt32(textBox1.Text));
                    }
                    else
                    {
                        Refrach();

                    }
                    break;
                default:
                    break;
            }
        }

        private void showPToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                object cellValue = selectedRow.Cells["IssuedUsingLocalLicenseID"].Value;

                if (cellValue != null && cellValue != DBNull.Value)
                {
                    string IssuedUsingLocalLicenseID = cellValue.ToString();
                    int personID = clsLicense.GetPersonIDByLicenseID(Convert.ToInt32(IssuedUsingLocalLicenseID));
                    Person_Details f = new Person_Details(personID.ToString());
                    f.Show();

                }
                else
                {
                    MessageBox.Show("There is no value");
                }
            }
            else
            {
                MessageBox.Show("No specific records");
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dataGridView1.ClearSelection();

                dataGridView1.Rows[e.RowIndex].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                object cellValue = selectedRow.Cells["IssuedUsingLocalLicenseID"].Value;

                if (cellValue != null && cellValue != DBNull.Value)
                {
                    string IssuedUsingLocalLicenseID = cellValue.ToString();
                    int localid= clsLicense.BackLocalIDByLicensesID(Convert.ToInt32(IssuedUsingLocalLicenseID));
                    DriverLicense_Info f2 = new DriverLicense_Info(Convert.ToInt32(localid));
                    f2.ShowDialog();
                    Refrach();
                }
                else
                {
                    MessageBox.Show("There is no value");
                }
            }
            else
            {
                MessageBox.Show("No specific records");
            }

        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                object cellValue = selectedRow.Cells["IssuedUsingLocalLicenseID"].Value;
                object cellValue2 = selectedRow.Cells["DriverID"].Value;
                string nationalNO = clsDriver.GetNationalNoByDriverID(Convert.ToInt32(cellValue2.ToString()));

                int LocalLicenseID = Convert.ToInt32(cellValue.ToString());
                int localid = clsLicense.BackLocalIDByLicensesID(Convert.ToInt32(LocalLicenseID));

                if (cellValue != null && cellValue != DBNull.Value)
                {
                    LicenseHistory_Screen f = new LicenseHistory_Screen(nationalNO , LocalLicenseID);
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("There is not specific Row");
                }

                Refrach();
            }
        }
    }
}
