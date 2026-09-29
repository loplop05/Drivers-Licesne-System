using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsUsersData
    {
        public static bool FindUserByCredentials(
            string Username,
            string Password,
            ref int UserID,
            ref int PersonID,
            ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"
                SELECT *
                FROM Users
                WHERE Username = @Username AND Password = @Password AND IsActive = 1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    IsActive = (bool)reader["IsActive"];
                }
                else
                {
                    // No matching user found
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                // Log error but don't show UI in DAL layer
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        // CHECK IF USER EXISTS BY USERNAME
        public static bool IsUserExist(string Username)
        {
            bool isFound = false;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"
                SELECT 1
                FROM Users
                WHERE Username = @Username";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", Username);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        // GET ALL USERS
        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                string query = "SELECT * FROM Users";

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

        // GET USERS BY FILTER
        public static DataTable GetUsersByFilter(string ColumnName, string Value)
        {
            DataTable dt = new DataTable();

            string query = "SELECT * FROM Users";

            switch (ColumnName)
            {
                case "UserID":
                    query += " WHERE UserID LIKE '%' + @Value + '%'";
                    break;

                case "PersonID":
                    query += " WHERE PersonID LIKE '%' + @Value + '%'";
                    break;

                case "Username":
                    query += " WHERE Username LIKE '%' + @Value + '%'";
                    break;

                case "IsActive":
                    query += " WHERE IsActive = @Value";
                    break;

                case "None":
                    break;

                default:
                    return dt;
            }

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (ColumnName != "None")
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

        public static bool DeleteUser(int UserID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(
                "DELETE FROM Users WHERE UserID = @UserID", connection))
            {
                command.Parameters.AddWithValue("@UserID", UserID);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public static bool ChangePassword(int UserID, string CurrentPassword, string NewPassword)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(@"
                UPDATE Users
                SET Password = @NewPassword
                WHERE UserID = @UserID AND Password = @CurrentPassword", connection))
            {
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@CurrentPassword", CurrentPassword);
                command.Parameters.AddWithValue("@NewPassword", NewPassword);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }


        // ADD NEW USER
        public static int AddNewUser(
            int PersonID,
            string Username,
            string Password,
            bool IsActive)
        {
            int UserID = -1;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"
            INSERT INTO Users
            (
            PersonID,
            UserName,
            Password,
            IsActive
        )
        VALUES
        (
            @PersonID,
            @Username,
            @Password,
            @IsActive
        );

        SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    UserID = Convert.ToInt32(result);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return UserID;
        }




    }
}
