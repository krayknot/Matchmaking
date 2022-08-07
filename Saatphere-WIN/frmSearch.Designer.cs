namespace Saatphere_WIN
{
    partial class frmSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearch));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbCustomers = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rdbAssignedExecutives = new System.Windows.Forms.RadioButton();
            this.cmbExecutives = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdbAssignedCustomers = new System.Windows.Forms.RadioButton();
            this.drpCity = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.rdbEmail = new System.Windows.Forms.RadioButton();
            this.rdbMobile = new System.Windows.Forms.RadioButton();
            this.rdbName = new System.Windows.Forms.RadioButton();
            this.rdbId = new System.Windows.Forms.RadioButton();
            this.rdbCity = new System.Windows.Forms.RadioButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgrdResults = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewBiodataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewBiodataDetailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.activateMembershipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deactivateMembershipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.switchFranchiseeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.resetCredentialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteBiodataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSelectedRecord = new System.Windows.Forms.Label();
            this.btnExporttoExcel = new System.Windows.Forms.Button();
            this.biodataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdResults)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbCustomers);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rdbAssignedExecutives);
            this.groupBox1.Controls.Add(this.cmbExecutives);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rdbAssignedCustomers);
            this.groupBox1.Controls.Add(this.drpCity);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtMobile);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.rdbEmail);
            this.groupBox1.Controls.Add(this.rdbMobile);
            this.groupBox1.Controls.Add(this.rdbName);
            this.groupBox1.Controls.Add(this.rdbId);
            this.groupBox1.Controls.Add(this.rdbCity);
            this.groupBox1.Location = new System.Drawing.Point(4, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(189, 454);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Filter(s)";
            // 
            // cmbCustomers
            // 
            this.cmbCustomers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomers.FormattingEnabled = true;
            this.cmbCustomers.Location = new System.Drawing.Point(26, 311);
            this.cmbCustomers.Name = "cmbCustomers";
            this.cmbCustomers.Size = new System.Drawing.Size(157, 21);
            this.cmbCustomers.TabIndex = 15;
            this.cmbCustomers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbCustomers_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Customers:";
            // 
            // rdbAssignedExecutives
            // 
            this.rdbAssignedExecutives.AutoSize = true;
            this.rdbAssignedExecutives.Location = new System.Drawing.Point(8, 276);
            this.rdbAssignedExecutives.Name = "rdbAssignedExecutives";
            this.rdbAssignedExecutives.Size = new System.Drawing.Size(146, 17);
            this.rdbAssignedExecutives.TabIndex = 13;
            this.rdbAssignedExecutives.TabStop = true;
            this.rdbAssignedExecutives.Text = "List Assigned Executives:";
            this.rdbAssignedExecutives.UseVisualStyleBackColor = true;
            // 
            // cmbExecutives
            // 
            this.cmbExecutives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExecutives.FormattingEnabled = true;
            this.cmbExecutives.Location = new System.Drawing.Point(26, 235);
            this.cmbExecutives.Name = "cmbExecutives";
            this.cmbExecutives.Size = new System.Drawing.Size(157, 21);
            this.cmbExecutives.TabIndex = 12;
            this.cmbExecutives.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbExecutives_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Executives:";
            // 
            // rdbAssignedCustomers
            // 
            this.rdbAssignedCustomers.AutoSize = true;
            this.rdbAssignedCustomers.Location = new System.Drawing.Point(8, 199);
            this.rdbAssignedCustomers.Name = "rdbAssignedCustomers";
            this.rdbAssignedCustomers.Size = new System.Drawing.Size(145, 17);
            this.rdbAssignedCustomers.TabIndex = 10;
            this.rdbAssignedCustomers.TabStop = true;
            this.rdbAssignedCustomers.Text = "List Assigned Customers:";
            this.rdbAssignedCustomers.UseVisualStyleBackColor = true;
            this.rdbAssignedCustomers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rdbAssignedCustomers_MouseClick);
            // 
            // drpCity
            // 
            this.drpCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpCity.FormattingEnabled = true;
            this.drpCity.Location = new System.Drawing.Point(26, 53);
            this.drpCity.Name = "drpCity";
            this.drpCity.Size = new System.Drawing.Size(157, 21);
            this.drpCity.TabIndex = 9;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(67, 160);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(116, 21);
            this.txtEmail.TabIndex = 8;
            this.txtEmail.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtEmail_MouseClick);
            this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmail_KeyDown);
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(67, 134);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(116, 21);
            this.txtMobile.TabIndex = 7;
            this.txtMobile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtMobile_MouseClick);
            this.txtMobile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMobile_KeyDown);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(67, 108);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(116, 21);
            this.txtName.TabIndex = 6;
            this.txtName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtName_MouseClick);
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(67, 83);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(116, 21);
            this.txtID.TabIndex = 5;
            this.txtID.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtID_MouseClick);
            this.txtID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtID_KeyDown);
            // 
            // rdbEmail
            // 
            this.rdbEmail.AutoSize = true;
            this.rdbEmail.Location = new System.Drawing.Point(8, 164);
            this.rdbEmail.Name = "rdbEmail";
            this.rdbEmail.Size = new System.Drawing.Size(53, 17);
            this.rdbEmail.TabIndex = 4;
            this.rdbEmail.TabStop = true;
            this.rdbEmail.Text = "Email:";
            this.rdbEmail.UseVisualStyleBackColor = true;
            // 
            // rdbMobile
            // 
            this.rdbMobile.AutoSize = true;
            this.rdbMobile.Location = new System.Drawing.Point(8, 137);
            this.rdbMobile.Name = "rdbMobile";
            this.rdbMobile.Size = new System.Drawing.Size(59, 17);
            this.rdbMobile.TabIndex = 3;
            this.rdbMobile.TabStop = true;
            this.rdbMobile.Text = "Mobile:";
            this.rdbMobile.UseVisualStyleBackColor = true;
            // 
            // rdbName
            // 
            this.rdbName.AutoSize = true;
            this.rdbName.Location = new System.Drawing.Point(8, 109);
            this.rdbName.Name = "rdbName";
            this.rdbName.Size = new System.Drawing.Size(56, 17);
            this.rdbName.TabIndex = 2;
            this.rdbName.TabStop = true;
            this.rdbName.Text = "Name:";
            this.rdbName.UseVisualStyleBackColor = true;
            // 
            // rdbId
            // 
            this.rdbId.AutoSize = true;
            this.rdbId.Location = new System.Drawing.Point(8, 83);
            this.rdbId.Name = "rdbId";
            this.rdbId.Size = new System.Drawing.Size(39, 17);
            this.rdbId.TabIndex = 1;
            this.rdbId.TabStop = true;
            this.rdbId.Text = "Id:";
            this.rdbId.UseVisualStyleBackColor = true;
            // 
            // rdbCity
            // 
            this.rdbCity.AutoSize = true;
            this.rdbCity.Location = new System.Drawing.Point(8, 34);
            this.rdbCity.Name = "rdbCity";
            this.rdbCity.Size = new System.Drawing.Size(48, 17);
            this.rdbCity.TabIndex = 0;
            this.rdbCity.TabStop = true;
            this.rdbCity.Text = "City:";
            this.rdbCity.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Silver;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(12, 461);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(177, 68);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgrdResults);
            this.groupBox2.Location = new System.Drawing.Point(199, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(788, 495);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Result(s)";
            // 
            // dgrdResults
            // 
            this.dgrdResults.AllowUserToAddRows = false;
            this.dgrdResults.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgrdResults.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgrdResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgrdResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdResults.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgrdResults.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgrdResults.Location = new System.Drawing.Point(3, 17);
            this.dgrdResults.Name = "dgrdResults";
            this.dgrdResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdResults.Size = new System.Drawing.Size(782, 472);
            this.dgrdResults.TabIndex = 0;
            this.dgrdResults.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrdResults_CellClick);
            this.dgrdResults.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgrdResults_CellMouseDown);
            this.dgrdResults.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgrdResults_MouseClick);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(906, 506);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(199, 506);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(77, 13);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "Total Records:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewBiodataToolStripMenuItem,
            this.viewBiodataDetailToolStripMenuItem,
            this.toolStripSeparator2,
            this.activateMembershipToolStripMenuItem,
            this.deactivateMembershipToolStripMenuItem,
            this.toolStripSeparator3,
            this.switchFranchiseeToolStripMenuItem,
            this.toolStripSeparator1,
            this.resetCredentialsToolStripMenuItem,
            this.toolStripSeparator4,
            this.biodataToolStripMenuItem,
            this.deleteBiodataToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(209, 226);
            // 
            // viewBiodataToolStripMenuItem
            // 
            this.viewBiodataToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewBiodataToolStripMenuItem.Image")));
            this.viewBiodataToolStripMenuItem.Name = "viewBiodataToolStripMenuItem";
            this.viewBiodataToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.viewBiodataToolStripMenuItem.Text = "View Biodata - Master...";
            this.viewBiodataToolStripMenuItem.Click += new System.EventHandler(this.viewBiodataToolStripMenuItem_Click);
            // 
            // viewBiodataDetailToolStripMenuItem
            // 
            this.viewBiodataDetailToolStripMenuItem.Name = "viewBiodataDetailToolStripMenuItem";
            this.viewBiodataDetailToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.viewBiodataDetailToolStripMenuItem.Text = "View Biodata - Detail...";
            this.viewBiodataDetailToolStripMenuItem.Click += new System.EventHandler(this.viewBiodataDetailToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(205, 6);
            // 
            // activateMembershipToolStripMenuItem
            // 
            this.activateMembershipToolStripMenuItem.Name = "activateMembershipToolStripMenuItem";
            this.activateMembershipToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.activateMembershipToolStripMenuItem.Text = "Activate Membership...";
            // 
            // deactivateMembershipToolStripMenuItem
            // 
            this.deactivateMembershipToolStripMenuItem.Name = "deactivateMembershipToolStripMenuItem";
            this.deactivateMembershipToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.deactivateMembershipToolStripMenuItem.Text = "Deactivate Membership...";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(205, 6);
            // 
            // switchFranchiseeToolStripMenuItem
            // 
            this.switchFranchiseeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("switchFranchiseeToolStripMenuItem.Image")));
            this.switchFranchiseeToolStripMenuItem.Name = "switchFranchiseeToolStripMenuItem";
            this.switchFranchiseeToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.switchFranchiseeToolStripMenuItem.Text = "Switch Franchisee...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(205, 6);
            // 
            // resetCredentialsToolStripMenuItem
            // 
            this.resetCredentialsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("resetCredentialsToolStripMenuItem.Image")));
            this.resetCredentialsToolStripMenuItem.Name = "resetCredentialsToolStripMenuItem";
            this.resetCredentialsToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.resetCredentialsToolStripMenuItem.Text = "Reset Credentials...";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(205, 6);
            // 
            // deleteBiodataToolStripMenuItem
            // 
            this.deleteBiodataToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteBiodataToolStripMenuItem.Image")));
            this.deleteBiodataToolStripMenuItem.Name = "deleteBiodataToolStripMenuItem";
            this.deleteBiodataToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.deleteBiodataToolStripMenuItem.Text = "Delete Biodata";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(422, 506);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Selected Record:";
            // 
            // lblSelectedRecord
            // 
            this.lblSelectedRecord.AutoSize = true;
            this.lblSelectedRecord.Location = new System.Drawing.Point(508, 506);
            this.lblSelectedRecord.Name = "lblSelectedRecord";
            this.lblSelectedRecord.Size = new System.Drawing.Size(0, 13);
            this.lblSelectedRecord.TabIndex = 13;
            // 
            // btnExporttoExcel
            // 
            this.btnExporttoExcel.Location = new System.Drawing.Point(776, 506);
            this.btnExporttoExcel.Name = "btnExporttoExcel";
            this.btnExporttoExcel.Size = new System.Drawing.Size(124, 30);
            this.btnExporttoExcel.TabIndex = 14;
            this.btnExporttoExcel.Text = "E&xport to Excel";
            this.btnExporttoExcel.UseVisualStyleBackColor = true;
            this.btnExporttoExcel.Click += new System.EventHandler(this.btnExporttoExcel_Click);
            // 
            // biodataToolStripMenuItem
            // 
            this.biodataToolStripMenuItem.Name = "biodataToolStripMenuItem";
            this.biodataToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.biodataToolStripMenuItem.Text = "Biodata...";
            this.biodataToolStripMenuItem.Click += new System.EventHandler(this.biodataToolStripMenuItem_Click);
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 544);
            this.Controls.Add(this.btnExporttoExcel);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblSelectedRecord);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearch";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Biodata(s)";
            this.Load += new System.EventHandler(this.frmSearch_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdResults)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgrdResults;
        private System.Windows.Forms.ComboBox drpCity;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.RadioButton rdbEmail;
        private System.Windows.Forms.RadioButton rdbMobile;
        private System.Windows.Forms.RadioButton rdbName;
        private System.Windows.Forms.RadioButton rdbId;
        private System.Windows.Forms.RadioButton rdbCity;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewBiodataToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem deleteBiodataToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem activateMembershipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deactivateMembershipToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem switchFranchiseeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetCredentialsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem viewBiodataDetailToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSelectedRecord;
        private System.Windows.Forms.ComboBox cmbCustomers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdbAssignedExecutives;
        private System.Windows.Forms.ComboBox cmbExecutives;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdbAssignedCustomers;
        private System.Windows.Forms.Button btnExporttoExcel;
        private System.Windows.Forms.ToolStripMenuItem biodataToolStripMenuItem;
    }
}