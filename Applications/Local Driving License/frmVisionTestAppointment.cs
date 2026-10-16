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

        public frmVisionTestAppointment(int localDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _localDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            ctrlLocalDrivingLicenseApplicationInfo1.LoadDrivingLicsenseApplicationInfo(
                _localDrivingLicenseApplicationID);
        }

        private void btnAddVisionTestAppointment_Click(object sender, EventArgs e)
        {
            frmSchedualeVisionTestAppointment vision = new frmSchedualeVisionTestAppointment(_localDrivingLicenseApplicationID);
            vision.ShowDialog();
        }
    }
}
