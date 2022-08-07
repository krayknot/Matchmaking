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
    public partial class frmDuplicateIDList : Form
    {
        DataSet dstDuplicate = new DataSet();
        public frmDuplicateIDList(DataSet DuplicateList)
        {
            InitializeComponent();
            dstDuplicate = DuplicateList;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDuplicateIDList_Load(object sender, EventArgs e)
        {
            dgrdData.DataSource = dstDuplicate.Tables[0];
        }
    }
}
