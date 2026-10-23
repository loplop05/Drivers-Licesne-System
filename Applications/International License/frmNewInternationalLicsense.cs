using DVLD_Business;
using DVLD.Applications.Local_Driving_License;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DVLD.Applications.International_License
{
    public partial class frmNewInternationalLicsense : Form
    {
        private readonly clsUsers _currentUser;
        private int _licenseId;
        private DataRow _license;
        private int _applicationId = -1;
        private int _internationalLicenseId = -1;

        public frmNewInternationalLicsense(clsUsers currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
        }
        private void btnFindLicense_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtLicenseId.Text.Trim(), out _licenseId) || _licenseId <= 0)
            {
                MessageBox.Show("Please enter a valid license ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLicenseId.Focus();
                return;
            }
            DataTable licenseInfo = clsLicenses.GetLicenseInfo(_licenseId);

            if (licenseInfo.Rows.Count == 0)
            {
                MessageBox.Show("License was not found.", "Search result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _license = licenseInfo.Rows[0];
            lblDriverInfo.Text = BuildDriverInfoText(_license);
            LoadApplicantImage(_license);
            lnkLicenseHistory.Enabled = true;
        }

        private void LoadApplicantImage(DataRow license)
        {
            picApplicant.Image = null;

            string imagePath = GetValue(license, "ImagePath");

            if (string.IsNullOrWhiteSpace(imagePath) || imagePath == "-")
            {
                return;
            }

            imagePath = imagePath.Replace('/', Path.DirectorySeparatorChar);

            if (!Path.IsPathRooted(imagePath))
            {
                imagePath = Path.Combine(Application.StartupPath, imagePath);
            }

            if (!File.Exists(imagePath))
            {
                return;
            }

            try
            {
                using (Image image = Image.FromFile(imagePath))
                {
                    picApplicant.Image = new Bitmap(image);
                }
            }
            catch
            {
                picApplicant.Image = null;
            }
        }

        private string BuildDriverInfoText(DataRow license)
        {
            return $"Class:     {GetValue(license, "ClassName")}        Is Active?:     {FormatBoolean(license, "IsActive")}\n\n" +
                   $"Name:     {GetValue(license, "FullName")}\n\n" +
                   $"License ID:     {GetValue(license, "LicenseID")}        Date Of Birth:     {FormatDate(license, "DateOfBirth")}\n\n" +
                   $"National No:     {GetValue(license, "NationalNo")}        Driver ID:     {GetValue(license, "DriverID")}\n\n" +
                   $"Issue Date:     {FormatDate(license, "IssueDate")}        Expiration Date:     {FormatDate(license, "ExpirationDate")}\n\n" +
                   $"Issue Reason:     {GetValue(license, "IssueReason")}        Is Detained?:     {FormatBoolean(license, "IsDetained")}";
        }

        private string GetValue(DataRow row, string columnName)
        {
            return row[columnName] == DBNull.Value ? "-" : row[columnName].ToString();
        }

        private string FormatDate(DataRow row, string columnName)
        {
            if (row[columnName] == DBNull.Value || !DateTime.TryParse(row[columnName].ToString(), out DateTime date))
            {
                return "-";
            }

            return date.ToString("dd/MMM/yyyy");
        }

        private string FormatBoolean(DataRow row, string columnName)
        {
            return row[columnName] != DBNull.Value && Convert.ToBoolean(row[columnName]) ? "Yes" : "No";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (_license == null)
            {
                MessageBox.Show("Please find a license first.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Convert.ToBoolean(_license["IsActive"]))
            {
                MessageBox.Show("The local license is not active.", "Cannot issue", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int personId = Convert.ToInt32(_license["PersonID"]);

            if (clsApplications.HasInternationalLicense(personId))
            {
                MessageBox.Show("This person already has an international license.", "Cannot issue", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable applicationTypes = clsApplicationTypes.ListAllApplicationsTypes();
            DataRow[] internationalTypes = applicationTypes.Select("ApplicationTypeTitle LIKE '%International%'");

            if (internationalTypes.Length == 0)
            {
                MessageBox.Show("The international license application type was not found.", "Cannot issue", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRow applicationType = internationalTypes[0];
            int applicationId = clsApplications.AddNewApplication(
                personId,
                DateTime.Now,
                Convert.ToInt32(applicationType["ApplicationTypeID"]),
                1,
                DateTime.Now,
                Convert.ToDecimal(applicationType["ApplicationFees"]),
                _currentUser.UserID);

            if (applicationId == -1)
            {
                MessageBox.Show("The international license application could not be created.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _applicationId = applicationId;
            try
            {
                _internationalLicenseId = clsInternationalLicenses.Issue(
                    _applicationId,
                    Convert.ToInt32(_license["DriverID"]),
                    _licenseId,
                    _currentUser.UserID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"The international license could not be issued.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (_internationalLicenseId == -1)
            {
                MessageBox.Show("The international license could not be issued.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lnkInternationalLicenseInfo.Enabled = true;
            lblApplicationInfo.Text = BuildApplicationInfoText(applicationType, _applicationId, _internationalLicenseId);

            MessageBox.Show($"International license issued successfully.\nInternational License ID: {_internationalLicenseId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string BuildApplicationInfoText(DataRow applicationType, int applicationId, int internationalLicenseId)
        {
            return $"I.L.Application ID:     {applicationId}                         I.L.License ID:     {internationalLicenseId}\n\n" +
                   $"Application Date:     {DateTime.Today:dd/MMM/yyyy}          Local License ID:     {_licenseId}\n\n" +
                   $"Issue Date:     {DateTime.Today:dd/MMM/yyyy}                 Expiration Date:     {DateTime.Today.AddYears(1):dd/MMM/yyyy}\n\n" +
                   $"Fees:     {Convert.ToDecimal(applicationType["ApplicationFees"]):0.##}                                              Created By:     {_currentUser.Username}";
        }

        private void lnkInternationalLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_internationalLicenseId <= 0)
            {
                return;
            }

            using (frmInternationalLicenseInfo info = new frmInternationalLicenseInfo(_internationalLicenseId))
            {
                info.ShowDialog(this);
            }
        }

        private void lnkLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_license == null)
            {
                return;
            }

            using (frmLicenseHistory history = new frmLicenseHistory(Convert.ToInt32(_license["PersonID"])))
            {
                history.ShowDialog(this);
            }
        }
    }
}
