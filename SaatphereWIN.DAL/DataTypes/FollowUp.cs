using System;

namespace SaatphereWIN.DAL.DataTypes
{
    public class FollowUp
    {
        public int        FollowUpCid {get;set;}
        public int  FollowUpExecutiveId{get;set;}
        public DateTime   FollowUpDateTime{get;set;}
        public int  FollowUpActivityCid{get;set;}
        public int  FollowUpCreatedBy{get;set;}
        public DateTime   FollowUpDateCreated{get;set;}
        public bool FollowUpActive { get; set; }



    }
}
