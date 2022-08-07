using System;
using System.Windows.Forms;
using System.Net;

namespace Saatphere_WIN.Masters
{
    public partial class FrmMultipleProfilePicUpload : Form
    {
        string _filetoUpload = string.Empty;

        public FrmMultipleProfilePicUpload()
        {
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (txtProfileID.Text.Length > 0)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    //Get the Image Destination path
                    var imageName = txtProfileID.Text + System.IO.Path.GetExtension(_filetoUpload);
                    var imgPath = txtProfileID.Text.Substring(0, 1) + "-Images/" + imageName;

                    var ftpusername = SaatphereWIN.DAL.Constants.FtpUsername;
                    var ftppassword = SaatphereWIN.DAL.Constants.FtpPassword;
                    var fileurl = _filetoUpload;

                    var ftpClient = (FtpWebRequest)FtpWebRequest.Create(ftpurl);
                    ftpClient.Credentials = new System.Net.NetworkCredential(ftpusername, ftppassword);
                    ftpClient.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
                    ftpClient.UseBinary = true;
                    ftpClient.KeepAlive = true;
                    var fi = new System.IO.FileInfo(fileurl);
                    ftpClient.ContentLength = fi.Length;
                    byte[] buffer = new byte[4097];
                    var bytes = 0;
                    var totalBytes = (int)fi.Length;
                    var fs = fi.OpenRead();
                    var rs = ftpClient.GetRequestStream();
                    while (totalBytes > 0)
                    {
                        bytes = fs.Read(buffer, 0, buffer.Length);
                        rs.Write(buffer, 0, bytes);
                        totalBytes = totalBytes - bytes;
                    }
                    //fs.Flush();
                    fs.Close();
                    rs.Close();
                    var uploadResponse = (FtpWebResponse)ftpClient.GetResponse();
                    var value = uploadResponse.StatusDescription;
                    uploadResponse.Close();
                    

                    //Update the photo name in the Profile so that it could visible outside
                    new SaatphereWIN.DAL.User.ClsUpdate().UpdatePhotograph(Convert.ToInt32(txtProfileID.Text.Trim()), imageName);

                    MessageBox.Show(@"Image has uploaded successfully.");
                    txtProfileID.Text = string.Empty;
                    txtImagePath.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Arrow;
                    MessageBox.Show(@"Error: " + ex.Message + @" Please try again."); ;
                }
                finally
                {
                    Cursor.Current = Cursors.Arrow;
                }
            }
            else
            {
                MessageBox.Show(@"Profile ID is mandatory.");
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            _filetoUpload = openFileDialog1.FileName;
            txtImagePath.Text = openFileDialog1.FileName;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
