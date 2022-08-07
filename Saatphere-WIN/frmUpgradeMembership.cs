using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace Saatphere_WIN
{
    public partial class frmUpgradeMembership : Form
    {
        //This variable will set to true after successful operation. If there will be any eexeption, user can retry and only those operation wil be performed
        //which has the flag value false.
        //----------------------------------------------------------------------------------------------------------------------------------------------------
        bool flagBiodata = false;
        bool flagFrancisee = false;
        bool flagCustAcc = false;
        bool flagProfileSend = false;
        bool flagUpdateCalender = false;
        //----------------------------------------------------------------------------------------------------------------------------------------------------

        DataSet dstBiodata = new DataSet();

        public frmUpgradeMembership()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeControls()
        {
            groupBox1.Enabled = false;
            groupBox1.Refresh();
            btnUpgrade.Enabled = false;
            btnUpgrade.Refresh();
            btnRenew.Enabled = false;
            btnRenew.Refresh();
            btnExtend.Enabled = false;
            btnExtend.Refresh();
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            InitializeControls();            

            //Validation
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtCustomerID.Text.Trim(), "^[0-9]*$"))
            {
                MessageBox.Show("Only numeric Customer Ids are allowed.", "Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            if (txtCustomerID.Text.Length < 1)
            {
                MessageBox.Show("Customer ID is mandatory.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int customerID = Convert.ToInt32(txtCustomerID.Text.Trim());

                ChangeButtonState(btnStatus, false);

                //Check whether the user is a Paid Member or not

                bool Response = false;
                string CustomerName = string.Empty;


                if (Response == true)
                {
                    btnUpgrade.Enabled = false;
                    btnExtend.Enabled = true;
                    btnRenew.Enabled = true;
                }
                else
                {
                    btnExtend.Enabled = false;
                    btnRenew.Enabled = false;
                    btnUpgrade.Enabled = true;
                }
                lblCustomerName.Text = CustomerName;
                lblCustomerName.Visible = true;

                ChangeButtonState(btnStatus, true);
                
                groupBox1.Enabled = true;

                //Get the biodata details here only and use the details in other steps, this will decrease the processing time
                dstBiodata = new SaatphereWIN.DAL.User.ClsSelect().GetBiodataFromId(customerID);

                //Fill the grid
            }
            cmbMembershipType.Focus();
            Cursor.Current = Cursors.Arrow;
        }

        private void ChangeButtonState(Button ButtonInfo, bool Action)
        {
            ButtonInfo.Enabled = Action;
            ButtonInfo.Refresh();
        }


        private void txtCustomerID_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !char.IsNumber(e.KeyChar);            
        }

        private void cmbMembershipType_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbMembershipType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Create the Dataset for the MEmbership based on the membership.xml and search inside
            DataSet dstMembership = new DataSet();
            string response = string.Empty;
            try
            {
                dstMembership.ReadXml("TemporaryXML\\Memberships.xml");

                string expression = "MembershipType = '" + cmbMembershipType.Text + "'";
                DataRow[] foundRows; 
                foundRows = dstMembership.Tables[0].Select(expression);

            
                lblContacts.Text = foundRows[0]["Contact"].ToString();
                lblDuration.Text = foundRows[0]["Duration"].ToString();
                lblPrice.Text = foundRows[0]["Price"].ToString();
            }
            catch (Exception)
            {
               
            }
        }

        private void btnUpgrade_Click(object sender, EventArgs e)
        {
            //Collect the values
            //-------------------------------------------------------------------------
            string MemberShipType = cmbMembershipType.Text;
            string Status = cmbStatus.Text;

            try
            {
                //Collect the selected MEmbership Details
                //-------------------------------------------------------------------------
                DataSet dstMembership = new DataSet();
                dstMembership.ReadXml("TemporaryXML\\Memberships.xml");
                string expression = "MembershipType = '" + cmbMembershipType.Text + "'";
                DataRow[] foundRows;
                foundRows = dstMembership.Tables[0].Select(expression);
                //-------------------------------------------------------------------------          

                DateTime date1 = DateTime.Now;
                string date2 = DateTime.Now.ToString(SaatphereWIN.DAL.Constants.MembershipRenewalDateTimeFormat); 
                string date3 = "";

                //Update the details in Biodata Table
                //----------------------------------------------------------------------------------------------------------
                if (!flagBiodata)
                {
                    if (lblDuration.Text != string.Empty)
                        date3 = date1.AddMonths(Convert.ToInt32(cmbMembershipType.SelectedValue)).ToString(SaatphereWIN.DAL.Constants.MembershipRenewalDateTimeFormat);
                        //date3 = date1.AddMonths(Convert.ToInt32(cmbMembershipType.SelectedValue)).ToString(SaatphereWIN.DAL.Constants.MembershipRenewalDateTimeFormat);
                        //date3 = String.Format("{0:d}", date1.AddMonths(Convert.ToInt32(cmbMembershipType.SelectedValue)));

                    SaatphereWIN.DAL.DataTypes.Biodata biodataDetails = new SaatphereWIN.DAL.DataTypes.Biodata();
                    biodataDetails.Membershiptype = cmbMembershipType.Text;
                    biodataDetails.Validity = lblContacts.Text;
                    biodataDetails.ValidityLeft = lblContacts.Text;
                    biodataDetails.Status = cmbStatus.Text;
                    biodataDetails.StartDate = date2;
                    biodataDetails.LastDate = date3;
                    biodataDetails.FranchiseeUserName = SaatphereWIN.DAL.Global.Frusername;
                    biodataDetails.RowIdBiodata = Convert.ToInt32(txtCustomerID.Text);
                    biodataDetails.Remark = txtRemark.Text;

                    flagBiodata = true;
                }
                //----------------------------------------------------------------------------------------------------------
                //Franchise Account entry
                //----------------------------------------------------------------------------------------------------------
                if (!flagFrancisee)
                {
                    SaatphereWIN.DAL.DataTypes.Franchisee franchiseeDetails = new SaatphereWIN.DAL.DataTypes.Franchisee();
                    float amt = 0;

                    if (lblPrice.Text != string.Empty)
                    {
                        amt = Convert.ToSingle(lblPrice.Text);
                        amt = amt / 2;
                    }
                    float amts;
                    amts = (float)Math.Round(amt, 2);

                    franchiseeDetails.Activity = cmbMembershipType.Text;
                    franchiseeDetails.AmountDed = amts;
                    franchiseeDetails.AmountRec = 0;
                    franchiseeDetails.CustomerId = txtCustomerID.Text;
                    franchiseeDetails.FranId = SaatphereWIN.DAL.Global.FrRowId;
                    new SaatphereWIN.DAL.Franchisee.ClsInsert().InsertFranAccount(franchiseeDetails);
                    flagFrancisee = true;
                }
                //----------------------------------------------------------------------------------------------------------

                //CustAcc Table Entry
                //----------------------------------------------------------------------------------------------------------
                if (!flagCustAcc)
                {
                    SaatphereWIN.DAL.DataTypes.CustAcc custAccDetails = new SaatphereWIN.DAL.DataTypes.CustAcc();
                    custAccDetails.OnDate = date2;
                    custAccDetails.CustomerId = txtCustomerID.Text;
                    custAccDetails.ViewId = string.Empty;
                    custAccDetails.Membership = cmbMembershipType.Text;
                    custAccDetails.FranId = SaatphereWIN.DAL.Global.FrRowId;
                    new SaatphereWIN.DAL.User.ClsInsert().InsertCustAcc(custAccDetails);
                    flagCustAcc = true;
                }
                //----------------------------------------------------------------------------------------------------------

                //As per discuss with alok sir, while activating id, id shld be activate in calendar also
                //----------------------------------------------------------------------------------------------------------
                if (!flagProfileSend)
                {
                    CultureInfo myCI = new CultureInfo("en-US", false);
                    DateTime startDate = Convert.ToDateTime(strdt, myCI);
                    DateTime endDate = DateTime.Now.AddMonths(Convert.ToInt32(cmbMembershipType.SelectedValue));
                    DateTime calculatedDate = startDate;

                    //string strdt = new SaatphereWIN.DAL.Membership.clsSelect().GetProfileMembershipActivationDate(Convert.ToInt32(txtCustomerID.Text)).ToString();
                    //DateTime startDate = Convert.ToDateTime(strdt);
                    //DateTime endDate = DateTime.Now.AddMonths(Convert.ToInt32(cmbMembershipType.SelectedValue));
                    //DateTime calculatedDate = startDate;

                    string format = "d";
                    DateTime dateString;
                    CultureInfo provider = CultureInfo.InvariantCulture;

                    string serviceModes = string.Empty;

                    for (int i = 0; i <= lstServiceMode.SelectedItems.Count - 1; i++)
                    {
                        serviceModes = serviceModes + ", " + lstServiceMode.Items[i].ToString();
                    }

                    while (startDate <= endDate)
                    {
                        dateString = calculatedDate;

                        calculatedDate = calculatedDate.AddDays(10);
                        startDate = startDate.AddDays(10);
                    }
                    flagProfileSend = true;
                }
                //Update the End Date column for the profileid
                //---------------------------------------------------------------------------------------------------------
                if (!flagUpdateCalender)
                {
                    flagUpdateCalender = true;
                }
                //----------------------------------------------------------------------------------------------------------

                MessageBox.Show("Profile Activation has completed Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message +  "\nThere is some error. You should retry.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw;
            }            
        }

        private void frmUpgradeMembership_Load(object sender, EventArgs e)
        {
            //Create the Membership Combobox
            DataSet dst = new DataSet();
            dst.Tables.Add("Membership");
            dst.Tables["Membership"].Columns.Add("MonthID");
            dst.Tables["Membership"].Columns.Add("MonthString");

            dst.Tables["Membership"].Rows.Add("1","One Month");
            dst.Tables["Membership"].Rows.Add("2", "Two Months");
            dst.Tables["Membership"].Rows.Add("3", "Three Months");
            dst.Tables["Membership"].Rows.Add("4", "Four Months");
            dst.Tables["Membership"].Rows.Add("5", "Five Months");
            dst.Tables["Membership"].Rows.Add("6", "Six Months");
            dst.Tables["Membership"].Rows.Add("7", "Seven Months");
            dst.Tables["Membership"].Rows.Add("8", "Eight Months");
            dst.Tables["Membership"].Rows.Add("9", "Nine Months");
            dst.Tables["Membership"].Rows.Add("10", "Ten Months");
            dst.Tables["Membership"].Rows.Add("11", "Eleven Months");
            dst.Tables["Membership"].Rows.Add("12", "One Year");
            dst.Tables["Membership"].Rows.Add("13", "Thirteen Months");
            dst.Tables["Membership"].Rows.Add("14", "Fourteen Months");
            dst.Tables["Membership"].Rows.Add("", "Registered");
            dst.Tables["Membership"].Rows.Add("", "No Change");

            cmbMembershipType.DataSource = dst.Tables[0];
            cmbMembershipType.DisplayMember = "MonthString";
            cmbMembershipType.ValueMember = "MonthID";
        }

        private void btnExtend_Click(object sender, EventArgs e)
        {
            //Valiations
            if (txtRemark.Text.Length < 1)
            {
                MessageBox.Show("Remark is mandatory.", "Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            try
            {
                ChangeButtonState(btnExtend, false);

                string lastdate = dstBiodata.Tables[0].Rows[0]["LastDate"].ToString();

                DateTime ldate;
                try
                {
                    ldate = DateTime.Parse(lastdate);
                }
                catch (Exception)
                {
                    ldate = DateTime.ParseExact(lastdate, "M/d/yyyy", null);
                }
                string date3 = "";

                //Adding days due to change in the Extend functionality
                date3 = String.Format("{0:d}", ldate.AddDays(Convert.ToInt32(txtExtendDays.Text)));

                //Entry in Membership history
                SaatphereWIN.DAL.DataTypes.Biodata biodataDetails = new SaatphereWIN.DAL.DataTypes.Biodata();
                biodataDetails.Membershiptype = cmbMembershipType.Text;
                biodataDetails.Validity = lblContacts.Text;
                biodataDetails.ValidityLeft = lblContacts.Text;
                biodataDetails.Status = cmbStatus.Text;
                biodataDetails.LastDate = date3;
                biodataDetails.FranchiseeUserName = SaatphereWIN.DAL.Global.Frusername;
                biodataDetails.RowIdBiodata = Convert.ToInt32(txtCustomerID.Text);
                biodataDetails.Remark = "Membership Extension: " + txtRemark.Text;

                ChangeButtonState(btnExtend, true);

                MessageBox.Show("Membership has extended successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nThere is an Error. You should retry.", "Information", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }            
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            try
            {
                //new SaatphereWIN.DAL.User.clsUpdate().UpdateStatus(Convert.ToInt32(txtCustomerID.Text), cmbStatus.Text);

                DateTime date1 = DateTime.Now;
                //string date2 = String.Format("{0:d}", date1);
                string date2 = DateTime.Now.ToString(SaatphereWIN.DAL.Constants.MembershipRenewalDateTimeFormat);
                string date3 = "";

                if (lblDuration.Text != string.Empty)
                {
                    //date3 = String.Format("{0:d}", date1.AddMonths(Convert.ToInt32(cmbMembershipType.SelectedValue)));
                    date3 = date1.AddMonths(Convert.ToInt32(cmbMembershipType.SelectedValue)).ToString(SaatphereWIN.DAL.Constants.MembershipRenewalDateTimeFormat);
                }



                SaatphereWIN.DAL.DataTypes.Biodata biodataDetails = new SaatphereWIN.DAL.DataTypes.Biodata();
                biodataDetails.Membershiptype = cmbMembershipType.Text;
                biodataDetails.Validity = lblContacts.Text;
                biodataDetails.ValidityLeft = lblContacts.Text;
                biodataDetails.Status = cmbStatus.Text;
                biodataDetails.StartDate = date2;
                biodataDetails.LastDate = date3.Replace('-','/');
                biodataDetails.FranchiseeUserName = SaatphereWIN.DAL.Global.Frusername;
                biodataDetails.RowIdBiodata = Convert.ToInt32(txtCustomerID.Text);
                new SaatphereWIN.DAL.User.ClsUpdate().UpdateMembership(biodataDetails);


                SaatphereWIN.DAL.DataTypes.Franchisee franchiseeDetails = new SaatphereWIN.DAL.DataTypes.Franchisee();
                float amt = 0;

                if (lblPrice.Text != string.Empty)
                {
                    amt = Convert.ToSingle(lblPrice.Text);
                    amt = amt / 2;
                }
                float amts;
                amts = (float)Math.Round(amt, 2);

                franchiseeDetails.Activity = cmbMembershipType.Text;
                franchiseeDetails.AmountDed = amts;
                franchiseeDetails.AmountRec = 0;
                franchiseeDetails.CustomerId = txtCustomerID.Text;
                franchiseeDetails.FranId = SaatphereWIN.DAL.Global.FrRowId;
                new SaatphereWIN.DAL.Franchisee.ClsInsert().InsertFranAccount(franchiseeDetails);


                SaatphereWIN.DAL.DataTypes.CustAcc custAccDetails = new SaatphereWIN.DAL.DataTypes.CustAcc();
                custAccDetails.OnDate = date2;
                custAccDetails.CustomerId = txtCustomerID.Text;
                custAccDetails.ViewId = string.Empty;
                custAccDetails.Membership = cmbMembershipType.Text;
                custAccDetails.FranId = SaatphereWIN.DAL.Global.FrRowId;


                //As per discuss with alok sir, while activating id, id shld be activate in calendar also
                //=======================================================================================
                CultureInfo myCI = new CultureInfo("en-US", false);
                DateTime startDate = Convert.ToDateTime(strdt, myCI);
                DateTime endDate = DateTime.Now.AddMonths(Convert.ToInt32(cmbMembershipType.SelectedValue));
                DateTime calculatedDate = startDate;

                string format = "d";
                DateTime dateString;
                CultureInfo provider = CultureInfo.InvariantCulture;

                string serviceModes = string.Empty;

                for (int i = 0; i <= lstServiceMode.SelectedItems.Count - 1; i++)
                {
                    serviceModes = serviceModes + ", " + lstServiceMode.Items[i].ToString();
                }

                while (startDate <= endDate)
                {
                    dateString = calculatedDate;

                    calculatedDate = calculatedDate.AddDays(10);
                    startDate = startDate.AddDays(10);
                }


                MessageBox.Show("Membership renewed successfully.", "Information", MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message + "\nThere is an error. You should retry.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnStatus_Click(sender, e);
            }
        }

        private void cmbMembershipType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbStatus.Focus();
            }
        }

        private void cmbStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lstServiceMode.Focus();
            }
        }

        private void lstServiceMode_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void lstServiceMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnUpgrade.Enabled == true)
                {
                    btnUpgrade_Click(sender, e);
                }

                if (btnRenew.Enabled == true)
                {
                    btnRenew_Click(sender, e);
                }
            }
        }

        private void txtExtendDays_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtExtendDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsNumber(e.KeyChar);
        }

        private void chkExtend_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExtend.CheckState == CheckState.Checked)
            {
                txtExtendDays.Enabled = true;
                label12.Enabled = true;
            }
            else if (chkExtend.CheckState == CheckState.Unchecked)
            {
                txtExtendDays.Enabled = false;
                label12.Enabled = false;
            }
        }

        private void btnTransfertoTomorrow_Click(object sender, EventArgs e)
        {
            if (txtCustomerID.Text.Length > 0)
            {
                MessageBox.Show("Transfer has done successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Customer ID is Empty.", "Information", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
