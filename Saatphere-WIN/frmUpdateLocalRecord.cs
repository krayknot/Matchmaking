using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Saatphere_WIN
{
    public partial class frmUpdateLocalRecord : Form
    {
        public frmUpdateLocalRecord()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int biodataID = Convert.ToInt32(txtProfileId.Text);
            string server = txtDestServer.Text;
            string username = txtDestUsername.Text;
            string password = txtDestPassword.Text;
            string database = cmbDestDatabase.Text;


        }

        private void btnDestRefresh_Click(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();

            if (ofd.FileName.Length > 0)
            {
                string filename = ofd.FileName;

                DataSet dst = new DataSet();
                dst.ReadXml(filename);

                txtDestServer.Text = dst.Tables[0].Rows[0]["Server"].ToString();
                txtDestUsername.Text = dst.Tables[0].Rows[0]["Username"].ToString();
                txtDestPassword.Text = dst.Tables[0].Rows[0]["Password"].ToString();
                cmbDestDatabase.Text = dst.Tables[0].Rows[0]["Database"].ToString();

                MessageBox.Show("Credentials loaded successfully.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
