using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public static class clsLicenses
    {
        public static DataTable GetLicenseHistory(int personID) => clsLicensesData.GetLicenseHistory(personID);
        public static int GetLicenseIDByLocalApplicationID(int id) => clsLicensesData.GetLicenseIDByLocalApplicationID(id);
        public static bool CanIssueFirstLicense(int id) => clsLicensesData.CanIssueFirstLicense(id);
        public static int IssueFirstLicense(int id, int userID, string notes) => clsLicensesData.IssueFirstLicense(id, userID, notes);
        public static DataTable GetLicenseInfo(int id) => clsLicensesData.GetLicenseInfo(id);
        public static int RenewLicense(int applicationId, int oldLicenseId, int userId, decimal licenseFees) => clsLicensesData.RenewLicense(applicationId, oldLicenseId, userId, licenseFees);

        public static bool ReplaceLicense(
            int applicationTypeId,
            int oldLicenseId,
            int userId,
            decimal applicationFees,
            byte issueReason,
            ref int applicationId,
            ref int newLicenseId)
        {
            return clsLicensesData.ReplaceLicense(
                applicationTypeId,
                oldLicenseId,
                userId,
                applicationFees,
                issueReason,
                ref applicationId,
                ref newLicenseId);
        }
    }
}
