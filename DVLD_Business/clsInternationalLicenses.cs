using DVLD_DataAccess;
using System.Data;

namespace DVLD_Business
{
    public static class clsInternationalLicenses
    {
        public static DataTable GetLicenseHistory(int personId)
        {
            return clsInternationalLicensesData.GetLicenseHistory(personId);
        }

        public static int Issue(int applicationId, int driverId, int localLicenseId, int userId)
        {
            return clsInternationalLicensesData.Issue(applicationId, driverId, localLicenseId, userId);
        }

        public static DataTable GetInfo(int internationalLicenseId)
        {
            return clsInternationalLicensesData.GetInfo(internationalLicenseId);
        }
    }
}
