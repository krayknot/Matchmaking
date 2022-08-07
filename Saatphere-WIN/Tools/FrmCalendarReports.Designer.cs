namespace Saatphere_WIN.Tools
{
    partial class FrmCalendarReports
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbReport = new System.Windows.Forms.ComboBox();
            this.txtCandidateID = new System.Windows.Forms.TextBox();
            this.txtCandidateName = new System.Windows.Forms.TextBox();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnSearchCandidateID = new System.Windows.Forms.Button();
            this.btnSearchCandidateName = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgrdReport = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdReport)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.btnSearchCandidateName);
            this.groupBox1.Controls.Add(this.btnSearchCandidateID);
            this.groupBox1.Controls.Add(this.btnReport);
            this.groupBox1.Controls.Add(this.dateTo);
            this.groupBox1.Controls.Add(this.dateFrom);
            this.groupBox1.Controls.Add(this.txtCandidateName);
            this.groupBox1.Controls.Add(this.txtCandidateID);
            this.groupBox1.Controls.Add(this.cmbReport);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(773, 190);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report Options";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Report:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Candidate ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Candidate Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Date To:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Date From:";
            // 
            // cmbReport
            // 
            this.cmbReport.FormattingEnabled = true;
            this.cmbReport.Items.AddRange(new object[] {
            "COURIER SENT",
            "EMAIL SENT",
            "POST SENT",
            "TIME ISSUE",
            "NO MATCH FOUND",
            "EMAIL & COURIER"});
            this.cmbReport.Location = new System.Drawing.Point(137, 37);
            this.cmbReport.Name = "cmbReport";
            this.cmbReport.Size = new System.Drawing.Size(199, 21);
            this.cmbReport.TabIndex = 6;
            // 
            // txtCandidateID
            // 
            this.txtCandidateID.Location = new System.Drawing.Point(137, 64);
            this.txtCandidateID.Name = "txtCandidateID";
            this.txtCandidateID.Size = new System.Drawing.Size(148, 21);
            this.txtCandidateID.TabIndex = 7;
            // 
            // txtCandidateName
            // 
            this.txtCandidateName.Location = new System.Drawing.Point(137, 91);
            this.txtCandidateName.Name = "txtCandidateName";
            this.txtCandidateName.Size = new System.Drawing.Size(148, 21);
            this.txtCandidateName.TabIndex = 8;
            // 
            // dateFrom
            // 
            this.dateFrom.Location = new System.Drawing.Point(136, 125);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(200, 21);
            this.dateFrom.TabIndex = 9;
            // 
            // dateTo
            // 
            this.dateTo.Location = new System.Drawing.Point(136, 152);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(200, 21);
            this.dateTo.TabIndex = 10;
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(342, 35);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 23);
            this.btnReport.TabIndex = 11;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnSearchCandidateID
            // 
            this.btnSearchCandidateID.Location = new System.Drawing.Point(342, 64);
            this.btnSearchCandidateID.Name = "btnSearchCandidateID";
            this.btnSearchCandidateID.Size = new System.Drawing.Size(157, 23);
            this.btnSearchCandidateID.TabIndex = 12;
            this.btnSearchCandidateID.Text = "Search Candidate ID";
            this.btnSearchCandidateID.UseVisualStyleBackColor = true;
            this.btnSearchCandidateID.Click += new System.EventHandler(this.btnSearchCandidateID_Click);
            // 
            // btnSearchCandidateName
            // 
            this.btnSearchCandidateName.Location = new System.Drawing.Point(342, 89);
            this.btnSearchCandidateName.Name = "btnSearchCandidateName";
            this.btnSearchCandidateName.Size = new System.Drawing.Size(157, 23);
            this.btnSearchCandidateName.TabIndex = 13;
            this.btnSearchCandidateName.Text = "Search Candidate Name";
            this.btnSearchCandidateName.UseVisualStyleBackColor = true;
            this.btnSearchCandidateName.Click += new System.EventHandler(this.btnSearchCandidateName_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(342, 150);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(84, 23);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgrdReport);
            this.groupBox2.Location = new System.Drawing.Point(4, 193);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(773, 371);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dgrdReport
            // 
            this.dgrdReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdReport.Location = new System.Drawing.Point(3, 17);
            this.dgrdReport.Name = "dgrdReport";
            this.dgrdReport.Size = new System.Drawing.Size(767, 351);
            this.dgrdReport.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(684, 570);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 30);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmCalendarReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 609);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCalendarReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calendar Reports - Saatphere";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCandidateName;
        private System.Windows.Forms.TextBox txtCandidateID;
        private System.Windows.Forms.ComboBox cmbReport;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnSearchCandidateName;
        private System.Windows.Forms.Button btnSearchCandidateID;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgrdReport;
        private System.Windows.Forms.Button btnClose;
    }
}