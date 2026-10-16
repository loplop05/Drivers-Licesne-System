using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD.Applications.Local_Driving_License
{
    public partial class ctrlLocalDrivingLicenseApplicationInfo : UserControl
    {
        private int _localDrivingLicenseApplicationID = -1;

        public ctrlLocalDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        public void LoadDrivingLicsenseApplicationInfo(int LocalDrivingLicenseApplicationID)
        {
            _localDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

            DataTable applicationInfo = clsLocalDrivingLicenseApplications
                .GetLocalDrivingLicenseApplicationInfoByID(LocalDrivingLicenseApplicationID);

            if (applicationInfo.Rows.Count == 0)
            {
                ClearApplicationInfo();
                return;
            }

            DataRow row = applicationInfo.Rows[0];
            lblDrivingLicsenseAppID.Text = row["LocalDrivingLicenseApplicationID"].ToString();
            lblAppliedForLicense.Text = row["ClassName"].ToString();
            lblID.Text = row["ApplicationID"].ToString();
            lblStatus.Text = GetApplicationStatus(row["ApplicationStatus"]);
            lblFees.Text = Convert.ToDecimal(row["PaidFees"]).ToString("0.00");
            lblType.Text = "New Local Driving License";
            lblApplicant.Text = row["FullName"].ToString();
            lblDate.Text = Convert.ToDateTime(row["ApplicationDate"]).ToShortDateString();
            lblStatusDate.Text = Convert.ToDateTime(row["LastStatusDate"]).ToShortDateString();
            lblCreateByUser.Text = row["CreatedByUserID"].ToString();
            lblPassedTests.Text = "0/3";
        }

        private static string GetApplicationStatus(object status)
        {
            switch (Convert.ToByte(status))
            {
                case 1: return "New";
                case 2: return "Cancelled";
                case 3: return "Completed";
                default: return "Unknown";
            }
        }

        private void ClearApplicationInfo()
        {
            lblDrivingLicsenseAppID.Text = "???";
            lblAppliedForLicense.Text = "???";
            lblID.Text = "???";
            lblStatus.Text = "???";
            lblFees.Text = "???";
            lblType.Text = "???";
            lblApplicant.Text = "???";
            lblDate.Text = "???";
            lblStatusDate.Text = "???";
            lblCreateByUser.Text = "???";
            lblPassedTests.Text = "0/3";
        }
    }
}
