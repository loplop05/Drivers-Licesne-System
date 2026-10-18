using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public static class clsDrivers
    {
        public static DataTable GetDrivers(string filter, string value) => clsDriversData.GetDrivers(filter, value);
    }
}
