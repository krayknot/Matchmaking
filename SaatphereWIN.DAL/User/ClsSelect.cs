using System;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using SaatphereWIN.DAL.DBClass;

namespace SaatphereWIN.DAL.User
{
    public class ClsSelect
    {
        public enum LoginAs
        {
            Administrator,
            Franchisee,
            Customer
        }

        public enum ProfileStatus
        {
            Active,
            Dactive,
            Hold,
            Registered            
        }

        public ProfileStatus GetProfileStatus(int biodataId)
        {
            ProfileStatus response = 0;
            var saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.BioDatas.SingleOrDefault(a => a.RowIDBioData.Equals(biodataId));

            if (query == null) return response;
            if(query.Status == "Active")
            {
                response = ProfileStatus.Active;
            }
            else if (query.Status == "Dactive")
            {
                response = ProfileStatus.Dactive;
            }
            else if (query.Status == "Hold")
            {
                response = ProfileStatus.Hold;
            }
            else if (query.Status == "Registered")
            {
                response = ProfileStatus.Registered;
            }
            else if (query.Status == "")
            {
                response = ProfileStatus.Dactive;
            }

            return response;
        }
        
        public string GetReligionFromBiodataId(int biodataId)
        {
            var response = string.Empty;
            var saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.BioDatas.SingleOrDefault(a => a.RowIDBioData.Equals(biodataId));
            if (query != null)
            {
                response = query.Religion;
            }
            return response;
        }

        public string GetMotherTongueFromBiodataId(int biodataId)
        {
            var response = string.Empty;
            var saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.BioDatas.SingleOrDefault(a => a.RowIDBioData.Equals(biodataId));
            if (query != null)
            {
                response = query.Mothertongue;
            }

            return response;
        }

        public string GetMaritalStatusFromBiodataID(int biodataId)
        {
            var response = string.Empty;
            var saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.BioDatas.SingleOrDefault(a => a.RowIDBioData.Equals(biodataId));
            if (query != null)
            {
                response = query.Martialstatus;
            }

            return response;
        }

        public string GetCasteFromBiodataId(int biodataId)
        {
            var response = string.Empty;
            var saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.BioDatas.SingleOrDefault(a => a.RowIDBioData.Equals(biodataId));
            if (query != null)
            {
                response = query.Caste;
            }

            return response;
        }

        public DateTime GetDobFromBiodataId(int biodataId)
        {
            DateTime response = DateTime.Now;
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.BioDatas.SingleOrDefault(a => a.RowIDBioData.Equals(biodataId));
            if (query != null)
            {
                if (query.DateofBirth.Length > 0)
                {
                    response = Convert.ToDateTime(query.DateofBirth);
                }
            }

            return response;
        }

        public string GetEmailFromBiodataID(int biodataId)
        {
            var response = string.Empty;
            var saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.BioDatas.SingleOrDefault(a => a.RowIDBioData.Equals(biodataId));
            if (query != null)
            {
                response = query.Email;
            }

            return response;
        }

        public DataSet ProfileMatch_SearchUserFromID(int profileId)
        {
            DataSet dst = new DataSet();
            dst = new ClsCommon().GetDatasetonSQLQuery(Global.PmatchSqlGetuserfromid.Replace("{PROFILEID}", profileId.ToString()));
            return dst;
        }

        public DataSet GetCustomerDetails(int franchiseeId, string language)
        {
            var dst = new DataSet();
            dst = new ClsCommon().GetDatasetonSQLQuery(Global.GetCustomerDetails.Replace("{FRANCHISEID}", franchiseeId.ToString()).Replace("{LANGUAGE}", language));

            return dst;
        }


        public DataSet GetUserInfofromRowIdBiodata(int profileId)
        {
            var con = new SqlConnection(SaatphereWIN.DAL.Global.SaatphereCon);
            var query = "SELECT rowidbiodata'Sr. No.', Firstname'Name', ('')'Amount', Mobile'Phone Number', CityofResidence'Location', rowidbiodata'ID',('')'Service Mode', membershiptype'Membership', startdate'Start Date', lastdate'End Date', ('')'Welcome Call' FROM biodata WHERE rowidbiodata = " + profileId;
            var dad = new SqlDataAdapter(query, con);
            var dst = new DataSet();
            dad.Fill(dst);

            return dst;
        }

        public bool IsMobileNumberExists(string mobileNumber)
        {
            var response = false;

            var saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.BioDatas.Where(a => a.Mobile.Trim().Equals(mobileNumber.Trim())).ToList();
            if (query.Count>0)
            {
                response = true;
            }
            return response;
        }

        public string GetCandidateNameFromBiodataId(int biodataId)
        {
            var response = string.Empty;
            var saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.BioDatas.SingleOrDefault(a => a.RowIDBioData.Equals(biodataId));
            if (query != null)
            {
                response = query.Firstname; 
            }

            return response;
        }

        public int GetProfileCountonQuery(string query)
        {
            int response;

            var con = new SqlConnection(SaatphereWIN.DAL.Global.SaatphereCon);
            var cmd = new SqlCommand(query, con);
            con.Open();
            response = (int)cmd.ExecuteScalar();
            con.Close();
            return response;
        }

        public bool GetEmailUnsubscribeStatus(int profileId)
        {
            var saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var response = false;

            var query = saatphere.BioDatas.SingleOrDefault(a => a.RowIDBioData.Equals(profileId));
            if (query?.Biodata_UnsubscribeEmailStatus != null)
            {
                response = (bool)query.Biodata_UnsubscribeEmailStatus;
            }
            return response;
        }

