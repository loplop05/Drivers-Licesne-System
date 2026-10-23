using System;
using System.Data;
using System.Windows.Forms;
using DVLD.Applications.Controls;
using DVLD.Applications.Local_Driving_License;
using DVLD_Business;

namespace DVLD.Licenses.DetainLicense
{
    public partial class frmDetainLicense : Form
    {
        private readonly clsUsers _currentUser;
        private DataRow _license;
        private int _licenseId = -1;

        public frmDetainLicense() : this(null)
        {
        }

        public frmDetainLicense(clsUsers currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            btnDetain.Enabled = false;
            lnkLicenseHistory.Enabled = false;
        }

        private void btnFindLicense_Click(object sender, EventArgs e)
        {
            ClearSearchState();

            if (!int.TryParse(txtLicenseId.Text.Trim(), out _licenseId) || _licenseId <= 0)
            {
                MessageBox.Show(
                    "Please enter a valid license ID.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtLicenseId.Focus();
                return;
            }

            DataTable licenseInfo = clsLicenses.GetLicenseInfo(_licenseId);

            if (licenseInfo.Rows.Count == 0)
            {
                MessageBox.Show(
                    "License was not found.",
                    "Search result",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            _license = licenseInfo.Rows[0];
            ctrlLicenseInfo.LoadLicenseInfo(_licenseId);
            lnkLicenseHistory.Enabled = true;

            if (!Convert.ToBoolean(_license["IsActive"]))
            {
                MessageBox.Show(
                    "This license is not active and cannot be detained.",
                    "Cannot detain license",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (Convert.ToBoolean(_license["IsDetained"]))
            {
                MessageBox.Show(
                    "This license is already detained.",
                    "Cannot detain license",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            btnDetain.Enabled = true;
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (_license == null || !btnDetain.Enabled)
            {
                return;
            }

            if (_currentUser == null)
            {
                MessageBox.Show(
                    "A logged-in user is required to detain a license.",
                    "Cannot detain license",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtFineFees.Text.Trim(), out decimal fineFees) || fineFees <= 0)
            {
                MessageBox.Show(
                    "Please enter valid fine fees.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtFineFees.Focus();
                return;
            }

            int detainId;

            try
            {
                detainId = clsDetainedLicenses.DetainLicense(
                    _licenseId,
                    fineFees,
                    _currentUser.UserID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "The license could not be detained.\n\n" + ex.Message,
                    "Detain failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (detainId == -2)
            {
                MessageBox.Show(
                    "This license is already detained.",
                    "Cannot detain license",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (detainId <= 0)
            {
                MessageBox.Show(
                    "This license is not active and could not be detained.",
                    "Detain failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            btnDetain.Enabled = false;
            _license = clsLicenses.GetLicenseInfo(_licenseId).Rows[0];
            ctrlLicenseInfo.LoadLicenseInfo(_licenseId);

            MessageBox.Show(
                "License detained successfully.\nDetain ID: " + detainId,
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
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
            _license = null;
            btnDetain.Enabled = false;
            lnkLicenseHistory.Enabled = false;
            ctrlLicenseInfo.ClearInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
