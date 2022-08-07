using System;
using System.Windows.Forms;
using System.Globalization;

namespace Saatphere_WIN.Tools
{
    public partial class FrmCalendarReports : Form
    {
        public FrmCalendarReports()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            var status = cmbReport.SelectedText;
        }

        private void btnSearchCandidateID_Click(object sender, EventArgs e)
        {
            var candidateID = txtCandidateID.Text;
        }

        private void btnSearchCandidateName_Click(object sender, EventArgs e)
        {
            string candidateName = txtCandidateName.Text;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var format = "d";
            var provider = CultureInfo.InvariantCulture;

            DateTime fromDate = DateTime.ParseExact(dateFrom.Value.ToString(), format, provider);
            DateTime toDate = DateTime.ParseExact(dateTo.Value.ToString(), format, provider);
            string status = cmbReport.SelectedText;

 
        }



    }
}
