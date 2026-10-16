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
            RefreshAppointments();
        }

        private void RefreshAppointments()
        {
            dgvWrittenTestAppointments.DataSource = clsTestAppointments.GetVisionAppointments(
                _localDrivingLicenseApplicationID);
            dgvWrittenTestAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        private void btnAddWrittenTestAppointment_Click(object sender, EventArgs e)
        {
            frmSchedualeWrittenTestAppointment frm = new frmSchedualeWrittenTestAppointment(_localDrivingLicenseApplicationID, _currentUserID);
            frm.ShowDialog();
        }

























    }
}
