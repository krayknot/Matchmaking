using System;
using System.Windows.Forms;
using SaatphereWIN.DAL.DataTypes;

namespace Saatphere_WIN.Franchisee
{
    public partial class FrmExecutiveAdd : Form
    {
        public FrmExecutiveAdd()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Validation
            var flag = false;
            var executiveName = txtExecutiveName.Text.Trim();

            if (executiveName.Length < 1)
            {
                flag = true;
            }

            if (flag == false)
            {
                var executiveDetails = new Executive
                {
                    ExecutiveName = executiveName
                };

                MessageBox.Show(@"Executive has added succesfully.");
                txtExecutiveName.Text = string.Empty;
            }
            else
            {
                MessageBox.Show(@"All fields with * are mandatory to enter.");
            }
        }
    }
}
