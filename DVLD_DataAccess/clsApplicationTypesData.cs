using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsApplicationTypesData
    {
        public static bool FindApplicationTypeByID(
            int ApplicationTypeID,
            ref string ApplicationTypeTitle,
            ref decimal ApplicationFees)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(
                "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID",
                connection))
            {
                command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            ApplicationTypeTitle = reader["ApplicationTypeTitle"].ToString();
                            ApplicationFees = Convert.ToDecimal(reader["ApplicationFees"]);
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Error while Finding Application Type");
                }
            }

            return isFound;
        }

        public static DataTable ListAllApplicationsTypes()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                string query = "select * from ApplicationTypes ";

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
                        Console.WriteLine("Error while Loading Application Types");
                    }
                }
            }

            return dt;
        }

        public static bool UpdateApplicationType(
            int ApplicationTypeID,
            string ApplicationTypeTitle,
            decimal ApplicationFees)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(@"
                UPDATE ApplicationTypes
                SET ApplicationTypeTitle = @ApplicationTypeTitle,
                    ApplicationFees = @ApplicationFees
                WHERE ApplicationTypeID = @ApplicationTypeID", connection))
            {
                command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
                command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);

                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch
                {
                    Console.WriteLine("Error while Updating Application Type");
                    return false;
                }
            }
        }








    }
}
