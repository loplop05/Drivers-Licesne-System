using DVLD.Applications.Applications_Types;
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

namespace DVLD.Tests.Test_Types
{
    public partial class frmManageTestTypes : Form
    {


        private void _ListAllTestTypes()
        {
            DataTable dt = clsTestTypes.ListAllTestTypes();
            dbvManageTestTypes.DataSource = dt;
        }






        public frmManageTestTypes()
        {
            InitializeComponent();
            _ListAllTestTypes();

        }

        private int _GetSelectedTestTypeID()
        {
            if (dbvManageTestTypes.CurrentRow == null)
                return -1;

            return Convert.ToInt32(
                dbvManageTestTypes.CurrentRow.Cells["TestTypeID"].Value);
        }

        private void editTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestTypeID = _GetSelectedTestTypeID();

            if (TestTypeID == -1)
            {
                MessageBox.Show("Please select a test type first.");
                return;
            }

            frmUpdateTestTypes frm = new frmUpdateTestTypes(TestTypeID);
            frm.ShowDialog();

            _ListAllTestTypes();
        }

        private void dbvManageTestTypes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dbvManageTestTypes.ClearSelection();
                dbvManageTestTypes.Rows[e.RowIndex].Selected = true;
                dbvManageTestTypes.CurrentCell = dbvManageTestTypes.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }
    }
}
