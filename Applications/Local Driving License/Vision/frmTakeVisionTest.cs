using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmTakeVisionTest : Form
    {
        private readonly int _appointmentID;
        private readonly int _currentUserID;

        public frmTakeVisionTest(int localDrivingLicenseApplicationID, int appointmentID, int currentUserID)
        {
            InitializeComponent();
            _appointmentID = appointmentID;
            _currentUserID = currentUserID;

            DataTable info = clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationInfoByID(localDrivingLicenseApplicationID);
            if (info.Rows.Count > 0)
            {
                lblAppID.Text = localDrivingLicenseApplicationID.ToString();
                lblName.Text = info.Rows[0]["FullName"].ToString();
            }

            DataTable appointments = clsTestAppointments.GetVisionAppointments(localDrivingLicenseApplicationID);
            DataRow[] selected = appointments.Select("TestAppointmentID = " + appointmentID);
            if (selected.Length == 1)
                dateTimePicker1.Value = Convert.ToDateTime(selected[0]["AppointmentDate"]).Date;

            Button save = new Button { Text = "Save", Width = 100, Height = 35, Left = 470, Top = 605 };
            save.Click += btnSave_Click_1;
            Controls.Add(save);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
        
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!rbPass.Checked && !rbFail.Checked)
            {
                MessageBox.Show("Please select Pass or Fail.");
                return;
            }

            if (!clsTestAppointments.CompleteVisionAppointment(_appointmentID, rbPass.Checked, txtNotes.Text.Trim(), _currentUserID))
            {
                MessageBox.Show("Unable to save the test result.", "Save Failed");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }









    }
}
