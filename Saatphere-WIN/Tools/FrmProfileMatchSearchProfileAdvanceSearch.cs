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
    public partial class FrmProfileMatchSearchProfileAdvanceSearch : Form
    {
        string xmlFolder = "TemporaryXML\\";
        int userProfileID = 0;

        public FrmProfileMatchSearchProfileAdvanceSearch(int UserProfileID = 0, string UserGender = "")
        {
            InitializeComponent();
            userProfileID = UserProfileID;

            this.Text = this.Text + " - " + userProfileID.ToString();

            txtEducation.Text = "";
            txtCityofResidence.Text = "";
            txtReligion.Text = "";
            txtMotherTongue.Text = "";
            txtCandidateLocation.Text = "";
            txtOccupation.Text = "";
            txtState.Text = "";
            txtCaste.Text = "";
            txtDiet.Text = "";



            if (UserGender.Length > 0)
            {
                if (UserGender == "Male")
                {
                    cmbGender.SelectedItem = "Female";
                }
                else if (UserGender == "Female")
                {
                    cmbGender.SelectedItem = "Male";
                }
                cmbGender.Enabled = false;
            }
            else
            {
                cmbGender.Enabled = true;
            }
        }

        private void btnSelectEducation_Click(object sender, EventArgs e)
        {
            using (var form = new FrmProfileMatchOptionsList("Education.xml"))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue1;            //values preserved after close
                    //string dateString = form.ReturnValue2;
                    //Do something here with these values

                    //for example
                    txtEducation.Text = val;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectCaste_Click(object sender, EventArgs e)
        {
            using (var form = new FrmProfileMatchOptionsList("Caste.xml"))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue1;            //values preserved after close
                    //string dateString = form.ReturnValue2;
                    //Do something here with these values

                    //for example
                    txtCaste.Text = val;
                }
            }

        }

        private void btnSelectState_Click(object sender, EventArgs e)
        {
            using (var form = new FrmProfileMatchOptionsList("State.xml"))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue1;            //values preserved after close
                    //string dateString = form.ReturnValue2;
                    //Do something here with these values

                    //for example
                    txtState.Text = val;
                }
            }
        }

        private void btnSelectOccupation_Click(object sender, EventArgs e)
        {
            using (var form = new FrmProfileMatchOptionsList("Occupation.xml"))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue1;            //values preserved after close
                    //string dateString = form.ReturnValue2;
                    //Do something here with these values

                    //for example
                    txtOccupation.Text = val;
                }
            }

        }

        private void btnSelectCandidaeLocation_Click(object sender, EventArgs e)
        {
            using (var form = new FrmProfileMatchOptionsList("CityofResidence.xml"))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue1;            //values preserved after close
                    //string dateString = form.ReturnValue2;
                    //Do something here with these values

                    //for example
                    txtCandidateLocation.Text = val;
                }
            }

        }

        private void btnSelectMotherTongue_Click(object sender, EventArgs e)
        {
            using (var form = new FrmProfileMatchOptionsList("MotherTongue.xml"))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue1;            //values preserved after close
                    //string dateString = form.ReturnValue2;
                    //Do something here with these values

                    //for example
                    txtMotherTongue.Text = val;
                }
            }
        
        }

        private void btnSelectReligion_Click(object sender, EventArgs e)
        {
            using (var form = new FrmProfileMatchOptionsList("Religion.xml"))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue1;            //values preserved after close
                    //string dateString = form.ReturnValue2;
                    //Do something here with these values

                    //for example
                    txtReligion.Text = val;
                }
            }
        }

        private void btnSelectCityofResidence_Click(object sender, EventArgs e)
        {
            using (var form = new FrmProfileMatchOptionsList("CityofResidence.xml"))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue1;            //values preserved after close
                    //string dateString = form.ReturnValue2;
                    //Do something here with these values

                    //for example
                    txtCityofResidence.Text = val;
                }
            }
        }

        private void frmProfileMatchSearchProfileAdvanceSearch_Load(object sender, EventArgs e)
        {
            BindDropDowns();
        }

        private void BindDropDowns()
        {
            BindAge();
            BindManglik();
            BindAnnualIncomeFrom();
            BindAnnualIncomeTo();
            BindMaritalStatus();
            BindCasteNoBar();
            BindCountry();
            //BindGender();
            BindHeight();
        }

        private void BindHeight()
        {
            cmbHeightFrom.Text = "Dosen't Matter";
            cmbHeightTo.Text = "Dosen't Matter";
        }

        private void BindGender()
        {
            cmbGender.Text = "Male";
        }
        

        private void BindCountry()
        {
            cmbCountry.Text = "India";

        }


        private void BindCasteNoBar()
        {
            cmbCasteNoBar.Text = "Doesn't Matter";
        }

        private void BindAge()
        {
            DataSet dstAgeFrom = new DataSet();
            dstAgeFrom.ReadXml(xmlFolder + "age.xml");
            cmbAgeFrom.DataSource = dstAgeFrom.Tables[0];
            cmbAgeFrom.DisplayMember = "value";
            cmbAgeTo.DisplayMember = "value";

            DataSet dstAgeTo = new DataSet();
            dstAgeTo.ReadXml(xmlFolder + "age.xml");
            cmbAgeTo.DataSource = dstAgeTo.Tables[0];
            cmbAgeTo.DisplayMember = "value";
            cmbAgeTo.DisplayMember = "value";
        }

        private void BindManglik()
        {
            DataSet dst = new DataSet();
            dst.ReadXml(xmlFolder + "manglik.xml");
            cmbMangalik.DataSource = dst.Tables[0];
            cmbMangalik.DisplayMember = "value";
            cmbMangalik.DisplayMember = "value";

            cmbMangalik.Text = "Dosen't Matter";
        }

        private void BindMaritalStatus()
        {
            DataSet dst = new DataSet();
            dst.ReadXml(xmlFolder + "MaritalStatus.xml");
            cmbMaritalStatus.DataSource = dst.Tables[0];
            cmbMaritalStatus.DisplayMember = "value";
            cmbMaritalStatus.DisplayMember = "value";

            cmbMaritalStatus.Text = "UnMarried";
        }

        private void BindAnnualIncomeFrom()
        {
            DataSet dst = new DataSet();
            dst.ReadXml(xmlFolder + "AnnualIncome.xml");
            cmbAnnualIncomeFrom.DataSource = dst.Tables[0];
            cmbAnnualIncomeFrom.DisplayMember = "value";
            cmbAnnualIncomeFrom.DisplayMember = "value";

            cmbAnnualIncomeFrom.Text = "Dosen't Matter";
        }

        private void BindAnnualIncomeTo()
        {
            DataSet dst = new DataSet();
            dst.ReadXml(xmlFolder + "AnnualIncome.xml");
            cmbAnnualIncomeTo.DataSource = dst.Tables[0];
            cmbAnnualIncomeTo.DisplayMember = "value";
            cmbAnnualIncomeTo.DisplayMember = "value";

            cmbAnnualIncomeTo.Text = "Dosen't Matter";
        }

        private void btnSelectDiet_Click(object sender, EventArgs e)
        {
            using (var form = new FrmProfileMatchOptionsList("Diet.xml"))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue1;            //values preserved after close
                    //string dateString = form.ReturnValue2;
                    //Do something here with these values

                    //for example
                    txtDiet.Text = val;
                }
            }
        }

        private void btnSearchfromPaidMembers_Click(object sender, EventArgs e)
        {


            #region Saatphere
            SaatphereWIN.DAL.DataTypes.SearchFields searchFields = new SaatphereWIN.DAL.DataTypes.SearchFields();

            if (txtCityofResidence.Text.Length > 0)
            {
                searchFields.City = txtCityofResidence.Text.Trim();
            }

            if (txtCandidateLocation.Text.Length > 0)
            {
                searchFields.CandidateLocation = txtCandidateLocation.Text.Trim();
            }

            if (txtEducation.Text.Length > 0)
            {
                searchFields.Education = txtEducation.Text.Trim();
            }

            if (txtReligion.Text.Length > 0)
            {
                searchFields.Religion = txtReligion.Text.Trim();
            }

            if (txtState.Text.Length > 0)
            {
                searchFields.State = txtState.Text.Trim();
            }

            if (txtOccupation.Text.Length > 0)
            {
                searchFields.Occupation = txtOccupation.Text.Trim();
            }

            if (txtCaste.Text.Length > 0)
            {
                searchFields.Caste = txtCaste.Text.Trim();
            }

            if (txtMotherTongue.Text.Length > 0)
            {
                searchFields.Mothertongue = txtMotherTongue.Text.Trim();
            }

            if (txtDiet.Text.Length > 0)
            {
                searchFields.Diet = txtDiet.Text.Trim();
            }

            searchFields.HeightFrom = cmbHeightFrom.Text;
            searchFields.HeightTo = cmbHeightTo.Text;
            searchFields.AgeFrom = cmbAgeFrom.Text;
            searchFields.AgeTo = cmbAgeTo.Text;
            searchFields.AnnualIncomeFrom = cmbAnnualIncomeFrom.Text;
            searchFields.AnnualIncomeTo = cmbAnnualIncomeTo.Text;
            searchFields.MaritalStatus = cmbMaritalStatus.Text;
            searchFields.NoofChildren = txtNoOfChildren.Text;
            searchFields.Manglik = cmbMangalik.Text;
            searchFields.Country = cmbCountry.Text;
            searchFields.Gender = cmbGender.Text;
            searchFields.CasteNoBar = cmbCasteNoBar.Text;
            searchFields.WithPicture = chkPicture.Checked;

            #endregion

            if (new SaatphereWIN.DAL.Membership.ClsSelect().IsPaidMember(userProfileID))
            {
                if (new SaatphereWIN.DAL.Membership.ClsSelect().IsMembershipExpired(userProfileID))
                {
                    //Session["_MESSAGEHEADING"] = "Membership is Expired";
                    //Session["_MESSAGEBODY"] = Session["MembershipExpired"].ToString();
                    //Response.Redirect("Saatphere_MessagePage.aspx", true);
                    //Response.Redirect("Saatphere_ProfileMatch_MatchResults.aspx", true);
                    MessageBox.Show("Membership Expired: No Address Details will appear", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    new Tools.FrmProfileMatchResults(searchFields,userProfileID, false).ShowDialog();

                }
                else
                {
                    //Response.Redirect("Saatphere_ProfileMatch_MatchResultsWithAddress.aspx", true);
                    new Tools.FrmProfileMatchResults(searchFields,userProfileID, true).ShowDialog();
                }
            }
            else
            {
                //Response.Redirect("Saatphere_ProfileMatch_MatchResults.aspx", true);
                MessageBox.Show("Not a Paid Member: No Address Details will appear", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new Tools.FrmProfileMatchResults(searchFields, userProfileID, false).ShowDialog();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            #region Saatphere
            SaatphereWIN.DAL.DataTypes.SearchFields searchFields = new SaatphereWIN.DAL.DataTypes.SearchFields();

            if (txtCityofResidence.Text.Length > 0)
            {
                searchFields.City = txtCityofResidence.Text.Trim();
            }

            if (txtCandidateLocation.Text.Length > 0)
            {
                searchFields.CandidateLocation = txtCandidateLocation.Text.Trim();
            }

            if (txtEducation.Text.Length > 0)
            {
                searchFields.Education = txtEducation.Text.Trim();
            }

            if (txtReligion.Text.Length > 0)
            {
                searchFields.Religion = txtReligion.Text.Trim();
            }

            if (txtState.Text.Length > 0)
            {
                searchFields.State = txtState.Text.Trim();
            }

            if (txtOccupation.Text.Length > 0)
            {
                searchFields.Occupation = txtOccupation.Text.Trim();
            }

            if (txtCaste.Text.Length > 0)
            {
                searchFields.Caste = txtCaste.Text.Trim();
            }

            if (txtMotherTongue.Text.Length > 0)
            {
                searchFields.Mothertongue = txtMotherTongue.Text.Trim();
            }

            if (txtDiet.Text.Length > 0)
            {
                searchFields.Diet = txtDiet.Text.Trim();
            }

            //handle annual income
            

            searchFields.HeightFrom = cmbHeightFrom.Text;
            searchFields.HeightTo = cmbHeightTo.Text;
            searchFields.AgeFrom = cmbAgeFrom.Text;
            searchFields.AgeTo = cmbAgeTo.Text;

            //if(cmbAnnualIncomeFrom.Text == "-")
            //{

            //}

            //if (cmbAnnualIncomeTo.Text == "-")
            //{

            //}

            //string[] annualIncomeFrom = cmbAnnualIncomeFrom.Text.Split('-');
            //string[] annualIncomeTo = cmbAnnualIncomeTo.Text.Split('-');
            //searchFields.AnnualIncomeFrom = annualIncomeFrom[0].Replace("Lacs","").Replace("Lac","").Trim();
            //searchFields.AnnualIncomeTo = annualIncomeTo[1].Replace("Lacs", "").Replace("Lac", "").Trim(); 

            searchFields.AnnualIncomeFrom = cmbAnnualIncomeFrom.Text.Trim();
            searchFields.AnnualIncomeTo = cmbAnnualIncomeTo.Text.Trim();

            searchFields.MaritalStatus = cmbMaritalStatus.Text;
            searchFields.NoofChildren = txtNoOfChildren.Text;
            searchFields.Manglik = cmbMangalik.Text;
            searchFields.Country = cmbCountry.Text;
            searchFields.Gender = cmbGender.Text;
            searchFields.CasteNoBar = cmbCasteNoBar.Text;
            searchFields.WithPicture = chkPicture.Checked;

            #endregion

            {
                {
                    MessageBox.Show("Membership Expired  or an unpaid Member: No Address Details will appear", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    new Tools.FrmProfileMatchResults(searchFields, userProfileID, false, true).ShowDialog();
                }
                else
                {
                    new Tools.FrmProfileMatchResults(searchFields, userProfileID, true, true).ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Not a Paid Member: No Address Details will appear", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new Tools.FrmProfileMatchResults(searchFields, userProfileID, false, true).ShowDialog();
            }
            
        }
    }
}


