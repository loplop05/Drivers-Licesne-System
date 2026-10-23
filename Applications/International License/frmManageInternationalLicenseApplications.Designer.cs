namespace DVLD.Applications.International_License
{
    partial class frmManageInternationalLicenseApplications
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle, lblFilter;
        private System.Windows.Forms.DataGridView dgvApplications;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Button btnAddNewApplication;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseHistoryToolStripMenuItem;

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
            dgvApplications = new System.Windows.Forms.DataGridView();
            cbFilterBy = new System.Windows.Forms.ComboBox();
            lblFilter = new System.Windows.Forms.Label();
            txtFilterValue = new System.Windows.Forms.TextBox();
            btnAddNewApplication = new System.Windows.Forms.Button();
            contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
            cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            showLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgvApplications).BeginInit();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();

            lblTitle.AutoSize = false;
            lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            lblTitle.ForeColor = System.Drawing.Color.Red;
            lblTitle.Location = new System.Drawing.Point(290, 45);
            lblTitle.Size = new System.Drawing.Size(850, 60);
            lblTitle.Text = "International License Applications";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            lblFilter.AutoSize = true;
            lblFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            lblFilter.Location = new System.Drawing.Point(260, 145);
            lblFilter.Text = "Filter By:";
            cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            cbFilterBy.Location = new System.Drawing.Point(360, 143);
            cbFilterBy.Size = new System.Drawing.Size(205, 30);
            cbFilterBy.SelectedIndexChanged += new System.EventHandler(cbFilterBy_SelectedIndexChanged);
            txtFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            txtFilterValue.Location = new System.Drawing.Point(575, 146);
            txtFilterValue.Size = new System.Drawing.Size(260, 28);
            txtFilterValue.TextChanged += new System.EventHandler(txtFilterValue_TextChanged);

            btnAddNewApplication.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAddNewApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            btnAddNewApplication.Image = global::DVLD.Properties.Resources.New_Application_64;
            btnAddNewApplication.Location = new System.Drawing.Point(1300, 105);
            btnAddNewApplication.Size = new System.Drawing.Size(112, 77);
            btnAddNewApplication.Click += new System.EventHandler(btnAddNewApplication_Click);

            contextMenuStrip.Font = new System.Drawing.Font("Segoe UI", 12F);
            contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { cancelApplicationToolStripMenuItem, showLicenseHistoryToolStripMenuItem });
            contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(contextMenuStrip_Opening);
            cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            cancelApplicationToolStripMenuItem.Click += new System.EventHandler(cancelApplicationToolStripMenuItem_Click);
            showLicenseHistoryToolStripMenuItem.Text = "Show License History";
            showLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(showLicenseHistoryToolStripMenuItem_Click);

            dgvApplications.AllowUserToAddRows = false;
            dgvApplications.AllowUserToDeleteRows = false;
            dgvApplications.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvApplications.ContextMenuStrip = contextMenuStrip;
            dgvApplications.Location = new System.Drawing.Point(120, 195);
            dgvApplications.ReadOnly = true;
            dgvApplications.Size = new System.Drawing.Size(1350, 525);
            dgvApplications.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dataGridView_CellMouseDown);

            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1584, 776);
            Controls.Add(btnAddNewApplication);
            Controls.Add(txtFilterValue);
            Controls.Add(cbFilterBy);
            Controls.Add(lblFilter);
            Controls.Add(dgvApplications);
            Controls.Add(lblTitle);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Manage International License Applications";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvApplications).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
