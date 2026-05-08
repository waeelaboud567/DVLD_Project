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
    public partial class ManagerPeople : Form
    {
        public ManagerPeople()
        {
            InitializeComponent();
        }

        private void ManagerPeople_Load(object sender, EventArgs e)
        {
            Refrach();
            textBox1.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {   if(comboBox1.SelectedItem.ToString()!="none")
            textBox1.Visible = true;
        }

        private void Refrach()
        {
            dataGridView1.DataSource = clspeople.GetAllPeople();
            labresultCountRecord.Text=(dataGridView1.Rows.Count).ToString();

         
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    if (textBox1.Text != "")
                    {
                        dataGridView1.DataSource = clspeople.FindPersonID(Convert.ToInt32(textBox1.Text));
                    }
                    else
                    {
                        Refrach();
                    }
                    break;
                case 1:
                    if (textBox1.Text != "")
                    {
                        dataGridView1.DataSource = clspeople.FindNationalNo(textBox1.Text);
                    }
                    else
                    {
                        Refrach();

                    }
                    break;
                case 2:
                    if (textBox1.Text != "")
                    {
                        dataGridView1.DataSource = clspeople.FindFirstName(textBox1.Text);
                    }
                    else
                    {
                        Refrach();

                    }
                    break;
                case 3:
                    if (textBox1.Text != "")
                    {
                        dataGridView1.DataSource = clspeople.FindSecondName(textBox1.Text);
                    }
                    else
                    {
                        Refrach();

                    }
                    break;
                case 4:
                    if (textBox1.Text != "")
                    {
                        dataGridView1.DataSource = clspeople.FindThirdName(textBox1.Text);
                    }
                    else
                    {
                        Refrach();

                    }
                    break;
                case 5:
                    if (textBox1.Text != "")
                    {
                        dataGridView1.DataSource = clspeople.FindLastName(textBox1.Text);
                    }
                    else
                    {
                        Refrach();

                    }
                    break;
                case 6:
                    if (textBox1.Text != "")
                    {
                        dataGridView1.DataSource = clspeople.FindGendor(Convert.ToInt32(textBox1.Text));
                    }
                    else
                    {
                        Refrach();

                    }
                    break;
                case 7:
                    if (textBox1.Text != "")
                    {
                        dataGridView1.DataSource = clspeople.FindNationality(textBox1.Text);
                    }
                    else
                    {
                        Refrach();

                    }
                    break;
                case 8:
                    if (textBox1.Text != "")
                    {
                        dataGridView1.DataSource = clspeople.FindPhone(textBox1.Text);
                    }
                    else
                    {
                        Refrach();

                    }
                    break;
                case 9:
                    if (textBox1.Text != "")
                    {
                        dataGridView1.DataSource = clspeople.FindEmail(textBox1.Text);
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

        private void button1_Click(object sender, EventArgs e)
        {
            AddOrUpdatePersonInfo f = new AddOrUpdatePersonInfo();
            f.ShowDialog();
            Refrach();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                object cellValue = selectedRow.Cells["PersonID"].Value;

                if (cellValue != null && cellValue != DBNull.Value)
                {
                    string i = cellValue.ToString();
                    Person_Details f = new Person_Details(i);
                    f.ShowDialog();
                    Refrach();
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
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dataGridView1.ClearSelection();

                dataGridView1.Rows[e.RowIndex].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
                    AddOrUpdatePersonInfo f = new AddOrUpdatePersonInfo();
                    f.ShowDialog();
               
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                object cellValue = selectedRow.Cells["PersonID"].Value;

                if (cellValue != null && cellValue != DBNull.Value)
                {
                    string i = cellValue.ToString();
                    AddOrUpdatePersonInfo f = new AddOrUpdatePersonInfo(Convert.ToInt32(i));
                    f.ShowDialog();
                    Refrach();
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

        private void refrechToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Refrach();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                object cellValue = selectedRow.Cells["PersonID"].Value;

                if (cellValue != null && cellValue != DBNull.Value)
                {
                    string i = cellValue.ToString();
                    if (MessageBox.Show($"Do you want to delete the person with the PersonID {i}",
                    "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        string Message = "";
                        if (DeletePerson(Convert.ToInt32(i), ref Message))
                        {
                            MessageBox.Show("Successfully Deleted",
                           "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(Message);
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

        }
        private bool DeletePerson(int id, ref string Message)
        {
            return clspeople.DeletePerson(id,ref Message);
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
