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
using DVLD.Applications.Local_Driving_License.Written;

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmWrtittenTestAppointment : Form
    {
        private readonly int _localDrivingLicenseApplicationID;
        private readonly int _currentUserID;

        public frmWrtittenTestAppointment(int localDrivingLicenseApplicationID, int currentUserID)
        {
            InitializeComponent();
            
            _localDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            _currentUserID = currentUserID;
            ctrlLocalDrivingLicenseApplicationInfo1.LoadDrivingLicsenseApplicationInfo(
                _localDrivingLicenseApplicationID);
            btnAddWrittenTestAppointment.Enabled = !clsTestAppointments.HasPassedWrittenTest(
                _localDrivingLicenseApplicationID);
            RefreshAppointments();
        }

        private void RefreshAppointments()
        {
            dgvWrittenTestAppointments.DataSource = clsTestAppointments.GetWrittenAppointments(
                _localDrivingLicenseApplicationID);
            dgvWrittenTestAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvWrittenTestAppointments.Columns.Contains("AppointmentDate"))
                dgvWrittenTestAppointments.Columns["AppointmentDate"].DefaultCellStyle.Format = "d";
        }



        private void btnAddWrittenTestAppointment_Click(object sender, EventArgs e)
        {
            using (frmSchedualeWrittenTestAppointment frm = new frmSchedualeWrittenTestAppointment(_localDrivingLicenseApplicationID, _currentUserID))
                frm.ShowDialog(this);
            RefreshAppointments();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgvWrittenTestAppointments.CurrentRow == null)
            {
                MessageBox.Show("Please select an appointment first.");
                return;
            }

            int appointmentID = Convert.ToInt32(
                dgvWrittenTestAppointments.CurrentRow.Cells["TestAppointmentID"].Value);
            bool isLocked = Convert.ToBoolean(
                dgvWrittenTestAppointments.CurrentRow.Cells["IsLocked"].Value);

            if (isLocked)
            {
                MessageBox.Show("A locked appointment cannot be edited.");
                return;
            }

            using (frmSchedualeWrittenTestAppointment vision = new frmSchedualeWrittenTestAppointment(
                _localDrivingLicenseApplicationID, _currentUserID, appointmentID))
                vision.ShowDialog(this);
            RefreshAppointments();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvWrittenTestAppointments.CurrentRow == null) { MessageBox.Show("Please select an appointment first."); return; }
            int appointmentID = Convert.ToInt32(dgvWrittenTestAppointments.CurrentRow.Cells["TestAppointmentID"].Value);
            if (Convert.ToBoolean(dgvWrittenTestAppointments.CurrentRow.Cells["IsLocked"].Value)) { MessageBox.Show("This appointment has already been completed."); return; }
            using (frmTakeWrittenTest test = new frmTakeWrittenTest(_localDrivingLicenseApplicationID, appointmentID, _currentUserID)) test.ShowDialog(this);
            RefreshAppointments();
        }
    }
}
