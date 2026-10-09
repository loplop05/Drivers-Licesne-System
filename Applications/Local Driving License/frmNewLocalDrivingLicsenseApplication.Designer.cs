namespace DVLD.Applications.Local_Driving_License
{
    partial class frmNewLocalDrivingLicsenseApplication
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
            this.tcAddNewUser = new System.Windows.Forms.TabControl();
            this.tabPersonalInfo = new System.Windows.Forms.TabPage();
            this.btnNextTab = new System.Windows.Forms.Button();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.btnFindPerson = new System.Windows.Forms.Button();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ctrlPersonDetails1 = new DVLD.People.Controls.ctrlPersonDetails();
            this.tpApplicationInfo = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDLapplictionID = new System.Windows.Forms.Label();
            this.lblApplictionDate = new System.Windows.Forms.Label();
            this.cbLicsenseClass = new System.Windows.Forms.ComboBox();
            this.lblApplictionFees = new System.Windows.Forms.Label();
            this.lblCreatedByUser = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tcAddNewUser.SuspendLayout();
            this.tabPersonalInfo.SuspendLayout();
            this.tpApplicationInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcAddNewUser
            // 
            this.tcAddNewUser.Controls.Add(this.tabPersonalInfo);
            this.tcAddNewUser.Controls.Add(this.tpApplicationInfo);
            this.tcAddNewUser.Location = new System.Drawing.Point(7, 46);
            this.tcAddNewUser.Name = "tcAddNewUser";
            this.tcAddNewUser.SelectedIndex = 0;
            this.tcAddNewUser.Size = new System.Drawing.Size(1068, 579);
            this.tcAddNewUser.TabIndex = 1;
            // 
            // tabPersonalInfo
            // 
            this.tabPersonalInfo.Controls.Add(this.btnNextTab);
            this.tabPersonalInfo.Controls.Add(this.btnAddNewPerson);
            this.tabPersonalInfo.Controls.Add(this.btnFindPerson);
            this.tabPersonalInfo.Controls.Add(this.txtFilterValue);
            this.tabPersonalInfo.Controls.Add(this.cbFilterBy);
            this.tabPersonalInfo.Controls.Add(this.label5);
            this.tabPersonalInfo.Controls.Add(this.ctrlPersonDetails1);
            this.tabPersonalInfo.Location = new System.Drawing.Point(4, 25);
            this.tabPersonalInfo.Name = "tabPersonalInfo";
            this.tabPersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPersonalInfo.Size = new System.Drawing.Size(1060, 550);
            this.tabPersonalInfo.TabIndex = 0;
            this.tabPersonalInfo.Text = "Personal Info";
            this.tabPersonalInfo.UseVisualStyleBackColor = true;
            // 
            // btnNextTab
            // 
            this.btnNextTab.Location = new System.Drawing.Point(900, 510);
            this.btnNextTab.Name = "btnNextTab";
            this.btnNextTab.Size = new System.Drawing.Size(87, 34);
            this.btnNextTab.TabIndex = 6;
            this.btnNextTab.Text = "Next";
            this.btnNextTab.UseVisualStyleBackColor = true;
            this.btnNextTab.Click += new System.EventHandler(this.btnNextTab_Click);
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.Image = global::DVLD.Properties.Resources.AddPerson_323;
            this.btnAddNewPerson.Location = new System.Drawing.Point(726, 58);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(51, 41);
            this.btnAddNewPerson.TabIndex = 5;
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            // 
            // btnFindPerson
            // 
            this.btnFindPerson.Image = global::DVLD.Properties.Resources.SearchPerson3;
            this.btnFindPerson.Location = new System.Drawing.Point(645, 58);
            this.btnFindPerson.Name = "btnFindPerson";
            this.btnFindPerson.Size = new System.Drawing.Size(51, 41);
            this.btnFindPerson.TabIndex = 4;
            this.btnFindPerson.UseVisualStyleBackColor = true;
            this.btnFindPerson.Click += new System.EventHandler(this.btnFindPerson_Click);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterValue.Location = new System.Drawing.Point(369, 64);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(225, 30);
            this.txtFilterValue.TabIndex = 3;
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Location = new System.Drawing.Point(201, 68);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(150, 28);
            this.cbFilterBy.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(109, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 22);
            this.label5.TabIndex = 1;
            this.label5.Text = "Find By : ";
            // 
            // ctrlPersonDetails1
            // 
            this.ctrlPersonDetails1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ctrlPersonDetails1.Location = new System.Drawing.Point(80, 105);
            this.ctrlPersonDetails1.Name = "ctrlPersonDetails1";
            this.ctrlPersonDetails1.Size = new System.Drawing.Size(875, 399);
            this.ctrlPersonDetails1.TabIndex = 0;
            // 
            // tpApplicationInfo
            // 
            this.tpApplicationInfo.Controls.Add(this.lblCreatedByUser);
            this.tpApplicationInfo.Controls.Add(this.lblApplictionFees);
            this.tpApplicationInfo.Controls.Add(this.cbLicsenseClass);
            this.tpApplicationInfo.Controls.Add(this.lblApplictionDate);
            this.tpApplicationInfo.Controls.Add(this.lblDLapplictionID);
            this.tpApplicationInfo.Controls.Add(this.label6);
            this.tpApplicationInfo.Controls.Add(this.label4);
            this.tpApplicationInfo.Controls.Add(this.label3);
            this.tpApplicationInfo.Controls.Add(this.label2);
            this.tpApplicationInfo.Controls.Add(this.label1);
            this.tpApplicationInfo.Location = new System.Drawing.Point(4, 25);
            this.tpApplicationInfo.Name = "tpApplicationInfo";
            this.tpApplicationInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpApplicationInfo.Size = new System.Drawing.Size(1060, 550);
            this.tpApplicationInfo.TabIndex = 1;
            this.tpApplicationInfo.Text = "Application Info";
            this.tpApplicationInfo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(89, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "D.L Application ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(89, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Application Date :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(89, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Licsense Class : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(89, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "ApplictonFees : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(89, 319);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "Created By : ";
            // 
            // lblDLapplictionID
            // 
            this.lblDLapplictionID.AutoSize = true;
            this.lblDLapplictionID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblDLapplictionID.Location = new System.Drawing.Point(289, 74);
            this.lblDLapplictionID.Name = "lblDLapplictionID";
            this.lblDLapplictionID.Size = new System.Drawing.Size(67, 25);
            this.lblDLapplictionID.TabIndex = 5;
            this.lblDLapplictionID.Text = "?????";
            // 
            // lblApplictionDate
            // 
            this.lblApplictionDate.AutoSize = true;
            this.lblApplictionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblApplictionDate.Location = new System.Drawing.Point(289, 136);
            this.lblApplictionDate.Name = "lblApplictionDate";
            this.lblApplictionDate.Size = new System.Drawing.Size(67, 25);
            this.lblApplictionDate.TabIndex = 6;
            this.lblApplictionDate.Text = "?????";
            // 
            // cbLicsenseClass
            // 
            this.cbLicsenseClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbLicsenseClass.FormattingEnabled = true;
            this.cbLicsenseClass.Location = new System.Drawing.Point(276, 198);
            this.cbLicsenseClass.Name = "cbLicsenseClass";
            this.cbLicsenseClass.Size = new System.Drawing.Size(329, 33);
            this.cbLicsenseClass.TabIndex = 7;
            // 
            // lblApplictionFees
            // 
            this.lblApplictionFees.AutoSize = true;
            this.lblApplictionFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblApplictionFees.Location = new System.Drawing.Point(271, 259);
            this.lblApplictionFees.Name = "lblApplictionFees";
            this.lblApplictionFees.Size = new System.Drawing.Size(56, 25);
            this.lblApplictionFees.TabIndex = 8;
            this.lblApplictionFees.Text = "????";
            // 
            // lblCreatedByUser
            // 
            this.lblCreatedByUser.AutoSize = true;
            this.lblCreatedByUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblCreatedByUser.Location = new System.Drawing.Point(252, 319);
            this.lblCreatedByUser.Name = "lblCreatedByUser";
            this.lblCreatedByUser.Size = new System.Drawing.Size(56, 25);
            this.lblCreatedByUser.TabIndex = 9;
            this.lblCreatedByUser.Text = "????";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(919, 631);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(122, 44);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(741, 631);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 44);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close ";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // frmNewLocalDrivingLicsenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 694);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tcAddNewUser);
            this.Name = "frmNewLocalDrivingLicsenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNewLocalDrivingLicsenseApplication";
            this.tcAddNewUser.ResumeLayout(false);
            this.tabPersonalInfo.ResumeLayout(false);
            this.tabPersonalInfo.PerformLayout();
            this.tpApplicationInfo.ResumeLayout(false);
            this.tpApplicationInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcAddNewUser;
        private System.Windows.Forms.TabPage tabPersonalInfo;
        private System.Windows.Forms.Button btnNextTab;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.Button btnFindPerson;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label5;
        private People.Controls.ctrlPersonDetails ctrlPersonDetails1;
        private System.Windows.Forms.TabPage tpApplicationInfo;
        private System.Windows.Forms.Label lblApplictionDate;
        private System.Windows.Forms.Label lblDLapplictionID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCreatedByUser;
        private System.Windows.Forms.Label lblApplictionFees;
        private System.Windows.Forms.ComboBox cbLicsenseClass;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}