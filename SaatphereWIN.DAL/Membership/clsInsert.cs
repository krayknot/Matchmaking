using System;
using SaatphereWIN.DAL.DBClass;
using System.Data.SqlClient;

namespace SaatphereWIN.DAL.Membership
{
    public class ClsInsert
    {
        
        public void InsertProfileMatchLog(int receiverCid, string receiverEmail, string receiverEmail2, DateTime profileSendDate, int sentProfileCid)
        {
            var saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon); //For local version
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

        /// <summary>
        /// Saves the log after sending the Profiles with addresses to the Customer
        /// </summary>
        /// <param name="profileId">Customer to whom the profiles are sending with Address</param>
        /// <param name="ProfileName">Name of the Customer</param>
        /// <param name="profileChoiceId">Result Profile Id</param>
        /// <param name="ProfileChoiceName">Result Profile Name</param>
        public void InsertProfileSentLog(int profileId, int profileChoiceId)
        {
            //Format the id
            ClsSelect select = new ClsSelect();
            var profileName = select.GetProfileFirstNamefromProfileCID(profileId).Substring(0, 1);
            var profileChoiceName = select.GetProfileFirstNamefromProfileCID(profileChoiceId).Substring(0, 1);

            var date = String.Format("{0:d}", DateTime.Now);

            //string biodataUpdateQuery = "update biodata set validityleft = validityleft-1 where RowIDBioData= " + ProfileID;
            var finalviewInsertQuery = "insert into finalView values('" + profileName + profileId + "','" + profileChoiceName + profileChoiceId + "','" + date + "')";
            var storedProcedureQuery = "Exec insert_cust_account '" + date + "', " + profileId + ", '', " + profileChoiceId + ",''";
            //In saatphere each user to whom the address is sending is marked as favorite so that he could get easily tracked in future
            var favoriteCustomerInsertQuery = "insert into favouritecustomer values('" + profileName + profileId + "','" + profileChoiceName + profileChoiceId + "','" + date + "')";

            var update = new clsUpdate();
            update.UpdateValidityLeft(profileId);

            //SqlConnection con = new SqlConnection(clsGlobal.dbConnectionString);

            //----------------------------------------------------------------------------------------------------
            //Author: kshtiij - 24th Feb 2015
            //Here we need to maintain the profile sent log both on the server and on the local 
            //The variable dbConnectionString containst the local system's connectionstring and the 
            //dbConnectionString_Exception contins the server connectionstring.
            //Profile sent log has to be same so that the searching results for both the servers local and online
            //should be the same.
            //----------------------------------------------------------------------------------------------------
            //==============================SERVER TRANSACTION====================================================
            var con = new SqlConnection(DAL.Global.SaatphereCon); //For local version
            var cmd = new SqlCommand();

            cmd.Connection = con;

            cmd.CommandText = finalviewInsertQuery;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            cmd.CommandText = storedProcedureQuery;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            cmd.CommandText = favoriteCustomerInsertQuery;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            con.Dispose();

            //=============================LOCAL TRANSACTION====================================================
            var conLocal = new SqlConnection(DAL.Global.SaatphereCon); //For local version
            var cmdLocal = new SqlCommand();

            cmdLocal.Connection = conLocal;

            cmdLocal.CommandText = finalviewInsertQuery;
            conLocal.Open();
            cmdLocal.ExecuteNonQuery();
            conLocal.Close();

            cmdLocal.CommandText = storedProcedureQuery;
            conLocal.Open();
            cmdLocal.ExecuteNonQuery();
            conLocal.Close();

            cmdLocal.CommandText = favoriteCustomerInsertQuery;
            conLocal.Open();
            cmdLocal.ExecuteNonQuery();
            conLocal.Close();

            conLocal.Dispose();
            //----------------------------------------------------------------------------------------------------
        }


        public void InsertMembershipHistory(DataTypes.Biodata biodataDetails)
        {
            var saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);            
            var query = new MembershipHistory
            {
                MembershipHistory_Active = true,
                MembershipHistory_DateCreated = DateTime.Now,
                MembershipHistory_FranchiseeUserName = biodataDetails.FranchiseeUserName,
                MembershipHistory_LastDate = Convert.ToDateTime(biodataDetails.LastDate),
                MembershipHistory_MembershipType = biodataDetails.Membershiptype,
                MembershipHistory_RowIDBiodata = biodataDetails.RowIdBiodata,
                MembershipHistory_StartDate = Convert.ToDateTime(biodataDetails.StartDate),
                MembershipHistory_Status = biodataDetails.Status,
                MembershipHistory_Validity = biodataDetails.Validity,
                MembershipHistory_ValidityLeft = biodataDetails.ValidityLeft
            };
            saatphere.MembershipHistories.InsertOnSubmit(query);
            
        }
    }
}
