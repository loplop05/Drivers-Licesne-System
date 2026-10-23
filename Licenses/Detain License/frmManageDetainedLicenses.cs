using System;
using System.Data;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD.Licenses.DetainLicense
{
    public partial class frmManageDetainedLicenses : Form
    {
        public frmManageDetainedLicenses()
        {
            InitializeComponent();
            Load += frmManageDetainedLicenses_Load;
        }

        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            LoadDetainedLicenses();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDetainedLicenses();
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            e.SuppressKeyPress = true;
            LoadDetainedLicenses();
        }

        private void LoadDetainedLicenses()
        {
            try
            {
                string filterValue = txtFilter == null
                    ? string.Empty
                    : txtFilter.Text.Trim();

                DataTable detainedLicenses = clsDetainedLicenses.GetDetainedLicenses(
                    filterValue);

                if (detainedLicenses == null)
                {
                    throw new InvalidOperationException(
                        "The detained licenses query returned no data table.");
                }

                dgvDetainedLicenses.DataSource = detainedLicenses;

                if (lblRecords != null)
                {
                    lblRecords.Text = "# Records: " + detainedLicenses.Rows.Count;
                }

                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Detained licenses could not be loaded.\n\n" + ex.ToString(),
                    "Load failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void FormatGrid()
        {
            if (dgvDetainedLicenses == null || dgvDetainedLicenses.Columns == null)
            {
                return;
            }

            if (dgvDetainedLicenses.Columns["Detain ID"] != null)
            {
                dgvDetainedLicenses.Columns["Detain ID"].Width = 80;
            }

            if (dgvDetainedLicenses.Columns["License ID"] != null)
            {
                dgvDetainedLicenses.Columns["License ID"].Width = 85;
            }

            if (dgvDetainedLicenses.Columns["Is Released"] != null)
            {
                dgvDetainedLicenses.Columns["Is Released"].Width = 90;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
