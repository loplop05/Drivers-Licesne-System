using DVLD_Business;
using System;
using System.Windows.Forms;

using System.Data;

namespace DVLD.Users
{
    public partial class frmAddNewUser : Form
    {
        private int _PersonID = -1;
        private bool _PersonFound = false;

        public frmAddNewUser()
        {
            InitializeComponent();
            SetupFilterComboBox();
            LockLoginInfo(true);
            cbIsActive.Checked = true;
            btnNextTab.Click += btnNextTab_Click;
        }

        private void SetupFilterComboBox()
        {
            cbFilterBy.Items.Add("PersonID");
            cbFilterBy.Items.Add("NationalNo");
            cbFilterBy.Items.Add("Name");
            cbFilterBy.SelectedIndex = 0;
        }

        private void LockLoginInfo(bool lockIt)
        {
            txtUserName.Enabled = !lockIt;
            txtPassword.Enabled = !lockIt;
            txtConfirmPassword.Enabled = !lockIt;
            cbIsActive.Enabled = !lockIt;
        }

        private void btnNextTab_Click(object sender, EventArgs e)
        {
            if (!_PersonFound || _PersonID <= 0)
            {
                MessageBox.Show(
                    "Please find or add a person before continuing.",
                    "Person Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Re-read the person so the user is always linked to a valid database row.
            if (clsPeople.Find(_PersonID) == null)
            {
                _PersonID = -1;
                _PersonFound = false;
                LockLoginInfo(true);
                MessageBox.Show("The selected person no longer exists.");
                return;
            }

            tcAddNewUser.SelectedTab = tpLoginInfo;
            txtUserName.Focus();
        }

     

        private void btnFindPerson_Click_1(object sender, EventArgs e)
        {
            

            if (string.IsNullOrWhiteSpace(txtFilterValue.Text))
            {
                MessageBox.Show("Please enter a filter value.");
                return;
            }

            clsPeople person = null;
            string filterBy = cbFilterBy.SelectedItem.ToString();

            switch (filterBy)
            {
                case "PersonID":
                    if (int.TryParse(txtFilterValue.Text, out int personID))
                    {
                        person = clsPeople.Find(personID);
                    }
                    break;

                case "NationalNo":
                    DataTable people = clsPeople.GetPeopleByFilter(
                        "National No",
                        txtFilterValue.Text.Trim()
                    );

                    if (people.Rows.Count > 0)
                    {
                        person = clsPeople.Find(
                            Convert.ToInt32(people.Rows[0]["PersonID"])
                        );
                    }
                    break;

                case "Name":
                    // For name, we'll need to search by name - this might need a new method
                    // For now, we'll show a message that this isn't implemented yet
                    MessageBox.Show("Search by name is not implemented yet. Please use PersonID or NationalNo.");
                    return;
            }

            if (person == null)
            {
                MessageBox.Show("Person not found in the system.");
                _PersonID = -1;
                _PersonFound = false;
                LockLoginInfo(true);
                return;
            }

            _PersonID = person.PersonID;
            _PersonFound = true;
            ctrlPersonDetails1.LoadPerson(_PersonID);
            LockLoginInfo(false);
        }
    

        private bool ValidateUserInfo()
        {
            if (!_PersonFound)
            {
                MessageBox.Show("Please find or add a person first.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                MessageBox.Show("Username is required.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password is required.");
                return false;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return false;
            }

            if (clsUsers.IsUserExist(txtUserName.Text))
            {
                MessageBox.Show("Username already exists.");
                return false;
            }

            return true;
        }

        private bool SaveUser()
        {
            if (!ValidateUserInfo())
            {
                return false;
            }

            try
            {
                int UserID = clsUsers.AddNewUser(
                    _PersonID,
                    txtUserName.Text.Trim(),
                    txtPassword.Text,
                    cbIsActive.Checked
                );

                if (UserID != -1)
                {
                    lblUserID.Text = UserID.ToString();
                    MessageBox.Show("User added successfully with ID: " + UserID);
                    return true;
                }

                MessageBox.Show("Failed to add user.");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Database error while adding user:\n" + ex.Message,
                    "Add User Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            People.frmAddPeople frm = new People.frmAddPeople();
            frm.ShowDialog();

            // After adding new person, try to load it if it was added
            if (frm.PersonID != -1)
            {
                _PersonID = frm.PersonID;
                _PersonFound = true;
                ctrlPersonDetails1.LoadPerson(_PersonID);
                LockLoginInfo(false);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveUser();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
