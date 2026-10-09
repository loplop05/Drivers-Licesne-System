using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsLocalDrivingLicenseApplications
    {
        public static int AddNewLocalDrivingLicenseApplication(
            int ApplicationID,
            int LicenseClassID)
        {
            return clsLocalDrivingLicenseApplicationsData.AddNewLocalDrivingLicenseApplication(
                ApplicationID,
                LicenseClassID);
        }
    }
}
