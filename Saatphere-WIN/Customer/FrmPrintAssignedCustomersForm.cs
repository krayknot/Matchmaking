using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Saatphere_WIN.Customer
{
    public partial class FrmPrintAssignedCustomersForm : Form
    {
        //private DataSet _dstAssignment = new DataSet();
        private Bitmap _bitmap;
        PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
        

        public FrmPrintAssignedCustomersForm(DataSet assignmentDataset)
        {
            InitializeComponent();
            dgrdAsigned.DataSource = assignmentDataset.Tables[0];
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmPrintAssignedCustomersForm_Load(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //Resize DataGridView to full height.
            var height = dgrdAsigned.Height;
            dgrdAsigned.Height = dgrdAsigned.RowCount * dgrdAsigned.RowTemplate.Height;

            //Create a Bitmap and draw the DataGridView on it.
            _bitmap = new Bitmap(dgrdAsigned.Width, dgrdAsigned.Height);
            dgrdAsigned.DrawToBitmap(_bitmap, new Rectangle(0, 0, dgrdAsigned.Width, dgrdAsigned.Height));

            //Resize DataGridView back to original height.
            dgrdAsigned.Height = height;

            //Show the Print Preview Dialog.
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(_bitmap, 0, 0);
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            // creating Excel Application
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();

            // creating new WorkBook within Excel application
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);

            // creating new Excelsheet in workbook
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            // see the excel sheet behind the program
            app.Visible = true;

            // get the reference of first sheet. By default its name is Sheet1.
            // store its reference to worksheet
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

            // changing the name of active sheet
            worksheet.Name = "Customer Assignment - Saatphere";

            // storing header part in Excel
            for (var i = 1; i < dgrdAsigned.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dgrdAsigned.Columns[i - 1].HeaderText;
            }

            // storing Each row and column value to excel sheet
            for (var i = 0; i < dgrdAsigned.Rows.Count; i++)
            {
                for (var j = 0; j < dgrdAsigned.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dgrdAsigned.Rows[i].Cells[j].Value.ToString();
                }
            }

            var destination = Path.GetTempPath() + Guid.NewGuid() + ".xls";            

            workbook.SaveAs(destination, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        
            // Exit from the application
            app.Quit();

            Process.Start(destination);
        }
    }
}
