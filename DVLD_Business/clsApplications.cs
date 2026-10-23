using DVLD_DataAccess;
using System;
using System.Data;

namespace DVLD_Business
{
    public class clsApplications
    {
        public static DataTable GetInternationalApplicationsByFilter(string filterBy, string filterValue)
        {
            return clsApplicationsData.GetInternationalApplicationsByFilter(filterBy, filterValue);
        }

        public static bool HasInternationalLicense(int personID) => clsApplicationsData.HasInternationalLicense(personID);

        public static bool UpdateApplicationStatus(int applicationID, byte status) => clsApplicationsData.UpdateApplicationStatus(applicationID, status);
        public static int AddNewApplication(
            int ApplicantPersonID,
            DateTime ApplicationDate,
            int ApplicationTypeID,
            byte ApplicationStatus,
            DateTime LastStatusDate,
            decimal PaidFees,
            int CreatedByUserID)
        {
            return clsApplicationsData.AddNewApplication(
                ApplicantPersonID,
                ApplicationDate,
                ApplicationTypeID,
                ApplicationStatus,
                LastStatusDate,
                PaidFees,
                CreatedByUserID);
        }
    }
}
