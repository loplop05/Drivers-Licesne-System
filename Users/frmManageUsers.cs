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

namespace DVLD.Users
{
    public partial class frmManageUsers : Form
    {

        private void _RefreshUsersList()
        {
            DataTable dt = clsUsers.GetUsersByFilter(
                comboBox1.Text.Trim(), 
                txtFilterValue.Text.Trim()
            );
            dataGridView1.DataSource = dt;
        }

        public frmManageUsers()
        {
            InitializeComponent();
            
            // Populate filter options
            comboBox1.Items.Add("None");
            comboBox1.Items.Add("UserID");
            comboBox1.Items.Add("PersonID");
            comboBox1.Items.Add("Username");
            comboBox1.Items.Add("IsActive");
            comboBox1.SelectedIndex = 0;

            _RefreshUsersList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Clear();
            _RefreshUsersList();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _RefreshUsersList();
        }














    }
}
