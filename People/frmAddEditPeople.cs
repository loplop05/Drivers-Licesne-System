using DVLD.People.Controls;
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
        public frmAddPeople()
        {
            InitializeComponent();
            ctrlAddEditPerson1.PersonSaved += CtrlAddEditPerson1_PersonSaved;
        }
        private void CtrlAddEditPerson1_PersonSaved(object sender, EventArgs e)
        {
            lblPersonID.Text = ctrlAddEditPerson1.PersonID.ToString();
        }

        private void ctrlAddEditPerson1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
