using System;
using System.Drawing;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD.Drivers
{
    public class frmManageDrivers : Form
    {
        readonly ComboBox filter = new ComboBox(); readonly TextBox value = new TextBox(); readonly DataGridView grid = new DataGridView(); readonly Label records = new Label();
        public frmManageDrivers()
        {
            Text = "List Drivers"; StartPosition = FormStartPosition.CenterScreen; WindowState = FormWindowState.Normal; ClientSize = new Size(1150, 780);
            var image = new PictureBox { Image = global::DVLD.Properties.Resources.Drivers_641, Location = new Point(470, 20), Size = new Size(220, 170), SizeMode = PictureBoxSizeMode.StretchImage };
            var title = new Label { Text = "Manage Drivers", Font = new Font("Microsoft Sans Serif", 24, FontStyle.Bold), ForeColor = Color.DarkRed, AutoSize = true, Location = new Point(455, 195) };
            var filterLabel = new Label { Text = "Filter By:", Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold), AutoSize = true, Location = new Point(25, 275) }; filter.Location = new Point(110, 270); filter.Width = 210; filter.DropDownStyle = ComboBoxStyle.DropDownList; filter.Items.AddRange(new object[] { "None", "Driver ID", "Person ID", "National No.", "Full Name" }); filter.SelectedIndex = 0;
            value.Location = new Point(330, 270); value.Width = 260; value.Visible = false;
            grid.Location = new Point(20, 315); grid.Size = new Size(1110, 390); grid.ReadOnly = true; grid.AllowUserToAddRows = false; grid.AllowUserToDeleteRows = false; grid.BackgroundColor = SystemColors.ButtonFace; grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            records.Text = "# Records: 0"; records.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold); records.AutoSize = true; records.Location = new Point(25, 725);
            var close = new Button { Text = "Close", Location = new Point(1000, 725), Size = new Size(120, 35) }; close.Click += (s, e) => Close(); filter.SelectedIndexChanged += (s, e) => { value.Visible = filter.SelectedIndex > 0; RefreshDrivers(); }; value.TextChanged += (s, e) => RefreshDrivers(); Controls.AddRange(new Control[] { image, title, filterLabel, filter, value, grid, records, close }); RefreshDrivers();
        }
        void RefreshDrivers() { grid.DataSource = clsDrivers.GetDrivers(filter.Text, value.Text.Trim()); records.Text = "# Records: " + grid.Rows.Count; }
    }
}
