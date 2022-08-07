namespace Saatphere_WIN
{
    partial class frmUpgradeMembership
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtExtendDays = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.chkExtend = new System.Windows.Forms.CheckBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblContacts = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lstServiceMode = new System.Windows.Forms.ListBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cmbMembershipType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgrdUserInfo = new System.Windows.Forms.DataGridView();
            this.btnStatus = new System.Windows.Forms.Button();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRenew = new System.Windows.Forms.Button();
            this.btnExtend = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpgrade = new System.Windows.Forms.Button();
            this.btnTransfertoTomorrow = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdUserInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRemark);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtExtendDays);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.chkExtend);
            this.groupBox1.Controls.Add(this.lblCustomerName);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblPrice);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblContacts);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblDuration);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lstServiceMode);
            this.groupBox1.Controls.Add(this.cmbStatus);
            this.groupBox1.Controls.Add(this.cmbMembershipType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(5, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(557, 326);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Upgrade Details";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(120, 192);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemark.Size = new System.Drawing.Size(252, 116);
            this.txtRemark.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(67, 195);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Remark:";
            // 
            // txtExtendDays
            // 
            this.txtExtendDays.Enabled = false;
            this.txtExtendDays.Location = new System.Drawing.Point(490, 158);
            this.txtExtendDays.Name = "txtExtendDays";
            this.txtExtendDays.Size = new System.Drawing.Size(42, 21);
            this.txtExtendDays.TabIndex = 21;
            this.txtExtendDays.TextChanged += new System.EventHandler(this.txtExtendDays_TextChanged);
            this.txtExtendDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExtendDays_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Enabled = false;
            this.label12.Location = new System.Drawing.Point(449, 161);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Days:";
            // 
            // chkExtend
            // 
            this.chkExtend.AutoSize = true;
            this.chkExtend.Location = new System.Drawing.Point(410, 135);
            this.chkExtend.Name = "chkExtend";
            this.chkExtend.Size = new System.Drawing.Size(120, 17);
            this.chkExtend.TabIndex = 19;
            this.chkExtend.Text = "Extend Membership";
            this.chkExtend.UseVisualStyleBackColor = true;
            this.chkExtend.CheckedChanged += new System.EventHandler(this.chkExtend_CheckedChanged);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblCustomerName.Location = new System.Drawing.Point(120, 21);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(112, 13);
            this.lblCustomerName.TabIndex = 18;
            this.lblCustomerName.Text = "<CustomerName>";
            this.lblCustomerName.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(57, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Customer:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(487, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Rupees";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(487, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Days";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(442, 55);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(13, 13);
            this.lblPrice.TabIndex = 14;
            this.lblPrice.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(384, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Price:";
            // 
            // lblContacts
            // 
            this.lblContacts.AutoSize = true;
            this.lblContacts.Location = new System.Drawing.Point(442, 39);
            this.lblContacts.Name = "lblContacts";
            this.lblContacts.Size = new System.Drawing.Size(13, 13);
            this.lblContacts.TabIndex = 12;
            this.lblContacts.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(384, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Contacts:";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(442, 23);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(13, 13);
            this.lblDuration.TabIndex = 10;
            this.lblDuration.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(384, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Duration:";
            // 
            // lstServiceMode
            // 
            this.lstServiceMode.FormattingEnabled = true;
            this.lstServiceMode.Items.AddRange(new object[] {
            "Email",
            "Courier",
            "Post",
            "Pickup"});
            this.lstServiceMode.Location = new System.Drawing.Point(120, 123);
            this.lstServiceMode.Name = "lstServiceMode";
            this.lstServiceMode.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstServiceMode.Size = new System.Drawing.Size(179, 56);
            this.lstServiceMode.TabIndex = 8;
            this.lstServiceMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstServiceMode_KeyDown);
            this.lstServiceMode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstServiceMode_MouseDown);
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Registered",
            "Active",
            "Dactive",
            "Hold"});
            this.cmbStatus.Location = new System.Drawing.Point(120, 80);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(179, 21);
            this.cmbStatus.TabIndex = 7;
            this.cmbStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbStatus_KeyDown);
            // 
            // cmbMembershipType
            // 
            this.cmbMembershipType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMembershipType.FormattingEnabled = true;
            this.cmbMembershipType.Location = new System.Drawing.Point(120, 53);
            this.cmbMembershipType.Name = "cmbMembershipType";
            this.cmbMembershipType.Size = new System.Drawing.Size(179, 21);
            this.cmbMembershipType.TabIndex = 5;
            this.cmbMembershipType.SelectedIndexChanged += new System.EventHandler(this.cmbMembershipType_SelectedIndexChanged);
            this.cmbMembershipType.TextChanged += new System.EventHandler(this.cmbMembershipType_TextChanged);
            this.cmbMembershipType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMembershipType_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Service Mode:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Status:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(329, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Details:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Membership Type:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgrdUserInfo);
            this.groupBox2.Controls.Add(this.btnStatus);
            this.groupBox2.Controls.Add(this.txtCustomerID);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(6, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(556, 159);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User Details";
            // 
            // dgrdUserInfo
            // 
            this.dgrdUserInfo.AllowUserToAddRows = false;
            this.dgrdUserInfo.AllowUserToDeleteRows = false;
            this.dgrdUserInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgrdUserInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdUserInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgrdUserInfo.Location = new System.Drawing.Point(6, 55);
            this.dgrdUserInfo.Name = "dgrdUserInfo";
            this.dgrdUserInfo.Size = new System.Drawing.Size(544, 96);
            this.dgrdUserInfo.TabIndex = 3;
            // 
            // btnStatus
            // 
            this.btnStatus.Location = new System.Drawing.Point(238, 18);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(75, 23);
            this.btnStatus.TabIndex = 2;
            this.btnStatus.Text = "&Status";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Location = new System.Drawing.Point(95, 20);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(137, 21);
            this.txtCustomerID.TabIndex = 1;
            this.txtCustomerID.TextChanged += new System.EventHandler(this.txtCustomerID_TextChanged);
            this.txtCustomerID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyDown);
            this.txtCustomerID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomerID_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer ID:";
            // 
            // btnRenew
            // 
            this.btnRenew.Enabled = false;
            this.btnRenew.Location = new System.Drawing.Point(165, 511);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(75, 30);
            this.btnRenew.TabIndex = 3;
            this.btnRenew.Text = "&Renew";
            this.btnRenew.UseVisualStyleBackColor = true;
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
            // 
            // btnExtend
            // 
            this.btnExtend.Enabled = false;
            this.btnExtend.Location = new System.Drawing.Point(239, 511);
            this.btnExtend.Name = "btnExtend";
            this.btnExtend.Size = new System.Drawing.Size(75, 30);
            this.btnExtend.TabIndex = 4;
            this.btnExtend.Text = "&Extend";
            this.btnExtend.UseVisualStyleBackColor = true;
            this.btnExtend.Click += new System.EventHandler(this.btnExtend_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(473, 511);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpgrade
            // 
            this.btnUpgrade.Enabled = false;
            this.btnUpgrade.Location = new System.Drawing.Point(90, 511);
            this.btnUpgrade.Name = "btnUpgrade";
            this.btnUpgrade.Size = new System.Drawing.Size(75, 30);
            this.btnUpgrade.TabIndex = 6;
            this.btnUpgrade.Text = "&Upgrade";
            this.btnUpgrade.UseVisualStyleBackColor = true;
            this.btnUpgrade.Click += new System.EventHandler(this.btnUpgrade_Click);
            // 
            // btnTransfertoTomorrow
            // 
            this.btnTransfertoTomorrow.Enabled = false;
            this.btnTransfertoTomorrow.Location = new System.Drawing.Point(314, 511);
            this.btnTransfertoTomorrow.Name = "btnTransfertoTomorrow";
            this.btnTransfertoTomorrow.Size = new System.Drawing.Size(127, 30);
            this.btnTransfertoTomorrow.TabIndex = 7;
            this.btnTransfertoTomorrow.Text = "Transfer to Tomorrow";
            this.btnTransfertoTomorrow.UseVisualStyleBackColor = true;
            this.btnTransfertoTomorrow.Click += new System.EventHandler(this.btnTransfertoTomorrow_Click);
            // 
            // frmUpgradeMembership
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 551);
            this.Controls.Add(this.btnTransfertoTomorrow);
            this.Controls.Add(this.btnUpgrade);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExtend);
            this.Controls.Add(this.btnRenew);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUpgradeMembership";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Upgrade Membership";
            this.Load += new System.EventHandler(this.frmUpgradeMembership_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdUserInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMembershipType;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.ListBox lstServiceMode;
        private System.Windows.Forms.Button btnRenew;
        private System.Windows.Forms.Button btnExtend;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpgrade;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblContacts;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtExtendDays;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkExtend;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dgrdUserInfo;
        private System.Windows.Forms.Button btnTransfertoTomorrow;
    }
}