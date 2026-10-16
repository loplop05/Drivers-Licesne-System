using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public static class clsTestAppointmentsData
    {
        public static int AddTestAppointment(int testTypeID, int localApplicationID, DateTime appointmentDate, decimal paidFees, int createdByUserID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(@"INSERT INTO TestAppointments (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked) VALUES (@TestTypeID, @LocalApplicationID, @AppointmentDate, @PaidFees, @CreatedByUserID, 0); SELECT CAST(SCOPE_IDENTITY() AS int);", connection))
            {
                command.Parameters.AddWithValue("@TestTypeID", testTypeID);
                command.Parameters.AddWithValue("@LocalApplicationID", localApplicationID);
                command.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
                command.Parameters.AddWithValue("@PaidFees", paidFees);
                command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
                connection.Open();
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public static bool DoesActiveAppointmentExist(int testTypeID, int localApplicationID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand("SELECT COUNT(1) FROM TestAppointments WHERE TestTypeID = @TestTypeID AND LocalDrivingLicenseApplicationID = @LocalApplicationID AND IsLocked = 0", connection))
            {
                command.Parameters.AddWithValue("@TestTypeID", testTypeID);
                command.Parameters.AddWithValue("@LocalApplicationID", localApplicationID);
                connection.Open();
                return Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
        }

        public static bool HasPassedTest(int testTypeID, int localApplicationID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(@"SELECT COUNT(1)
                FROM TestAppointments TA INNER JOIN Tests T ON TA.TestAppointmentID = T.TestAppointmentID
                WHERE TA.TestTypeID = @TestTypeID
                  AND TA.LocalDrivingLicenseApplicationID = @LocalApplicationID
                  AND T.TestResult = 1", connection))
            {
                command.Parameters.AddWithValue("@TestTypeID", testTypeID);
                command.Parameters.AddWithValue("@LocalApplicationID", localApplicationID);
                connection.Open();
                return Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
        }

        public static DataTable GetAppointments(int testTypeID, int localApplicationID)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand("SELECT TA.TestAppointmentID, TA.AppointmentDate, TA.PaidFees, TA.IsLocked, U.Username AS CreatedBy FROM TestAppointments TA INNER JOIN Users U ON TA.CreatedByUserID = U.UserID WHERE TA.TestTypeID = @TestTypeID AND TA.LocalDrivingLicenseApplicationID = @LocalApplicationID ORDER BY TA.AppointmentDate DESC", connection))
            {
                command.Parameters.AddWithValue("@TestTypeID", testTypeID);
                command.Parameters.AddWithValue("@LocalApplicationID", localApplicationID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader()) table.Load(reader);
            }
            return table;
        }

        public static bool UpdateAppointmentDate(int appointmentID, DateTime appointmentDate)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand("UPDATE TestAppointments SET AppointmentDate = @AppointmentDate WHERE TestAppointmentID = @AppointmentID AND IsLocked = 0", connection))
            {
                command.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
                command.Parameters.AddWithValue("@AppointmentID", appointmentID);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public static bool CompleteAppointment(int appointmentID, bool result, string notes, int createdByUserID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(@"BEGIN TRANSACTION;
                INSERT INTO Tests (TestAppointmentID, TestResult, Notes, CreatedByUserID)
                VALUES (@ID, @Result, @Notes, @CreatedByUserID);
                UPDATE TestAppointments SET IsLocked = 1 WHERE TestAppointmentID = @ID;
                COMMIT TRANSACTION;", connection))
            {
                command.Parameters.AddWithValue("@ID", appointmentID);
                command.Parameters.AddWithValue("@Result", result);
                command.Parameters.AddWithValue("@Notes", notes ?? string.Empty);
                command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
