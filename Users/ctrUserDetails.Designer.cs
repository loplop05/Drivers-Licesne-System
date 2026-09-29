namespace DVLD.Users
{
    partial class ctrlUserDetails
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlPersonDetails1 = new DVLD.People.Controls.ctrlPersonDetails();
            this.ctrlLoginInfo1 = new DVLD.Users.ctrlLoginInfo();
            this.SuspendLayout();
            // 
            // ctrlPersonDetails1
            // 
            this.ctrlPersonDetails1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ctrlPersonDetails1.Location = new System.Drawing.Point(81, 49);
            this.ctrlPersonDetails1.Name = "ctrlPersonDetails1";
            this.ctrlPersonDetails1.Size = new System.Drawing.Size(818, 403);
            this.ctrlPersonDetails1.TabIndex = 0;
            // 
            // ctrlLoginInfo1
            // 
            this.ctrlLoginInfo1.Location = new System.Drawing.Point(81, 481);
            this.ctrlLoginInfo1.Name = "ctrlLoginInfo1";
            this.ctrlLoginInfo1.Size = new System.Drawing.Size(818, 78);
            this.ctrlLoginInfo1.TabIndex = 1;
            // 
            // ctrlUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlLoginInfo1);
            this.Controls.Add(this.ctrlPersonDetails1);
            this.Name = "ctrlUserDetails";
            this.Size = new System.Drawing.Size(941, 572);
            this.ResumeLayout(false);

        }

        #endregion

        private People.Controls.ctrlPersonDetails ctrlPersonDetails1;
        private ctrlLoginInfo ctrlLoginInfo1;
    }
}
