using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;

namespace Saatphere_WIN.Customer
{
    public partial class FrmAssignCustomer : Form
    {
        public FrmAssignCustomer()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAssignCustomer_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            BindExecutives();
            BindMotherTongue();
            BindFranchisee();
            Cursor.Current = Cursors.Arrow;
        }



        private void BindExecutives()
        {
          
        }

        private void BindFranchisee()
        {
            var mbindResults = new BindingSource();

            cmbFranchisee.DataSource = mbindResults;
            cmbFranchisee.DisplayMember = "Value";
            cmbFranchisee.ValueMember = "key";

            cmbFranchisee.SelectedValue = SaatphereWIN.DAL.Global.LoginUser;
        }

        private void BindMotherTongue()
        {
            var db = new SaatphereWIN.DAL.Masters.ClsSelect();

            cmbLanguage.DataSource = db.GetList("MotherTongue").Tables[0];
            cmbLanguage.DisplayMember = "value";
            cmbLanguage.ValueMember = "value";
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            var franchiseeId = Convert.ToInt32(SaatphereWIN.DAL.Global.FrRowId);
            var language = cmbLanguage.Text;
            
            Cursor.Current = Cursors.Arrow;
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"You have selected multiple Executive(s) to assign Customers. Should system Auto-Assign the customers?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                #region If Auto-Assign

                //get the customer ids in hash table
                var customers = new Hashtable();
                var count = 0;
                var lastKey = 0;

                foreach (DataGridViewRow row in dgrdResults.SelectedRows)
                {
                    customers[count++] = row.Cells[0].Value.ToString();
                }
                lastKey = count -1;

        
                //var executiveId ;
                count = 0;
                var resetFlag = false;

                Cursor.Current = Cursors.WaitCursor;
                for (var i = 0; i <= lstExecutives.SelectedItems.Count - 1; i++)
                {
                    if (resetFlag)
                    {
                        i--; // after reset i =0, when it comes to start it does i++ again and thus we need i--
                        resetFlag = false;
                    }
                    //var executive = ((DataRowView)lstExecutives.SelectedItems[i]).Row.ItemArray[1].ToString();
                    var executiveId = Convert.ToInt32(((DataRowView)(lstExecutives.SelectedItems[i])).Row.ItemArray[0]);

                    if (count <= lastKey)
                    {
                        //MessageBox.Show(executiveId.ToString() + " " + executive);
                    }
                    else
                    {
                        break;
                    }

                    count++;
                    if (i == lstExecutives.SelectedItems.Count - 1)
                    {
                        if (count <= customers.Count - 1)
                        {
                            //Here it does i = 0, that will start the loop again but also it will do i++
                            //so we will use resetflag = true that will do the i = 0 again and initilaize the loop
                            i = 0;
                            resetFlag = true;
                        }
                    }
                }
                Cursor.Current = Cursors.Arrow;

                #endregion
            }
            else
            {
                #region If not Auto-Assign
                var executive = lstExecutives.Text;
                var selectedRowsCount = dgrdResults.SelectedRows.Count;
                //int columnId = 0;
                int executiveId = Convert.ToInt32(lstExecutives.SelectedValue);

                if (MessageBox.Show(@"You are assigning " + selectedRowsCount + @" customer(s) to " + executive + @". Are you sure?", @"Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    foreach (DataGridViewRow row in dgrdResults.SelectedRows)
                    {
                        //MessageBox.Show(row.Cells[0].Value.ToString() + " " + executiveId.ToString());
                    }
                    Cursor.Current = Cursors.Arrow;

                    if (MessageBox.Show(@"Do you want to print the Assignment Details?", @"Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var dstAssignment = new DataSet();
                        dstAssignment.Tables.Add("assign");
                        dstAssignment.Tables[0].Columns.Add("Column1");
                        dstAssignment.Tables[0].Columns.Add("Column2");
                        

                        dstAssignment.Tables[0].Rows.Add("Assigned Date: ", DateTime.Now.ToString());
                        dstAssignment.Tables[0].Rows.Add("");

                        dstAssignment.Tables[0].Rows.Add("Customer Assignment Details");
                        dstAssignment.Tables[0].Rows.Add("Executive: ", executive);
                        dstAssignment.Tables[0].Rows.Add("");
                        dstAssignment.Tables[0].Rows.Add("Customer Details");


                        foreach (DataGridViewRow row in dgrdResults.SelectedRows)
                        {
                            dstAssignment.Tables[0].Rows.Add(row.Cells[2].Value.ToString(), row.Cells[1].Value.ToString());
                        }

                        new FrmPrintAssignedCustomersForm(dstAssignment).ShowDialog();
                    }

                }
                
                #endregion
            }
            btnFetch_Click(sender, e);
        }

        private void frmAssignCustomer_Activated(object sender, EventArgs e)
        {
            
        }
    }
}
