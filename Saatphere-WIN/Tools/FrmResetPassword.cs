using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Saatphere_WIN.Tools
{
    public partial class FrmResetPassword : Form
    {
        public FrmResetPassword()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmResetPassword_Load(object sender, EventArgs e)
        {
            BindFranchisees();
        }

        private void BindFranchisees()
        {
        }

        private void btnResend_Click(object sender, EventArgs e)
        {
            string franchiseeName = string.Empty;
            string franchiseePassword = string.Empty;

            string mailBody = string.Empty;

            try
            {
                DataSet dstFranchisees = new DataSet();

                for (int i = 0; i <= dstFranchisees.Tables[0].Rows.Count - 1; i++)
                {
                    franchiseeName = dstFranchisees.Tables[0].Rows[i]["franchiseeusername"].ToString();


                    mailBody = mailBody + "<br/> " + franchiseeName + " - " + franchiseePassword;
                    MessageBox.Show(mailBody);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
