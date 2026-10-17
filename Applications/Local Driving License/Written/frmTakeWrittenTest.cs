using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Applications.Local_Driving_License.Written
{
    public partial class frmTakeWrittenTest : Form
    {
        private readonly int _appointmentID;
        private readonly int _currentUserID;

        public frmTakeWrittenTest(int localApplicationID, int appointmentID, int currentUserID)
        {
            InitializeComponent();
            _appointmentID = appointmentID;
            _currentUserID = currentUserID;

            DataTable info = clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationInfoByID(localApplicationID);
            if (info.Rows.Count > 0)
            {
                lblAppID.Text = localApplicationID.ToString();
                lblName.Text = info.Rows[0]["FullName"].ToString();
            }

            DataTable appointments = clsTestAppointments.GetWrittenAppointments(localApplicationID);
            DataRow[] selected = appointments.Select("TestAppointmentID = " + appointmentID);
            if (selected.Length == 1)
                dateTimePicker1.Value = Convert.ToDateTime(selected[0]["AppointmentDate"]).Date;

           
        }

     

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!rbPass.Checked && !rbFail.Checked)
            {
                MessageBox.Show("Please select Pass or Fail.");
                return;
            }

            if (!clsTestAppointments.CompleteWrittenAppointment(_appointmentID, rbPass.Checked, txtNotes.Text.Trim(), _currentUserID))
            {
                MessageBox.Show("Unable to save the test result.", "Save Failed");
                return;
            }else
            {
                MessageBox.Show("Test result saved successfully.", "Save Successful");
                
            }


            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
