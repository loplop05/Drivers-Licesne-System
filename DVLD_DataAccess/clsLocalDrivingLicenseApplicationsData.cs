using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsLocalDrivingLicenseApplicationsData
    {
        public static bool GetLocalDrivingLicenseApplicationInfoByID(
            int LocalDrivingLicenseApplicationID, DataTable dt)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(@"
                SELECT TOP 1
                    LD.LocalDrivingLicenseApplicationID,
                    A.ApplicationID,
                    LC.ClassName,
                    A.ApplicationDate,
                    A.ApplicationStatus,
                    A.LastStatusDate,
                    A.PaidFees,
                    A.CreatedByUserID,
                    A.ApplicantPersonID,
                    (P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName) AS FullName
                FROM LocalDrivingLicenseApplications LD
                INNER JOIN Applications A ON LD.ApplicationID = A.ApplicationID
                INNER JOIN People P ON A.ApplicantPersonID = P.PersonID
                INNER JOIN LicenseClasses LC ON LD.LicenseClassID = LC.LicenseClassID
                WHERE LD.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID", connection))
            {
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }

            return dt.Rows.Count > 0;
        }

        // GET BY ID
        public static bool GetLocalDrivingLicenseApplicationByID(
            int LocalDrivingLicenseApplicationID,
            ref int ApplicationID,
            ref int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"
                SELECT *
                FROM LocalDrivingLicenseApplications
                WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                    LicenseClassID = Convert.ToInt32(reader["LicenseClassID"]);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        // ADD NEW
        public static int AddNewLocalDrivingLicenseApplication(
            int ApplicationID,
            int LicenseClassID)
        {
            int LocalDrivingLicenseApplicationID = -1;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"
                INSERT INTO LocalDrivingLicenseApplications
                (
                    ApplicationID,
                    LicenseClassID
                )
                VALUES
                (
                    @ApplicationID,
                    @LicenseClassID
                );

                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null &&
                    int.TryParse(result.ToString(), out int insertedID))
                {
                    LocalDrivingLicenseApplicationID = insertedID;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }

            return LocalDrivingLicenseApplicationID;
        }

        // UPDATE
        public static bool UpdateLocalDrivingLicenseApplication(
            int LocalDrivingLicenseApplicationID,
            int ApplicationID,
            int LicenseClassID)
        {
            int rowsAffected = 0;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"
                UPDATE LocalDrivingLicenseApplications
                SET
                    ApplicationID = @ApplicationID,
                    LicenseClassID = @LicenseClassID
                WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }

        // GET ALL
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                string query = @"
                    SELECT
                        LD.LocalDrivingLicenseApplicationID AS 'L.D.L.AppID',
                        LC.ClassName AS 'Driving Class',
                        P.NationalNo AS 'National No',
                        (P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName) AS 'Full Name',
                        A.ApplicationDate AS 'Application Date',
                        0 AS 'Passed Tests',
                        CASE
                            WHEN A.ApplicationStatus = 1 THEN 'New'
                            WHEN A.ApplicationStatus = 2 THEN 'Cancelled'
                            WHEN A.ApplicationStatus = 3 THEN 'Completed'
                            ELSE 'Unknown'
                        END AS 'Status'
                    FROM LocalDrivingLicenseApplications LD
                    INNER JOIN Applications A ON LD.ApplicationID = A.ApplicationID
                    INNER JOIN People P ON A.ApplicantPersonID = P.PersonID
                    INNER JOIN LicenseClasses LC ON LD.LicenseClassID = LC.LicenseClassID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }

            return dt;
        }

        // GET BY FILTER
        public static DataTable GetLocalDrivingLicenseApplicationsByFilter(string Filter, string Value)
        {
            DataTable dt = new DataTable();

            string query = @"
                SELECT
                    LD.LocalDrivingLicenseApplicationID AS 'L.D.L.AppID',
                    LC.ClassName AS 'Driving Class',
                    P.NationalNo AS 'National No',
                    (P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName) AS 'Full Name',
                    A.ApplicationDate AS 'Application Date',
                    0 AS 'Passed Tests',
                    CASE
                        WHEN A.ApplicationStatus = 1 THEN 'New'
                        WHEN A.ApplicationStatus = 2 THEN 'Cancelled'
                        WHEN A.ApplicationStatus = 3 THEN 'Completed'
                        ELSE 'Unknown'
                    END AS 'Status'
                FROM LocalDrivingLicenseApplications LD
                INNER JOIN Applications A ON LD.ApplicationID = A.ApplicationID
                INNER JOIN People P ON A.ApplicantPersonID = P.PersonID
                INNER JOIN LicenseClasses LC ON LD.LicenseClassID = LC.LicenseClassID";

            switch (Filter)
            {
                case "L.D.L.AppID":
                    query += " WHERE LD.LocalDrivingLicenseApplicationID LIKE '%' + @Value + '%'";
                    break;

                case "ApplicationID":
                    query += " WHERE A.ApplicationID LIKE '%' + @Value + '%'";
                    break;

                case "National No":
                    query += " WHERE P.NationalNo LIKE '%' + @Value + '%'";
                    break;

                case "Full Name":
                    query += " WHERE (P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName) LIKE '%' + @Value + '%'";
                    break;

                case "Driving Class":
                    query += " WHERE LC.ClassName LIKE '%' + @Value + '%'";
                    break;

                case "Status":
                    query += " WHERE CASE WHEN A.ApplicationStatus = 1 THEN 'New' WHEN A.ApplicationStatus = 2 THEN 'Cancelled' WHEN A.ApplicationStatus = 3 THEN 'Completed' ELSE 'Unknown' END LIKE '%' + @Value + '%'";
                    break;

                case "None":
                    break;

                default:
                    return dt;
            }

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (Filter != "None")
                {
                    command.Parameters.AddWithValue("@Value", Value);
                }

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }

            return dt;
        }

        // DELETE
        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            int rowsAffected = 0;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"
                DELETE FROM LocalDrivingLicenseApplications
                WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }

        // CHECK IF PERSON HAS ACTIVE APPLICATION FOR LICENSE CLASS
        public static bool DoesPersonHaveActiveApplicationForLicenseClass(int PersonID, int LicenseClassID)
        {
            bool hasActiveApplication = false;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"
                SELECT 1
                FROM LocalDrivingLicenseApplications LD
                INNER JOIN Applications A ON LD.ApplicationID = A.ApplicationID
                WHERE A.ApplicantPersonID = @PersonID
                AND LD.LicenseClassID = @LicenseClassID
                AND A.ApplicationStatus != 2";// -- 2 = Cancelled 

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    hasActiveApplication = true;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                hasActiveApplication = false;
            }
            finally
            {
                connection.Close();
            }

            return hasActiveApplication;
        }
    }
}
