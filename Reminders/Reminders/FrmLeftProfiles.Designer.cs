namespace Reminders
{
    partial class FrmLeftProfiles
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgrdTodaysPendingProfiles = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgrdPendingProfiles = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.profileHasSentRemoveTheUserFromListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCount = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdTodaysPendingProfiles)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdPendingProfiles)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(7, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 296);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Users left in previous Attempts";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 17);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(489, 273);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            this.tabControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseClick);
            this.tabControl1.TabIndexChanged += new System.EventHandler(this.tabControl1_TabIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgrdTodaysPendingProfiles);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(481, 247);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Today\'s Profiles";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgrdTodaysPendingProfiles
            // 
            this.dgrdTodaysPendingProfiles.AllowUserToAddRows = false;
            this.dgrdTodaysPendingProfiles.AllowUserToDeleteRows = false;
            this.dgrdTodaysPendingProfiles.AllowUserToOrderColumns = true;
            this.dgrdTodaysPendingProfiles.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgrdTodaysPendingProfiles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdTodaysPendingProfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdTodaysPendingProfiles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgrdTodaysPendingProfiles.Location = new System.Drawing.Point(6, 6);
            this.dgrdTodaysPendingProfiles.Name = "dgrdTodaysPendingProfiles";
            this.dgrdTodaysPendingProfiles.Size = new System.Drawing.Size(469, 235);
            this.dgrdTodaysPendingProfiles.TabIndex = 1;
            this.dgrdTodaysPendingProfiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgrdTodaysPendingProfiles_MouseClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgrdPendingProfiles);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(481, 247);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Previous Profiles";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgrdPendingProfiles
            // 
            this.dgrdPendingProfiles.AllowUserToAddRows = false;
            this.dgrdPendingProfiles.AllowUserToDeleteRows = false;
            this.dgrdPendingProfiles.AllowUserToOrderColumns = true;
            this.dgrdPendingProfiles.AllowUserToResizeColumns = false;
            this.dgrdPendingProfiles.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgrdPendingProfiles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgrdPendingProfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdPendingProfiles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgrdPendingProfiles.Location = new System.Drawing.Point(6, 6);
            this.dgrdPendingProfiles.Name = "dgrdPendingProfiles";
            this.dgrdPendingProfiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdPendingProfiles.Size = new System.Drawing.Size(469, 235);
            this.dgrdPendingProfiles.TabIndex = 2;
            this.dgrdPendingProfiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgrdPendingProfiles_MouseClick);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(424, 302);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.historyToolStripMenuItem,
            this.toolStripMenuItem1,
            this.profileHasSentRemoveTheUserFromListToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(296, 54);
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.historyToolStripMenuItem.Text = "History";
            this.historyToolStripMenuItem.Click += new System.EventHandler(this.historyToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(292, 6);
            // 
            // profileHasSentRemoveTheUserFromListToolStripMenuItem
            // 
            this.profileHasSentRemoveTheUserFromListToolStripMenuItem.Name = "profileHasSentRemoveTheUserFromListToolStripMenuItem";
            this.profileHasSentRemoveTheUserFromListToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.profileHasSentRemoveTheUserFromListToolStripMenuItem.Text = "Profile has sent. Remove the user from list";
            this.profileHasSentRemoveTheUserFromListToolStripMenuItem.Click += new System.EventHandler(this.profileHasSentRemoveTheUserFromListToolStripMenuItem_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(12, 302);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(77, 13);
            this.lblCount.TabIndex = 2;
            this.lblCount.Text = "Total Records:";
            // 
            // frmLeftProfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 332);
            this.ControlBox = false;
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmLeftProfiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Left Profiles";
            this.Load += new System.EventHandler(this.frmLeftProfiles_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdTodaysPendingProfiles)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdPendingProfiles)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgrdTodaysPendingProfiles;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgrdPendingProfiles;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.ToolStripMenuItem profileHasSentRemoveTheUserFromListToolStripMenuItem;
    }
}