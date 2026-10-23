namespace DVLD.Applications.Renew_Driving_License
{
    partial class frmReenewLocalDrivingLicense
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle, lblLicenseId, lblApplicationInfo;
        private System.Windows.Forms.TextBox txtLicenseId;
        private System.Windows.Forms.Button btnFindLicense, btnRenew, btnClose;
        private System.Windows.Forms.GroupBox grpFilter, grpApplicationInfo;
        private System.Windows.Forms.LinkLabel lnkLicenseHistory, lnkNewLicenseInfo;
        private DVLD.Applications.Controls.ctrlLocalDrivingLicenseInfo ctrlLicenseInfo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTitle = new System.Windows.Forms.Label(); grpFilter = new System.Windows.Forms.GroupBox(); lblLicenseId = new System.Windows.Forms.Label(); txtLicenseId = new System.Windows.Forms.TextBox(); btnFindLicense = new System.Windows.Forms.Button(); ctrlLicenseInfo = new DVLD.Applications.Controls.ctrlLocalDrivingLicenseInfo(); grpApplicationInfo = new System.Windows.Forms.GroupBox(); lblApplicationInfo = new System.Windows.Forms.Label(); lnkLicenseHistory = new System.Windows.Forms.LinkLabel(); lnkNewLicenseInfo = new System.Windows.Forms.LinkLabel(); btnClose = new System.Windows.Forms.Button(); btnRenew = new System.Windows.Forms.Button();
            SuspendLayout();
            lblTitle.Dock = System.Windows.Forms.DockStyle.Top; lblTitle.Height = 62; lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold); lblTitle.ForeColor = System.Drawing.Color.Firebrick; lblTitle.Text = "Renew License Application"; lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            grpFilter.Location = new System.Drawing.Point(35, 70); grpFilter.Size = new System.Drawing.Size(600, 86); grpFilter.Text = "Filter";
            lblLicenseId.AutoSize = true; lblLicenseId.Location = new System.Drawing.Point(28, 35); lblLicenseId.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold); lblLicenseId.Text = "License ID:";
            txtLicenseId.Location = new System.Drawing.Point(170, 30); txtLicenseId.Size = new System.Drawing.Size(320, 27); txtLicenseId.Font = new System.Drawing.Font("Segoe UI", 11F);
            btnFindLicense.Location = new System.Drawing.Point(515, 19); btnFindLicense.Size = new System.Drawing.Size(70, 52); btnFindLicense.Text = "Find"; btnFindLicense.Click += new System.EventHandler(btnFindLicense_Click); grpFilter.Controls.AddRange(new System.Windows.Forms.Control[] { lblLicenseId, txtLicenseId, btnFindLicense });
            ctrlLicenseInfo.Location = new System.Drawing.Point(24, 168); ctrlLicenseInfo.Size = new System.Drawing.Size(870, 335);
            grpApplicationInfo.Location = new System.Drawing.Point(30, 510); grpApplicationInfo.Size = new System.Drawing.Size(850, 176); grpApplicationInfo.Text = "Application New License Info";
            lblApplicationInfo.Dock = System.Windows.Forms.DockStyle.Fill; lblApplicationInfo.Font = new System.Drawing.Font("Segoe UI", 10.5F); lblApplicationInfo.Padding = new System.Windows.Forms.Padding(18, 8, 8, 8); lblApplicationInfo.Text = "R.L.Application ID:     [???]                         Renewed License ID:     [???]\n\nApplication Date:     [???]                         Old License ID:     [???]\n\nIssue Date:     [???]                                      Expiration Date:     [???]\n\nApplication Fees:     [???]                                  Created By:     [???]\n\nLicense Fees:     [$$$]                                      Total Fees:     [$$$]"; grpApplicationInfo.Controls.Add(lblApplicationInfo);
            lnkLicenseHistory.AutoSize = true; lnkLicenseHistory.Location = new System.Drawing.Point(32, 700); lnkLicenseHistory.Text = "Show Licenses History"; lnkLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(lnkLicenseHistory_LinkClicked);
            lnkNewLicenseInfo.AutoSize = true; lnkNewLicenseInfo.Location = new System.Drawing.Point(220, 700); lnkNewLicenseInfo.Text = "Show New License Info"; lnkNewLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(lnkNewLicenseInfo_LinkClicked);
            btnClose.Location = new System.Drawing.Point(615, 690); btnClose.Size = new System.Drawing.Size(126, 42); btnClose.Text = "Close"; btnClose.Click += new System.EventHandler(btnClose_Click); btnRenew.Location = new System.Drawing.Point(747, 690); btnRenew.Size = new System.Drawing.Size(126, 42); btnRenew.Text = "Renew"; btnRenew.Click += new System.EventHandler(btnRenew_Click);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font; ClientSize = new System.Drawing.Size(910, 750); Controls.Add(lblTitle); Controls.Add(grpFilter); Controls.Add(ctrlLicenseInfo); Controls.Add(grpApplicationInfo); Controls.Add(lnkLicenseHistory); Controls.Add(lnkNewLicenseInfo); Controls.Add(btnClose); Controls.Add(btnRenew); FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle; MaximizeBox = false; StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; Text = "Renew Local Driving License"; ResumeLayout(false); PerformLayout();
        }
    }
}