        public string GetEmailFromBiodataId(int biodataId)
        {
            var response = string.Empty;

            var saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.ContactDetails.SingleOrDefault(a => a.ContactDetailRowID.Equals(biodataId));
            if(query != null)
            {
                response = query.EmailUser;
            }

            return response;
        }

        public string GetEmail2FromBiodataId(int biodataId)
        {
            var response = string.Empty;

            var saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.BioDatas.SingleOrDefault(a => a.RowIDBioData.Equals(biodataId));
            if (query != null)
            {
                response = query.Biodata_Email2;
            }

            return response;
        }

        public string GetProfileFirstNamefromProfileCid(int profileCid)
        {
            var saatphere = new dcSaatphereDataContext(SaatphereWIN.DAL.Global.SaatphereCon);
            var query = saatphere.BioDatas.SingleOrDefault(a => a.RowIDBioData.Equals(profileCid));
            var response = string.Empty;

            if (query != null)
            {
                response = query.Firstname;
            }
            saatphere.Dispose();
            return response;
        }

        public DataSet BindDataAdvanceSearchWithAddress(SaatphereWIN.DAL.DataTypes.PreferredPartner preferredPartnerDetails, int resultRecordCount, string biodataReceiverId)
        {
            //To get the opposite gender search so that, male will get female profiles and female will get male profiles
            //----------------------------------------------------------------------------------------------------------------------------------
            var gender = new User.ClsSelect().GetGenderfromActualRowId(Convert.ToInt32(preferredPartnerDetails.PreferredPartnerBiodataCid));
            if (gender == "Male")
                gender = "Female";
            else if (gender == "Female")
                gender = "Male";
            //----------------------------------------------------------------------------------------------------------------------------------

            var query = "select top " + resultRecordCount + " biodata.FranchiseeUsername, (CASE WHEN membershiptype <> 'Registered' THEN Convert(varchar, Rowidbiodata) + '#' ELSE Convert(varchar, rowidbiodata) END)'ID', ('<a href = http://admin.peopleonegroup.com/PROFILEMATCH/biodatafinal.aspx?biodataid=' + convert(varchar, biodata.rowidbiodata) + '>' + convert(varchar, biodata.FirstName) + '</a>')'Name', biodata.Gender, biodata.CityofResidence'City', biodata.Caste, ('http://saatphere.peopleonegroup.com//BiodataImages//' + substring(biodata.Photograph,1,1) + '-Images//' + convert(varchar,biodata.Photograph))'Photograph', biodata.EducationStatus, biodata.Occupation, biodata.Religion, biodata.Country, biodata.Age, biodata.Height, biodata.Email, biodata.biodata_email2, biodata.residenceno, biodata.mobile, biodata.residentialaddress, Biodata.MembershipType, contactdetail.contactpersonname from userlogin inner join contactdetail on contactdetail.contactdetailrowid = userlogin.actualrowid inner join biodata on biodata.rowidbiodata = userlogin.actualrowid inner join contactdetail as cd1 on biodata.rowidbiodata = cd1.contactdetailrowid where biodata.gender = '" + gender + "' and biodata.status = 'Active'  and LEN(CONVERT(VARCHAR,Photograph)) > 0 and CONVERT(VARCHAR,Photograph) <> 'Not Avaliable' and biodata.rowidbiodata not in (select profileMatchLog_SentProfileCID from ProfileMAtchlog where profilematchlog_receivercid = " + biodataReceiverId + ")";

            #region SaatpheredBSearch
            var heightfrom = preferredPartnerDetails.PreferredPartnerHeightFrom;
            var heightto = preferredPartnerDetails.PreferredPartnerHeightTo;
            var agefrom = preferredPartnerDetails.PreferredPartnerAgeFrom;
            var ageto = preferredPartnerDetails.PreferredPartnerAgeTo;
            var occupation = preferredPartnerDetails.PreferredPartnerOccupation;
            var manglik = preferredPartnerDetails.PreferredPartnerMangalik;
            var caste = preferredPartnerDetails.PreferredPartnerCaste;
            var religion = preferredPartnerDetails.PreferredPartnerReligion;
            var country = preferredPartnerDetails.PreferredPartnerCountry;
            var city = preferredPartnerDetails.PreferredPartnerCity;
            var education = preferredPartnerDetails.PreferredPartnerEducation;
            var candidateLocation = preferredPartnerDetails.PreferredPartnerCandidateLocation;
            var castenobar = preferredPartnerDetails.PreferredPartnerCasteNoBar;
            var annualIncome = preferredPartnerDetails.PreferredPartnerIncome;
            var motherTongue = preferredPartnerDetails.PreferredPartnerMotherTongue;
            var maritalStatus = preferredPartnerDetails.PreferredPartnerMaritalStatus;

            var state = preferredPartnerDetails.PreferredPartnerState;
            var dset = new DataSet();

            //Age Filter
            if (agefrom.Length > 0 && ageto.Length > 0)
            {
                query = query + " and convert(int, Age) >= " + agefrom + " and convert(int, Age) <= " + ageto;
            }

            //Height Filter
            if (heightfrom.Trim().Length > 0 && heightto.Trim().Length > 0)
            {
                query = query + " and  Convert(float, height) >= " + heightfrom.Replace("'", "").Replace('"', ' ').Trim() + " and convert(float, height) <= " + heightto.Replace("'", "").Replace('"', ' ').Trim();
            }

            //Religion
            if (religion.Length > 0)
            {
                query = query + " and Religion in ('" + religion.Replace(",", "','") + "')";
            }

            //Caste
            if (caste.Length > 0)
            {
                query = query + " and Caste in ('" + caste.Replace(",", "','") + "')";
            }

            //Caste No Bar
            if (castenobar.Length > 0)
            {
                query = query + " and castenobar in ('" + castenobar.Replace(",", "','") + "')";
            }

            //Education
            if (education.Length > 0)
            {
                query = query + " and educationstatus in ('" + education.Replace(",", "','") + "')";
            }

            //Occupation
            if (occupation.Length > 0)
            {
                query = query + " and occupation in ('" + occupation.Replace(",", "','") + "')";
            }

            //Income
            if (annualIncome.Length > 0)
            {
                query = query + " and annualincome in ('" + annualIncome.Replace(",", "','") + "')";
            }

            //Country
            if (country.Length > 0)
            {
                query = query + " and country in ('" + country.Replace(",", "','") + "')";
            }

            //State
            if (state.Length > 0)
            {
                query = query + " and cd1.State in ('" + state.Replace(",", "','") + "')";
            }

            //City
            if (city.Length > 0)
            {
                query = query + " and cityofresidence in ('" + city.Replace(",", "','") + "')";
            }

            //Mangalik
            if (manglik.Length > 0)
            {
                query = query + " and manglik in ('" + manglik.Replace(",", "','") + "')";
            }

            //Candidate Location
            if (candidateLocation.Length > 0)
            {
                query = query + " and cityofresidence in ('" + candidateLocation.Replace(",", "','") + "')";
            }

            //Candidate Mother Tongue
            if (motherTongue?.Length > 0)
            {
                query = query + " and mothertongue in ('" + motherTongue.Replace(",", "','") + "')";
            }

            //Candidate Marital Status
            if (maritalStatus?.Length > 0)
            {
                query = query + " and martialstatus in ('" + maritalStatus.Replace(",", "','") + "')";
            }

            query = query + " order by rowidbiodata desc"; //to get the latest profils first

            SqlConnection conn = new SqlConnection(DAL.Global.SaatphereCon);
            SqlCommand comm = new SqlCommand(query, conn);
            SqlDataAdapter adas = new SqlDataAdapter(comm);
            adas.Fill(dset);
                       
            #endregion

            var dstResponse = dset;
            return dstResponse;
        }

