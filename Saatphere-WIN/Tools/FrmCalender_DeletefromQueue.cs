using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Saatphere_WIN.Tools
{
    public partial class FrmCalender_DeletefromQueue : Form
    {
        public FrmCalender_DeletefromQueue()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtCandidateId.Text.Length > 0)
            {
                MessageBox.Show("Profile deletion from queue has completed successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Candidate ID is invalid.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
