using System;
using SaatphereWIN.DAL.DBClass;

namespace SaatphereWIN.DAL.User
{
    public class ClsInsert
    {
        public void InsertProfileMatchLog(int receiverCid, string receiverEmail, string receiverEmail2, DateTime profileSendDate, int sentProfileCid)
        {
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(SaatphereWIN.DAL.Global.SaatphereCon); //For local version
            var query = new ProfileMatchLog
            {
                ProfileMatchLog_Active = true,
                ProfileMatchLog_DateCreated = DateTime.Now,
                ProfileMatchLog_ProfileSendDate = profileSendDate,
                ProfileMatchLog_ReceiverCID = receiverCid,
                ProfileMatchLog_ReceiverEmail = receiverEmail,
                ProfileMatchLog_SentProfileCID = sentProfileCid,
                ProfileMatchLog_ReceiverEmail2 = receiverEmail2
            };
            saatphere.ProfileMatchLogs.InsertOnSubmit(query);
            saatphere.SubmitChanges();
            saatphere.Dispose();
        }

        public void InsertCustomerDetails(DataTypes.CustomerDetails customerDetails)
        {
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = new CustomerDetail
            {
                CustomerDetails_Active = customerDetails.CustomerDetailsActive,
                CustomerDetails_CreatedBy = customerDetails.CustomerDetailsCreatedBy,
                CustomerDetails_DateCreated = customerDetails.CustomerDetailsDateCreated,
                CustomerDetails_ExecutiveDSRID = customerDetails.CustomerDetailsExecutiveDsrid,
                CustomerDetails_Name = customerDetails.CustomerDetailsName,
                CustomerDetails_Phone = customerDetails.CustomerDetailsPhone,
                CustomerDetails_Remarks = customerDetails.CustomerDetailsRemarks,
                CustomerDetails_CallDirection = customerDetails.CustomerDetailsCallDirection,
                CustomerDetails_Language= customerDetails.CustomerDetailsLanguage
            };
            saatphere.CustomerDetails.InsertOnSubmit(query);
            saatphere.SubmitChanges();
            saatphere.Dispose();

        }

        public void InsertPreferredPartnerDetails(DAL.DataTypes.PreferredPartner preferredPartnerDetails)
        {
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = new PreferredPartner
            {
                PreferredPartner_Active = preferredPartnerDetails.PreferredPartnerActive,
                PreferredPartner_AgeFrom = preferredPartnerDetails.PreferredPartnerAgeFrom,
                PreferredPartner_AgeTo = preferredPartnerDetails.PreferredPartnerAgeTo,
                PreferredPartner_BiodataCID = preferredPartnerDetails.PreferredPartnerBiodataCid,
                PreferredPartner_CandidateLocation = preferredPartnerDetails.PreferredPartnerCandidateLocation,
                PreferredPartner_Caste = preferredPartnerDetails.PreferredPartnerCaste,
                PreferredPartner_CasteNoBar = preferredPartnerDetails.PreferredPartnerCasteNoBar,
                PreferredPartner_City = preferredPartnerDetails.PreferredPartnerCity,
                PreferredPartner_Country = preferredPartnerDetails.PreferredPartnerCountry,
                PreferredPartner_CreatedBy=preferredPartnerDetails.PreferredPartnerCreatedBy,
                PreferredPartner_DateCreated = preferredPartnerDetails.PreferredPartnerDateCreated,
                PreferredPartner_Education = preferredPartnerDetails.PreferredPartnerEducation,
                PreferredPartner_HeightFrom = preferredPartnerDetails.PreferredPartnerHeightFrom,
                PreferredPartner_HeightTo = preferredPartnerDetails.PreferredPartnerHeightTo,
                PreferredPartner_Income = preferredPartnerDetails.PreferredPartnerIncome,
                PreferredPartner_Mangalik = preferredPartnerDetails.PreferredPartnerMangalik,
                PreferredPartner_Occupation = preferredPartnerDetails.PreferredPartnerOccupation,
                PreferredPartner_Religion = preferredPartnerDetails.PreferredPartnerReligion,
                PreferredPartner_State = preferredPartnerDetails.PreferredPartnerState,
                PreferredPartner_MaritalStatus = preferredPartnerDetails.PreferredPartnerMaritalStatus,
                PreferredPartner_MotherTongue= preferredPartnerDetails.PreferredPartnerMotherTongue
            };
            saatphere.PreferredPartners.InsertOnSubmit(query);
            saatphere.SubmitChanges();
            saatphere.Dispose();
        }

