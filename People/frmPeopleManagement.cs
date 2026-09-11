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
            DataTable dt = clsPeople.GetPeopleByFilter(
                cbFilterBy.Text.Trim(), txtboxFilter.Text.Trim());

            dgvPeople.DataSource = dt;
        }




        public frmPeopleManagement()
        {
            InitializeComponent();
            cbFilterBy.SelectedIndex = 0; 

            LoadDataFromDataBase();
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
    }
}
