using DVLD.Applications.Controls;
using DVLD.Applications.Local_Driving_License;
using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Applications.Renew_Driving_License
{
    public partial class frmReenewLocalDrivingLicense : Form
    {
        private readonly clsUsers _currentUser;
        private int _oldLicenseId = -1;
        private int _newLicenseId = -1;
        private DataRow _oldLicense;

        public frmReenewLocalDrivingLicense() : this(null)
        {
        }

        public frmReenewLocalDrivingLicense(clsUsers currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            btnRenew.Enabled = false;
            lnkLicenseHistory.Enabled = false;
            lnkNewLicenseInfo.Enabled = false;
        }

        private void btnFindLicense_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtLicenseId.Text.Trim(), out _oldLicenseId) || _oldLicenseId <= 0)
            {
                MessageBox.Show("Please enter a valid license ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLicenseId.Focus();
                return;
            }

            DataTable licenseInfo = clsLicenses.GetLicenseInfo(_oldLicenseId);

            if (licenseInfo.Rows.Count == 0)
            {
                MessageBox.Show("License was not found.", "Search result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _oldLicense = licenseInfo.Rows[0];
            ctrlLicenseInfo.LoadLicenseInfo(_oldLicenseId);
            lnkLicenseHistory.Enabled = true;
            btnRenew.Enabled = Convert.ToBoolean(_oldLicense["IsActive"]);

            DateTime expirationDate = Convert.ToDateTime(_oldLicense["ExpirationDate"]).Date;

            if (expirationDate >= DateTime.Today)
            {
                btnRenew.Enabled = false;
                MessageBox.Show(
                    $"This license has not expired yet.\nExpiration Date: {expirationDate:dd/MMM/yyyy}",
                    "Cannot renew",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (!btnRenew.Enabled)
            {
                MessageBox.Show("This license is not active and cannot be renewed.", "Cannot renew", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (_oldLicense == null || !btnRenew.Enabled)
            {
                return;
            }

            DataTable applicationTypes = clsApplicationTypes.ListAllApplicationsTypes();
            DataRow[] renewTypes = applicationTypes.Select("ApplicationTypeTitle LIKE '%Renew%'");

            if (renewTypes.Length == 0)
            {
                MessageBox.Show("The renewal application type was not found.", "Cannot renew", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRow applicationType = renewTypes[0];
            int applicationId = clsApplications.AddNewApplication(
                Convert.ToInt32(_oldLicense["PersonID"]), DateTime.Now,
                Convert.ToInt32(applicationType["ApplicationTypeID"]), 1,
                DateTime.Now, Convert.ToDecimal(applicationType["ApplicationFees"]), _currentUser.UserID);

            if (applicationId <= 0)
            {
                MessageBox.Show("The renewal application could not be created.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _newLicenseId = clsLicenses.RenewLicense(applicationId, _oldLicenseId, _currentUser.UserID, 20m);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The license could not be renewed.\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_newLicenseId <= 0)
            {
                MessageBox.Show("The old license is not active and could not be renewed.", "Cannot renew", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lblApplicationInfo.Text = BuildApplicationInfo(applicationId, _newLicenseId, applicationType);
            lnkNewLicenseInfo.Enabled = true;
            btnRenew.Enabled = false;
            MessageBox.Show($"License renewed successfully.\nNew License ID: {_newLicenseId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string BuildApplicationInfo(int applicationId, int newLicenseId, DataRow applicationType)
        {
            decimal applicationFees = Convert.ToDecimal(applicationType["ApplicationFees"]);
            return $"R.L.Application ID:     {applicationId}                         Renewed License ID:     {newLicenseId}\n\n" +
                $"Application Date:     {DateTime.Today:dd/MMM/yyyy}          Old License ID:     {_oldLicenseId}\n\n" +
                $"Issue Date:     {DateTime.Today:dd/MMM/yyyy}                 Expiration Date:     {DateTime.Today.AddYears(10):dd/MMM/yyyy}\n\n" +
                $"Application Fees:     {applicationFees:0.##}                              Created By:     {_currentUser.Username}\n\n" +
                $"License Fees:     20                                      Total Fees:     {applicationFees + 20:0.##}";
        }

        private void lnkLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_oldLicense == null) return;
            using (frmLicenseHistory history = new frmLicenseHistory(Convert.ToInt32(_oldLicense["PersonID"]))) history.ShowDialog(this);
        }

        private void lnkNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_newLicenseId <= 0) return;
            using (frmLicenseInfo info = new frmLicenseInfo(_newLicenseId)) info.ShowDialog(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
