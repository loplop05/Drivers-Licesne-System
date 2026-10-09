using DVLD_DataAccess;
using System.Data;

namespace DVLD_Business
{
    public class clsLicenseClasses
    {
        public static DataTable ListAllLicenseClasses()
        {
            return clsLicenseClassesData.ListAllLicenseClasses();
        }
    }
}
