namespace BulkEmail
{
    partial class frmUploadFiles
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button9 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbEmail = new System.Windows.Forms.ComboBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnExcelfile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnhtmlfile = new System.Windows.Forms.Button();
            this.txtHtmlfile = new System.Windows.Forms.TextBox();
            this.txtExcelfile = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCloseimage = new System.Windows.Forms.Button();
            this.btnClearimage = new System.Windows.Forms.Button();
            this.btnSendImage = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbImgemail = new System.Windows.Forms.ComboBox();
            this.txtImghost = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtimgPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.Label();
            this.txtImagefile = new System.Windows.Forms.TextBox();
            this.btnImagefile = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtimgSub = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnExcelimgfile = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txtimgExcelfile = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.openFileDialog4 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(56, 194);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 25);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "&Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(259, 194);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.FileName = "openFileDialog3";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(417, 258);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button9);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnClose);
            this.tabPage1.Controls.Add(this.btnSend);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(409, 232);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Send HTML File";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(159, 196);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 13;
            this.button9.Text = "C&lear";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbEmail);
            this.groupBox1.Controls.Add(this.txtHost);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSubject);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.btnExcelfile);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnhtmlfile);
            this.groupBox1.Controls.Add(this.txtHtmlfile);
            this.groupBox1.Controls.Add(this.txtExcelfile);
            this.groupBox1.Location = new System.Drawing.Point(7, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 170);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Send HTML";
            // 
            // cmbEmail
            // 
            this.cmbEmail.FormattingEnabled = true;
            this.cmbEmail.Items.AddRange(new object[] {
            "Saatphere",
            "Saatphere Gmail",
            "Shreeshaadi",
            "Shreeshaadi Gmail"});
            this.cmbEmail.Location = new System.Drawing.Point(185, 35);
            this.cmbEmail.Name = "cmbEmail";
            this.cmbEmail.Size = new System.Drawing.Size(142, 21);
            this.cmbEmail.TabIndex = 24;
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(185, 10);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(100, 20);
            this.txtHost.TabIndex = 23;
            this.txtHost.Visible = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(94, 14);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(70, 13);
            this.label18.TabIndex = 22;
            this.label18.Text = "Host Address";
            this.label18.Visible = false;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(185, 61);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(142, 20);
            this.txtPass.TabIndex = 21;
            this.txtPass.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Please Select HTML File";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(185, 139);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(142, 20);
            this.txtSubject.TabIndex = 10;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(46, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(116, 13);
            this.label14.TabIndex = 19;
            this.label14.Text = "Please Enter Password";
            this.label14.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Please Select Excel File (.xls) ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(24, 38);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(140, 13);
            this.label17.TabIndex = 18;
            this.label17.Text = "Please Select Sender Name";
            // 
            // btnExcelfile
            // 
            this.btnExcelfile.Location = new System.Drawing.Point(333, 111);
            this.btnExcelfile.Name = "btnExcelfile";
            this.btnExcelfile.Size = new System.Drawing.Size(24, 23);
            this.btnExcelfile.TabIndex = 2;
            this.btnExcelfile.Text = "...";
            this.btnExcelfile.UseVisualStyleBackColor = true;
            this.btnExcelfile.Click += new System.EventHandler(this.btnExcelfile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Subject";
            // 
            // btnhtmlfile
            // 
            this.btnhtmlfile.Location = new System.Drawing.Point(333, 85);
            this.btnhtmlfile.Name = "btnhtmlfile";
            this.btnhtmlfile.Size = new System.Drawing.Size(24, 23);
            this.btnhtmlfile.TabIndex = 1;
            this.btnhtmlfile.Text = "...";
            this.btnhtmlfile.UseVisualStyleBackColor = true;
            this.btnhtmlfile.Click += new System.EventHandler(this.btnhtmlfile_Click);
            // 
            // txtHtmlfile
            // 
            this.txtHtmlfile.Location = new System.Drawing.Point(185, 87);
            this.txtHtmlfile.Name = "txtHtmlfile";
            this.txtHtmlfile.Size = new System.Drawing.Size(142, 20);
            this.txtHtmlfile.TabIndex = 0;
            // 
            // txtExcelfile
            // 
            this.txtExcelfile.Location = new System.Drawing.Point(185, 113);
            this.txtExcelfile.Name = "txtExcelfile";
            this.txtExcelfile.Size = new System.Drawing.Size(142, 20);
            this.txtExcelfile.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnCloseimage);
            this.tabPage2.Controls.Add(this.btnClearimage);
            this.tabPage2.Controls.Add(this.btnSendImage);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(409, 232);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Send Image File";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCloseimage
            // 
            this.btnCloseimage.Location = new System.Drawing.Point(259, 194);
            this.btnCloseimage.Name = "btnCloseimage";
            this.btnCloseimage.Size = new System.Drawing.Size(75, 23);
            this.btnCloseimage.TabIndex = 17;
            this.btnCloseimage.Text = "&Close";
            this.btnCloseimage.UseVisualStyleBackColor = true;
            this.btnCloseimage.Click += new System.EventHandler(this.btnCloseimage_Click);
            // 
            // btnClearimage
            // 
            this.btnClearimage.Location = new System.Drawing.Point(162, 194);
            this.btnClearimage.Name = "btnClearimage";
            this.btnClearimage.Size = new System.Drawing.Size(75, 23);
            this.btnClearimage.TabIndex = 16;
            this.btnClearimage.Text = "C&lear";
            this.btnClearimage.UseVisualStyleBackColor = true;
            this.btnClearimage.Click += new System.EventHandler(this.btnClearimage_Click);
            // 
            // btnSendImage
            // 
            this.btnSendImage.Location = new System.Drawing.Point(56, 194);
            this.btnSendImage.Name = "btnSendImage";
            this.btnSendImage.Size = new System.Drawing.Size(75, 23);
            this.btnSendImage.TabIndex = 15;
            this.btnSendImage.Text = "Send";
            this.btnSendImage.UseVisualStyleBackColor = true;
            this.btnSendImage.Click += new System.EventHandler(this.btnSendImage_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbImgemail);
            this.groupBox2.Controls.Add(this.txtImghost);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.txtimgPass);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.Email);
            this.groupBox2.Controls.Add(this.txtImagefile);
            this.groupBox2.Controls.Add(this.btnImagefile);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtimgSub);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.btnExcelimgfile);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtimgExcelfile);
            this.groupBox2.Location = new System.Drawing.Point(7, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(396, 170);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Send IMAGE";
            // 
            // cmbImgemail
            // 
            this.cmbImgemail.FormattingEnabled = true;
            this.cmbImgemail.Items.AddRange(new object[] {
            "Saatphere",
            "Saatphere Gmail",
            "Shreeshaadi",
            "Shreeshaadi Gmail"});
            this.cmbImgemail.Location = new System.Drawing.Point(185, 36);
            this.cmbImgemail.Name = "cmbImgemail";
            this.cmbImgemail.Size = new System.Drawing.Size(142, 21);
            this.cmbImgemail.TabIndex = 19;
            // 
            // txtImghost
            // 
            this.txtImghost.Location = new System.Drawing.Point(185, 10);
            this.txtImghost.Name = "txtImghost";
            this.txtImghost.Size = new System.Drawing.Size(100, 20);
            this.txtImghost.TabIndex = 18;
            this.txtImghost.Visible = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(94, 14);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(70, 13);
            this.label19.TabIndex = 14;
            this.label19.Text = "Host Address";
            this.label19.Visible = false;
            // 
            // txtimgPass
            // 
            this.txtimgPass.Location = new System.Drawing.Point(185, 61);
            this.txtimgPass.Name = "txtimgPass";
            this.txtimgPass.PasswordChar = '*';
            this.txtimgPass.Size = new System.Drawing.Size(142, 20);
            this.txtimgPass.TabIndex = 17;
            this.txtimgPass.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Please Enter Password";
            this.label4.Visible = false;
            // 
            // Email
            // 
            this.Email.AutoSize = true;
            this.Email.Location = new System.Drawing.Point(66, 38);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(98, 13);
            this.Email.TabIndex = 14;
            this.Email.Text = "Please Enter Email ";
            // 
            // txtImagefile
            // 
            this.txtImagefile.Location = new System.Drawing.Point(185, 87);
            this.txtImagefile.Name = "txtImagefile";
            this.txtImagefile.Size = new System.Drawing.Size(142, 20);
            this.txtImagefile.TabIndex = 13;
            // 
            // btnImagefile
            // 
            this.btnImagefile.Location = new System.Drawing.Point(333, 87);
            this.btnImagefile.Name = "btnImagefile";
            this.btnImagefile.Size = new System.Drawing.Size(24, 23);
            this.btnImagefile.TabIndex = 12;
            this.btnImagefile.Text = "...";
            this.btnImagefile.UseVisualStyleBackColor = true;
            this.btnImagefile.Click += new System.EventHandler(this.btnImagefile_Click_1);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(46, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(118, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "Please select Image file";
            // 
            // txtimgSub
            // 
            this.txtimgSub.Location = new System.Drawing.Point(185, 139);
            this.txtimgSub.Name = "txtimgSub";
            this.txtimgSub.Size = new System.Drawing.Size(142, 20);
            this.txtimgSub.TabIndex = 10;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 116);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(147, 13);
            this.label15.TabIndex = 8;
            this.label15.Text = "Please Select Excel File (.xls) ";
            // 
            // btnExcelimgfile
            // 
            this.btnExcelimgfile.Location = new System.Drawing.Point(333, 116);
            this.btnExcelimgfile.Name = "btnExcelimgfile";
            this.btnExcelimgfile.Size = new System.Drawing.Size(24, 23);
            this.btnExcelimgfile.TabIndex = 2;
            this.btnExcelimgfile.Text = "...";
            this.btnExcelimgfile.UseVisualStyleBackColor = true;
            this.btnExcelimgfile.Click += new System.EventHandler(this.btnExcelimgfile_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(121, 142);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 13);
            this.label16.TabIndex = 9;
            this.label16.Text = "Subject";
            // 
            // txtimgExcelfile
            // 
            this.txtimgExcelfile.Location = new System.Drawing.Point(185, 113);
            this.txtimgExcelfile.Name = "txtimgExcelfile";
            this.txtimgExcelfile.Size = new System.Drawing.Size(142, 20);
            this.txtimgExcelfile.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(185, 83);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(142, 20);
            this.textBox1.TabIndex = 13;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(333, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Please select Image file";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Please Select HTML File";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(185, 112);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(142, 20);
            this.textBox2.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Please Select Excel File (.xls) ";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(333, 50);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(24, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(121, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Subject";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(333, 22);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(24, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(185, 22);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(142, 20);
            this.textBox3.TabIndex = 0;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(185, 52);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(142, 20);
            this.textBox4.TabIndex = 3;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(185, 83);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(142, 20);
            this.textBox5.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(333, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(46, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Please select Image file";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(40, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Please Select HTML File";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(185, 112);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(142, 20);
            this.textBox6.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(147, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Please Select Excel File (.xls) ";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(333, 50);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(24, 23);
            this.button5.TabIndex = 2;
            this.button5.Text = "...";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(121, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Subject";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(333, 22);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(24, 23);
            this.button6.TabIndex = 1;
            this.button6.Text = "...";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(185, 22);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(142, 20);
            this.textBox7.TabIndex = 0;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(185, 52);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(142, 20);
            this.textBox8.TabIndex = 3;
            // 
            // openFileDialog4
            // 
            this.openFileDialog4.FileName = "openFileDialog4";
            // 
            // frmUploadFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 278);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmUploadFiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Send Bulk Email";
            this.Load += new System.EventHandler(this.frmUploadFiles_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.OpenFileDialog openFileDialog3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExcelfile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnhtmlfile;
        private System.Windows.Forms.TextBox txtHtmlfile;
        private System.Windows.Forms.TextBox txtExcelfile;
        private System.Windows.Forms.Button btnCloseimage;
        private System.Windows.Forms.Button btnClearimage;
        private System.Windows.Forms.Button btnSendImage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtImagefile;
        private System.Windows.Forms.Button btnImagefile;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtimgSub;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnExcelimgfile;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtimgExcelfile;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.OpenFileDialog openFileDialog4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Email;
        private System.Windows.Forms.TextBox txtimgPass;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtImghost;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbEmail;
        private System.Windows.Forms.ComboBox cmbImgemail;
    }
}

