namespace DVLD.Tests.Test_Types
{
    partial class frmManageTestTypes
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.dbvManageTestTypes = new System.Windows.Forms.DataGridView();
            this.cmsManageTestTypes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dbvManageTestTypes)).BeginInit();
            this.cmsManageTestTypes.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.8F);
            this.label1.Location = new System.Drawing.Point(274, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Test Types";
            // 
            // dbvManageTestTypes
            // 
            this.dbvManageTestTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbvManageTestTypes.ContextMenuStrip = this.cmsManageTestTypes;
            this.dbvManageTestTypes.Location = new System.Drawing.Point(131, 162);
            this.dbvManageTestTypes.Name = "dbvManageTestTypes";
            this.dbvManageTestTypes.RowHeadersWidth = 51;
            this.dbvManageTestTypes.RowTemplate.Height = 24;
            this.dbvManageTestTypes.Size = new System.Drawing.Size(703, 347);
            this.dbvManageTestTypes.TabIndex = 1;
            this.dbvManageTestTypes.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dbvManageTestTypes_CellMouseDown);
            // 
            // cmsManageTestTypes
            // 
            this.cmsManageTestTypes.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsManageTestTypes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTestToolStripMenuItem});
            this.cmsManageTestTypes.Name = "cmsManageTestTypes";
            this.cmsManageTestTypes.Size = new System.Drawing.Size(139, 28);
            // 
            // editTestToolStripMenuItem
            // 
            this.editTestToolStripMenuItem.Name = "editTestToolStripMenuItem";
            this.editTestToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.editTestToolStripMenuItem.Text = "Edit Test ";
            this.editTestToolStripMenuItem.Click += new System.EventHandler(this.editTestToolStripMenuItem_Click);
            // 
            // frmManageTestTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 572);
            this.Controls.Add(this.dbvManageTestTypes);
            this.Controls.Add(this.label1);
            this.Name = "frmManageTestTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmManageTestTypes";
            ((System.ComponentModel.ISupportInitialize)(this.dbvManageTestTypes)).EndInit();
            this.cmsManageTestTypes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dbvManageTestTypes;
        private System.Windows.Forms.ContextMenuStrip cmsManageTestTypes;
        private System.Windows.Forms.ToolStripMenuItem editTestToolStripMenuItem;
    }
}