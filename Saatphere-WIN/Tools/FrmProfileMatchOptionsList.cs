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
    public partial class FrmProfileMatchOptionsList : Form
    {
        string valuetoBind = string.Empty;
        string xmlFolder = "TemporaryXML\\";

        public string ReturnValue1 { get; set; }
        public string ReturnValue2 { get; set; }

        public FrmProfileMatchOptionsList(string ValuetoBind = "")
        {
            InitializeComponent();

            DataSet dst = new DataSet();
            dst.ReadXml(xmlFolder + ValuetoBind);
            lstValues.DataSource = dst.Tables[0];
            lstValues.DisplayMember = "value";
            lstValues.ValueMember = "value";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProfileMatchOptionsList_Load(object sender, EventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string selectedItems = string.Empty;

            foreach (var item in lstValues.SelectedItems)
            {
                selectedItems += (((DataRowView)item).Row).ItemArray[0] + ",";
            }

            if (selectedItems.Length > 0)
            {
                selectedItems = selectedItems.Substring(0, selectedItems.Length - 1);

                //Check for the Dosen't matter.
                //Dosen't matter or blank measn filter not to be considered.
                //Here we will check if the filter contains only contains Dosen't Matter then it is okay, else
                //there will be other comman separated filters may involved, in that case we will remove the Dosen't matter
                if (selectedItems != "Dosen't Matter" || selectedItems != "Doesn't matter")
                {
                    selectedItems = selectedItems.Replace("Dosen't Matter", "").Replace("Doesn't matter", "");
                }

                //Check if the string is starting with comman,
                if (selectedItems.Length > 0)
                {
                    if (selectedItems.Substring(0, 1) == ",")
                    {
                        selectedItems = selectedItems.Substring(1, selectedItems.Length);
                    }
                }

            }

            this.ReturnValue1 = selectedItems;// lstValues.Text;
            this.ReturnValue2 = DateTime.Now.ToString(); //example
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lstValues.ClearSelected();
        }
    }
}
