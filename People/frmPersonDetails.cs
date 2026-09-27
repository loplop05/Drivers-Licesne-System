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
    public partial class frmPersonDetails : Form
    {
        private int _PersonID; 

        public frmPersonDetails(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            ctrlUserDetails1.LoadPerson(PersonID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
