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

            scheduleVisionTestToolStripMenuItem.Enabled = active && applicationID > 0 && !visionPassed;
            scheduleVisionTestToolStripMenuItem1.Enabled = visionPassed && !writtenPassed;
            scheduleVisionTestToolStripMenuItem2.Enabled = writtenPassed;

            
            
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
        }






    }
}