        /// <summary>
        /// Returns the height string to match from the database
        /// </summary>
        /// <param name="HeightFrom">Starting height</param>
        /// <param name="HeightTo">Ending height</param>
        /// <returns></returns>
        private string HeightString(string HeightFrom, string HeightTo)
        {
            var response = string.Empty;

            //Take the Maximum and minimum height values
            var heightFrom = 35;
            var heightTo = 7;

            //Get the ' and " replace with space to convert into numeric
            if (HeightFrom.Length > 0)
            {
                heightFrom = Convert.ToInt32(HeightFrom.Replace("'","").Replace("\"",""));
            }

            if (HeightTo.Length > 0)
            {
                heightTo = Convert.ToInt32(HeightTo.Replace("'", "").Replace("\"", ""));
            }


            //Create the sequence like '4'','4'5"' etc...
            for (int i = heightFrom; i <= heightTo; i++)
            {
                if (i.ToString().Length == 1)
                {
                    response = response + "'" + i + "''',";
                }
                else if (i.ToString().Length == 2)
                {
                    response = response + "'" + i.ToString().Substring(0,1)  +"''" + i.ToString().Substring(1,1) + "\"'," ;
                }
            }

            //Remove the last comma, from the string 
            if (response.Length > 0)
            {
                response = response.Substring(0, response.Length - 1);
            }
            return response;
        }

