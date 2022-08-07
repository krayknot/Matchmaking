using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.Win32;
using System.Net;

namespace Saatphere_WIN
{
    public partial class frmTestConnection : Form
    {
        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        public enum Style : int
        {
            Tiled,
            Centered,
            Stretched
        }

        public frmTestConnection()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //System.IO.File s = new System.Net.WebClient().OpenRead(uri.ToString());

        System.Drawing.Image img = System.Drawing.Image.FromFile("d://1.bmp");
        string tempPath = Path.Combine(Path.GetTempPath(), "1.bmp");
        img.Save(tempPath, System.Drawing.Imaging.ImageFormat.Bmp);

        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

        Style style;
            style = Style.Stretched;

        if (style == Style.Stretched)
        {
            key.SetValue(@"WallpaperStyle", 2.ToString());
            key.SetValue(@"TileWallpaper", 0.ToString());
        }

        if (style == Style.Centered)
        {
            key.SetValue(@"WallpaperStyle", 1.ToString());
            key.SetValue(@"TileWallpaper", 0.ToString());
        }

        if (style == Style.Tiled)
        {
            key.SetValue(@"WallpaperStyle", 1.ToString());
            key.SetValue(@"TileWallpaper", 1.ToString());
        }

        SystemParametersInfo(SPI_SETDESKWALLPAPER,
            0,
            tempPath,
            SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
    }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string ftpusername = "peoplvrd";
                string ftppassword = "qwedsa@123";
                string fileurl = "d://6.jpg";

                FtpWebRequest ftpClient = (FtpWebRequest)FtpWebRequest.Create(ftpurl);
                ftpClient.Credentials = new System.Net.NetworkCredential(ftpusername, ftppassword);
                ftpClient.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
                ftpClient.UseBinary = true;
                ftpClient.KeepAlive = true;
                System.IO.FileInfo fi = new System.IO.FileInfo(fileurl);
                ftpClient.ContentLength = fi.Length;
                byte[] buffer = new byte[4097];
                int bytes = 0;
                int total_bytes = (int)fi.Length;
                System.IO.FileStream fs = fi.OpenRead();
                System.IO.Stream rs = ftpClient.GetRequestStream();
                while (total_bytes > 0)
                {
                    bytes = fs.Read(buffer, 0, buffer.Length);
                    rs.Write(buffer, 0, bytes);
                    total_bytes = total_bytes - bytes;
                }
                //fs.Flush();
                fs.Close();
                rs.Close();
                FtpWebResponse uploadResponse = (FtpWebResponse)ftpClient.GetResponse();
                string value = uploadResponse.StatusDescription;
                uploadResponse.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + " Please try again." ); ;
            }            
        }

        private void button3_Click(object sender, EventArgs e)
        {
    }
        
}

