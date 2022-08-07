using System;
using SaatphereWIN.DAL.DBClass;

namespace SaatphereWIN.DAL.Complaints
{
    public class ClsInsert
    {
        public void InsertTagging(DataTypes.Activity activityDetails)
        {
            var saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = new Activity
            {
                Activity_Active = true,
                Activity_DateTime = DateTime.Now,
                Activity_Details = activityDetails.ActivityDetails,
                Activity_FranchiseeID = activityDetails.ActivityFranchiseeId,
                Activity_ProfileID = activityDetails.ActivityProfileId,
                Activity_Type = activityDetails.ActivityType,
                Activity_Executive = activityDetails.ActivityExecutive
            };
            saatphere.Activities.InsertOnSubmit(query);
            saatphere.SubmitChanges();
            saatphere.Dispose();
        }

        public void InsertFollowUp(DataTypes.FollowUp followUpDetails)
        {
            var saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = new FollowUp
            {
                FollowUp_Active = followUpDetails.FollowUpActive,
                FollowUp_ActivityCID = followUpDetails.FollowUpActivityCid,
                FollowUp_CreatedBy = followUpDetails.FollowUpCreatedBy,
                FollowUp_DateCreated = followUpDetails.FollowUpDateCreated,
                FollowUp_DateTime = followUpDetails.FollowUpDateTime,
                FollowUp_ExecutiveID = followUpDetails.FollowUpExecutiveId
            };
            saatphere.FollowUps.InsertOnSubmit(query);
            saatphere.SubmitChanges();
            saatphere.Dispose();
        }

        public void InsertComplaint(DataTypes.Complaint complaintDetails)
        {
            var saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = new Complaint
            {
                Complaint_Active = complaintDetails.ComplaintActive,
                Complaint_Complaint = complaintDetails.ComplaintComplaint,
                Complaint_CreatedBy = complaintDetails.ComplaintCreatedBy,
                Complaint_CustomerContactNumber = complaintDetails.ComplaintCustomerContactNumber,
                Complaint_CustomerEmailAddress = complaintDetails.ComplaintCustomerEmailAddress,
                Complaint_CustomerName = complaintDetails.ComplaintCustomerName,
                Complaint_CustomerProfileID = complaintDetails.ComplaintCustomerProfileId,
                Complaint_DateCreated = complaintDetails.ComplaintDateCreated,
                Complaint_Escalated = complaintDetails.ComplaintEscalated,
                Complaint_Individual = complaintDetails.ComplaintIndividual,
                Complaint_Priority = complaintDetails.ComplaintPriority,
                Complaint_Remarks = complaintDetails.ComplaintRemarks,
                Complaint_Status = complaintDetails.ComplaintStatus  ,   
                Complaint_Type = complaintDetails.ComplaintType,
                Complaint_ContactName = complaintDetails.ComplaintContactName,
                Complaint_ContactNumber = complaintDetails.ComplaintContactNumber,
                Complaint_Executive = complaintDetails.ComplaintExecutive
            };
            saatphere.Complaints.InsertOnSubmit(query);
            saatphere.SubmitChanges();
            saatphere.Dispose();
        }

        public void InsertTagging(string activityDetails, int franchiseeId, int profileId, string executive)
        {
            var saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = new Activity
            {
                Activity_Active = true,
                Activity_DateTime = DateTime.Now,
                Activity_Details=  activityDetails,
                Activity_FranchiseeID = franchiseeId,
                Activity_ProfileID = profileId,
                Activity_Type = "COMPLAINT-TAGGING",
                Activity_Executive = executive
            };
            saatphere.Activities.InsertOnSubmit(query);
            saatphere.SubmitChanges();
            saatphere.Dispose();
        }

        public void InsertActivity(DataTypes.Activity activityDetails)
        {
            var saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = new Activity
            {
                Activity_Active = activityDetails.ActivityActive,
                Activity_DateTime = activityDetails.ActivityDateTime,
                Activity_Details = activityDetails.ActivityDetails,
                Activity_FranchiseeID = activityDetails.ActivityFranchiseeId,
                Activity_ProfileID = activityDetails.ActivityProfileId,
                Activity_Type = activityDetails.ActivityType,
                Activity_Executive = activityDetails.ActivityExecutive
            };
            saatphere.Activities.InsertOnSubmit(query);
            saatphere.SubmitChanges();
            saatphere.Dispose();
        }
    }
}
