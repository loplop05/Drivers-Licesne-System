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
    public partial class frmVisionTestAppointment : Form
    {
        private readonly int _localDrivingLicenseApplicationID;
        private readonly int _currentUserID;

        public frmVisionTestAppointment(int localDrivingLicenseApplicationID, int currentUserID)
        {
            InitializeComponent();
            _localDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            _currentUserID = currentUserID;
            ctrlLocalDrivingLicenseApplicationInfo1.LoadDrivingLicsenseApplicationInfo(
                _localDrivingLicenseApplicationID);
            RefreshAppointments();
        }

        private void RefreshAppointments()
        {
            dgvVisionTestAppointments.DataSource = clsTestAppointments.GetVisionAppointments(
                _localDrivingLicenseApplicationID);
            dgvVisionTestAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvVisionTestAppointments.Columns.Contains("AppointmentDate"))
                dgvVisionTestAppointments.Columns["AppointmentDate"].DefaultCellStyle.Format = "d";
        }

        private void btnAddVisionTestAppointment_Click(object sender, EventArgs e)
        {
            using (frmSchedualeVisionTestAppointment vision = new frmSchedualeVisionTestAppointment(_localDrivingLicenseApplicationID, _currentUserID))
                vision.ShowDialog(this);
            RefreshAppointments();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvVisionTestAppointments.CurrentRow == null)
            {
                MessageBox.Show("Please select an appointment first.");
                return;
            }

            int appointmentID = Convert.ToInt32(
                dgvVisionTestAppointments.CurrentRow.Cells["TestAppointmentID"].Value);
            bool isLocked = Convert.ToBoolean(
                dgvVisionTestAppointments.CurrentRow.Cells["IsLocked"].Value);

            if (isLocked)
            {
                MessageBox.Show("A locked appointment cannot be edited.");
                return;
            }

            using (frmSchedualeVisionTestAppointment vision = new frmSchedualeVisionTestAppointment(
                _localDrivingLicenseApplicationID, _currentUserID, appointmentID))
                vision.ShowDialog(this);
            RefreshAppointments();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvVisionTestAppointments.CurrentRow == null) { MessageBox.Show("Please select an appointment first."); return; }
            int appointmentID = Convert.ToInt32(dgvVisionTestAppointments.CurrentRow.Cells["TestAppointmentID"].Value);
            if (Convert.ToBoolean(dgvVisionTestAppointments.CurrentRow.Cells["IsLocked"].Value)) { MessageBox.Show("This appointment has already been completed."); return; }
            using (frmTakeVisionTest test = new frmTakeVisionTest(_localDrivingLicenseApplicationID, appointmentID, _currentUserID)) test.ShowDialog(this);
            RefreshAppointments();
        }
    }
}
