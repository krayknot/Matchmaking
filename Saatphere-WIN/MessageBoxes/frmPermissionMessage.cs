using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Saatphere_WIN.MessageBoxes
{
    public partial class frmPermissionMessage : Form
    {
        public frmPermissionMessage()
        {
            InitializeComponent();
        }

        private void frmPermissionMessage_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
