using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People.Controls
{
    public partial class ctrlAddEditPerson : UserControl
    {



        private clsPeople _Person;
        private string selectedSourceFilePath = "";



        // عشان ترجع ال ID 
        public event EventHandler PersonSaved;

        public int PersonID
        {
            get { return _Person.PersonID; }
        }


        private void _LoadCountries()
        {
            DataTable dtCountries = clsCountries.ListAllCountries();

            cbCountries.DataSource = dtCountries;
            cbCountries.DisplayMember = "CountryName";
            cbCountries.ValueMember = "CountryID";
        }
        

        public ctrlAddEditPerson()
        {
            InitializeComponent();
            _Person = new clsPeople();
            _LoadCountries();
        }


















        private string GetImagesFolder()
        {
            string imagesFolder = Path.Combine(
                Application.StartupPath,
                "Images"
            );

            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }

            return imagesFolder;
        }

        private string SavePersonImage()
        {
            if (string.IsNullOrEmpty(selectedSourceFilePath))
                return "";

            string imagesFolder = GetImagesFolder();

            string extension = Path.GetExtension(selectedSourceFilePath);

            string fileName = Guid.NewGuid().ToString() + extension;

            string destinationPath = Path.Combine(
                imagesFolder,
                fileName
            );

            File.Copy(selectedSourceFilePath, destinationPath);

            return Path.Combine("Images", fileName);
        }




        private void llSetimage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter =
                    "Image Files|*.jpg;*.jpeg;*.png;*.gif";

                openFileDialog.Title = "Select Person Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedSourceFilePath = openFileDialog.FileName;

                    using (Image tempImage = Image.FromFile(selectedSourceFilePath))
                    {
                        pbPersonImage.Image = new Bitmap(tempImage);
                    }
                }
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.Image = null;
            selectedSourceFilePath = "";
            _Person.ImagePath = "";
        }













        private void btnSave_Click(object sender, EventArgs e)
        {
            _Person.NationalNo = txtNationalNo.Text;
            _Person.FirstName = txtFirstName.Text;
            _Person.SecondName = txtSecondName.Text;
            _Person.ThirdName = txtThirdName.Text;
            _Person.LastName = txtLastName.Text;

            _Person.Address = txtAddress.Text;
            _Person.Phone = txtPhone.Text;
            _Person.Email = txtEmail.Text;

            _Person.DateOfBirth = dtpDateOfBirth.Value;
          

            if (!string.IsNullOrEmpty(selectedSourceFilePath))
            {
                _Person.ImagePath = SavePersonImage();
            }

            // Country
            if (cbCountries.SelectedValue != null)
            {
                _Person.NationalityCountryID =
                    Convert.ToInt32(cbCountries.SelectedValue);
            }

            
            if (rbMale.Checked)
            {
                _Person.Gendor = "1";
            }
            else if (rbFemale.Checked)
            {
                _Person.Gendor = "0";
            }









            if (_Person.Save())
            {
                MessageBox.Show("Person saved successfully.");

                PersonSaved?.Invoke(this, EventArgs.Empty);

            }
            else
            {
                MessageBox.Show("Error: Person was not saved.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();

            if (parentForm != null)
            {
                parentForm.Close();
            }
           
        }





    }
    }

