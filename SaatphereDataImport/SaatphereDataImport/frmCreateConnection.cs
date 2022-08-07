using System;
using System.Data;
using System.Windows.Forms;

namespace SaatphereDataImport
{
    public partial class FrmCreateConnection : Form
    {
        public FrmCreateConnection()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var dst = new DataSet();
            dst.Tables.Add("xml");
            dst.Tables["xml"].Columns.Add("Server");
            dst.Tables["xml"].Columns.Add("Username");
            dst.Tables["xml"].Columns.Add("Password");
            dst.Tables["xml"].Columns.Add("Database");

            var username = txtDestUsername.Text;
            var password = txtDestPassword.Text;
            var server = txtDestServer.Text;
            var database = txtDestDatabase.Text;

            dst.Tables["xml"].Rows.Add(server, username, password,database);

            var sf = new SaveFileDialog();
            sf.ShowDialog();
            var filePath = sf.FileName;
            dst.WriteXml(filePath);
        }
    }
}
