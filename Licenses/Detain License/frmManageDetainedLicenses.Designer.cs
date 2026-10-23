namespace DVLD.Licenses.DetainLicense
{
    partial class frmManageDetainedLicenses
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvDetainedLicenses;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTitle = new System.Windows.Forms.Label();
            grpFilter = new System.Windows.Forms.GroupBox();
            lblFilter = new System.Windows.Forms.Label();
            txtFilter = new System.Windows.Forms.TextBox();
            btnSearch = new System.Windows.Forms.Button();
            dgvDetainedLicenses = new System.Windows.Forms.DataGridView();
            lblRecords = new System.Windows.Forms.Label();
            btnClose = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(dgvDetainedLicenses)).BeginInit();
            SuspendLayout();
            grpFilter.SuspendLayout();

            lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitle.Font = new System.Drawing.Font(
                "Segoe UI",
                22F,
                System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.Firebrick;
            lblTitle.Height = 70;
            lblTitle.Text = "Manage Detained Licenses";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            grpFilter.Location = new System.Drawing.Point(25, 78);
            grpFilter.Size = new System.Drawing.Size(850, 75);
            grpFilter.Text = "Filter";

            lblFilter.AutoSize = true;
            lblFilter.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold);
            lblFilter.Location = new System.Drawing.Point(20, 30);
            lblFilter.Text = "Detain ID, License ID, or Person:";

            txtFilter.Location = new System.Drawing.Point(270, 26);
            txtFilter.Size = new System.Drawing.Size(390, 27);
            txtFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(txtFilter_KeyDown);

            btnSearch.Location = new System.Drawing.Point(680, 22);
            btnSearch.Size = new System.Drawing.Size(100, 36);
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += new System.EventHandler(btnSearch_Click);

            grpFilter.Controls.Add(lblFilter);
            grpFilter.Controls.Add(txtFilter);
            grpFilter.Controls.Add(btnSearch);

            dgvDetainedLicenses.AllowUserToAddRows = false;
            dgvDetainedLicenses.AllowUserToDeleteRows = false;
            dgvDetainedLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetainedLicenses.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dgvDetainedLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetainedLicenses.Location = new System.Drawing.Point(25, 170);
            dgvDetainedLicenses.ReadOnly = true;
            dgvDetainedLicenses.RowHeadersWidth = 45;
            dgvDetainedLicenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvDetainedLicenses.Size = new System.Drawing.Size(850, 320);

            lblRecords.AutoSize = true;
            lblRecords.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold);
            lblRecords.Location = new System.Drawing.Point(25, 505);
            lblRecords.Text = "# Records: 0";

            btnClose.Location = new System.Drawing.Point(755, 520);
            btnClose.Size = new System.Drawing.Size(120, 40);
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += new System.EventHandler(btnClose_Click);

            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(900, 580);
            Controls.Add(lblTitle);
            Controls.Add(grpFilter);
            Controls.Add(dgvDetainedLicenses);
            Controls.Add(lblRecords);
            Controls.Add(btnClose);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmManageDetainedLicenses";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Manage Detained Licenses";

            grpFilter.ResumeLayout(false);
            grpFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(dgvDetainedLicenses)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
