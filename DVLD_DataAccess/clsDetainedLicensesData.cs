using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public static class clsDetainedLicensesData
    {
        public static DataTable GetDetainedLicenses(string filterValue)
        {
            DataTable table = new DataTable();
            string filter = filterValue == null ? string.Empty : filterValue.Trim();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(@"
                SELECT
                    DL.DetainID AS [Detain ID],
                    DL.LicenseID AS [License ID],
                    P.NationalNo AS [National No],
                    P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName AS [Full Name],
                    DL.DetainDate AS [Detain Date],
                    DL.FineFees AS [Fine Fees],
                    DL.IsReleased AS [Is Released],
                    DL.ReleaseDate AS [Release Date]
                FROM DetainedLicenses DL
                INNER JOIN Licenses L ON L.LicenseID = DL.LicenseID
                INNER JOIN Drivers D ON D.DriverID = L.DriverID
                INNER JOIN People P ON P.PersonID = D.PersonID
                WHERE
                    @Filter = ''
                    OR CONVERT(varchar(20), DL.DetainID) = @Filter
                    OR CONVERT(varchar(20), DL.LicenseID) = @Filter
                    OR P.NationalNo LIKE '%' + @Filter + '%'
                    OR P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName LIKE '%' + @Filter + '%'
                ORDER BY DL.DetainDate DESC;", connection))
            {
                command.Parameters.AddWithValue("@Filter", filter);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    table.Load(reader);
                }
            }

            return table;
        }

        public static DataTable GetOpenDetentionInfo(int identifier)
        {
            DataTable table = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(@"
                SELECT TOP 1
                    DL.DetainID,
                    DL.LicenseID,
                    DL.DetainDate,
                    DL.FineFees,
                    DL.IsReleased
                FROM DetainedLicenses DL
                WHERE DL.IsReleased = 0
                  AND (DL.DetainID = @Identifier OR DL.LicenseID = @Identifier)
                ORDER BY DL.DetainDate DESC;", connection))
            {
                command.Parameters.AddWithValue("@Identifier", identifier);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    table.Load(reader);
                }
            }

            return table;
        }

        public static int DetainLicense(int licenseId, decimal fineFees, int userId)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(@"
                SET NOCOUNT ON;
                SET XACT_ABORT ON;
                BEGIN TRANSACTION;

                IF NOT EXISTS
                (
                    SELECT 1
                    FROM Licenses
                    WHERE LicenseID = @LicenseID
                      AND IsActive = 1
                )
                BEGIN
                    ROLLBACK TRANSACTION;
                    SELECT -1;
                    RETURN;
                END;

                IF EXISTS
                (
                    SELECT 1
                    FROM DetainedLicenses
                    WHERE LicenseID = @LicenseID
                      AND IsReleased = 0
                )
                BEGIN
                    ROLLBACK TRANSACTION;
                    SELECT -2;
                    RETURN;
                END;

                INSERT INTO DetainedLicenses
                (
                    LicenseID,
                    DetainDate,
                    FineFees,
                    CreatedByUserID,
                    IsReleased
                )
                VALUES
                (
                    @LicenseID,
                    GETDATE(),
                    @FineFees,
                    @UserID,
                    0
                );

                DECLARE @DetainID int = CONVERT(int, SCOPE_IDENTITY());

                COMMIT TRANSACTION;
                SELECT @DetainID;", connection))
            {
                command.Parameters.AddWithValue("@LicenseID", licenseId);
                command.Parameters.AddWithValue("@FineFees", fineFees);
                command.Parameters.AddWithValue("@UserID", userId);
                connection.Open();

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public static bool ReleaseLicense(
            int detainId,
            int applicationTypeId,
            int userId,
            decimal applicationFees,
            ref int applicationId)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(@"
                SET NOCOUNT ON;
                SET XACT_ABORT ON;
                BEGIN TRANSACTION;

                DECLARE @LicenseID int;
                DECLARE @PersonID int;

                SELECT
                    @LicenseID = DL.LicenseID,
                    @PersonID = D.PersonID
                FROM DetainedLicenses DL
                INNER JOIN Licenses L ON L.LicenseID = DL.LicenseID
                INNER JOIN Drivers D ON D.DriverID = L.DriverID
                WHERE DL.DetainID = @DetainID
                  AND DL.IsReleased = 0;

                IF @LicenseID IS NULL
                BEGIN
                    ROLLBACK TRANSACTION;
                    SELECT 0 AS ApplicationID;
                    RETURN;
                END;

                INSERT INTO Applications
                (
                    ApplicantPersonID,
                    ApplicationDate,
                    ApplicationTypeID,
                    ApplicationStatus,
                    LastStatusDate,
                    PaidFees,
                    CreatedByUserID
                )
                VALUES
                (
                    @PersonID,
                    GETDATE(),
                    @ApplicationTypeID,
                    3,
                    GETDATE(),
                    @ApplicationFees,
                    @UserID
                );

                DECLARE @ApplicationID int = CONVERT(int, SCOPE_IDENTITY());

                UPDATE DetainedLicenses
                SET
                    IsReleased = 1,
                    ReleaseDate = GETDATE(),
                    ReleasedByUserID = @UserID,
                    ReleaseApplicationID = @ApplicationID
                WHERE DetainID = @DetainID;

                COMMIT TRANSACTION;
                SELECT @ApplicationID AS ApplicationID;", connection))
            {
                command.Parameters.AddWithValue("@DetainID", detainId);
                command.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeId);
                command.Parameters.AddWithValue("@UserID", userId);
                command.Parameters.AddWithValue("@ApplicationFees", applicationFees);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return false;
                    }

                    applicationId = Convert.ToInt32(reader["ApplicationID"]);
                    return applicationId > 0;
                }
            }
        }
    }
}
