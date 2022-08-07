using System;
using System.Windows.Forms;

namespace Reminders
{
    public partial class FrmHistory : Form
    {
        public FrmHistory()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHistory_Load(object sender, EventArgs e)
        {
            try
            {
                var common = new ClsCommon();
                lblCount.Text = @"Total Records: " + dgrdHistory.Rows.Count; 
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        private void dgrdHistory_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var selectedRowCount = dgrdHistory.Rows.GetRowCount(DataGridViewElementStates.Selected);

                for (var i = 0; i < selectedRowCount; i++)
                {
                    ClsCommon.DateofView = dgrdHistory.SelectedRows[i].Cells[0].Value.ToString();
                }

                var historyDetails = new FrmHistoryDetails();
                historyDetails.ShowDialog(); 
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
    }
}