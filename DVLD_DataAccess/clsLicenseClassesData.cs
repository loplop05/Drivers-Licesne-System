using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsLicenseClassesData
    {
        public static DataTable ListAllLicenseClasses()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(
                "SELECT LicenseClassID, ClassName FROM LicenseClasses ORDER BY LicenseClassID",
                connection))
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
                    Console.WriteLine("Error while Loading License Classes");
                }
            }

            return dt;
        }
    }
}
