namespace Saatphere_WIN.Tools
{
    partial class FrmProfileMatchResults
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgrdProfileMatchResults = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lstSelectedProfiles = new System.Windows.Forms.ListBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectProfieToSendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblFranchisee = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtReceiver = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.btnExporttoExcel = new System.Windows.Forms.Button();
            this.txtExportRecordCount = new System.Windows.Forms.TextBox();
            this.btnSelectMultipleProfiles = new System.Windows.Forms.Button();
            this.btnPdf = new System.Windows.Forms.Button();
            this.lblMessageExporttoWord = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdProfileMatchResults)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgrdProfileMatchResults);
            this.groupBox1.Location = new System.Drawing.Point(3, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(801, 450);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Profile Match Results";
            // 
            // dgrdProfileMatchResults
            // 
            this.dgrdProfileMatchResults.AllowUserToAddRows = false;
            this.dgrdProfileMatchResults.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgrdProfileMatchResults.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdProfileMatchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdProfileMatchResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdProfileMatchResults.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgrdProfileMatchResults.Location = new System.Drawing.Point(3, 17);
            this.dgrdProfileMatchResults.Name = "dgrdProfileMatchResults";
            this.dgrdProfileMatchResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdProfileMatchResults.Size = new System.Drawing.Size(795, 430);
            this.dgrdProfileMatchResults.TabIndex = 0;
            this.dgrdProfileMatchResults.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrdProfileMatchResults_CellClick);
            this.dgrdProfileMatchResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrdProfileMatchResults_CellContentClick);
            this.dgrdProfileMatchResults.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgrdProfileMatchResults_CellMouseDown);
            this.dgrdProfileMatchResults.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgrdProfileMatchResults_MouseClick);
            this.dgrdProfileMatchResults.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgrdProfileMatchResults_MouseDoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(902, 457);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnShowAll.Location = new System.Drawing.Point(821, 457);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(75, 30);
            this.btnShowAll.TabIndex = 2;
            this.btnShowAll.Text = "&Show All";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnSelectAll);
            this.groupBox2.Controls.Add(this.btnRemove);
            this.groupBox2.Controls.Add(this.lstSelectedProfiles);
            this.groupBox2.Controls.Add(this.btnSend);
            this.groupBox2.Location = new System.Drawing.Point(807, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(178, 269);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selected Profiles";
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(153, 233);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(22, 30);
            this.btnSelectAll.TabIndex = 6;
            this.btnSelectAll.Text = "#";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRemove.Location = new System.Drawing.Point(6, 233);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(50, 30);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Clear";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lstSelectedProfiles
            // 
            this.lstSelectedProfiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lstSelectedProfiles.FormattingEnabled = true;
            this.lstSelectedProfiles.Location = new System.Drawing.Point(3, 17);
            this.lstSelectedProfiles.Name = "lstSelectedProfiles";
            this.lstSelectedProfiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstSelectedProfiles.Size = new System.Drawing.Size(172, 212);
            this.lstSelectedProfiles.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSend.Location = new System.Drawing.Point(59, 233);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(91, 30);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectProfieToSendToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(182, 26);
            // 
            // selectProfieToSendToolStripMenuItem
            // 
            this.selectProfieToSendToolStripMenuItem.Name = "selectProfieToSendToolStripMenuItem";
            this.selectProfieToSendToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.selectProfieToSendToolStripMenuItem.Text = "Select profie to send";
            this.selectProfieToSendToolStripMenuItem.Click += new System.EventHandler(this.selectProfieToSendToolStripMenuItem_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.lblFranchisee);
            this.groupBox4.Controls.Add(this.txtMessage);
            this.groupBox4.Controls.Add(this.txtReceiver);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Location = new System.Drawing.Point(807, 270);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(178, 181);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Send Email";
            // 
            // lblFranchisee
            // 
            this.lblFranchisee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFranchisee.AutoSize = true;
            this.lblFranchisee.Location = new System.Drawing.Point(74, 156);
            this.lblFranchisee.Name = "lblFranchisee";
            this.lblFranchisee.Size = new System.Drawing.Size(67, 13);
            this.lblFranchisee.TabIndex = 5;
            this.lblFranchisee.Text = "{franchisee}";
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(6, 86);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(157, 67);
            this.txtMessage.TabIndex = 4;
            // 
            // txtReceiver
            // 
            this.txtReceiver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReceiver.Location = new System.Drawing.Point(6, 38);
            this.txtReceiver.Name = "txtReceiver";
            this.txtReceiver.Size = new System.Drawing.Size(157, 21);
            this.txtReceiver.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 156);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Franchisee:";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Message:";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Receiver:";
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Location = new System.Drawing.Point(12, 466);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(75, 13);
            this.lblRecordCount.TabIndex = 8;
            this.lblRecordCount.Text = "{recordcount}";
            // 
            // btnExporttoExcel
            // 
            this.btnExporttoExcel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExporttoExcel.Location = new System.Drawing.Point(494, 457);
            this.btnExporttoExcel.Name = "btnExporttoExcel";
            this.btnExporttoExcel.Size = new System.Drawing.Size(124, 30);
            this.btnExporttoExcel.TabIndex = 15;
            this.btnExporttoExcel.Text = "E&xport to Excel";
            this.btnExporttoExcel.UseVisualStyleBackColor = true;
            this.btnExporttoExcel.Click += new System.EventHandler(this.btnExporttoExcel_Click);
            // 
            // txtExportRecordCount
            // 
            this.txtExportRecordCount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtExportRecordCount.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtExportRecordCount.Location = new System.Drawing.Point(461, 458);
            this.txtExportRecordCount.Name = "txtExportRecordCount";
            this.txtExportRecordCount.Size = new System.Drawing.Size(33, 27);
            this.txtExportRecordCount.TabIndex = 16;
            this.txtExportRecordCount.Text = "10";
            // 
            // btnSelectMultipleProfiles
            // 
            this.btnSelectMultipleProfiles.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSelectMultipleProfiles.Location = new System.Drawing.Point(331, 457);
            this.btnSelectMultipleProfiles.Name = "btnSelectMultipleProfiles";
            this.btnSelectMultipleProfiles.Size = new System.Drawing.Size(124, 30);
            this.btnSelectMultipleProfiles.TabIndex = 17;
            this.btnSelectMultipleProfiles.Text = "Select Multiple Profiles";
            this.btnSelectMultipleProfiles.UseVisualStyleBackColor = true;
            this.btnSelectMultipleProfiles.Click += new System.EventHandler(this.btnSelectMultipleProfiles_Click);
            // 
            // btnPdf
            // 
            this.btnPdf.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPdf.Location = new System.Drawing.Point(619, 457);
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Size = new System.Drawing.Size(108, 30);
            this.btnPdf.TabIndex = 7;
            this.btnPdf.Text = "Export to Word";
            this.btnPdf.UseVisualStyleBackColor = true;
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
            // 
            // lblMessageExporttoWord
            // 
            this.lblMessageExporttoWord.AutoSize = true;
            this.lblMessageExporttoWord.Location = new System.Drawing.Point(733, 466);
            this.lblMessageExporttoWord.Name = "lblMessageExporttoWord";
            this.lblMessageExporttoWord.Size = new System.Drawing.Size(17, 13);
            this.lblMessageExporttoWord.TabIndex = 18;
            this.lblMessageExporttoWord.Text = "??";
            this.lblMessageExporttoWord.Visible = false;
            this.lblMessageExporttoWord.Click += new System.EventHandler(this.lblMessageExporttoWord_Click);
            this.lblMessageExporttoWord.DoubleClick += new System.EventHandler(this.lblMessageExporttoWord_DoubleClick);
            // 
            // frmProfileMatchResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 499);
            this.Controls.Add(this.lblMessageExporttoWord);
            this.Controls.Add(this.btnPdf);
            this.Controls.Add(this.btnSelectMultipleProfiles);
            this.Controls.Add(this.txtExportRecordCount);
            this.Controls.Add(this.btnExporttoExcel);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "frmProfileMatchResults";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Profile Match Results - Saatphere";
            this.Load += new System.EventHandler(this.frmProfileMatchResults_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdProfileMatchResults)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgrdProfileMatchResults;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem selectProfieToSendToolStripMenuItem;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblFranchisee;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtReceiver;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.ListBox lstSelectedProfiles;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Button btnExporttoExcel;
        private System.Windows.Forms.TextBox txtExportRecordCount;
        private System.Windows.Forms.Button btnSelectMultipleProfiles;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnPdf;
        private System.Windows.Forms.Label lblMessageExporttoWord;
    }
}