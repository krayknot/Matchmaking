using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.IO;

namespace Saatphere_WIN.Tools
{
    public partial class FrmUpdateAge : Form
    {
        public FrmUpdateAge()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Thread t = new Thread(StartUpdate);
            //t.Start();

            //this.Hide();
            StartUpdate();

            MessageBox.Show("Process has finished.","Information");
        }

    }
}