        public void InsertBlankRowUserLogin()
        {
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = new userlogin
            {
                Customer
                = string.Empty,
                CustomerUserName = string.Empty,
            };
            saatphere.userlogins.InsertOnSubmit(query);
            saatphere.SubmitChanges();
            saatphere.Dispose();
        }

        public void InsertUserLogin(string username, string password)
        {
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = new userlogin
            {
                CustomerPassword = password,
                CustomerUserName = username,
                LastLoginDate = DateTime.Now
            };
            saatphere.userlogins.InsertOnSubmit(query);
            saatphere.SubmitChanges();
            saatphere.Dispose();
        }

        public void InsertAddUser(DAL.DataTypes.CustomerMaster customerMasterInformation)
        {
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            string createdBy = string.Empty;

            if (customerMasterInformation.CreatedBy == "adminlogin")
            {
                createdBy = "A";
            }
            else
            {
                createdBy = "F";
            }

            var query = new ContactDetail
            {
                ContactDetailRowID = customerMasterInformation.Id,
                Name = customerMasterInformation.Name,
                AddressLine1 = customerMasterInformation.Address1,
                AddressLine2 = customerMasterInformation.Address2,
                City = customerMasterInformation.City,
                Pincode = customerMasterInformation.PinCode,
                CountryUser = customerMasterInformation.Country,
                Telephone1 = customerMasterInformation.Phone1,
                Telephone2 = customerMasterInformation.Phone2,
                Mobile = customerMasterInformation.Mobile,
                EmailUser = customerMasterInformation.Email,
                //CityPCode = CustomerMasterInformation.CityPCode,
                //CityP2Code = CustomerMasterInformation.CityFCode,
                State = customerMasterInformation.State,
                ContactPersonName = customerMasterInformation.ContactPersonName,
                CreatedBy = createdBy,
                EmailUser2 = customerMasterInformation.Email2
            };

            saatphere.ContactDetails.InsertOnSubmit(query);
            saatphere.SubmitChanges();
            saatphere.Dispose();
        }

