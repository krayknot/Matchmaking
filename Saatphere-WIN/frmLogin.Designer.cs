namespace Saatphere_WIN
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnShreeshaadi = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkRememberMe = new System.Windows.Forms.CheckBox();
            this.cmbLoginAs = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbUsernames = new System.Windows.Forms.ComboBox();
            this.cmbFranchisees = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblHeading = new System.Windows.Forms.Label();
            this.lblDI = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnShreeshaadi);
            this.groupBox1.Location = new System.Drawing.Point(465, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 129);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter your credentials:";
            // 
            // btnShreeshaadi
            // 
            this.btnShreeshaadi.Location = new System.Drawing.Point(14, 39);
            this.btnShreeshaadi.Name = "btnShreeshaadi";
            this.btnShreeshaadi.Size = new System.Drawing.Size(75, 23);
            this.btnShreeshaadi.TabIndex = 10;
            this.btnShreeshaadi.Text = "&Shreeshaadi";
            this.btnShreeshaadi.UseVisualStyleBackColor = true;
            this.btnShreeshaadi.Visible = false;
            this.btnShreeshaadi.Click += new System.EventHandler(this.btnShreeshaadi_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(95, 111);
            this.txtUsername.MaxLength = 50;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(187, 21);
            this.txtUsername.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Username:";
            // 
            // chkRememberMe
            // 
            this.chkRememberMe.AutoSize = true;
            this.chkRememberMe.Location = new System.Drawing.Point(95, 195);
            this.chkRememberMe.Name = "chkRememberMe";
            this.chkRememberMe.Size = new System.Drawing.Size(94, 17);
            this.chkRememberMe.TabIndex = 3;
            this.chkRememberMe.Text = "Remember Me";
            this.chkRememberMe.UseVisualStyleBackColor = true;
            // 
            // cmbLoginAs
            // 
            this.cmbLoginAs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoginAs.FormattingEnabled = true;
            this.cmbLoginAs.Items.AddRange(new object[] {
            "Administrator",
            "Customer",
            "Franchisee"});
            this.cmbLoginAs.Location = new System.Drawing.Point(95, 168);
            this.cmbLoginAs.Name = "cmbLoginAs";
            this.cmbLoginAs.Size = new System.Drawing.Size(171, 21);
            this.cmbLoginAs.TabIndex = 2;
            this.cmbLoginAs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLoginAs_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Login as:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(95, 141);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(187, 21);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // cmbUsernames
            // 
            this.cmbUsernames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsernames.FormattingEnabled = true;
            this.cmbUsernames.Location = new System.Drawing.Point(465, 43);
            this.cmbUsernames.Name = "cmbUsernames";
            this.cmbUsernames.Size = new System.Drawing.Size(187, 21);
            this.cmbUsernames.TabIndex = 9;
            this.cmbUsernames.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbUsernames_MouseClick);
            // 
            // cmbFranchisees
            // 
            this.cmbFranchisees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFranchisees.FormattingEnabled = true;
            this.cmbFranchisees.Items.AddRange(new object[] {
            "Administrator",
            "Customer",
            "Franchisee"});
            this.cmbFranchisees.Location = new System.Drawing.Point(465, 15);
            this.cmbFranchisees.Name = "cmbFranchisees";
            this.cmbFranchisees.Size = new System.Drawing.Size(171, 21);
            this.cmbFranchisees.TabIndex = 7;
            this.cmbFranchisees.SelectedIndexChanged += new System.EventHandler(this.cmbFranchisees_SelectedIndexChanged);
            this.cmbFranchisees.Click += new System.EventHandler(this.cmbFranchisees_Click);
            this.cmbFranchisees.Leave += new System.EventHandler(this.cmbFranchisees_Leave);
            this.cmbFranchisees.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbFranchisees_MouseClick);
            this.cmbFranchisees.MouseLeave += new System.EventHandler(this.cmbFranchisees_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(415, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Branch:";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(271, 232);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 28);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(190, 232);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 28);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "&Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblVersion);
            this.panel1.Location = new System.Drawing.Point(465, 247);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(317, 93);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(40, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(69, 43);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(49, 13);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "Version: ";
            this.lblVersion.Visible = false;
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(26, 64);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(133, 19);
            this.lblHeading.TabIndex = 1;
            this.lblHeading.Text = "{application name}";
            // 
            // lblDI
            // 
            this.lblDI.AutoSize = true;
            this.lblDI.Location = new System.Drawing.Point(462, 76);
            this.lblDI.Name = "lblDI";
            this.lblDI.Size = new System.Drawing.Size(92, 13);
            this.lblDI.TabIndex = 3;
            this.lblDI.Text = "DateTimePattern:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(359, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.lblHeading);
            this.panel2.Controls.Add(this.chkRememberMe);
            this.panel2.Controls.Add(this.txtUsername);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnLogin);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtPassword);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.cmbLoginAs);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(359, 274);
            this.panel2.TabIndex = 12;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(5, 254);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(65, 13);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(358, 273);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblDI);
            this.Controls.Add(this.cmbUsernames);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbFranchisees);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbLoginAs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox chkRememberMe;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblDI;
        private System.Windows.Forms.ComboBox cmbFranchisees;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbUsernames;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnShreeshaadi;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}