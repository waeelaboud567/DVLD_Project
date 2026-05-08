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
    public partial class Person_Details : Form
    {
        public Person_Details(string id)
        {
            InitializeComponent();

            person_details_usercontrol1.SetID(id);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void person_details_usercontrol1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
