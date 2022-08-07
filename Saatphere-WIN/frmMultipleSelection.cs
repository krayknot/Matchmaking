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
    public partial class frmMultipleSelection : Form
    {
        DataSet dstItems = new DataSet();
        public string ReturnValues { get; set; }

        public frmMultipleSelection(DataSet ListItems)
        {
            InitializeComponent();
            dstItems = ListItems;
        }

        private void frmMultipleSelection_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Arrow;
            
            listBox1.DataSource = dstItems.Tables[0];
            listBox1.DisplayMember = "value";
            listBox1.ValueMember = "value";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= listBox1.SelectedItems.Count - 1; i++)
            {
                ReturnValues = ReturnValues + listBox1.GetItemText (listBox1.SelectedItems[i]) + ",";
            }

            if (ReturnValues !=null)
            {
                ReturnValues = ReturnValues.Substring(0, ReturnValues.Length - 1);
            }

            this.Close();
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This will deselect all the items and that would be assume as Select All.\nPlease note that the blank filters will not get included in the search.", "Information: Select All", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.ClearSelected();
        }        
    }
}
