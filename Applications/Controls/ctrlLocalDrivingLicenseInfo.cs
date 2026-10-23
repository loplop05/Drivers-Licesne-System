using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD.Applications.Controls
{
    [ToolboxItem(true)]
    [DesignerCategory("UserControl")]
    public partial class ctrlLocalDrivingLicenseInfo : UserControl
    {
        public ctrlLocalDrivingLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadLicenseInfo(int licenseId)
        {
            DataTable licenseInfo = clsLicenses.GetLicenseInfo(licenseId);

            if (licenseInfo.Rows.Count == 0)
            {
                ClearInfo();
                return;
            }

            DataRow license = licenseInfo.Rows[0];
            lblClass.Text = GetValue(license, "ClassName");
            lblName.Text = GetValue(license, "FullName");
            lblLicenseId.Text = GetValue(license, "LicenseID");
            lblIsActive.Text = FormatBoolean(license, "IsActive");
            lblNationalNo.Text = GetValue(license, "NationalNo");
            lblDateOfBirth.Text = FormatDate(license, "DateOfBirth");
            lblGender.Text = GetValue(license, "Gendor");
            lblDriverId.Text = GetValue(license, "DriverID");
            lblIssueDate.Text = FormatDate(license, "IssueDate");
            lblExpirationDate.Text = FormatDate(license, "ExpirationDate");
            lblIssueReason.Text = GetValue(license, "IssueReason");
            lblIsDetained.Text = FormatBoolean(license, "IsDetained");
            lblNotes.Text = GetValue(license, "Notes");
            LoadApplicantImage(GetValue(license, "ImagePath"));
        }

        public void ClearInfo()
        {
            lblClass.Text = "[???]"; lblName.Text = "[???]"; lblLicenseId.Text = "[???]"; lblIsActive.Text = "[???]";
            lblNationalNo.Text = "[???]"; lblDateOfBirth.Text = "[???]"; lblGender.Text = "[???]"; lblDriverId.Text = "[???]";
            lblIssueDate.Text = "[???]"; lblExpirationDate.Text = "[???]"; lblIssueReason.Text = "[???]"; lblIsDetained.Text = "[???]"; lblNotes.Text = "[???]";
            picApplicant.Image = null;
        }

        private void LoadApplicantImage(string imagePath)
        {
            picApplicant.Image = null;
            if (string.IsNullOrWhiteSpace(imagePath) || imagePath == "-") return;
            imagePath = imagePath.Replace('/', Path.DirectorySeparatorChar);
            if (!Path.IsPathRooted(imagePath)) imagePath = Path.Combine(Application.StartupPath, imagePath);
            if (!File.Exists(imagePath)) return;

            try
            {
                using (Image image = Image.FromFile(imagePath)) picApplicant.Image = new Bitmap(image);
            }
            catch
            {
                picApplicant.Image = null;
            }
        }

        private string GetValue(DataRow row, string columnName)
        {
            return row[columnName] == DBNull.Value ? "-" : row[columnName].ToString();
        }

        private string FormatDate(DataRow row, string columnName)
        {
            return row[columnName] == DBNull.Value ? "-" : Convert.ToDateTime(row[columnName]).ToString("dd/MMM/yyyy");
        }

        private string FormatBoolean(DataRow row, string columnName)
        {
            return row[columnName] != DBNull.Value && Convert.ToBoolean(row[columnName]) ? "Yes" : "No";
        }
    }
}