        public DataSet BindDataAdvanceSearchWithoutAddress(SaatphereWIN.DAL.DataTypes.PreferredPartner preferredPartnerDetails, int resultRecordCount, string biodataReceiverId)
        {
            #region SaatpheredBSearch

            //To get the opposite gender search so that, male will get female profiles and female will get male profiles
            //----------------------------------------------------------------------------------------------------------------------------------
            var gender = new User.ClsSelect().GetGenderfromActualRowId(Convert.ToInt32(preferredPartnerDetails.PreferredPartnerBiodataCid));
            if (gender == "Male")
                gender = "Female";
            else if (gender == "Female")
                gender = "Male";
            //----------------------------------------------------------------------------------------------------------------------------------

            var query = "select top " + resultRecordCount + " biodata.FranchiseeUsername, Convert(varchar, biodata.rowidbiodata)'ID', ('<a href = http://admin.peopleonegroup.com/PROFILEMATCH/biodatafinal.aspx?biodataid=' + convert(varchar, biodata.rowidbiodata) + '>' + convert(varchar, biodata.FirstName) + '</a>')'Name', biodata.Gender, biodata.CityofResidence'City', biodata.Caste, ('http://saatphere.peopleonegroup.com//BiodataImages//' + substring(biodata.Photograph,1,1) + '-Images//' + convert(varchar,biodata.Photograph))'Photograph', biodata.EducationStatus, biodata.Occupation, biodata.Religion, biodata.Country, biodata.Age from userlogin inner join contactdetail on contactdetail.contactdetailrowid = userlogin.actualrowid inner join biodata on biodata.rowidbiodata = userlogin.actualrowid inner join contactdetail as cd1 on biodata.rowidbiodata = cd1.contactdetailrowid where biodata.gender = '" + gender + "' and biodata.status = 'Active' and LEN(CONVERT(VARCHAR,Photograph)) > 0 and CONVERT(VARCHAR,Photograph) <> 'Not Avaliable' and biodata.rowidbiodata not in (select profileMatchLog_SentProfileCID from ProfileMAtchlog where profilematchlog_receivercid = " + biodataReceiverId + ")";
            
            var heightfrom = preferredPartnerDetails.PreferredPartnerHeightFrom;
            var heightto = preferredPartnerDetails.PreferredPartnerHeightTo;            
            var agefrom = preferredPartnerDetails.PreferredPartnerAgeFrom;
            var ageto = preferredPartnerDetails.PreferredPartnerAgeTo;
            var occupation = preferredPartnerDetails.PreferredPartnerOccupation;
            var manglik = preferredPartnerDetails.PreferredPartnerMangalik;
            var caste = preferredPartnerDetails.PreferredPartnerCaste;
            var religion = preferredPartnerDetails.PreferredPartnerReligion;
            var country = preferredPartnerDetails.PreferredPartnerCountry;
            var city = preferredPartnerDetails.PreferredPartnerCity;
            var education = preferredPartnerDetails.PreferredPartnerEducation;
            var candidateLocation = preferredPartnerDetails.PreferredPartnerCandidateLocation;
            var castenobar = preferredPartnerDetails.PreferredPartnerCasteNoBar;
            var annualIncome = preferredPartnerDetails.PreferredPartnerIncome;
            var motherTongue = preferredPartnerDetails.PreferredPartnerMotherTongue;
            var maritalStatus = preferredPartnerDetails.PreferredPartnerMaritalStatus;

            var state = preferredPartnerDetails.PreferredPartnerState;

            var dset = new DataSet();

            //Age Filter
            if (agefrom.Length > 0 && ageto.Length > 0)
            {
                query = query + " and convert(int, Age) >= " + agefrom + " and convert(int, Age) <= " + ageto;
            }

            //Height Filter
            if (heightfrom.Trim().Length > 0 && heightto.Trim().Length > 0)
            {
                query = query + " and  Convert(float, height) >= " + heightfrom.Replace("'", "").Replace('"', ' ').Trim() + " and convert(float, height) <= " + heightto.Replace("'", "").Replace('"', ' ').Trim();
            }

            //Religion
            if (religion.Length > 0)
            {
                query = query + " and Religion in ('" + religion.Replace(",", "','") + "')";
            }

            //Caste
            if (caste.Length > 0)
            {
                query = query + " and Caste in ('" + caste.Replace(",", "','").Replace("'","") + "')";
            }

            //Caste No Bar
            if (castenobar.Length > 0)
            {
                query = query + " and castenobar in ('" + castenobar.Replace(",", "','") + "')";
            }

            //Education
            if (education.Length > 0)
            {
                query = query + " and educationstatus in ('" + education.Replace(",", "','") + "')";
            }

            //Occupation
            if (occupation.Length > 0)
            {
                query = query + " and occupation in ('" + occupation.Replace(",", "','") + "')";
            }

            //Income
            if (annualIncome.Length > 0)
            {
                query = query + " and annualincome in ('" + annualIncome.Replace(",", "','") + "')";
            }

            //Country
            if (country.Length > 0)
            {
                query = query + " and country in ('" + country.Replace(",", "','") + "')";
            }

            //State
            if (state.Length > 0)
            {
                query = query + " and cd1.State in ('" + state.Replace(",", "','") + "')";
            }

            //City
            if (city.Length > 0)
            {
                query = query + " and cityofresidence in ('" + city.Replace(",", "','") + "')";
            }

            //Mangalik
            if (manglik.Length > 0)
            {
                query = query + " and manglik in ('" + manglik.Replace(",", "','") + "')";
            }

            //Candidate Location
            if (candidateLocation.Length > 0)
            {
                query = query + " and cityofresidence in ('" + candidateLocation.Replace(",", "','") + "')";
            }

            //Candidate Mother Tongue
            if (motherTongue.Length > 0)
            {
                query = query + " and mothertongue in ('" + motherTongue.Replace(",", "','") + "')";
            }

            //Candidate Marital Status
            if (maritalStatus.Length > 0)
            {
                query = query + " and martialstatus in ('" + maritalStatus.Replace(",", "','") + "')";
            }

            query = query + " order by rowidbiodata desc"; //to get the latest profils first


            var conn = new SqlConnection(DAL.Global.SaatphereCon);
            var comm = new SqlCommand(query, conn);
            var adas = new SqlDataAdapter(comm);
            adas.Fill(dset);
           
            #endregion

            var dstResponse = dset;
            return dstResponse;
        }


