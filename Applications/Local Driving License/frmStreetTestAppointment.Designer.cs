namespace DVLD.Applications.Local_Driving_License
{
    partial class frmStreetTestAppointment
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvStreetTestAppointments = new System.Windows.Forms.DataGridView();
            this.cmsAppointments = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddStreetTestAppointment = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ctrlLocalDrivingLicenseApplicationInfo1 = new DVLD.Applications.Local_Driving_License.ctrlLocalDrivingLicenseApplicationInfo();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStreetTestAppointments)).BeginInit();
            this.cmsAppointments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.8F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(300, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(378, 37);
            this.label1.TabIndex = 4;
            this.label1.Text = "Street Test Appointments";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.label2.Location = new System.Drawing.Point(12, 520);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Appointments : ";
            // 
            // dgvStreetTestAppointments
            // 
            this.dgvStreetTestAppointments.AllowUserToAddRows = false;
            this.dgvStreetTestAppointments.AllowUserToDeleteRows = false;
            this.dgvStreetTestAppointments.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvStreetTestAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStreetTestAppointments.ContextMenuStrip = this.cmsAppointments;
            this.dgvStreetTestAppointments.Location = new System.Drawing.Point(23, 564);
            this.dgvStreetTestAppointments.Name = "dgvStreetTestAppointments";
            this.dgvStreetTestAppointments.ReadOnly = true;
            this.dgvStreetTestAppointments.RowHeadersWidth = 51;
            this.dgvStreetTestAppointments.RowTemplate.Height = 24;
            this.dgvStreetTestAppointments.Size = new System.Drawing.Size(978, 193);
            this.dgvStreetTestAppointments.TabIndex = 0;
            // 
            // cmsAppointments
            // 
            this.cmsAppointments.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsAppointments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.cmsAppointments.Name = "cmsAppointments";
            this.cmsAppointments.Size = new System.Drawing.Size(146, 56);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLD.Properties.Resources.edit_322;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.Test_32;
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.takeTestToolStripMenuItem.Text = "Take Test ";
            // 
            // btnAddStreetTestAppointment
            // 
            this.btnAddStreetTestAppointment.Image = global::DVLD.Properties.Resources.AddAppointment_321;
            this.btnAddStreetTestAppointment.Location = new System.Drawing.Point(929, 500);
            this.btnAddStreetTestAppointment.Name = "btnAddStreetTestAppointment";
            this.btnAddStreetTestAppointment.Size = new System.Drawing.Size(72, 58);
            this.btnAddStreetTestAppointment.TabIndex = 1;
            this.btnAddStreetTestAppointment.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Street_Test_32;
            this.pictureBox1.Location = new System.Drawing.Point(460, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // ctrlLocalDrivingLicenseApplicationInfo1
            // 
            this.ctrlLocalDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(-4, 113);
            this.ctrlLocalDrivingLicenseApplicationInfo1.Name = "ctrlLocalDrivingLicenseApplicationInfo1";
            this.ctrlLocalDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(1040, 392);
            this.ctrlLocalDrivingLicenseApplicationInfo1.TabIndex = 3;
            // 
            // frmStreetTestAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 922);
            this.Controls.Add(this.dgvStreetTestAppointments);
            this.Controls.Add(this.btnAddStreetTestAppointment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrlLocalDrivingLicenseApplicationInfo1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmStreetTestAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmStreetTestAppointment";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStreetTestAppointments)).EndInit();
            this.cmsAppointments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.PictureBox pictureBox1; private System.Windows.Forms.Label label1; private ctrlLocalDrivingLicenseApplicationInfo ctrlLocalDrivingLicenseApplicationInfo1; private System.Windows.Forms.Label label2; private System.Windows.Forms.Button btnAddStreetTestAppointment; private System.Windows.Forms.DataGridView dgvStreetTestAppointments; private System.Windows.Forms.ContextMenuStrip cmsAppointments; private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem; private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
    }
}
