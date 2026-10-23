using DVLD.Applications.Applications_Types;
using DVLD.Applications.International_License;
using DVLD.Applications.Local_Driving_License;
using DVLD.Applications.ReplaceLostOrDamagedLicense;
using DVLD.Applications.ReleaseDetainedLicense;
using DVLD.Applications.Renew_Driving_License;
using DVLD.Drivers;
using DVLD.Licenses.DetainLicense;
using DVLD.People;
using DVLD.Tests.Test_Types;
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

            pnlContent.Resize += pnlContent_Resize;
        }







        // Helper method to switch forms
        private void SwitchToForm(Form newForm)
        {
            if (newForm == null)
            {
                return;
            }

            if (_currentForm != null && !_currentForm.IsDisposed)
            {
                _currentForm.Close();
                _currentForm.Dispose();
            }

            pnlContent.Controls.Clear();
            pnlContent.AutoScroll = true;

            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.WindowState = FormWindowState.Normal;
            newForm.StartPosition = FormStartPosition.Manual;
            newForm.Dock = DockStyle.None;

            _currentForm = newForm;
            pnlContent.Controls.Add(newForm);
            newForm.Show();
            CenterCurrentForm();
            newForm.BringToFront();
        }

        private void pnlContent_Resize(object sender, EventArgs e)
        {
            CenterCurrentForm();
        }

        private void CenterCurrentForm()
        {
            if (_currentForm == null || _currentForm.IsDisposed)
            {
                return;
            }

            int left = Math.Max(0, (pnlContent.ClientSize.Width - _currentForm.Width) / 2);
            int top = Math.Max(0, (pnlContent.ClientSize.Height - _currentForm.Height) / 2);

            _currentForm.Location = new Point(left, top);
        }

        private void btnPeople_Click(object sender, EventArgs e)
        {
            SwitchToForm(new frmPeopleManagement());
        }


        private void MSPeople_Click(object sender, EventArgs e)
        {
            SwitchToForm(new frmPeopleManagement());
        }






       /*
        * 
        * 
        * ACCOUNT SETTINGS + USER 
        * 
        */

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


        /*
     * 
     * 
     * APPLICATION TYPES 
     * 
     */




        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SwitchToForm(new frmManageApplicationTypes());

        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchToForm(new frmManageTestTypes());
        }

        private void localLicsenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchToForm(new frmNewLocalDrivingLicsenseApplication(_currentUser));
        }

        private void manageLocalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchToForm(new frmManageLocalDrivingLisenseApplictions(_currentUser));
        }

        private void localDrivingLicsenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchToForm(new frmManageLocalDrivingLisenseApplictions(_currentUser));
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SwitchToForm(new frmManageDrivers());
        }

        private void internationalLicsenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchToForm(new frmNewInternationalLicsense(_currentUser));
        }

        private void internationalLicsenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchToForm(new frmManageInternationalLicenseApplications(_currentUser));
        }

        private void renewDrivingLicsenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchToForm(new frmReenewLocalDrivingLicense(_currentUser));
        }

        private void replaceForLostOrDamagedLicsenseToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            SwitchToForm(new frmReplaceLostOrDamagedLicense(_currentUser));
        }

        private void manageDetainedLicsenseToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            SwitchToForm(new frmManageDetainedLicenses());
        }

        private void detainLicsenseToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            SwitchToForm(new frmDetainLicense(_currentUser));
        }

        private void releaseDetainedLicsenseToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            SwitchToForm(new frmReleaseDetainedLicense(_currentUser));
        }

        private void releaseDetainedDrivingLicsenseToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            SwitchToForm(new frmReleaseDetainedLicense(_currentUser));
        }






    }
}
