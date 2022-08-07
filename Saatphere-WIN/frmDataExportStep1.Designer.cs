namespace Saatphere_WIN
{
    partial class frmDataExportStep1
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
            this.lstTables = new System.Windows.Forms.ListBox();
            this.rdbSelectTable = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.rdbWriteQuery = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnBrowseQueryFile = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstTables);
            this.groupBox1.Location = new System.Drawing.Point(4, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 250);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lstTables
            // 
            this.lstTables.FormattingEnabled = true;
            this.lstTables.Location = new System.Drawing.Point(2, 9);
            this.lstTables.Name = "lstTables";
            this.lstTables.Size = new System.Drawing.Size(460, 238);
            this.lstTables.TabIndex = 1;
            // 
            // rdbSelectTable
            // 
            this.rdbSelectTable.AutoSize = true;
            this.rdbSelectTable.Checked = true;
            this.rdbSelectTable.Location = new System.Drawing.Point(6, 7);
            this.rdbSelectTable.Name = "rdbSelectTable";
            this.rdbSelectTable.Size = new System.Drawing.Size(129, 17);
            this.rdbSelectTable.TabIndex = 0;
            this.rdbSelectTable.TabStop = true;
            this.rdbSelectTable.Text = "Select table to Export";
            this.rdbSelectTable.UseVisualStyleBackColor = true;
            this.rdbSelectTable.CheckedChanged += new System.EventHandler(this.rdbSelectTable_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBrowseQueryFile);
            this.groupBox2.Controls.Add(this.txtQuery);
            this.groupBox2.Location = new System.Drawing.Point(4, 286);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(462, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(5, 11);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQuery.Size = new System.Drawing.Size(424, 85);
            this.txtQuery.TabIndex = 3;
            // 
            // rdbWriteQuery
            // 
            this.rdbWriteQuery.AutoSize = true;
            this.rdbWriteQuery.Location = new System.Drawing.Point(6, 274);
            this.rdbWriteQuery.Name = "rdbWriteQuery";
            this.rdbWriteQuery.Size = new System.Drawing.Size(93, 17);
            this.rdbWriteQuery.TabIndex = 2;
            this.rdbWriteQuery.TabStop = true;
            this.rdbWriteQuery.Text = "Write a Query";
            this.rdbWriteQuery.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(384, 394);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "&Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(303, 394);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "&Next";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnBrowseQueryFile
            // 
            this.btnBrowseQueryFile.Location = new System.Drawing.Point(431, 73);
            this.btnBrowseQueryFile.Name = "btnBrowseQueryFile";
            this.btnBrowseQueryFile.Size = new System.Drawing.Size(27, 23);
            this.btnBrowseQueryFile.TabIndex = 4;
            this.btnBrowseQueryFile.Text = "...";
            this.btnBrowseQueryFile.UseVisualStyleBackColor = true;
            this.btnBrowseQueryFile.Click += new System.EventHandler(this.btnBrowseQueryFile_Click);
            // 
            // frmDataExportStep1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 425);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.rdbWriteQuery);
            this.Controls.Add(this.rdbSelectTable);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDataExportStep1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Export - Step 1";
            this.Load += new System.EventHandler(this.frmDataExportStep1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstTables;
        private System.Windows.Forms.RadioButton rdbSelectTable;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.RadioButton rdbWriteQuery;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnBrowseQueryFile;
    }
}