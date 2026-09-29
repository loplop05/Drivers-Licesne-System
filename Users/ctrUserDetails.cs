using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD.Users
{
    [ToolboxItem(true)]
    public partial class ctrlUserDetails : UserControl
    {
        public ctrlUserDetails()
        {
            InitializeComponent();
        }

        public void LoadUser(int userID)
        {
            DataTable users = clsUsers.GetUsersByFilter("UserID", userID.ToString());
            if (users.Rows.Count == 0)
                throw new InvalidOperationException("User not found.");

            DataRow user = users.Rows[0];
            int personID = Convert.ToInt32(user["PersonID"]);

            ctrlLoginInfo1.LoadUser(
                Convert.ToInt32(user["UserID"]),
                Convert.ToString(user["Username"]),
                Convert.ToBoolean(user["IsActive"])
            );

            ctrlPersonDetails1.LoadPerson(personID);
        }
    }
}
