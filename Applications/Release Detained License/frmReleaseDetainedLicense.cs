using System;
using System.Data;
using System.Windows.Forms;
using DVLD.Applications.Controls;
using DVLD.Applications.Local_Driving_License;
using DVLD_Business;

namespace DVLD.Applications.ReleaseDetainedLicense
{
    public partial class frmReleaseDetainedLicense : Form
    {
        private readonly clsUsers _currentUser;
        private DataRow _detention;
        private DataRow _license;
        private int _licenseId = -1;
        private int _applicationId = -1;

        public frmReleaseDetainedLicense() : this(null)
        {
        }

        public frmReleaseDetainedLicense(clsUsers currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            btnRelease.Enabled = false;
            lnkLicenseHistory.Enabled = false;
        }

        private void btnFindDetention_Click(object sender, EventArgs e)
        {
            ClearSearchState();

            if (!int.TryParse(txtDetainId.Text.Trim(), out int identifier) || identifier <= 0)
            {
                MessageBox.Show(
                    "Please enter a valid detain ID or license ID.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtDetainId.Focus();
                return;
            }

            DataTable detentionInfo = clsDetainedLicenses.GetOpenDetentionInfo(identifier);

            if (detentionInfo.Rows.Count == 0)
            {
                MessageBox.Show(
                    "An open detained license was not found.",
                    "Search result",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            _detention = detentionInfo.Rows[0];
            _licenseId = Convert.ToInt32(_detention["LicenseID"]);
            DataTable licenseInfo = clsLicenses.GetLicenseInfo(_licenseId);

            if (licenseInfo.Rows.Count == 0)
            {
                MessageBox.Show(
                    "The detained license information was not found.",
                    "Search result",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                ClearSearchState();
                return;
            }

            _license = licenseInfo.Rows[0];
            ctrlLicenseInfo.LoadLicenseInfo(_licenseId);
            ShowDetentionInfo();
            lnkLicenseHistory.Enabled = true;
            btnRelease.Enabled = true;
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (_detention == null || !btnRelease.Enabled)
            {
                return;
            }

            if (_currentUser == null)
            {
                MessageBox.Show(
                    "A logged-in user is required to release a license.",
                    "Cannot release license",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!TryGetReleaseApplicationType(
                    out int applicationTypeId,
                    out decimal applicationFees))
            {
                MessageBox.Show(
                    "The release detained license application type was not found.",
                    "Cannot release license",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            try
            {
                bool released = clsDetainedLicenses.ReleaseLicense(
                    Convert.ToInt32(_detention["DetainID"]),
                    applicationTypeId,
                    _currentUser.UserID,
                    applicationFees,
                    ref _applicationId);

                if (!released)
                {
                    MessageBox.Show(
                        "The detained license could not be released.",
                        "Release failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "The detained license could not be released.\n\n" + ex.Message,
                    "Release failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            lblApplicationIdValue.Text = _applicationId.ToString();
            btnRelease.Enabled = false;
            _detention = null;

            ctrlLicenseInfo.LoadLicenseInfo(_licenseId);

            MessageBox.Show(
                "Detained license released successfully.\nRelease Application ID: " + _applicationId,
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private bool TryGetReleaseApplicationType(
            out int applicationTypeId,
            out decimal applicationFees)
        {
            applicationTypeId = -1;
            applicationFees = 0;

            DataTable applicationTypes = clsApplicationTypes.ListAllApplicationsTypes();
            DataRow[] releaseTypes = applicationTypes.Select(
                "ApplicationTypeTitle LIKE '%Release Detained%'"
            );

            if (releaseTypes.Length == 0)
            {
                releaseTypes = applicationTypes.Select(
                    "ApplicationTypeTitle LIKE '%Release%'"
                );
            }

            if (releaseTypes.Length == 0)
            {
                return false;
            }

            applicationTypeId = Convert.ToInt32(releaseTypes[0]["ApplicationTypeID"]);
            applicationFees = Convert.ToDecimal(releaseTypes[0]["ApplicationFees"]);
            return true;
        }

        private void ShowDetentionInfo()
        {
            lblDetainIdValue.Text = _detention["DetainID"].ToString();
            lblLicenseIdValue.Text = _detention["LicenseID"].ToString();
            lblDetainDateValue.Text = Convert.ToDateTime(_detention["DetainDate"])
                .ToString("dd/MMM/yyyy");
            lblFineFeesValue.Text = Convert.ToDecimal(_detention["FineFees"])
                .ToString("0.##");
            lblApplicationIdValue.Text = "[???]";
        }

        private void lnkLicenseHistory_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            if (_license == null)
            {
                return;
            }

            using (frmLicenseHistory history = new frmLicenseHistory(
                Convert.ToInt32(_license["PersonID"])))
            {
                history.ShowDialog(this);
            }
        }

        private void ClearSearchState()
        {
            _detention = null;
            _license = null;
            _licenseId = -1;
            _applicationId = -1;
            btnRelease.Enabled = false;
            lnkLicenseHistory.Enabled = false;
            ctrlLicenseInfo.ClearInfo();
            ClearDetentionInfo();
        }

        private void ClearDetentionInfo()
        {
            lblDetainIdValue.Text = "[???]";
            lblLicenseIdValue.Text = "[???]";
            lblDetainDateValue.Text = "[???]";
            lblFineFeesValue.Text = "[???]";
            lblApplicationIdValue.Text = "[???]";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
