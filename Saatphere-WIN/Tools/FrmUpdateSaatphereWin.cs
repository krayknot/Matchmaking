using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace Saatphere_WIN.Tools
{
    public partial class FrmUpdateSaatphereWin : Form
    {
        public FrmUpdateSaatphereWin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CheckVersion()
        {
            try
            {
                string folderInfo = Application.CommonAppDataPath;

                request.Credentials = new NetworkCredential(SaatphereWIN.DAL.Constants.FtpUsername, SaatphereWIN.DAL.Constants.FtpPassword);
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string text = reader.ReadToEnd();
                response.Close();


                //Download the Features file
                requestFeatures.Method = WebRequestMethods.Ftp.DownloadFile;
                requestFeatures.Credentials = new NetworkCredential(SaatphereWIN.DAL.Constants.FtpUsername, SaatphereWIN.DAL.Constants.FtpPassword);
                FtpWebResponse responseFeatures = (FtpWebResponse)requestFeatures.GetResponse();
                StreamReader readerFeature = new StreamReader(responseFeatures.GetResponseStream());
                string textFeature = readerFeature.ReadToEnd();
                response.Close();

                string moreInfo = "\nFor more information please contact krayknot below - \nEmail - krayknot@gmail.com, contact@krayknot.com\nPhone - 91-9503177442";
                if (SaatphereWIN.DAL.Constants.ApplicationVersion < Convert.ToDecimal(text))
                {
                    MessageBox.Show("There is new version available to download with the following features - \n" + textFeature + moreInfo, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in checking and downloading new Version.\nYou can Download the updates, if available, from Help>Check for Updates", "Information - Saatphere", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                CheckVersion();
            }
            catch (Exception)
            {
                Cursor.Current = Cursors.WaitCursor;

                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.ShowDialog();
                string folderInfo = fbd.SelectedPath;

                request.Method = WebRequestMethods.Ftp.DownloadFile;

                request.Credentials = new NetworkCredential(SaatphereWIN.DAL.Constants.FtpUsername, SaatphereWIN.DAL.Constants.FtpPassword);

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                FileStream file = File.Create(folderInfo + "\\SaatphereWin.rar");
                byte[] buffer = new byte[32 * 1024];
                int read;
                //reader.Read(

                while ((read = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    file.Write(buffer, 0, read);
                }

                file.Close();
                responseStream.Close();
                response.Close();

                Cursor.Current = Cursors.Arrow;

                if (MessageBox.Show("Open download folder?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    Process.Start(folderInfo);
                }
            }
            
            
            
        }
    }
}
