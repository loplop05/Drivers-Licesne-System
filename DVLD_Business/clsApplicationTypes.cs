using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsApplicationTypes
    {
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationFees { get; set; }

        private clsApplicationTypes(
            int ApplicationTypeID,
            string ApplicationTypeTitle,
            decimal ApplicationFees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationFees = ApplicationFees;
        }

        public static DataTable ListAllApplicationsTypes()
        {
            return clsApplicationTypesData.ListAllApplicationsTypes();
        }

        public static clsApplicationTypes Find(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = "";
            decimal ApplicationFees = 0;

            bool isFound = clsApplicationTypesData.FindApplicationTypeByID(
                ApplicationTypeID,
                ref ApplicationTypeTitle,
                ref ApplicationFees);

            if (isFound)
            {
                return new clsApplicationTypes(
                    ApplicationTypeID,
                    ApplicationTypeTitle,
                    ApplicationFees);
            }

            return null;
        }

        public static bool UpdateApplicationType(
            int ApplicationTypeID,
            string ApplicationTypeTitle,
            decimal ApplicationFees)
        {
            return clsApplicationTypesData.UpdateApplicationType(
                ApplicationTypeID,
                ApplicationTypeTitle,
                ApplicationFees);
        }












    }
}
