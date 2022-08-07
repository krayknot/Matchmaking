using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace Saatphere_WIN
{
    public partial class frmDataExportStep1 : Form
    {
        public frmDataExportStep1()
        {
            InitializeComponent();
        }

        private void frmDataExportStep1_Load(object sender, EventArgs e)
        {
            try
            {
                //Fetch the table list of the database
                lstTables.DataSource = new SaatphereWIN.DAL.ClsCommon().GetTables().Tables[0];
                lstTables.DisplayMember = "name";
                lstTables.ValueMember = "name";
            }
            catch (Exception)
            {
                
                throw;
            }


        

        }

        public void BackupExcelSeparateSheet(DataSet ExportDataset, string destination, string TableName)
        {
            Cursor.Current = Cursors.WaitCursor;

            bool dataError = false;

            DataSet dstTemp = new DataSet();

            try
            {
                dstTemp = ExportDataset;
            }
            catch (Exception)
            {
                dataError = true;
            }

            if (File.Exists(destination + "\\" + TableName + ".xls"))
                File.Delete(destination + "\\" + TableName + ".xls");

            //si Excel, 
            //créer un classeur avec un nom de table EmployeeData. La table a different champs
            //string tableName = string.Empty;
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + destination + "\\" + TableName + ".xls; Extended Properties='Excel 8.0;HDR=YES'"; ;
            conn.Open();

            if (dataError == false)
            {
                if (dstTemp.Tables.Count > 0)
                {
                    //extraire les colonnes de la table de données
                    string cols = string.Empty;
                    for (int i = 0; i <= dstTemp.Tables[0].Columns.Count - 1; i++)
                    {
                        cols = cols + "[" + dstTemp.Tables[0].Columns[i].ColumnName.ToString() + "] varchar(255), ";
                    }
                    cols = cols.Substring(0, cols.Length - 2);

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "CREATE TABLE [" + TableName + "] (" + cols + ")";
                    cmd.ExecuteNonQuery();

                    //extraire les colonnes de la table source
                    string colsDest = string.Empty;
                    string colsValues = string.Empty;
                    string fieldValue = string.Empty;

                    for (int i = 0; i <= dstTemp.Tables[0].Columns.Count - 1; i++)
                    {
                        colsDest = colsDest + "left([" + dstTemp.Tables[0].Columns[i].ColumnName.ToString() + "],255) , ";
                    }
                    colsDest = colsDest.Substring(0, colsDest.Length - 2);

                    //Insérez l'enregistrement de la table
                    for (int rowData = 0; rowData <= dstTemp.Tables[0].Rows.Count - 1; rowData++)
                    {
                        for (int colData = 0; colData <= dstTemp.Tables[0].Columns.Count - 1; colData++)
                        {
                            fieldValue = dstTemp.Tables[0].Rows[rowData][colData].ToString();
                            if (fieldValue.Contains(""))
                            {
                                fieldValue = string.Empty;
                            }

                            if (fieldValue.Length >= 250)
                            {
                                try
                                {
                                    colsValues = colsValues + "'" + fieldValue.Substring(1, 250).Replace("'", "''") + "',";
                                }
                                catch (Exception)
                                {

                                }
                            }
                            else
                            {
                                colsValues = colsValues + "'" + fieldValue.Replace("'", "''") + "',";
                            }

                        }
                        colsValues = colsValues.Substring(0, colsValues.Length - 1);

                        cmd.CommandText = "INSERT INTO [" + TableName + "] values (" + colsValues + ")";
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {

                        }

                        colsValues = string.Empty;
                    }
                }
            }
            else
            {

            }
            conn.Close();
            Cursor.Current = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Validation
            if (lstTables.SelectedItems.Count < 1)
            {
                MessageBox.Show("No Tablename selected.", "Error - Table Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                if (rdbSelectTable.Checked == true)
                {
                    new frmDataExportStep2(lstTables.Text, "TABLE").ShowDialog();
                }
                else if (rdbWriteQuery.Checked == true)
                {
                    new frmDataExportStep2(txtQuery.Text, "QUERY").ShowDialog();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdbSelectTable_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnBrowseQueryFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtQuery.Text = System.IO.File.ReadAllText(ofd.FileName);
            }
        }
    }
}
