using System;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsApplicationsData
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
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(@"
                INSERT INTO Applications
                    (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus,
                     LastStatusDate, PaidFees, CreatedByUserID)
                VALUES
                    (@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus,
                     @LastStatusDate, @PaidFees, @CreatedByUserID);
                SELECT SCOPE_IDENTITY();", connection))
            {
                command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                command.Parameters.AddWithValue("@PaidFees", PaidFees);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int ApplicationID))
                    {
                        return ApplicationID;
                    }
                }
                catch
                {
                    Console.WriteLine("Error while Adding New Application");
                }
            }

            return -1;
        }
    }
}
