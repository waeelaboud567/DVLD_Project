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
    public partial class ManageDrivers_screen : Form
    {
        public ManageDrivers_screen()
        {
            InitializeComponent();
        }

        private void ManageDrivers_screen_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _LoadData()
        {
            dataGridView1.DataSource = clsDriver.GetAllDrivers();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            labresultCountRecord.Text=(dataGridView1.Rows.Count).ToString();
            textBox1.Visible=false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            switch (comboBox1.SelectedItem)
            {
                case "DriverID":
                    if (textBox1.Text != "")
                    {
                        dataGridView1.DataSource = clsDriver.FindDriverID(Convert.ToInt32(textBox1.Text));
                    }
                    else
                    {
                        _LoadData();
                    }
                    break;
                case "PersonID":
                    if (textBox1.Text != "")
                    {
                       dataGridView1.DataSource = clsDriver.FindPersonID(Convert.ToInt32(textBox1.Text));
                    }
                    else
                    {
                        _LoadData();
                    }
                    break;

                default:

                    _LoadData();
                    break;

            }
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "None")
            {
                textBox1.Visible=false;
            }
            else
            {
                textBox1.Visible = true;
            }
        }
    }
}
