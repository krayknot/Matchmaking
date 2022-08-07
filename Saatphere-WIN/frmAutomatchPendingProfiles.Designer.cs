namespace Saatphere_WIN
{
    partial class frmAutomatchPendingProfiles
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBiodataCount = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblProfileID = new System.Windows.Forms.Label();
            this.btnAutomatch = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgrdResults = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdResults)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtBiodataCount);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Number of profiles to fetch";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Count of profiles to send:";
            // 
            // txtBiodataCount
            // 
            this.txtBiodataCount.Location = new System.Drawing.Point(158, 20);
            this.txtBiodataCount.Name = "txtBiodataCount";
            this.txtBiodataCount.Size = new System.Drawing.Size(69, 21);
            this.txtBiodataCount.TabIndex = 0;
            this.txtBiodataCount.Text = "6";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblProfileID);
            this.groupBox2.Controls.Add(this.btnAutomatch);
            this.groupBox2.Location = new System.Drawing.Point(6, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 78);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Press Automatch to get the preferred profiles";
            // 
            // lblProfileID
            // 
            this.lblProfileID.AutoSize = true;
            this.lblProfileID.Location = new System.Drawing.Point(6, 34);
            this.lblProfileID.Name = "lblProfileID";
            this.lblProfileID.Size = new System.Drawing.Size(55, 13);
            this.lblProfileID.TabIndex = 1;
            this.lblProfileID.Text = "{profileid}";
            // 
            // btnAutomatch
            // 
            this.btnAutomatch.Location = new System.Drawing.Point(94, 20);
            this.btnAutomatch.Name = "btnAutomatch";
            this.btnAutomatch.Size = new System.Drawing.Size(133, 40);
            this.btnAutomatch.TabIndex = 0;
            this.btnAutomatch.Text = "Automatch";
            this.btnAutomatch.UseVisualStyleBackColor = true;
            this.btnAutomatch.Click += new System.EventHandler(this.btnAutomatch_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgrdResults);
            this.groupBox3.Location = new System.Drawing.Point(6, 144);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(245, 188);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Results";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(170, 338);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 32);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(89, 338);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 32);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(9, 338);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 32);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Del";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openProfileToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(150, 26);
            // 
            // openProfileToolStripMenuItem
            // 
            this.openProfileToolStripMenuItem.Name = "openProfileToolStripMenuItem";
            this.openProfileToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.openProfileToolStripMenuItem.Text = "Open profile...";
            this.openProfileToolStripMenuItem.Click += new System.EventHandler(this.openProfileToolStripMenuItem_Click);
            // 
            // dgrdResults
            // 
            this.dgrdResults.AllowUserToAddRows = false;
            this.dgrdResults.AllowUserToOrderColumns = true;
            this.dgrdResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgrdResults.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgrdResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdResults.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgrdResults.Location = new System.Drawing.Point(3, 17);
            this.dgrdResults.MultiSelect = false;
            this.dgrdResults.Name = "dgrdResults";
            this.dgrdResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdResults.Size = new System.Drawing.Size(239, 168);
            this.dgrdResults.TabIndex = 1;
            this.dgrdResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrdPendingProfiles_CellContentClick);
            this.dgrdResults.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgrdPendingProfiles_CellMouseDown);
            this.dgrdResults.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgrdPendingProfiles_MouseClick);
            // 
            // frmAutomatchPendingProfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 382);
            this.ControlBox = false;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmAutomatchPendingProfiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Automatch Pending Profiles";
            this.Load += new System.EventHandler(this.frmAutomatchPendingProfiles_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBiodataCount;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAutomatch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblProfileID;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openProfileToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgrdResults;
    }
}