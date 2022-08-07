using System;
using System.Windows.Forms;

namespace Saatphere_WIN.Financial
{
    public partial class FrmDsrShowAllReport : Form
    {
        public FrmDsrShowAllReport()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Current = Cursors.Arrow;
        }

        private void frmDSR_ShowAllReport_Load(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }
    }
}
