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

            changePasswordToolStripMenuItem.Click += changePasswordToolStripMenuItem_Click;

            //showDetailsToolStripMenuItem.Click += showDetailsToolStripMenuItem_Click;
            //addNewUserToolStripMenuItem.Click += addNewUserToolStripMenuItem_Click;
            //editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            //deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;

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

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddNewUser addUser = new frmAddNewUser();
            addUser.ShowDialog();
            _RefreshUsersList();
        }

        private int GetSelectedUserID()
        {
            if (dataGridView1.CurrentRow == null)
                return -1;

            return Convert.ToInt32(dataGridView1.CurrentRow.Cells["UserID"].Value);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a user first.");
                return;
            }

            int userID = GetSelectedUserID();
            if (userID == -1)
                return;

            using (frmUserDetails details = new frmUserDetails(userID))
            {
                details.ShowDialog();
            }
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddUser_Click(sender, e);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GetSelectedUserID() == -1)
            {
                MessageBox.Show("Please select a user first.");
                return;
            }

            using (frmChangePassword changePassword = new frmChangePassword(GetSelectedUserID()))
            {
                changePassword.ShowDialog();
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userID = GetSelectedUserID();

            if (userID == -1)
            {
                MessageBox.Show("Please select a user first.");
                return;
            }

            using (frmChangePassword changePassword = new frmChangePassword(userID))
            {
                changePassword.ShowDialog();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userID = GetSelectedUserID();
            if (userID == -1)
            {
                MessageBox.Show("Please select a user first.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this user?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes && clsUsers.DeleteUser(userID))
            {
                _RefreshUsersList();
                MessageBox.Show("User deleted successfully.");
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        { if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
    {
        // 2. Clear current selections and select the right-clicked row
        dataGridView1.ClearSelection();
        dataGridView1.Rows[e.RowIndex].Selected = true;

        // 3. Optional: Set the right-clicked cell as the active cell
        dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

        // 4. Display the ContextMenuStrip at the mouse cursor position
        msUserManagement.Show(Cursor.Position);
    }

        }










    }
}
