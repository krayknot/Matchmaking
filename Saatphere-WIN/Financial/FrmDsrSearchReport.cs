using System;
using System.Windows.Forms;


namespace Saatphere_WIN.Financial
{
    public partial class FrmDsrSearchReport : Form
    {
        public FrmDsrSearchReport()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFranchiseeReport_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var fromDate = dtFromFranchisee.Value;
            var toDate = dtToFranchisee.Value;
            var franchisee = cmbFranchisee.Text;

            lblTotalRecordsCount.Text = @"Total Records: " + dgrdResults.Rows.Count;
            SetAmountSum();
            Cursor.Current = Cursors.Arrow;
        }

        private void SetAmountSum()
        {
            decimal sum = 0;

            for (var i = 0; i < dgrdResults.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgrdResults.Rows[i].Cells[4].Value);
            }

            lblAmountTotal.Text = @"Total Amount: " + sum;
            lblAmountTotal.Visible = true;
        }

        private void frmDSR_SearchReport_Load(object sender, EventArgs e)
        {
            BindExecutives();
            BindUsers();
        }

        private void BindUsers()
        {
            var mbindResults = new BindingSource
            {
            };

            cmbFranchisee.DataSource = mbindResults;
            cmbFranchisee.DisplayMember = "Value";
            cmbFranchisee.ValueMember = "key";

            cmbFranchisee.SelectedValue = SaatphereWIN.DAL.Global.LoginUser;
        }

        private void BindExecutives()
        {
            cmbExecutive.DisplayMember = "DSR_ExecutiveName";
            cmbExecutive.ValueMember = "DSR_ExecutiveName";          
        }

        private void btnExecutiveReport_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            var fromDate = dtFromExecutive.Value;
            var toDate = dtToExecutive.Value;
            var executive = cmbExecutive.Text;
            lblTotalRecordsCount.Text = @"Total Records: " +(dgrdResults.Rows.Count);
            SetAmountSum();
            Cursor.Current = Cursors.Arrow;
        }
    }
}
