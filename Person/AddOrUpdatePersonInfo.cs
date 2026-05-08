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
    public partial class AddOrUpdatePersonInfo : Form
    {
        public event Action<string> BackPersonID;
        public string PID;
        public AddOrUpdatePersonInfo()
        {
            InitializeComponent();
            label1.Text = "Add Person";
            update_person_usercontrol1.closeFormFromUsreControl += Closew;
            PID = update_person_usercontrol1.PersonId;
           
        }
        public AddOrUpdatePersonInfo(int personid)
        {
            InitializeComponent();
            update_person_usercontrol1.closeFormFromUsreControl += Closew;
            update_person_usercontrol1.PersonId = personid.ToString();
        }
        private void Closew()
        {
            PID = update_person_usercontrol1.PersonId;
            BackPersonID?.Invoke(PID);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
