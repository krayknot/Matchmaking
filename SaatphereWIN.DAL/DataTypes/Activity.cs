using System;

namespace SaatphereWIN.DAL.DataTypes
{
    public class Activity
    {
        public int ActivityCid {get;set;}
        public string ActivityType {get;set;}
        public string ActivityDetails {get;set;}
        public int ActivityProfileId {get;set;}
        public int ActivityFranchiseeId {get;set;}
        public DateTime  ActivityDateTime {get;set;}
        public bool  ActivityActive {get;set;}
        public string ActivityExecutive { get; set; }
    }
}
