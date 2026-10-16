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
    public partial class frmSchedualeVisionTestAppointment : Form
    {
        private readonly int _localDrivingLicenseApplicationID;
        private readonly int _currentUserID;
        private readonly int _appointmentID;
        private readonly bool _editMode;

        public frmSchedualeVisionTestAppointment(int localDrivingLicenseApplicationID, int currentUserID)
            : this(localDrivingLicenseApplicationID, currentUserID, -1)
        {
        }

        public frmSchedualeVisionTestAppointment(int localDrivingLicenseApplicationID, int currentUserID, int appointmentID)
        {
            InitializeComponent();
            _localDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            _currentUserID = currentUserID;
            _appointmentID = appointmentID;
            _editMode = appointmentID > 0;
            LoadApplicationInfo();
        }

        private void LoadApplicationInfo()
        {
            DataTable info = clsLocalDrivingLicenseApplications
                .GetLocalDrivingLicenseApplicationInfoByID(_localDrivingLicenseApplicationID);

            if (info.Rows.Count == 0)
            {
                MessageBox.Show("Application not found.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            DataRow row = info.Rows[0];
            label5.Text = _localDrivingLicenseApplicationID.ToString();
            lblName.Text = row["FullName"].ToString();
            DataTable appointments = clsTestAppointments.GetVisionAppointments(
                _localDrivingLicenseApplicationID);
            bool hasActiveAppointment = clsTestAppointments.HasActiveVisionAppointment(
                _localDrivingLicenseApplicationID);
            bool isRetake = appointments.Rows.Count > 0 && !hasActiveAppointment;

            label8.Text = isRetake ? "15" : "10";
            lblRetakeAppFees.Text = isRetake ? "5" : "0";
            lblRetakeTotalFees.Text = isRetake ? "15" : "10";
            lblRetakeTestAppID.Text = "N/A";
            btnSave.Enabled = !hasActiveAppointment;
            dateTimePicker1.MinDate = DateTime.Today;
            dateTimePicker1.Value = DateTime.Today;

            if (_editMode)
            {
                DataTable selectedAppointments = clsTestAppointments.GetVisionAppointments(
                    _localDrivingLicenseApplicationID);
                DataRow[] selected = selectedAppointments.Select(
                    "TestAppointmentID = " + _appointmentID);
                if (selected.Length == 1 && !Convert.ToBoolean(selected[0]["IsLocked"]))
                    dateTimePicker1.Value = Convert.ToDateTime(selected[0]["AppointmentDate"]);

                label1.Text = "Edit Vision Test Appointment";
                btnSave.Text = "Update";
                btnSave.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Appointment date cannot be in the past.", "Invalid Date",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int appointmentID = _editMode
                ? (clsTestAppointments.UpdateVisionAppointmentDate(_appointmentID, dateTimePicker1.Value.Date) ? _appointmentID : -1)
                : clsTestAppointments.AddVisionAppointment(
                    _localDrivingLicenseApplicationID, dateTimePicker1.Value.Date,
                    Convert.ToDecimal(label8.Text), _currentUserID);

            if (appointmentID == -1)
            {
                MessageBox.Show("An active vision test appointment already exists, or the appointment could not be saved.",
                    "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(_editMode ? "Vision test appointment updated successfully." : "Vision test appointment saved successfully.", "Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }











    }
}
