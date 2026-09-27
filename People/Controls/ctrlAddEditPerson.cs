using DVLD_Business;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DVLD.People.Controls
{
    public partial class ctrlAddEditPerson : UserControl
    {
        private clsPeople _Person;
        private string selectedSourceFilePath = "";

        private ErrorProvider _ErrorProvider;


        // =========================================================
        // EVENT
        // =========================================================

        public event EventHandler PersonSaved;


        // =========================================================
        // PERSON ID
        // =========================================================

        public int PersonID
        {
            get
            {
                return _Person.PersonID;
            }
        }


        // =========================================================
        // CONSTRUCTOR
        // =========================================================

        public ctrlAddEditPerson()
        {
            InitializeComponent();

            _ErrorProvider = new ErrorProvider();

            _ErrorProvider.BlinkStyle =
                ErrorBlinkStyle.NeverBlink;

            _Person = new clsPeople();

            _LoadCountries();

            _SetupValidationEvents();
        }


        // =========================================================
        // LOAD COUNTRIES
        // =========================================================

        private void _LoadCountries()
        {
            DataTable dtCountries =
                clsCountries.ListAllCountries();

            cbCountries.DataSource = dtCountries;

            cbCountries.DisplayMember =
                "CountryName";

            cbCountries.ValueMember =
                "CountryID";
        }


        // =========================================================
        // LOAD EXISTING PERSON
        // =========================================================
        //
        // The FORM can find the person and pass it here.
        //
        // Example:
        //
        // ctrlAddEditPerson1.LoadPerson(clsPeople.Find(ID));
        //
        // =========================================================

        public void LoadPerson(clsPeople Person)
        {
            if (Person == null)
                return;

            _Person = Person;

            // When loading an existing person, set mode to Update
            _Person.Mode = clsPeople.enMode.Update;

            txtNationalNo.Text =
                _Person.NationalNo;

            txtFirstName.Text =
                _Person.FirstName;

            txtSecondName.Text =
                _Person.SecondName;

            txtThirdName.Text =
                _Person.ThirdName;

            txtLastName.Text =
                _Person.LastName;

            txtAddress.Text =
                _Person.Address;

            txtPhone.Text =
                _Person.Phone;

            txtEmail.Text =
                _Person.Email;

            dtpDateOfBirth.Value =
                _Person.DateOfBirth;


            // =====================================================
            // COUNTRY
            // =====================================================

            if (_Person.NationalityCountryID > 0)
            {
                cbCountries.SelectedValue =
                    _Person.NationalityCountryID;
            }


            // =====================================================
            // GENDER
            // =====================================================

            if (_Person.Gendor == "1")
            {
                rbMale.Checked = true;
            }
            else if (_Person.Gendor == "0")
            {
                rbFemale.Checked = true;
            }


            // =====================================================
            // IMAGE
            // =====================================================

            _LoadPersonImage();


            ClearErrors();
        }


        // =========================================================
        // LOAD PERSON IMAGE
        // =========================================================

        private void _LoadPersonImage()
        {
            if (string.IsNullOrWhiteSpace(
                _Person.ImagePath))
            {
                pbPersonImage.Image = null;

                return;
            }


            string fullPath =
                Path.Combine(
                    Application.StartupPath,
                    _Person.ImagePath
                );


            if (!File.Exists(fullPath))
            {
                pbPersonImage.Image = null;

                return;
            }


            try
            {
                using (Image tempImage =
                    Image.FromFile(fullPath))
                {
                    pbPersonImage.Image =
                        new Bitmap(tempImage);
                }
            }
            catch
            {
                pbPersonImage.Image = null;
            }
        }


        // =========================================================
        // IMAGE FOLDER
        // =========================================================

        private string GetImagesFolder()
        {
            string imagesFolder =
                Path.Combine(
                    Application.StartupPath,
                    "Images"
                );


            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(
                    imagesFolder
                );
            }


            return imagesFolder;
        }


        // =========================================================
        // SAVE PERSON IMAGE
        // =========================================================

        private string SavePersonImage()
        {
            if (string.IsNullOrEmpty(
                selectedSourceFilePath))
            {
                return "";
            }


            string imagesFolder =
                GetImagesFolder();


            string extension =
                Path.GetExtension(
                    selectedSourceFilePath
                );


            string fileName =
                Guid.NewGuid().ToString()
                + extension;


            string destinationPath =
                Path.Combine(
                    imagesFolder,
                    fileName
                );


            File.Copy(
                selectedSourceFilePath,
                destinationPath
            );


            return Path.Combine(
                "Images",
                fileName
            );
        }


        // =========================================================
        // SET IMAGE
        // =========================================================

        private void llSetimage_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            using (OpenFileDialog openFileDialog =
                new OpenFileDialog())
            {
                openFileDialog.Filter =
                    "Image Files|*.jpg;*.jpeg;*.png;*.gif";

                openFileDialog.Title =
                    "Select Person Image";


                if (openFileDialog.ShowDialog()
                    == DialogResult.OK)
                {
                    selectedSourceFilePath =
                        openFileDialog.FileName;


                    using (Image tempImage =
                        Image.FromFile(
                            selectedSourceFilePath))
                    {
                        pbPersonImage.Image =
                            new Bitmap(tempImage);
                    }


                    // Remove any previous image error
                    _ErrorProvider.SetError(
                        pbPersonImage,
                        ""
                    );
                }
            }
        }


        // =========================================================
        // REMOVE IMAGE
        // =========================================================

      


        // =========================================================
        // VALIDATE PERSON
        // =========================================================

        public bool ValidatePerson()
        {
            ClearErrors();

            bool IsValid = true;


            // =====================================================
            // NATIONAL NO
            // =====================================================

            if (string.IsNullOrWhiteSpace(
                txtNationalNo.Text))
            {
                SetError(
                    txtNationalNo,
                    "National No is required."
                );

                IsValid = false;
            }


            // =====================================================
            // FIRST NAME
            // =====================================================

            if (string.IsNullOrWhiteSpace(
                txtFirstName.Text))
            {
                SetError(
                    txtFirstName,
                    "First Name is required."
                );

                IsValid = false;
            }
            else if (!IsValidName(
                txtFirstName.Text))
            {
                SetError(
                    txtFirstName,
                    "First Name contains invalid characters."
                );

                IsValid = false;
            }


            // =====================================================
            // SECOND NAME
            // =====================================================

            if (!string.IsNullOrWhiteSpace(
                txtSecondName.Text))
            {
                if (!IsValidName(
                    txtSecondName.Text))
                {
                    SetError(
                        txtSecondName,
                        "Second Name contains invalid characters."
                    );

                    IsValid = false;
                }
            }


            // =====================================================
            // THIRD NAME
            // =====================================================

            if (!string.IsNullOrWhiteSpace(
                txtThirdName.Text))
            {
                if (!IsValidName(
                    txtThirdName.Text))
                {
                    SetError(
                        txtThirdName,
                        "Third Name contains invalid characters."
                    );

                    IsValid = false;
                }
            }


            // =====================================================
            // LAST NAME
            // =====================================================

            if (string.IsNullOrWhiteSpace(
                txtLastName.Text))
            {
                SetError(
                    txtLastName,
                    "Last Name is required."
                );

                IsValid = false;
            }
            else if (!IsValidName(
                txtLastName.Text))
            {
                SetError(
                    txtLastName,
                    "Last Name contains invalid characters."
                );

                IsValid = false;
            }


            // =====================================================
            // DATE OF BIRTH
            // =====================================================

            if (dtpDateOfBirth.Value.Date >
                DateTime.Today)
            {
                SetError(
                    dtpDateOfBirth,
                    "Date of birth cannot be in the future."
                );

                IsValid = false;
            }


            // =====================================================
            // GENDER
            // =====================================================

            if (!rbMale.Checked &&
                !rbFemale.Checked)
            {
                SetError(
                    rbMale,
                    "Please select gender."
                );

                IsValid = false;
            }


            // =====================================================
            // PHONE
            // =====================================================

            if (string.IsNullOrWhiteSpace(
                txtPhone.Text))
            {
                SetError(
                    txtPhone,
                    "Phone number is required."
                );

                IsValid = false;
            }
            else if (!IsValidPhone(
                txtPhone.Text))
            {
                SetError(
                    txtPhone,
                    "Please enter a valid phone number."
                );

                IsValid = false;
            }


            // =====================================================
            // EMAIL
            // =====================================================

            if (!string.IsNullOrWhiteSpace(
                txtEmail.Text))
            {
                if (!IsValidEmail(
                    txtEmail.Text))
                {
                    SetError(
                        txtEmail,
                        "Please enter a valid email address."
                    );

                    IsValid = false;
                }
            }


            // =====================================================
            // ADDRESS
            // =====================================================

            if (string.IsNullOrWhiteSpace(
                txtAddress.Text))
            {
                SetError(
                    txtAddress,
                    "Address is required."
                );

                IsValid = false;
            }


            // =====================================================
            // COUNTRY
            // =====================================================

            if (cbCountries.SelectedIndex == -1 ||
                cbCountries.SelectedValue == null)
            {
                SetError(
                    cbCountries,
                    "Please select a country."
                );

                IsValid = false;
            }


            return IsValid;
        }


        // =========================================================
        // NAME VALIDATION
        // =========================================================

        private bool IsValidName(string Name)
        {
            Name = Name.Trim();


            if (Name.Length < 2)
                return false;


            foreach (char Character in Name)
            {
                if (!char.IsLetter(Character) &&
                    Character != ' ')
                {
                    return false;
                }
            }


            return true;
        }


        // =========================================================
        // PHONE VALIDATION
        // =========================================================

        private bool IsValidPhone(string Phone)
        {
            Phone = Phone.Trim();


            if (Phone.Length < 7 ||
                Phone.Length > 20)
            {
                return false;
            }


            foreach (char Character in Phone)
            {
                if (!char.IsDigit(Character) &&
                    Character != '+' &&
                    Character != '-' &&
                    Character != ' ' &&
                    Character != '(' &&
                    Character != ')')
                {
                    return false;
                }
            }


            return true;
        }


        // =========================================================
        // EMAIL VALIDATION
        // =========================================================

        private bool IsValidEmail(string Email)
        {
            Email = Email.Trim();


            return Regex.IsMatch(
                Email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase
            );
        }


        // =========================================================
        // SET ERROR
        // =========================================================

        private void SetError(
            Control control,
            string message)
        {
            _ErrorProvider.SetError(
                control,
                message
            );
        }


        // =========================================================
        // CLEAR ERRORS
        // =========================================================

        public void ClearErrors()
        {
            _ErrorProvider.Clear();
        }


        // =========================================================
        // CLEAR ALL FIELDS
        // =========================================================

        public void Clear()
        {
            _Person = new clsPeople();

            selectedSourceFilePath = "";


            txtNationalNo.Clear();

            txtFirstName.Clear();
            txtSecondName.Clear();
            txtThirdName.Clear();
            txtLastName.Clear();

            txtAddress.Clear();

            txtPhone.Clear();
            txtEmail.Clear();


            dtpDateOfBirth.Value =
                DateTime.Today;


            rbMale.Checked = false;
            rbFemale.Checked = false;


            cbCountries.SelectedIndex = -1;


            pbPersonImage.Image = null;


            ClearErrors();
        }


        // =========================================================
        // SETUP VALIDATION EVENTS
        // =========================================================

        private void _SetupValidationEvents()
        {
            txtNationalNo.TextChanged +=
                _ClearControlError;

            txtFirstName.TextChanged +=
                _ClearControlError;

            txtSecondName.TextChanged +=
                _ClearControlError;

            txtThirdName.TextChanged +=
                _ClearControlError;

            txtLastName.TextChanged +=
                _ClearControlError;

            txtAddress.TextChanged +=
                _ClearControlError;

            txtPhone.TextChanged +=
                _ClearControlError;

            txtEmail.TextChanged +=
                _ClearControlError;

            cbCountries.SelectedIndexChanged +=
                _ClearControlError;

            dtpDateOfBirth.ValueChanged +=
                _ClearControlError;

            rbMale.CheckedChanged +=
                _ClearControlError;

            rbFemale.CheckedChanged +=
                _ClearControlError;
        }


        // =========================================================
        // CLEAR ERROR WHEN USER FIXES FIELD
        // =========================================================

        private void _ClearControlError(
            object sender,
            EventArgs e)
        {
            Control control =
                sender as Control;


            if (control != null)
            {
                _ErrorProvider.SetError(
                    control,
                    ""
                );
            }
        }


        // =========================================================
        // SAVE
        // =========================================================

        private void btnSave_Click(
            object sender,
            EventArgs e)
        {
            // Stop here if validation fails
            if (!ValidatePerson())
                return;


            // =====================================================
            // GET VALUES
            // =====================================================

            _Person.NationalNo =
                txtNationalNo.Text.Trim();

            _Person.FirstName =
                txtFirstName.Text.Trim();

            _Person.SecondName =
                txtSecondName.Text.Trim();

            _Person.ThirdName =
                txtThirdName.Text.Trim();

            _Person.LastName =
                txtLastName.Text.Trim();

            _Person.Address =
                txtAddress.Text.Trim();

            _Person.Phone =
                txtPhone.Text.Trim();

            _Person.Email =
                txtEmail.Text.Trim();

            _Person.DateOfBirth =
                dtpDateOfBirth.Value;


            // =====================================================
            // COUNTRY
            // =====================================================

            if (cbCountries.SelectedValue != null)
            {
                _Person.NationalityCountryID =
                    Convert.ToInt32(
                        cbCountries.SelectedValue);
            }


            // =====================================================
            // GENDER
            // =====================================================

            if (rbMale.Checked)
            {
                _Person.Gendor = "1";
            }
            else if (rbFemale.Checked)
            {
                _Person.Gendor = "0";
            }


            // =====================================================
            // IMAGE
            // =====================================================

            if (!string.IsNullOrEmpty(
                selectedSourceFilePath))
            {
                _Person.ImagePath =
                    SavePersonImage();
            }


            // =====================================================
            // SAVE
            // =====================================================

            if (_Person.Save())
            {
                MessageBox.Show(
                    "Person saved successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );


                PersonSaved?.Invoke(
                    this,
                    EventArgs.Empty
                );
            }
            else
            {
                MessageBox.Show(
                    "Error: Person was not saved.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            parentForm.Close();
               
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.Image = null;
            pbPersonImage.BackgroundImage = null;

            selectedSourceFilePath = "";
            _Person.ImagePath = "";
        }
    }
}