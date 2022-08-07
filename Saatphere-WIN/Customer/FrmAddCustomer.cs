using System;
using System.Windows.Forms;

namespace Saatphere_WIN.Customer
{
    public partial class FrmAddCustomer : Form
    {
        public FrmAddCustomer()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BindExecutives()
        {
          
        }

        private void frmAddCustomer_Load(object sender, EventArgs e)
        {
            BindExecutives();
            BindMotherTongue();
        }

        private void BindMotherTongue()
        {
           var db = new SaatphereWIN.DAL.Masters.ClsSelect();

            cmbLanguage.DataSource = db.GetList("MotherTongue").Tables[0];
            cmbLanguage.DisplayMember = "value";
            cmbLanguage.ValueMember = "value";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var customerName = txtCustomerName.Text.Trim();
            var customerPhone = txtCustomerPhone.Text.Trim();
            var executive = 0; // Convert.ToInt32(cmbExecutive.SelectedValue);
            var remarks = txtRemarks.Text.Trim();
            var callDirection = rdbIncoming.Checked? "INCOMING": "OUTGOING";

            var customerDetails = new SaatphereWIN.DAL.DataTypes.CustomerDetails
            {
                CustomerDetailsActive = true,
                CustomerDetailsCreatedBy = Convert.ToInt32(SaatphereWIN.DAL.Global.FrRowId),
                CustomerDetailsDateCreated = DateTime.Now,
                CustomerDetailsExecutiveDsrid = executive,
                CustomerDetailsName = customerName,
                CustomerDetailsPhone = customerPhone,
                CustomerDetailsRemarks = remarks,
                CustomerDetailsCallDirection = callDirection,
                CustomerDetailsLanguage = cmbLanguage.Text
            };

            new SaatphereWIN.DAL.User.ClsInsert().InsertCustomerDetails(customerDetails);

            if (MessageBox.Show(@"Record saved successfully. Want to add more?", @"Question - Saatphere", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            txtCustomerName.Text = string.Empty;
            txtCustomerPhone.Text = string.Empty;
            txtRemarks.Text = string.Empty;

            txtCustomerName.Focus();
        }

        private void txtCustomerPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
