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
using System.Text.RegularExpressions;
using System.IO;
using System.Resources;


namespace presntion_DVLD
{

    public partial class update_person_usercontrol : UserControl
    {
        enum Mode { Add ,Update}
        clspeople person;
        private string selectedImagesFolder = @"C:\Users\hp\Pictures\pic_DVLD\selectedImages";
        private string lastcopiedImageName="";
        public  string PersonId="";

        private bool   changePhoto;
        public  event Action closeFormFromUsreControl;
        Mode mod;
        public update_person_usercontrol()
        {
            InitializeComponent();

            if(!Directory.Exists(selectedImagesFolder))
            {
                Directory.CreateDirectory(selectedImagesFolder);
            }
            
        }

        private void txtFN_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFN_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFN.Text))
            {
                errorProvider1.SetError(txtFN, "plase enter the Name");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtFN, "");

            
        }

        private void txtFN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                
                errorProvider1.SetError(txtFN, "plase enter letter ");
                
            }
            else
                errorProvider1.SetError(txtFN, "");


        }

        private void txtSN_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSN.Text))
            {
                errorProvider1.SetError(txtSN, "plase enter the Name");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtSN, "");

        }

        private void txtSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {

                errorProvider1.SetError(txtSN, "plase enter letter ");

            }
            else
                errorProvider1.SetError(txtSN, "");


        }

        private void txtTN_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTN.Text))
            {
                errorProvider1.SetError(txtTN, "plase enter the Name");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtTN, "");

        }

        private void txtTN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {

                errorProvider1.SetError(txtTN, "plase enter letter ");

            }
            else
                errorProvider1.SetError(txtTN, "");

        }

        private void txtLN_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLN.Text))
            {
                errorProvider1.SetError(txtLN, "plase enter the Name");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtLN, "");

        }

        private void txtLN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {

                errorProvider1.SetError(txtLN, "plase enter letter ");

            }
            else
                errorProvider1.SetError(txtLN, "");

        }

        private void txtNNO_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtTN.Text))
            {
                errorProvider1.SetError(txtTN, "plase enter the Name");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtTN, "");
            

        }

        private void update_person_usercontrol_Load(object sender, EventArgs e)
        {

            dateTimePicker1.MaxDate= DateTime.Today.AddYears(-18);
            comboBox1.DataSource   = clspeople.GetAllCountries();
            comboBox1.DisplayMember = "CountryName";
            comboBox1.SelectedIndex =comboBox1.FindString("syria");
            pictureBox1.Image =Properties.Resources.man;
            changePhoto = false;
            radioButton1.Checked = true;
            lastcopiedImageName = "";

            if (PersonId != "")
            {
                mod = Mode.Update;
                _LoadDataForUpdate();
                ModeUpdatePerson();
                person=clspeople.GetPersonByID(Convert.ToInt32(PersonId));  
            }
            else
            {
                mod = Mode.Add;
                person=new clspeople();
            }

            linkLabel2.Visible = (pictureBox1.ImageLocation!= null);
        }
        private void _LoadDataForUpdate()
        {
            
                DataView dv = clspeople.FindPersonIDForAllColumn(Convert.ToInt32(PersonId));

                txtFN.Text = dv[0][2].ToString();
                txtSN.Text = dv[0][3].ToString();
                txtTN.Text = dv[0][4].ToString();
                txtLN.Text = dv[0][5].ToString();
                txtp.Text = dv[0][9].ToString();
                txtNNO.Text = dv[0][1].ToString();
                dateTimePicker1.Value = (Convert.ToDateTime(dv[0][6])).Date;
                comboBox1.SelectedItem = clspeople.GetCountryName(Convert.ToInt32(dv[0][11]));
                if (dv[0][7].ToString() == "0")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
                if (dv[0][12].ToString() == DBNull.Value.ToString())
                {
                    TheImageReqiuredBefourRemoveImage();
                }
                else
                {
                    changePhoto = true;
                    pictureBox1.Image = Image.FromFile(dv[0][12].ToString());
                    
                }



                if (dv[0][10].ToString() == DBNull.Value.ToString())
                {
                    txtE.Text = "";
                }
                else
                {
                    txtE.Text = dv[0][10].ToString();

                }
                txtAddress.Text = dv[0][8].ToString();

            linkLabel2.Visible = (pictureBox1.ImageLocation != null);

        }
        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTN.Text))
            {
                errorProvider1.SetError(txtTN, "plase enter the Name");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtTN, "");
        }

        private void txtE_TextChanged(object sender, EventArgs e)
        {
           
  
                string email = txtE.Text.Trim();

                // الباترن يسمح لأي اسم قبل @gmail.com
                string pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";

                // إذا الحقل فارغ → مسموح
                if (email == "")
                {
                    errorProvider1.SetError(txtE, "");
                    return;
                }

                // إذا الحقل غير فارغ → يتحقق من السينتاكس
                if (!Regex.IsMatch(email, pattern))
                {
                    errorProvider1.SetError(txtE, "الإيميل يجب أن يكون بصيغة صحيحة وينتهي بـ @gmail.com");
                }
                else
                {
                    errorProvider1.SetError(txtE, ""); // يمسح الخطأ
                }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd= new OpenFileDialog();
            ofd.Filter = "Image Files| *.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if(ofd.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.ImageLocation = ofd.FileName;

                string extension=Path.GetExtension(ofd.FileName);
                string uniqueName=Path.Combine(selectedImagesFolder,Guid.NewGuid().ToString()+extension);

                string destfile=Path.Combine(selectedImagesFolder,uniqueName);
                
                File.Copy(ofd.FileName, destfile,true);
                 lastcopiedImageName = uniqueName;
                changePhoto = true;
                linkLabel2.Visible = (pictureBox1.ImageLocation !=null);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RemoveImage();
        }
        private void RemoveImage()
        {
            if (lastcopiedImageName != null)
            {
                string FileToDelete = Path.Combine(selectedImagesFolder, lastcopiedImageName);

                if (File.Exists(FileToDelete))
                {
                    File.Delete(FileToDelete);
                }

                pictureBox1.Image = null;
                pictureBox1.ImageLocation = null;
                linkLabel2.Visible = (pictureBox1.ImageLocation != null);
                lastcopiedImageName = "";
                changePhoto = false;
                TheImageReqiuredBefourRemoveImage();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (changePhoto == false)
                pictureBox1.Image = Properties.Resources.woman;
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
                if(changePhoto==false)
                pictureBox1.Image = Properties.Resources.woman;
            
        }
        private void TheImageReqiuredBefourRemoveImage()
        {
            if (radioButton1.Checked)
            {
                pictureBox1.Image = Properties.Resources.man;

            }
            else
            {
                pictureBox1.Image = Properties.Resources.woman;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RemoveImage();
            closeFormFromUsreControl?.Invoke();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (clspeople.NNOIsExists(txtNNO.Text)==0 | (clspeople.NNOIsExists(txtNNO.Text) == 1 && mod==Mode.Update))
            {

                if (txtFN.Text != "" && txtLN.Text != "" && txtTN.Text != "" && txtSN.Text != "" && txtAddress.Text != "" && txtp.Text != "" && txtNNO.Text != "")
                {

                    person.FirstName = txtFN.Text;
                    person.SecondName = txtSN.Text;
                    person.ThirdName = txtTN.Text;
                    person.LastName = txtLN.Text;
                    person.NationalNo =txtNNO.Text;
                    person.Email = txtE.Text;
                    person.Phone = txtp.Text;
                    person.Address = txtAddress.Text;
                    person.DateOfBirth = dateTimePicker1.Value;
                    if (radioButton1.Checked)
                    {
                        person.Gendor = 0;
                    }
                    else
                    {
                        person.Gendor = 1;
                    }
                    person.ImagePath = lastcopiedImageName;


                    person.NationalityCountryID = clspeople.GetIDCountry(comboBox1.Text);



                    if (person.Save())
                    {
                        MessageBox.Show("successfully");
                        labresultPID.Text=person.PersonID.ToString();
                        PersonId= person.PersonID.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Faild");
                    }
                }
                else
                {
                    MessageBox.Show("fill all fild");
                }
            }
            else
            {
                MessageBox.Show("Enter Another NationalNO!","error",MessageBoxButtons.OKCancel);
                txtNNO.Focus();
            }
            
                
            


        }
        private void ModeUpdatePerson()
        {
            labresultPID.Text = PersonId;
        }

    }
}
