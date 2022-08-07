using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Text.RegularExpressions;

namespace Saatphere_WIN
{
    public partial class frmCustomerMaster : Form
    {
        SaatphereWIN.DAL.DataTypes.CustomerMaster customerMaster = new SaatphereWIN.DAL.DataTypes.CustomerMaster();
        string mode = string.Empty;

        public frmCustomerMaster(string Mode)
        {
            InitializeComponent();
            mode = Mode;

            if (mode == "ENQUIRY")
            {
                btnCheck.Visible = true;
                lblRemark.Visible = true;
                txtRemark.Visible = true;
                this.Width = 903;
            }
        }

        public frmCustomerMaster(int BiodataID)
        {
            InitializeComponent();

            DataSet dst = new DataSet();

            #region Collect Values for CustomerMaster Table
            //SaatphereWIN.DAL.DataTypes.CustomerMaster customerMaster = new SaatphereWIN.DAL.DataTypes.CustomerMaster();
            customerMaster.Id = BiodataID;
            customerMaster.Address1 = dst.Tables[0].Rows[0]["AddressLine1"].ToString();
            customerMaster.Address2 = dst.Tables[0].Rows[0]["AddressLine2"].ToString();
            customerMaster.City = dst.Tables[0].Rows[0]["city"].ToString();
            customerMaster.ContactPersonName = dst.Tables[0].Rows[0]["contactpersonname"].ToString();
            customerMaster.Country = dst.Tables[0].Rows[0]["countryuser"].ToString();
            customerMaster.Email = dst.Tables[0].Rows[0]["Emailuser"].ToString();
            customerMaster.Email2 = dst.Tables[0].Rows[0]["Emailuser2"].ToString();
            customerMaster.Mobile = dst.Tables[0].Rows[0]["Mobile"].ToString();
            customerMaster.Name = dst.Tables[0].Rows[0]["Name"].ToString();
            customerMaster.Phone1 = dst.Tables[0].Rows[0]["Telephone1"].ToString();
            customerMaster.Phone2 = dst.Tables[0].Rows[0]["Telephone2"].ToString();
            customerMaster.PinCode = dst.Tables[0].Rows[0]["Pincode"].ToString();
            customerMaster.State = dst.Tables[0].Rows[0]["state"].ToString();
            customerMaster.BiodataCreatedBy = dst.Tables[0].Rows[0]["CreatedBy"].ToString();
            #endregion            

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BindExecutive()
        {
            //cmbExecutive.DisplayMember = "Executive_Name";
            //cmbExecutive.ValueMember = "Executive_CID";

            ////Select the Current executive
            //cmbExecutive.Text = SaatphereWIN.DAL.Global.LoginUser;
        }

        private void frmCustomerMaster_Load(object sender, EventArgs e)
        {
            FillCity();
            FillState();

            BindExecutive();

            #region Collect Values for CustomerMaster Table
            //SaatphereWIN.DAL.DataTypes.CustomerMaster customerMaster = new SaatphereWIN.DAL.DataTypes.CustomerMaster();
            txtAddress1.Text= customerMaster.Address1 ;
            txtAddress2.Text= customerMaster.Address2 ;
            drpCity.Text= customerMaster.City ;
            txtContactPersonName.Text= customerMaster.ContactPersonName ;
            drpCountry.Text= customerMaster.Country ;
            txtEmail.Text= customerMaster.Email ;
            txtEmail2.Text= customerMaster.Email2 ;
            txtMobile.Text= customerMaster.Mobile ;
            txtName.Text= customerMaster.Name ;
            txtPhone1.Text= customerMaster.Phone1 ;
            txtPhone2.Text= customerMaster.Phone2 ;
            txtPinCode.Text= customerMaster.PinCode ; 
            drpState.Text=customerMaster.State ;
            this.Text = "Profile Id- " + customerMaster.Id.ToString() + " | Created By: " + customerMaster.BiodataCreatedBy;
            #endregion

            if (customerMaster.Id > 0)
            {
                btnEdit.Visible = true;
                btnSave.Visible = false;
                btnSaveinSaveFamily.Visible = false;
            }

            if (mode == "ENQUIRY")
            {
                this.Width = 903;
            }

        }

        private void FillCity()
        {
            SaatphereWIN.DAL.Masters.ClsSelect db = new SaatphereWIN.DAL.Masters.ClsSelect();
            //SaatphereWIN.DAL.Masters.clsSelect select = new SaatphereWIN.DAL.Masters.clsSelect();
            //drpCity.DataSource = select.GetCityfromGroupMaster().Tables[0];
            drpCity.DataSource = db.GetList("city").Tables[0];
            drpCity.DisplayMember = "value";
            drpCity.ValueMember = "value";
        }

        private void FillState()
        {
            SaatphereWIN.DAL.Masters.ClsSelect select = new SaatphereWIN.DAL.Masters.ClsSelect();
            drpState.DataSource = select.GetStatefromGroupMaster().Tables[0];
            drpState.DisplayMember = "value";
            drpState.ValueMember = "value";
        }

        private bool Validations()
        {
            bool response = true;

            if (txtName.Text.Length < 1)
            {
                MessageBox.Show("Name is mandatory.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.BackColor = Color.LightYellow;
                txtName.Focus();
                response = false;
            }

            if (txtMobile.Text.Length < 1)
            {
                MessageBox.Show("Mobile Number is mandatory.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMobile.BackColor = Color.LightYellow;
                txtMobile.Focus();
                response = false;
            }

            if (txtEmail.Text.Length > 0)
            {
                if (!Regex.IsMatch(txtEmail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                {
                    MessageBox.Show("Email Address1 has Invalid Format.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmail.SelectAll();
                    response = false;
                }
            }

            if (txtEmail2.Text.Length > 0)
            {
                if (!Regex.IsMatch(txtEmail2.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                {
                    MessageBox.Show("Email Address2 has Invalid Format.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmail2.SelectAll();
                    response = false;
                }
            }

            if (!Regex.IsMatch(txtMobile.Text.Trim(), @"^[0-9]{10,12}$"))
            {
                MessageBox.Show("Mobile Number has Invalid Format. It should be 10 Numeric digits.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMobile.SelectAll();
                response = false;
            }

            return response;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Collect the values
                //---------------------------------------------------------------------------------------------
                #region Collect Values for CustomerMaster Table
                //SaatphereWIN.DAL.DataTypes.CustomerMaster customerMaster = new SaatphereWIN.DAL.DataTypes.CustomerMaster();
                customerMaster.Address1 = txtAddress1.Text.Trim();
                customerMaster.Address2 = txtAddress2.Text.Trim();
                customerMaster.City = drpCity.Text.Trim();
                customerMaster.ContactPersonName = txtContactPersonName.Text.Trim();
                customerMaster.Country = drpCountry.Text.Trim();
                customerMaster.Email = txtEmail.Text.Trim();
                customerMaster.Email2 = txtEmail2.Text.Trim();
                customerMaster.Mobile = txtMobile.Text.Trim();
                customerMaster.Name = txtName.Text.Trim();
                customerMaster.Phone1 = txtPhone1.Text.Trim();
                customerMaster.Phone2 = txtPhone2.Text.Trim();
                customerMaster.PinCode = txtPinCode.Text.Trim();
                customerMaster.State = drpState.Text.Trim();
                customerMaster.BiodataCreatedBy = SaatphereWIN.DAL.Global.LoginUser;
                #endregion
                //---------------------------------------------------------------------------------------------
                if (!Validations())
                {
                    return;
                }

                //Check for the duplicate Profiles
                //---------------------------------------------------------------------------------------------
                DataSet dstDuplicate = new DataSet();
                string configFilter = ConfigurationManager.AppSettings["CustomerMasterDuplicateFilter"].ToString();
                dstDuplicate = new SaatphereWIN.DAL.User.ClsSelect().GetDuplicateId(customerMaster.Email, customerMaster.Mobile, configFilter);

                //Duplicate record will be saved on by the Save in same family button
                if (dstDuplicate.Tables[0].Rows.Count > 0)
                {
                    new frmDuplicateIDList(dstDuplicate).ShowDialog();
                }
                else //Save the Record
                {
                    Cursor.Current = Cursors.WaitCursor;

                    #region Variable and Object Initialization
                    SaatphereWIN.DAL.User.ClsSelect select = new SaatphereWIN.DAL.User.ClsSelect();
                    SaatphereWIN.DAL.User.ClsInsert insert = new SaatphereWIN.DAL.User.ClsInsert();

                    long check = 0;
                    int id = 0;
                    string createdby1 = SaatphereWIN.DAL.Global.LoginMessage.ToString();
                    SaatphereWIN.DAL.Global.LoginMessageforDetails = createdby1.ToString();

                    string city = customerMaster.City;
                    string state = customerMaster.State;
                    string country = customerMaster.Country;

                    check = select.CountUsers();

                    if (check == 0)
                    {
                        insert.InsertBlankRowUserLogin();
                    }

                    //select the maxmimunm value from the table
                    id = select.GetMaxTemp1Id();

                    if (id == 0)
                    {
                        id = id + 1000;
                    }
                    else
                    {
                        id = id + 1;
                    }
                    customerMaster.Id = id;
                    #endregion

                    

                    insert.InsertAddUser(customerMaster); //Add Details in Customer Master Table

                    //Add the userid and 
                    
                    
                    
                    
                    for the adduser2 table
                    string struname = SaatphereWIN.DAL.Global.Unameinsert;
                    SaatphereWIN.DAL.Global.Password2 = Guid.NewGuid().ToString();

                    #region Biodata Table details and insert the details
                    ////SaatphereWIN.DAL.DataTypes.Biodata BiodataDetails = new SaatphereWIN.DAL.DataTypes.Biodata();
                    ////BiodataDetails.CityofResidence = customerMaster.City;
                    ////BiodataDetails.Country = customerMaster.Country;
                    ////BiodataDetails.Email = customerMaster.Email;
                    ////BiodataDetails.ResidentialAddress = customerMaster.Address1 + " | " + customerMaster.Address2;
                    ////BiodataDetails.PinCode = customerMaster.PinCode;
                    ////BiodataDetails.ResidenceNo = customerMaster.Phone1;
                    ////BiodataDetails.Mobile = customerMaster.Mobile;
                    ////BiodataDetails.Email2 = customerMaster.Email2;
                    ////BiodataDetails.FirstName = customerMaster.Name;
                    ////BiodataDetails.RowIdBiodata = customerMaster.id;
                    ////insert.InsertAddUser2(BiodataDetails ,SaatphereWIN.DAL.Global.LoginMessage.ToString(), 
                    ////    SaatphereWIN.DAL.Global.frusername.ToString());



                    SaatphereWIN.DAL.DataTypes.Biodata BiodataDetails = new SaatphereWIN.DAL.DataTypes.Biodata();
                    BiodataDetails.CityofResidence = customerMaster.City;
                    BiodataDetails.Country = customerMaster.Country;
                    BiodataDetails.Email = customerMaster.Email;
                    BiodataDetails.ResidentialAddress = customerMaster.Address1 + " | " + customerMaster.Address2;
                    BiodataDetails.PinCode = customerMaster.PinCode;
                    BiodataDetails.ResidenceNo = customerMaster.Phone1;
                    BiodataDetails.Mobile = customerMaster.Mobile;
                    BiodataDetails.Email2 = customerMaster.Email2;
                    BiodataDetails.FirstName = customerMaster.Name;
                    BiodataDetails.RowIdBiodata = customerMaster.Id;

                    #endregion
                    //new SaatphereWIN.DAL.User.clsUpdate().UpdateValidity(customerMaster.id); //Update the Validity

                    #region Registration Details
                    decimal amt = 0;
                    DateTime date1 = DateTime.Now;
                    string date2 = String.Format("{0:d}", date1);

                    amt = new SaatphereWIN.DAL.Membership.ClsSelect().GetMembershipPrice();

                    int ifr = 0;
                    new SaatphereWIN.DAL.Franchisee.ClsInsert().InsertFranAccount(amt, customerMaster.Id, ifr, SaatphereWIN.DAL.Global.LoginMessage.ToString(), "Registered");
                    #endregion

                    InsertEnquiryDetails(); //If the form is in Enquiry Mode then this method will save the Enquiry related details

                    string messageBoxMessage = "Information saved successfully.\nThe Biodata id is " + customerMaster.Id + "\n\nProceed with Biodata details?";
                    if (MessageBox.Show(messageBoxMessage, "Information saved.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        new frmCustomerDetails(BiodataDetails).ShowDialog();
                    }

                    Cursor.Current = Cursors.Default;


                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error.\n" + ex.Message + "\nPlease retry...", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
            }
            
        }


        private void InsertEnquiryDetails()
        {
            #region Save with the Enquiry option
            if (mode == "ENQUIRY")
            {
                int executiveID = new SaatphereWIN.DAL.Franchisee.ClsSelect().GetExecutiveIdFromName(SaatphereWIN.DAL.Global.LoginUser);

                SaatphereWIN.DAL.DataTypes.FollowUp followUpDetails = new SaatphereWIN.DAL.DataTypes.FollowUp();
                SaatphereWIN.DAL.DataTypes.Activity activityDetails = new SaatphereWIN.DAL.DataTypes.Activity();

                activityDetails.ActivityActive = true;
                activityDetails.ActivityDateTime = DateTime.Now;
                activityDetails.ActivityDetails = txtRemark.Text;
                activityDetails.ActivityExecutive = SaatphereWIN.DAL.Global.LoginUser;  //cmbExecutive.Text;
                activityDetails.ActivityFranchiseeId = Convert.ToInt32(SaatphereWIN.DAL.Global.FrRowId);
                activityDetails.ActivityProfileId = customerMaster.Id;
                activityDetails.ActivityType = "ENQUIRY";
                new SaatphereWIN.DAL.Complaints.ClsInsert().InsertTagging(activityDetails);

                followUpDetails.FollowUpActive = true;
                followUpDetails.FollowUpActivityCid = new SaatphereWIN.DAL.Complaints.ClsSelect().GetMaxActivityId();
                followUpDetails.FollowUpCreatedBy = executiveID;
                followUpDetails.FollowUpDateCreated = DateTime.Now;
                followUpDetails.FollowUpDateTime = txtDOF.Value;
                followUpDetails.FollowUpExecutiveId = new SaatphereWIN.DAL.Franchisee.ClsSelect().GetExecutiveIdFromName(SaatphereWIN.DAL.Global.LoginUser);
                new SaatphereWIN.DAL.Complaints.ClsInsert().InsertFollowUp(followUpDetails);
            }
            #endregion
        }


        private void btnSaveinSaveFamily_Click(object sender, EventArgs e)
        {
            //Collect the values
            //---------------------------------------------------------------------------------------------
            #region Collect Values for CustomerMaster Table
            SaatphereWIN.DAL.DataTypes.CustomerMaster customerMaster = new SaatphereWIN.DAL.DataTypes.CustomerMaster();
            customerMaster.Address1 = txtAddress1.Text.Trim();
            customerMaster.Address2 = txtAddress2.Text.Trim();
            customerMaster.City = drpCity.Text.Trim();
            customerMaster.ContactPersonName = txtContactPersonName.Text.Trim();
            customerMaster.Country = drpCountry.Text.Trim();
            customerMaster.Email = txtEmail.Text.Trim();
            customerMaster.Email2 = txtEmail2.Text.Trim();
            customerMaster.Mobile = txtMobile.Text.Trim();
            customerMaster.Name = txtName.Text.Trim();
            customerMaster.Phone1 = txtPhone1.Text.Trim();
            customerMaster.Phone2 = txtPhone2.Text.Trim();
            customerMaster.PinCode = txtPinCode.Text.Trim();
            customerMaster.State = drpState.Text.Trim();
            #endregion
            //---------------------------------------------------------------------------------------------
            Validations();       

            if (SaatphereWIN.DAL.Global.LoginMessage != null)
            {
                string createdby1 = SaatphereWIN.DAL.Global.LoginMessage;
                SaatphereWIN.DAL.Global.LoginMessageforDetails = createdby1.ToString();

                //check if the table is null

                SaatphereWIN.DAL.User.ClsSelect select = new SaatphereWIN.DAL.User.ClsSelect();
                int check = select.CountUsers();

                SaatphereWIN.DAL.User.ClsInsert insert = new SaatphereWIN.DAL.User.ClsInsert();

                if (check == 0)
                {
                    insert.InsertBlankRowUserLogin();
                }

                //select the maxmimunm value from the table

                insert.InsertMaxIdinTemp1();

                //select the value and incretant by 1

                int id = select.GetMaxTemp1Id();

                if (id == 0)
                {
                    id = id + 1000;
                }
                else
                {
                    id = id + 1;
                }
                customerMaster.Id = id;

                //set the password and username
                string uname = customerMaster.Name;
                string unamefinal = uname.Substring(0, 1).ToUpper();
                long inmid = id;
                string unameinsert = unamefinal + inmid.ToString();
                SaatphereWIN.DAL.Global.Unameinsert = unameinsert.ToString();
                string tempstr = inmid + Guid.NewGuid().ToString();// Session.SessionID;
                string tempretrive = tempstr.Substring(0, 6);
                SaatphereWIN.DAL.Global.Password = tempretrive;

                //add to the userlogin table
                insert.InsertUserLogin(unameinsert, tempretrive);

                //add the username and password to the contactdetail
                string createdBy = string.Empty;
                if (createdby1 == "adminlogin")
                {
                    createdBy = "A";
                }
                else
                {
                    createdBy = "F";
                }

                insert.InsertAddUser(customerMaster); //Add Details in Customer Master Table

                new SaatphereWIN.DAL.User.ClsDelete().DeleteTemp1();

                //Add the userid and password for the adduser2 table
                #region Biodata Table details and insert the details
                //SaatphereWIN.DAL.DataTypes.Biodata BiodataDetails = new SaatphereWIN.DAL.DataTypes.Biodata();
                //BiodataDetails.CityofResidence = customerMaster.City;
                //BiodataDetails.Country = customerMaster.Country;
                //BiodataDetails.Email = customerMaster.Email;
                //BiodataDetails.ResidentialAddress = customerMaster.Address1 + " | " + customerMaster.Address2;
                //BiodataDetails.PinCode = customerMaster.PinCode;
                //BiodataDetails.ResidenceNo = customerMaster.Phone1;
                //BiodataDetails.Mobile = customerMaster.Mobile;
                //BiodataDetails.Email2 = customerMaster.Email2;
                //BiodataDetails.FirstName = customerMaster.Name;
                //BiodataDetails.RowIdBiodata = customerMaster.id;

                //insert.InsertAddUser2(BiodataDetails, SaatphereWIN.DAL.Global.LoginMessage.ToString(),
                //    SaatphereWIN.DAL.Global.frusername.ToString());

                SaatphereWIN.DAL.DataTypes.Biodata BiodataDetails = new SaatphereWIN.DAL.DataTypes.Biodata();
                BiodataDetails.CityofResidence = customerMaster.City;
                BiodataDetails.Country = customerMaster.Country;
                BiodataDetails.Email = customerMaster.Email;
                BiodataDetails.ResidentialAddress = customerMaster.Address1 + " | " + customerMaster.Address2;
                BiodataDetails.PinCode = customerMaster.PinCode;
                BiodataDetails.ResidenceNo = customerMaster.Phone1;
                BiodataDetails.Mobile = customerMaster.Mobile;
                BiodataDetails.Email2 = customerMaster.Email2;
                BiodataDetails.FirstName = customerMaster.Name;
                BiodataDetails.RowIdBiodata = customerMaster.Id;

                #endregion

                new SaatphereWIN.DAL.User.ClsUpdate().UpdateValidity(customerMaster.Id);

                #region Registration Details
                decimal amt = 0;
                DateTime date1 = DateTime.Now;
                string date2 = String.Format("{0:d}", date1);

                amt = new SaatphereWIN.DAL.Membership.ClsSelect().GetMembershipPrice();

                int ifr = 0;
                #endregion

                InsertEnquiryDetails(); //If the form is in Enquiry Mode then this method will save the Enquiry related details

                //string messageBoxMessage = "Information saved successfully.\nProceed with Biodata details?";
                string messageBoxMessage = "Information saved successfully.\nThe Biodata id is " + customerMaster.Id + "\n\nProceed with Biodata details?";

                if (MessageBox.Show(messageBoxMessage, "Information saved.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    new frmCustomerDetails(BiodataDetails).ShowDialog();
                }

                this.Close();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //Collect the values
            //---------------------------------------------------------------------------------------------
            #region Collect Values for CustomerMaster Table
            //SaatphereWIN.DAL.DataTypes.CustomerMaster customerMaster = new SaatphereWIN.DAL.DataTypes.CustomerMaster();
            customerMaster.Address1 = txtAddress1.Text.Trim();
            customerMaster.Address2 = txtAddress2.Text.Trim();
            customerMaster.City = drpCity.Text.Trim();
            customerMaster.ContactPersonName = txtContactPersonName.Text.Trim();
            customerMaster.Country = drpCountry.Text.Trim();
            customerMaster.Email = txtEmail.Text.Trim();
            customerMaster.Email2 = txtEmail2.Text.Trim();
            customerMaster.Mobile = txtMobile.Text.Trim();
            customerMaster.Name = txtName.Text.Trim();
            customerMaster.Phone1 = txtPhone1.Text.Trim();
            customerMaster.Phone2 = txtPhone2.Text.Trim();
            customerMaster.PinCode = txtPinCode.Text.Trim();
            customerMaster.State = drpState.Text.Trim();
            #endregion
            //---------------------------------------------------------------------------------------------
            if (!Validations())
            {
                return;
            }

            //MessageBox.Show("Biodata - Master Information has updated successfully.", "Information saved.", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            string messageBoxMessage = "Information saved successfully.\nThe Biodata id is " + customerMaster.Id + "\n\nProceed with Biodata details?";
            if (MessageBox.Show(messageBoxMessage, "Information saved.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                new frmCustomerDetails(customerMaster.Id, true, customerMaster).ShowDialog();
            }

            this.Close();          
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            //check the existence of the mobile number
            string mobileNumber = txtMobile1.Text;

            if (new SaatphereWIN.DAL.User.ClsSelect().IsMobileNumberExists(mobileNumber)) 
            {
                MessageBox.Show("Mobile Number exists in Database.", "Check Mobile Number - Saatphere", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Mobile Number not exists in Database.", "Check Mobile Number - Saatphere", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtMobile1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtMobile1_KeyDown(object sender, KeyEventArgs e)
        {
            //txtMobile.Text = txtMobile1.Text;
        }
    }
}
