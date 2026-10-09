using System;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsLocalDrivingLicenseApplicationsData
    {
        public static int AddNewLocalDrivingLicenseApplication(
            int ApplicationID,
            int LicenseClassID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(@"
                INSERT INTO LocalDrivingLicenseApplications
                    (ApplicationID, LicenseClassID)
                VALUES
                    (@ApplicationID, @LicenseClassID);
                SELECT SCOPE_IDENTITY();", connection))
            {
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int LocalDrivingLicenseApplicationID))
                    {
                        return LocalDrivingLicenseApplicationID;
                    }
                }
                catch
                {
                    Console.WriteLine("Error while Adding New Local Driving License Application");
                }
            }

            return -1;
        }
    }
}
