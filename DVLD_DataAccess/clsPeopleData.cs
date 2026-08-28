using System;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    internal class clsPeopleData
    {
        // GET PERSON BY ID
        public static bool GetPersonByID(
            int PersonID,
            ref string NationalNo,
            ref string FirstName,
            ref string SecondName,
            ref string ThirdName,
            ref string LastName,
            ref DateTime DateOfBirth,
            ref string Gendor,
            ref string Address,
            ref string Phone,
            ref string Email,
            ref int NationalityCountryID,
            ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"
                SELECT *
                FROM PEOPLE
                WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = (string)reader["ThirdName"];
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (string)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    Email = (string)reader["Email"];
                    NationalityCountryID =
                        (int)reader["NationalityCountryID"];

                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }
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


        // ADD NEW PERSON
        public static int AddNewPerson( string NationalNo,string FirstName,string SecondName,
            string ThirdName, string LastName, DateTime DateOfBirth, string Gendor, string Address,string Phone,
            string Email, int NationalityCountryID, string ImagePath)
        {
            int PersonID = -1;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"
                INSERT INTO PEOPLE
                (
                    NationalNo,
                    FirstName,
                    SecondName,
                    ThirdName,
                    LastName,
                    DateOfBirth,
                    Gendor,
                    Address,
                    Phone,
                    Email,
                    NationalityCountryID,
                    ImagePath
                )
                VALUES
                (
                    @NationalNo,
                    @FirstName,
                    @SecondName,
                    @ThirdName,
                    @LastName,
                    @DateOfBirth,
                    @Gendor,
                    @Address,
                    @Phone,
                    @Email,
                    @NationalityCountryID,
                    @ImagePath
                );

                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue(
                "@NationalityCountryID",
                NationalityCountryID
            );

            if (ImagePath != null)
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                command.Parameters.AddWithValue(
                    "@ImagePath",
                    DBNull.Value
                );
            }

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null &&
                    int.TryParse(result.ToString(), out int insertedID))
                {
                    PersonID = insertedID;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }

            return PersonID;
        }



 
// UPDATE PERSON
            public static bool UpdatePerson(
                int PersonID,
                string NationalNo,
                string FirstName,
                string SecondName,
                string ThirdName,
                string LastName,
                DateTime DateOfBirth,
                string Gendor,
                string Address,
                string Phone,
                string Email,
                int NationalityCountryID,
                string ImagePath)
        {
            int rowsAffected = 0;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"
        UPDATE PEOPLE
        SET
            NationalNo = @NationalNo,
            FirstName = @FirstName,
            SecondName = @SecondName,
            ThirdName = @ThirdName,
            LastName = @LastName,
            DateOfBirth = @DateOfBirth,
            Gendor = @Gendor,
            Address = @Address,
            Phone = @Phone,
            Email = @Email,
            NationalityCountryID = @NationalityCountryID,
            ImagePath = @ImagePath
        WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue(
                "@NationalityCountryID",
                NationalityCountryID
            );

            if (ImagePath != null)
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            }

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





        // CHECK IF PERSON EXISTS BY NATIONAL NO
        public static bool IsPersonExist(string NationalNo)
        {
            bool isFound = false;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"
        SELECT 1
        FROM PEOPLE
        WHERE NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

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










    }
}