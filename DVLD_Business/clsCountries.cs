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
        public int CountryID { get; set; }
        public string CountryName { get; set; }


        private clsCountries(int CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }




        public static DataTable ListAllCountries()
        {
            return clsCountriesData.ListAllCountries();
        }



        public static clsCountries Find(int CountryID)
        {
            string CountryName = "";

            bool IsFound = clsCountriesData.GetCountryByID(
                CountryID,
                ref CountryName
            );

            if (IsFound)
            {
                return new clsCountries(
                    CountryID,
                    CountryName
                );
            }

            return null;
        }









    }
}
