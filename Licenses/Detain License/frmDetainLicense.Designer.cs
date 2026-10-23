namespace DVLD.Licenses.DetainLicense
{
    partial class frmDetainLicense
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Label lblLicenseId;
        private System.Windows.Forms.TextBox txtLicenseId;
        private System.Windows.Forms.Button btnFindLicense;
        private DVLD.Applications.Controls.ctrlLocalDrivingLicenseInfo ctrlLicenseInfo;
        private System.Windows.Forms.GroupBox grpDetainInfo;
        private System.Windows.Forms.Label lblFineFees;
        private System.Windows.Forms.TextBox txtFineFees;
        private System.Windows.Forms.LinkLabel lnkLicenseHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDetain;

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
            lblLicenseId = new System.Windows.Forms.Label();
            txtLicenseId = new System.Windows.Forms.TextBox();
            btnFindLicense = new System.Windows.Forms.Button();
            ctrlLicenseInfo = new DVLD.Applications.Controls.ctrlLocalDrivingLicenseInfo();
            grpDetainInfo = new System.Windows.Forms.GroupBox();
            lblFineFees = new System.Windows.Forms.Label();
            txtFineFees = new System.Windows.Forms.TextBox();
            lnkLicenseHistory = new System.Windows.Forms.LinkLabel();
            btnClose = new System.Windows.Forms.Button();
            btnDetain = new System.Windows.Forms.Button();

            SuspendLayout();
            grpFilter.SuspendLayout();
            grpDetainInfo.SuspendLayout();

            lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitle.Font = new System.Drawing.Font(
                "Segoe UI",
                22F,
                System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.Firebrick;
            lblTitle.Height = 70;
            lblTitle.Text = "Detain License";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            grpFilter.Location = new System.Drawing.Point(25, 78);
            grpFilter.Size = new System.Drawing.Size(600, 75);
            grpFilter.Text = "Filter";

            lblLicenseId.AutoSize = true;
            lblLicenseId.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold);
            lblLicenseId.Location = new System.Drawing.Point(25, 30);
            lblLicenseId.Text = "License ID:";

            txtLicenseId.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtLicenseId.Location = new System.Drawing.Point(160, 26);
            txtLicenseId.Size = new System.Drawing.Size(350, 27);

            btnFindLicense.Location = new System.Drawing.Point(525, 20);
            btnFindLicense.Size = new System.Drawing.Size(65, 38);
            btnFindLicense.Text = "Find";
            btnFindLicense.UseVisualStyleBackColor = true;
            btnFindLicense.Click += new System.EventHandler(btnFindLicense_Click);

            grpFilter.Controls.Add(lblLicenseId);
            grpFilter.Controls.Add(txtLicenseId);
            grpFilter.Controls.Add(btnFindLicense);

            ctrlLicenseInfo.Location = new System.Drawing.Point(20, 165);
            ctrlLicenseInfo.Size = new System.Drawing.Size(870, 335);

            grpDetainInfo.Location = new System.Drawing.Point(25, 510);
            grpDetainInfo.Size = new System.Drawing.Size(850, 72);
            grpDetainInfo.Text = "Detain Information";

            lblFineFees.AutoSize = true;
            lblFineFees.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold);
            lblFineFees.Location = new System.Drawing.Point(22, 29);
            lblFineFees.Text = "Fine Fees:";

            txtFineFees.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtFineFees.Location = new System.Drawing.Point(145, 25);
            txtFineFees.Size = new System.Drawing.Size(220, 27);

            grpDetainInfo.Controls.Add(lblFineFees);
            grpDetainInfo.Controls.Add(txtFineFees);

            lnkLicenseHistory.AutoSize = true;
            lnkLicenseHistory.Location = new System.Drawing.Point(30, 605);
            lnkLicenseHistory.Text = "Show Licenses History";
            lnkLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
                lnkLicenseHistory_LinkClicked);

            btnClose.Location = new System.Drawing.Point(650, 595);
            btnClose.Size = new System.Drawing.Size(110, 40);
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += new System.EventHandler(btnClose_Click);

            btnDetain.Location = new System.Drawing.Point(770, 595);
            btnDetain.Size = new System.Drawing.Size(105, 40);
            btnDetain.Text = "Detain";
            btnDetain.UseVisualStyleBackColor = true;
            btnDetain.Click += new System.EventHandler(btnDetain_Click);

            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new System.Drawing.Size(910, 655);
            Controls.Add(lblTitle);
            Controls.Add(grpFilter);
            Controls.Add(ctrlLicenseInfo);
            Controls.Add(grpDetainInfo);
            Controls.Add(lnkLicenseHistory);
            Controls.Add(btnClose);
            Controls.Add(btnDetain);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDetainLicense";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Detain License";

            grpDetainInfo.ResumeLayout(false);
            grpDetainInfo.PerformLayout();
            grpFilter.ResumeLayout(false);
            grpFilter.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