        public void InsertAddUser2(DAL.DataTypes.Biodata biodataDetails, string loginMessage, string FranchiseeUsername)
        {
            string franchiseeUsername = string.Empty;
            if (loginMessage == "franchiseelogin")
            {
                franchiseeUsername =  new DAL.Franchisee.ClsSelect().GetFranchiseeActualRowIdfromFranchiseeUsername(FranchiseeUsername).ToString();
            }
            else
            {
                franchiseeUsername = "A";
            }

            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = new BioData
            {
                RowIDBioData = biodataDetails.RowIdBiodata,
                Surname = biodataDetails.SurName,
                MiddleName = biodataDetails.MiddleName,
                Gender = biodataDetails.Gender,
                DateofBirth = biodataDetails.DateofBirth,
                CityofResidence = biodataDetails.CityofResidence,
                Country = biodataDetails.Country,
                Email = biodataDetails.Email,

                ResidentialAddress = biodataDetails.ResidentialAddress,
                Pincode = biodataDetails.PinCode,
                Residenceno = biodataDetails.ResidenceNo,
                Officeno = biodataDetails.OfficeNo,
                Mobile = biodataDetails.Mobile,
                Biodatacreatedby = biodataDetails.BiodataCreatedBy,
                Martialstatus = biodataDetails.MaritalStatus,
                Marriedbrothers = biodataDetails.MarriedBrothers,
                Unmarriedbrother = biodataDetails.UnmarriedBrother,
                Marriedsister = biodataDetails.MarriedSister,
                Unmarriedsister = biodataDetails.UnmarriedSister,
                Numberofchildren = biodataDetails.NumberofChildren,
                Placeofbirth = biodataDetails.PlaceofBirth,
                Educationstatus = biodataDetails.EducationStatus,
                Complxtion = biodataDetails.Complextion,
                Aboutmother = biodataDetails.AboutMother,
                Aboutfather = biodataDetails.AboutFather,
                Membershiptype = "Registered",
                Occupation = biodataDetails.Occupation,
                Bodytype = biodataDetails.BodyType,
                Diet = biodataDetails.Diet,
                Manglik = biodataDetails.Manglik,
                Religion = biodataDetails.Religion,
                Caste = biodataDetails.Caste,
                Mothertongue = biodataDetails.Mothertongue,
                Hearaboutus = biodataDetails.Hearaboutus,
                Moreaboutcandidate = biodataDetails.MoreaboutCandidate,
                Expectedpartner = biodataDetails.ExpectedPartner,
                Remark = biodataDetails.Remark,
                Phusicallychallenged = biodataDetails.PhysicallyChallenged,
                Firstname = biodataDetails.FirstName,
                Height = biodataDetails.Height,
                Gotra = biodataDetails.Gotra,
                AnnualIncome = biodataDetails.AnnualIncome,
                TimeofBirthh = biodataDetails.TimeofBirthH,
                TimeofBirthm = biodataDetails.TimeofBirthM,
                Citypcode = biodataDetails.CitypCode,
                Officepcode = biodataDetails.OfficepCode,
                //Photograph = "Not Avaliable",
                Status = "Active",
                Age = biodataDetails.Age,
                FranchiseeUserName = franchiseeUsername,
                RegisterationDate = DateTime.Now,
                Biodata_Email2 = biodataDetails.Email2,
                Validity ="0",
                Validityleft ="0",
                Biodata_Motherdetails = biodataDetails.MotherDetails,
                Biodata_Fatherdetails = biodataDetails.FatherDetails,
                Biodata_Educationdetails = biodataDetails.EducationDetails,
                Biodata_Occupationdetails = biodataDetails.OccupationDetails,
                Biodata_Brotherdetails= biodataDetails.BrotherDetails,
                Biodata_Sisterdetails= biodataDetails.SisterDetails,
                subcaste = biodataDetails.SubCaste,
                Biodata_CandidateLocation = biodataDetails.CandidateLocation,
                Biodata_SentBy = biodataDetails.SentBy,
                Biodata_ReceivedMode = biodataDetails.ReceivedMode,
                Biodata_ReceivedOn = biodataDetails.ReceivedOn,
                Biodata_HoroscopeMatchingRequirement = biodataDetails.HoroscopeMatchingRequirement,
                castenobar = biodataDetails.CastenoBar,
                Biodata_VisibleInside = biodataDetails.VisibleInside ,
                Biodata_VisibleOutside = biodataDetails.VisibleOutside,
                Biodata_BloodGroup = biodataDetails.BloodGroup,
                Biodata_Executive = biodataDetails.Executive ,
                Biodata_Locality = biodataDetails.BiodataLocality,
                Biodata_NRIAcceptable = biodataDetails.BiodataNriAcceptable,
                Biodata_Weight = biodataDetails.BiodataWeight
            };

            saatphere.BioDatas.InsertOnSubmit(query);
            saatphere.SubmitChanges();
            saatphere.Dispose();
        }

        public void InsertCustAcc(DAL.DataTypes.CustAcc custAccDetails)
        {
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = new CustAcc
            {
                CustomerID = custAccDetails.CustomerId,
                FranID = custAccDetails.FranId,
                Membership = custAccDetails.Membership,
                OnDate = custAccDetails.OnDate,
                ViewID = custAccDetails.ViewId
            };
            saatphere.CustAccs.InsertOnSubmit(query);
            saatphere.SubmitChanges();
            saatphere.Dispose();
        }

        public void InsertProfileSendDetails(int rowIdBioData, DateTime profileSendDate, string serviceMode, int franchisee)
        {
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            ClsSelect select = new ClsSelect();

            var query = new ProfileSend
            {
                ProfileSend_Active = true,
                ProfileSend_DateCreated = DateTime.Now,
                ProfileSend_RowIDBioData = rowIdBioData,
                ProfileSend_SendDate = profileSendDate,
                ProfileSend_Franchisee = franchisee,
                ProfileSend_ServiceMode = serviceMode
            };
            saatphere.ProfileSends.InsertOnSubmit(query);
            saatphere.SubmitChanges();
            saatphere.Dispose();
        }

        public void InsertMaxIdinTemp1()
        {

            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            ClsSelect select = new ClsSelect();
            int maxId = Convert.ToInt32(new DAL.ClsCommon().GetDatasetonSQLQuery(Global.Gettempvalue).Tables[0].Rows[0][0]);

            var query = new temp1
            {
                id = maxId
            };
            saatphere.temp1s.InsertOnSubmit(query);
            saatphere.SubmitChanges();
            saatphere.Dispose();
        }
    }
}
