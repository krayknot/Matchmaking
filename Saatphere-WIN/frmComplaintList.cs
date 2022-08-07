using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Saatphere_WIN
{
    public partial class frmComplaintList : Form
    {
        public frmComplaintList()
        {
            InitializeComponent();
        }

        private void frmComplaintList_Load(object sender, EventArgs e)
        {
            //Get the complaints list
        }

        private void dgrdComplaints_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = 0;

            int complaintID = Convert.ToInt32(dgrdComplaints.Rows[row].Cells[col].Value);

            new frmComplaintsAdd(complaintID).ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
        }
    }
}
