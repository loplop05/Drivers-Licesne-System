using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmNewLocalDrivingLicsenseApplication : Form
    {
        private const int _LocalDrivingLicenseApplicationTypeID = 1;
        private const byte _NewApplicationStatus = 1;

        private int _PersonID = -1;
        private bool _PersonFound = false;
        private int _ApplicationID = -1;
        private int _LocalDrivingLicenseApplicationID = -1;
        private decimal _ApplicationFees = 0;
        private clsUsers _CurrentUser = null;
        private bool _EditMode = false;





        public frmNewLocalDrivingLicsenseApplication(clsUsers currentUser)
        {
            InitializeComponent();
            _CurrentUser = currentUser;
            SetupFilterComboBox();
            _LoadApplicationInfo();
            btnSave.Click += btnSave_Click;
            btnClose.Click += btnClose_Click;

        }

        public frmNewLocalDrivingLicsenseApplication(int localDrivingLicenseApplicationID, clsUsers currentUser)
            : this(currentUser)
        {
            _EditMode = true;
            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            clsLocalDrivingLicenseApplications application = clsLocalDrivingLicenseApplications.Find(localDrivingLicenseApplicationID);
            DataTable info = clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationInfoByID(localDrivingLicenseApplicationID);
            if (application == null || info.Rows.Count == 0) { MessageBox.Show("Application not found."); Close(); return; }
            _ApplicationID = application.ApplicationID;
            _PersonID = Convert.ToInt32(info.Rows[0]["ApplicantPersonID"]);
            _PersonFound = true;
            ctrlPersonDetails1.LoadPerson(_PersonID);
            cbLicsenseClass.SelectedValue = application.LicenseClassID;
            lblDLapplictionID.Text = localDrivingLicenseApplicationID.ToString();
            lblApplictionDate.Text = Convert.ToDateTime(info.Rows[0]["ApplicationDate"]).ToShortDateString();
            lblCreatedByUser.Text = info.Rows[0]["CreatedBy"].ToString();
            btnSave.Text = "Update";
            Text = "Edit Local Driving License Application";
        }

        private void SetupFilterComboBox()
        {
            cbFilterBy.Items.Add("PersonID");
            cbFilterBy.Items.Add("NationalNo");
            cbFilterBy.Items.Add("Name");
            cbFilterBy.SelectedIndex = 0;
        }

        private void _LoadApplicationInfo()
        {
            lblDLapplictionID.Text = "Not Saved Yet";
            lblApplictionDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedByUser.Text = _CurrentUser != null ? _CurrentUser.Username : "Unknown";

            clsApplicationTypes applicationType = clsApplicationTypes.Find(_LocalDrivingLicenseApplicationTypeID);
            if (applicationType != null)
            {
                _ApplicationFees = applicationType.ApplicationFees;
                lblApplictionFees.Text = _ApplicationFees.ToString();
            }
            else
            {
                lblApplictionFees.Text = "0";
            }

            DataTable dtLicenseClasses = clsLicenseClasses.ListAllLicenseClasses();
            cbLicsenseClass.DataSource = dtLicenseClasses;
            cbLicsenseClass.DisplayMember = "ClassName";
            cbLicsenseClass.ValueMember = "LicenseClassID";

            if (cbLicsenseClass.Items.Count > 0)
            {
                cbLicsenseClass.SelectedIndex = 0;
            }
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
               
                MessageBox.Show("The selected person no longer exists.");
                return;
            }

            tcAddNewUser.SelectedTab = tpApplicationInfo;
        }

        private bool _ValidateApplicationInfo()
        {
            if (!_PersonFound || _PersonID <= 0)
            {
                MessageBox.Show(
                    "Please find or add a person before saving.",
                    "Person Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                tcAddNewUser.SelectedTab = tabPersonalInfo;
                return false;
            }

            if (cbLicsenseClass.SelectedValue == null)
            {
                MessageBox.Show(
                    "Please select a license class.",
                    "License Class Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            if (_CurrentUser == null || _CurrentUser.UserID <= 0)
            {
                MessageBox.Show(
                    "Cannot save the application because the current user was not found.",
                    "User Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            // Check if person already has an active application for this license class
            int licenseClassID = Convert.ToInt32(cbLicsenseClass.SelectedValue);
            if (clsLocalDrivingLicenseApplications.DoesPersonHaveIssuedLicenseForClass(_PersonID, licenseClassID))
            {
                MessageBox.Show(
                    "This person already has an issued license for this license class.",
                    "License Already Exists",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (clsLocalDrivingLicenseApplications.DoesPersonHaveActiveApplicationForLicenseClass(_PersonID, licenseClassID))
            {
                MessageBox.Show(
                    "This person already has an active application for this license class. " +
                    "You cannot apply for the same license class twice unless the previous application is cancelled.",
                    "Duplicate Application",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_EditMode)
            {
                if (cbLicsenseClass.SelectedValue == null) return;
                if (clsLocalDrivingLicenseApplications.DoesPersonHaveIssuedLicenseForClass(_PersonID, Convert.ToInt32(cbLicsenseClass.SelectedValue)))
                {
                    MessageBox.Show("This person already has an issued license for this license class.", "License Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                clsLocalDrivingLicenseApplications application = clsLocalDrivingLicenseApplications.Find(_LocalDrivingLicenseApplicationID);
                application.LicenseClassID = Convert.ToInt32(cbLicsenseClass.SelectedValue);
                if (!application.Save()) { MessageBox.Show("Application was not updated.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                MessageBox.Show("Application updated successfully.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK; Close(); return;
            }
            if (_LocalDrivingLicenseApplicationID != -1)
            {
                MessageBox.Show("This application is already saved.");
                return;
            }

            if (!_ValidateApplicationInfo())
            {
                return;
            }

            DateTime applicationDate = DateTime.Now;

            _ApplicationID = clsApplications.AddNewApplication(
                _PersonID,
                applicationDate,
                _LocalDrivingLicenseApplicationTypeID,
                _NewApplicationStatus,
                applicationDate,
                _ApplicationFees,
                _CurrentUser.UserID);

            if (_ApplicationID == -1)
            {
                MessageBox.Show(
                    "Application was not saved.",
                    "Save Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            _LocalDrivingLicenseApplicationID =
                clsLocalDrivingLicenseApplications.AddNewLocalDrivingLicenseApplication(
                    _ApplicationID,
                    Convert.ToInt32(cbLicsenseClass.SelectedValue));

            if (_LocalDrivingLicenseApplicationID == -1)
            {
                MessageBox.Show(
                    "Local driving license application was not saved.",
                    "Save Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            lblDLapplictionID.Text = _LocalDrivingLicenseApplicationID.ToString();
            lblApplictionDate.Text = applicationDate.ToShortDateString();

            MessageBox.Show(
                "Application saved successfully.",
                "Saved",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFindPerson_Click(object sender, EventArgs e)
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
                //LockLoginInfo(true);
                return;
            }

            _PersonID = person.PersonID;
            _PersonFound = true;
            ctrlPersonDetails1.LoadPerson(_PersonID);
        }



























































































    }
}
