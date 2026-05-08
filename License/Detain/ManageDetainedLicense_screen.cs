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
    public partial class ManageDetainedLicense_screen : Form
    {
        public ManageDetainedLicense_screen()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DetainLicense_screen f=new DetainLicense_screen();
            f.Show();
            Refrach();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicense_screen f=new ReleaseDetainedLicense_screen();
            f.Show();
            Refrach();
        }

        private void ManageDetainedLicense_screen_Load(object sender, EventArgs e)
        {
            Refrach();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    if (textBox1.Text != "")
                    {
                        dataGridView1.DataSource = clsDetainedLicenses.FindDetainID(Convert.ToInt32(textBox1.Text));
                        labresultCountRecord.Text = (dataGridView1.Rows.Count).ToString();
                    }
                    else
                    {
                        Refrach();
                    }
                    break;
                case 1:
                    if (textBox1.Text != "")
                    {
                       dataGridView1.DataSource = clsDetainedLicenses.FindLicenseID(Convert.ToInt32(textBox1.Text));
                       labresultCountRecord.Text = (dataGridView1.Rows.Count).ToString();
                    }
                    else
                    {
                        Refrach();

                    }
                    break;
                case 2:
                    if (textBox1.Text != "")
                    {
                        dataGridView1.DataSource = clsDetainedLicenses.FindNationalNo(textBox1.Text);
                        labresultCountRecord.Text = (dataGridView1.Rows.Count).ToString();
                    }
                    else
                    {
                        Refrach();

                    }
                    break;
               
                    
                default:

                    Refrach();

                    break;
            }

        }
        public void Refrach()
        {
            dataGridView1.DataSource = clsDetainedLicenses.GetDetainedLicenses();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            labresultCountRecord.Text = (dataGridView1.Rows.Count).ToString();
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

                object cellValue = selectedRow.Cells["LicenseID"].Value;

                if (cellValue != null && cellValue != DBNull.Value)
                {
                    int licenseID = Convert.ToInt32(cellValue.ToString());
                    DetainLicense_screen f = new DetainLicense_screen(licenseID);
                    f.Show();
                    Refrach();
                }
                else
                {
                    MessageBox.Show("No Specific Records");
                }
            }
            else
            {
                MessageBox.Show("No Records");
            }
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                object cellValue = selectedRow.Cells["LicenseID"].Value;

                if (cellValue != null && cellValue != DBNull.Value)
                {   
                    int licenseID= Convert.ToInt32(cellValue.ToString());
                    int personID = clsLicense.GetPersonIDByLicenseID(licenseID);
                    string nationalNo = clspeople.GetNationalNoByPersonID(personID);
                    LicenseHistory_Screen f = new LicenseHistory_Screen(nationalNo,licenseID);
                    f.Show();
                    Refrach();
                }
                else
                {
                    MessageBox.Show("No Specific Records");
                }
            }
            else
            {
                MessageBox.Show("No Records");
            }
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                object cellValue = selectedRow.Cells["LicenseID"].Value;

                if (cellValue != null && cellValue != DBNull.Value)
                {
                    int licenseID = Convert.ToInt32(cellValue.ToString());
                    ReleaseDetainedLicense_screen f = new ReleaseDetainedLicense_screen(licenseID);
                    f.Show();
                    Refrach();
                }
                else
                {
                    MessageBox.Show("No Specific Records");
                }
            }
            else
            {
                MessageBox.Show("No Records");
            }
        }

        private void showPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                object cellValue = selectedRow.Cells["LicenseID"].Value;

                if (cellValue != null && cellValue != DBNull.Value)
                {
                    int licenseID = Convert.ToInt32(cellValue.ToString());
                    int personID = clsLicense.GetPersonIDByLicenseID(licenseID);
                    string nationalNo = clspeople.GetNationalNoByPersonID(personID);
                    Person_Details f = new Person_Details(personID.ToString());
                    f.Show();
                    Refrach();
                }
                else
                {
                    MessageBox.Show("No Specific Records");
                }
            }
            else
            {
                MessageBox.Show("No Records");
            }
        }
    }
}
