using System;
using System.Linq;
using SaatphereWIN.DAL.DBClass;
using System.Data;
using System.Globalization;

namespace SaatphereWIN.DAL.Membership
{
    public class ClsSelect : ClsCommon
    {
        public DataSet Chart_GetBiodataCount()
        {
            var dst = new DataSet();
            dst = new ClsCommon().GetDatasetonSQLQuery(Global.MainScreen_Chart_BiodataCount);
            return dst;
        }

        public DataSet DSR_ShowAllReport(string franchiseeName)
        {
            if (franchiseeName.Contains("mumbai"))
            {
                franchiseeName = "Mumbai Office";
            }

            if (franchiseeName.Contains("andheri"))
            {
                franchiseeName = "Andheri Office";
            }

            if (franchiseeName.Contains("jaipur"))
            {
                franchiseeName = "Jaipur Office";
            }

            if (franchiseeName.Contains("pune"))
            {
                franchiseeName = "Pune Office";
            }

            if (franchiseeName.Contains("swargateoffice"))
            {
                franchiseeName = "Swargate Office";
            }

            if (franchiseeName.Contains("indoreoffice"))
            {
                franchiseeName = "Indore Office";
            }


            var dst = new DataSet();
            dst = new ClsCommon().GetDatasetonSQLQuery(Global.DSR_ShowAllReport.Replace("{FRANCHISEE}", franchiseeName));
            return dst;
        }


