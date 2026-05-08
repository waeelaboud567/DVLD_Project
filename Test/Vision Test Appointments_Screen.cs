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
    public partial class Vision_Test_Appointments_Screen : Form
    {
        enum ModeTest {
            NoAppointmentAvailable=1 ,
            FailureAndRescheduling=2 ,
            Successful=3  }
        private int appid;

        private int localid;

        private int personid;

        private int TestTypeid;



       
        public Vision_Test_Appointments_Screen(int appid, int localid,int Testid)
        {
            InitializeComponent();
            this.appid = appid;
            this.localid = localid;
            this.TestTypeid = Testid;
            infoApplication_usercontrol1.appid = appid;
            infoApplication_usercontrol1.localid = localid;
            
            infoApplication_usercontrol1.GetPersonID_Event += GetPersonID;
            


        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Person_Details f = new Person_Details(personid.ToString());
            f.Show();
        }

        public void GetPersonID(int pid)
        {
            personid=pid;
        }

        private void Vision_Test_Appointments_Screen_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {
            dataGridView1.DataSource = clsTset_Appointments.LoadTestAppointment_ByLDLA_ID(localid);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            labresultCountRecord.Text = dataGridView1.RowCount.ToString();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
           
            if (clsTset_Appointments.AppointmentsIsExists(localid, TestTypeid))
            {
                if (clsTset_Appointments.IsLocked(localid, TestTypeid))
                {
                    if (clsTset_Appointments.ISPassTest(localid, TestTypeid))
                    {
                        ScheduleTest_Screen f = new ScheduleTest_Screen(localid, TestTypeid, Convert.ToInt32(ModeTest.Successful));
                        f.ShowDialog();
                    }
                    else
                    {
                        ScheduleTest_Screen f = new ScheduleTest_Screen(localid, TestTypeid,Convert.ToInt32(ModeTest.FailureAndRescheduling));
                        f.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Appointment is existis","Error",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                }
            }
            else
            {
                ScheduleTest_Screen f = new ScheduleTest_Screen(localid, TestTypeid,Convert.ToInt32(ModeTest.NoAppointmentAvailable));
                f.ShowDialog();
            }

            _LoadData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            object cellValue = selectedRow.Cells["AppointmentID"].Value;

            if (cellValue != null && cellValue != DBNull.Value)
            {
                int i = Convert.ToInt32(cellValue.ToString());

                ScheduleTest_Screen f = new ScheduleTest_Screen(i, Convert.ToInt32(ModeTest.NoAppointmentAvailable));
                f.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("There is not specific Row");  
                
            }
            _LoadData();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dataGridView1.ClearSelection();

                dataGridView1.Rows[e.RowIndex].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                object cellValue2 = selectedRow.Cells["IsLocked"].Value;
                string IsLocked =cellValue2.ToString().Trim();
                if (IsLocked=="True")
                {

                    takeTestToolStripMenuItem.Enabled = false;
                }
                else
                {
                    takeTestToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            object cellValue = selectedRow.Cells["AppointmentID"].Value;

            if (cellValue != null && cellValue != DBNull.Value)
            {
                int appointmentID = Convert.ToInt32(cellValue.ToString());

                TakeTest_Screen f = new TakeTest_Screen(appointmentID, TestTypeid,localid);
                f.ResultTest += GetResultTest;
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("There is not specific Row");

            }
            _LoadData();
        }
        public void GetResultTest(int resultTest)
        {
            if(resultTest == 1) 
                btnAppointment.Enabled = false;
        }
        
    }
}
