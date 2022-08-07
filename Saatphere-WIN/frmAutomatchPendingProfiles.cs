using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Saatphere_WIN
{
    public partial class frmAutomatchPendingProfiles : Form
    {
        string profileid = string.Empty;
        int biodataCID = 0;
        DataSet dstOutput = new DataSet();
        string profileContainerTemplate = string.Empty;
        string profileContainerFilled = string.Empty;
        string saatphereTemplate = string.Empty;
        SaatphereWIN.DAL.DataTypes.PreferredPartner preferredPartnerDetails = new SaatphereWIN.DAL.DataTypes.PreferredPartner();
        bool isPaidMember = false;

        int selectedBiodataId;

        public frmAutomatchPendingProfiles(string ProfileID)
        {
            InitializeComponent();
            profileid = ProfileID;

            lblProfileID.Text = profileid;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAutomatchPendingProfiles_Load(object sender, EventArgs e)
        {

        }

        private void btnAutomatch_Click(object sender, EventArgs e)
        {
            Automatch(lblProfileID.Text);
            //btnSend.Enabled = false;
        }

        /// <summary>
        /// Create the profile sent log for reminders
        /// </summary>
        /// <param name="ProfileCollection"></param>
        private void CreateProfileSentLog(DataSet ProfileCollection)
        {
            DataSet dstOutput = new DataSet();
            dstOutput = ProfileCollection;

            for (int i = 0; i <= dstOutput.Tables[0].Rows.Count - 1; i++)
            {
                //checking if same (own) profile is choice id(Some time clients wants to see her/his profiles), then shld not counted in remainder
                if ((dstOutput.Tables[0].Rows[i]["id"].ToString() != biodataCID.ToString()))
                {
                    //checking if choice id is already in FavoriteCustomer or not, if yes then it shld not counted in remainder
                    {
                        try
                        {
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error - Method - InsertProfileSentStatus - Profile Id : " + biodataCID);
                        }
                    }
                }
            } //Prepare and save the profile sent log in database for Reminder
        }

        private void Automatch(string BiodataID)
        {
            #region AutoMatch starts
            //btnSend.Enabled = false;

            //Initialize the variables and collect the values
            //---------------------------------------------------------------------------------------------------------------------------
            biodataCID = Convert.ToInt32(BiodataID.Trim());
            int biodataCount = Convert.ToInt32(txtBiodataCount.Text);

            //DataSet dstOutput = new DataSet();
            //string profileContainerTemplate = string.Empty;
            //string profileContainerFilled = string.Empty;
            //string saatphereTemplate = string.Empty;
            //bool sendProfilestoUnpaidonly = false;

            //sendProfilestoUnpaidonly = chkProfileSendOption.CheckState == CheckState.Checked ? true : false; //NA

            //No profiles to the deactivated customers
            //---------------------------------------------------------------------------------------------------------------------------                      
            if (new SaatphereWIN.DAL.User.ClsSelect().GetProfileStatus(biodataCID) == SaatphereWIN.DAL.User.ClsSelect.ProfileStatus.Dactive)
            {
                MessageBox.Show("Deactivated profile. Not able to send profiles.\nPlease contact administrator for more", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSend.Enabled = true;
                return;
            }
            //---------------------------------------------------------------------------------------------------------------------------                      

            //---------------------------------------------------------------------------------------------------------------------------                      
            //Fetch the Customer's Preferred Partner Details, provide message if not found.
            //---------------------------------------------------------------------------------------------------------------------------
            //SaatphereWIN.DAL.DataTypes.PreferredPartner preferredPartnerDetails = new SaatphereWIN.DAL.DataTypes.PreferredPartner();

            if (preferredPartnerDetails.PreferredPartnerBiodataCid == 0) //means prefered partner details not found, add then default values then
            {
                #region add the details with the default values if not preferred partner details found
                SaatphereWIN.DAL.DataTypes.PreferredPartner ppd = new SaatphereWIN.DAL.DataTypes.PreferredPartner();
                ppd.PreferredPartnerActive = true;

                DateTime userDOB = new SaatphereWIN.DAL.User.ClsSelect().GetDobFromBiodataId(biodataCID);
                int age = DateTime.Now.Year - userDOB.Year;

                string userGender = new SaatphereWIN.DAL.User.ClsSelect().GetGenderfromActualRowId(biodataCID);
                if (userGender == "Male") //if searching for male then the female age should be minimum less than 4 years
                {
                    //set the age as per the gender, if the user is female then from age = current age and to age = +4, and if male then reverse
                    //preferredPartnerDetails
                    ppd.PreferredPartnerAgeFrom = (age - 4).ToString();
                    ppd.PreferredPartnerAgeTo = age.ToString();
                }
                else if (userGender == "Female") //if searching for a female then the male age should not be maximum to 4 years
                {
                    //set the age as per the gender, if the user is female then from age = current age and to age = +4, and if male then reverse
                    ppd.PreferredPartnerAgeFrom = age.ToString();
                    ppd.PreferredPartnerAgeTo = (age + 4).ToString();
                }

                ppd.PreferredPartnerBiodataCid = biodataCID;
                ppd.PreferredPartnerCaste = new SaatphereWIN.DAL.User.ClsSelect().GetCasteFromBiodataId(biodataCID);

                ppd.PreferredPartnerDateCreated = DateTime.Now;
                ppd.PreferredPartnerMaritalStatus = new SaatphereWIN.DAL.User.ClsSelect().GetMaritalStatusFromBiodataID(biodataCID);

                new SaatphereWIN.DAL.User.ClsInsert().InsertPreferredPartnerDetails(ppd); //save the details
                #endregion

                Automatch(BiodataID); //call the automatch again to process the same request again

                btnSend.Enabled = true;
            }
            else
            {
                //Verify preferred partner details if the caste, mothertongue, religion or maritalstatus fields are empty. 
                //This invloves re calculation for the age from and age to feields as well
                //--------------------------------------------------------------------------------------------------------------------------------
                bool ppdUpdateFlag = false;
                SaatphereWIN.DAL.DataTypes.PreferredPartner ppd = new SaatphereWIN.DAL.DataTypes.PreferredPartner();
                ppd.PreferredPartnerActive = true;
                ppd.PreferredPartnerBiodataCid = biodataCID;
                ppd.PreferredPartnerDateCreated = DateTime.Now;

                //check caste, maritalstats, mothertongue and religion. if anyone of them is empty then update all the four fields.
                if (preferredPartnerDetails.PreferredPartnerCaste.Length < 1 || preferredPartnerDetails.PreferredPartnerMaritalStatus.Length < 1
                    || preferredPartnerDetails.PreferredPartnerMotherTongue.Length < 1 || preferredPartnerDetails.PreferredPartnerReligion.Length < 1)
                {

                    //update the age from and age to on the basis of date of birth in the biodata table
                    DateTime userDOB = new SaatphereWIN.DAL.User.ClsSelect().GetDobFromBiodataId(biodataCID);
                    int age = DateTime.Now.Year - userDOB.Year;

                    string userGender = new SaatphereWIN.DAL.User.ClsSelect().GetGenderfromActualRowId(biodataCID);
                    if (userGender == "Male")
                    {
                        //set the age as per the gender, if the user is female then from age = current age and to age = +4, and if male then reverse
                        //preferredPartnerDetails
                        ppd.PreferredPartnerAgeFrom = (age - 4).ToString();
                        ppd.PreferredPartnerAgeTo = age.ToString();
                        ppdUpdateFlag = true;
                    }
                    else if (userGender == "Female")
                    {
                        //set the age as per the gender, if the user is female then from age = current age and to age = +4, and if male then reverse
                        ppd.PreferredPartnerAgeFrom = age.ToString();
                        ppd.PreferredPartnerAgeTo = (age + 4).ToString();
                        ppdUpdateFlag = true;
                    }

                    ppdUpdateFlag = true;
                }

                //---------------------------------------------------------------------------------------------------------------------------------
                //fetch the preferred partner details again to get the updated values, if any
                //---------------------------------------------------------------------------------------------------------------------------------
                if (ppdUpdateFlag)
                {
                    preferredPartnerDetails = new SaatphereWIN.DAL.Membership.ClsSelect().GetPreferredPartnerDetailsfromBiodataCID(biodataCID);
                }
                //---------------------------------------------------------------------------------------------------------------------------------

                //Collect the values
                isPaidMember = new SaatphereWIN.DAL.Membership.ClsSelect().IsPaidMember(biodataCID);

                //3-december-2017. There is a check for the "Send profiles to unpaid members only", that assure whether to send the profiles to unpaid members only,
                //that will send the profiles without screening and unpaid members can receive the profiles of married people, or profiles with incomplete information
                //so there is a check for sendProfilestoUnpaidonly
                if (isPaidMember)
                {
                        {
                            MessageBox.Show("Membership has expired for this proile. Sending profiles without address");
                            dstOutput = new SaatphereWIN.DAL.User.ClsSelect().BindDataAdvanceSearchWithoutAddress(preferredPartnerDetails, biodataCount, BiodataID);
                            profileContainerTemplate = SaatphereWIN.DAL.HTML.HtmlStrings.ProfileContainerWithOutAddress; //Original Template
                        }
                        else
                        {
                            MessageBox.Show("Membership is live for this proile. Sending profiles with address");
                            try
                            {
                                dstOutput = new SaatphereWIN.DAL.User.ClsSelect().BindDataAdvanceSearchWithAddress(preferredPartnerDetails, biodataCount, BiodataID);
                                profileContainerTemplate = SaatphereWIN.DAL.HTML.HtmlStrings.ProfileContainerWithAddress; //Original Template
                            }
                            catch (Exception ex)
                            {
                            //Skip the record having any issue
                            throw ex;
                            }
                        }
                }

                if (dstOutput.Tables.Count > 0)
                {
                    dgrdResults.DataSource = dstOutput.Tables[0];

                    dgrdResults.Columns[0].Visible = false;
                    dgrdResults.Columns[2].Visible = false;
                    dgrdResults.Columns[3].Visible = false;
                    dgrdResults.Columns[4].Visible = false;
                    dgrdResults.Columns[5].Visible = false;
                    dgrdResults.Columns[6].Visible = false;
                    dgrdResults.Columns[7].Visible = false;
                    dgrdResults.Columns[8].Visible = false;
                    dgrdResults.Columns[9].Visible = false;
                    dgrdResults.Columns[10].Visible = false;
                    dgrdResults.Columns[11].Visible = false;
                    dgrdResults.Columns[12].Visible = false;
                    dgrdResults.Columns[13].Visible = false;
                    dgrdResults.Columns[14].Visible = false;
                    dgrdResults.Columns[15].Visible = false;
                    dgrdResults.Columns[16].Visible = false;
                    dgrdResults.Columns[17].Visible = false;
                    dgrdResults.Columns[18].Visible = false;
                    dgrdResults.Columns[19].Visible = false;
                  
                    dgrdResults.Columns[1].HeaderText = "Matched Profiles";


                    //for (int a = 0; a <= dstOutput.Tables[0].Rows.Count - 1; a++)
                    //{
                    //    lstResults.Items.Add(dstOutput.Tables[0].Rows[a]["id"].ToString());                        
                    //}
                }

                //if (dstOutput.Tables.Count > 0)
                //{
                //    if (dstOutput.Tables[0].Rows.Count > 0)
                //    {
                //        profileContainerFilled = string.Empty; //The one with the replaced values

                    //        for (int i = 0; i <= dstOutput.Tables[0].Rows.Count - 1; i++)
                    //        {
                    //            profileContainerFilled = profileContainerFilled + profileContainerTemplate;
                    //            profileContainerFilled = profileContainerFilled.Replace("{ImageSource}", dstOutput.Tables[0].Rows[i]["photograph"].ToString());
                    //            profileContainerFilled = profileContainerFilled.Replace("{Name}", dstOutput.Tables[0].Rows[i]["name"].ToString());
                    //            profileContainerFilled = profileContainerFilled.Replace("{City}", dstOutput.Tables[0].Rows[i]["city"].ToString());
                    //            profileContainerFilled = profileContainerFilled.Replace("{Caste}", dstOutput.Tables[0].Rows[i]["caste"].ToString());
                    //            profileContainerFilled = profileContainerFilled.Replace("{Education}", dstOutput.Tables[0].Rows[i]["educationstatus"].ToString());
                    //            profileContainerFilled = profileContainerFilled.Replace("{Occupation}", dstOutput.Tables[0].Rows[i]["occupation"].ToString());
                    //            profileContainerFilled = profileContainerFilled.Replace("{Religion}", dstOutput.Tables[0].Rows[i]["religion"].ToString());
                    //            profileContainerFilled = profileContainerFilled.Replace("{Country}", dstOutput.Tables[0].Rows[i]["country"].ToString());
                    //            profileContainerFilled = profileContainerFilled.Replace("{Age}", dstOutput.Tables[0].Rows[i]["age"].ToString());

                    //            //The following fields are not coming in the profile without address , hence it is covered under try...catch block
                    //            if (isPaidMember)
                    //            {
                    //                try
                    //                {
                    //                    profileContainerFilled = profileContainerFilled.Replace("{Height}", dstOutput.Tables[0].Rows[i]["height"].ToString());
                    //                    profileContainerFilled = profileContainerFilled.Replace("{Email}", dstOutput.Tables[0].Rows[i]["email"].ToString());
                    //                    profileContainerFilled = profileContainerFilled.Replace("{Email2}", dstOutput.Tables[0].Rows[i]["biodata_email2"].ToString());
                    //                    profileContainerFilled = profileContainerFilled.Replace("{Residence}", dstOutput.Tables[0].Rows[i]["residenceno"].ToString());
                    //                    profileContainerFilled = profileContainerFilled.Replace("{Mobile}", dstOutput.Tables[0].Rows[i]["mobile"].ToString());
                    //                    profileContainerFilled = profileContainerFilled.Replace("{Address}", dstOutput.Tables[0].Rows[i]["residentialaddress"].ToString());
                    //                    profileContainerFilled = profileContainerFilled.Replace("{MembershipType}", dstOutput.Tables[0].Rows[i]["membershiptype"].ToString());
                    //                    profileContainerFilled = profileContainerFilled.Replace("{ContactPerspn}", dstOutput.Tables[0].Rows[i]["contactpersonname"].ToString());

                    //                }
                    //                catch (Exception)
                    //                {
                    //                    //throw;
                    //                }
                    //            }
                    //        }

                    //        //Pick the Template master page and assign the profile and user related details in it
                    //        //--------------------------------------------------------------------------------------------------------------------------------------------------
                    //        saatphereTemplate = System.IO.File.ReadAllText("Templates//ProfileMatch//Template1//andherioffice.html");

                    //        saatphereTemplate = saatphereTemplate.Replace("$$PROFILES$$", profileContainerFilled);
                    //        saatphereTemplate = saatphereTemplate.Replace("$$USERPROFILE$$", new SaatphereWIN.DAL.User.clsSelect().GetCandidateNameFromBiodataID(biodataCID));
                    //        //--------------------------------------------------------------------------------------------------------------------------------------------------

                    //        //set the address template on the basis of the user login
                    //        //---------------------------------------------------------------------------------------------------------------------------------------
                    //        string currentUser = new SaatphereWIN.DAL.User.clsSelect().GetCandidateFranchiseeName(biodataCID);//  SaatphereWIN.DAL.Global.LoginUser;                        
                    //        if (currentUser == "andherioffice")
                    //        {
                    //            //saatphereTemplate = saatphereTemplate.Replace("$$ContactDetails$$", System.IO.File.ReadAllText("Templates//ProfileMatch//Template1//ContactDetails//andherioffice.htm"));
                    //            saatphereTemplate = saatphereTemplate.Replace("$$OFFICEADDRESS$$", System.IO.File.ReadAllText("Templates//ProfileMatch//Template1//ContactDetails//andherioffice.htm"));
                    //        }
                    //        else if (currentUser == "mumbaioffice")
                    //        {
                    //            //saatphereTemplate = saatphereTemplate.Replace("$$ContactDetails$$", System.IO.File.ReadAllText("Templates//ProfileMatch//Template1//ContactDetails//borivalioffice.htm"));
                    //            saatphereTemplate = saatphereTemplate.Replace("$$OFFICEADDRESS$$", System.IO.File.ReadAllText("Templates//ProfileMatch//Template1//ContactDetails//borivalioffice.htm"));
                    //        }
                    //        else if (currentUser == "indoreoffice")
                    //        {
                    //            //saatphereTemplate = saatphereTemplate.Replace("$$ContactDetails$$", System.IO.File.ReadAllText("Templates//ProfileMatch//Template1//ContactDetails//indoreoffice.htm"));
                    //            saatphereTemplate = saatphereTemplate.Replace("$$OFFICEADDRESS$$", System.IO.File.ReadAllText("Templates//ProfileMatch//Template1//ContactDetails//indoreoffice.htm"));
                    //        }
                    //        else if (currentUser == "jaipuroffice")
                    //        {
                    //            //saatphereTemplate = saatphereTemplate.Replace("$$ContactDetails$$", System.IO.File.ReadAllText("Templates//ProfileMatch//Template1//ContactDetails//jaipuroffice.htm"));
                    //            saatphereTemplate = saatphereTemplate.Replace("$$OFFICEADDRESS$$", System.IO.File.ReadAllText("Templates//ProfileMatch//Template1//ContactDetails//jaipuroffice.htm"));
                    //        }
                    //        else if (currentUser == "swargateoffice")
                    //        {
                    //            //saatphereTemplate = saatphereTemplate.Replace("$$ContactDetails$$", System.IO.File.ReadAllText("Templates//ProfileMatch//Template1//ContactDetails//swargateoffice.htm"));
                    //            saatphereTemplate = saatphereTemplate.Replace("$$OFFICEADDRESS$$", System.IO.File.ReadAllText("Templates//ProfileMatch//Template1//ContactDetails//swargateoffice.htm"));
                    //        }
                    //        //---------------------------------------------------------------------------------------------------------------------------------------

                    //        CreateProfileSentLog(dstOutput); //Prepare and save the profile sent log in database for Reminder
                    //    }

                    //    if (dstOutput.Tables[0].Rows.Count > 0)
                    //    {
                    //        string gridviewEmailString = profileContainerFilled;
                    //        //string toUser = txtReceiver.Text;
                    //        string receiver = string.Empty;
                    //        string receiver2 = string.Empty;

                    //        receiver = new SaatphereWIN.DAL.User.clsSelect().GetEmailFromBiodataId(biodataCID);
                    //        receiver2 = new SaatphereWIN.DAL.User.clsSelect().GetEmail2FromBiodataId(biodataCID);

                    //        if (new SaatphereWIN.DAL.User.clsSelect().GetEmailUnsubscribeStatus(biodataCID) != true)
                    //        {
                    //            //Create a log entry

                    //            //clsInsert insert = new clsInsert();
                    //            int receiverID = biodataCID;
                    //            string recieverEmail = receiver;
                    //            string recieverEmail2 = receiver2;
                    //            DateTime profileSendDate = DateTime.Now;
                    //            int sentProfileCID = 0;

                    //            if (dstOutput.Tables[0].Rows.Count < 1)
                    //            {
                    //                MessageBox.Show("There is an Error in Mail Sending.\nPlease try again to send the Email./nIf error persists contact to Administrator.");
                    //                btnSend.Enabled = true;
                    //            }
                    //            else
                    //            {
                    //                for (int i = 0; i <= dstOutput.Tables[0].Rows.Count - 1; i++)
                    //                {
                    //                    //checking if same (own) profile is choice id(Some time clients wants to see her/his profiles), then shld not counted in remainder
                    //                    if (Convert.ToInt32(dstOutput.Tables[0].Rows[i]["id"].ToString().Replace("#", "")) != biodataCID)
                    //                    {
                    //                        new SaatphereWIN.DAL.Membership.clsInsert().InsertProfileMatchLog(receiverID, recieverEmail, recieverEmail2, profileSendDate, Convert.ToInt32(dstOutput.Tables[0].Rows[i]["id"].ToString().Replace("#", "")));
                    //                    }
                    //                }
                    //            }

                    //            string emailFrom = SaatphereWIN.DAL.Global.BiodataSendEmailFrom;

                    //            try
                    //            {
                    //                //send mail to both the ids of the user
                    //                new SaatphereWIN.DAL.clsCommon().SendMailfromSaatphere(emailFrom, "Saatphere: Profile Match", receiver, preferredPartnerDetails.PreferredPartner_BiodataCID.ToString(), "Matched Profiles", saatphereTemplate, "");
                    //                new SaatphereWIN.DAL.clsCommon().SendMailfromSaatphere(emailFrom, "Saatphere: Profile Match", receiver2, preferredPartnerDetails.PreferredPartner_BiodataCID.ToString(), "Matched Profiles", saatphereTemplate, "");

                    //                new SaatphereWIN.DAL.clsCommon().SendMailfromSaatphere(emailFrom, "Saatphere: Profile Match - CC", "saatphereprofilematch@gmail.com", preferredPartnerDetails.PreferredPartner_BiodataCID.ToString(), "Matched Profiles", saatphereTemplate, "");
                    //            }
                    //            catch (Exception)
                    //            {

                    //            }


                    //        }
                    //        else
                    //        {
                    //            MessageBox.Show("Matched profiles processed has finished with Errors..");
                    //            btnSend.Enabled = true;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        //MessageBox.Show("Matched profiles sent FAILURE..\nProfiles list is Empty.");
                    //        btnSend.Enabled = true;
                    //    }
                    //}
                    //else
                    //{
                    //    //MessageBox.Show("Matched profiles sent FAILURE..\nProfiles list is Empty.");
                    //    btnSend.Enabled = true;
                    //}
            }
            #endregion
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            biodataCID = Convert.ToInt32(lblProfileID.Text.Trim());
            string emailSubject = "Profiles for you ";



            if (dstOutput.Tables.Count > 0)
            {
                if (dstOutput.Tables[0].Rows.Count > 0)
                {
                    profileContainerFilled = string.Empty; //The one with the replaced values

                    for (int i = 0; i <= dstOutput.Tables[0].Rows.Count - 1; i++)
                    {
                        profileContainerFilled = profileContainerFilled + profileContainerTemplate;
                        profileContainerFilled = profileContainerFilled.Replace("{ImageSource}", dstOutput.Tables[0].Rows[i]["photograph"].ToString());
                        profileContainerFilled = profileContainerFilled.Replace("{Name}", dstOutput.Tables[0].Rows[i]["name"].ToString());
                        profileContainerFilled = profileContainerFilled.Replace("{City}", dstOutput.Tables[0].Rows[i]["city"].ToString());
                        profileContainerFilled = profileContainerFilled.Replace("{Caste}", dstOutput.Tables[0].Rows[i]["caste"].ToString());
                        profileContainerFilled = profileContainerFilled.Replace("{Education}", dstOutput.Tables[0].Rows[i]["educationstatus"].ToString());
                        profileContainerFilled = profileContainerFilled.Replace("{Occupation}", dstOutput.Tables[0].Rows[i]["occupation"].ToString());
                        profileContainerFilled = profileContainerFilled.Replace("{Religion}", dstOutput.Tables[0].Rows[i]["religion"].ToString());
                        profileContainerFilled = profileContainerFilled.Replace("{Country}", dstOutput.Tables[0].Rows[i]["country"].ToString());
                        profileContainerFilled = profileContainerFilled.Replace("{Age}", dstOutput.Tables[0].Rows[i]["age"].ToString());

                        //The following fields are not coming in the profile without address , hence it is covered under try...catch block
                        if (isPaidMember)
                        {
                            try
                            {
                                profileContainerFilled = profileContainerFilled.Replace("{Height}", dstOutput.Tables[0].Rows[i]["height"].ToString());
                                profileContainerFilled = profileContainerFilled.Replace("{Email}", dstOutput.Tables[0].Rows[i]["email"].ToString());
                                profileContainerFilled = profileContainerFilled.Replace("{Email2}", dstOutput.Tables[0].Rows[i]["biodata_email2"].ToString());
                                profileContainerFilled = profileContainerFilled.Replace("{Residence}", dstOutput.Tables[0].Rows[i]["residenceno"].ToString());
                                profileContainerFilled = profileContainerFilled.Replace("{Mobile}", dstOutput.Tables[0].Rows[i]["mobile"].ToString());
                                profileContainerFilled = profileContainerFilled.Replace("{Address}", dstOutput.Tables[0].Rows[i]["residentialaddress"].ToString());
                                profileContainerFilled = profileContainerFilled.Replace("{MembershipType}", dstOutput.Tables[0].Rows[i]["membershiptype"].ToString());
                                profileContainerFilled = profileContainerFilled.Replace("{ContactPerspn}", dstOutput.Tables[0].Rows[i]["contactpersonname"].ToString());

                            }
                            catch (Exception)
                            {
                                //throw;
                            }
                        }
                    }

                    //Pick the Template master page and assign the profile and user related details in it
                    //--------------------------------------------------------------------------------------------------------------------------------------------------
                    saatphereTemplate = System.IO.File.ReadAllText("Templates//ProfileMatch//Template1//andherioffice.html");

                    saatphereTemplate = saatphereTemplate.Replace("$$PROFILES$$", profileContainerFilled);
                    saatphereTemplate = saatphereTemplate.Replace("$$USERPROFILE$$", new SaatphereWIN.DAL.User.ClsSelect().GetCandidateNameFromBiodataId(biodataCID));
                    //--------------------------------------------------------------------------------------------------------------------------------------------------

                    //set the address template on the basis of the user login
                    //---------------------------------------------------------------------------------------------------------------------------------------
                    string currentUser = new SaatphereWIN.DAL.User.ClsSelect().GetCandidateFranchiseeName(biodataCID);//  SaatphereWIN.DAL.Global.LoginUser;                        
                    if (currentUser == "andherioffice")
                    {
                        //saatphereTemplate = saatphereTemplate.Replace("$$ContactDetails$$", System.IO.File.ReadAllText("Templates//ProfileMatch//Template1//ContactDetails//andherioffice.htm"));
                        saatphereTemplate = saatphereTemplate.Replace("$$OFFICEADDRESS$$", System.IO.File.ReadAllText("Templates//ProfileMatch//Template1//ContactDetails//andherioffice.htm"));
                    }
                    else if (currentUser == "mumbaioffice")
                    {
                        //saatphereTemplate = saatphereTemplate.Replace("$$ContactDetails$$", System.IO.File.ReadAllText("Templates//ProfileMatch//Template1//ContactDetails//borivalioffice.htm"));
                        saatphereTemplate = saatphereTemplate.Replace("$$OFFICEADDRESS$$", System.IO.File.ReadAllText("Templates//ProfileMatch//Template1//ContactDetails//borivalioffice.htm"));
                    }
                    else if (currentUser == "indoreoffice")
                    {
                        //saatphereTemplate = saatphereTemplate.Replace("$$ContactDetails$$", System.IO.File.ReadAllText("Templates//ProfileMatch//Template1//ContactDetails//indoreoffice.htm"));
                        saatphereTemplate = saatphereTemplate.Replace("$$OFFICEADDRESS$$", System.IO.File.ReadAllText("Templates//ProfileMatch//Template1//ContactDetails//indoreoffice.htm"));
                    }
                    else if (currentUser == "jaipuroffice")
                    {
                        //saatphereTemplate = saatphereTemplate.Replace("$$ContactDetails$$", System.IO.File.ReadAllText("Templates//ProfileMatch//Template1//ContactDetails//jaipuroffice.htm"));
                        saatphereTemplate = saatphereTemplate.Replace("$$OFFICEADDRESS$$", System.IO.File.ReadAllText("Templates//ProfileMatch//Template1//ContactDetails//jaipuroffice.htm"));
                    }
                    else if (currentUser == "swargateoffice")
                    {
                        //saatphereTemplate = saatphereTemplate.Replace("$$ContactDetails$$", System.IO.File.ReadAllText("Templates//ProfileMatch//Template1//ContactDetails//swargateoffice.htm"));
                        saatphereTemplate = saatphereTemplate.Replace("$$OFFICEADDRESS$$", System.IO.File.ReadAllText("Templates//ProfileMatch//Template1//ContactDetails//swargateoffice.htm"));
                    }
                    //---------------------------------------------------------------------------------------------------------------------------------------

                    CreateProfileSentLog(dstOutput); //Prepare and save the profile sent log in database for Reminder
                }

                if (dstOutput.Tables[0].Rows.Count > 0)
                {
                    string gridviewEmailString = profileContainerFilled;
                    //string toUser = txtReceiver.Text;
                    string receiver = string.Empty;
                    string receiver2 = string.Empty;

                    receiver = new SaatphereWIN.DAL.User.ClsSelect().GetEmailFromBiodataId(biodataCID);
                    receiver2 = new SaatphereWIN.DAL.User.ClsSelect().GetEmail2FromBiodataId(biodataCID);

                    if (new SaatphereWIN.DAL.User.ClsSelect().GetEmailUnsubscribeStatus(biodataCID) != true)
                    {
                        //Create a log entry

                        //clsInsert insert = new clsInsert();
                        int receiverID = biodataCID;
                        string recieverEmail = receiver;
                        string recieverEmail2 = receiver2;
                        DateTime profileSendDate = DateTime.Now;
                        int sentProfileCID = 0;

                        if (dstOutput.Tables[0].Rows.Count < 1)
                        {
                            MessageBox.Show("There is an Error in Mail Sending.\nPlease try again to send the Email./nIf error persists contact to Administrator.");
                            btnSend.Enabled = true;
                        }
                        else
                        {
                            for (int i = 0; i <= dstOutput.Tables[0].Rows.Count - 1; i++)
                            {
                                //checking if same (own) profile is choice id(Some time clients wants to see her/his profiles), then shld not counted in remainder
                                if (Convert.ToInt32(dstOutput.Tables[0].Rows[i]["id"].ToString().Replace("#", "")) != biodataCID)
                                {
                                    new SaatphereWIN.DAL.Membership.ClsInsert().InsertProfileMatchLog(receiverID, recieverEmail, recieverEmail2, profileSendDate, Convert.ToInt32(dstOutput.Tables[0].Rows[i]["id"].ToString().Replace("#", "")));
                                }
                            }
                        }

                        string emailFrom = SaatphereWIN.DAL.Global.BiodataSendEmailFrom;

                        try
                        {
                            //send mail to both the ids of the user
                            new SaatphereWIN.DAL.ClsCommon().SendMailfromSaatphere(emailFrom, "Saatphere: Profile Match", receiver, preferredPartnerDetails.PreferredPartnerBiodataCid.ToString(), emailSubject, saatphereTemplate, "");
                            new SaatphereWIN.DAL.ClsCommon().SendMailfromSaatphere(emailFrom, "Saatphere: Profile Match", receiver2, preferredPartnerDetails.PreferredPartnerBiodataCid.ToString(), emailSubject, saatphereTemplate, "");

                            new SaatphereWIN.DAL.ClsCommon().SendMailfromSaatphere(emailFrom, "Saatphere: Profile Match - CC", "saatphereprofilematch@gmail.com", preferredPartnerDetails.PreferredPartnerBiodataCid.ToString(), emailSubject, saatphereTemplate, "");
                        }
                        catch (Exception)
                        {

                        }
                        MessageBox.Show("Matched profiles processed has finished.");
                        new SaatphereWIN.DAL.Automatch.ClsDelete().DeleteIgnoredPaidMember(biodataCID);
                    }
                    else
                    {
                        MessageBox.Show("Matched profiles processed has finished with Errors..");
                        btnSend.Enabled = true;
                    }
                }
                else
                {
                    //MessageBox.Show("Matched profiles sent FAILURE..\nProfiles list is Empty.");
                    btnSend.Enabled = true;
                }
            }
            else
            {
                //MessageBox.Show("Matched profiles sent FAILURE..\nProfiles list is Empty.");
                btnSend.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dstOutput.Tables[0].Rows.RemoveAt(dgrdResults.CurrentRow.Index);
            dgrdResults.Rows.RemoveAt(dgrdResults.CurrentRow.Index);
        }

        private void openProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void dgrdPendingProfiles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgrdPendingProfiles_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
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

                }
                catch (Exception)
                {

                }
            }
        }

        private void dgrdPendingProfiles_MouseClick(object sender, MouseEventArgs e)
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
}
