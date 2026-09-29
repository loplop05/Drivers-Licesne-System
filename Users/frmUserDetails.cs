using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmUserDetails : Form
    {
        public frmUserDetails()
        {
            InitializeComponent();
        }

        public frmUserDetails(int userID) : this()
        {
            try
            {
                ctrlUserDetails1.LoadUser(userID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "User Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
    }
}
