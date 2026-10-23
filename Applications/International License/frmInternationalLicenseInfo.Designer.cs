namespace DVLD.Applications.International_License
{
    partial class frmInternationalLicenseInfo
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle, lblLicenseInfo;
        private System.Windows.Forms.GroupBox grpLicenseInfo;
        private System.Windows.Forms.PictureBox picApplicant;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel lnkLicenseHistory;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTitle = new System.Windows.Forms.Label();
            grpLicenseInfo = new System.Windows.Forms.GroupBox();
            lblLicenseInfo = new System.Windows.Forms.Label();
            picApplicant = new System.Windows.Forms.PictureBox();
            btnClose = new System.Windows.Forms.Button();
            lnkLicenseHistory = new System.Windows.Forms.LinkLabel();
            SuspendLayout();
            lblTitle.AutoSize = false;
            lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitle.Height = 130;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 23F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.Firebrick;
            lblTitle.Text = "Driver International License Info";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            grpLicenseInfo.Location = new System.Drawing.Point(16, 140);
            grpLicenseInfo.Size = new System.Drawing.Size(852, 248);
            grpLicenseInfo.Text = "Driver International License Info";
            lblLicenseInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            lblLicenseInfo.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            lblLicenseInfo.Padding = new System.Windows.Forms.Padding(16);
            grpLicenseInfo.Controls.Add(lblLicenseInfo);
            picApplicant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picApplicant.Location = new System.Drawing.Point(684, 186);
            picApplicant.Size = new System.Drawing.Size(168, 168);
            picApplicant.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            btnClose.Location = new System.Drawing.Point(741, 405);
            btnClose.Size = new System.Drawing.Size(127, 40);
            btnClose.Text = "Close";
            btnClose.Click += new System.EventHandler(btnClose_Click);
            lnkLicenseHistory.AutoSize = true;
            lnkLicenseHistory.Location = new System.Drawing.Point(25, 415);
            lnkLicenseHistory.Text = "Show License History";
            lnkLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(lnkLicenseHistory_LinkClicked);
            Controls.Add(lblTitle);
            Controls.Add(grpLicenseInfo);
            Controls.Add(picApplicant);
            Controls.Add(btnClose);
            Controls.Add(lnkLicenseHistory);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(884, 460);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "International Driver Info";
            ResumeLayout(false);
        }
    }
}
