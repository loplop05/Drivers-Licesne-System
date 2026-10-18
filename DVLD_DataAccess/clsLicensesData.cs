using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public static class clsLicensesData
    {
        public static DataTable GetLicenseHistory(int personID)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand("SELECT L.LicenseID AS [Lic.ID], L.ApplicationID AS [App.ID], LC.ClassName AS [Class Name], L.IssueDate AS [Issue Date], L.ExpirationDate AS [Expiration Date], L.IsActive AS [Is Active] FROM Licenses L INNER JOIN Drivers D ON D.DriverID=L.DriverID INNER JOIN LicenseClasses LC ON LC.LicenseClassID=L.LicenseClass WHERE D.PersonID=@PersonID ORDER BY L.IssueDate DESC", connection))
            { command.Parameters.AddWithValue("@PersonID", personID); connection.Open(); using (SqlDataReader reader = command.ExecuteReader()) table.Load(reader); }
            return table;
        }
        public static int GetLicenseIDByLocalApplicationID(int localApplicationID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(@"SELECT TOP 1 L.LicenseID FROM Licenses L INNER JOIN Applications A ON A.ApplicationID = L.ApplicationID INNER JOIN LocalDrivingLicenseApplications LD ON LD.ApplicationID = A.ApplicationID WHERE LD.LocalDrivingLicenseApplicationID = @ID", connection))
            {
                command.Parameters.AddWithValue("@ID", localApplicationID);
                connection.Open();
                object result = command.ExecuteScalar();
                return result == null || result == DBNull.Value ? -1 : Convert.ToInt32(result);
            }
        }

        public static bool CanIssueFirstLicense(int localApplicationID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(@"SELECT CASE WHEN EXISTS (SELECT 1 FROM LocalDrivingLicenseApplications LD INNER JOIN TestAppointments TA ON TA.LocalDrivingLicenseApplicationID = LD.LocalDrivingLicenseApplicationID INNER JOIN Tests T ON T.TestAppointmentID = TA.TestAppointmentID WHERE LD.LocalDrivingLicenseApplicationID = @ID AND T.TestResult = 1 GROUP BY LD.LocalDrivingLicenseApplicationID HAVING COUNT(DISTINCT TA.TestTypeID) = 3) AND NOT EXISTS (SELECT 1 FROM Licenses L INNER JOIN Applications A ON A.ApplicationID = L.ApplicationID INNER JOIN LocalDrivingLicenseApplications LD ON LD.ApplicationID = A.ApplicationID WHERE LD.LocalDrivingLicenseApplicationID = @ID) THEN 1 ELSE 0 END", connection))
            { command.Parameters.AddWithValue("@ID", localApplicationID); connection.Open(); return Convert.ToInt32(command.ExecuteScalar()) == 1; }
        }

        public static int IssueFirstLicense(int localApplicationID, int userID, string notes)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(@"SET NOCOUNT ON; SET XACT_ABORT ON; BEGIN TRANSACTION;
DECLARE @ApplicationID int, @PersonID int, @ClassID int, @DriverID int, @LicenseID int;
SELECT @ApplicationID=LD.ApplicationID,@PersonID=A.ApplicantPersonID,@ClassID=LD.LicenseClassID FROM LocalDrivingLicenseApplications LD INNER JOIN Applications A ON A.ApplicationID=LD.ApplicationID WHERE LD.LocalDrivingLicenseApplicationID=@LocalID;
IF @ApplicationID IS NULL OR EXISTS(SELECT 1 FROM Licenses WHERE ApplicationID=@ApplicationID) BEGIN ROLLBACK TRANSACTION; SELECT -1; RETURN; END;
IF NOT EXISTS(SELECT 1 FROM TestAppointments TA INNER JOIN Tests T ON T.TestAppointmentID=TA.TestAppointmentID WHERE TA.LocalDrivingLicenseApplicationID=@LocalID AND T.TestResult=1 GROUP BY TA.LocalDrivingLicenseApplicationID HAVING COUNT(DISTINCT TA.TestTypeID)=3) BEGIN ROLLBACK TRANSACTION; SELECT -1; RETURN; END;
SELECT @DriverID=DriverID FROM Drivers WHERE PersonID=@PersonID;
IF @DriverID IS NULL BEGIN INSERT INTO Drivers(PersonID,CreatedDate,CreatedByUserID) VALUES(@PersonID,GETDATE(),@UserID); SET @DriverID=CONVERT(int,SCOPE_IDENTITY()); END;
INSERT INTO Licenses(ApplicationID,DriverID,LicenseClass,IssueDate,ExpirationDate,IsActive,IssueReason,PaidFees,CreatedByUserID) VALUES(@ApplicationID,@DriverID,@ClassID,GETDATE(),DATEADD(year,10,GETDATE()),1,1,@PaidFees,@UserID);
SET @LicenseID=CONVERT(int,SCOPE_IDENTITY()); UPDATE Applications SET ApplicationStatus=3,LastStatusDate=GETDATE() WHERE ApplicationID=@ApplicationID; COMMIT TRANSACTION; SELECT @LicenseID;", connection))
            { command.Parameters.AddWithValue("@LocalID", localApplicationID); command.Parameters.AddWithValue("@UserID", userID); command.Parameters.AddWithValue("@PaidFees", 20m); connection.Open(); return Convert.ToInt32(command.ExecuteScalar()); }
        }

        public static DataTable GetLicenseInfo(int licenseID)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(@"SELECT TOP 1 L.LicenseID,L.DriverID,L.LicenseClass,LC.ClassName,P.NationalNo,P.FirstName+' '+P.SecondName+' '+P.ThirdName+' '+P.LastName AS FullName,P.DateOfBirth,P.Gendor,P.ImagePath,L.IssueDate,L.ExpirationDate,L.IsActive,L.IssueReason,'No Notes' AS Notes,CASE WHEN EXISTS (SELECT 1 FROM DetainedLicenses DL WHERE DL.LicenseID=L.LicenseID AND DL.IsReleased=0) THEN 1 ELSE 0 END AS IsDetained FROM Licenses L INNER JOIN Drivers D ON D.DriverID=L.DriverID INNER JOIN People P ON P.PersonID=D.PersonID INNER JOIN LicenseClasses LC ON LC.LicenseClassID=L.LicenseClass WHERE L.LicenseID=@ID", connection))
            { command.Parameters.AddWithValue("@ID", licenseID); connection.Open(); using (SqlDataReader reader = command.ExecuteReader()) table.Load(reader); }
            return table;
        }
    }
}
