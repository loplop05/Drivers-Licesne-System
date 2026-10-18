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

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmStreetTestAppointment : Form
    {
        private readonly int _localDrivingLicenseApplicationID;
        private readonly int _currentUserID;

        public frmStreetTestAppointment(int localDrivingLicenseApplicationID, int currentUserID)
        {
            InitializeComponent();
            _localDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            _currentUserID = currentUserID;
            ctrlLocalDrivingLicenseApplicationInfo1.LoadDrivingLicsenseApplicationInfo(localDrivingLicenseApplicationID);
            btnAddStreetTestAppointment.Click += btnAddStreetTestAppointment_Click;
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            takeTestToolStripMenuItem.Click += takeTestToolStripMenuItem_Click;
            RefreshAppointments();
        }

        private void RefreshAppointments() { dgvStreetTestAppointments.DataSource = clsTestAppointments.GetStreetAppointments(_localDrivingLicenseApplicationID); dgvStreetTestAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; }
        private void btnAddStreetTestAppointment_Click(object sender, EventArgs e) { using (var f = new frmScheduleStreetTestAppointment(_localDrivingLicenseApplicationID, _currentUserID)) f.ShowDialog(this); RefreshAppointments(); }
        private int SelectedID() => dgvStreetTestAppointments.CurrentRow == null ? -1 : Convert.ToInt32(dgvStreetTestAppointments.CurrentRow.Cells["TestAppointmentID"].Value);
        private void editToolStripMenuItem_Click(object sender, EventArgs e) { int id = SelectedID(); if (id < 0) return; if (Convert.ToBoolean(dgvStreetTestAppointments.CurrentRow.Cells["IsLocked"].Value)) { MessageBox.Show("A locked appointment cannot be edited."); return; } using (var f = new frmScheduleStreetTestAppointment(_localDrivingLicenseApplicationID, _currentUserID, id)) f.ShowDialog(this); RefreshAppointments(); }
        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e) { int id = SelectedID(); if (id < 0) return; if (Convert.ToBoolean(dgvStreetTestAppointments.CurrentRow.Cells["IsLocked"].Value)) { MessageBox.Show("This appointment has already been completed."); return; } using (var f = new frmTakeStreetTest(_localDrivingLicenseApplicationID, id, _currentUserID)) f.ShowDialog(this); RefreshAppointments(); }
    }
}
