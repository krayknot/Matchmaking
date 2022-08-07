using System;
using System.Windows.Forms;

namespace Saatphere_WIN.Tools
{
    public partial class FrmCalendarEditRecord : Form
    {
        int _profileId;
        int _biodataID = 0;
        DateTime dtQueueDate = new DateTime();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProfileID">Profile CID in te database to identify the record</param>
        /// <param name="TargetDate"></param>
        /// <param name="BiodataID">Biodata id</param>
        public FrmCalendarEditRecord(int profileId, DateTime targetDate, int biodataId)
        {
            InitializeComponent();
            _profileId = profileId;
            txtProfileID.Text = biodataId.ToString();
            dtQueueDate = targetDate;
            _biodataID = biodataId;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int profileID = _profileId;
            string status = cmbSendDateStatus.Text;

            Cursor.Current = Cursors.WaitCursor;
            Cursor.Current = Cursors.Arrow;

            MessageBox.Show(@"Record has updated successfully.", @"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnTransferToTomorrow_Click(object sender, EventArgs e)
        {
            if (txtProfileID.Text.Length > 0)
            {
                MessageBox.Show(@"Transfer has done successfully.", @"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(@"Customer ID is Empty.", @"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmCalendarEditRecord_Load(object sender, EventArgs e)
        {

        }
    }
}
