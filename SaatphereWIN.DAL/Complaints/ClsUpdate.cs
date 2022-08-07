using System.Linq;

namespace SaatphereWIN.DAL.Complaints
{
    public class ClsUpdate
    {
        public void UpdateComplaintStatus(DataTypes.Complaint complaintDetails)
        {
            var saatphere = new DBClass.dcSaatphereDataContext(SaatphereWIN.DAL.Global.SaatphereCon);
            var query = saatphere.Complaints.SingleOrDefault(a => a.Complaint_CID.Equals(complaintDetails.ComplaintCid));
            if(query!= null)
            {                
                query.Complaint_Status = complaintDetails.ComplaintStatus;
                query.Complaint_Executive = complaintDetails.ComplaintExecutive;
            }
            saatphere.SubmitChanges();
            saatphere.Dispose();

        }
    }
}
