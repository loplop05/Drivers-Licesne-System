namespace DVLD.Applications.ReleaseDetainedLicense
{
    partial class frmReleaseDetainedLicense
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Label lblDetainId;
        private System.Windows.Forms.TextBox txtDetainId;
        private System.Windows.Forms.Button btnFindDetention;
        private DVLD.Applications.Controls.ctrlLocalDrivingLicenseInfo ctrlLicenseInfo;
        private System.Windows.Forms.GroupBox grpReleaseInfo;
        private System.Windows.Forms.Label lblDetainIdCaption;
        private System.Windows.Forms.Label lblDetainIdValue;
        private System.Windows.Forms.Label lblLicenseIdCaption;
        private System.Windows.Forms.Label lblLicenseIdValue;
        private System.Windows.Forms.Label lblDetainDateCaption;
        private System.Windows.Forms.Label lblDetainDateValue;
        private System.Windows.Forms.Label lblFineFeesCaption;
        private System.Windows.Forms.Label lblFineFeesValue;
        private System.Windows.Forms.Label lblApplicationIdCaption;
        private System.Windows.Forms.Label lblApplicationIdValue;
        private System.Windows.Forms.LinkLabel lnkLicenseHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRelease;

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
            lblDetainId = new System.Windows.Forms.Label();
            txtDetainId = new System.Windows.Forms.TextBox();
            btnFindDetention = new System.Windows.Forms.Button();
            ctrlLicenseInfo = new DVLD.Applications.Controls.ctrlLocalDrivingLicenseInfo();
            grpReleaseInfo = new System.Windows.Forms.GroupBox();
            lblDetainIdCaption = new System.Windows.Forms.Label();
            lblDetainIdValue = new System.Windows.Forms.Label();
            lblLicenseIdCaption = new System.Windows.Forms.Label();
            lblLicenseIdValue = new System.Windows.Forms.Label();
            lblDetainDateCaption = new System.Windows.Forms.Label();
            lblDetainDateValue = new System.Windows.Forms.Label();
            lblFineFeesCaption = new System.Windows.Forms.Label();
            lblFineFeesValue = new System.Windows.Forms.Label();
            lblApplicationIdCaption = new System.Windows.Forms.Label();
            lblApplicationIdValue = new System.Windows.Forms.Label();
            lnkLicenseHistory = new System.Windows.Forms.LinkLabel();
            btnClose = new System.Windows.Forms.Button();
            btnRelease = new System.Windows.Forms.Button();

            SuspendLayout();
            grpFilter.SuspendLayout();
            grpReleaseInfo.SuspendLayout();

            lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitle.Font = new System.Drawing.Font(
                "Segoe UI",
                22F,
                System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.Firebrick;
            lblTitle.Height = 70;
            lblTitle.Text = "Release Detained License";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            grpFilter.Location = new System.Drawing.Point(25, 78);
            grpFilter.Size = new System.Drawing.Size(600, 75);
            grpFilter.Text = "Filter";

            lblDetainId.AutoSize = true;
            lblDetainId.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold);
            lblDetainId.Location = new System.Drawing.Point(20, 30);
            lblDetainId.Text = "Detain ID / License ID:";

            txtDetainId.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtDetainId.Location = new System.Drawing.Point(180, 26);
            txtDetainId.Size = new System.Drawing.Size(330, 27);

            btnFindDetention.Location = new System.Drawing.Point(525, 20);
            btnFindDetention.Size = new System.Drawing.Size(65, 38);
            btnFindDetention.Text = "Find";
            btnFindDetention.UseVisualStyleBackColor = true;
            btnFindDetention.Click += new System.EventHandler(btnFindDetention_Click);

            grpFilter.Controls.Add(lblDetainId);
            grpFilter.Controls.Add(txtDetainId);
            grpFilter.Controls.Add(btnFindDetention);

            ctrlLicenseInfo.Location = new System.Drawing.Point(20, 165);
            ctrlLicenseInfo.Size = new System.Drawing.Size(870, 335);

            grpReleaseInfo.Location = new System.Drawing.Point(25, 510);
            grpReleaseInfo.Size = new System.Drawing.Size(850, 90);
            grpReleaseInfo.Text = "Release Information";

            AddInfoLabel(grpReleaseInfo, lblDetainIdCaption, "Detain ID:", 20, 28);
            AddInfoValue(grpReleaseInfo, lblDetainIdValue, 130, 28);
            AddInfoLabel(grpReleaseInfo, lblLicenseIdCaption, "License ID:", 250, 28);
            AddInfoValue(grpReleaseInfo, lblLicenseIdValue, 355, 28);
            AddInfoLabel(grpReleaseInfo, lblDetainDateCaption, "Detain Date:", 475, 28);
            AddInfoValue(grpReleaseInfo, lblDetainDateValue, 595, 28);
            AddInfoLabel(grpReleaseInfo, lblFineFeesCaption, "Fine Fees:", 20, 60);
            AddInfoValue(grpReleaseInfo, lblFineFeesValue, 130, 60);
            AddInfoLabel(grpReleaseInfo, lblApplicationIdCaption, "Release Application ID:", 250, 60);
            AddInfoValue(grpReleaseInfo, lblApplicationIdValue, 435, 60);

            lnkLicenseHistory.AutoSize = true;
            lnkLicenseHistory.Location = new System.Drawing.Point(30, 620);
            lnkLicenseHistory.Text = "Show Licenses History";
            lnkLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
                lnkLicenseHistory_LinkClicked);

            btnClose.Location = new System.Drawing.Point(650, 610);
            btnClose.Size = new System.Drawing.Size(110, 40);
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += new System.EventHandler(btnClose_Click);

            btnRelease.Location = new System.Drawing.Point(770, 610);
            btnRelease.Size = new System.Drawing.Size(105, 40);
            btnRelease.Text = "Release";
            btnRelease.UseVisualStyleBackColor = true;
            btnRelease.Click += new System.EventHandler(btnRelease_Click);

            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new System.Drawing.Size(910, 670);
            Controls.Add(lblTitle);
            Controls.Add(grpFilter);
            Controls.Add(ctrlLicenseInfo);
            Controls.Add(grpReleaseInfo);
            Controls.Add(lnkLicenseHistory);
            Controls.Add(btnClose);
            Controls.Add(btnRelease);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmReleaseDetainedLicense";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Release Detained License";

            grpReleaseInfo.ResumeLayout(false);
            grpReleaseInfo.PerformLayout();
            grpFilter.ResumeLayout(false);
            grpFilter.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void AddInfoLabel(
            System.Windows.Forms.Control parent,
            System.Windows.Forms.Label label,
            string text,
            int x,
            int y)
        {
            label.AutoSize = true;
            label.Font = new System.Drawing.Font(
                "Segoe UI",
                9F,
                System.Drawing.FontStyle.Bold);
            label.Location = new System.Drawing.Point(x, y);
            label.Text = text;
            parent.Controls.Add(label);
        }

        private void AddInfoValue(
            System.Windows.Forms.Control parent,
            System.Windows.Forms.Label label,
            int x,
            int y)
        {
            label.AutoSize = true;
            label.Font = new System.Drawing.Font("Segoe UI", 9F);
            label.Location = new System.Drawing.Point(x, y);
            label.Text = "[???]";
            parent.Controls.Add(label);
        }
    }
}
