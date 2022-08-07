namespace Saatphere_WIN
{
    partial class frmUpdateLocalRecord
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
            this.txtProfileId = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.cmbDestDatabase = new System.Windows.Forms.ComboBox();
            this.txtDestPassword = new System.Windows.Forms.TextBox();
            this.txtDestUsername = new System.Windows.Forms.TextBox();
            this.txtDestServer = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbDestDatabase);
            this.groupBox1.Controls.Add(this.txtDestPassword);
            this.groupBox1.Controls.Add(this.txtDestUsername);
            this.groupBox1.Controls.Add(this.txtDestServer);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtProfileId);
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 165);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server and Biodata Details";
            // 
            // txtProfileId
            // 
            this.txtProfileId.Location = new System.Drawing.Point(106, 131);
            this.txtProfileId.Name = "txtProfileId";
            this.txtProfileId.Size = new System.Drawing.Size(105, 21);
            this.txtProfileId.TabIndex = 0;
            this.txtProfileId.Text = "1973";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(140, 176);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(221, 176);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(59, 176);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 33;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // cmbDestDatabase
            // 
            this.cmbDestDatabase.FormattingEnabled = true;
            this.cmbDestDatabase.Location = new System.Drawing.Point(106, 104);
            this.cmbDestDatabase.Name = "cmbDestDatabase";
            this.cmbDestDatabase.Size = new System.Drawing.Size(132, 21);
            this.cmbDestDatabase.TabIndex = 31;
            this.cmbDestDatabase.Text = "sasatpherelocalnew";
            // 
            // txtDestPassword
            // 
            this.txtDestPassword.Location = new System.Drawing.Point(106, 78);
            this.txtDestPassword.Name = "txtDestPassword";
            this.txtDestPassword.PasswordChar = '*';
            this.txtDestPassword.Size = new System.Drawing.Size(105, 21);
            this.txtDestPassword.TabIndex = 30;
            this.txtDestPassword.Text = "12345";
            // 
            // txtDestUsername
            // 
            this.txtDestUsername.Location = new System.Drawing.Point(106, 52);
            this.txtDestUsername.Name = "txtDestUsername";
            this.txtDestUsername.Size = new System.Drawing.Size(105, 21);
            this.txtDestUsername.TabIndex = 29;
            this.txtDestUsername.Text = "sa";
            // 
            // txtDestServer
            // 
            this.txtDestServer.Location = new System.Drawing.Point(106, 26);
            this.txtDestServer.Name = "txtDestServer";
            this.txtDestServer.Size = new System.Drawing.Size(132, 21);
            this.txtDestServer.TabIndex = 28;
            this.txtDestServer.Text = "krayknot-pc";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Database:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(38, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Password:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(36, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Username:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(52, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Server:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Biodata ID:";
            // 
            // frmUpdateLocalRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 208);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUpdateLocalRecord";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Local Record";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtProfileId;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cmbDestDatabase;
        private System.Windows.Forms.TextBox txtDestPassword;
        private System.Windows.Forms.TextBox txtDestUsername;
        private System.Windows.Forms.TextBox txtDestServer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label label1;
    }
}