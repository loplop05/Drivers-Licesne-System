using DVLD_DataAccess;
using System;
using System.Data;

namespace DVLD_Business
{
    public class clsLocalDrivingLicenseApplications
    {
        public enum enMode
        {
            AddNew = 0,
            Update = 1
        }

        public enMode Mode { get; set; }

        public int LocalDrivingLicenseApplicationID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        // CONSTRUCTOR FOR ADD NEW
        public clsLocalDrivingLicenseApplications()
        {
            LocalDrivingLicenseApplicationID = -1;
            ApplicationID = -1;
            LicenseClassID = -1;

            Mode = enMode.AddNew;
        }

        // CONSTRUCTOR FOR EXISTING
        private clsLocalDrivingLicenseApplications(
            int LocalDrivingLicenseApplicationID,
            int ApplicationID,
            int LicenseClassID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;

            Mode = enMode.Update;
        }

        // FIND BY ID
        public static clsLocalDrivingLicenseApplications Find(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = -1;
            int LicenseClassID = -1;

            bool IsFound = clsLocalDrivingLicenseApplicationsData.GetLocalDrivingLicenseApplicationByID(
                LocalDrivingLicenseApplicationID,
                ref ApplicationID,
                ref LicenseClassID
            );

            if (IsFound)
            {
                return new clsLocalDrivingLicenseApplications(
                    LocalDrivingLicenseApplicationID,
                    ApplicationID,
                    LicenseClassID
                );
            }

            return null;
        }

        public static DataTable GetLocalDrivingLicenseApplicationInfoByID(int LocalDrivingLicenseApplicationID)
        {
            DataTable dt = new DataTable();
            clsLocalDrivingLicenseApplicationsData.GetLocalDrivingLicenseApplicationInfoByID(
                LocalDrivingLicenseApplicationID, dt);
            return dt;
        }

        // ADD NEW
        private bool _AddNewLocalDrivingLicenseApplication()
        {
            LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationsData.AddNewLocalDrivingLicenseApplication(
                ApplicationID,
                LicenseClassID
            );

            return LocalDrivingLicenseApplicationID != -1;
        }

        // UPDATE
        private bool _UpdateLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingLicenseApplicationsData.UpdateLocalDrivingLicenseApplication(
                LocalDrivingLicenseApplicationID,
                ApplicationID,
                LicenseClassID
            );
        }

        // SAVE
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLocalDrivingLicenseApplication())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateLocalDrivingLicenseApplication();
            }

            return false;
        }

        // STATIC ADD NEW (legacy support)
        public static int AddNewLocalDrivingLicenseApplication(
            int ApplicationID,
            int LicenseClassID)
        {
            return clsLocalDrivingLicenseApplicationsData.AddNewLocalDrivingLicenseApplication(
                ApplicationID,
                LicenseClassID);
        }

        // GET ALL
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationsData.GetAllLocalDrivingLicenseApplications();
        }

        // GET BY FILTER
        public static DataTable GetLocalDrivingLicenseApplicationsByFilter(string ColumnName, string Value)
        {
            return clsLocalDrivingLicenseApplicationsData.GetLocalDrivingLicenseApplicationsByFilter(ColumnName, Value);
        }

        // DELETE
        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplicationsData.DeleteLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID);
        }

        // CHECK IF PERSON HAS ACTIVE APPLICATION FOR LICENSE CLASS
        public static bool DoesPersonHaveActiveApplicationForLicenseClass(int PersonID, int LicenseClassID)
        {
            return clsLocalDrivingLicenseApplicationsData.DoesPersonHaveActiveApplicationForLicenseClass(PersonID, LicenseClassID);
        }
    }
}
