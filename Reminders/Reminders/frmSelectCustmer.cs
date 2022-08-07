using System;
using System.Windows.Forms;

namespace Reminders
{
    public partial class frmSelectCustomer : Form
    {
        public frmSelectCustomer()
        {
            InitializeComponent();
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            BindData("A");
        }

        private void BindData(string startLetter)
        {
            var common = new ClsCommon();
            lblCount.Visible = true ;
            lblCount.Text = @"Total Records: " + dgrdReminders.Rows.Count;
        }

        private void frmSelectCustomer_Load(object sender, EventArgs e)
        {

        }

        private void btnB_Click(object sender, EventArgs e)
        {
            BindData("B");
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            BindData("C");
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            BindData("D");
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            BindData("E");
        }

        private void btnF_Click(object sender, EventArgs e)
        {
            BindData("F");
        }

        private void btnG_Click(object sender, EventArgs e)
        {
            BindData("G");
        }

        private void btnH_Click(object sender, EventArgs e)
        {
            BindData("H");
        }

        private void btnI_Click(object sender, EventArgs e)
        {
            BindData("I");
        }

        private void btnJ_Click(object sender, EventArgs e)
        {
            BindData("J");
        }

        private void btnK_Click(object sender, EventArgs e)
        {
            BindData("K");
        }

        private void btnL_Click(object sender, EventArgs e)
        {
            BindData("L");
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            BindData("M");
        }

        private void btnN_Click(object sender, EventArgs e)
        {
            BindData("N");
        }

        private void btnO_Click(object sender, EventArgs e)
        {
            BindData("O");
        }

        private void btnP_Click(object sender, EventArgs e)
        {
            BindData("P");
        }

        private void btnQ_Click(object sender, EventArgs e)
        {
            BindData("Q");
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            BindData("R");
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            BindData("S");
        }

        private void btnT_Click(object sender, EventArgs e)
        {
            BindData("T");
        }

        private void btnU_Click(object sender, EventArgs e)
        {
            BindData("U");
        }

        private void btnV_Click(object sender, EventArgs e)
        {
            BindData("V");
        }

        private void btnW_Click(object sender, EventArgs e)
        {
            BindData("W");
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            BindData("X");
        }

        private void btnY_Click(object sender, EventArgs e)
        {
            BindData("Y");
        }

        private void btnZ_Click(object sender, EventArgs e)
        {
            BindData("Z");
        }

        private void dgrdReminders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //clsCommon.userID = dgrdReminders.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString ();  
        }

        private void dgrdReminders_Click(object sender, EventArgs e)
        {
            
        }

        private void dgrdReminders_MouseClick(object sender, MouseEventArgs e)
        {
            var selectedRowCount = dgrdReminders.Rows.GetRowCount(DataGridViewElementStates.Selected);

            for (int i = 0; i < selectedRowCount ; i++)
            {
                ClsCommon.UserId = dgrdReminders.SelectedRows[i].Cells[0].Value.ToString();
            }

            if (e.Button == MouseButtons.Right)
            {               
                contextMenuStrip1.Show(System.Windows.Forms.Cursor.Position.X, System.Windows.Forms.Cursor.Position.Y);  
            }
        }


        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var history = new FrmHistory();
            history.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var common = new ClsCommon();
            if (txtCustomerId.Text.Length > 0)
            {
            }
            else if (txtCustomerName.Text.Length > 0)
            {
            }
        }

        private void dgrdReminders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close(); 
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCustomerName.Checked)
            {
                txtCustomerName.Enabled = true;
            }
            else
            {
                txtCustomerName.Enabled = false;
                txtCustomerName.Text = string.Empty;
            }
        }

        private void rdbCustomerID_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCustomerID.Checked)
            {
                txtCustomerId.Enabled = true;
            }
            else
            {
                txtCustomerId.Enabled = false;
                txtCustomerId.Text = string.Empty;
            }
        }

        private void btnLeftProfiles_Click(object sender, EventArgs e)
        {
            var leftProfiles = new FrmLeftProfiles();
            leftProfiles.ShowDialog();
        }

        private void txtCustomerId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

    }
}