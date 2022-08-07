using System;
using System.Windows.Forms;

namespace Saatphere_WIN.Tools
{
    public partial class FrmCalendarActivities : Form
    {
        DateTime dtQueueDate = new DateTime();
        int _row = 0;
        int _col = 0;

        public FrmCalendarActivities(DateTime dateofQueue)
        {
            InitializeComponent();
            dtQueueDate = dateofQueue;

            this.Text = dateofQueue.ToString("dd MMMM yyyy");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCalendarActivities_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            dgrdCalendarActivities.Columns[0].Visible = false;
            Cursor.Current = Cursors.Arrow;

            lblTotal.Text = (dgrdCalendarActivities.Rows.Count).ToString();

        }

        private void dgrdCalendarActivities_Click(object sender, EventArgs e)
        {
            
        }

        private void dgrdCalendarActivities_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _row = e.RowIndex;
            _col = 0;
        }

        private void dgrdCalendarActivities_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var profileId = Convert.ToInt32(dgrdCalendarActivities.Rows[_row].Cells[0].Value);
            var biodataId = Convert.ToInt32(dgrdCalendarActivities.Rows[_row].Cells[1].Value);

            new FrmCalendarEditRecord(profileId, dtQueueDate, biodataId).ShowDialog();
        }

        private void frmCalendarActivities_Activated(object sender, EventArgs e)
        {
            frmCalendarActivities_Load(sender, e);
        }
    }
}
