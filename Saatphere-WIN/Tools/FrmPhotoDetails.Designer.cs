namespace Saatphere_WIN.Tools
{
    partial class FrmPhotoDetails
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
            this.pictUserImage = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmbImageMode = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictUserImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pictUserImage
            // 
            this.pictUserImage.Location = new System.Drawing.Point(4, 4);
            this.pictUserImage.Name = "pictUserImage";
            this.pictUserImage.Size = new System.Drawing.Size(387, 423);
            this.pictUserImage.TabIndex = 0;
            this.pictUserImage.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(407, 404);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(136, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbImageMode
            // 
            this.cmbImageMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImageMode.FormattingEnabled = true;
            this.cmbImageMode.Items.AddRange(new object[] {
            "Normal",
            "StretchImage",
            "Autosize",
            "CenterImage",
            "Zoom"});
            this.cmbImageMode.Location = new System.Drawing.Point(407, 12);
            this.cmbImageMode.Name = "cmbImageMode";
            this.cmbImageMode.Size = new System.Drawing.Size(136, 21);
            this.cmbImageMode.TabIndex = 24;
            this.cmbImageMode.TextChanged += new System.EventHandler(this.cmbImageMode_TextChanged);
            // 
            // frmPhotoDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 439);
            this.Controls.Add(this.cmbImageMode);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictUserImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPhotoDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Photo Details";
            this.Load += new System.EventHandler(this.frmPhotoDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictUserImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictUserImage;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cmbImageMode;
    }
}