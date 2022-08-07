using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;

namespace Saatphere_WIN
{
    public partial class frmDataExportStep2 : Form
    {        
        DataSet dst = new DataSet();

        string tableName = string.Empty;
        string type = string.Empty;
        string query = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="Type">TABLE or QUERY</param>
        public frmDataExportStep2(string TableName, string Type)
        {
            InitializeComponent();
            tableName = TableName;
            query = TableName;
            type = Type;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string backupPath = folderBrowserDialog1.SelectedPath;

                    BackupExcelSeparateSheet(dst, backupPath, fileName);
                    MessageBox.Show("Data has exported successfully.\nFilename: " + backupPath + fileName, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (type == "QUERY")
                    {
                        if (MessageBox.Show("Would you like to save the Query for further use?", "Save Query in text file?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            SaveFileDialog sfd = new SaveFileDialog();
                            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                System.IO.File.WriteAllText(sfd.FileName + ".txt", query);

                                MessageBox.Show("Query file has saved successfully.", "File saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
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

        //private void copyAlltoClipboard()
        //{
        //    dgrdData.SelectAll();
        //    DataObject dataObj = dgrdData.GetClipboardContent();
        //    if (dataObj != null)
        //        Clipboard.SetDataObject(dataObj);
        //}

        private void btnExtract_Click(object sender, EventArgs e)
        {
            bool flag = false;
            try
            {
                if (type == "TABLE")
                {
                    dst = new SaatphereWIN.DAL.ClsCommon().GetTableData(tableName);
                    flag = true;
                }
                else if (type == "QUERY")
                {
                    if (query.Length > 0)
                    {
                        dst = new SaatphereWIN.DAL.ClsCommon().GetTableDatafromQuery(query);
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                        MessageBox.Show("You have selected Export type: Write a Query, but has not provided any Query.", "Error - Saatphere", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (flag == true)
                {
                    dgrdData.DataSource = dst.Tables[0];
                    btnExport.Enabled = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void frmDataExportStep2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
