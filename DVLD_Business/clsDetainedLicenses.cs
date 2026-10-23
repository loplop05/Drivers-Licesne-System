using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public static class clsDetainedLicenses
    {
        public static DataTable GetDetainedLicenses(string filterValue)
        {
            return clsDetainedLicensesData.GetDetainedLicenses(filterValue);
        }

        public static DataTable GetOpenDetentionInfo(int identifier)
        {
            return clsDetainedLicensesData.GetOpenDetentionInfo(identifier);
        }

        public static int DetainLicense(int licenseId, decimal fineFees, int userId)
        {
            return clsDetainedLicensesData.DetainLicense(licenseId, fineFees, userId);
        }

        public static bool ReleaseLicense(
            int detainId,
            int applicationTypeId,
            int userId,
            decimal applicationFees,
            ref int applicationId)
        {
            return clsDetainedLicensesData.ReleaseLicense(
                detainId,
                applicationTypeId,
                userId,
                applicationFees,
                ref applicationId);
        }
    }
}
