using System;

namespace SaatphereWIN.DAL.DataTypes
{
    public class Complaint
    {
        public int ComplaintCid {get;set;}
        public string ComplaintEscalated {get;set;}
        public string ComplaintStatus {get;set;}
        public string ComplaintPriority {get;set;}
        public int ComplaintIndividual {get;set;}
        public int ComplaintComplaint {get;set;}
        public string ComplaintCustomerName {get;set;}
        public string ComplaintCustomerContactNumber {get;set;}
        public string ComplaintCustomerEmailAddress {get;set;}
        public int ComplaintCustomerProfileId {get;set;}
        public string ComplaintRemarks {get;set;}
        public DateTime ComplaintDateCreated {get;set;}
        public int ComplaintCreatedBy {get;set;}
        public bool ComplaintActive { get; set; }
        public int ComplaintType { get; set; }
        public string ComplaintContactName { get; set; }
        public string ComplaintContactNumber { get; set; }
        public string ComplaintExecutive { get; set; }
    }
}
