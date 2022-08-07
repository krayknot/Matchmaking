using System;
using System.Linq.Expressions;
using System.Windows.Forms;


namespace Saatphere_WIN.Customer
{
    public partial class FrmUploadCustomers : Form
    {
        public string StrExcelPathName = string.Empty;


        public FrmUploadCustomers()
        {
            InitializeComponent();
        }


        private void btnClose_ClientSizeChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var fdlg = new OpenFileDialog
            {
                Title = @"Select file",
                InitialDirectory = @"c:\",
                FileName = txtExcelPath.Text,
                Filter = @"Excel Sheet(*.xls)|*.xls|All Files(*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                txtExcelPath.Text = fdlg.FileName;
                Application.DoEvents();
            }

            Cursor.Current = Cursors.WaitCursor;

          
            lblTotalRecords.Text = dgrdRecords.Rows.Count.ToString();
            Cursor.Current = Cursors.Arrow;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var customerName = "";
            var customerPhone = "" ;
            var executive = 0 ;
            var remarks = string.Empty;
            const string callDirection = "OUTGOING";
            var language = string.Empty;

            for (var i = 0; i <= dgrdRecords.Rows.Count - 1; i++)
            {
                customerName = dgrdRecords.Rows[i].Cells[1].Value.ToString();
                customerPhone = dgrdRecords.Rows[i].Cells[0].Value.ToString();
                language = dgrdRecords.Rows[i].Cells[2].Value.ToString();
                customerName = dgrdRecords.Rows[i].Cells[3].Value.ToString();
                executive = 0; // Convert.ToInt32(cmbExecutive.SelectedValue);
                //remarks = txtRemarks.Text.Trim();



            }

            MessageBox.Show(@"Record upload has finished.", @"Information",MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }
    }
}
