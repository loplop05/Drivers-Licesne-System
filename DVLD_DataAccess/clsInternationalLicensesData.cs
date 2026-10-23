using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public static class clsInternationalLicensesData
    {
        public static DataTable GetLicenseHistory(int personId)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(@"SELECT IL.InternationalLicenseID AS [Int. Lic.ID], IL.ApplicationID AS [App.ID], IL.IssuedUsingLocalLicenseID AS [Local Lic.ID], IL.IssueDate AS [Issue Date], IL.ExpirationDate AS [Expiration Date], IL.IsActive AS [Is Active] FROM InternationalLicenses IL INNER JOIN Drivers D ON D.DriverID = IL.DriverID WHERE D.PersonID = @PersonID ORDER BY IL.IssueDate DESC", connection))
            {
                command.Parameters.AddWithValue("@PersonID", personId);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader()) table.Load(reader);
            }
            return table;
        }

        public static int Issue(int applicationId, int driverId, int localLicenseId, int userId)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(@"
                SET NOCOUNT ON;
                SET XACT_ABORT ON;
                BEGIN TRANSACTION;
                INSERT INTO InternationalLicenses
                    (ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID)
                VALUES
                    (@ApplicationID, @DriverID, @LocalLicenseID, GETDATE(), DATEADD(year, 1, GETDATE()), 1, @UserID);
                UPDATE Applications SET ApplicationStatus = 3, LastStatusDate = GETDATE() WHERE ApplicationID = @ApplicationID;
                SELECT CONVERT(int, SCOPE_IDENTITY());
                COMMIT TRANSACTION;", connection))
            {
                command.Parameters.AddWithValue("@ApplicationID", applicationId);
                command.Parameters.AddWithValue("@DriverID", driverId);
                command.Parameters.AddWithValue("@LocalLicenseID", localLicenseId);
                command.Parameters.AddWithValue("@UserID", userId);
                connection.Open();
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public static DataTable GetInfo(int internationalLicenseId)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(@"SELECT TOP 1 IL.InternationalLicenseID, IL.ApplicationID, IL.IssuedUsingLocalLicenseID AS LocalLicenseID, IL.IssueDate, IL.ExpirationDate, IL.IsActive, D.DriverID, P.PersonID, P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName AS FullName, P.NationalNo, P.DateOfBirth, P.Gendor, P.ImagePath FROM InternationalLicenses IL INNER JOIN Drivers D ON D.DriverID = IL.DriverID INNER JOIN People P ON P.PersonID = D.PersonID WHERE IL.InternationalLicenseID = @ID", connection))
            {
                command.Parameters.AddWithValue("@ID", internationalLicenseId);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader()) table.Load(reader);
            }
            return table;
        }
    }
}
