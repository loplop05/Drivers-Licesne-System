using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsCountriesData
    {

        public static DataTable ListAllCountries()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                string query = "SELECT CountryID, CountryName FROM Countries ORDER BY CountryName";

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
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error while Loading Countries");
                    }
                }
            }

            return dt;
        }

        public static bool GetCountryByID(int CountryID, ref string CountryName)
        {
            bool IsFound = false;

            using (SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.connectionString))
            {
                string query = @"SELECT CountryName
                                 FROM Countries
                                 WHERE CountryID = @CountryID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CountryID", CountryID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                CountryName = (string)reader["CountryName"];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception according to your project
                    }
                }
            }

            return IsFound;
        }










    }
}
