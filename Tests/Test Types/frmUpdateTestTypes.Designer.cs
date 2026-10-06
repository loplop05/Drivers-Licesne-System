namespace DVLD.Tests.Test_Types
{
    partial class frmUpdateTestTypes
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtFees = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.8F);
            this.label1.Location = new System.Drawing.Point(167, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Update Test Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.label2.Location = new System.Drawing.Point(54, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID : ";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.lblID.Location = new System.Drawing.Point(193, 118);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(36, 26);
            this.lblID.TabIndex = 2;
            this.lblID.Text = "??";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.label3.Location = new System.Drawing.Point(54, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "Title : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.label4.Location = new System.Drawing.Point(54, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 26);
            this.label4.TabIndex = 4;
            this.label4.Text = "Description :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.label5.Location = new System.Drawing.Point(54, 324);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 26);
            this.label5.TabIndex = 5;
            this.label5.Text = "Fees : ";
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.txtTitle.Location = new System.Drawing.Point(198, 176);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(408, 27);
            this.txtTitle.TabIndex = 6;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.txtDescription.Location = new System.Drawing.Point(198, 230);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(408, 71);
            this.txtDescription.TabIndex = 7;
            // 
            // txtFees
            // 
            this.txtFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.txtFees.Location = new System.Drawing.Point(198, 326);
            this.txtFees.Name = "txtFees";
            this.txtFees.Size = new System.Drawing.Size(408, 27);
            this.txtFees.TabIndex = 8;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(332, 386);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(108, 52);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(498, 386);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 52);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmUpdateTestTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 467);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtFees);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmUpdateTestTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUpdateTestTypes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtFees;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
    }
}
