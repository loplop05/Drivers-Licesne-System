namespace DVLD
{
    partial class frmMain
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.menuStrip4 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.currentUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.MsUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MSPeople = new System.Windows.Forms.ToolStripMenuItem();
            this.MsApplications = new System.Windows.Forms.MenuStrip();
            this.applicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drivingLicesesServicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDrivingLicsenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localLicsenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalLicsenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renewDrivingLicsenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceForLostOrDamagedLicsenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseDetainedDrivingLicsenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retakeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localDrivingLicsenseApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalLicsenseApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detainLicensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageApplicationTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageTestTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlTop.SuspendLayout();
            this.menuStrip4.SuspendLayout();
            this.menuStrip3.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.MsApplications.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTop.AutoSize = true;
            this.pnlTop.Controls.Add(this.menuStrip4);
            this.pnlTop.Controls.Add(this.menuStrip3);
            this.pnlTop.Controls.Add(this.menuStrip2);
            this.pnlTop.Controls.Add(this.menuStrip1);
            this.pnlTop.Controls.Add(this.MsApplications);
            this.pnlTop.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1609, 120);
            this.pnlTop.TabIndex = 1;
            // 
            // menuStrip4
            // 
            this.menuStrip4.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip4.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip4.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.menuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3});
            this.menuStrip4.Location = new System.Drawing.Point(1200, 30);
            this.menuStrip4.Name = "menuStrip4";
            this.menuStrip4.Size = new System.Drawing.Size(259, 58);
            this.menuStrip4.TabIndex = 9;
            this.menuStrip4.Text = "PeopleStripMenu";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentUserToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.signOutToolStripMenuItem});
            this.toolStripMenuItem3.Image = global::DVLD.Properties.Resources.account_settings_642;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(251, 54);
            this.toolStripMenuItem3.Text = "Account Settings";
            // 
            // currentUserToolStripMenuItem
            // 
            this.currentUserToolStripMenuItem.Image = global::DVLD.Properties.Resources.PersonDetails_321;
            this.currentUserToolStripMenuItem.Name = "currentUserToolStripMenuItem";
            this.currentUserToolStripMenuItem.Size = new System.Drawing.Size(312, 56);
            this.currentUserToolStripMenuItem.Text = "Current User Info";
            this.currentUserToolStripMenuItem.Click += new System.EventHandler(this.currentUserToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Image = global::DVLD.Properties.Resources.Password_32;
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(312, 56);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Image = global::DVLD.Properties.Resources.SignOut_64;
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(312, 56);
            this.signOutToolStripMenuItem.Text = "Sign Out";
            this.signOutToolStripMenuItem.Click += new System.EventHandler(this.signOutToolStripMenuItem_Click);
            // 
            // menuStrip3
            // 
            this.menuStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip3.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MsUsers});
            this.menuStrip3.Location = new System.Drawing.Point(950, 30);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Size = new System.Drawing.Size(142, 58);
            this.menuStrip3.TabIndex = 8;
            this.menuStrip3.Text = "PeopleStripMenu";
            // 
            // MsUsers
            // 
            this.MsUsers.Image = global::DVLD.Properties.Resources.Users_2_641;
            this.MsUsers.Name = "MsUsers";
            this.MsUsers.Size = new System.Drawing.Size(134, 54);
            this.MsUsers.Text = "Users";
            this.MsUsers.Click += new System.EventHandler(this.MsUsers_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(700, 30);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(157, 58);
            this.menuStrip2.TabIndex = 7;
            this.menuStrip2.Text = "PeopleStripMenu";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::DVLD.Properties.Resources.Drivers_641;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 54);
            this.toolStripMenuItem1.Text = "Drivers";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MSPeople});
            this.menuStrip1.Location = new System.Drawing.Point(450, 30);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(155, 58);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "PeopleStripMenu";
            // 
            // MSPeople
            // 
            this.MSPeople.Image = global::DVLD.Properties.Resources.People_64;
            this.MSPeople.Name = "MSPeople";
            this.MSPeople.Size = new System.Drawing.Size(147, 54);
            this.MSPeople.Text = "People";
            this.MSPeople.Click += new System.EventHandler(this.MSPeople_Click);
            // 
            // MsApplications
            // 
            this.MsApplications.Dock = System.Windows.Forms.DockStyle.None;
            this.MsApplications.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MsApplications.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.MsApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationsToolStripMenuItem});
            this.MsApplications.Location = new System.Drawing.Point(108, 30);
            this.MsApplications.Name = "MsApplications";
            this.MsApplications.Size = new System.Drawing.Size(364, 58);
            this.MsApplications.TabIndex = 5;
            this.MsApplications.Text = "ApplicationStripMenu";
            // 
            // applicationsToolStripMenuItem
            // 
            this.applicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drivingLicesesServicesToolStripMenuItem,
            this.manageApplicationsToolStripMenuItem,
            this.detainLicensesToolStripMenuItem,
            this.manageApplicationTypesToolStripMenuItem,
            this.manageTestTypesToolStripMenuItem});
            this.applicationsToolStripMenuItem.Image = global::DVLD.Properties.Resources.Applications_641;
            this.applicationsToolStripMenuItem.Name = "applicationsToolStripMenuItem";
            this.applicationsToolStripMenuItem.Size = new System.Drawing.Size(206, 54);
            this.applicationsToolStripMenuItem.Text = "Applications";
            // 
            // drivingLicesesServicesToolStripMenuItem
            // 
            this.drivingLicesesServicesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDrivingLicsenseToolStripMenuItem,
            this.renewDrivingLicsenseToolStripMenuItem,
            this.replaceForLostOrDamagedLicsenseToolStripMenuItem,
            this.releaseDetainedDrivingLicsenseToolStripMenuItem,
            this.retakeTestToolStripMenuItem});
            this.drivingLicesesServicesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drivingLicesesServicesToolStripMenuItem.Image = global::DVLD.Properties.Resources.Driver_License_48;
            this.drivingLicesesServicesToolStripMenuItem.Name = "drivingLicesesServicesToolStripMenuItem";
            this.drivingLicesesServicesToolStripMenuItem.Size = new System.Drawing.Size(404, 56);
            this.drivingLicesesServicesToolStripMenuItem.Text = "Driving Liceses Services";
            // 
            // newDrivingLicsenseToolStripMenuItem
            // 
            this.newDrivingLicsenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localLicsenseToolStripMenuItem,
            this.internationalLicsenseToolStripMenuItem});
            this.newDrivingLicsenseToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.newDrivingLicsenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.New_Driving_License_32;
            this.newDrivingLicsenseToolStripMenuItem.Name = "newDrivingLicsenseToolStripMenuItem";
            this.newDrivingLicsenseToolStripMenuItem.Size = new System.Drawing.Size(452, 56);
            this.newDrivingLicsenseToolStripMenuItem.Text = "New Driving Licsense ";
            // 
            // localLicsenseToolStripMenuItem
            // 
            this.localLicsenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.Local_321;
            this.localLicsenseToolStripMenuItem.Name = "localLicsenseToolStripMenuItem";
            this.localLicsenseToolStripMenuItem.Size = new System.Drawing.Size(314, 56);
            this.localLicsenseToolStripMenuItem.Text = "Local Licsense";
            this.localLicsenseToolStripMenuItem.Click += new System.EventHandler(this.localLicsenseToolStripMenuItem_Click);
            // 
            // internationalLicsenseToolStripMenuItem
            // 
            this.internationalLicsenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.International_32;
            this.internationalLicsenseToolStripMenuItem.Name = "internationalLicsenseToolStripMenuItem";
            this.internationalLicsenseToolStripMenuItem.Size = new System.Drawing.Size(314, 56);
            this.internationalLicsenseToolStripMenuItem.Text = "International Licsense";
            // 
            // renewDrivingLicsenseToolStripMenuItem
            // 
            this.renewDrivingLicsenseToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.renewDrivingLicsenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.Renew_Driving_License_32;
            this.renewDrivingLicsenseToolStripMenuItem.Name = "renewDrivingLicsenseToolStripMenuItem";
            this.renewDrivingLicsenseToolStripMenuItem.Size = new System.Drawing.Size(452, 56);
            this.renewDrivingLicsenseToolStripMenuItem.Text = "Renew Driving Licsense";
            // 
            // replaceForLostOrDamagedLicsenseToolStripMenuItem
            // 
            this.replaceForLostOrDamagedLicsenseToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.replaceForLostOrDamagedLicsenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.Damaged_Driving_License_32;
            this.replaceForLostOrDamagedLicsenseToolStripMenuItem.Name = "replaceForLostOrDamagedLicsenseToolStripMenuItem";
            this.replaceForLostOrDamagedLicsenseToolStripMenuItem.Size = new System.Drawing.Size(452, 56);
            this.replaceForLostOrDamagedLicsenseToolStripMenuItem.Text = "Replace for Lost or Damaged Licsense";
            // 
            // releaseDetainedDrivingLicsenseToolStripMenuItem
            // 
            this.releaseDetainedDrivingLicsenseToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.releaseDetainedDrivingLicsenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.Release_Detained_License_32;
            this.releaseDetainedDrivingLicsenseToolStripMenuItem.Name = "releaseDetainedDrivingLicsenseToolStripMenuItem";
            this.releaseDetainedDrivingLicsenseToolStripMenuItem.Size = new System.Drawing.Size(452, 56);
            this.releaseDetainedDrivingLicsenseToolStripMenuItem.Text = "Release Detained Driving Licsense";
            // 
            // retakeTestToolStripMenuItem
            // 
            this.retakeTestToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.retakeTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.Retake_Test_32;
            this.retakeTestToolStripMenuItem.Name = "retakeTestToolStripMenuItem";
            this.retakeTestToolStripMenuItem.Size = new System.Drawing.Size(452, 56);
            this.retakeTestToolStripMenuItem.Text = "Retake Test";
            // 
            // manageApplicationsToolStripMenuItem
            // 
            this.manageApplicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localDrivingLicsenseApplicationsToolStripMenuItem,
            this.internationalLicsenseApplicationsToolStripMenuItem});
            this.manageApplicationsToolStripMenuItem.Image = global::DVLD.Properties.Resources.Applications;
            this.manageApplicationsToolStripMenuItem.Name = "manageApplicationsToolStripMenuItem";
            this.manageApplicationsToolStripMenuItem.Size = new System.Drawing.Size(404, 56);
            this.manageApplicationsToolStripMenuItem.Text = "Manage Applications";
            // 
            // localDrivingLicsenseApplicationsToolStripMenuItem
            // 
            this.localDrivingLicsenseApplicationsToolStripMenuItem.Image = global::DVLD.Properties.Resources.Local_323;
            this.localDrivingLicsenseApplicationsToolStripMenuItem.Name = "localDrivingLicsenseApplicationsToolStripMenuItem";
            this.localDrivingLicsenseApplicationsToolStripMenuItem.Size = new System.Drawing.Size(490, 56);
            this.localDrivingLicsenseApplicationsToolStripMenuItem.Text = "Local Driving Licsense Applications";
            // 
            // internationalLicsenseApplicationsToolStripMenuItem
            // 
            this.internationalLicsenseApplicationsToolStripMenuItem.Image = global::DVLD.Properties.Resources.International_321;
            this.internationalLicsenseApplicationsToolStripMenuItem.Name = "internationalLicsenseApplicationsToolStripMenuItem";
            this.internationalLicsenseApplicationsToolStripMenuItem.Size = new System.Drawing.Size(490, 56);
            this.internationalLicsenseApplicationsToolStripMenuItem.Text = "International Licsense Applications";
            // 
            // detainLicensesToolStripMenuItem
            // 
            this.detainLicensesToolStripMenuItem.Image = global::DVLD.Properties.Resources.Detain_32;
            this.detainLicensesToolStripMenuItem.Name = "detainLicensesToolStripMenuItem";
            this.detainLicensesToolStripMenuItem.Size = new System.Drawing.Size(404, 56);
            this.detainLicensesToolStripMenuItem.Text = "Detain Licenses";
            // 
            // manageApplicationTypesToolStripMenuItem
            // 
            this.manageApplicationTypesToolStripMenuItem.Image = global::DVLD.Properties.Resources.Application_Types_64;
            this.manageApplicationTypesToolStripMenuItem.Name = "manageApplicationTypesToolStripMenuItem";
            this.manageApplicationTypesToolStripMenuItem.Size = new System.Drawing.Size(404, 56);
            this.manageApplicationTypesToolStripMenuItem.Text = "Manage Application Types";
            this.manageApplicationTypesToolStripMenuItem.Click += new System.EventHandler(this.manageApplicationTypesToolStripMenuItem_Click);
            // 
            // manageTestTypesToolStripMenuItem
            // 
            this.manageTestTypesToolStripMenuItem.Image = global::DVLD.Properties.Resources.Test_Type_64;
            this.manageTestTypesToolStripMenuItem.Name = "manageTestTypesToolStripMenuItem";
            this.manageTestTypesToolStripMenuItem.Size = new System.Drawing.Size(404, 56);
            this.manageTestTypesToolStripMenuItem.Text = "Manage Test Types";
            this.manageTestTypesToolStripMenuItem.Click += new System.EventHandler(this.manageTestTypesToolStripMenuItem_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlContent.AutoScroll = true;
            this.pnlContent.BackColor = System.Drawing.Color.Black;
            this.pnlContent.Location = new System.Drawing.Point(0, 120);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1609, 801);
            this.pnlContent.TabIndex = 3;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1609, 921);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlTop);
            this.MainMenuStrip = this.MsApplications;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DVLD - Driver and Vehicle Licensing Department";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.menuStrip4.ResumeLayout(false);
            this.menuStrip4.PerformLayout();
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.MsApplications.ResumeLayout(false);
            this.MsApplications.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.MenuStrip MsApplications;
        private System.Windows.Forms.ToolStripMenuItem applicationsToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MSPeople;
        private System.Windows.Forms.ToolStripMenuItem drivingLicesesServicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detainLicensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageApplicationTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageTestTypesToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.ToolStripMenuItem MsUsers;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem currentUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDrivingLicsenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renewDrivingLicsenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceForLostOrDamagedLicsenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseDetainedDrivingLicsenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retakeTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localLicsenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalLicsenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localDrivingLicsenseApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalLicsenseApplicationsToolStripMenuItem;
    }
}