        public DataTypes.PreferredPartner GetPreferredPartnerDetails(int biodataId)
        {
            var preferredPartnerDetails = new DataTypes.PreferredPartner();
            var dst = new DataSet();
            dst = new ClsCommon().GetDatasetonSQLQuery(Global.GetPreferredPartnerDetails.Replace("{BIODATACID}", biodataId.ToString()));

            if (dst.Tables[0].Rows.Count > 0)
            {
                preferredPartnerDetails.PreferredPartnerActive = Convert.ToBoolean(dst.Tables[0].Rows[0]["PreferredPartner_Active"]);
                preferredPartnerDetails.PreferredPartnerAgeFrom = dst.Tables[0].Rows[0]["PreferredPartner_AgeFrom"].ToString();
                preferredPartnerDetails.PreferredPartnerAgeTo = dst.Tables[0].Rows[0]["PreferredPartner_AgeTo"].ToString();
                preferredPartnerDetails.PreferredPartnerBiodataCid = Convert.ToInt32(dst.Tables[0].Rows[0]["PreferredPartner_BiodataCID"]);
                preferredPartnerDetails.PreferredPartnerCandidateLocation = dst.Tables[0].Rows[0]["PreferredPartner_CandidateLocation"].ToString();
                preferredPartnerDetails.PreferredPartnerCaste = dst.Tables[0].Rows[0]["PreferredPartner_Caste"].ToString();
                preferredPartnerDetails.PreferredPartnerCasteNoBar = dst.Tables[0].Rows[0]["PreferredPartner_CasteNoBar"].ToString();
                preferredPartnerDetails.PreferredPartnerCity = dst.Tables[0].Rows[0]["PreferredPartner_City"].ToString();
                preferredPartnerDetails.PreferredPartnerCountry = dst.Tables[0].Rows[0]["PreferredPartner_Country"].ToString();
                preferredPartnerDetails.PreferredPartnerCreatedBy = Convert.ToInt32(dst.Tables[0].Rows[0]["PreferredPartner_CreatedBy"]);
                preferredPartnerDetails.PreferredPartnerDateCreated = Convert.ToDateTime(dst.Tables[0].Rows[0]["PreferredPartner_DateCreated"]);
                preferredPartnerDetails.PreferredPartnerEducation = dst.Tables[0].Rows[0]["PreferredPartner_Education"].ToString();
                preferredPartnerDetails.PreferredPartnerHeightFrom = dst.Tables[0].Rows[0]["PreferredPartner_HeightFrom"].ToString();
                preferredPartnerDetails.PreferredPartnerHeightTo = dst.Tables[0].Rows[0]["PreferredPartner_HeightTo"].ToString();
                preferredPartnerDetails.PreferredPartnerIncome = dst.Tables[0].Rows[0]["PreferredPartner_Income"].ToString();
                preferredPartnerDetails.PreferredPartnerMangalik = dst.Tables[0].Rows[0]["PreferredPartner_Mangalik"].ToString();
                preferredPartnerDetails.PreferredPartnerOccupation = dst.Tables[0].Rows[0]["PreferredPartner_Occupation"].ToString();
                preferredPartnerDetails.PreferredPartnerReligion = dst.Tables[0].Rows[0]["PreferredPartner_Religion"].ToString();
                preferredPartnerDetails.PreferredPartnerState = dst.Tables[0].Rows[0]["PreferredPartner_State"].ToString();
                preferredPartnerDetails.PreferredPartnerMaritalStatus = dst.Tables[0].Rows[0]["PreferredPartner_MaritalStatus"].ToString();
                preferredPartnerDetails.PreferredPartnerMotherTongue = dst.Tables[0].Rows[0]["PreferredPartner_MotherTongue"].ToString();
            }

            return preferredPartnerDetails;
        }


        /// <summary>
        /// Returns True or False based on the Credentials provided
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="
        /// ">Password</param>
        /// <param name="loginType">Type of User</param>
        /// <returns></returns>
        public bool IsUserAuthenticated(string username, string password, LoginAs loginType)
        {
            bool response = false;
            var saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);

            if (loginType == LoginAs.Administrator)
            {
                var query = saatphere.AdminLogins.SingleOrDefault(a => a.UserName.ToLower().Equals(username.ToLower()) && a.Password.Equals(password));
                if (query != null)
                {
                    response = true;
                }
            }
            else if (loginType == LoginAs.Customer)
            {
                var query = saatphere.userlogins.SingleOrDefault(a => a.CustomerUserName.ToLower().Equals(username.ToLower()) && a.CustomerPassword.Equals(password));
                if (query != null)
                {
                    response = true;
                }
            }
            else if (loginType == LoginAs.Franchisee)
            {
                var query = saatphere.FranchiseeLoginMasters.SingleOrDefault(a => a.FranchiseeUserName.ToLower().Equals(username.ToLower()) && a.FranchiseePassword.Equals(password) && a.Status.Equals('A'));
                               
                if (query != null)
                {
                    response = true;
                }
            }
            return response;
        }

        public int GetActualRowIDfromUsername(string username)
        {
            var saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var response = saatphere.userlogins.SingleOrDefault(a => a.CustomerUserName.ToLower().Equals(username.ToLower()));
            return Convert.ToInt32(response.ActualRowID);
        }

        public string GetGenderfromActualRowId(int actualRowId)
        {
            var saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var resGender = string.Empty;

            var response = saatphere.BioDatas.SingleOrDefault(a => a.RowIDBioData.Equals(actualRowId));
            if (response != null)
            {
                resGender = response.Gender;
            }
            return resGender;
        }

        public string GetCandidateFranchiseeName(int candidateId)
        {
            var response = string.Empty;

            try
            {
                var saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);

                var query = (from b in saatphere.BioDatas
                             join flm in saatphere.FranchiseeLoginMasters on b.FranchiseeUserName equals flm.FrRowID.ToString()
                             where b.RowIDBioData == candidateId

                             select new
                             {
                                 flm.FranchiseeUserName
                             }).SingleOrDefault();
                response = query?.FranchiseeUserName;
            }
            catch (Exception)
            {
                //if exception then use the mumbaioffice location 
                response = "mumbaioffice";
            }
                        
