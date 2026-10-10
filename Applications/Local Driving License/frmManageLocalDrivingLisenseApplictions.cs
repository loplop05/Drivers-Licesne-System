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
    public partial class frmManageLocalDrivingLisenseApplictions : Form
    {
        private clsUsers _currentUser;

        private void _RefreshLocalDrivingLicenseApplicationsList()
        {
            DataTable dt = clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationsByFilter(
                cbFilterBy.Text.Trim(),
                txtFilterValue.Text.Trim()
            );
            dgvLocalDrivingLicsenseApplictions.DataSource = dt;
        }

        public frmManageLocalDrivingLisenseApplictions(clsUsers currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;

            // Populate filter options
            cbFilterBy.Items.Add("None");
            cbFilterBy.Items.Add("LocalDrivingLicenseApplicationID");
            cbFilterBy.Items.Add("ApplicationID");
            cbFilterBy.Items.Add("PersonID");
            cbFilterBy.Items.Add("LicenseClassID");
            cbFilterBy.SelectedIndex = 0;

            _RefreshLocalDrivingLicenseApplicationsList();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Clear();
            _RefreshLocalDrivingLicenseApplicationsList();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _RefreshLocalDrivingLicenseApplicationsList();
        }

        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicsenseApplication newApplication = new frmNewLocalDrivingLicsenseApplication(_currentUser);
            newApplication.ShowDialog();
            _RefreshLocalDrivingLicenseApplicationsList();
        }

        private int GetSelectedApplicationID()
        {
            if (dgvLocalDrivingLicsenseApplictions.CurrentRow == null)
                return -1;

            return Convert.ToInt32(dgvLocalDrivingLicsenseApplictions.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLocalDrivingLicsenseApplictions.CurrentRow == null)
            {
                MessageBox.Show("Please select an application first.");
                return;
            }

            int applicationID = GetSelectedApplicationID();
            if (applicationID == -1)
                return;

            // Details form would need to be created
        }

        private void addNewApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddNewApplication_Click(sender, e);
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvLocalDrivingLicsenseApplictions.ClearSelection();
                dgvLocalDrivingLicsenseApplictions.Rows[e.RowIndex].Selected = true;
                dgvLocalDrivingLicsenseApplictions.CurrentCell = dgvLocalDrivingLicsenseApplictions.Rows[e.RowIndex].Cells[e.ColumnIndex];
                contextMenuStrip1.Show(Cursor.Position);
            }
        }
    }
}