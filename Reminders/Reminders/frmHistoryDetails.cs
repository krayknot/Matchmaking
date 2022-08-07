using System;
using System.Windows.Forms;

namespace Reminders
{
    public partial class FrmHistoryDetails : Form
    {
        public FrmHistoryDetails()
        {
            InitializeComponent();
        }

        private void frmHistoryDetails_Load(object sender, EventArgs e)
        {
            try
            {
                var common = new ClsCommon();
                lblCount.Text = @"Total Records: " + dgrdHistoryDetails.Rows.Count;
            }
            catch (Exception)
            {                
                throw;
            }

 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}