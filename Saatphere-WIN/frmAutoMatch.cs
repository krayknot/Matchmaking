using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Saatphere_WIN
{
    public partial class frmAutoMatch : Form
    {
        int biodataCID = 0;
        public frmAutoMatch()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Throws the message to the Listbox
        /// </summary>
        /// <param name="MessagetoThrow"></param>
        private void ThrowStatus(string MessagetoThrow)
        {
            lstSentLog.Items.Add(MessagetoThrow);
            lstSentLog.SelectedIndex = lstSentLog.Items.Count - 1;
            lstSentLog.Refresh();
        }

        private bool ValidationStatus_BiodataRange(string fromId, string toId)
        {
            bool flag = false;

            if (txtFrom.Text.Length < 1 || txtTo.Text.Length < 1)
            {
                MessageBox.Show("Biodata from and to values are mandatory.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFrom.BackColor = Color.LightSkyBlue;
                txtTo.BackColor = Color.LightSkyBlue;
                flag = true;
            }

            if (!new SaatphereWIN.DAL.ClsCommon().IsNumeric(fromId))
            {
                MessageBox.Show("Biodata From value should be numeric.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFrom.BackColor = Color.LightSkyBlue;
                flag = true;
            }

            if (!new SaatphereWIN.DAL.ClsCommon().IsNumeric(toId))
            {
                MessageBox.Show("Biodata To value should be numeric.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTo.BackColor = Color.LightSkyBlue;
                flag = true;
            }

            //to biodata id should be greater than From biodata id
            if (Convert.ToInt32(toId) < Convert.ToInt32(fromId))
            {
                MessageBox.Show("Biodata Id in To field should be greater than From.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTo.BackColor = Color.LightSkyBlue;
                flag = true;
            }
            return flag;
        }


        private void btnSend_Click(object sender, EventArgs e)
        {
            //Pre validations
            bool flag = false;
            string fromId = txtFrom.Text.Trim();
            string toId = txtTo.Text.Trim();

            //THIS PROCESS REQUIRES MAIL SENDING FEATURE
            //checks whether the mail informatino is there or not
            //check the default mail sending setting
            //read mail sending via google or peopleonegroup
            Microsoft.Win32.RegistryKey keyEmailPreference = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("EMAILPREFERENCE");
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("PROFILESENDINGEMAIL");

            if (keyEmailPreference.GetValue("EmailSender") == null || key.GetValue("EmailAddress") == null || key.GetValue("Password") == null)
            {
                MessageBox.Show("Mail sender domain not selected. Please check Options", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                flag = true;
            }


            if (radioBiodata.Checked)
            {
                flag = ValidationStatus_BiodataRange(fromId, toId); //validation called
                if (flag == false)
                {
                    for(int i = Convert.ToInt32(fromId); i<= Convert.ToInt32(toId); i++)
                    {
                        //Ignore the profile if it is in deactive state
                        {
                            ThrowStatus(i.ToString() +  " profile is Deactive. Please contact Administrator.");
                        }
                        else
                        {
                            Automatch(i.ToString());
                        }                        
                    }
                    ThrowStatus("Automatch process has finished");
                    MessageBox.Show("Automatch process has finished.\nYou shall receive a Carbon Copy of the same.");
                    btnSend.Enabled = true;
                }
            }
            else if (radioComma.Checked)
            {
                if (txtCustBiodataID.Text.Length < 1)
                {
                    MessageBox.Show("Customer Biodata is mandatory.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    flag = true;
                }

                if (txtCustBiodataID.Text.Length < 1)
                {
                    MessageBox.Show("Customer Biodata is mandatory.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    flag = true;
                }

                //Automatch for multiple ids, Comma Separated ids
                if (flag == false)
                {
                    if (txtCustBiodataID.Text.Contains(","))
                    {
                        string[] strBiodata = txtCustBiodataID.Text.Split(',');

                        for (int i = 0; i <= strBiodata.GetUpperBound(0); i++)
                        {
                            {
                                ThrowStatus(i.ToString() + " profile is Deactive. Please contact Administrator.");
                            }
                            else
                            {
                                Automatch(strBiodata[i]);
                            }
                        }
                        ThrowStatus("Automatch process has finished");
                        MessageBox.Show("Automatch process has finished.\nYou shall receive a Carbon Copy of the same.");
                        btnSend.Enabled = true;
                    }
                    else
                    {
                        {
                            ThrowStatus(txtCustBiodataID.Text.Trim() + " profile is Deactive. Please contact Administrator.");
                        }
                        else
                        {
                            Automatch(txtCustBiodataID.Text.Trim());
                        }
                    }

                    MessageBox.Show("Process Completed. Please check the log for more information.", "Automatch - Informationm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }                 
        }

        private void Automatch(string BiodataID)
        {
            #region AutoMatch starts

            //IF the customer id has not Email address mentioned in his profile then qit this id and 
            //continue with the next customer. Check both the email addresses
            //-----------------------------------------------------------------------------------------------
            var email1 = new SaatphereWIN.DAL.User.ClsSelect().GetEmailFromBiodataId(Convert.ToInt32(BiodataID));
            var email2 = new SaatphereWIN.DAL.User.ClsSelect().GetEmail2FromBiodataId(Convert.ToInt32(BiodataID));

            if (email1.Length < 1 && email2.Length < 1)
                return;
            //-----------------------------------------------------------------------------------------------


            btnSend.Enabled = false;
            string emailSubject = "Profiles for you ";

            ThrowStatus("======================================================");
            ThrowStatus("Biodata Id: " + BiodataID.ToString());
            ThrowStatus("Process started at: " + DateTime.Now.ToString());

            //Initialize the variables and collect the values
            //---------------------------------------------------------------------------------------------------------------------------
            biodataCID = Convert.ToInt32(BiodataID.Trim());
            int biodataCount = Convert.ToInt32(txtBiodataCount.Text);

            DataSet dstOutput = new DataSet();
            string profileContainerTemplate = string.Empty;
            string profileContainerFilled = string.Empty;
            string saatphereTemplate = string.Empty;
            bool sendProfilestoUnpaidonly = false;

            sendProfilestoUnpaidonly = chkProfileSendOption.CheckState == CheckState.Checked ? true : false;

            //No profiles to the deactivated customers
            //---------------------------------------------------------------------------------------------------------------------------                      
            if (new SaatphereWIN.DAL.User.ClsSelect().GetProfileStatus(biodataCID) == SaatphereWIN.DAL.User.ClsSelect.ProfileStatus.Dactive)
            {
                ThrowStatus("Profile is Deactive. Please contact Administrator.");
                MessageBox.Show("Deactivated profile. Not able to send profiles.\nPlease contact administrator for more", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSend.Enabled = true;
                return;
            }
            //---------------------------------------------------------------------------------------------------------------------------                      

            //---------------------------------------------------------------------------------------------------------------------------                      
            //Fetch the Customer's Preferred Partner Details, provide message if not found.
            //---------------------------------------------------------------------------------------------------------------------------
            ThrowStatus("Fetching Preferred partner details.");

            if (preferredPartnerDetails.PreferredPartnerBiodataCid == 0) //means prefered partner details not found, add then default values then
            {
                #region add the details with the default values if not preferred partner details found
                SaatphereWIN.DAL.DataTypes.PreferredPartner ppd = new SaatphereWIN.DAL.DataTypes.PreferredPartner();
                ppd.PreferredPartnerActive = true;

                DateTime userDOB = new SaatphereWIN.DAL.User.ClsSelect().GetDobFromBiodataId(biodataCID);
                
                if(userDOB.Date == DateTime.Now.Date) //validtion. if userDob is todays date then the id has error in the dateofbirthfield
                {
                    ThrowStatus("Date Error in Biodata ID:" + biodataCID.ToString());
                    btnSend.Enabled = true;
                }
                else
                {
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

                    ThrowStatus("No Preferred partner details found. Operation Failed");
                    btnSend.Enabled = true;
                }                
            }
            else
            {
                ThrowStatus("Preferred Partner details found. Verifying...");

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
                    ppd.PreferredPartnerCaste = new SaatphereWIN.DAL.User.ClsSelect().GetCasteFromBiodataId(biodataCID);
                    ppd.PreferredPartnerMaritalStatus = new SaatphereWIN.DAL.User.ClsSelect().GetMaritalStatusFromBiodataID(biodataCID);
                    ppd.PreferredPartnerMotherTongue = new SaatphereWIN.DAL.User.ClsSelect().GetMotherTongueFromBiodataId(biodataCID);
                    ppd.PreferredPartnerReligion = new SaatphereWIN.DAL.User.ClsSelect().GetReligionFromBiodataId(biodataCID);

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
                    new SaatphereWIN.DAL.User.ClsUpdate().UpdatePreferredPartnerDetails(ppd); //update the new values in prefered partner details
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
                //bool isPaidMember = new SaatphereWIN.DAL.Membership.ClsSelect().IsPaidMember(biodataCID);

                //hardcoded. System is sending profiles to unpaid members only. As per the discussion with alok
                //paid members are getting handled manually
                bool isPaidMember = false; 

                //3-december-2017. There is a check for the "Send profiles to unpaid members only", that assure whether to send the profiles to unpaid members only,
                //that will send the profiles without screening and unpaid members can receive the profiles of married people, or profiles with incomplete information
                //so there is a check for sendProfilestoUnpaidonly
                if (isPaidMember) //unreachable code. as it has set false temporarily
                {
                    if (!sendProfilestoUnpaidonly)
                    {
                        ThrowStatus("Paid Member = True");
                        if (new SaatphereWIN.DAL.Membership.ClsSelect().IsMembershipExpired(biodataCID))
                        {
                            ThrowStatus("MembershipExpired = True");
                            dstOutput = new SaatphereWIN.DAL.User.ClsSelect().BindDataAdvanceSearchWithoutAddress(preferredPartnerDetails, biodataCount, BiodataID);
                            profileContainerTemplate = SaatphereWIN.DAL.HTML.HtmlStrings.ProfileContainerWithOutAddress; //Original Template
                        }
                        else
                        {
                            ThrowStatus("MembershipExpired = False");
                            try
                            {
                                dstOutput = new SaatphereWIN.DAL.User.ClsSelect().BindDataAdvanceSearchWithAddress(preferredPartnerDetails, biodataCount, BiodataID);
                                profileContainerTemplate = SaatphereWIN.DAL.HTML.HtmlStrings.ProfileContainerWithAddress; //Original Template
                            }
                            catch (Exception ex)
                            {
                                //Skip the record having any issue
                                ThrowStatus("Error in biodata:" + BiodataID.ToString());
                                ThrowStatus("Error:" + ex.Message);
                            }
                        }
                    }
                    else
                    {
                        new SaatphereWIN.DAL.Automatch.ClsInsert().InsertIgnoredPaidMember(biodataCID);
                        ThrowStatus("Send profiles to unpaid member = checked");
                        ThrowStatus("No profile sent to paid member. ID collected");
                    }
                }
                else
                {
                    ThrowStatus("Paid Member = False");
                    dstOutput = new SaatphereWIN.DAL.User.ClsSelect().BindDataAdvanceSearchWithoutAddress(preferredPartnerDetails, biodataCount, BiodataID);
                    profileContainerTemplate = SaatphereWIN.DAL.HTML.HtmlStrings.ProfileContainerWithOutAddress; //Original Template
                }


                if (dstOutput.Tables.Count > 0)
                {
                    if (dstOutput.Tables[0].Rows.Count > 0)
                    {
                        ThrowStatus("Collected profiles. Arranging in Template.");

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
                        ThrowStatus("Profiles has arranged in Template.");
                        

                        CreateProfileSentLog(dstOutput); //Prepare and save the profile sent log in database for Reminder

                        //for (int i = 0; i <= dstOutput.Tables[0].Rows.Count - 1; i++)
                        //{
                        //    //checking if same (own) profile is choice id(Some time clients wants to see her/his profiles), then shld not counted in remainder
                        //    if ((dstOutput.Tables[0].Rows[i]["id"].ToString() != txtCustBiodataID.Text.Trim()))
                        //    {
                        //        //checking if choice id is already in FavoriteCustomer or not, if yes then it shld not counted in remainder
                        //        if (!new SaatphereWIN.DAL.Membership.clsSelect().GetAlreadyTakenDetails(biodataCID, Convert.ToInt32(dstOutput.Tables[0].Rows[i]["id"].ToString().Replace("#", ""))))
                        //        {
                        //            try
                        //            {
                        //                new SaatphereWIN.DAL.Membership.clsInsert().InsertProfileSentLog(Convert.ToInt32(biodataCID), Convert.ToInt32(dstOutput.Tables[0].Rows[i]["id"].ToString().Replace("#", "")));
                        //            }
                        //            catch (Exception)
                        //            {
                        //                ThrowStatus("Error - Method - InsertProfileSentStatus - Profile Id : " + biodataCID);
                        //            }
                        //        }
                        //    }
                        //} 
                    }

                    if (dstOutput.Tables[0].Rows.Count > 0)
                    {
                        string gridviewEmailString = profileContainerFilled;
                        //string toUser = txtReceiver.Text;
                        string toUser = "Admin";

                        string receiver = string.Empty;
                        string receiver2 = string.Empty;

                        receiver = new SaatphereWIN.DAL.User.ClsSelect().GetEmailFromBiodataId(biodataCID);
                        receiver2 = new SaatphereWIN.DAL.User.ClsSelect().GetEmail2FromBiodataId(biodataCID);

                        if (new SaatphereWIN.DAL.User.ClsSelect().GetEmailUnsubscribeStatus(biodataCID) != true)
                        {
                            ThrowStatus("Email Unsubscribe Status = False");

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

                            ThrowStatus("Sending Profiles in Email.");

                            try
                            {
                                //send mail to both the ids of the user
                                if (receiver.Length > 0)
                                {
                                    new SaatphereWIN.DAL.ClsCommon().SendMailfromSaatphere(emailFrom, "Saatphere: Profile Match", receiver, preferredPartnerDetails.PreferredPartnerBiodataCid.ToString(), emailSubject, saatphereTemplate, "");
                                }
                                else
                                {
                                    ThrowStatus("NO EMAIL ADDRESS 1: " + BiodataID);
                                }

                                if (receiver2.Length > 0)
                                {
                                    new SaatphereWIN.DAL.ClsCommon().SendMailfromSaatphere(emailFrom, "Saatphere: Profile Match", receiver2, preferredPartnerDetails.PreferredPartnerBiodataCid.ToString(), emailSubject, saatphereTemplate, "");
                                }
                                else
                                {
                                    //ThrowStatus("NO EMAIL ADDRESS 2: " + BiodataID);
                                }

                                new SaatphereWIN.DAL.ClsCommon().SendMailfromSaatphere(emailFrom, "Saatphere: Profile Match - CC", "saatphereprofilematch@gmail.com", preferredPartnerDetails.PreferredPartnerBiodataCid.ToString(), emailSubject, saatphereTemplate, "");
                            }
                            catch (Exception ex)
                            {
                                ThrowStatus("Error in mail sending - Method - SendMailfromSaatphere - " + emailFrom + " " + ex.StackTrace);
                            }
                        }
                        else
                        {
                            ThrowStatus("Email Unsubscript Status = True. Operation Failed");
                            MessageBox.Show("Matched profiles processed has finished with Errors..");
                            btnSend.Enabled = true;
                        }
                    }
                    else
                    {
                        ThrowStatus("FINISHED: Profiles list is empty. Operation has finished");
                        //MessageBox.Show("Matched profiles sent FAILURE..\nProfiles list is Empty.");
                        btnSend.Enabled = true;
                    }
                }
                else
                {
                    ThrowStatus("ERROR: Operation has finished");
                    //MessageBox.Show("Matched profiles sent FAILURE..\nProfiles list is Empty.");
                    btnSend.Enabled = true;
                }

                
            }
            
            #endregion
        }

        /// <summary>
        /// Create the profile sent log for reminders
        /// </summary>
        /// <param name="ProfileCollection"></param>
        private void CreateProfileSentLog(DataSet ProfileCollection)
        {
            ThrowStatus("Preparing Profiles sent log.");

            DataSet dstOutput = new DataSet();
            dstOutput = ProfileCollection;

            for (int i = 0; i <= dstOutput.Tables[0].Rows.Count - 1; i++)
            {
                //checking if same (own) profile is choice id(Some time clients wants to see her/his profiles), then shld not counted in remainder
                if ((dstOutput.Tables[0].Rows[i]["id"].ToString() != biodataCID.ToString()))
                {
                    //checking if choice id is already in FavoriteCustomer or not, if yes then it shld not counted in remainder
                    if (!new SaatphereWIN.DAL.Membership.ClsSelect().GetAlreadyTakenDetails(biodataCID, Convert.ToInt32(dstOutput.Tables[0].Rows[i]["id"].ToString().Replace("#", ""))))
                    {
                        try
                        {
                        }
                        catch (Exception)
                        {
                            ThrowStatus("Error - Method - InsertProfileSentStatus - Profile Id : " + biodataCID);
                        }
                    }
                }
            } //Prepare and save the profile sent log in database for Reminder
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstSentLog_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(lstSentLog.SelectedItem.ToString());
        }

        private void txtTo_DoubleClick(object sender, EventArgs e)
        {
            txtTo.Text = txtFrom.Text;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string BiodataID = (string)e.Argument;

            #region AutoMatch starts
            btnSend.Enabled = false;
            string emailSubject = "Profiles for you ";

            ThrowStatus("======================================================");
            ThrowStatus("Biodata Id: " + BiodataID.ToString());
            ThrowStatus("Process started at: " + DateTime.Now.ToString());

            //Initialize the variables and collect the values
            //---------------------------------------------------------------------------------------------------------------------------
            biodataCID = Convert.ToInt32(BiodataID.Trim());
            int biodataCount = Convert.ToInt32(txtBiodataCount.Text);

            DataSet dstOutput = new DataSet();
            string profileContainerTemplate = string.Empty;
            string profileContainerFilled = string.Empty;
            string saatphereTemplate = string.Empty;
            bool sendProfilestoUnpaidonly = false;

            sendProfilestoUnpaidonly = chkProfileSendOption.CheckState == CheckState.Checked ? true : false;

            //No profiles to the deactivated customers
            //---------------------------------------------------------------------------------------------------------------------------                      
            if (new SaatphereWIN.DAL.User.ClsSelect().GetProfileStatus(biodataCID) == SaatphereWIN.DAL.User.ClsSelect.ProfileStatus.Dactive)
            {
                ThrowStatus("Profile is Deactive. Please contact Administrator.");
                MessageBox.Show("Deactivated profile. Not able to send profiles.\nPlease contact administrator for more", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSend.Enabled = true;
                return;
            }
            //---------------------------------------------------------------------------------------------------------------------------                      

            //---------------------------------------------------------------------------------------------------------------------------                      
            //Fetch the Customer's Preferred Partner Details, provide message if not found.
            //---------------------------------------------------------------------------------------------------------------------------
            ThrowStatus("Fetching Preferred partner details.");
            SaatphereWIN.DAL.DataTypes.PreferredPartner preferredPartnerDetails = new SaatphereWIN.DAL.DataTypes.PreferredPartner();
            preferredPartnerDetails = new SaatphereWIN.DAL.Membership.ClsSelect().GetPreferredPartnerDetailsfromBiodataCID(biodataCID);

            if (preferredPartnerDetails.PreferredPartnerBiodataCid == 0) //means prefered partner details not found, add then default values then
            {
                #region add the details with the default values if not preferred partner details found
                SaatphereWIN.DAL.DataTypes.PreferredPartner ppd = new SaatphereWIN.DAL.DataTypes.PreferredPartner();
                ppd.PreferredPartnerActive = true;

                DateTime userDOB = new SaatphereWIN.DAL.User.ClsSelect().GetDobFromBiodataId(biodataCID);

                if (userDOB.Date == DateTime.Now.Date) //validtion. if userDob is todays date then the id has error in the dateofbirthfield
                {
                    ThrowStatus("Date Error in Biodata ID:" + biodataCID.ToString());
                    btnSend.Enabled = true;
                }
                else
                {
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

                    ThrowStatus("No Preferred partner details found. Operation Failed");
                    btnSend.Enabled = true;
                }
            }
            else
            {
                ThrowStatus("Preferred Partner details found. Verifying...");

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
                    ppd.PreferredPartnerCaste = new SaatphereWIN.DAL.User.ClsSelect().GetCasteFromBiodataId(biodataCID);
                    ppd.PreferredPartnerMaritalStatus = new SaatphereWIN.DAL.User.ClsSelect().GetMaritalStatusFromBiodataID(biodataCID);
                    ppd.PreferredPartnerMotherTongue = new SaatphereWIN.DAL.User.ClsSelect().GetMotherTongueFromBiodataId(biodataCID);
                    ppd.PreferredPartnerReligion = new SaatphereWIN.DAL.User.ClsSelect().GetReligionFromBiodataId(biodataCID);

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
                    new SaatphereWIN.DAL.User.ClsUpdate().UpdatePreferredPartnerDetails(ppd); //update the new values in prefered partner details
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
                bool isPaidMember = new SaatphereWIN.DAL.Membership.ClsSelect().IsPaidMember(biodataCID);

                //3-december-2017. There is a check for the "Send profiles to unpaid members only", that assure whether to send the profiles to unpaid members only,
                //that will send the profiles without screening and unpaid members can receive the profiles of married people, or profiles with incomplete information
                //so there is a check for sendProfilestoUnpaidonly
                if (isPaidMember)
                {
                    if (!sendProfilestoUnpaidonly)
                    {
                        ThrowStatus("Paid Member = True");
                        if (new SaatphereWIN.DAL.Membership.ClsSelect().IsMembershipExpired(biodataCID))
                        {
                            ThrowStatus("MembershipExpired = True");
                            dstOutput = new SaatphereWIN.DAL.User.ClsSelect().BindDataAdvanceSearchWithoutAddress(preferredPartnerDetails, biodataCount, BiodataID);
                            profileContainerTemplate = SaatphereWIN.DAL.HTML.HtmlStrings.ProfileContainerWithOutAddress; //Original Template
                        }
                        else
                        {
                            ThrowStatus("MembershipExpired = False");
                            try
                            {
                                dstOutput = new SaatphereWIN.DAL.User.ClsSelect().BindDataAdvanceSearchWithAddress(preferredPartnerDetails, biodataCount, BiodataID);
                                profileContainerTemplate = SaatphereWIN.DAL.HTML.HtmlStrings.ProfileContainerWithAddress; //Original Template
                            }
                            catch (Exception ex)
                            {
                                //Skip the record having any issue
                                ThrowStatus("Error in biodata:" + BiodataID.ToString());
                                ThrowStatus("Error:" + ex.Message);
                            }
                        }
                    }
                    else
                    {
                        new SaatphereWIN.DAL.Automatch.ClsInsert().InsertIgnoredPaidMember(biodataCID);
                        ThrowStatus("Send profiles to unpaid member = checked");
                        ThrowStatus("No profile sent to paid member. ID collected");
                    }
                }
                else
                {
                    ThrowStatus("Paid Member = False");
                    dstOutput = new SaatphereWIN.DAL.User.ClsSelect().BindDataAdvanceSearchWithoutAddress(preferredPartnerDetails, biodataCount, BiodataID);
                    profileContainerTemplate = SaatphereWIN.DAL.HTML.HtmlStrings.ProfileContainerWithOutAddress; //Original Template
                }


                if (dstOutput.Tables.Count > 0)
                {
                    if (dstOutput.Tables[0].Rows.Count > 0)
                    {
                        ThrowStatus("Collected profiles. Arranging in Template.");

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
                        ThrowStatus("Profiles has arranged in Template.");


                        CreateProfileSentLog(dstOutput); //Prepare and save the profile sent log in database for Reminder

                        //for (int i = 0; i <= dstOutput.Tables[0].Rows.Count - 1; i++)
                        //{
                        //    //checking if same (own) profile is choice id(Some time clients wants to see her/his profiles), then shld not counted in remainder
                        //    if ((dstOutput.Tables[0].Rows[i]["id"].ToString() != txtCustBiodataID.Text.Trim()))
                        //    {
                        //        //checking if choice id is already in FavoriteCustomer or not, if yes then it shld not counted in remainder
                        //        if (!new SaatphereWIN.DAL.Membership.clsSelect().GetAlreadyTakenDetails(biodataCID, Convert.ToInt32(dstOutput.Tables[0].Rows[i]["id"].ToString().Replace("#", ""))))
                        //        {
                        //            try
                        //            {
                        //                new SaatphereWIN.DAL.Membership.clsInsert().InsertProfileSentLog(Convert.ToInt32(biodataCID), Convert.ToInt32(dstOutput.Tables[0].Rows[i]["id"].ToString().Replace("#", "")));
                        //            }
                        //            catch (Exception)
                        //            {
                        //                ThrowStatus("Error - Method - InsertProfileSentStatus - Profile Id : " + biodataCID);
                        //            }
                        //        }
                        //    }
                        //} 
                    }

                    if (dstOutput.Tables[0].Rows.Count > 0)
                    {
                        string gridviewEmailString = profileContainerFilled;
                        //string toUser = txtReceiver.Text;
                        string toUser = "Admin";

                        string receiver = string.Empty;
                        string receiver2 = string.Empty;

                        receiver = new SaatphereWIN.DAL.User.ClsSelect().GetEmailFromBiodataId(biodataCID);
                        receiver2 = new SaatphereWIN.DAL.User.ClsSelect().GetEmail2FromBiodataId(biodataCID);

                        if (new SaatphereWIN.DAL.User.ClsSelect().GetEmailUnsubscribeStatus(biodataCID) != true)
                        {
                            ThrowStatus("Email Unsubscribe Status = False");

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

                            ThrowStatus("Sending Profiles in Email.");

                            try
                            {
                                //send mail to both the ids of the user
                                if (receiver.Length > 0)
                                {
                                    new SaatphereWIN.DAL.ClsCommon().SendMailfromSaatphere(emailFrom, "Saatphere: Profile Match", receiver, preferredPartnerDetails.PreferredPartnerBiodataCid.ToString(), emailSubject, saatphereTemplate, "");
                                }
                                else
                                {
                                    ThrowStatus("NO EMAIL ADDRESS 1: " + BiodataID);
                                }

                                if (receiver2.Length > 0)
                                {
                                    new SaatphereWIN.DAL.ClsCommon().SendMailfromSaatphere(emailFrom, "Saatphere: Profile Match", receiver2, preferredPartnerDetails.PreferredPartnerBiodataCid.ToString(), emailSubject, saatphereTemplate, "");
                                }
                                else
                                {
                                    //ThrowStatus("NO EMAIL ADDRESS 2: " + BiodataID);
                                }

                                new SaatphereWIN.DAL.ClsCommon().SendMailfromSaatphere(emailFrom, "Saatphere: Profile Match - CC", "saatphereprofilematch@gmail.com", preferredPartnerDetails.PreferredPartnerBiodataCid.ToString(), emailSubject, saatphereTemplate, "");
                            }
                            catch (Exception ex)
                            {
                                ThrowStatus("Error in mail sending - Method - SendMailfromSaatphere - " + emailFrom + " " + ex.StackTrace);
                            }


                        }
                        else
                        {
                            ThrowStatus("Email Unsubscript Status = True. Operation Failed");
                            MessageBox.Show("Matched profiles processed has finished with Errors..");
                            btnSend.Enabled = true;
                        }
                    }
                    else
                    {
                        ThrowStatus("FINISHED: Profiles list is empty. Operation has finished");
                        //MessageBox.Show("Matched profiles sent FAILURE..\nProfiles list is Empty.");
                        btnSend.Enabled = true;
                    }
                }
                else
                {
                    ThrowStatus("ERROR: Operation has finished");
                    //MessageBox.Show("Matched profiles sent FAILURE..\nProfiles list is Empty.");
                    btnSend.Enabled = true;
                }


            }

            #endregion

        }

        private void btnExportLog_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            // set a default file name
            savefile.FileName = DateTime.Now.ToString().Replace(":", "-");
            // set filters - this can be done in properties as well
            savefile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                //string removedListObject = null;

                string path = savefile.FileName; //Host file location
                //if (!File.Exists(path) || lstSentLog.SelectedItems.Count <= 0 || string.IsNullOrEmpty(removedListObject = lstSentLog.Text))
                //{
                //    return;
                //}
                //lstSentLog.Items.Remove(lstSentLog.SelectedItem);

                //string filePath = savefile.FileName;
                //File.CreateText(path);
                

                using (var fileSStream = File.Open(path, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(fileSStream))
                    {
                        for (int i = 0; i <= lstSentLog.Items.Count - 1; i++)
                        {
                            writer.WriteLine(lstSentLog.Items[i].ToString());
                        }

                        writer.Flush();
                        writer.Close();
                    }
                    fileSStream.Close();
                }


            }
        }
    }
}
