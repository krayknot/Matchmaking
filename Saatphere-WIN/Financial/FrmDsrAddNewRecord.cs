using System;
using System.Windows.Forms;

namespace Saatphere_WIN.Financial
{
    public partial class FrmDsrAddNewRecord : Form
    {
        public FrmDsrAddNewRecord()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var candidatename = txtCandidateName.Text;
            var profileId = txtProfileID.Text;
            var phoneNo = txtPhoneNumber.Text;
            var membershipType = cmbMembershipType.SelectedItem.ToString(); ;

            var amount = txtAmount.Text;
            var status = cmbStatus.Text;
            var mode = txtMode.Text;
            var executiveName = cmbExecutiveName.Text;
            var franchisee = SaatphereWIN.DAL.Global.Frusername;


            var dSrDetails = new SaatphereWIN.DAL.DataTypes.SaatphereDsr
            {
                DsrAmount = Convert.ToInt32(amount),
                DsrCandidatename = candidatename,
                DsrExecutivename = executiveName,
                DsrFranchisee = franchisee,
                DsrMembershiptype = membershipType,
                DsrMode = mode,
                DsrPhoneno = phoneNo,
                DsrStatus = status,
                DsrDate = dtDSRDate.Value
            };

            Cursor.Current = Cursors.Arrow;

            MessageBox.Show(@"Record added successfully.", @"Information - Saatphere", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (MessageBox.Show(@"Add another record?", @"Question - Saatphere", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                InitializeForm();
            }
            else
            {
                Close();
            }
        }

        private void InitializeForm()
        {
            txtCandidateName.Text = string.Empty;
            txtProfileID.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtMode.Text = string.Empty;
            
        }

        private void frmDSR_AddNewRecord_Load(object sender, EventArgs e)
        {
            BindExecutives();
        }

        private void BindExecutives()
        {
            cmbExecutiveName.DisplayMember = "DSR_ExecutiveName";
            cmbExecutiveName.ValueMember = "DSR_ExecutiveName";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
