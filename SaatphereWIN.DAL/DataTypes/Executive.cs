using System;

namespace SaatphereWIN.DAL.DataTypes
{
    public class Executive
    {
        public int ExecutiveCid { get; set; }
        public string ExecutiveName{ get; set; }
        public DateTime ExecutiveDateCreated{ get; set; }
        public bool ExecutiveActive{ get; set; }
        public int ExecutiveFranchiseeCid { get; set; }
        public string ExecutiveUsername {get;set;}
        public string ExecutivePassword {get;set;}
    }
}
