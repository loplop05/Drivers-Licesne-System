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
using DVLD.GlobalClasses;

namespace DVLD.Users
{
    public partial class frmChangePassword : Form
    {
        private readonly int _userID;

        public frmChangePassword(int userID)
        {
            _userID = userID;
            InitializeComponent();
            ctrlUserDetails1.LoadUser(userID);

            txtCurrentPassword.UseSystemPasswordChar = true;
            txtNewPassowrd.UseSystemPasswordChar = true;
            txtConfirmNewPassword.UseSystemPasswordChar = true;

        }

   

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.ValidateRequiredField(txtCurrentPassword, "current password"))
            {
                return;
            }

            if (!ValidationHelper.ValidateRequiredField(txtNewPassowrd, "new password"))
            {
                return;
            }

            if (!ValidationHelper.ValidateRequiredField(txtConfirmNewPassword, "confirm new password"))
            {
                return;
            }

            if (txtNewPassowrd.Text != txtConfirmNewPassword.Text)
            {
                MessageBox.Show("The new passwords do not match.");
                return;
            }

            if (!clsUsers.ChangePassword(_userID, txtCurrentPassword.Text, txtNewPassowrd.Text))
            {
                MessageBox.Show("The current password is incorrect.");
                return;
            }

            MessageBox.Show("Password changed successfully.");
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();


        }
    }
}
