using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsTestTypesData
    {
        public static bool FindTestTypeByID(
            int TestTypeID,
            ref string TestTypeTitle,
            ref string TestTypeDescription,
            ref decimal TestTypeFees)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(
                "SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID",
                connection))
            {
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            TestTypeTitle = reader["TestTypeTitle"].ToString();
                            TestTypeDescription = reader["TestTypeDescription"].ToString();
                            TestTypeFees = Convert.ToDecimal(reader["TestTypeFees"]);
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Error while Finding Test Type");
                }
            }

            return isFound;
        }

        public static DataTable ListAllTestTypes()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                string query = "SELECT * FROM TestTypes";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Error while Loading Test Types");
                    }
                }
            }

            return dt;
        }

        public static bool UpdateTestType(
            int TestTypeID,
            string TestTypeTitle,
            string TestTypeDescription,
            decimal TestTypeFees)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(@"
                UPDATE TestTypes
                SET TestTypeTitle = @TestTypeTitle,
                    TestTypeDescription = @TestTypeDescription,
                    TestTypeFees = @TestTypeFees
                WHERE TestTypeID = @TestTypeID", connection))
            {
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
                command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
                command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);

                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch
                {
                    Console.WriteLine("Error while Updating Test Type");
                    return false;
                }
            }
        }
    }
}
