namespace Saatphere_WIN
{
    partial class frmAutoMatch
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
            this.txtBiodataCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustBiodataID = new System.Windows.Forms.TextBox();
            this.lstSentLog = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.radioComma = new System.Windows.Forms.RadioButton();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radioBiodata = new System.Windows.Forms.RadioButton();
            this.chkProfileSendOption = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnExportLog = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBiodataCount
            // 
            this.txtBiodataCount.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBiodataCount.Location = new System.Drawing.Point(110, 173);
            this.txtBiodataCount.Name = "txtBiodataCount";
            this.txtBiodataCount.Size = new System.Drawing.Size(55, 24);
            this.txtBiodataCount.TabIndex = 3;
            this.txtBiodataCount.Text = "6";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Biodata Count:";
            // 
            // txtCustBiodataID
            // 
            this.txtCustBiodataID.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustBiodataID.Location = new System.Drawing.Point(17, 123);
            this.txtCustBiodataID.Name = "txtCustBiodataID";
            this.txtCustBiodataID.Size = new System.Drawing.Size(394, 24);
            this.txtCustBiodataID.TabIndex = 1;
            // 
            // lstSentLog
            // 
            this.lstSentLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstSentLog.FormattingEnabled = true;
            this.lstSentLog.Location = new System.Drawing.Point(28, 276);
            this.lstSentLog.Name = "lstSentLog";
            this.lstSentLog.Size = new System.Drawing.Size(407, 171);
            this.lstSentLog.TabIndex = 0;
            this.lstSentLog.DoubleClick += new System.EventHandler(this.lstSentLog_DoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DimGray;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(359, 451);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 40);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.DimGray;
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(201, 451);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(152, 40);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "&Search and Send Biodata";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTo);
            this.groupBox1.Controls.Add(this.radioComma);
            this.groupBox1.Controls.Add(this.txtFrom);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.radioBiodata);
            this.groupBox1.Controls.Add(this.txtCustBiodataID);
            this.groupBox1.Location = new System.Drawing.Point(3, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 160);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Biodata selection:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "(double click to repeat the From id)";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(168, 45);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(59, 21);
            this.txtTo.TabIndex = 4;
            this.txtTo.DoubleClick += new System.EventHandler(this.txtTo_DoubleClick);
            // 
            // radioComma
            // 
            this.radioComma.AutoSize = true;
            this.radioComma.Location = new System.Drawing.Point(17, 100);
            this.radioComma.Name = "radioComma";
            this.radioComma.Size = new System.Drawing.Size(210, 17);
            this.radioComma.TabIndex = 5;
            this.radioComma.Text = "Comma separated or Single Biodata id:";
            this.radioComma.UseVisualStyleBackColor = true;
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(74, 45);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(59, 21);
            this.txtFrom.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(139, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "To:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "From:";
            // 
            // radioBiodata
            // 
            this.radioBiodata.AutoSize = true;
            this.radioBiodata.Checked = true;
            this.radioBiodata.Location = new System.Drawing.Point(17, 20);
            this.radioBiodata.Name = "radioBiodata";
            this.radioBiodata.Size = new System.Drawing.Size(92, 17);
            this.radioBiodata.TabIndex = 0;
            this.radioBiodata.TabStop = true;
            this.radioBiodata.Text = "Biodata range";
            this.radioBiodata.UseVisualStyleBackColor = true;
            // 
            // chkProfileSendOption
            // 
            this.chkProfileSendOption.AutoSize = true;
            this.chkProfileSendOption.Checked = true;
            this.chkProfileSendOption.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProfileSendOption.Location = new System.Drawing.Point(28, 209);
            this.chkProfileSendOption.Name = "chkProfileSendOption";
            this.chkProfileSendOption.Size = new System.Drawing.Size(201, 17);
            this.chkProfileSendOption.TabIndex = 5;
            this.chkProfileSendOption.Text = "Send profiles to Unpaid member only";
            this.chkProfileSendOption.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(46, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(368, 46);
            this.label4.TabIndex = 6;
            this.label4.Text = "Check this option will send profiles ( ignoring the marital status ) to the unpai" +
    "d members only. It will collect the Paid members\'s id to send them profiles on m" +
    "anual basis.";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // btnExportLog
            // 
            this.btnExportLog.BackColor = System.Drawing.Color.Chocolate;
            this.btnExportLog.ForeColor = System.Drawing.Color.White;
            this.btnExportLog.Location = new System.Drawing.Point(28, 451);
            this.btnExportLog.Name = "btnExportLog";
            this.btnExportLog.Size = new System.Drawing.Size(95, 40);
            this.btnExportLog.TabIndex = 7;
            this.btnExportLog.Text = "E&xport Log";
            this.btnExportLog.UseVisualStyleBackColor = false;
            this.btnExportLog.Click += new System.EventHandler(this.btnExportLog_Click);
            // 
            // frmAutoMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 503);
            this.Controls.Add(this.btnExportLog);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkProfileSendOption);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBiodataCount);
            this.Controls.Add(this.lstSentLog);
            this.Controls.Add(this.btnSend);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAutoMatch";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto Match Biodata";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBiodataCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustBiodataID;
        private System.Windows.Forms.ListBox lstSentLog;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioBiodata;
        private System.Windows.Forms.RadioButton radioComma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkProfileSendOption;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnExportLog;
    }
}