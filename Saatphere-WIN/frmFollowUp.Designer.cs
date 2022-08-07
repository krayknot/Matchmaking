namespace Saatphere_WIN
{
    partial class frmFollowUp
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
            this.txtCreatedBy = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtExecutiveName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCreateRemark = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLastRemark = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblLastRemark);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCreatedBy);
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.txtExecutiveName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 250);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Follow up details";
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.Location = new System.Drawing.Point(79, 78);
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.Size = new System.Drawing.Size(183, 21);
            this.txtCreatedBy.TabIndex = 5;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(79, 51);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(183, 21);
            this.txtDate.TabIndex = 4;
            // 
            // txtExecutiveName
            // 
            this.txtExecutiveName.Location = new System.Drawing.Point(79, 24);
            this.txtExecutiveName.Name = "txtExecutiveName";
            this.txtExecutiveName.Size = new System.Drawing.Size(183, 21);
            this.txtExecutiveName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Created By:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Executive:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(254, 258);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "&Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCreateRemark
            // 
            this.btnCreateRemark.Location = new System.Drawing.Point(148, 258);
            this.btnCreateRemark.Name = "btnCreateRemark";
            this.btnCreateRemark.Size = new System.Drawing.Size(100, 23);
            this.btnCreateRemark.TabIndex = 3;
            this.btnCreateRemark.Text = "Create Remark";
            this.btnCreateRemark.UseVisualStyleBackColor = true;
            this.btnCreateRemark.Click += new System.EventHandler(this.btnCreateRemark_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Last Remark:";
            // 
            // lblLastRemark
            // 
            this.lblLastRemark.AutoSize = true;
            this.lblLastRemark.Location = new System.Drawing.Point(79, 111);
            this.lblLastRemark.Name = "lblLastRemark";
            this.lblLastRemark.Size = new System.Drawing.Size(70, 13);
            this.lblLastRemark.TabIndex = 7;
            this.lblLastRemark.Text = "Last Remark:";
            // 
            // frmFollowUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 287);
            this.Controls.Add(this.btnCreateRemark);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFollowUp";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Followup - Saatphere";
            this.Load += new System.EventHandler(this.frmFollowUp_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCreatedBy;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtExecutiveName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCreateRemark;
        private System.Windows.Forms.Label lblLastRemark;
        private System.Windows.Forms.Label label4;
    }
}