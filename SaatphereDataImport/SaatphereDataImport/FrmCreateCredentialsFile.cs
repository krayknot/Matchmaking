using System;
using System.Data;
using System.Windows.Forms;

namespace SaatphereDataImport
{
    public partial class FrmCreateCredentialsFile : Form
    {
        public FrmCreateCredentialsFile()
        {
            InitializeComponent();
        }

        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            //Get the path
            var sfd = new SaveFileDialog();
            sfd.ShowDialog();

            //Create the dataset for xml
            var dst = new DataSet();
            dst.Tables.Add("Credentials");
            dst.Tables["Credentials"].Columns.Add("Server");
            dst.Tables["Credentials"].Columns.Add("Username");
            dst.Tables["Credentials"].Columns.Add("Password");
            dst.Tables["Credentials"].Columns.Add("Database");

            dst.Tables["Credentials"].Rows.Add(EnCryptDecrypt.CryptorEngine.Encrypt(txtSourceServer.Text, true,""), 
                EnCryptDecrypt.CryptorEngine.Encrypt(txtSourceUsername.Text, true,""), 
                EnCryptDecrypt.CryptorEngine.Encrypt(txtSourcePassword.Text, true,""),
                EnCryptDecrypt.CryptorEngine.Encrypt(txtDatabase.Text, true, ""));
            dst.WriteXml(sfd.FileName);

            MessageBox.Show(@"File Saved");
            //Save the file at the selected path

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(-1);
        }
    }
}
