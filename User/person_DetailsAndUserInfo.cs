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
    public partial class person_DetailsAndUserInfo : Form
    {
        private int _PID;
        public person_DetailsAndUserInfo()
        {
            InitializeComponent();
        }
        public person_DetailsAndUserInfo(int personid)
        {
            InitializeComponent();
            _PID = personid;
            personDetailsAndUserInfo_UserControl1.GivePID(_PID);
        }

        private void person_DetailsAndUserInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
