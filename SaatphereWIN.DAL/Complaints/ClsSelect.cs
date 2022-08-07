using System;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace SaatphereWIN.DAL.Complaints
{
    public class ClsSelect
    {
        public string GetCustomerNamefromFollowUpId(int followupId)
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.GetCustomerNamefromFollowUpId.Replace("{FOLLOWUPID}", followupId.ToString())).Tables[0].Rows[0][0].ToString();    
        }

        public DataSet GetFollowUpbyFollowupId(int followUpId)
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.GetFollowupByFollowUpId.Replace("{FOLLOWUPID}", followUpId.ToString()));
        }

        public DataSet GetFollowUpbyId(int executiveId)
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.GetFollowupByExecutiveId.Replace("{FOLLOWUPID}", executiveId.ToString()));
        }

        public int GetMaxActivityId()
        {
            DBClass.dcSaatphereDataContext saatphere = new DBClass.dcSaatphereDataContext(DAL.Global.SaatphereCon);
            return (int)saatphere.Activities.Max(a => a.Activity_CID);
        }

        public DataSet GetActivityByActivityId(int activityId)
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.GetActivitybyActivityId.Replace("{ACTIVITYID}", activityId.ToString()));
        }


        public DataSet GetActivityByProfileId(int profileId)
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.GetActivitybyProfileId.Replace("{PROFILEID}", profileId.ToString()));
        }

        public DataSet GetComplaintTypes()
        {
            var con = new SqlConnection(DAL.Global.SaatphereCon);
            var dstComplaintType = new DataSet();
            var dad = new SqlDataAdapter(query, con);
            dad.Fill(dstComplaintType);
            con.Dispose();
            return dstComplaintType;
        }


        public int GetLastComplaintId()
        {
            var response = 0;
            var saatphere = new DBClass.dcSaatphereDataContext(SaatphereWIN.DAL.Global.SaatphereCon);
            var query = saatphere.Complaints.Max(a => a.Complaint_CID);
            response = Convert.ToInt32(query);
            return response;
        }

        public DataSet GetComplaints()
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.GetComplaints);
        }

        public DataSet GetComplaintsbyStatus(string complaintStatus)
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.GetComplaintsbyFilter.Replace("{COMPLAINTSTATUS}", complaintStatus));
        }

        public DataSet GetComplaintbyId(int complaintId)
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.GetComplaintbyId.Replace("{COMPLAINTID}", complaintId.ToString()));
        }
    }
}
