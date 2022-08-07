using System;
using System.Windows.Forms;

namespace Saatphere_WIN.MessageBoxes
{
    public partial class FrmPermissionDialog : Form
    {
        public FrmPermissionDialog()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
