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

            Button save = new Button { Text = "Save", Width = 90, Left = 850, Top = 650 };
            Button cancel = new Button { Text = "Cancel", Width = 90, Left = 950, Top = 650 };
            save.Click += Save_Click;
            cancel.Click += (sender, e) => Close();
            Controls.Add(save);
            Controls.Add(cancel);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text) ||
                string.IsNullOrWhiteSpace(txtNewPassowrd.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmNewPassword.Text))
            {
                MessageBox.Show("Please fill in all password fields.");
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
            Close();
        }
    }
}
