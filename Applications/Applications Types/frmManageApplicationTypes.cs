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

namespace DVLD.Applications.Applications_Types
{
    public partial class frmManageApplicationTypes : Form
    {
        private void _ListAllApplicationsTypes()
        {
            DataTable dt = clsApplicationTypes.ListAllApplicationsTypes();
            dgvApplicationTypes.DataSource = dt;
        }



        public frmManageApplicationTypes()
        {
            InitializeComponent();
            _ListAllApplicationsTypes();
        }

        private int _GetSelectedApplicationTypeID()
        {
            if (dgvApplicationTypes.CurrentRow == null)
                return -1;

            return Convert.ToInt32(
                dgvApplicationTypes.CurrentRow.Cells["ApplicationTypeID"].Value);
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationTypeID = _GetSelectedApplicationTypeID();

            if (ApplicationTypeID == -1)
            {
                MessageBox.Show("Please select an application type first.");
                return;
            }

            frmUpdateApplicationType frm = new frmUpdateApplicationType(ApplicationTypeID);
            frm.ShowDialog();

            _ListAllApplicationsTypes();
        }

        private void dgvApplicationTypes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvApplicationTypes.ClearSelection();
                dgvApplicationTypes.Rows[e.RowIndex].Selected = true;
                dgvApplicationTypes.CurrentCell = dgvApplicationTypes.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }
    }
}
