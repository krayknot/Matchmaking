using System;
using System.Windows.Forms;

namespace Saatphere_WIN.Masters
{
    public partial class FrmAddUser : Form
    {
        public FrmAddUser()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BindFranchisees()
        {
            cmbBranch.DisplayMember = "FranchiseeUsername";
            cmbBranch.ValueMember = "FrRowID";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Validations
            var flag = false;

            var username = txtUsername.Text;
            var password = txtPassword.Text;
            var confirmPassword = txtConfirmPassword.Text;
            var error = string.Empty;
            var branchId = Convert.ToInt32(cmbBranch.SelectedValue);
            var name = txtName.Text;

            if (username.Length < 0)
            {
                error = error + "- Username is mandatory. \n";
                flag = true;
            }

            if (password.Length < 0)
            {
                error = error + "- Password is mandatory. \n";
                flag = true;
            }

            if (confirmPassword.Length < 0)
            {
                error = error + "- Confirm Password is mandatory. \n";
                flag = true;
            }

            if (password != confirmPassword)
            {
                error = error + "- Both password should match. \n";
                flag = true;
            }

            if (flag == false)
            {
                var executiveDetails = new SaatphereWIN.DAL.DataTypes.Executive
                {
                    ExecutiveActive = true,
                    ExecutiveDateCreated = DateTime.Now,
                    ExecutiveFranchiseeCid = branchId,
                    ExecutiveName = name,
                    ExecutivePassword = EnCryptDecrypt.CryptorEngine.Encrypt(password, true, "1982"),
                    ExecutiveUsername = username
                };

                {
                    MessageBox.Show(@"Executive Added successfully.", @"Information - Saatphere", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    InitializeForm();
                }
                else
                {
                    MessageBox.Show(@"Username already exists.", @"Information - Saatphere", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(@"There are errors \n\n" + error, @"Errors - Saatphere", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeForm()
        {
            txtName.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;

            txtName.Focus();
        }

        private void frmAddUser_Load(object sender, EventArgs e)
        {
            BindFranchisees();
        }

        private void txtConfirmPassword_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void txtConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
        }

        private void txtName_Click(object sender, EventArgs e)
        {
            txtName.SelectAll();
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            txtUsername.SelectAll();
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.SelectAll();
        }

        private void txtConfirmPassword_Click(object sender, EventArgs e)
        {
            txtConfirmPassword.SelectAll();
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            txtName.SelectAll();
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            txtUsername.SelectAll();
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.SelectAll();
        }

        private void txtConfirmPassword_Enter(object sender, EventArgs e)
        {
            txtConfirmPassword.SelectAll();
        }
    }
}
