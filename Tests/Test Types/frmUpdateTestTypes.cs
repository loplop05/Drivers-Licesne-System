using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.GlobalClasses;
using DVLD_Business;


namespace DVLD.Tests.Test_Types
{
    public partial class frmUpdateTestTypes : Form
    {
        private int _TestTypeID = -1;
        private clsTestTypes _TestType;
        private ValidationHelper ValidationHelper;

        public frmUpdateTestTypes(int TestTypeID)
        {
            InitializeComponent();

            _TestTypeID = TestTypeID;
            _LoadTestTypeData();
        }

        private void _LoadTestTypeData()
        {
            _TestType = clsTestTypes.Find(_TestTypeID);

            if (_TestType == null)
            {
                MessageBox.Show("Test type was not found.");
                Close();
                return;
            }

            lblID.Text = _TestType.TestTypeID.ToString();
            txtTitle.Text = _TestType.TestTypeTitle;
            txtDescription.Text = _TestType.TestTypeDescription;
            txtFees.Text = _TestType.TestTypeFees.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.ValidateRequiredField(txtTitle, "test type title"))
            {
                return;
            }

            if (!ValidationHelper.ValidateRequiredField(txtDescription, "test type description"))
            {
                return;
            }

            if (!ValidationHelper.ValidateDecimalInput(txtFees, "test type fee", out decimal TestTypeFees))
            {
                return;
            }

            bool isUpdated = clsTestTypes.UpdateTestType(
                _TestTypeID,
                txtTitle.Text.Trim(),
                txtDescription.Text.Trim(),
                TestTypeFees);

            if (isUpdated)
            {
                MessageBox.Show("Test type updated successfully.");
                Close();
            }
            else
            {
                MessageBox.Show("Test type update failed.");
            }
        }
    }
}
