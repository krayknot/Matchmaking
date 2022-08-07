using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Saatphere_WIN.Tools
{
    public partial class FrmPhotoDetails : Form
    {
        public FrmPhotoDetails(string ImagePath = null)
        {
            InitializeComponent();

            try
            {
                WebClient wc = new WebClient();
                wc.Headers.Add("user-agent", "Only a test!");

                byte[] bytes = wc.DownloadData(ImagePath);
                MemoryStream ms = new MemoryStream(bytes);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                pictUserImage.Image = img;
                pictUserImage.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Image does not exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbImageMode_TextChanged(object sender, EventArgs e)
        {
            if (cmbImageMode.Text == "Normal")
            {
                pictUserImage.SizeMode = PictureBoxSizeMode.Normal;
            }
            else if (cmbImageMode.Text == "StretchImage")
            {
                pictUserImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (cmbImageMode.Text == "AutoSize")
            {
                pictUserImage.SizeMode = PictureBoxSizeMode.AutoSize;
            }
            else if (cmbImageMode.Text == "CenterImage")
            {
                pictUserImage.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            else if (cmbImageMode.Text == "Zoom")
            {
                pictUserImage.SizeMode = PictureBoxSizeMode.Zoom;
            }
            pictUserImage.Refresh();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPhotoDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
