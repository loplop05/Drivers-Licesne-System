using DVLD_Business;
using DVLD.Applications.Local_Driving_License;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Applications.International_License
{
    public partial class frmManageInternationalLicenseApplications : Form
    {
        private readonly clsUsers _currentUser;

        public frmManageInternationalLicenseApplications(clsUsers currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;

            cbFilterBy.Items.Add("None");
            cbFilterBy.Items.Add("I.L.AppID");
            cbFilterBy.Items.Add("National No");
            cbFilterBy.Items.Add("Full Name");
            cbFilterBy.Items.Add("Status");
            cbFilterBy.SelectedIndex = 0;

            RefreshApplicationsList();
        }

        private void RefreshApplicationsList()
        {
            DataTable applications = clsApplications.GetInternationalApplicationsByFilter(
                cbFilterBy.Text.Trim(),
                txtFilterValue.Text.Trim());

            dgvApplications.DataSource = applications;
            dgvApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvApplications.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Clear();
            RefreshApplicationsList();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            RefreshApplicationsList();
        }

        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
            using (frmNewInternationalLicsense form = new frmNewInternationalLicsense(_currentUser))
            {
                form.ShowDialog(this);
            }

            RefreshApplicationsList();
        }

        private int GetSelectedApplicationId()
        {
            if (dgvApplications.CurrentRow == null)
            {
                return -1;
            }

            return Convert.ToInt32(dgvApplications.CurrentRow.Cells["I.L.AppID"].Value);
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int applicationId = GetSelectedApplicationId();

            if (applicationId <= 0)
            {
                return;
            }

            string status = dgvApplications.CurrentRow.Cells["Status"].Value.ToString();

            if (status != "New")
            {
                MessageBox.Show("Only new applications can be cancelled.", "Cannot cancel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to cancel this application?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            if (!clsApplications.UpdateApplicationStatus(applicationId, 2))
            {
                MessageBox.Show("Application could not be cancelled.", "Cancel Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RefreshApplicationsList();
        }

        private void dataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right || e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            dgvApplications.ClearSelection();
            dgvApplications.Rows[e.RowIndex].Selected = true;
            dgvApplications.CurrentCell = dgvApplications.Rows[e.RowIndex].Cells[e.ColumnIndex];
            contextMenuStrip.Show(Cursor.Position);
        }

        private void contextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool hasSelection = dgvApplications.CurrentRow != null;
            cancelApplicationToolStripMenuItem.Enabled = hasSelection && dgvApplications.CurrentRow.Cells["Status"].Value.ToString() == "New";
        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvApplications.CurrentRow == null)
            {
                return;
            }

            int personId = Convert.ToInt32(dgvApplications.CurrentRow.Cells["Person ID"].Value);
            using (frmLicenseHistory history = new frmLicenseHistory(personId))
            {
                history.ShowDialog(this);
            }
        }
    }
}
