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
    public partial class ManagerUsers : Form
    {
        public ManagerUsers()
        {
            InitializeComponent();
        }

       
        private void Refrash()
        {
            dataGridView1.DataSource = clsUser.GetAllUsers();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            labresultCountRecord.Text= (dataGridView1.Rows.Count).ToString();

        }

        private void ReplaceBetweenTextBoxAndComboBoxInVisible()
        {
            if (comboBox1.SelectedItem.ToString() == "IsActive")
            {
                comboBox2.Visible = true;
                textBox1.Visible = false;
            }
            else if (comboBox1.SelectedItem.ToString() == "none")
            {
                comboBox2.Visible = false;
                textBox1.Visible = false;
            }
            else
            {
                textBox1.Visible = true;
                comboBox2.Visible=false; 

            }

        }
        private void ManagerUsers_Load(object sender, EventArgs e)
        {
            Refrash();
            comboBox2.Visible= false;
            textBox1.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem)
            {
                case "UserID":
                    if (textBox1.Text != "")
                    {
                        dataGridView1.DataSource = clsUser.FindUserID(Convert.ToInt32(textBox1.Text));
                    }
                    else
                    {
                        Refrash();
                    }
                    break;
                case "PersonID":
                    if (textBox1.Text != "")
                    {
                        dataGridView1.DataSource = clsUser.FindPersonID(Convert.ToInt32(textBox1.Text));
                    }
                    else
                    {
                        Refrash();
                    }
                    break;
                case "UserName":
                    if (textBox1.Text != "")
                    {
                        dataGridView1.DataSource = clsUser.FindUserName(textBox1.Text);
                    }
                    else
                    {
                        Refrash();
                    }
                    break;
                case "FullName":
                    if (textBox1.Text != "")
                    {
                        dataGridView1.DataSource = clsUser.FindFirstName(textBox1.Text);
                    }
                    else
                    {
                        Refrash();
                    }
                    break;
                case "IsActive":
                    
                        
                    break;

                default:

                    Refrash();
                    break;

            }
            Refresh();
        }
        private void SelectedItemFroActive()
        {
            switch (comboBox2.SelectedItem)
            {
                case "Active":
                    dataGridView1.DataSource = clsUser.FindActive();
                    break;
                case "not Active":
                    dataGridView1.DataSource = clsUser.FindNotActive();
                    break;
                case "All":
                    dataGridView1.DataSource = clsUser.GetAllUsers();
                    break;
                default:
                    Refrash();
                    break;
            }
            Refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReplaceBetweenTextBoxAndComboBoxInVisible();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedItemFroActive();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddNew_UpdateUser f=new AddNew_UpdateUser();
            f.ShowDialog();
            Refrash();
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
                    person_DetailsAndUserInfo f = new person_DetailsAndUserInfo(Convert.ToInt32(i));
                    f.ShowDialog();
                    Refrash();
                }
                else
                {
                    MessageBox.Show("noooooooooooooo row");
                }
            }
            else
            {
                MessageBox.Show("error");
            }
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNew_UpdateUser f= new AddNew_UpdateUser();
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
                    AddNew_UpdateUser f = new AddNew_UpdateUser(Convert.ToInt32(i));
                    f.ShowDialog();
                    Refrash();
                }
                else
                {
                    MessageBox.Show("No specific user");
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

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                object cellValue = selectedRow.Cells["UserID"].Value;
                object cellValueUserName= selectedRow.Cells["UserName"].Value;
                if (cellValue != null && cellValue != DBNull.Value)
                {   
                    string username=cellValueUserName.ToString();

                    string i = cellValue.ToString();

                    if (MessageBox.Show($"Do you want Delete this user : {username}", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        if(clsUser.DeleteUser(Convert.ToInt32(i)))
                        {
                          MessageBox.Show("Deleted sccussfully","Message",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
                        }
                        else
                        {
                          MessageBox.Show("Failed ", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        }
                    }
                    Refrash();
                }
                else
                {
                    MessageBox.Show("No specific user");
                }
            }
            else
            {
                MessageBox.Show("error");
            }
        }

        private void refrshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
