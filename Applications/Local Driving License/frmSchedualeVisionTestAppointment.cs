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
    public partial class frmSchedualeVisionTestAppointment : Form
    {
        private readonly int _localDrivingLicenseApplicationID;

        public frmSchedualeVisionTestAppointment(int localDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _localDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
        }

        private void frmSchedualeVisionTestAppointment_Load(object sender, EventArgs e)
        {
            using (frmVisionTestAppointment visionTestForm =
                new frmVisionTestAppointment(_localDrivingLicenseApplicationID))
            {
                visionTestForm.ShowDialog(this);
            }
        }
    }
}
