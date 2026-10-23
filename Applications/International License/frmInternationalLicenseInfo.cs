using DVLD_Business;
using DVLD.Applications.Local_Driving_License;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DVLD.Applications.International_License
{
    public partial class frmInternationalLicenseInfo : Form
    {
        private readonly int _internationalLicenseId;

        public frmInternationalLicenseInfo(int internationalLicenseId)
        {
            InitializeComponent();
            _internationalLicenseId = internationalLicenseId;
            LoadLicenseInfo();
        }

        private void LoadLicenseInfo()
        {
            DataTable info = clsInternationalLicenses.GetInfo(_internationalLicenseId);

            if (info.Rows.Count == 0)
            {
                MessageBox.Show("International license was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            DataRow license = info.Rows[0];
            lblLicenseInfo.Text = $"Name:     {license["FullName"]}\n\n" +
                $"Int. License ID:     {license["InternationalLicenseID"]}        Application ID:     {license["ApplicationID"]}\n\n" +
                $"License ID:     {license["LocalLicenseID"]}                         Is Active?:     {(Convert.ToBoolean(license["IsActive"]) ? "Yes" : "No")}\n\n" +
                $"National No:     {license["NationalNo"]}                  Date Of Birth:     {Convert.ToDateTime(license["DateOfBirth"]):dd/MMM/yyyy}\n\n" +
                $"Gender:     {license["Gendor"]}                              Driver ID:     {license["DriverID"]}\n\n" +
                $"Issue Date:     {Convert.ToDateTime(license["IssueDate"]):dd/MMM/yyyy}                 Expiration Date:     {Convert.ToDateTime(license["ExpirationDate"]):dd/MMM/yyyy}";

            LoadApplicantImage(license["ImagePath"]?.ToString());
        }

        private void LoadApplicantImage(string imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath))
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lnkLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataTable info = clsInternationalLicenses.GetInfo(_internationalLicenseId);

            if (info.Rows.Count == 0)
            {
                return;
            }

            using (frmLicenseHistory history = new frmLicenseHistory(Convert.ToInt32(info.Rows[0]["PersonID"])))
            {
                history.ShowDialog(this);
            }
        }
    }
}
