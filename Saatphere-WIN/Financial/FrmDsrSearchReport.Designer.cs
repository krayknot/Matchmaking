namespace Saatphere_WIN.Financial
{
    partial class FrmDsrSearchReport
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
            this.btnFranchiseeReport = new System.Windows.Forms.Button();
            this.dtToFranchisee = new System.Windows.Forms.DateTimePicker();
            this.dtFromFranchisee = new System.Windows.Forms.DateTimePicker();
            this.cmbFranchisee = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExecutiveReport = new System.Windows.Forms.Button();
            this.dtToExecutive = new System.Windows.Forms.DateTimePicker();
            this.dtFromExecutive = new System.Windows.Forms.DateTimePicker();
            this.cmbExecutive = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgrdResults = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTotalRecordsCount = new System.Windows.Forms.Label();
            this.lblAmountTotal = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdResults)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFranchiseeReport);
            this.groupBox1.Controls.Add(this.dtToFranchisee);
            this.groupBox1.Controls.Add(this.dtFromFranchisee);
            this.groupBox1.Controls.Add(this.cmbFranchisee);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 158);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Filters - Franchisee";
            // 
            // btnFranchiseeReport
            // 
            this.btnFranchiseeReport.Location = new System.Drawing.Point(110, 116);
            this.btnFranchiseeReport.Name = "btnFranchiseeReport";
            this.btnFranchiseeReport.Size = new System.Drawing.Size(75, 30);
            this.btnFranchiseeReport.TabIndex = 6;
            this.btnFranchiseeReport.Text = "Report";
            this.btnFranchiseeReport.UseVisualStyleBackColor = true;
            this.btnFranchiseeReport.Click += new System.EventHandler(this.btnFranchiseeReport_Click);
            // 
            // dtToFranchisee
            // 
            this.dtToFranchisee.Location = new System.Drawing.Point(110, 53);
            this.dtToFranchisee.Name = "dtToFranchisee";
            this.dtToFranchisee.Size = new System.Drawing.Size(200, 21);
            this.dtToFranchisee.TabIndex = 5;
            // 
            // dtFromFranchisee
            // 
            this.dtFromFranchisee.Location = new System.Drawing.Point(110, 26);
            this.dtFromFranchisee.Name = "dtFromFranchisee";
            this.dtFromFranchisee.Size = new System.Drawing.Size(200, 21);
            this.dtFromFranchisee.TabIndex = 4;
            // 
            // cmbFranchisee
            // 
            this.cmbFranchisee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFranchisee.Enabled = false;
            this.cmbFranchisee.FormattingEnabled = true;
            this.cmbFranchisee.Location = new System.Drawing.Point(110, 80);
            this.cmbFranchisee.Name = "cmbFranchisee";
            this.cmbFranchisee.Size = new System.Drawing.Size(226, 21);
            this.cmbFranchisee.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Franchisee:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date To: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date From: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExecutiveReport);
            this.groupBox2.Controls.Add(this.dtToExecutive);
            this.groupBox2.Controls.Add(this.dtFromExecutive);
            this.groupBox2.Controls.Add(this.cmbExecutive);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(441, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(431, 158);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Filters - Executive";
            // 
            // btnExecutiveReport
            // 
            this.btnExecutiveReport.Location = new System.Drawing.Point(107, 116);
            this.btnExecutiveReport.Name = "btnExecutiveReport";
            this.btnExecutiveReport.Size = new System.Drawing.Size(75, 30);
            this.btnExecutiveReport.TabIndex = 13;
            this.btnExecutiveReport.Text = "Report";
            this.btnExecutiveReport.UseVisualStyleBackColor = true;
            this.btnExecutiveReport.Click += new System.EventHandler(this.btnExecutiveReport_Click);
            // 
            // dtToExecutive
            // 
            this.dtToExecutive.Location = new System.Drawing.Point(107, 53);
            this.dtToExecutive.Name = "dtToExecutive";
            this.dtToExecutive.Size = new System.Drawing.Size(200, 21);
            this.dtToExecutive.TabIndex = 12;
            // 
            // dtFromExecutive
            // 
            this.dtFromExecutive.Location = new System.Drawing.Point(107, 26);
            this.dtFromExecutive.Name = "dtFromExecutive";
            this.dtFromExecutive.Size = new System.Drawing.Size(200, 21);
            this.dtFromExecutive.TabIndex = 11;
            // 
            // cmbExecutive
            // 
            this.cmbExecutive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExecutive.FormattingEnabled = true;
            this.cmbExecutive.Location = new System.Drawing.Point(107, 80);
            this.cmbExecutive.Name = "cmbExecutive";
            this.cmbExecutive.Size = new System.Drawing.Size(226, 21);
            this.cmbExecutive.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Executive:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Date To: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Date From: ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgrdResults);
            this.groupBox3.Location = new System.Drawing.Point(4, 164);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(868, 428);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Results";
            // 
            // dgrdResults
            // 
            this.dgrdResults.AllowUserToAddRows = false;
            this.dgrdResults.AllowUserToDeleteRows = false;
            this.dgrdResults.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgrdResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdResults.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgrdResults.Location = new System.Drawing.Point(3, 17);
            this.dgrdResults.Name = "dgrdResults";
            this.dgrdResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdResults.Size = new System.Drawing.Size(862, 408);
            this.dgrdResults.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(788, 598);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTotalRecordsCount
            // 
            this.lblTotalRecordsCount.AutoSize = true;
            this.lblTotalRecordsCount.Location = new System.Drawing.Point(12, 598);
            this.lblTotalRecordsCount.Name = "lblTotalRecordsCount";
            this.lblTotalRecordsCount.Size = new System.Drawing.Size(102, 13);
            this.lblTotalRecordsCount.TabIndex = 8;
            this.lblTotalRecordsCount.Text = "{totalrecordscount}";
            this.lblTotalRecordsCount.Visible = false;
            // 
            // lblAmountTotal
            // 
            this.lblAmountTotal.AutoSize = true;
            this.lblAmountTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountTotal.Location = new System.Drawing.Point(228, 598);
            this.lblAmountTotal.Name = "lblAmountTotal";
            this.lblAmountTotal.Size = new System.Drawing.Size(92, 13);
            this.lblAmountTotal.TabIndex = 9;
            this.lblAmountTotal.Text = "{totalamount}";
            this.lblAmountTotal.Visible = false;
            // 
            // frmDSR_SearchReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 636);
            this.Controls.Add(this.lblAmountTotal);
            this.Controls.Add(this.lblTotalRecordsCount);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDSR_SearchReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DSR Search Report - Saatphere";
            this.Load += new System.EventHandler(this.frmDSR_SearchReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFranchiseeReport;
        private System.Windows.Forms.DateTimePicker dtToFranchisee;
        private System.Windows.Forms.DateTimePicker dtFromFranchisee;
        private System.Windows.Forms.ComboBox cmbFranchisee;
        private System.Windows.Forms.Button btnExecutiveReport;
        private System.Windows.Forms.DateTimePicker dtToExecutive;
        private System.Windows.Forms.DateTimePicker dtFromExecutive;
        private System.Windows.Forms.ComboBox cmbExecutive;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgrdResults;
        private System.Windows.Forms.Label lblTotalRecordsCount;
        private System.Windows.Forms.Label lblAmountTotal;
    }
}