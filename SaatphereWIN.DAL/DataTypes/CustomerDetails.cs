using System;

namespace SaatphereWIN.DAL.DataTypes
{
    public class CustomerDetails
    {
        public int CustomerDetailsCid {get; set;}
        public string CustomerDetailsName {get; set;}
        public string CustomerDetailsPhone {get; set;}
        public int CustomerDetailsExecutiveDsrid {get; set;}
        public string CustomerDetailsRemarks {get; set;}
        public DateTime CustomerDetailsDateCreated {get; set;}
        public int CustomerDetailsCreatedBy {get; set;}
        public bool CustomerDetailsActive { get; set; }
        public string CustomerDetailsCallDirection { get; set; }
        public string CustomerDetailsLanguage { get; set; }


    }
}
