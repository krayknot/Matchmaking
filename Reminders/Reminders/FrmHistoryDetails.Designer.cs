namespace Reminders
{
    partial class FrmHistoryDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgrdHistoryDetails = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdHistoryDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgrdHistoryDetails);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 240);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dgrdHistoryDetails
            // 
            this.dgrdHistoryDetails.AllowUserToAddRows = false;
            this.dgrdHistoryDetails.AllowUserToDeleteRows = false;
            this.dgrdHistoryDetails.AllowUserToOrderColumns = true;
            this.dgrdHistoryDetails.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgrdHistoryDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdHistoryDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdHistoryDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgrdHistoryDetails.Location = new System.Drawing.Point(6, 15);
            this.dgrdHistoryDetails.Name = "dgrdHistoryDetails";
            this.dgrdHistoryDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdHistoryDetails.Size = new System.Drawing.Size(345, 219);
            this.dgrdHistoryDetails.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(279, 249);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(6, 249);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(77, 13);
            this.lblCount.TabIndex = 2;
            this.lblCount.Text = "Total Records:";
            // 
            // frmHistoryDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 280);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHistoryDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reminder: History Details";
            this.Load += new System.EventHandler(this.frmHistoryDetails_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdHistoryDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgrdHistoryDetails;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblCount;
    }
}