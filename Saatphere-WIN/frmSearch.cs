using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Saatphere_WIN
{
    public partial class frmSearch : Form
    {
        int selectedBiodataId = 0;
        DataSet dstSearchResults = new DataSet();

        public frmSearch()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            string searchString = string.Empty;

            if (rdbCity.Checked)
            {
                searchString = drpCity.SelectedText;
            }
            else if (rdbId.Checked)
            {
                searchString = txtID.Text;
            }
            else if (rdbName.Checked)
            {
                searchString = txtName.Text;
            }
            else if (rdbMobile.Checked)
            {
                searchString = txtMobile.Text;
            }
            else if (rdbEmail.Checked)
            {
                searchString = txtEmail.Text;
            }
            else if (rdbAssignedCustomers.Checked)
            {
                searchString = cmbExecutives.SelectedValue.ToString() ;
            }
            else if (rdbAssignedExecutives.Checked)
            {
                searchString = cmbCustomers.SelectedValue.ToString();
            }

            dgrdResults.DataSource = dstSearchResults.Tables[0];
            lblTotal.Text = "Total Records: " + (dgrdResults.Rows.Count).ToString();

            dgrdResults.ClearSelection();
            Cursor.Current = Cursors.Default;
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void txtMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            FillCity();
            BindExecutives();
            BindCustomers();
        }

        private void BindCustomers()
        {
            cmbCustomers.DisplayMember = "CustomerDetails_Name";
            cmbCustomers.ValueMember = "CustomerDetails_Name";
        }

        private void BindExecutives()
        {
            cmbExecutives.DisplayMember = "DSR_ExecutiveName";
            cmbExecutives.ValueMember = "DSR_ID";
        }

        private void FillCity()
        {
            SaatphereWIN.DAL.Masters.ClsSelect select = new SaatphereWIN.DAL.Masters.ClsSelect();
            drpCity.DisplayMember = "value";
            drpCity.ValueMember = "value";
        }

        private void dgrdResults_MouseClick(object sender, MouseEventArgs e)
        {
            if (rdbCity.Checked || rdbId.Checked || rdbName.Checked || rdbMobile.Checked || rdbEmail.Checked)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    //Select the row first
                    //var hti = dgrdResults.HitTest(Cursor.Position.X, Cursor.Position.Y);
                    //dgrdResults.ClearSelection();
                    //dgrdResults.Rows[hti.RowIndex].Selected = true;

                    contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void dgrdResults_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    dgrdResults.CurrentCell = dgrdResults.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    // Can leave these here - doesn't hurt
                    dgrdResults.Rows[e.RowIndex].Selected = true;
                    dgrdResults.Focus();

                    selectedBiodataId = Convert.ToInt32(dgrdResults.Rows[e.RowIndex].Cells[1].Value);

                    lblSelectedRecord.Text = selectedBiodataId.ToString();
                }
                catch (Exception)
                {

                }
            }
        }

        private void viewBiodataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmCustomerMaster(selectedBiodataId).ShowDialog();
        }

        private void viewBiodataDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmCustomerDetails(selectedBiodataId).ShowDialog();
        }

        private void dgrdResults_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (rdbCity.Checked || rdbId.Checked || rdbName.Checked || rdbMobile.Checked || rdbEmail.Checked)
            {
                selectedBiodataId = Convert.ToInt32(dgrdResults.Rows[e.RowIndex].Cells[1].Value);
            }
        }

        private void txtID_MouseClick(object sender, MouseEventArgs e)
        {
            rdbId.Checked = true;
            rdbName.Checked = false;
            rdbMobile.Checked = false;
            rdbEmail.Checked = false;

            rdbAssignedCustomers.Checked = false;
            rdbAssignedExecutives.Checked = false;
        }

        private void txtName_MouseClick(object sender, MouseEventArgs e)
        {
            rdbId.Checked = false;
            rdbName.Checked = true;
            rdbMobile.Checked = false;
            rdbEmail.Checked = false;

            rdbAssignedCustomers.Checked = false;
            rdbAssignedExecutives.Checked = false;
        }

        private void txtMobile_MouseClick(object sender, MouseEventArgs e)
        {
            rdbId.Checked = false;
            rdbName.Checked = false;
            rdbMobile.Checked = true;
            rdbEmail.Checked = false;

            rdbAssignedCustomers.Checked = false;
            rdbAssignedExecutives.Checked = false;
        }

        private void txtEmail_MouseClick(object sender, MouseEventArgs e)
        {
            rdbId.Checked = false;
            rdbName.Checked = false;
            rdbMobile.Checked = false;
            rdbEmail.Checked = true;

            rdbAssignedCustomers.Checked = false;
            rdbAssignedExecutives.Checked = false;
        }

        private void cmbCustomers_MouseClick(object sender, MouseEventArgs e)
        {
            rdbId.Checked = false;
            rdbName.Checked = false;
            rdbMobile.Checked = false;
            rdbEmail.Checked = false;
            rdbAssignedCustomers.Checked = false;
            rdbAssignedExecutives.Checked = true;
        }

        private void rdbAssignedCustomers_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void cmbExecutives_MouseClick(object sender, MouseEventArgs e)
        {
            rdbId.Checked = false;
            rdbName.Checked = false;
            rdbMobile.Checked = false;
            rdbEmail.Checked = false;
            rdbAssignedCustomers.Checked = true;
            rdbAssignedExecutives.Checked = false;

        }

        private void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string backupPath = folderBrowserDialog1.SelectedPath;
                    string fileName = "SaatphereExportData_" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;

                    BackupExcelSeparateSheet(dstSearchResults, backupPath, fileName);
                    MessageBox.Show("Data has exported successfully.\nFilename: " + backupPath + fileName, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                       
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

        private void biodataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Tools.FrmProfileDetails(null, Convert.ToInt32(selectedBiodataId), null).ShowDialog();
        }
    }
}
