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

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmManageLocalDrivingLisenseApplictions : Form
    {
        private clsUsers _currentUser;

        private void _RefreshLocalDrivingLicenseApplicationsList()
        {
            DataTable dt = clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationsByFilter(
                cbFilterBy.Text.Trim(),
                txtFilterValue.Text.Trim()
            );
            dgvLocalDrivingLicsenseApplictions.DataSource = dt;
            dgvLocalDrivingLicsenseApplictions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLocalDrivingLicsenseApplictions.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvLocalDrivingLicsenseApplictions.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
        }

        public frmManageLocalDrivingLisenseApplictions(clsUsers currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            scheduleVisionTestToolStripMenuItem1.Enabled = false;
            scheduleVisionTestToolStripMenuItem2.Enabled = false;

            // Populate filter options
            cbFilterBy.Items.Add("None");
            cbFilterBy.Items.Add("L.D.L.AppID");
            cbFilterBy.Items.Add("National No");
            cbFilterBy.Items.Add("Full Name");
            cbFilterBy.Items.Add("Driving Class");
            cbFilterBy.Items.Add("Status");
            cbFilterBy.SelectedIndex = 0;

            _RefreshLocalDrivingLicenseApplicationsList();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Clear();
            _RefreshLocalDrivingLicenseApplicationsList();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _RefreshLocalDrivingLicenseApplicationsList();
        }

        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicsenseApplication newApplication = new frmNewLocalDrivingLicsenseApplication(_currentUser);
            newApplication.ShowDialog();
            _RefreshLocalDrivingLicenseApplicationsList();
        }

        private int GetSelectedApplicationID()
        {
            if (dgvLocalDrivingLicsenseApplictions.CurrentRow == null)
                return -1;

            return Convert.ToInt32(dgvLocalDrivingLicsenseApplictions.CurrentRow.Cells["L.D.L.AppID"].Value);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSelectedApplicationDetails();
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSelectedApplicationDetails();
        }

        private void ShowSelectedApplicationDetails()
        {
            if (dgvLocalDrivingLicsenseApplictions.CurrentRow == null)
            {
                MessageBox.Show("Please select an application first.");
                return;
            }

            int applicationID = GetSelectedApplicationID();
            if (applicationID == -1)
                return;

            if (clsLocalDrivingLicenseApplications.Find(applicationID) == null)
            {
                MessageBox.Show("Application not found.");
                return;
            }

            using (frmLocalDrivingLicsenseApplicationDetails details =
                new frmLocalDrivingLicsenseApplicationDetails(applicationID))
            {
                details.ShowDialog(this);
            }
        }

        private void addNewApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddNewApplication_Click(sender, e);
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvLocalDrivingLicsenseApplictions.ClearSelection();
                dgvLocalDrivingLicsenseApplictions.Rows[e.RowIndex].Selected = true;
                dgvLocalDrivingLicsenseApplictions.CurrentCell = dgvLocalDrivingLicsenseApplictions.Rows[e.RowIndex].Cells[e.ColumnIndex];
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLocalDrivingLicsenseApplictions.CurrentRow == null)
            {
                MessageBox.Show("Please select an application first.");
                return;
            }

            int applicationID = GetSelectedApplicationID();
            string status = dgvLocalDrivingLicsenseApplictions.CurrentRow.Cells["Status"].Value.ToString();
            if (status == "Cancelled")
            {
                MessageBox.Show("This application was cancelled. The applicant must submit a new application.");
                return;
            }
            if (status == "Completed")
            {
                MessageBox.Show("This application is completed and cannot schedule tests.");
                return;
            }
            if (applicationID == -1 || clsLocalDrivingLicenseApplications.Find(applicationID) == null)
            {
                MessageBox.Show("Application not found.");
                return;
            }

           frmVisionTestAppointment  frm = new frmVisionTestAppointment(applicationID, _currentUser.UserID);
            frm.ShowDialog(this);
        }




        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int applicationID = GetSelectedApplicationID();
            string status = dgvLocalDrivingLicsenseApplictions.CurrentRow == null ? "" :
                dgvLocalDrivingLicsenseApplictions.CurrentRow.Cells["Status"].Value.ToString();
            bool active = status == "New";
            bool visionPassed = active && applicationID > 0 && clsTestAppointments.HasPassedVisionTest(applicationID);
            bool writtenPassed = visionPassed && clsTestAppointments.HasPassedWrittenTest(applicationID);
            bool streetPassed = writtenPassed && clsTestAppointments.HasPassedStreetTest(applicationID);
            bool hasLicense = applicationID > 0 && clsLicenses.GetLicenseIDByLocalApplicationID(applicationID) > 0;

            scheduleVisionTestToolStripMenuItem.Enabled = active && applicationID > 0 && !visionPassed;
            scheduleVisionTestToolStripMenuItem1.Enabled = visionPassed && !writtenPassed;
            scheduleVisionTestToolStripMenuItem2.Enabled = writtenPassed && !streetPassed;
            issueDrivingLicenseToolStripMenuItem.Enabled = active && streetPassed;
            showLicenseToolStripMenuItem.Enabled = hasLicense;

            
            
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!scheduleVisionTestToolStripMenuItem1.Enabled)
                return;

            using (frmWrtittenTestAppointment  frm =
                new frmWrtittenTestAppointment(GetSelectedApplicationID(), _currentUser.UserID))
            {
                frm.ShowDialog(this);
            }
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!scheduleVisionTestToolStripMenuItem2.Enabled)
                return;

            using (frmStreetTestAppointment frm =
                new frmStreetTestAppointment(GetSelectedApplicationID(), _currentUser.UserID))
            {
                frm.ShowDialog(this);
            }


        }

        private void issueDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int applicationID = GetSelectedApplicationID();
            if (applicationID <= 0 || !clsLicenses.CanIssueFirstLicense(applicationID))
            {
                MessageBox.Show("The applicant must pass all three tests before the license can be issued.", "Cannot Issue License", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (frmIssueDrivingLicense issue = new frmIssueDrivingLicense(applicationID, _currentUser.UserID))
            {
                if (issue.ShowDialog(this) == DialogResult.OK)
                {
                    _RefreshLocalDrivingLicenseApplicationsList();
                    using (frmLicenseInfo info = new frmLicenseInfo(issue.IssuedLicenseID)) info.ShowDialog(this);
                }
            }
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int applicationID = GetSelectedApplicationID();
            int licenseID = clsLicenses.GetLicenseIDByLocalApplicationID(applicationID);
            if (licenseID <= 0)
            {
                MessageBox.Show("This application does not have an issued license yet.", "License Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (frmLicenseInfo info = new frmLicenseInfo(licenseID)) info.ShowDialog(this);
        }






    }
}
