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
    public partial class ManageApplicationTypes_Screen : Form
    {
        public ManageApplicationTypes_Screen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageApplicationTypes_Screen_Load(object sender, EventArgs e)
        {
            Refresh();
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void Refresh()
        {
            DataGridView1.DataSource = clsApplicationTypes.GetApplicationTypes();
            labNumberRecored.Text = DataGridView1.RowCount.ToString();
        }

        private void updateApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = DataGridView1.SelectedRows[0];

                object cellValue = selectedRow.Cells["ApplicationTypeID"].Value;

                if (cellValue != null && cellValue != DBNull.Value)
                {
                    string i = cellValue.ToString();
                    UpdateApplicationType_Screen f = new UpdateApplicationType_Screen(Convert.ToInt32(i));
                    f.ShowDialog();
                    Refresh();
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
        }

        private void DataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView1.ClearSelection();

                DataGridView1.Rows[e.RowIndex].Selected = true;
                DataGridView1.CurrentCell = DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }
    }
}
