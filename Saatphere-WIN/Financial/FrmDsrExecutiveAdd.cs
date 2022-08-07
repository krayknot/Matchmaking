using System;
using System.Data;
using System.Windows.Forms;

namespace Saatphere_WIN.Financial
{
    public partial class FrmDsrExecutiveAdd : Form
    {
        int dsrExecutiveId;
        public FrmDsrExecutiveAdd(int dsrExecutiveId = 0)
        {
            InitializeComponent();

            if (dsrExecutiveId > 0)
            {
                var dst = new DataSet();

                txtExecutiveName.Text = dst.Tables[0].Rows[0]["DSr_ExecutiveName"].ToString();
                txt
                    
                    .Text = dst.Tables[0].Rows[0]["DSr_ExecutivePassword"].ToString();
                txtConfirmPassword.Text = txtPassword.Text;

                btnAdd.Text = @"&Edit";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var executiveName = txtExecutiveName.Text.Trim();
            var password = txtPassword.Text.Trim();
            var confirmPassword = txtConfirmPassword.Text.Trim();
            var franchisee = txtFranchisee.Text.Trim();

            var flag = false;
            var validationMessage = "There are following errors: \n";

            //Validations
            if (executiveName.Length < 1)
            {
                validationMessage = validationMessage + "- Executive Name is mandatory.\n";
                flag = true;
            }

            if (password.Length < 1)
            {
                validationMessage = validationMessage + "- Password is mandatory.\n";
                flag = true;
            }

            if (confirmPassword.Length < 1)
            {
                validationMessage = validationMessage + "- Confirm Password is mandatory.\n";
                flag = true;
            }

            if (password != confirmPassword)
            {
                validationMessage = validationMessage + "- Password and Confirm Password must match.";
                flag = true;
            }

            if (flag)
            {
                MessageBox.Show(validationMessage, @"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                var dsrExecutiveDetails = new SaatphereWIN.DAL.DataTypes.DsrExecutive
                {
                    DsrExecutiveName = executiveName,
                    DsrExecutivePassword = password,
                    DsrFranchisee = franchisee,
                    DsrId = dsrExecutiveId
                };

                var message = "";
                if (btnAdd.Text == @"&Edit")
                {
                    message = "DSR Executive has edited successfully.";
                }
                else
                {
                    message = "DSR Executive has saved successfully.";
                }
                Cursor.Current = Cursors.Arrow;

                MessageBox.Show(message, @"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (btnAdd.Text == @"&Edit")
                {
                    Close();
                }
                InitializeForm();
            }
        }

        private void InitializeForm()
        {
            txtExecutiveName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
        }

        private void frmDSRExecutiveADd_Load(object sender, EventArgs e)
        {
            if (dsrExecutiveId == 0) //Will not appear while editing the record
            {
                if (MessageBox.Show(@"It is recommended to check the Executive name to avoid duplicacy. \nDo you want to see the DSR Executive list?", @"Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    new FrmDsrExecutiveEditDelete().ShowDialog();
                }
            }

            txtFranchisee.Text = SaatphereWIN.DAL.Global.Frusername;
        }
    }
}
