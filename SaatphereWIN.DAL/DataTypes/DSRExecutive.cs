using System;

namespace SaatphereWIN.DAL.DataTypes
{
    public class DsrExecutive
    {
        public int DsrId {get;set;}
        public string DsrExecutiveName {get;set;}
        public DateTime DsrDateCreated {get;set;}
        public bool DsrStatus {get;set;}
        public string DsrFranchisee {get;set;}
        public string DsrExecutivePassword {get;set;}
        public bool DsrActive { get; set; }
    }
}
