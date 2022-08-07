namespace Saatphere_WIN
{
    partial class frmMaintenance
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
            this.btnUpdateSearchXML = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUpdateSearchXML
            // 
            this.btnUpdateSearchXML.Location = new System.Drawing.Point(77, 198);
            this.btnUpdateSearchXML.Name = "btnUpdateSearchXML";
            this.btnUpdateSearchXML.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateSearchXML.TabIndex = 0;
            this.btnUpdateSearchXML.Text = "Update Search XML";
            this.btnUpdateSearchXML.UseVisualStyleBackColor = true;
            this.btnUpdateSearchXML.Click += new System.EventHandler(this.btnUpdateSearchXML_Click);
            // 
            // frmMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 310);
            this.Controls.Add(this.btnUpdateSearchXML);
            this.Name = "frmMaintenance";
            this.Text = "frmMaintenance";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUpdateSearchXML;
    }
}