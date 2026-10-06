using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsTestTypes
    {
        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }

        private clsTestTypes(
            int TestTypeID,
            string TestTypeTitle,
            string TestTypeDescription,
            decimal TestTypeFees)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;
        }

        public static DataTable ListAllTestTypes()
        {
            return clsTestTypesData.ListAllTestTypes();
        }

        public static clsTestTypes Find(int TestTypeID)
        {
            string TestTypeTitle = "";
            string TestTypeDescription = "";
            decimal TestTypeFees = 0;

            bool isFound = clsTestTypesData.FindTestTypeByID(
                TestTypeID,
                ref TestTypeTitle,
                ref TestTypeDescription,
                ref TestTypeFees);

            if (isFound)
            {
                return new clsTestTypes(
                    TestTypeID,
                    TestTypeTitle,
                    TestTypeDescription,
                    TestTypeFees);
            }

            return null;
        }

        public static bool UpdateTestType(
            int TestTypeID,
            string TestTypeTitle,
            string TestTypeDescription,
            decimal TestTypeFees)
        {
            return clsTestTypesData.UpdateTestType(
                TestTypeID,
                TestTypeTitle,
                TestTypeDescription,
                TestTypeFees);
        }
    }
}
