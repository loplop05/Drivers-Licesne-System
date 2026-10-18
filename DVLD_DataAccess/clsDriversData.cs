using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public static class clsDriversData
    {
        public static DataTable GetDrivers(string filter, string value)
        {
            DataTable table = new DataTable();
            string where = string.Empty;
            switch (filter)
            {
                case "Driver ID": where = " WHERE D.DriverID LIKE '%' + @Value + '%'"; break;
                case "Person ID": where = " WHERE D.PersonID LIKE '%' + @Value + '%'"; break;
                case "National No.": where = " WHERE P.NationalNo LIKE '%' + @Value + '%'"; break;
                case "Full Name": where = " WHERE (P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName) LIKE '%' + @Value + '%'"; break;
            }
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(@"SELECT D.DriverID AS [Driver ID], D.PersonID AS [Person ID], P.NationalNo AS [National No.], P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName AS [Full Name], D.CreatedDate AS [Date], COUNT(L.LicenseID) AS [Active Licenses] FROM Drivers D INNER JOIN People P ON P.PersonID = D.PersonID LEFT JOIN Licenses L ON L.DriverID = D.DriverID AND L.IsActive = 1" + where + " GROUP BY D.DriverID,D.PersonID,P.NationalNo,P.FirstName,P.SecondName,P.ThirdName,P.LastName,D.CreatedDate ORDER BY D.DriverID", connection))
            {
                if (!string.IsNullOrEmpty(where)) command.Parameters.AddWithValue("@Value", value ?? string.Empty);
                connection.Open(); using (SqlDataReader reader = command.ExecuteReader()) table.Load(reader);
            }
            return table;
        }
    }
}
