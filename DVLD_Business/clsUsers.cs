using DVLD_DataAccess;
using System;
using System.Data;

namespace DVLD_Business
{
    public class clsUsers
    {
        public enum enMode
        {
            AddNew = 0,
            Update = 1
        }

        public enMode Mode { get; set; }

        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        // CONSTRUCTOR FOR ADD NEW USER
        public clsUsers()
        {
            UserID = -1;
            PersonID = -1;
            Username = "";
            Password = "";
            IsActive = true;

            Mode = enMode.AddNew;
        }

        // CONSTRUCTOR FOR EXISTING USER
        private clsUsers(
            int UserID,
            int PersonID,
            string Username,
            string Password,
            bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.Username = Username;
            this.Password = Password;
            this.IsActive = IsActive;

            Mode = enMode.Update;
        }

        // FIND USER BY USERNAME AND PASSWORD
        public static clsUsers FindByCredentials(string Username, string Password)
        {
            int UserID = -1;
            int PersonID = -1;
            bool IsActive = false;

            bool IsFound = clsUsersData.FindUserByCredentials(
                Username,
                Password,
                ref UserID,
                ref PersonID,
                ref IsActive
            );

            if (IsFound)
            {
                return new clsUsers(
                    UserID,
                    PersonID,
                    Username,
                    Password,
                    IsActive
                );
            }

            return null;
        }

        // CHECK IF USER EXISTS
        public static bool IsUserExist(string Username)
        {
            return clsUsersData.IsUserExist(Username);
        }

        // STATIC LOGIN METHOD
        public static clsUsers Login(string Username, string Password)
        {
            return FindByCredentials(Username, Password);
        }


        public static DataTable GetAllUsers()
        {
            return clsUsersData.GetAllUsers();
        }

        // GET USERS BY FILTER
        public static DataTable GetUsersByFilter(string ColumnName, string Value)
        {
            return clsUsersData.GetUsersByFilter(ColumnName, Value);
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUsersData.DeleteUser(UserID);
        }

        public static bool ChangePassword(int UserID, string CurrentPassword, string NewPassword)
        {
            return clsUsersData.ChangePassword(UserID, CurrentPassword, NewPassword);
        }

        // ADD NEW USER
        public static int AddNewUser(int PersonID, string Username, string Password, bool IsActive)
        {
            // Step 1: Validate that the person exists
            clsPeople person = clsPeople.Find(PersonID);
            if (person == null)
            {
                return -1; // Person not found, cannot create user
            }

            // Step 2: Call DAL to insert user with PersonID connection
            int UserID = clsUsersData.AddNewUser(
                PersonID,
                Username,
                Password,
                IsActive
            );

            return UserID; // Returns the generated UserID or -1 on failure
        }









    }
}
