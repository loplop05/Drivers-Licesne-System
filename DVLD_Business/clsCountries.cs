using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsCountries
    {


        public static DataTable ListAllCountries()
        {
            return clsCountriesData.ListAllCountries();
        }













    }
}
