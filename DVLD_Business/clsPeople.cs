using DVLD_DataAccess;
using System;
using System.Data;
using System.IO;
namespace DVLD_Business
{
    public class clsPeople
    {
        public enum enMode
        {
            AddNew = 0,
            Update = 1
        }

        public enMode Mode { get; set; }

        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }
        private string selectedSourceFilePath = "";

        // CONSTRUCTOR FOR ADD NEW PERSON
        public clsPeople()
        {
            PersonID = -1;
            NationalNo = "";
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            DateOfBirth = DateTime.Now;
            Gendor = "";
            Address = "";
            Phone = "";
            Email = "";
            NationalityCountryID = -1;
            ImagePath = "";

            Mode = enMode.AddNew;
        }


        // CONSTRUCTOR FOR EXISTING PERSON
        private clsPeople(
            int PersonID,
            string NationalNo,
            string FirstName,
            string SecondName,
            string ThirdName,
            string LastName,
            DateTime DateOfBirth,
            string Gendor,
            string Address,
            string Phone,
            string Email,
            int NationalityCountryID,
            string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;

            Mode = enMode.Update;
        }


        
        public static clsPeople Find(int PersonID)
        {
            string NationalNo = "";
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            string Gendor = "";
            string Address = "";
            string Phone = "";
            string Email = "";
            int NationalityCountryID = -1;
            string ImagePath = "";

            bool IsFound = clsPeopleData.GetPersonByID(
                PersonID,
                ref NationalNo,
                ref FirstName,
                ref SecondName,
                ref ThirdName,
                ref LastName,
                ref DateOfBirth,
                ref Gendor,
                ref Address,
                ref Phone,
                ref Email,
                ref NationalityCountryID,
                ref ImagePath
            );

            if (IsFound)
            {
                return new clsPeople(
                    PersonID,
                    NationalNo,
                    FirstName,
                    SecondName,
                    ThirdName,
                    LastName,
                    DateOfBirth,
                    Gendor,
                    Address,
                    Phone,
                    Email,
                    NationalityCountryID,
                    ImagePath
                );
            }

            return null;
        }



        private bool _AddNewPerson()
        {
            PersonID = clsPeopleData.AddNewPerson(
                NationalNo,
                FirstName,
                SecondName,
                ThirdName,
                LastName,
                DateOfBirth,
                Gendor,
                Address,
                Phone,
                Email,
                NationalityCountryID,
                ImagePath
            );

            return PersonID != -1;
        }



        private bool _UpdatePerson()
        {
            return clsPeopleData.UpdatePerson(
                PersonID,
                NationalNo,
                FirstName,
                SecondName,
                ThirdName,
                LastName,
                DateOfBirth,
                Gendor,
                Address,
                Phone,
                Email,
                NationalityCountryID,
                ImagePath
            );
        }


        public static bool IsPersonExist(string NationalNo)
        {
            return clsPeopleData.IsPersonExist(NationalNo);
        }
 
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }


                    return false;


                case enMode.Update:

                    return _UpdatePerson();
            }

            return false;
        }

        public static DataTable ListAllPeople()
        {
            return clsPeopleData.ListAllPeople();
        }





        public static DataTable GetPeopleByFilter(string ColumnName, string Value)
        {
            return clsPeopleData.GetPeopleByFilter(ColumnName, Value);
        }

        public bool AddNewPerson()
        {
            if (_AddNewPerson())
            {
                Mode = enMode.Update;
                return true;
            }

            return false;
        }

        public bool UpdatePerson()
        {
            return _UpdatePerson();
        }






    }
}