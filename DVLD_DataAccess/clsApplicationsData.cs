using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsApplicationsData
    {
        public static DataTable GetInternationalApplicationsByFilter(string filterBy, string filterValue)
        {
            DataTable table = new DataTable();
            string query = @"SELECT A.ApplicationID AS [I.L.AppID], A.ApplicationDate AS [Application Date],
                P.PersonID AS [Person ID], P.NationalNo AS [National No], P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName AS [Full Name],
                T.ApplicationTypeTitle AS [Application Type], A.ApplicationStatus,
                CASE A.ApplicationStatus WHEN 1 THEN 'New' WHEN 2 THEN 'Cancelled' WHEN 3 THEN 'Completed' ELSE 'Unknown' END AS [Status],
                A.PaidFees AS [Fees], U.Username AS [Created By]
                FROM Applications A
                INNER JOIN ApplicationTypes T ON T.ApplicationTypeID = A.ApplicationTypeID
                INNER JOIN People P ON P.PersonID = A.ApplicantPersonID
                INNER JOIN Users U ON U.UserID = A.CreatedByUserID
                WHERE T.ApplicationTypeTitle LIKE '%International%'
                AND (@FilterBy = 'None' OR
                    (@FilterBy = 'I.L.AppID' AND A.ApplicationID = TRY_CONVERT(int, @FilterValue)) OR
                    (@FilterBy = 'National No' AND P.NationalNo LIKE '%' + @FilterValue + '%') OR
                    (@FilterBy = 'Full Name' AND (P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName) LIKE '%' + @FilterValue + '%') OR
                    (@FilterBy = 'Status' AND (CASE A.ApplicationStatus WHEN 1 THEN 'New' WHEN 2 THEN 'Cancelled' WHEN 3 THEN 'Completed' ELSE 'Unknown' END) LIKE '%' + @FilterValue + '%'))
                ORDER BY A.ApplicationID DESC";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@FilterBy", filterBy);
                command.Parameters.AddWithValue("@FilterValue", filterValue);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    table.Load(reader);
                }
            }

            return table;
        }

        public static bool HasInternationalLicense(int personID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(@"SELECT COUNT(*) FROM Applications A INNER JOIN ApplicationTypes T ON T.ApplicationTypeID = A.ApplicationTypeID WHERE A.ApplicantPersonID = @PersonID AND A.ApplicationStatus = 3 AND T.ApplicationTypeTitle LIKE '%International%'", connection))
            {
                command.Parameters.AddWithValue("@PersonID", personID);
                connection.Open();
                return Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
        }

        public static bool UpdateApplicationStatus(int applicationID, byte status)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand("UPDATE Applications SET ApplicationStatus = @Status, LastStatusDate = GETDATE() WHERE ApplicationID = @ApplicationID", connection))
            { command.Parameters.AddWithValue("@ApplicationID", applicationID); command.Parameters.AddWithValue("@Status", status); connection.Open(); return command.ExecuteNonQuery() > 0; }
        }

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
