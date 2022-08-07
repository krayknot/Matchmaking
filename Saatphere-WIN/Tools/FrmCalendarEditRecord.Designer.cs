namespace Saatphere_WIN.Tools
{
    partial class FrmCalendarEditRecord
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
            this.cmbSendDateStatus = new System.Windows.Forms.ComboBox();
            this.txtProfileID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnTransferToTomorrow = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbSendDateStatus);
            this.groupBox1.Controls.Add(this.txtProfileID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 119);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edit Calendar Information";
            // 
            // cmbSendDateStatus
            // 
            this.cmbSendDateStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSendDateStatus.FormattingEnabled = true;
            this.cmbSendDateStatus.Items.AddRange(new object[] {
            "COURIER SENT",
            "EMAIL SENT",
            "POST SENT",
            "TIME ISSUE",
            "NO MATCH FOUND",
            "EMAIL & COURIER"});
            this.cmbSendDateStatus.Location = new System.Drawing.Point(131, 65);
            this.cmbSendDateStatus.Name = "cmbSendDateStatus";
            this.cmbSendDateStatus.Size = new System.Drawing.Size(238, 21);
            this.cmbSendDateStatus.TabIndex = 3;
            // 
            // txtProfileID
            // 
            this.txtProfileID.Enabled = false;
            this.txtProfileID.Location = new System.Drawing.Point(131, 38);
            this.txtProfileID.Name = "txtProfileID";
            this.txtProfileID.Size = new System.Drawing.Size(100, 21);
            this.txtProfileID.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Send Date Status:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Profile ID:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(96, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "&Update Status";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTransferToTomorrow
            // 
            this.btnTransferToTomorrow.Location = new System.Drawing.Point(206, 127);
            this.btnTransferToTomorrow.Name = "btnTransferToTomorrow";
            this.btnTransferToTomorrow.Size = new System.Drawing.Size(128, 30);
            this.btnTransferToTomorrow.TabIndex = 2;
            this.btnTransferToTomorrow.Text = "&Transfer to Tomorrow";
            this.btnTransferToTomorrow.UseVisualStyleBackColor = true;
            this.btnTransferToTomorrow.Click += new System.EventHandler(this.btnTransferToTomorrow_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(361, 127);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 30);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmCalendarEditRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 166);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnTransferToTomorrow);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCalendarEditRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Calendar Record - Saatphere";
            this.Load += new System.EventHandler(this.frmCalendarEditRecord_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbSendDateStatus;
        private System.Windows.Forms.TextBox txtProfileID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTransferToTomorrow;
        private System.Windows.Forms.Button btnClose;
    }
}