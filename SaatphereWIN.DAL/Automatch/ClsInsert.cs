using SaatphereWIN.DAL.DBClass;
using System;
using System.Linq;

namespace SaatphereWIN.DAL.Automatch
{
    public class ClsInsert
    {
        public void InsertIgnoredPaidMember(int paidMemberProfileId)
        {
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(SaatphereWIN.DAL.Global.SaatphereCon); //For local version

            //Check for the duplicacy. Duplicate id is not allowed
            var queryCheck = saatphere.AutoMatchPaidMembers.SingleOrDefault(b => b.AutoMatchPaidMembers_ProfileID.Equals(paidMemberProfileId));
            if (queryCheck == null)
            {
                var query = new AutoMatchPaidMember
                {
                    AutoMatchPaidMembers_DateAdded = DateTime.Now,
                    AutoMatchPaidMembers_ProfileID = paidMemberProfileId
                };
                saatphere.AutoMatchPaidMembers.InsertOnSubmit(query);
                saatphere.SubmitChanges();
                saatphere.Dispose();
            }
        }
    }
}
