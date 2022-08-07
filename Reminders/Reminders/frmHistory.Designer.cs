namespace Reminders
{
    partial class FrmHistory
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
            this.grpHistory = new System.Windows.Forms.GroupBox();
            this.dgrdHistory = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.grpHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // grpHistory
            // 
            this.grpHistory.Controls.Add(this.dgrdHistory);
            this.grpHistory.Location = new System.Drawing.Point(3, 2);
            this.grpHistory.Name = "grpHistory";
            this.grpHistory.Size = new System.Drawing.Size(560, 327);
            this.grpHistory.TabIndex = 0;
            this.grpHistory.TabStop = false;
            // 
            // dgrdHistory
            // 
            this.dgrdHistory.AllowUserToAddRows = false;
            this.dgrdHistory.AllowUserToDeleteRows = false;
            this.dgrdHistory.AllowUserToOrderColumns = true;
            this.dgrdHistory.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgrdHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdHistory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgrdHistory.Location = new System.Drawing.Point(5, 14);
            this.dgrdHistory.Name = "dgrdHistory";
            this.dgrdHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdHistory.Size = new System.Drawing.Size(548, 306);
            this.dgrdHistory.TabIndex = 0;
            this.dgrdHistory.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgrdHistory_CellMouseDoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(481, 335);
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
            this.lblCount.Location = new System.Drawing.Point(12, 335);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(77, 13);
            this.lblCount.TabIndex = 1;
            this.lblCount.Text = "Total Records:";
            // 
            // frmHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 364);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grpHistory);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reminder: Customer History";
            this.Load += new System.EventHandler(this.frmHistory_Load);
            this.grpHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpHistory;
        private System.Windows.Forms.DataGridView dgrdHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblCount;
    }
}