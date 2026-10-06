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

namespace DVLD.Applications.Applications_Types
{
    public partial class frmUpdateApplicationType : Form
    {
        private int _ApplicationTypeID = -1;
        private clsApplicationTypes _ApplicationType;

        public frmUpdateApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();

            _ApplicationTypeID = ApplicationTypeID;
            _LoadApplicationTypeData();
        }

        private void _LoadApplicationTypeData()
        {
            _ApplicationType = clsApplicationTypes.Find(_ApplicationTypeID);

            if (_ApplicationType == null)
            {
                MessageBox.Show("Application type was not found.");
                Close();
                return;
            }

            lblID.Text = _ApplicationType.ApplicationTypeID.ToString();
            txtTitle.Text = _ApplicationType.ApplicationTypeTitle;
            txtFees.Text = _ApplicationType.ApplicationFees.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter application type title.");
                txtTitle.Focus();
                return;
            }

            if (!decimal.TryParse(txtFees.Text.Trim(), out decimal ApplicationFees))
            {
                MessageBox.Show("Please enter a valid application fee.");
                txtFees.Focus();
                return;
            }

            bool isUpdated = clsApplicationTypes.UpdateApplicationType(
                _ApplicationTypeID,
                txtTitle.Text.Trim(),
                ApplicationFees);

            if (isUpdated)
            {
                MessageBox.Show("Application type updated successfully.");
                Close();
            }
            else
            {
                MessageBox.Show("Application type update failed.");
            }
        }
    }
}
