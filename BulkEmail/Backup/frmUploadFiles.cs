using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Net;
//using System.Net.WebRequestMethods;
using System.IO;
using System.Data.OleDb;

namespace BulkEmail
{
    public partial class frmUploadFiles : Form
    {
        public frmUploadFiles()
        {
            InitializeComponent();
        }

        private void btnhtmlfile_Click(object sender, EventArgs e)
        {
            //openFileDialog1.ShowDialog();
            openFileDialog1.Title = "Select an Html File";           
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtHtmlfile.Text = Path.GetFileName(openFileDialog1.FileName);
            }
            string fileName = Path.GetFileName(openFileDialog1.FileName);
            string sourcePath = "@" + txtHtmlfile.Text;
            string targetPath = Application.StartupPath + "\\File\\" + fileName;
            File.Copy(txtHtmlfile.Text, targetPath, true);
            Global.html = txtHtmlfile.Text;
        }

        private void btnExcelfile_Click(object sender, EventArgs e)
        {
            //openFileDialog2.ShowDialog();
            openFileDialog2.Title = "Select an Excel File";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                txtExcelfile.Text = Path.GetFileName(openFileDialog2.FileName);
            }
            string excelfileName = Path.GetFileName(openFileDialog2.FileName);
            string excelsourcePath = "@" + txtExcelfile.Text;
            string exceltargetPath = Application.StartupPath + "\\File\\" + excelfileName;
            File.Copy(txtExcelfile.Text, exceltargetPath, true);
            Global.excel = txtExcelfile.Text;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            String strFilePath = Application.StartupPath + "\\File\\" + Global.excel;
            String strExcelConn = "Provider=Microsoft.Jet.OLEDB.4.0;"
            + "Data Source=" + strFilePath + ";"
            + "Extended Properties='Excel 8.0;HDR=Yes'";
            OleDbConnection connExcel = new OleDbConnection(strExcelConn);
            OleDbCommand cmdExcel = new OleDbCommand();
            //try
            //{
            cmdExcel.Connection = connExcel;

            //Check if the Sheet Exists
            connExcel.Open();
            DataTable dtExcelSchema;
            //Get the Schema of the WorkBook
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            connExcel.Close();

            //Read Data from Sheet1
            connExcel.Open();
            OleDbDataAdapter da = new OleDbDataAdapter();
            DataSet ds = new DataSet();
            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            cmdExcel.CommandText = "SELECT ID From [" + SheetName + "]";
            //Range Query
            //cmdExcel.CommandText = "SELECT * From [" + SheetName + "A3:B5]";


            da.SelectCommand = cmdExcel;
            da.Fill(ds);
            string str = "";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                str = ds.Tables[0].Rows[i]["ID"].ToString() + "";
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(strRegex);

