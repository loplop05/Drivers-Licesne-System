using System;
using System.Data;
using System.Windows.Forms;
using DVLD.Applications.Local_Driving_License;
using DVLD_Business;

namespace DVLD.Applications.ReplaceLostOrDamagedLicense
{
    public partial class frmReplaceLostOrDamagedLicense : Form
    {
        private const byte DamagedLicenseReason = 3;
        private const byte LostLicenseReason = 4;

        private readonly clsUsers _currentUser;
        private DataRow _oldLicense;
        private int _oldLicenseId = -1;
        private int _applicationId = -1;
        private int _newLicenseId = -1;

        public frmReplaceLostOrDamagedLicense() : this(null)
        {
        }

        public frmReplaceLostOrDamagedLicense(clsUsers currentUser)
        {
            InitializeComponent();

            _currentUser = currentUser;
            btnIssueReplacement.Enabled = false;
            lnkLicenseHistory.Enabled = false;
            lnkNewLicenseInfo.Enabled = false;
        }

        private void btnFindLicense_Click(object sender, EventArgs e)
        {
            ClearSearchState();

            if (!int.TryParse(txtLicenseId.Text.Trim(), out _oldLicenseId) || _oldLicenseId <= 0)
            {
                MessageBox.Show(
                    "Please enter a valid license ID.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtLicenseId.Focus();
                return;
            }

            DataTable licenseInfo = clsLicenses.GetLicenseInfo(_oldLicenseId);

            if (licenseInfo.Rows.Count == 0)
            {
                MessageBox.Show(
                    "License was not found.",
                    "Search result",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            _oldLicense = licenseInfo.Rows[0];
            ctrlLicenseInfo.LoadLicenseInfo(_oldLicenseId);
            lnkLicenseHistory.Enabled = true;

            if (!CanReplaceLicense())
            {
                return;
            }

            btnIssueReplacement.Enabled = true;
        }

        private bool CanReplaceLicense()
        {
            if (!Convert.ToBoolean(_oldLicense["IsActive"]))
            {
                MessageBox.Show(
                    "This license is not active and cannot be replaced.",
                    "Cannot replace license",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (Convert.ToBoolean(_oldLicense["IsDetained"]))
            {
                MessageBox.Show(
                    "This license is detained and cannot be replaced.",
                    "Cannot replace license",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            DateTime expirationDate = Convert.ToDateTime(_oldLicense["ExpirationDate"]).Date;

            if (expirationDate < DateTime.Today)
            {
                MessageBox.Show(
                    "This license has expired. Renew it before replacing it.",
                    "Cannot replace license",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if (_oldLicense == null || !btnIssueReplacement.Enabled)
            {
                return;
            }

            if (_currentUser == null)
            {
                MessageBox.Show(
                    "A logged-in user is required to issue a replacement license.",
                    "Cannot issue license",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!TryGetReplacementApplicationType(
                    out int applicationTypeId,
                    out decimal applicationFees))
            {
                MessageBox.Show(
                    "The replacement application type was not found.",
                    "Cannot issue license",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            byte issueReason = rdoLostLicense.Checked
                ? LostLicenseReason
                : DamagedLicenseReason;

            try
            {
                bool issued = clsLicenses.ReplaceLicense(
                    applicationTypeId,
                    _oldLicenseId,
                    _currentUser.UserID,
                    applicationFees,
                    issueReason,
                    ref _applicationId,
                    ref _newLicenseId);

                if (!issued)
                {
                    MessageBox.Show(
                        "The replacement license could not be issued.",
                        "Issue failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "The replacement license could not be issued.\n\n" + ex.Message,
                    "Issue failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            ShowApplicationInfo(applicationFees);
            btnIssueReplacement.Enabled = false;
            lnkNewLicenseInfo.Enabled = true;

            MessageBox.Show(
                "Replacement license issued successfully.\nNew License ID: " + _newLicenseId,
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void replacementType_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoLostLicense.Checked)
            {
                lblTitle.Text = "Replacement for Lost License";
                Text = "Replacement for Lost License";
                return;
            }

            lblTitle.Text = "Replacement for Damaged License";
            Text = "Replacement for Damaged License";
        }

        private bool TryGetReplacementApplicationType(
            out int applicationTypeId,
            out decimal applicationFees)
        {
            applicationTypeId = -1;
            applicationFees = 0;

            DataTable applicationTypes = clsApplicationTypes.ListAllApplicationsTypes();
            string reason = rdoLostLicense.Checked ? "Lost" : "Damaged";
            DataRow[] matchingTypes = applicationTypes.Select(
                "ApplicationTypeTitle LIKE '%" + reason + "%'"
            );

            if (matchingTypes.Length == 0)
            {
                matchingTypes = applicationTypes.Select(
                    "ApplicationTypeTitle LIKE '%Replacement%'"
                );
            }

            if (matchingTypes.Length == 0)
            {
                return false;
            }

            applicationTypeId = Convert.ToInt32(matchingTypes[0]["ApplicationTypeID"]);
            applicationFees = Convert.ToDecimal(matchingTypes[0]["ApplicationFees"]);

            return true;
        }

        private void ShowApplicationInfo(decimal applicationFees)
        {
            lblApplicationIdValue.Text = _applicationId.ToString();
            lblApplicationDateValue.Text = DateTime.Today.ToString("dd/MMM/yyyy");
            lblApplicationFeesValue.Text = applicationFees.ToString("0.##");
            lblNewLicenseIdValue.Text = _newLicenseId.ToString();
            lblOldLicenseIdValue.Text = _oldLicenseId.ToString();
            lblCreatedByValue.Text = _currentUser.Username;
        }

        private void ClearSearchState()
        {
            _oldLicense = null;
            _applicationId = -1;
            _newLicenseId = -1;
            btnIssueReplacement.Enabled = false;
            lnkLicenseHistory.Enabled = false;
            lnkNewLicenseInfo.Enabled = false;
            ctrlLicenseInfo.ClearInfo();
            ClearApplicationInfo();
        }

        private void ClearApplicationInfo()
        {
            lblApplicationIdValue.Text = "[???]";
            lblApplicationDateValue.Text = "[???]";
            lblApplicationFeesValue.Text = "[???]";
            lblNewLicenseIdValue.Text = "[???]";
            lblOldLicenseIdValue.Text = "[???]";
            lblCreatedByValue.Text = "[???]";
        }

        private void lnkLicenseHistory_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            if (_oldLicense == null)
            {
                return;
            }

            using (frmLicenseHistory history = new frmLicenseHistory(
                Convert.ToInt32(_oldLicense["PersonID"])))
            {
                history.ShowDialog(this);
            }
        }

        private void lnkNewLicenseInfo_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            if (_newLicenseId <= 0)
            {
                return;
            }

            using (frmLicenseInfo licenseInfo = new frmLicenseInfo(_newLicenseId))
            {
                licenseInfo.ShowDialog(this);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
