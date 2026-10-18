using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public static class clsLicenses
    {
        public static int GetLicenseIDByLocalApplicationID(int id) => clsLicensesData.GetLicenseIDByLocalApplicationID(id);
        public static bool CanIssueFirstLicense(int id) => clsLicensesData.CanIssueFirstLicense(id);
        public static int IssueFirstLicense(int id, int userID, string notes) => clsLicensesData.IssueFirstLicense(id, userID, notes);
        public static DataTable GetLicenseInfo(int id) => clsLicensesData.GetLicenseInfo(id);
    }
}
