using System;
using System.Drawing;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD.Applications.Local_Driving_License
{
    public class frmIssueDrivingLicense : Form
    {
        readonly int applicationID, userID; readonly TextBox notes = new TextBox();
        public int IssuedLicenseID { get; private set; }
        public frmIssueDrivingLicense(int applicationID, int userID)
        {
            this.applicationID = applicationID; this.userID = userID; Text = "Issue Driver License For the First Time"; StartPosition = FormStartPosition.CenterScreen; ClientSize = new Size(950, 620);
            var title = new Label { Text = Text, Font = new Font("Microsoft Sans Serif", 15, FontStyle.Bold), ForeColor = Color.DarkRed, AutoSize = true, Location = new Point(310, 20) };
            var info = new ctrlLocalDrivingLicenseApplicationInfo { Location = new Point(20, 70), Size = new Size(910, 392) }; info.LoadDrivingLicsenseApplicationInfo(applicationID);
            var notesLabel = new Label { Text = "Notes:", Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold), AutoSize = true, Location = new Point(30, 485) }; notes.Location = new Point(130, 480); notes.Size = new Size(780, 70); notes.Multiline = true;
            var close = new Button { Text = "Close", Location = new Point(650, 565), Size = new Size(120, 35) }; close.Click += (s, e) => Close(); var issue = new Button { Text = "Issue", Location = new Point(790, 565), Size = new Size(120, 35) }; issue.Click += Issue_Click;
            Controls.AddRange(new Control[] { title, info, notesLabel, notes, close, issue });
        }
        void Issue_Click(object sender, EventArgs e)
        {
            if (!clsLicenses.CanIssueFirstLicense(applicationID)) { MessageBox.Show("The applicant must pass all three tests and must not already have a license.", "Cannot Issue License", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            try { IssuedLicenseID = clsLicenses.IssueFirstLicense(applicationID, userID, notes.Text.Trim()); }
            catch (Exception ex) { MessageBox.Show("Database error while issuing the license:\n\n" + ex.ToString(), "Issue Failed", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (IssuedLicenseID <= 0) { MessageBox.Show("The license could not be issued.", "Issue Failed", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            MessageBox.Show("License issued successfully.\nLicense ID: " + IssuedLicenseID, "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information); DialogResult = DialogResult.OK; Close();
        }
    }
}
