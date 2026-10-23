namespace DVLD.Applications.ReplaceLostOrDamagedLicense
{
    partial class frmReplaceLostOrDamagedLicense
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Label lblLicenseId;
        private System.Windows.Forms.TextBox txtLicenseId;
        private System.Windows.Forms.Button btnFindLicense;
        private System.Windows.Forms.GroupBox grpReplacementType;
        private System.Windows.Forms.RadioButton rdoDamagedLicense;
        private System.Windows.Forms.RadioButton rdoLostLicense;
        private DVLD.Applications.Controls.ctrlLocalDrivingLicenseInfo ctrlLicenseInfo;
        private System.Windows.Forms.GroupBox grpApplicationInfo;
        private System.Windows.Forms.Label lblApplicationId;
        private System.Windows.Forms.Label lblApplicationIdValue;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label lblApplicationDateValue;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblApplicationFeesValue;
        private System.Windows.Forms.Label lblNewLicenseId;
        private System.Windows.Forms.Label lblNewLicenseIdValue;
        private System.Windows.Forms.Label lblOldLicenseId;
        private System.Windows.Forms.Label lblOldLicenseIdValue;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblCreatedByValue;
        private System.Windows.Forms.LinkLabel lnkLicenseHistory;
        private System.Windows.Forms.LinkLabel lnkNewLicenseInfo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnIssueReplacement;

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
            grpReplacementType = new System.Windows.Forms.GroupBox();
            rdoDamagedLicense = new System.Windows.Forms.RadioButton();
            rdoLostLicense = new System.Windows.Forms.RadioButton();
            ctrlLicenseInfo = new DVLD.Applications.Controls.ctrlLocalDrivingLicenseInfo();
            grpApplicationInfo = new System.Windows.Forms.GroupBox();
            lblApplicationId = new System.Windows.Forms.Label();
            lblApplicationIdValue = new System.Windows.Forms.Label();
            lblApplicationDate = new System.Windows.Forms.Label();
            lblApplicationDateValue = new System.Windows.Forms.Label();
            lblApplicationFees = new System.Windows.Forms.Label();
            lblApplicationFeesValue = new System.Windows.Forms.Label();
            lblNewLicenseId = new System.Windows.Forms.Label();
            lblNewLicenseIdValue = new System.Windows.Forms.Label();
            lblOldLicenseId = new System.Windows.Forms.Label();
            lblOldLicenseIdValue = new System.Windows.Forms.Label();
            lblCreatedBy = new System.Windows.Forms.Label();
            lblCreatedByValue = new System.Windows.Forms.Label();
            lnkLicenseHistory = new System.Windows.Forms.LinkLabel();
            lnkNewLicenseInfo = new System.Windows.Forms.LinkLabel();
            btnClose = new System.Windows.Forms.Button();
            btnIssueReplacement = new System.Windows.Forms.Button();

            SuspendLayout();
            grpFilter.SuspendLayout();
            grpReplacementType.SuspendLayout();
            grpApplicationInfo.SuspendLayout();

            lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitle.Font = new System.Drawing.Font(
                "Segoe UI",
                22F,
                System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.Firebrick;
            lblTitle.Height = 75;
            lblTitle.Text = "Replacement for Damaged License";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            grpFilter.Location = new System.Drawing.Point(24, 82);
            grpFilter.Size = new System.Drawing.Size(600, 88);
            grpFilter.Text = "Filter";

            lblLicenseId.AutoSize = true;
            lblLicenseId.Font = new System.Drawing.Font(
                "Segoe UI",
                11F,
                System.Drawing.FontStyle.Bold);
            lblLicenseId.Location = new System.Drawing.Point(28, 35);
            lblLicenseId.Text = "LicenseID:";

            txtLicenseId.Font = new System.Drawing.Font("Segoe UI", 11F);
            txtLicenseId.Location = new System.Drawing.Point(170, 30);
            txtLicenseId.Size = new System.Drawing.Size(320, 27);

            btnFindLicense.Location = new System.Drawing.Point(515, 18);
            btnFindLicense.Size = new System.Drawing.Size(70, 52);
            btnFindLicense.Text = "Find";
            btnFindLicense.UseVisualStyleBackColor = true;
            btnFindLicense.Click += new System.EventHandler(btnFindLicense_Click);

            grpFilter.Controls.Add(lblLicenseId);
            grpFilter.Controls.Add(txtLicenseId);
            grpFilter.Controls.Add(btnFindLicense);

            grpReplacementType.Location = new System.Drawing.Point(635, 82);
            grpReplacementType.Size = new System.Drawing.Size(240, 88);
            grpReplacementType.Text = "Replacement For:";

            rdoDamagedLicense.AutoSize = true;
            rdoDamagedLicense.Checked = true;
            rdoDamagedLicense.Location = new System.Drawing.Point(12, 27);
            rdoDamagedLicense.Text = "Damaged License";
            rdoDamagedLicense.CheckedChanged += new System.EventHandler(replacementType_CheckedChanged);

            rdoLostLicense.AutoSize = true;
            rdoLostLicense.Location = new System.Drawing.Point(12, 54);
            rdoLostLicense.Text = "Lost License";
            rdoLostLicense.CheckedChanged += new System.EventHandler(replacementType_CheckedChanged);

            grpReplacementType.Controls.Add(rdoDamagedLicense);
            grpReplacementType.Controls.Add(rdoLostLicense);

            ctrlLicenseInfo.Location = new System.Drawing.Point(20, 182);
            ctrlLicenseInfo.Size = new System.Drawing.Size(870, 335);

            grpApplicationInfo.Location = new System.Drawing.Point(23, 525);
            grpApplicationInfo.Size = new System.Drawing.Size(864, 135);
            grpApplicationInfo.Text = "Application Info for License Replacement";

            AddApplicationInfoLabel(
                grpApplicationInfo,
                lblApplicationId,
                "L.R.Application ID:",
                10,
                30);
            AddApplicationInfoValue(
                grpApplicationInfo,
                lblApplicationIdValue,
                215,
                30);

            AddApplicationInfoLabel(
                grpApplicationInfo,
                lblApplicationDate,
                "Application Date:",
                10,
                65);
            AddApplicationInfoValue(
                grpApplicationInfo,
                lblApplicationDateValue,
                215,
                65);

            AddApplicationInfoLabel(
                grpApplicationInfo,
                lblApplicationFees,
                "Application Fees:",
                10,
                100);
            AddApplicationInfoValue(
                grpApplicationInfo,
                lblApplicationFeesValue,
                215,
                100);

            AddApplicationInfoLabel(
                grpApplicationInfo,
                lblNewLicenseId,
                "Replaced License ID:",
                405,
                30);
            AddApplicationInfoValue(
                grpApplicationInfo,
                lblNewLicenseIdValue,
                625,
                30);

            AddApplicationInfoLabel(
                grpApplicationInfo,
                lblOldLicenseId,
                "Old License ID:",
                405,
                65);
            AddApplicationInfoValue(
                grpApplicationInfo,
                lblOldLicenseIdValue,
                625,
                65);

            AddApplicationInfoLabel(
                grpApplicationInfo,
                lblCreatedBy,
                "Created By:",
                405,
                100);
            AddApplicationInfoValue(
                grpApplicationInfo,
                lblCreatedByValue,
                625,
                100);

            lnkLicenseHistory.AutoSize = true;
            lnkLicenseHistory.Location = new System.Drawing.Point(34, 680);
            lnkLicenseHistory.Text = "Show Licenses History";
            lnkLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
                lnkLicenseHistory_LinkClicked);

            lnkNewLicenseInfo.AutoSize = true;
            lnkNewLicenseInfo.Location = new System.Drawing.Point(225, 680);
            lnkNewLicenseInfo.Text = "Show New License Info";
            lnkNewLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
                lnkNewLicenseInfo_LinkClicked);

            btnClose.Location = new System.Drawing.Point(615, 672);
            btnClose.Size = new System.Drawing.Size(126, 42);
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += new System.EventHandler(btnClose_Click);

            btnIssueReplacement.Location = new System.Drawing.Point(747, 672);
            btnIssueReplacement.Size = new System.Drawing.Size(140, 42);
            btnIssueReplacement.Text = "Issue Replacement";
            btnIssueReplacement.UseVisualStyleBackColor = true;
            btnIssueReplacement.Click += new System.EventHandler(btnIssueReplacement_Click);

            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new System.Drawing.Size(910, 730);
            Controls.Add(lblTitle);
            Controls.Add(grpFilter);
            Controls.Add(grpReplacementType);
            Controls.Add(ctrlLicenseInfo);
            Controls.Add(grpApplicationInfo);
            Controls.Add(lnkLicenseHistory);
            Controls.Add(lnkNewLicenseInfo);
            Controls.Add(btnClose);
            Controls.Add(btnIssueReplacement);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmReplaceLostOrDamagedLicense";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Replacement for Damaged License";

            grpApplicationInfo.ResumeLayout(false);
            grpApplicationInfo.PerformLayout();
            grpReplacementType.ResumeLayout(false);
            grpReplacementType.PerformLayout();
            grpFilter.ResumeLayout(false);
            grpFilter.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void AddApplicationInfoLabel(
            System.Windows.Forms.Control parent,
            System.Windows.Forms.Label label,
            string text,
            int x,
            int y)
        {
            label.AutoSize = true;
            label.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold);
            label.Location = new System.Drawing.Point(x, y);
            label.Text = text;
            parent.Controls.Add(label);
        }

        private void AddApplicationInfoValue(
            System.Windows.Forms.Control parent,
            System.Windows.Forms.Label label,
            int x,
            int y)
        {
            label.AutoSize = true;
            label.Font = new System.Drawing.Font("Segoe UI", 10F);
            label.Location = new System.Drawing.Point(x, y);
            label.Text = "[???]";
            parent.Controls.Add(label);
        }
    }
}
