using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Saatphere_WIN.Tools
{
    public partial class FrmProfileMatchSearchProfileResult : Form
    {
        public FrmProfileMatchSearchProfileResult(SaatphereWIN.DAL.DataTypes.SearchResults SearchResults)
        {
            InitializeComponent();

            try
            {
                WebClient wc = new WebClient();
                wc.Headers.Add("user-agent", "Only a test!");

                byte[] bytes = wc.DownloadData(SearchResults.Photograph);
                MemoryStream ms = new MemoryStream(bytes);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                pictUserImage.Image = img;
            }
            catch (Exception)
            {
                //throw;
            }

            lblProfileID.Text = SearchResults.Id;
            lblName.Text = SearchResults.Name;
            lblMaritalStatus.Text = SearchResults.MaritalStatus;
            lblGender.Text = SearchResults.Gender;
            lblCasteNoBar.Text = SearchResults.CastenoBar;
            lblDOB.Text = SearchResults.Dob;
            lblState.Text = SearchResults.State;
            lblAge.Text = SearchResults.Age;
            lblHeight.Text = SearchResults.Height;
            lblQualification.Text = SearchResults.Qualification;
            lblReligion.Text = SearchResults.Religion;
            lblOccupation.Text = SearchResults.Occupation;
            lblMotherTongue.Text = SearchResults.MotherTongue;
            lblCaste.Text = SearchResults.Caste;


        }

        private void btnAdvanceSearch_Click(object sender, EventArgs e)
        {
        }

        private void frmProfileMatchSearchProfileResult_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearchMachProfiles_Click(object sender, EventArgs e)
        {

            string gender = lblGender.Text;
            string caste = lblCaste.Text;
            string religion = lblReligion.Text;
            string state = lblState.Text;
            string motherTongue = lblMotherTongue.Text;
            string qualification = lblQualification.Text;


            if (gender == "Male")
            {
                query = query + " where Gender = 'Female' ";
            }
            else if (gender == "Female")
            {
                query = query + " where Gender = 'Male' ";
            }

            if (chkProfileWithPicture.Checked)
                query = query + " and LEN(convert(varchar, photograph)) > 0 ";


            if (chkSameCaste.Checked)
            {
                if (caste != "Dosen't Matter")
                {
                    if (!chkCastenoBar.Checked)
                        query = query + " and caste ='" + caste + "'";
                }
            }

            if (chkSameMotherTongue.Checked)
                query = query + " and mothertongue ='" + motherTongue + "'";

            if (chkSameReligion.Checked)
                query = query + " and religion ='" + religion + "'";

            if (chkState.Checked)
                query = query + " and Lower(contactdetail.state)  ='" + state.ToLower() + "'"; //City variable contains the State

            if (chkEducation.Checked)
            {
                if (gender == "Male")
                {
                    // if boy = professional, doctorate then professional, doctorate
                    //if boy = graduate , post graduate then graduate, post-graduate
                    //if boy = under graduate, diploma then under graduate, graduate, diploma, post graduate.
                    if (qualification == "Professional" || qualification == "Doctorate")
                        query = query + " and EducationStatus in ('Professional', 'Doctorate')";
                    else if (qualification == "Graduate" || qualification == "Post Graduate")
                          query = query + " and EducationStatus in ('Graduate', 'Post Graduate')";
                    else if (qualification == "Under Graduate" || qualification == "Diploma")
                         query = query + " and EducationStatus in ('Under Graduate', 'Graduate', 'Diploma', 'Post Graduate')";
                    }
                else if (gender == "Female")
                {
                    //if gals education = professional or doctorate then all male professionals and doctorate
                    //if gals education = graduate and post graduate then graduate and post graduate and professional and doctorate
                    //if gals education = diploma or under-graduate then graduates, under-graduate and diploma.
                    if (qualification == "Professional" || qualification == "Doctorate")
                        query = query + " and EducationStatus in ('Professional', 'Doctorate')";
                    else if (qualification == "Graduate" || qualification == "Post Graduate")
                        query = query + " and EducationStatus in ('Graduate', 'Post Graduate','Professional', 'Doctorate')";
                    else if (qualification == "Under Graduate" || qualification == "Diploma")
                        query = query + " and EducationStatus in ('Under Graduate', 'Graduate', 'Diploma')";
                }
            }

            if (chkCastenoBar.Checked)
                query = query + " and castenobar  ='Yes'";

            if (drpMaritalStatus.Text != "Doesn't Matter")
                query = query + " and MartialStatus  ='" + drpMaritalStatus.Text + "'";

            if (drpAnnualIncome.Text != "Dosen't Matter" && drpAnnualIncome.Text != "-")
                query = query + " and AnnualIncome  ='" + drpAnnualIncome.Text + "'";

            if (chkAgeFactor.Checked)
            {
                if (lblAge.Text.Trim().Length > 0)
                {
                    string DOB = lblAge.Text;

                    if (gender == "Male")
                    {   //For males age = age -5
                        query = query + " and convert(int,Age) >= " +
                                        " convert(int, " + txtAgeFrom.Text.ToString() + ")  and " +
                                        " Convert(int, age) <= " +
                                        " Convert(int," + txtAgeTo.Text.ToString() + ") ";
                    }
                    else if (gender == "Female")
                    {   //For girls age = age + 4
                        query = query + " and Convert(int,Age) >= " +
                                        " Convert(int," + txtAgeFrom.Text.ToString() + ") and " +
                                        " Convert(int,Age) <= " +
                                        " Convert(int," + txtAgeTo.Text.ToString() + ") ";
                    }
                }
            }

            //Reason, If Internal Visibility is NO, biodata shouldnt be visible in searching

            string ProfileName = new SaatphereWIN.DAL.User.ClsSelect().GetProfileFirstNamefromProfileCid(Convert.ToInt32(lblProfileID.Text)).Substring(0, 1) + lblProfileID.Text;

            //string query = query;
            //Session["AdvanceSearch"] = null; //This Session is using for Advance Search page and not here
            //Based on the Membership the user will redirect to the specified page
            //--------------------------------------------------------------------
            int userProfileID = Convert.ToInt32(lblProfileID.Text);
            if (new SaatphereWIN.DAL.Membership.ClsSelect().IsPaidMember(userProfileID))
            {
                if (new SaatphereWIN.DAL.Membership.ClsSelect().IsMembershipExpired(userProfileID))
                {
                    new Tools.FrmProfileMatchResults(query).ShowDialog();
                }
                else
                {
                    new Tools.FrmProfileMatchResults(query).ShowDialog();
                }
            }
            else
            {
                new Tools.FrmProfileMatchResults(query).ShowDialog();
            }
        }

        private void btnSearchbyID_Click(object sender, EventArgs e)
        {
            bool withAddress = false;
            int userProfileID = Convert.ToInt32(lblProfileID.Text);

            if (new SaatphereWIN.DAL.Membership.ClsSelect().IsPaidMember(userProfileID))
            {
                if (new SaatphereWIN.DAL.Membership.ClsSelect().IsMembershipExpired(userProfileID))
                {
                    MessageBox.Show("Membership Expired: No Address Details will appear", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    withAddress = false;
                }
                else
                {
                    withAddress = true;
                }
            }
            else
            {
                MessageBox.Show("Not a Paid Member: No Address Details will appear", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                withAddress = false;
            }

            //If the customer for whom system is searching is a Paid Member then include the residenail address field as well
            string showResidentialAddress = string.Empty; //this includes the phone numbers and email address also
            if (withAddress)
            {
                showResidentialAddress = ", ResidentialAddress'Address', ContactDetail.Telephone1'Phone 1', ContactDetail.Telephone2'Phone 2', ContactDetail.EmailUser'Email Address1',biodata.Email'Email Address2',Biodata.Biodata_Email2'Email Address3',  ContactDetail.mobile'Mobile' ";
            }

            string query = "select  rowidbiodata'ID', (convert(varchar, FirstName))'Name', Gender, CityofResidence'City', Caste, ('http://saatphere.peopleonegroup.com//BiodataImages//' + substring(biodata.Photograph,1,1) + '-Images//'+ convert(varchar,Photograph))'Photograph', EducationStatus'Education Status', Occupation, Religion, Country, Age, contactdetail.ContactPersonName'Contact Person Name'" + showResidentialAddress + " from biodata inner join ContactDetail on  biodata.rowidbiodata = ContactDetail.ContactDetailRowID where rowidbiodata in (" + txtProfileID.Text + ") and status <> 'Dactive'";
            
           
            new Tools.FrmProfileMatchResults(query, Convert.ToInt32(lblProfileID.Text)).ShowDialog();

        }

        private void linkViewOwnBiodata_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //SaatphereWIN.DAL.DataTypes.SearchResults searchResults = new SaatphereWIN.DAL.DataTypes.SearchResults();
            new FrmProfileDetails(null, Convert.ToInt32(lblProfileID.Text), null).ShowDialog();
        }
    }
}
