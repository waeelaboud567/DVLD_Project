using Business_DVLD;
using presntion_DVLD.Application;
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
    public partial class LocalDrivingLicenseApplication_Screen : Form
    {
        public enum StatusApplication { Complete = 3, New = 1, Cancel = 2 }
        public enum TestTypes { VisionTest = 1, WrittenTest = 2, StreetTest = 3 }
        DataTable dt;
        public LocalDrivingLicenseApplication_Screen()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    if (textBox1.Text != "")
                    {
                        dataGridView1.DataSource = clsApplication.FindByApplicationID(Convert.ToInt32(textBox1.Text));
                    }
                    else
                    {
                        Refrach();
                    }
                    break;
                case 1:
                    if (textBox1.Text != "")
                    {
                        dataGridView1.DataSource = clsApplication.FindByDrivingClass(textBox1.Text);

                    }
                    else
                    {
                        Refrach();

                    }
                    break;
                case 2:
                    if (textBox1.Text != "")
                    {
                        dataGridView1.DataSource = clsApplication.FindByNNO(textBox1.Text);

                    }
                    else
                    {
                        Refrach();

                    }
                    break;
                case 3:
                    if (textBox1.Text != "")
                    {
                        dataGridView1.DataSource = clsApplication.FindByFullName(textBox1.Text);
                    }
                    else
                    {
                        Refrach();

                    }
                    break;
                case 4:
                    if (textBox1.Text != "")
                    {
                        // dataGridView1.DataSource = clsLocalDrivingLicenseApplicationJoinTabels.FindByApplicationDate(textBox1.Text);
                    }
                    else
                    {
                        Refrach();

                    }
                    break;
                case 5:
                    if (textBox1.Text != "")
                    {
                        dataGridView1.DataSource = clsApplication.FindByStatus(textBox1.Text);
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
        private void Refrach()
        {
            dt = clsApplication.GetAllApplication().ToTable();
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            labresultCountRecord.Text = (dataGridView1.Rows.Count).ToString();

        }

        private void LocalDrivingLicenseApplication_Screen_Load(object sender, EventArgs e)
        {
            Refrach();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewLocalDrivingLicenseApplication_Screen f = new NewLocalDrivingLicenseApplication_Screen();
            f.ShowDialog();
            Refrach();
        }

        private void refrechToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Refrach();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                object cellValue = selectedRow.Cells["LocalDrivingLicenseApplicationID"].Value;

                if (cellValue != null && cellValue != DBNull.Value)
                {
                    string i = cellValue.ToString();
                    if (MessageBox.Show($"Do you want to delete Application ",
                    "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        int appid = clsApplication.GetAppliccationIDByLDLA(Convert.ToInt32(i));

                        if (clsApplication.DeleteApplicationFromLDLA(appid))
                        {


                            MessageBox.Show("Deleted Successfully", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                        }
                        else
                        {
                            MessageBox.Show("Deletetion Failed", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.None);

                        }



                        Refrach();
                    }
                }
                else
                {
                    MessageBox.Show("There is not specific person");
                }

            }
            else
            {
                MessageBox.Show("error");
            }
            Refrach();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dataGridView1.ClearSelection();

                dataGridView1.Rows[e.RowIndex].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                object cellValue2 = selectedRow.Cells["status"].Value;
                object cellValue3 = selectedRow.Cells["PassedTestCount"].Value;
                string status = cellValue2.ToString();


                Enabled_OptionsInCMS_ByPassedTest(Convert.ToInt32(cellValue3));
                Enabled_OptionsInCMS_ByApplicationStatus(status);

            }
        }

        private void Enabled_OptionsInCMS_ByPassedTest(int countPassedTest)
        {
            if (countPassedTest == 0 || countPassedTest == 1 || countPassedTest == 2)
            {
                _whileCountPassedTestEqualZeroOrOneOrTow();
            }
            else
            {
                _whileCountPassedTestEqualThree();
            }
        }
        private void _whileCountPassedTestEqualZeroOrOneOrTow()
        {
            editToolStripMenuItem.Enabled = true;
            deleteToolStripMenuItem.Enabled = true;
            cancelToolStripMenuItem.Enabled = true;
            TestToolStripMenuItem.Enabled = true;
            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            showLicenseToolStripMenuItem.Enabled = false;
            showPersonLicenseHistoryToolStripMenuItem.Enabled = false;
        }
        private void _whileCountPassedTestEqualThree()
        {
            editToolStripMenuItem.Enabled = true;
            deleteToolStripMenuItem.Enabled = true;
            cancelToolStripMenuItem.Enabled = true;
            TestToolStripMenuItem.Enabled = false;
            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
            showLicenseToolStripMenuItem.Enabled = false;
            showPersonLicenseHistoryToolStripMenuItem.Enabled = false;
        }

        private void Enabled_OptionsInCMS_ByApplicationStatus(string status)
        {
            if (status == "Cancelled")
            {

                TestToolStripMenuItem.Enabled = false;
                editToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = true;
                cancelToolStripMenuItem.Enabled = false;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = false;
                showPersonLicenseHistoryToolStripMenuItem.Enabled = false;


            }
            else if (status == "Completed")
            {
                editToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
                cancelToolStripMenuItem.Enabled = false;
                TestToolStripMenuItem.Enabled = false;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = true;
                showPersonLicenseHistoryToolStripMenuItem.Enabled = true;
            }

        }


        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                object cellValue = selectedRow.Cells["LocalDrivingLicenseApplicationID"].Value;

                if (cellValue != null && cellValue != DBNull.Value)
                {
                    string i = cellValue.ToString();
                    if (MessageBox.Show($"Do you want to Canseled Application ",
                    "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        int appid = clsApplication.GetAppliccationIDByLDLA(Convert.ToInt32(i));

                        //1   complete
                        //2   new
                        //3   cancel

                        if (clsApplication.ChangeStatus(Convert.ToInt32(StatusApplication.Cancel), appid))
                        {
                            MessageBox.Show("Change Status Successfully", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.None);

                        }
                        else
                        {
                            MessageBox.Show("Change Status Failed", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.None);

                        }


                        Refrach();
                    }
                }
                else
                {
                    MessageBox.Show("There is not specific Row");
                }
            }
            else
            {
                MessageBox.Show("error");
            }
            Refrach();
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                object cellValue = selectedRow.Cells["LocalDrivingLicenseApplicationID"].Value;


                if (cellValue != null && cellValue != DBNull.Value)

                {
                    int idlocal = Convert.ToInt32(cellValue.ToString());
                    int appid = clsApplication.GetAppliccationIDByLDLA(Convert.ToInt32(idlocal));




                    Vision_Test_Appointments_Screen f = new Vision_Test_Appointments_Screen(appid, idlocal, Convert.ToInt32(TestTypes.VisionTest)); ;
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("There is not specific person");
                }
            }
            else
            {
                MessageBox.Show("error");
            }
            Refrach();
        }

        private void _checkPassedTest(int passedTestCount)
        {
            if (passedTestCount == 0)
            {
                cmsVisionTest.Enabled = true;
                cmsWrittenTest.Enabled = false;
                cmsStreetTest.Enabled = false;
            }
            else if (passedTestCount == 1)
            {
                cmsVisionTest.Enabled = false;
                cmsWrittenTest.Enabled = true;
                cmsStreetTest.Enabled = false;
            }
            else if (passedTestCount == 2)
            {
                cmsVisionTest.Enabled = false;
                cmsWrittenTest.Enabled = false;
                cmsStreetTest.Enabled = true;
            }
            else
            {
                cmsVisionTest.Enabled = false;
                cmsWrittenTest.Enabled = false;
                cmsStreetTest.Enabled = false;
            }


        }

        private void phoneCallToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                object cellValuePassedTest = selectedRow.Cells["PassedTestCount"].Value;


                if (cellValuePassedTest != null && cellValuePassedTest != DBNull.Value)
                {
                    string ptc = cellValuePassedTest.ToString();
                    _checkPassedTest(Convert.ToInt32(ptc));
                }
                else
                {
                    MessageBox.Show("There is not specific Row");
                }
            }


            else
            {
                MessageBox.Show("error");
            }



        }

        private void cmsWrittenTest_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                object cellValue = selectedRow.Cells["LocalDrivingLicenseApplicationID"].Value;


                if (cellValue != null && cellValue != DBNull.Value)

                {
                    int idlocal = Convert.ToInt32(cellValue.ToString());
                    int appid = clsApplication.GetAppliccationIDByLDLA(Convert.ToInt32(idlocal));




                    Vision_Test_Appointments_Screen f = new Vision_Test_Appointments_Screen(appid, idlocal, Convert.ToInt32(TestTypes.WrittenTest)); ;
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("There is not specific person");
                }
            }
            else
            {
                MessageBox.Show("error");
            }
            Refrach();
        }

        private void cmsStreetTest_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                object cellValue = selectedRow.Cells["LocalDrivingLicenseApplicationID"].Value;


                if (cellValue != null && cellValue != DBNull.Value)

                {
                    int idlocal = Convert.ToInt32(cellValue.ToString());
                    int appid = clsApplication.GetAppliccationIDByLDLA(Convert.ToInt32(idlocal));




                    Vision_Test_Appointments_Screen f = new Vision_Test_Appointments_Screen(appid, idlocal, Convert.ToInt32(TestTypes.StreetTest)); ;
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("There is not specific person");
                }
            }
            else
            {
                MessageBox.Show("error");
            }
            Refrach();
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;

            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                object cellValue = selectedRow.Cells["LocalDrivingLicenseApplicationID"].Value;
                object cellValue2 = selectedRow.Cells["ClassName"].Value;

                if (cellValue != null && cellValue != DBNull.Value)
                {
                    int idlocal = Convert.ToInt32(cellValue.ToString());
                    int appid = clsApplication.GetAppliccationIDByLDLA(Convert.ToInt32(idlocal));
                    int classID = clsLicenseClasses.GetClassID(cellValue2.ToString());



                    IssueDriver_LicenseForFirst_Time f = new IssueDriver_LicenseForFirst_Time(appid, idlocal, classID); ;
                    f.ShowDialog();
                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show("error");
            }
            Refrach();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                object cellValue = selectedRow.Cells["LocalDrivingLicenseApplicationID"].Value;
                int LocalID = Convert.ToInt32(cellValue.ToString());
                int LicenseID = clsLicense.GetLicenseIDByLocalID(LocalID);
                if (cellValue != null && cellValue != DBNull.Value)
                {
                    DriverLicense_Info f = new DriverLicense_Info(LicenseID);
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("There is not specific Row");
                }

                Refrach();
            }
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                object cellValue = selectedRow.Cells["LocalDrivingLicenseApplicationID"].Value;
                object cellValue2 = selectedRow.Cells["NationalNo"].Value;

                int LocalDrivingLicenseApplicationID = Convert.ToInt32(cellValue.ToString());

                if (cellValue != null && cellValue != DBNull.Value)
                {
                    LicenseHistory_Screen f = new LicenseHistory_Screen(LocalDrivingLicenseApplicationID, cellValue2.ToString());
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("There is not specific Row");
                }

                Refrach();
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localDrivingLicenseApplicationID=Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            int appID = clsApplication.GetAppliccationIDByLDLA(localDrivingLicenseApplicationID);
            LocalDrivingLicenseApplication_Info frm = new LocalDrivingLicenseApplication_Info(appID, localDrivingLicenseApplicationID);
            frm.ShowDialog();
        }
    }
}