                try
                {
                    if (re.IsMatch(str))
                    {
                        Global email = new Global();
                        StreamReader reader = File.OpenText(Application.StartupPath + "\\File\\" + Global.html);
                        //string host = txtHost.Text;
                        string host = "";
                        string emailaddress = cmbEmail.Text;
                        string fromdisplayname = "";
                        string toemailaddress = str;
                        string todisplayname = "";
                        string subject = txtSubject.Text;
                        string body = reader.ReadToEnd();
                        //string password = txtPass.Text;
                        string password = "";
                        string fromemailaddress = string.Empty;
                        int port = 0;
                        if (emailaddress == "Saatphere")
                        {
                            fromemailaddress = "saatphere@peopleonegroup.com";
                            host = "webmail.peopleonegroup.com";
                            password = "P@ssw0rd";
                            fromdisplayname = "Saatphere";
                            email.sendMail(fromemailaddress, fromdisplayname, toemailaddress, todisplayname, subject, body, password, "", host);
                        }



                        if (emailaddress == "Saatphere Gmail")
                        {
                            fromemailaddress = "saatphere.peopleonegroup@gmail.com";
                            host = "smtp.gmail.com";
                            password = "s@@t7fere";
                            fromdisplayname = "Saat Phere";
                            port = 587;
                            email.sendMailfromgmail(fromemailaddress, fromdisplayname, toemailaddress, todisplayname, subject, body, password, "", host, port);
                        }



                        if (emailaddress == "Shreeshaadi")
                        {
                            fromemailaddress = "info@shreeshaadi.com";
                            host = "webmail.shreeshaadi.com";
                            password = "s$$t@r@m";
                            fromdisplayname = "Shreeshaadi";
                            email.sendMail(fromemailaddress, fromdisplayname, toemailaddress, todisplayname, subject, body, password, "", host);
                        }

                        if (emailaddress == "Shreeshaadi Gmail")
                        {
                            fromemailaddress = "shreeshaadimum@gmail.com";
                            host = "smtp.gmail.com";
                            port = 587;
                            password = "shree*shaadi";
                            fromdisplayname = "Shreeshaadi";
                            email.sendMailfromgmail(fromemailaddress, fromdisplayname, toemailaddress, todisplayname, subject, body, password, "", host, port);
                        }

                        string path1 = Application.StartupPath + "\\File\\Sent.txt";
                        StreamWriter writer = File.AppendText(path1);
                        writer.WriteLine(str);
                        //writer.Flush();
                        writer.Close();

                    }
                    else
                    {
                        string path = Application.StartupPath + "\\File\\Error.txt";
                        StreamWriter writer = File.AppendText(path);
                        writer.WriteLine(str);
                        //writer.Flush();
                        writer.Close();
                    }
                   

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error");
                }


            }



            MessageBox.Show("Email has been sent successfully");
            //txtEmail.Text = "";
            cmbEmail.Text = "";
            txtPass.Text = "";
            txtHtmlfile.Text = "";
            txtExcelfile.Text = "";
            txtSubject.Text = "";
            txtHost.Text = "";
            //str = str.Substring(0, str.Length - 1);
            //TextBox1.Text = str;
            connExcel.Close();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
          
        //}

        private void frmUploadFiles_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(Application.StartupPath + "\\File"))
            {
                string foldername = Application.StartupPath + "\\File";
                Directory.CreateDirectory(foldername);
            }

            string fileLoc = Application.StartupPath + "\\File\\Sent.txt";
            FileStream fs = null;

            if (!File.Exists(fileLoc))
            {
                using (fs = File.Create(fileLoc))
                {
                }
            }

            string fileLoc2 = Application.StartupPath + "\\File\\Error.txt";
            FileStream fs2 = null;

            if (!File.Exists(fileLoc2))
            {
                using (fs2 = File.Create(fileLoc2))
                {
                }
            }

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImagefile_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
            openFileDialog2.Title = "Select an Excel File";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                txtExcelfile.Text = Path.GetFileName(openFileDialog2.FileName);
            }
            string excelfileName = Path.GetFileName(openFileDialog2.FileName);
            string excelsourcePath = "@" + txtExcelfile.Text;
            string exceltargetPath = Application.StartupPath + "\\File\\" + excelfileName;
            File.Copy(txtExcelfile.Text, exceltargetPath, true);
            Global.excel = txtExcelfile.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtHost.Text = "";
            //txtEmail.Text = "";
            cmbEmail.Text = "";
            txtPass.Text = "";
            txtHtmlfile.Text = "";
            txtExcelfile.Text = "";
            txtSubject.Text = "";
        }

        private void btnClearimage_Click(object sender, EventArgs e)
        {
            cmbImgemail.Text = "";
            txtimgPass.Text = "";
            txtImagefile.Text = "";
            txtimgExcelfile.Text = "";
            txtimgSub.Text = "";
            txtImghost.Text = "";
        }

        private void btnImagefile_Click_1(object sender, EventArgs e)
        {
            //openFileDialog3.ShowDialog();
            openFileDialog3.Title = "Select an Image File";
            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                txtImagefile.Text = Path.GetFileName(openFileDialog3.FileName);
            }
            string fileName = Path.GetFileName(openFileDialog3.FileName);
            string sourcePath = "@" + txtImagefile.Text;
            string targetPath = Application.StartupPath + "\\File\\" + fileName;
            File.Copy(txtImagefile.Text, targetPath, true);

            MessageBox.Show("Image is uploading on Server, This may take some time");

            FileInfo toUpload = new FileInfo(txtImagefile.Text);
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.images.peopleonegroup.com//httpdocs//IMAGESFOREMAILERS//" + toUpload.Name);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential("imagespog", "@pplication");
            Stream ftpstream = request.GetRequestStream();
            FileStream file = File.OpenRead(txtImagefile.Text);
            int lenght = 1024;
            byte[] buffer = new byte[lenght];
            int bytesread = 0;
            do
            {
                bytesread = file.Read(buffer, 0, lenght);
                ftpstream.Write(buffer, 0, bytesread);
            }
            while (bytesread != 0);
            file.Close();
            ftpstream.Close();

            //MessageBox.Show("DONE");
            Global.image = txtImagefile.Text;
        }

        private void btnExcelimgfile_Click(object sender, EventArgs e)
        {
            //openFileDialog4.ShowDialog();
            openFileDialog4.Title = "Select an Excel File";
            if (openFileDialog4.ShowDialog() == DialogResult.OK)
            {
                txtimgExcelfile.Text = Path.GetFileName(openFileDialog4.FileName);
            }
            string excelfileName = Path.GetFileName(openFileDialog4.FileName);
            string excelsourcePath = "@" + txtimgExcelfile.Text;
            string exceltargetPath = Application.StartupPath + "\\File\\" + excelfileName;
            File.Copy(txtimgExcelfile.Text, exceltargetPath, true);
            Global.imgexcel = txtimgExcelfile.Text;
        }

        private void btnSendImage_Click(object sender, EventArgs e)
        {
            String strFilePath = Application.StartupPath + "\\File\\" + Global.imgexcel;
            String strExcelConn = "Provider=Microsoft.Jet.OLEDB.4.0;"
            + "Data Source=" + strFilePath + ";"
            + "Extended Properties='Excel 8.0;HDR=Yes'";
            OleDbConnection connExcel = new OleDbConnection(strExcelConn);
            OleDbCommand cmdExcel = new OleDbCommand();
            //try
            //{
            cmdExcel.Connection = connExcel;

            //Check if the Sheet Exists
            connExcel.Open();
            DataTable dtExcelSchema;
            //Get the Schema of the WorkBook
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            connExcel.Close();

            //Read Data from Sheet1
            connExcel.Open();
            OleDbDataAdapter da = new OleDbDataAdapter();
            DataSet ds = new DataSet();
            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            cmdExcel.CommandText = "SELECT ID From [" + SheetName + "]";
            //Range Query
            //cmdExcel.CommandText = "SELECT * From [" + SheetName + "A3:B5]";


            da.SelectCommand = cmdExcel;
            da.Fill(ds);
            string str = "";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                str = ds.Tables[0].Rows[i]["ID"].ToString() + "";
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(strRegex);

                try
                {
                    if (re.IsMatch(str))
                    {
                        Global email = new Global();
                        //StreamReader reader = File.OpenText(Application.StartupPath + "\\File\\" + Global.image);
                        string host = "";
                        string emailaddress = cmbImgemail.Text;
                        string fromdisplayname = "";
                        string toemailaddress = str;
                        string todisplayname = "";
                        string subject = txtimgSub.Text;
                      
                        string body = "<html><head><titile></titile><body><img src='http://www.images.peopleonegroup.com/IMAGESFOREMAILERS/" + Global.image + "'/></body></head></html>";
                        string password = "";
                        string fromemailaddress = string.Empty;
                        int port = 0;

                        if (emailaddress == "Saatphere")
                        {
                            fromemailaddress = "saatphere@peopleonegroup.com";
                            host = "webmail.peopleonegroup.com";
                            password = "P@ssw0rd";
                            fromdisplayname = "Saatphere";
                            email.sendMail(fromemailaddress, fromdisplayname, toemailaddress, todisplayname, subject, body, password, "", host);
                        }



                        if (emailaddress == "Saatphere Gmail")
                        {
                            fromemailaddress = "saatphere.peopleonegroup@gmail.com";
                            host = "smtp.gmail.com";
                            password = "s@@t7fere";
                            fromdisplayname = "Saat Phere";
                            port = 587;
                            email.sendMailfromgmail(fromemailaddress, fromdisplayname, toemailaddress, todisplayname, subject, body, password, "", host, port);
                        }



                        if (emailaddress == "Shreeshaadi")
                        {
                            fromemailaddress = "info@shreeshaadi.com";
                            host = "webmail.shreeshaadi.com";
                            password = "s$$t@r@m";
                            fromdisplayname = "Shreeshaadi";
                            email.sendMail(fromemailaddress, fromdisplayname, toemailaddress, todisplayname, subject, body, password, "", host);
                        }

                        if (emailaddress == "Shreeshaadi Gmail")
                        {
                            fromemailaddress = "shreeshaadimum@gmail.com";
                            host = "smtp.gmail.com";
                            port = 587;
                            password = "kaushal80";
                            fromdisplayname = "Shreeshaadi";
                            email.sendMailfromgmail(fromemailaddress, fromdisplayname, toemailaddress, todisplayname, subject, body, password, "", host, port);
                        }


                     
                        
                        
                        string path1 = Application.StartupPath + "\\File\\Sent.txt";
                        StreamWriter writer = File.AppendText(path1);
                        writer.WriteLine(str);
                        //writer.Flush();
                        writer.Close();

                    }
                    else
                    {
                        string path = Application.StartupPath + "\\File\\Error.txt";
                        StreamWriter writer = File.AppendText(path);
                        writer.WriteLine(str);
                        //writer.Flush();
                        writer.Close();
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error");
                }


            }
            MessageBox.Show("Email has been sent successfully");
            cmbImgemail.Text = "";
            txtimgPass.Text = "";
            txtImagefile.Text = "";
            txtimgExcelfile.Text = "";
            txtimgSub.Text = "";
            txtImghost.Text = "";

            //str = str.Substring(0, str.Length - 1);
            //TextBox1.Text = str;
            connExcel.Close();
        }

        private void btnCloseimage_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

       

       

       
    }
}
