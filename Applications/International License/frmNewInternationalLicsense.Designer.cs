namespace DVLD.Applications.International_License
{
    partial class frmNewInternationalLicsense
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle, lblLicenseId;
        private System.Windows.Forms.TextBox txtLicenseId;
        private System.Windows.Forms.Button btnFindLicense, btnClose, btnIssue;
        private System.Windows.Forms.GroupBox grpFilter, grpDriverInfo, grpApplicationInfo;
        private System.Windows.Forms.Label lblDriverInfo, lblApplicationInfo;
        private System.Windows.Forms.PictureBox picApplicant;
        private System.Windows.Forms.LinkLabel lnkInternationalLicenseInfo;
        private System.Windows.Forms.LinkLabel lnkLicenseHistory;

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
            grpDriverInfo = new System.Windows.Forms.GroupBox();
            lblDriverInfo = new System.Windows.Forms.Label();
            grpApplicationInfo = new System.Windows.Forms.GroupBox();
            lblApplicationInfo = new System.Windows.Forms.Label();
            picApplicant = new System.Windows.Forms.PictureBox();
            btnClose = new System.Windows.Forms.Button();
            btnIssue = new System.Windows.Forms.Button();
            lnkInternationalLicenseInfo = new System.Windows.Forms.LinkLabel();
            lnkLicenseHistory = new System.Windows.Forms.LinkLabel();
            SuspendLayout();

            lblTitle.AutoSize = false;
            lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitle.Height = 62;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.Firebrick;
            lblTitle.Text = "International License Application";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            grpFilter.Location = new System.Drawing.Point(28, 72);
            grpFilter.Size = new System.Drawing.Size(822, 86);
            grpFilter.Text = "Filter";
            lblLicenseId.AutoSize = true;
            lblLicenseId.Location = new System.Drawing.Point(28, 35);
            lblLicenseId.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblLicenseId.Text = "License ID:";
            txtLicenseId.Location = new System.Drawing.Point(170, 30);
            txtLicenseId.Size = new System.Drawing.Size(330, 27);
            txtLicenseId.Font = new System.Drawing.Font("Segoe UI", 11F);
            btnFindLicense.Location = new System.Drawing.Point(710, 19);
            btnFindLicense.Size = new System.Drawing.Size(82, 52);
            btnFindLicense.Text = "Find";
            btnFindLicense.Click += new System.EventHandler(btnFindLicense_Click);
            grpFilter.Controls.Add(lblLicenseId);
            grpFilter.Controls.Add(txtLicenseId);
            grpFilter.Controls.Add(btnFindLicense);

            grpDriverInfo.Location = new System.Drawing.Point(24, 168);
            grpDriverInfo.Size = new System.Drawing.Size(856, 292);
            grpDriverInfo.Text = "Driver License Info";
            picApplicant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picApplicant.Location = new System.Drawing.Point(704, 46);
            picApplicant.Size = new System.Drawing.Size(130, 160);
            picApplicant.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            grpDriverInfo.Controls.Add(picApplicant);
            lblDriverInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            lblDriverInfo.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblDriverInfo.Padding = new System.Windows.Forms.Padding(18);
            lblDriverInfo.Text = "Class:     Class 3 - Ordinary driving license        Is Active?:     Yes\n\nName:     Mahmoud Omar Ali Almajed\n\nLicense ID:     25                              Date Of Birth:     09/Oct/2005\n\nNational No:     N10                          Driver ID:     11\n\nIssue Date:     09/Oct/2023                 Expiration Date:     09/Oct/2033\n\nIssue Reason:     First Time                    Is Detained?:     No";
            grpDriverInfo.Controls.Add(lblDriverInfo);

            grpApplicationInfo.Location = new System.Drawing.Point(30, 470);
            grpApplicationInfo.Size = new System.Drawing.Size(850, 142);
            grpApplicationInfo.Text = "Application Info";
            lblApplicationInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            lblApplicationInfo.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            lblApplicationInfo.Padding = new System.Windows.Forms.Padding(18, 8, 8, 8);
            lblApplicationInfo.Text = "I.L.Application ID:     [???]                         I.L.License ID:     [???]\n\nApplication Date:     " + System.DateTime.Today.ToString("dd/MMM/yyyy") + "          Local License ID:     25\n\nIssue Date:     " + System.DateTime.Today.ToString("dd/MMM/yyyy") + "                 Expiration Date:     " + System.DateTime.Today.AddYears(1).ToString("dd/MMM/yyyy") + "\n\nFees:     51                                              Created By:     -";
            grpApplicationInfo.Controls.Add(lblApplicationInfo);

            btnClose.Location = new System.Drawing.Point(615, 622);
            btnClose.Size = new System.Drawing.Size(126, 42);
            btnClose.Text = "Close";
            btnClose.Click += new System.EventHandler(btnClose_Click);
            btnIssue.Location = new System.Drawing.Point(747, 622);
            btnIssue.Size = new System.Drawing.Size(126, 42);
            btnIssue.Text = "Issue";
            btnIssue.Click += new System.EventHandler(btnIssue_Click);
            lnkInternationalLicenseInfo.AutoSize = true;
            lnkInternationalLicenseInfo.Enabled = false;
            lnkInternationalLicenseInfo.Location = new System.Drawing.Point(32, 630);
            lnkInternationalLicenseInfo.Text = "Show International License Info";
            lnkInternationalLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(lnkInternationalLicenseInfo_LinkClicked);
            lnkLicenseHistory.AutoSize = true;
            lnkLicenseHistory.Enabled = false;
            lnkLicenseHistory.Location = new System.Drawing.Point(32, 650);
            lnkLicenseHistory.Text = "Show License History";
            lnkLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(lnkLicenseHistory_LinkClicked);

            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(910, 680);
            Controls.Add(lblTitle);
            Controls.Add(grpFilter);
            Controls.Add(grpDriverInfo);
            Controls.Add(grpApplicationInfo);
            Controls.Add(btnClose);
            Controls.Add(btnIssue);
            Controls.Add(lnkInternationalLicenseInfo);
            Controls.Add(lnkLicenseHistory);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "New International License Application";
            ResumeLayout(false);
        }
    }
}