            return response;
        }

        public int GetFranchiseeRowIDfromUsername(string username)
        {
            var res = 0;
            var saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var response = saatphere.FranchiseeLoginMasters.SingleOrDefault(a => a.FranchiseeUserName.ToLower().Equals(username.ToLower()));
            if (response != null)
                res = Convert.ToInt32(response.FrRowID);

            return res;
        }

        public DataSet GetDuplicateId(string emailAddress, string mobileNumber, string filterType)
        {
            var filter = string.Empty;

            if (emailAddress.Length > 0 && mobileNumber.Length > 0)
            {
                filter = (filterType == "LIKE") ? Global.EmailMobileFilterLike.Replace("{EMAILADDRESS}", emailAddress).Replace("{MOBILENUMBER}", mobileNumber) : Global.EmailMobileFilterEquals.Replace("{EMAILADDRESS}", emailAddress).Replace("{MOBILENUMBER}", mobileNumber);
            }
            else if (emailAddress.Length > 1)
            {
                filter = (filterType == "LIKE") ? Global.EmailFilterLike.Replace("{EMAILADDRESS}", emailAddress) : Global.EmailFilterEquals.Replace("{EMAILADDRESS}", emailAddress);
            }
            else if (mobileNumber.Length > 1)
            {
                filter = (filterType == "LIKE") ? Global.MobileFilterLike.Replace("{MOBILENUMBER}", mobileNumber) : Global.MobileFilterEquals.Replace("{MOBILENUMBER}", mobileNumber);
            }

            var con = new SqlConnection(SaatphereWIN.DAL.Global.SaatphereCon);
            var query = "select Rowidbiodata, FirstName, Gender, Email, Mobile, Membershiptype, (Select convert(varchar, FranchiseeUserName) From FranchiseeLoginMaster where convert(varchar, FrRowid) = BioData.FranchiseeUserName)'Created By' from biodata where " + filter + " and  FranchiseeUserName in (select convert(varchar, FrRowId) from franchiseeloginmaster)";

            var dad = new SqlDataAdapter(query, con);
            var dst = new DataSet();
            dad.Fill(dst);

            return dst;
        }

        public int CountUsers()
        {
            var saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.userlogins.Count();
            return Convert.ToInt32(query);
        }

        public int GetMaxTemp1Id()
        {
            return Convert.ToInt32(new ClsCommon().GetDatasetonSQLQuery(Global.Gettempvalue, DAL.Global.SaatphereCon).Tables[0].Rows[0][0]);
        }

        public static void IsPaidMember(int profileId, out string customerName, out bool response)
        {
            response = false;
            customerName = string.Empty;

            var saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.BioDatas.SingleOrDefault(a => a.RowIDBioData.Equals(profileId));
            if (query != null)
            {
                if (query.Membershiptype != "Registered")
                {
                    response = true;
                }
                customerName = query.Firstname + " " + query.MiddleName + " " + query.LastDate;
            }
            saatphere.Dispose();
        }

        public static bool IsPaidMember(int profileId)
        {
            var response = false;
            var saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.BioDatas.SingleOrDefault(a => a.RowIDBioData.Equals(profileId));
            if (query != null)
            {
                if (query.Membershiptype != "Registered")
                {
                    response = true;
                }
            }
            saatphere.Dispose();
            return response;
        }

        public string GetLastDate(int profileId)
        {
            var lastdate = string.Empty;
            var saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.BioDatas.SingleOrDefault(a => a.RowIDBioData.Equals(profileId));
            if (query != null)
            {
                lastdate = query.LastDate;
            }
            saatphere.Dispose();
            return lastdate;
        }

        public string GetMembershipType(int profileId)
        {
            var membershiptype = string.Empty;
            var saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.BioDatas.SingleOrDefault(a => a.RowIDBioData.Equals(profileId));
            if (query != null)
            {
                membershiptype = query.Membershiptype.ToString();
            }
            saatphere.Dispose();
            return membershiptype;
        }

        public DataSet GetBiodataFromId(int bioDataId)
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.Getbiodata.Replace("{BIODATAID}", bioDataId.ToString()));
        }

        public DataTypes.Biodata GetBiodataFromID_1(int bioDataId)
        {
            var dst = new DataSet();
            var biodataDetails = new DataTypes.Biodata();

            dst = new ClsCommon().GetDatasetonSQLQuery(Global.Getbiodata.Replace("{BIODATAID}", bioDataId.ToString()));
            biodataDetails.RowIdBiodata = Convert.ToInt32(dst.Tables[0].Rows[0]["rowidbiodata"]);
            biodataDetails.SurName = dst.Tables[0].Rows[0]["surname"].ToString();
            biodataDetails.FirstName = dst.Tables[0].Rows[0]["firstname"].ToString();
            biodataDetails.MiddleName = dst.Tables[0].Rows[0]["middlename"].ToString();
            biodataDetails.Gender = dst.Tables[0].Rows[0]["gender"].ToString();
            biodataDetails.Height = dst.Tables[0].Rows[0]["height"].ToString();
            biodataDetails.DateofBirth = dst.Tables[0].Rows[0]["dateofbirth"].ToString();
            biodataDetails.PlaceofBirth = dst.Tables[0].Rows[0]["placeofbirth"].ToString();
            biodataDetails.CityofResidence = dst.Tables[0].Rows[0]["cityofresidence"].ToString();
            biodataDetails.Country = dst.Tables[0].Rows[0]["country"].ToString();
            biodataDetails.CitypCode = dst.Tables[0].Rows[0]["citypcode"].ToString();
            biodataDetails.ResidenceNo = dst.Tables[0].Rows[0]["residenceno"].ToString();
            biodataDetails.OfficepCode = dst.Tables[0].Rows[0]["officepcode"].ToString();
            biodataDetails.OfficeNo = dst.Tables[0].Rows[0]["officeno"].ToString();
            biodataDetails.Email = dst.Tables[0].Rows[0]["email"].ToString();
            biodataDetails.PinCode = dst.Tables[0].Rows[0]["pincode"].ToString();
            biodataDetails.Mobile = dst.Tables[0].Rows[0]["mobile"].ToString();
            biodataDetails.Age = dst.Tables[0].Rows[0]["age"].ToString();
            biodataDetails.BiodataCreatedBy = dst.Tables[0].Rows[0]["biodatacreatedby"].ToString();
            biodataDetails.MaritalStatus = dst.Tables[0].Rows[0]["martialstatus"].ToString();
            biodataDetails.MarriedBrothers = dst.Tables[0].Rows[0]["marriedbrothers"].ToString();
            biodataDetails.UnmarriedBrother = dst.Tables[0].Rows[0]["unmarriedbrother"].ToString();
            biodataDetails.MarriedSister = dst.Tables[0].Rows[0]["marriedsister"].ToString();
            biodataDetails.UnmarriedSister = dst.Tables[0].Rows[0]["unmarriedsister"].ToString();
            biodataDetails.NumberofChildren = dst.Tables[0].Rows[0]["numberofchildren"].ToString();
            biodataDetails.EducationStatus = dst.Tables[0].Rows[0]["educationstatus"].ToString();
            biodataDetails.Complextion = dst.Tables[0].Rows[0]["complxtion"].ToString();
            biodataDetails.AboutMother = dst.Tables[0].Rows[0]["aboutmother"].ToString();
            biodataDetails.AboutFather = dst.Tables[0].Rows[0]["aboutfather"].ToString();
            biodataDetails.BodyType = dst.Tables[0].Rows[0]["bodytype"].ToString();
            biodataDetails.PhysicallyChallenged = dst.Tables[0].Rows[0]["phusicallychallenged"].ToString();
            biodataDetails.TimeofBirthH = dst.Tables[0].Rows[0]["timeofbirthH"].ToString();
            biodataDetails.TimeofBirthM = dst.Tables[0].Rows[0]["timeofbirthM"].ToString();
            biodataDetails.Occupation = dst.Tables[0].Rows[0]["occupation"].ToString();
            biodataDetails.AnnualIncome = dst.Tables[0].Rows[0]["annualincome"].ToString();
            biodataDetails.Religion = dst.Tables[0].Rows[0]["religion"].ToString();
            biodataDetails.Caste = dst.Tables[0].Rows[0]["caste"].ToString();
            biodataDetails.Gotra = dst.Tables[0].Rows[0]["gotra"].ToString();
            biodataDetails.Manglik = dst.Tables[0].Rows[0]["manglik"].ToString();
            biodataDetails.Mothertongue = dst.Tables[0].Rows[0]["mothertongue"].ToString();
            biodataDetails.Diet = dst.Tables[0].Rows[0]["diet"].ToString();
            biodataDetails.Hearaboutus = dst.Tables[0].Rows[0]["hearaboutus"].ToString();
            biodataDetails.ExpectedPartner = dst.Tables[0].Rows[0]["expectedpartner"].ToString();
            biodataDetails.MoreaboutCandidate = dst.Tables[0].Rows[0]["moreaboutcandidate"].ToString();
            biodataDetails.Remark = dst.Tables[0].Rows[0]["remark"].ToString();
            biodataDetails.Photograph = dst.Tables[0].Rows[0]["photograph"].ToString();
            biodataDetails.Status = dst.Tables[0].Rows[0]["status"].ToString();
            biodataDetails.FranchiseeUserName = dst.Tables[0].Rows[0]["franchiseeusername"].ToString();
            biodataDetails.Membershiptype = dst.Tables[0].Rows[0]["membershiptype"].ToString();
            biodataDetails.Validity = dst.Tables[0].Rows[0]["validity"].ToString();
            biodataDetails.ValidityLeft = dst.Tables[0].Rows[0]["validityleft"].ToString();
            biodataDetails.StartDate = dst.Tables[0].Rows[0]["startdate"].ToString();
            biodataDetails.UpdateDate = dst.Tables[0].Rows[0]["updatedate"].ToString();
            biodataDetails.LastDate = dst.Tables[0].Rows[0]["lastdate"].ToString();
            biodataDetails.SubCaste = dst.Tables[0].Rows[0]["subcaste"].ToString();
            biodataDetails.CastenoBar = dst.Tables[0].Rows[0]["castenobar"].ToString();
            biodataDetails.AboutCandidateFamily = dst.Tables[0].Rows[0]["aboutcandidatefamily"].ToString();

            if (dst.Tables[0].Rows[0]["registerationdate"] != null && dst.Tables[0].Rows[0]["registerationdate"].ToString().Length > 0)
            {
                biodataDetails.RegistrationDate = Convert.ToDateTime(dst.Tables[0].Rows[0]["registerationdate"].ToString());
            }

            if (dst.Tables[0].Rows[0]["Biodata_active"] != null && dst.Tables[0].Rows[0]["Biodata_active"].ToString().Length > 0)
            {
                biodataDetails.Active = Convert.ToBoolean(dst.Tables[0].Rows[0]["Biodata_active"]);
            }

            if(dst.Tables[0].Rows[0]["Biodata_unsubscribeemailstatus"].ToString().Length >0)
                biodataDetails.UnsubscribeEmailStatus = Convert.ToBoolean(dst.Tables[0].Rows[0]["Biodata_unsubscribeemailstatus"]);
            
            if(dst.Tables[0].Rows[0]["Biodata_visibleoutside"].ToString().Length > 0)
                biodataDetails.VisibleOutside = Convert.ToBoolean(dst.Tables[0].Rows[0]["Biodata_visibleoutside"]);

            biodataDetails.CandidateLocation = dst.Tables[0].Rows[0]["Biodata_candidatelocation"].ToString();
            biodataDetails.BloodGroup = dst.Tables[0].Rows[0]["Biodata_bloodgroup"].ToString();
            biodataDetails.HoroscopeMatchingRequirement = dst.Tables[0].Rows[0]["Biodata_horoscopematchingrequirement"].ToString();

            if (dst.Tables[0].Rows[0]["Biodata_approved"].ToString().Length > 0)
            {
                biodataDetails.Approved = Convert.ToBoolean(dst.Tables[0].Rows[0]["Biodata_approved"]);
            }


            biodataDetails.EducationDetails = dst.Tables[0].Rows[0]["Biodata_educationdetails"].ToString();
            biodataDetails.OccupationDetails = dst.Tables[0].Rows[0]["Biodata_occupationdetails"].ToString();
            biodataDetails.FatherDetails = dst.Tables[0].Rows[0]["Biodata_fatherdetails"].ToString();
            biodataDetails.MotherDetails = dst.Tables[0].Rows[0]["Biodata_motherdetails"].ToString();
            biodataDetails.SisterDetails = dst.Tables[0].Rows[0]["Biodata_sisterdetails"].ToString();
            biodataDetails.BrotherDetails = dst.Tables[0].Rows[0]["Biodata_brotherdetails"].ToString();
            biodataDetails.CandidateOtherDetails = dst.Tables[0].Rows[0]["Biodata_candidateotherdetails"].ToString();
            biodataDetails.Source = dst.Tables[0].Rows[0]["Biodata_source"].ToString();
            biodataDetails.Email2 = dst.Tables[0].Rows[0]["Biodata_email2"].ToString();

            if (dst.Tables[0].Rows[0]["Biodata_visibleinside"].ToString().Length > 0)
                biodataDetails.VisibleInside = Convert.ToBoolean(dst.Tables[0].Rows[0]["Biodata_visibleinside"]);
            
            biodataDetails.LastUpdateBio = dst.Tables[0].Rows[0]["Biodata_lastupdatebio"].ToString();
            biodataDetails.RejectReason = dst.Tables[0].Rows[0]["Biodata_rejectreason"].ToString();
            biodataDetails.SentBy = dst.Tables[0].Rows[0]["Biodata_sentby"].ToString();
            biodataDetails.ReceivedMode = dst.Tables[0].Rows[0]["Biodata_receivedmode"].ToString();
            biodataDetails.ReceivedOn = dst.Tables[0].Rows[0]["Biodata_receivedon"].ToString();
            biodataDetails.HighestDegree = dst.Tables[0].Rows[0]["Biodata_highestdegree"].ToString();
            biodataDetails.ResidentialAddress = dst.Tables[0].Rows[0]["residentialaddress"].ToString();

            if(dst.Tables[0].Rows[0]["Biodata_executive"].ToString().Length > 0)
                biodataDetails.Executive = Convert.ToInt32(dst.Tables[0].Rows[0]["Biodata_executive"]);

            biodataDetails.BiodataLocality = dst.Tables[0].Rows[0]["biodata_locality"].ToString();

            if(dst.Tables[0].Rows[0]["biodata_believeinhoroscopematching"].ToString().Length >0)
                biodataDetails. BiodataBelieveinHoroscopeMatching = Convert.ToBoolean(dst.Tables[0].Rows[0]["biodata_believeinhoroscopematching"]);

            if(dst.Tables[0].Rows[0]["biodata_NRIacceptable"].ToString().Length > 0)
                biodataDetails. BiodataNriAcceptable = Convert.ToBoolean( dst.Tables[0].Rows[0]["biodata_NRIacceptable"]);
            
            if(dst.Tables[0].Rows[0]["biodata_weight"].ToString().Length >0)
                biodataDetails.BiodataWeight = Convert.ToDecimal( dst.Tables[0].Rows[0]["biodata_weight"]);           

            return biodataDetails;
        }

        public DataSet GetBiodataContactDetailFromId(int bioDataId)
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.Getbiodatacontactdetail.Replace("{ID}", bioDataId.ToString()));
        }

        public DataTypes.ContactDetail GetBiodataContactDetailFromID_1(int bioDataId)
        {
            var dst = new DataSet();
            var contactDetail = new DataTypes.ContactDetail();
            dst = new DAL.ClsCommon().GetDatasetonSQLQuery(Global.Getbiodatacontactdetail.Replace("{ID}", bioDataId.ToString()));

            contactDetail.ContactDetailRowId = Convert.ToInt32(dst.Tables[0].Rows[0]["contactdetailrowid"]);
            contactDetail.Name = dst.Tables[0].Rows[0]["name"].ToString();
            contactDetail.AddressLine1 = dst.Tables[0].Rows[0]["addressline1"].ToString();
            contactDetail.AddressLine2 = dst.Tables[0].Rows[0]["addressline2"].ToString();
            contactDetail.City = dst.Tables[0].Rows[0]["city"].ToString();
            contactDetail.Pincode = dst.Tables[0].Rows[0]["pincode"].ToString();
            contactDetail.CountryUser = dst.Tables[0].Rows[0]["countryuser"].ToString();
            contactDetail.Telephone1 = dst.Tables[0].Rows[0]["telephone1"].ToString();
            contactDetail.Telephone2 = dst.Tables[0].Rows[0]["telephone2"].ToString();
            contactDetail.Mobile = dst.Tables[0].Rows[0]["mobile"].ToString();
            contactDetail.EmailUser = dst.Tables[0].Rows[0]["emailuser"].ToString();
            contactDetail.CityP2Code = dst.Tables[0].Rows[0]["cityp2code"].ToString();
            contactDetail.CityPCode = dst.Tables[0].Rows[0]["citypcode"].ToString();
            contactDetail.State = dst.Tables[0].Rows[0]["state"].ToString();
            contactDetail.CreatedBy = dst.Tables[0].Rows[0]["createdby"].ToString();
            contactDetail.ContactPersonName = dst.Tables[0].Rows[0]["contactpersonname"].ToString();
            contactDetail.ContactDetailActive = Convert.ToBoolean(dst.Tables[0].Rows[0]["contactdetail_active"]);
            contactDetail.EmailUser2 = dst.Tables[0].Rows[0]["emailuser2"].ToString();

            return contactDetail;
        }

        public DataSet GetLastBiodata()
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.GetLastBiodata);
        }

    }
}
