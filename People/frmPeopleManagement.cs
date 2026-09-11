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
            DataTable dt = clsPeople.ListAllPeople();

            dgvPeople.DataSource = dt;
        }




        public frmPeopleManagement()
        {
            InitializeComponent();
            LoadDataFromDataBase();
        }









    }
}
