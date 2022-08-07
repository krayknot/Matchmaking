using System;
using System.Windows.Forms;

namespace Saatphere_WIN.Financial
{
    public partial class FrmDsrExecutiveEditDelete : Form
    {
        int row = 0;
        int col = 0;
        
        public FrmDsrExecutiveEditDelete()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDSRExecutiveEditDelete_Load(object sender, EventArgs e)
        {
            BindDSRExecutives();
        }

        private void BindDSRExecutives()
        {
        }

        private void dgrdDSRExecutives_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            col = e.ColumnIndex;
        }

        private void dgrdDSRExecutives_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var executiveId = Convert.ToInt32(dgrdDSRExecutives.Rows[row].Cells[0].Value);
            new FrmDsrExecutiveAdd(executiveId).ShowDialog();

            BindDSRExecutives();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
        }
    }
}
