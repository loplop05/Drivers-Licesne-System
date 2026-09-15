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

namespace DVLD.People
{
    public partial class frmPeopleManagement : Form
    {


        private void LoadDataFromDataBase()
        {
            
        }

        private void _RefreshPeopleList()
        {
            DataTable dt = clsPeople.GetPeopleByFilter(
                 cbFilterBy.Text.Trim(), txtboxFilter.Text.Trim());

            dgvPeople.DataSource = dt;
        }





        public frmPeopleManagement()
        {
            InitializeComponent();
            cbFilterBy.SelectedIndex = 0; 

           

            _RefreshPeopleList();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtboxFilter.Clear();

            LoadDataFromDataBase();
        }


    

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtboxFilter.Clear();

            LoadDataFromDataBase();
        }

        private void cbFilterBy_TextChanged(object sender, EventArgs e)
        {
            LoadDataFromDataBase();
        }

        private void txtboxFilter_TextChanged(object sender, EventArgs e)
        {
            LoadDataFromDataBase();
        }

        private void btnAddPeople_Click(object sender, EventArgs e)
        {
            frmAddPeople frmAdd = new frmAddPeople();

            frmAdd.ShowDialog();

            _RefreshPeopleList();

        }





        private void btnRefreshPeople_Click(object sender, EventArgs e)
        {
            _RefreshPeopleList();
        }

        private void dgvPeople_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvPeople.ClearSelection();

                dgvPeople.Rows[e.RowIndex].Selected = true;

                dgvPeople.CurrentCell = dgvPeople.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }

        }

        private int _GetSelectedPersonID()
        {
            if (dgvPeople.CurrentRow == null)
                return -1;

            return Convert.ToInt32(
                dgvPeople.CurrentRow.Cells["PersonID"].Value.ToString()
            );
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = _GetSelectedPersonID();

            if (PersonID == -1) return;

            frmPersonDetails frm = new frmPersonDetails(PersonID);
            frm.ShowDialog();



        }
    }
}
