using System;
using System.Windows.Forms;

namespace Saatphere_WIN.Masters
{
    public partial class FrmAddCity : Form
    {
        public FrmAddCity()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCityName.Text.Length > 0)
            {
                Cursor = Cursors.WaitCursor;
                Cursor = Cursors.Arrow;
            }
            else
            {
                MessageBox.Show(@"City name is mandatory.", @"Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtCityName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
        }
    }
}