        public DataSet GetUsersfromDates(DateTime fromDate, DateTime toDate, string status)
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.PSEND_SQL_GETUSERSFROMDATE.Replace("{FROMDATE}", fromDate.ToString("MM/dd/yyyy")).Replace("{TODATE}", toDate.ToString("MM/dd/yyyy")).Replace("{PSSTATUS}", status));
        }

        public DataSet GetUsersFromName(string userName)
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.PSEND_SQL_GETUSERSFROMNAME.Replace("{NAME}", userName));
        }

        public DataSet GetUserInfofromRowIdBiodata(int profileId)
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.GetUserInfofromRowIDBiodata.Replace("{PROFILEID}", profileId.ToString()));
        }

        public DataSet SearchQueuebyStatus(string status)
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.SearchQueuebyStatus.Replace("{STATUS}", status));
        }

        public DataSet GetQueuebyDate(DateTime dateofQueue)
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.PSEND_SQL_GETQUEUEFROMDATE.Replace("{DATE}", dateofQueue.ToString("MM/dd/yyyy")));
        }

        public DataSet GetQueuebyDate(DateTime dateofQueue, int franchiseeId)
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.PSEND_SQL_GETQUEUEFROMDATE_USERWISE.Replace("{DATE}", dateofQueue.ToString("MM/dd/yyyy")).Replace("{FRANCHISEEID}", franchiseeId.ToString()));
         }

        public string GetQueuebyDateCount(DateTime DateofQueue, int FranchiseeID)
        {
            string response = string.Empty;

            DataSet dst = new DataSet();
            dst = new ClsCommon().GetDatasetonSQLQuery(Global.PSEND_SQL_GETQUEUEFROMDATE_USERWISE_COUNT.Replace("{DATE}", DateofQueue.ToString("MM/dd/yyyy")).Replace("{FRANCHISEEID}", FranchiseeID.ToString()));

            if (dst.Tables[0].Rows[0][0] == null)
            {
                response = "0";
            }
            else
            {
                response =dst.Tables[0].Rows[0][0].ToString();
            }

            return response;
        }

        /// <summary>
        /// Returns Profile First Name on the basis of the Profile ID
        /// </summary>
        /// <param name="ProfileCID">Profile ID</param>
        /// <returns>Profile First Name</returns>
        public string GetProfileFirstNamefromProfileCID(int ProfileCID)
        {
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.BioDatas.Where(a => a.RowIDBioData.Equals(ProfileCID)).SingleOrDefault();
            string response = string.Empty;

            if (query != null)
            {
                response = query.Firstname.ToString();
            }
            saatphere.Dispose();
            return response;
        }

        public bool GetAlreadyTakenDetails(int ProfileID, int ProfileChoiceId)
        {
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(SaatphereWIN.DAL.Global.SaatphereCon);
            bool response = false;
            string ProfileName = new SaatphereWIN.DAL.User.ClsSelect().GetProfileFirstNamefromProfileCid(ProfileID);
            if (ProfileName.Length > 0) //to check if the profile exists in the database or not
            {
                ProfileName = ProfileName.Substring(0, 1);
                string ProfileChoiceName = GetProfileFirstNamefromProfileCID(ProfileChoiceId).Substring(0, 1);
                var query = saatphere.FavouriteCustomers.Where(a => a.CustomerId.Equals(ProfileName + ProfileID.ToString()) && a.ChoiceId.Equals(ProfileChoiceName + ProfileChoiceId.ToString())).FirstOrDefault();
                if (query != null)
                {
                    response = true;
                }
            }
            else
            {
                response = false;
            }
            return response;
        }


        /// <summary>
        /// Checks the membership status
        /// </summary>
        /// <param name="ProfileID">User Profile id</param>
        /// <returns></returns>
        public bool IsMembershipExpired(int ProfileID)
        {
            string lastdate = string.Empty;
            bool response = false;
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.BioDatas.Where(a => a.RowIDBioData.Equals(ProfileID)).SingleOrDefault();
            if (query != null)
            {
                if (query.LastDate != null)
                {
                    lastdate = query.LastDate.ToString();
                }
                else
                {
                    response = true; //It means an unpaid member or membership has expired
                }
            }
            saatphere.Dispose();

            if (lastdate.Length > 0)
            {
                DateTime ldate = DateTime.Now;
                try
                {
                    ldate = DateTime.Parse(lastdate);
                }
                catch (Exception)
                {
                    try
                    {
                        ldate = DateTime.ParseExact(lastdate, "M/d/yyyy", null);
                    }
                    catch (Exception)
                    {
                        //to do
                    }
                }

                string date1 = DateTime.Now.ToString("M/d/yyyy");
                DateTime date2;
                try
                {
                    date2 = DateTime.Parse(date1);
                }
                catch (Exception)
                {
                    date2 = DateTime.ParseExact(date1, "M/d/yyyy", null);
                }


                DateTime lastdate2 = ldate.AddDays(5);
                //if (ldate == ldate.AddDays(5))
                if (lastdate2 <= date2)
                {
                    response = true;
                }
            }
            return response;
        }

        /// <summary>
        /// Whether the user is a Paid member or not
        /// </summary>
        /// <param name="ProfileID">User Profile ID</param>
        /// <returns></returns>
        public bool IsPaidMember(int ProfileID)
        {
            bool response = false;
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.BioDatas.Where(a => a.RowIDBioData.Equals(ProfileID)).SingleOrDefault();
            if (query != null)
            {
                //DateTime lastMembershipDate = new DateTime();

                int daysLeft = 0;
                string lmDate = string.Empty;

                //check the Last date field on the basis of dash - and slash / and create a date
                if (query.LastDate != null)
                {
                    if (query.LastDate.Contains("/"))
                    {
                        lmDate = query.LastDate.Replace("/", "-");
                    }
                    else if (query.LastDate.Contains("\\"))
                    {
                        lmDate = query.LastDate.Replace("\\", "-");
                    }
                    else
                    {
                        lmDate = query.LastDate;
                    }
                }

                if (query.LastDate != null)
                {
                    if (query.LastDate.Length < 1)
                    {
                        response = false;
                    }
                    else
                    {
                        DateTime dt = DateTime.ParseExact(lmDate, "MM-dd-yyyy", CultureInfo.InstalledUICulture);
                        daysLeft = (int)(dt.Date - DateTime.Now.Date).TotalDays;
                    }

                    if (daysLeft > 0)
                    {
                        response = true;
                    }
                }
                else
                {
                    response =false;
                }

                //if (query.Membershiptype != "Registered")
                //{
                //    response = true;
                //}
            }
            saatphere.Dispose();
            return response;
        }


        public DataTypes.PreferredPartner GetPreferredPartnerDetailsfromBiodataCID(int BiodataCID)
        {
            SaatphereWIN.DAL.DataTypes.PreferredPartner preferredPartnerDetails = new DataTypes.PreferredPartner();

            DataSet dst = new DataSet ();
            dst = new SaatphereWIN.DAL.ClsCommon().GetDatasetonSQLQuery(Global.GETPREFERREDPARTNERDETAILS.Replace("{BIODATACID}", BiodataCID.ToString()));

            if (dst.Tables[0].Rows.Count > 0)
            {
                preferredPartnerDetails.PreferredPartnerAgeFrom = dst.Tables[0].Rows[0]["PreferredPartner_AgeFrom"].ToString();
                preferredPartnerDetails.PreferredPartnerAgeTo = dst.Tables[0].Rows[0]["PreferredPartner_AgeTo"].ToString();
                preferredPartnerDetails.PreferredPartnerHeightFrom = dst.Tables[0].Rows[0]["PreferredPartner_HeightFrom"].ToString();
                preferredPartnerDetails.PreferredPartnerHeightTo = dst.Tables[0].Rows[0]["PreferredPartner_HeightTo"].ToString();
                preferredPartnerDetails.PreferredPartnerReligion = dst.Tables[0].Rows[0]["PreferredPartner_Religion"].ToString();
                preferredPartnerDetails.PreferredPartnerCaste = dst.Tables[0].Rows[0]["PreferredPartner_Caste"].ToString();
                preferredPartnerDetails.PreferredPartnerCasteNoBar = dst.Tables[0].Rows[0]["PreferredPartner_CasteNoBar"].ToString();
                preferredPartnerDetails.PreferredPartnerEducation = dst.Tables[0].Rows[0]["PreferredPartner_Education"].ToString();
                preferredPartnerDetails.PreferredPartnerOccupation = dst.Tables[0].Rows[0]["PreferredPartner_Occupation"].ToString();
                preferredPartnerDetails.PreferredPartnerIncome = dst.Tables[0].Rows[0]["PreferredPartner_Income"].ToString();
                preferredPartnerDetails.PreferredPartnerCountry = dst.Tables[0].Rows[0]["PreferredPartner_Country"].ToString();
                preferredPartnerDetails.PreferredPartnerState = dst.Tables[0].Rows[0]["PreferredPartner_State"].ToString();
                preferredPartnerDetails.PreferredPartnerCity = dst.Tables[0].Rows[0]["PreferredPartner_City"].ToString();
                preferredPartnerDetails.PreferredPartnerMangalik = dst.Tables[0].Rows[0]["PreferredPartner_Mangalik"].ToString();
                preferredPartnerDetails.PreferredPartnerCandidateLocation = dst.Tables[0].Rows[0]["PreferredPartner_CandidateLocation"].ToString();
                preferredPartnerDetails.PreferredPartnerBiodataCid = Convert.ToInt32(dst.Tables[0].Rows[0]["PreferredPartner_BiodataCID"]);
                preferredPartnerDetails.PreferredPartnerDateCreated = Convert.ToDateTime(dst.Tables[0].Rows[0]["PreferredPartner_DateCreated"]);
                preferredPartnerDetails.PreferredPartnerCreatedBy = Convert.ToInt32(dst.Tables[0].Rows[0]["PreferredPartner_CreatedBy"]);
                preferredPartnerDetails.PreferredPartnerActive = Convert.ToBoolean(dst.Tables[0].Rows[0]["PreferredPartner_Active"]);
                preferredPartnerDetails.PreferredPartnerMotherTongue = dst.Tables[0].Rows[0]["PreferredPartner_MotherTongue"].ToString();
                preferredPartnerDetails.PreferredPartnerMaritalStatus = dst.Tables[0].Rows[0]["PreferredPartner_MaritalStatus"].ToString();
            }

            return preferredPartnerDetails;
        }

        public decimal GetMembershipPrice()
        {
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            decimal response = 0;

            var query = saatphere.Memberships.Where(a => a.MembershipType.Equals("Registered")).SingleOrDefault();
            if (query != null)
            {
                response = Convert.ToDecimal(query.Price);
            }
            saatphere.Dispose();
            return response;
        }

        public static DataSet GetMemberships()
        {
            return new DAL.ClsCommon().GetDatasetonSQLQuery(Global.GETMEMBERSHIPS);
        }

        public string GetProfileMembershipActivationDate(int ProfileID)
        {
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            string format = "d";
            CultureInfo provider = CultureInfo.InvariantCulture;
            string strDate = string.Empty;

            var query = saatphere.BioDatas.Where(a => a.RowIDBioData.Equals(ProfileID)).SingleOrDefault();
            if (query != null)
            {              
                strDate = query.StartDate;
            }
            return strDate;
        }

        public string getmembershiptypevalue(string membershiptype)
        {
            string value = string.Empty;

            if (membershiptype == "One Month")
            {
                value = "1";
            }
            if (membershiptype == "Two Months")
            {
                value = "2";
            }
            if (membershiptype == "Three Months")
            {
                value = "3";
            }
            if (membershiptype == "Four Months")
            {
                value = "4";
            }
            if (membershiptype == "Five Months")
            {
                value = "5";
            }
            if (membershiptype == "Six Months")
            {
                value = "6";
            }
            if (membershiptype == "Seven Months")
            {
                value = "7";
            }
            if (membershiptype == "Eight Months")
            {
                value = "8";
            }
            if (membershiptype == "Nine Months")
            {
                value = "9";
            }
            if (membershiptype == "Ten Months")
            {
                value = "10";
            }
            if (membershiptype == "Eleven Months")
            {
                value = "11";
            }
            if (membershiptype == "One Year")
            {
                value = "12";
            }
            if (membershiptype == "Thirteen Months")
            {
                value = "13";
            }
            if (membershiptype == "Fourteen Months")
            {
                value = "14";
            }

            return value;
        }

        public string getmembershiptypefromvalue(string membershiptypevalue)
        {
            string type = string.Empty;

            if (membershiptypevalue == "1")
            {
                type = "One Month";
            }
            if (membershiptypevalue == "2")
            {
                type = "Two Months";
            }
            if (membershiptypevalue == "3")
            {
                type = "Three Months";
            }
            if (membershiptypevalue == "4")
            {
                type = "Four Months";
            }
            if (membershiptypevalue == "5")
            {
                type = "Five Months";
            }
            if (membershiptypevalue == "6")
            {
                type = "Six Months";
            }
            if (membershiptypevalue == "7")
            {
                type = "Seven Months";
            }
            if (membershiptypevalue == "8")
            {
                type = "Eight Months";
            }
            if (membershiptypevalue == "9")
            {
                type = "Nine Months";
            }
            if (membershiptypevalue == "10")
            {
                type = "Ten Months";
            }
            if (membershiptypevalue == "11")
            {
                type = "Eleven Months";
            }
            if (membershiptypevalue == "12")
            {
                type = "One Year";
            }
            if (membershiptypevalue == "13")
            {
                type = "Thirteen Months";
            }
            if (membershiptypevalue == "14")
            {
                type = "Fourteen Months";
            }

            return type;
        }
    }
}
