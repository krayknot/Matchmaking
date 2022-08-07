using System;
using System.Windows.Forms;

namespace Reminders
{
    public partial class FrmLeftProfiles : Form
    {
        public FrmLeftProfiles()
        {
            InitializeComponent();
        }

        private void frmLeftProfiles_Load(object sender, EventArgs e)
        {
            try
            {
                var common = new ClsCommon();

                if (tabControl1.SelectedTab == tabPage1)
                {
                    lblCount.Text = @"Total Records: " + dgrdTodaysPendingProfiles.Rows.Count;
                }
                else
                {
                    lblCount.Text = @"Total Records: " + dgrdPendingProfiles.Rows.Count;
                }
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

        private void dgrdTodaysPendingProfiles_MouseClick(object sender, MouseEventArgs e)
        {
            var selectedRowCount = dgrdTodaysPendingProfiles.Rows.GetRowCount(DataGridViewElementStates.Selected);

            for (var i = 0; i < selectedRowCount; i++)
            {
                ClsCommon.UserId = dgrdTodaysPendingProfiles.SelectedRows[i].Cells[0].Value.ToString();
            }

            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void dgrdPendingProfiles_MouseClick(object sender, MouseEventArgs e)
        {
            var selectedRowCount = dgrdPendingProfiles.Rows.GetRowCount(DataGridViewElementStates.Selected);

            for (var i = 0; i < selectedRowCount; i++)
            {
                ClsCommon.UserId = dgrdPendingProfiles.SelectedRows[i].Cells[0].Value.ToString();
                ClsCommon.PendingDate = dgrdPendingProfiles.SelectedRows[i].Cells[6].Value.ToString();
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

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1 )
            {
                lblCount.Text = @"Total Records: " + dgrdTodaysPendingProfiles.Rows.Count; 
            }
            else
            {
                lblCount.Text = @"Total Records: " + dgrdPendingProfiles.Rows.Count ; 
            }
        }

        private void profileHasSentRemoveTheUserFromListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon common = new ClsCommon();
            lblCount.Text = @"Total Records: " + dgrdPendingProfiles.Rows.Count;
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            profileHasSentRemoveTheUserFromListToolStripMenuItem.Enabled =
                (tabControl1.SelectedIndex == 1);
        }
    }
}