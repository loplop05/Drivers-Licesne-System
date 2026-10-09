using DVLD_DataAccess;
using System;

namespace DVLD_Business
{
    public class clsApplications
    {
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
