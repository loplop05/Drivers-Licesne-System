namespace DVLD.Applications.Controls
{
    partial class ctrlLocalDrivingLicenseInfo
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpLicenseInfo;
        private System.Windows.Forms.PictureBox picApplicant;
        private System.Windows.Forms.Label lblClass, lblName, lblLicenseId, lblIsActive, lblNationalNo, lblDateOfBirth, lblGender, lblDriverId, lblIssueDate, lblExpirationDate, lblIssueReason, lblIsDetained, lblNotes;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            grpLicenseInfo = new System.Windows.Forms.GroupBox();
            picApplicant = new System.Windows.Forms.PictureBox();
            lblClass = CreateValueLabel(); lblName = CreateValueLabel(); lblName.ForeColor = System.Drawing.Color.Firebrick; lblLicenseId = CreateValueLabel(); lblIsActive = CreateValueLabel(); lblNationalNo = CreateValueLabel(); lblDateOfBirth = CreateValueLabel(); lblGender = CreateValueLabel(); lblDriverId = CreateValueLabel(); lblIssueDate = CreateValueLabel(); lblExpirationDate = CreateValueLabel(); lblIssueReason = CreateValueLabel(); lblIsDetained = CreateValueLabel(); lblNotes = CreateValueLabel();
            SuspendLayout();
            grpLicenseInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            grpLicenseInfo.Text = "Driver License Info";
            AddRow("Class:", lblClass, 18, 35); AddRow("Name:", lblName, 18, 72); AddRow("License ID:", lblLicenseId, 18, 109); AddRow("National No:", lblNationalNo, 18, 146); AddRow("Gender:", lblGender, 18, 183); AddRow("Issue Date:", lblIssueDate, 18, 220); AddRow("Issue Reason:", lblIssueReason, 18, 257); AddRow("Notes:", lblNotes, 18, 294);
            AddRow("Is Active?", lblIsActive, 380, 109); AddRow("Date Of Birth:", lblDateOfBirth, 380, 146); AddRow("Driver ID:", lblDriverId, 380, 183); AddRow("Expiration Date:", lblExpirationDate, 380, 220); AddRow("Is Detained?", lblIsDetained, 380, 257);
            picApplicant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picApplicant.Location = new System.Drawing.Point(700, 45);
            picApplicant.Size = new System.Drawing.Size(150, 185);
            picApplicant.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            grpLicenseInfo.Controls.Add(picApplicant);
            Controls.Add(grpLicenseInfo);
            Size = new System.Drawing.Size(870, 335);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label CreateValueLabel()
        {
            return new System.Windows.Forms.Label { AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F), Text = "[???]" };
        }

        private void AddRow(string title, System.Windows.Forms.Label value, int x, int y)
        {
            grpLicenseInfo.Controls.Add(new System.Windows.Forms.Label { AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold), Location = new System.Drawing.Point(x, y), Text = title });
            value.Location = new System.Drawing.Point(x + 135, y);
            grpLicenseInfo.Controls.Add(value);
        }

        #endregion
    }
}
