using DVLD.People;
using DVLD.Users;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmMain : System.Windows.Forms.Form
    {
        private Form _currentForm;

        private clsUsers _currentUser;


        public frmMain(clsUsers currentUser)
        {

            _currentUser = currentUser;

            InitializeComponent();
        }







        // Helper method to switch forms
        private void SwitchToForm(Form newForm)
        {
            // Close and dispose current form if exists
            if (_currentForm != null)
            {
                _currentForm.Close();
                _currentForm.Dispose();
            }

            // Clear panel
            pnlContent.Controls.Clear();

            // Setup new form
            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;

            // Add to panel
            pnlContent.Controls.Add(newForm);
            _currentForm = newForm;
            newForm.Show();
        }

        private void btnPeople_Click(object sender, EventArgs e)
        {
            SwitchToForm(new frmPeopleManagement());
        }


        private void MSPeople_Click(object sender, EventArgs e)
        {
            SwitchToForm(new frmPeopleManagement());
        }

        private void MsUsers_Click(object sender, EventArgs e)
        {
            SwitchToForm(new frmManageUsers());
        }




        private void currentUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
                SwitchToForm(new frmUserDetails(_currentUser.UserID));

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchToForm(new frmChangePassword(_currentUser.UserID));
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to sign out?",
                "Sign Out",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            if (_currentForm != null)
            {
                _currentForm.Close();
                _currentForm.Dispose();
                _currentForm = null;
            }

            
            _currentUser = null;
            Close();
        }








    }
}
