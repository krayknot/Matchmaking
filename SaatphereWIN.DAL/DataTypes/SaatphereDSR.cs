using System;

namespace SaatphereWIN.DAL.DataTypes
{
    public class SaatphereDsr
    {
        public int DsrId {get;set;}
        public DateTime DsrDate {get;set;}
        public string DsrCandidatename {get;set;}
        public string DsrPhoneno {get;set;}
        public int DsrAmount {get;set;}
        public string DsrMode {get;set;}
        public string DsrStatus {get;set;}
        public string DsrMembershiptype {get;set;}
        public string DsrExecutivename {get;set;}
        public string DsrProfileid {get;set;}
        public string DsrFranchisee {get;set;}
        public DateTime DsrDatecreated {get;set;}
        public bool DsrActiveStatus { get; set; }
    }
}
