using DVLD.People.Controls;
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


   






    public partial class frmAddPeople : Form
    {



        public enum enMode
        {
            AddNew = 0,
            Update = 1
        }

        private enMode _Mode;
        private int _PersonID = -1;
        private clsPeople _Person;


        public frmAddPeople()
        {
            InitializeComponent();
            ctrlAddEditPerson1.PersonSaved += CtrlAddEditPerson1_PersonSaved;
            _Mode = enMode.AddNew;
        }


        public frmAddPeople(int PersonID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _PersonID = PersonID;
            ctrlAddEditPerson1.PersonSaved += CtrlAddEditPerson1_PersonSaved;
        }

        private void CtrlAddEditPerson1_PersonSaved(object sender, EventArgs e)
        {
            lblPersonID.Text = ctrlAddEditPerson1.PersonID.ToString();
        }

        private void ctrlAddEditPerson1_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                _Person = clsPeople.Find(_PersonID);
                if (_Person != null)
                {
                    ctrlAddEditPerson1.LoadPerson(_Person);
                    lblPersonID.Text = _PersonID.ToString();
                }
                else
                {
                    MessageBox.Show("Person not found.");
                    this.Close();
                }
            }
        }
    }
}
