using System;
using System.Linq;
using SaatphereWIN.DAL.DBClass;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SaatphereWIN.DAL.User
{
    public class ClsUpdate
    {
        public enum LocationMode
        {
            Server,
            Local
        }

        public void AssignExecutivetoCustomer(int customerRecordCid, int executiveId)
        {
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);

            var query = saatphere.CustomerDetails.SingleOrDefault(a => a.CustomerDetails_CID.Equals(customerRecordCid));
            if (query != null)
            {
                query.CustomerDetails_ExecutiveDSRID = executiveId;
                query.CustomerDetails_AssignedDate = DateTime.Now;
                saatphere.SubmitChanges(); 
            }
            saatphere.Dispose();

        }

        /// <summary>
        /// Updates the photograph name
        /// </summary>
        /// <param name="profileId"></param>
        /// <param name="photographName"></param>
        public void UpdatePhotograph(int profileId, string photographName)
        {
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(SaatphereWIN.DAL.Global.SaatphereCon);
            var query = saatphere.BioDatas.SingleOrDefault(a => a.RowIDBioData.Equals(profileId));
            if (query != null)
            {
                query.Photograph = photographName;
                saatphere.SubmitChanges();
            }
            saatphere.Dispose();
        }

        public void UpdateAge(int biodataId)
        {
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            saatphere.ExecuteCommand(Global.UpdateAge.Replace("{ROWIDBIODATA}", biodataId.ToString()));
            saatphere.Dispose();
        }

        public void UpdatePreferredPartnerDetails(DAL.DataTypes.PreferredPartner preferredPartnerDetails)
        {
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.PreferredPartners.SingleOrDefault(a => false);
            
            //If preferred partner details found then edit else it will create the details because this functionality has introduced later and to create again for the profile
            //created before applying this functionality.
            if(query != null)
            {
                query.PreferredPartner_Active = preferredPartnerDetails.PreferredPartnerActive;
                query.PreferredPartner_AgeFrom = preferredPartnerDetails.PreferredPartnerAgeFrom;
                query.PreferredPartner_AgeTo = preferredPartnerDetails.PreferredPartnerAgeTo;
                query.PreferredPartner_BiodataCID = preferredPartnerDetails.PreferredPartnerBiodataCid;
                query.PreferredPartner_CandidateLocation = preferredPartnerDetails.PreferredPartnerCandidateLocation;
                query.PreferredPartner_Caste = preferredPartnerDetails.PreferredPartnerCaste;
                query.PreferredPartner_CasteNoBar = preferredPartnerDetails.PreferredPartnerCasteNoBar;
                query.PreferredPartner_City = preferredPartnerDetails.PreferredPartnerCity;
                query.PreferredPartner_Country = preferredPartnerDetails.PreferredPartnerCountry;
                query.PreferredPartner_CreatedBy = preferredPartnerDetails.PreferredPartnerCreatedBy;
                query.PreferredPartner_DateCreated = preferredPartnerDetails.PreferredPartnerDateCreated;
                query.PreferredPartner_Education = preferredPartnerDetails.PreferredPartnerEducation;
                query.PreferredPartner_HeightFrom = preferredPartnerDetails.PreferredPartnerHeightFrom;
                query.PreferredPartner_HeightTo = preferredPartnerDetails.PreferredPartnerHeightTo;
                query.PreferredPartner_Income = preferredPartnerDetails.PreferredPartnerIncome;
                query.PreferredPartner_Mangalik = preferredPartnerDetails.PreferredPartnerMangalik;
                query.PreferredPartner_Occupation = preferredPartnerDetails.PreferredPartnerOccupation;
                query.PreferredPartner_Religion = preferredPartnerDetails.PreferredPartnerReligion;
                query.PreferredPartner_State = preferredPartnerDetails.PreferredPartnerState;
                query.PreferredPartner_MaritalStatus = preferredPartnerDetails.PreferredPartnerMaritalStatus;
                query.PreferredPartner_MotherTongue = preferredPartnerDetails.PreferredPartnerMotherTongue;
            }
            else
            {
                new ClsInsert().InsertPreferredPartnerDetails(preferredPartnerDetails);
            }
            saatphere.SubmitChanges();
            saatphere.Dispose();
        }

        public void UpdateLocalBiodata(int biodataId, string localServer, string localUsername, string localPassword, string localDatabase)
        {
            dcSaatphereDataContext saatphereServer = new dcSaatphereDataContext(SaatphereWIN.DAL.Global.SaatphereCon);
            DataSet dstBiodata = new DataSet();
            DataSet dstContactDetails = new DataSet();

            dstBiodata = new ClsSelect().GetBiodataFromId(biodataId);
            dstContactDetails = new ClsSelect().GetBiodataContactDetailFromId(biodataId);

            //Get the local Credentials
            string LocalConnectionString = "Connection Timeout= 200;Data Source=" + localServer + ";Initial Catalog="+ localDatabase +";User Id=" + localUsername + ";Password=" + localPassword + ";";
            SqlConnection con = new SqlConnection(LocalConnectionString);
            
            dcSaatphereDataContext saatphereLocal = new dcSaatphereDataContext(con);
            string biodataTableUpdateQuery = "UPDATE [BioData]" +
                                               "SET [Surname] = '" + dstBiodata.Tables[0].Rows[0]["SurName"] + "'" +
                                                "  ,[Firstname] = '" + dstBiodata.Tables[0].Rows[0]["FirstName"] + "'" +
                                                " ,[MiddleName] = '" + dstBiodata.Tables[0].Rows[0]["MiddleName"] + "'" +
                                                "  ,[Gender] ='" + dstBiodata.Tables[0].Rows[0]["Gender"] + "'" +
                                                 " ,[Height] ='" + dstBiodata.Tables[0].Rows[0]["Height"].ToString().Replace("'", "''") + "'" +
                                                  ",[DateofBirth] = '" + dstBiodata.Tables[0].Rows[0]["DateofBirth"] + "'" +
                                                  ",[Placeofbirth] = '" + dstBiodata.Tables[0].Rows[0]["PlaceofBirth"] + "'" +
                                                  ",[CityofResidence] ='" + dstBiodata.Tables[0].Rows[0]["CityofResidence"] + "'" +
                                                  ",[ResidentialAddress] = '" + dstBiodata.Tables[0].Rows[0]["ResidentialAddress"] + "'" +
                                                  ",[Country] = '" + dstBiodata.Tables[0].Rows[0]["Country"] + "'" +
                                                  ",[Residenceno] ='" + dstBiodata.Tables[0].Rows[0]["ResidenceNo"] + "'" +
                                                 " ,[Officeno] = '" + dstBiodata.Tables[0].Rows[0]["OfficeNo"] + "'" +
                                                  ",[Email] = '" + dstBiodata.Tables[0].Rows[0]["Email"] + "'" +
                                                "  ,[Pincode] = '" + dstBiodata.Tables[0].Rows[0]["PinCode"] + "'" +
                                                 " ,[Mobile] = '" + dstBiodata.Tables[0].Rows[0]["Mobile"] + "'" +
                                                "  ,[Age] = '" + dstBiodata.Tables[0].Rows[0]["Age"] + "'" +
                                                "  ,[Biodatacreatedby] = '" + dstBiodata.Tables[0].Rows[0]["BiodataCreatedBy"] + "'" +
                                                "  ,[Martialstatus] ='" + dstBiodata.Tables[0].Rows[0]["Martialstatus"] + "'" +
                                                "  ,[Marriedbrothers] = '" + dstBiodata.Tables[0].Rows[0]["Marriedbrothers"] + "'" +
                                                "  ,[Unmarriedbrother] = '" + dstBiodata.Tables[0].Rows[0]["Unmarriedbrother"] + "'" +
                                                "  ,[Marriedsister] = '" + dstBiodata.Tables[0].Rows[0]["Marriedsister"] + "'" +
                                                "  ,[Unmarriedsister] ='" + dstBiodata.Tables[0].Rows[0]["Unmarriedsister"] + "'" +
                                                "  ,[Numberofchildren] = '" + dstBiodata.Tables[0].Rows[0]["Numberofchildren"] + "'" +
                                               "   ,[Educationstatus] = '" + dstBiodata.Tables[0].Rows[0]["Educationstatus"] + "'" +
                                               "   ,[Complxtion] = '" + dstBiodata.Tables[0].Rows[0]["Complxtion"] + "'" +
                                               "   ,[Aboutmother] = '" + dstBiodata.Tables[0].Rows[0]["Aboutmother"] + "'" +
                                                "  ,[Aboutfather] ='" + dstBiodata.Tables[0].Rows[0]["Aboutfather"] + "'" +
                                                "  ,[Bodytype] = '" + dstBiodata.Tables[0].Rows[0]["Bodytype"] + "'" +
                                               "   ,[Phusicallychallenged] ='" + dstBiodata.Tables[0].Rows[0]["Phusicallychallenged"] + "'" +
                                                "  ,[TimeofBirthh] = '" + dstBiodata.Tables[0].Rows[0]["TimeofBirthh"] + "'" +
                                                "  ,[TimeofBirthm] = '" + dstBiodata.Tables[0].Rows[0]["TimeofBirthm"] + "'" +
                                              "    ,[Occupation] = '" + dstBiodata.Tables[0].Rows[0]["Occupation"] + "'" +
                                               "   ,[AnnualIncome] = '" + dstBiodata.Tables[0].Rows[0]["AnnualIncome"] + "'" +
                                              "    ,[Religion] ='" + dstBiodata.Tables[0].Rows[0]["Religion"] + "'" +
                                                "  ,[Caste] = '" + dstBiodata.Tables[0].Rows[0]["Caste"] + "'" +
                                             "     ,[Gotra] = '" + dstBiodata.Tables[0].Rows[0]["Gotra"] + "'" +
                                               "   ,[Manglik] = '" + dstBiodata.Tables[0].Rows[0]["Manglik"] + "'" +
                                               "   ,[Mothertongue] ='" + dstBiodata.Tables[0].Rows[0]["Mothertongue"] + "'" +
                                               "   ,[Diet] = '" + dstBiodata.Tables[0].Rows[0]["Diet"] + "'" +
                                              "    ,[Hearaboutus] = '" + dstBiodata.Tables[0].Rows[0]["Hearaboutus"] + "'" +
                                               "   ,[Expectedpartner] ='" + dstBiodata.Tables[0].Rows[0]["Expectedpartner"] + "'" +
                                               "   ,[Moreaboutcandidate] = '" + dstBiodata.Tables[0].Rows[0]["Moreaboutcandidate"] + "'" +
                                              "    ,[Remark] = '" + dstBiodata.Tables[0].Rows[0]["Remark"] + "'" +
                                              "    ,[Photograph] ='" + dstBiodata.Tables[0].Rows[0]["Photograph"] + "'" +
                                               "   ,[Status] ='" + dstBiodata.Tables[0].Rows[0]["Status"] + "'" +
                                              "    ,[FranchiseeUserName] ='" + dstBiodata.Tables[0].Rows[0]["FranchiseeUserName"] + "'" +
                                              "    ,[Membershiptype] = '" + dstBiodata.Tables[0].Rows[0]["Membershiptype"] + "'" +
                                             "     ,[Validity] ='" + dstBiodata.Tables[0].Rows[0]["Validity"] + "'" +
                                                "  ,[Validityleft] = '" + dstBiodata.Tables[0].Rows[0]["Validityleft"] + "'" +
                                                "  ,[StartDate] ='" + dstBiodata.Tables[0].Rows[0]["StartDate"] + "'" +
                                              "    ,[UpdateDate] ='" + dstBiodata.Tables[0].Rows[0]["UpdateDate"] + "'" +
                                              "    ,[LastDate] = '" + dstBiodata.Tables[0].Rows[0]["LastDate"] + "'" +
                                              "    ,[subcaste] ='" + dstBiodata.Tables[0].Rows[0]["subcaste"] + "'" +
                                             "     ,[castenobar] ='" + dstBiodata.Tables[0].Rows[0]["castenobar"] + "'" +
                                               "   ,[AboutCandidateFamily] = '" + dstBiodata.Tables[0].Rows[0]["AboutCandidateFamily"] + "'" +
                                               "   ,[RegisterationDate] = '" + dstBiodata.Tables[0].Rows[0]["RegisterationDate"] + "'" +
                                              "    ,[Biodata_Active] = '" + dstBiodata.Tables[0].Rows[0]["Biodata_Active"] + "'" +
                                              "    ,[Biodata_UnsubscribeEmailStatus] = '" + dstBiodata.Tables[0].Rows[0]["Biodata_UnsubscribeEmailStatus"] + "'" +
                                              "    ,[Biodata_VisibleOutside] = '" + dstBiodata.Tables[0].Rows[0]["Biodata_VisibleOutside"] + "'" +
                                             "     ,[Biodata_CandidateLocation] ='" + dstBiodata.Tables[0].Rows[0]["Biodata_CandidateLocation"] + "'" +
                                               "   ,[Biodata_BloodGroup] = '" + dstBiodata.Tables[0].Rows[0]["Biodata_BloodGroup"] + "'" +
                                              "    ,[Biodata_HoroscopeMatchingRequirement] ='" + dstBiodata.Tables[0].Rows[0]["Biodata_HoroscopeMatchingRequirement"] + "'" +
                                              "    ,[Biodata_Approved] = '" + dstBiodata.Tables[0].Rows[0]["Biodata_Approved"] + "'" +
                                             "     ,[BioData_EducationDetails] = '" + dstBiodata.Tables[0].Rows[0]["BioData_EducationDetails"] + "'" +
                                             "     ,[BioData_OccupationDetails] = '" + dstBiodata.Tables[0].Rows[0]["BioData_OccupationDetails"] + "'" +
                                             "     ,[BioData_FatherDetails] = '" + dstBiodata.Tables[0].Rows[0]["BioData_FatherDetails"] + "'" +
                                             "     ,[BioData_MotherDetails] = '" + dstBiodata.Tables[0].Rows[0]["BioData_MotherDetails"] + "'" +
                                               "   ,[BioData_SisterDetails] ='" + dstBiodata.Tables[0].Rows[0]["BioData_SisterDetails"] + "'" +
                                              "    ,[BioData_BrotherDetails] ='" + dstBiodata.Tables[0].Rows[0]["BioData_BrotherDetails"] + "'" +
                                               "   ,[BioData_CandidateOtherDetails] = '" + dstBiodata.Tables[0].Rows[0]["BioData_CandidateOtherDetails"] + "'" +
                                               "   ,[BioData_Source] = '" + dstBiodata.Tables[0].Rows[0]["BioData_Source"] + "'" +
                                              "    ,[BioData_email2] = '" + dstBiodata.Tables[0].Rows[0]["BioData_email2"] + "'" +
                                               "   ,[BioData_VisibleInside] = '" + dstBiodata.Tables[0].Rows[0]["BioData_VisibleInside"] + "'" +
                                              "    ,[BioData_LastUpdateBio] = '" + dstBiodata.Tables[0].Rows[0]["BioData_LastUpdateBio"] + "'" +
                                               "   ,[BioData_RejectReason] = '" + dstBiodata.Tables[0].Rows[0]["BioData_RejectReason"] + "'" +
                                               "   ,[BioData_ReceivedOn] =>'" + dstBiodata.Tables[0].Rows[0]["BioData_ReceivedOn"] + "'" +
                                                "  ,[BioData_HighestDegree] ='" + dstBiodata.Tables[0].Rows[0]["BioData_HighestDegree"] + "'" +
                                               "   ,[BioData_SentBy] = '" + dstBiodata.Tables[0].Rows[0]["BioData_SentBy"] + "'" +
                                               "   ,[BioData_ReceivedMode] = '" + dstBiodata.Tables[0].Rows[0]["BioData_ReceivedMode"] + "'" +
                                          "   WHERE [RowIDBioData]=" + biodataId;

            SqlCommand cmd = new SqlCommand(biodataTableUpdateQuery, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            

            var queryContact = saatphereLocal.ContactDetails.SingleOrDefault(a => a.ContactDetailRowID.Equals(biodataId));
            if (queryContact != null)
            {
                queryContact.Name = dstContactDetails.Tables[0].Rows[0]["Name"].ToString();
                queryContact.AddressLine1 = dstContactDetails.Tables[0].Rows[0]["AddressLine1"].ToString();
                queryContact.AddressLine2 = dstContactDetails.Tables[0].Rows[0]["AddressLine2"].ToString();
                queryContact.City = dstContactDetails.Tables[0].Rows[0]["City"].ToString();
                queryContact.Pincode = dstContactDetails.Tables[0].Rows[0]["PinCode"].ToString();
                queryContact.CountryUser = dstContactDetails.Tables[0].Rows[0]["CountryUser"].ToString();
                queryContact.Telephone1 = dstContactDetails.Tables[0].Rows[0]["Telephone1"].ToString();
                queryContact.Telephone2 = dstContactDetails.Tables[0].Rows[0]["Telephone2"].ToString();
                queryContact.Mobile = dstContactDetails.Tables[0].Rows[0]["Mobile"].ToString();
                queryContact.EmailUser = dstContactDetails.Tables[0].Rows[0]["EmailUser"].ToString();
                //CityPCode = dstContactDetails.Tables[0].Rows[0]["CityPCode"].ToString();
                //CityP2Code = dstContactDetails.Tables[0].Rows[0]["CityFCode"].ToString();
                queryContact.State = dstContactDetails.Tables[0].Rows[0]["State"].ToString();
                queryContact.ContactPersonName = dstContactDetails.Tables[0].Rows[0]["ContactPersonName"].ToString();
                queryContact.EmailUser2 = dstContactDetails.Tables[0].Rows[0]["EmailUser2"].ToString();

                saatphereLocal.SubmitChanges();
            }

            saatphereServer.Dispose();
            saatphereLocal.Dispose();
        }

        public void UpdateValidity(int userId)
        {
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.BioDatas.SingleOrDefault(a => a.RowIDBioData.Equals(userId));
            if (query != null)
            {
                query.Validity = "0";
                query.Validityleft = "0";

                saatphere.SubmitChanges();
            }
            saatphere.Dispose();
        }

        public void EditCustomerDetails(DAL.DataTypes.Biodata biodataDetails)
        {
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.BioDatas.SingleOrDefault(a => a.RowIDBioData.Equals(biodataDetails.RowIdBiodata));
            if (query != null)
            {
                query.Surname = biodataDetails.SurName;
                query.Firstname = biodataDetails.FirstName;
                query.MiddleName = biodataDetails.MiddleName;
                query.Gender = biodataDetails.Gender;
                query.Height = biodataDetails.Height;
                query.DateofBirth = biodataDetails.DateofBirth;
                query.Placeofbirth = biodataDetails.PlaceofBirth;
                query.CityofResidence = biodataDetails.CityofResidence;
                query.ResidentialAddress = biodataDetails.ResidentialAddress;
                query.Country = biodataDetails.Country;
                query.Residenceno = biodataDetails.ResidenceNo;
                query.Officeno = biodataDetails.OfficeNo;
                query.Email = biodataDetails.Email;
                query.Pincode = biodataDetails.PinCode;
                query.Mobile = biodataDetails.Mobile;
                query.Age = biodataDetails.Age;
                query.Biodatacreatedby = biodataDetails.BiodataCreatedBy;
                query.Martialstatus = biodataDetails.MaritalStatus;
                query.Marriedbrothers = biodataDetails.MarriedBrothers;
                query.Unmarriedbrother = biodataDetails.UnmarriedBrother;
                query.Marriedsister = biodataDetails.MarriedSister;
                query.Unmarriedsister = biodataDetails.UnmarriedSister;
                query.Numberofchildren = biodataDetails.NumberofChildren;
                query.Educationstatus = biodataDetails.EducationStatus;
                query.Complxtion = biodataDetails.Complextion;
                query.Aboutmother = biodataDetails.AboutMother;
                query.Aboutfather = biodataDetails.AboutFather;
                query.Bodytype = biodataDetails.BodyType;
                query.Phusicallychallenged = biodataDetails.PhysicallyChallenged;
                query.TimeofBirthh = biodataDetails.TimeofBirthH;
                query.TimeofBirthm = biodataDetails.TimeofBirthM;
                query.Occupation = biodataDetails.Occupation;
                query.AnnualIncome = biodataDetails.AnnualIncome;
                query.Religion = biodataDetails.Religion;
                query.Caste = biodataDetails.Caste;
                query.Gotra = biodataDetails.Gotra;
                query.Manglik = biodataDetails.Manglik;
                query.Mothertongue = biodataDetails.Mothertongue;
                query.Diet = biodataDetails.Diet;
                query.Hearaboutus = biodataDetails.Hearaboutus;
                query.Expectedpartner = biodataDetails.ExpectedPartner;
                query.Moreaboutcandidate = biodataDetails.MoreaboutCandidate;
                query.Remark = biodataDetails.Remark;
                query.subcaste = biodataDetails.SubCaste;
                query.castenobar = biodataDetails.CastenoBar;
                query.AboutCandidateFamily = biodataDetails.AboutCandidateFamily;
                query.Biodata_VisibleOutside = Convert.ToBoolean(Convert.ToInt32(biodataDetails.VisibleOutside));
                query.Biodata_CandidateLocation = biodataDetails.CandidateLocation;
                query.Biodata_BloodGroup = biodataDetails.BloodGroup;
                query.Biodata_HoroscopeMatchingRequirement = biodataDetails.HoroscopeMatchingRequirement;
                query.Biodata_Educationdetails = biodataDetails.EducationDetails;
                query.Biodata_Occupationdetails = biodataDetails.OccupationDetails;
                query.Biodata_Fatherdetails = biodataDetails.FatherDetails;
                query.Biodata_Motherdetails = biodataDetails.MotherDetails;
                query.Biodata_Sisterdetails = biodataDetails.SisterDetails;
                query.Biodata_Brotherdetails = biodataDetails.BrotherDetails;
                query.Biodata_CandidateOtherDetails = biodataDetails.CandidateOtherDetails;
                query.Biodata_Source = biodataDetails.Source;
                query.Biodata_Email2 = biodataDetails.Email2;
                query.Biodata_SentBy = biodataDetails.SentBy;
                query.Biodata_ReceivedMode = biodataDetails.ReceivedMode;
                query.Biodata_ReceivedOn = biodataDetails.ReceivedOn;
                query.Biodata_VisibleInside = Convert.ToBoolean(Convert.ToInt32(biodataDetails.VisibleInside));

                saatphere.SubmitChanges();
            }
            saatphere.Dispose();
        }

        public void UpdateMembership(DAL.DataTypes.Biodata biodataDetails)
        {
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);

            
            string updateQuery = "update Biodata set MembershipType = '" + biodataDetails.Membershiptype + "',Validity = '" + biodataDetails.Validity + "', " +
            "Validityleft= '"+ biodataDetails.ValidityLeft  +"', Status ='" + biodataDetails.Status + "', StartDate= '" + biodataDetails.StartDate + "', " +
            "LastDate= '" + biodataDetails.LastDate + "', FranchiseeUserName = '" + biodataDetails.FranchiseeUserName + "' where RowIDBioData = " + biodataDetails.RowIdBiodata;
            saatphere.ExecuteCommand(updateQuery);
            saatphere.Dispose();
        }  

        public void UpdateCalendarLastDate(int profileId)
        {
            SqlConnection con = new SqlConnection(DAL.Global.SaatphereCon);
            SqlCommand cmd = new SqlCommand(Global.PsendSqlUpdatelastdate.Replace("{PROFILEID}", profileId.ToString()), con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateLastDate(int profileId, string lastDate, string remark)
        {
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.BioDatas.SingleOrDefault(a => a.RowIDBioData.Equals(profileId));
            if (query != null)
            {
                query.LastDate = lastDate;
                saatphere.SubmitChanges();
            }
            saatphere.Dispose();

           

        }

        public void UpdateStatus(int profileId, string status)
        {
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.BioDatas.SingleOrDefault(a => a.RowIDBioData.Equals(profileId));
            if (query != null)
            {
                query.Status = status;
                saatphere.SubmitChanges();
                saatphere.Transaction.Commit();
            }
            saatphere.Dispose();
        }

        public void UpdateBiodata(DAL.DataTypes.Biodata biodataDetails, LocationMode location)
        {
            string saveLocation = string.Empty;
            if (location == LocationMode.Local)
            {
                saveLocation = ConfigurationManager.AppSettings["LocalConnectionString"].ToString();
            }
            else
            {
                saveLocation = DAL.Global.SaatphereCon;
            }

            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(saveLocation);
            
            var query = saatphere.BioDatas.SingleOrDefault(a => a.RowIDBioData.Equals(biodataDetails.RowIdBiodata));
            if(query!=null)
            {
                query.RowIDBioData = biodataDetails.RowIdBiodata;
                query.Surname = biodataDetails.SurName;
                query.MiddleName = biodataDetails.MiddleName;
                query.Gender = biodataDetails.Gender;
                query.DateofBirth = biodataDetails.DateofBirth;
                query.CityofResidence = biodataDetails.CityofResidence;
                query.Country = biodataDetails.Country;
                query.Email = biodataDetails.Email;

                query.ResidentialAddress = biodataDetails.ResidentialAddress;
                query.Pincode = biodataDetails.PinCode;
                query.Residenceno = biodataDetails.ResidenceNo;
                query.Officeno = biodataDetails.OfficeNo;
                query.Mobile = biodataDetails.Mobile;
                query.Biodatacreatedby = biodataDetails.BiodataCreatedBy;
                query.Martialstatus = biodataDetails.MaritalStatus;
                query.Marriedbrothers = biodataDetails.MarriedBrothers;
                query.Unmarriedbrother = biodataDetails.UnmarriedBrother;
                query.Marriedsister = biodataDetails.MarriedSister;
                query.Unmarriedsister = biodataDetails.UnmarriedSister;
                query.Numberofchildren = biodataDetails.NumberofChildren;
                query.Placeofbirth = biodataDetails.PlaceofBirth;
                query.Educationstatus = biodataDetails.EducationStatus;
                query.Complxtion = biodataDetails.Complextion;
                query.Aboutmother = biodataDetails.AboutMother;
                query.Aboutfather = biodataDetails.AboutFather;
                query.Occupation = biodataDetails.Occupation;
                query.Bodytype = biodataDetails.BodyType;
                query.Diet = biodataDetails.Diet;
                query.Manglik = biodataDetails.Manglik;
                query.Religion = biodataDetails.Religion;
                query.Caste = biodataDetails.Caste;
                query.Mothertongue = biodataDetails.Mothertongue;
                query.Hearaboutus = biodataDetails.Hearaboutus;
                query.Moreaboutcandidate = biodataDetails.MoreaboutCandidate;
                query.Expectedpartner = biodataDetails.ExpectedPartner;
                query.Remark = biodataDetails.Remark;
                query.Phusicallychallenged = biodataDetails.PhysicallyChallenged;
                query.Firstname = biodataDetails.FirstName;
                query.Height = biodataDetails.Height;
                query.Gotra = biodataDetails.Gotra;
                query.AnnualIncome = biodataDetails.AnnualIncome;
                query.TimeofBirthh = biodataDetails.TimeofBirthH;
                query.TimeofBirthm = biodataDetails.TimeofBirthM;
                query.Citypcode = biodataDetails.CitypCode;
                query.Officepcode = biodataDetails.OfficepCode;
                //query.Photograph = "Not Avaliable";
                query.Status = "Active";
                query.Age = biodataDetails.Age;
                //query.FranchiseeUserName = franchiseeUsername;
                query.RegisterationDate = DateTime.Now;
                query.Biodata_Email2 = biodataDetails.Email2;
                query.Validity = "0";
                query.Validityleft = "0";
                query.Biodata_Motherdetails = biodataDetails.MotherDetails;
                query.Biodata_Fatherdetails = biodataDetails.FatherDetails;
                query.Biodata_Educationdetails = biodataDetails.EducationDetails;
                query.Biodata_Occupationdetails = biodataDetails.OccupationDetails;
                query.Biodata_Brotherdetails = biodataDetails.BrotherDetails;
                query.Biodata_Sisterdetails = biodataDetails.SisterDetails;
                query.subcaste = biodataDetails.SubCaste;
                query.Biodata_CandidateLocation = biodataDetails.CandidateLocation;
                query.Biodata_SentBy = biodataDetails.SentBy;
                query.Biodata_ReceivedMode = biodataDetails.ReceivedMode;
                query.Biodata_ReceivedOn = biodataDetails.ReceivedOn;
                query.Biodata_HoroscopeMatchingRequirement = biodataDetails.HoroscopeMatchingRequirement;
                query.castenobar = biodataDetails.CastenoBar;
                query.Biodata_VisibleInside = biodataDetails.VisibleInside;
                query.Biodata_VisibleOutside = biodataDetails.VisibleOutside;
                query.Biodata_Executive = biodataDetails.Executive;
                query.Biodata_Locality = biodataDetails.BiodataLocality;
                query.Biodata_NRIAcceptable = biodataDetails.BiodataNriAcceptable;
                query.Biodata_Weight = biodataDetails.BiodataWeight;
                query.Biodata_Source = biodataDetails.Source;
                query.Biodata_BloodGroup = biodataDetails.BloodGroup;
            }
            
            saatphere.SubmitChanges();
            saatphere.Dispose();
        }

        public void UpdateContactDetail(DAL.DataTypes.CustomerMaster customerMasterInformation)
        {
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
         

            var query = saatphere.ContactDetails.SingleOrDefault(a => a.ContactDetailRowID.Equals(customerMasterInformation.Id));
            if(query !=null)
            {
                query.Name = customerMasterInformation.Name;
                query.AddressLine1 = customerMasterInformation.Address1;
                query.AddressLine2 = customerMasterInformation.Address2;
                query.City = customerMasterInformation.City;
                query.Pincode = customerMasterInformation.PinCode;
                query.CountryUser = customerMasterInformation.Country;
                query.Telephone1 = customerMasterInformation.Phone1;
                query.Telephone2 = customerMasterInformation.Phone2;
                query.Mobile = customerMasterInformation.Mobile;
                query.EmailUser = customerMasterInformation.Email;
                //CityPCode = CustomerMasterInformation.CityPCode;
                //CityP2Code = CustomerMasterInformation.CityFCode;
                query.State = customerMasterInformation.State;
                query.ContactPersonName = customerMasterInformation.ContactPersonName;                
                query.EmailUser2 = customerMasterInformation.Email2;
            };

            saatphere.SubmitChanges();
            saatphere.Dispose();
        }

        
    }


}
