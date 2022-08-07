using System;
using SaatphereWIN.DAL.DBClass;
using System.Linq;

namespace SaatphereWIN.DAL.Automatch
{
    public class ClsDelete
    {
        public void DeleteIgnoredPaidMember(int paidMemberProfileId)
        {
           var saatphere = new dcSaatphereDataContext(SaatphereWIN.DAL.Global.SaatphereCon); //For local version

            var query = saatphere.AutoMatchPaidMembers.SingleOrDefault(a => a.AutoMatchPaidMembers_ProfileID.Equals(paidMemberProfileId));
            saatphere.AutoMatchPaidMembers.DeleteOnSubmit(query ?? throw new InvalidOperationException());
            saatphere.SubmitChanges();
            saatphere.Dispose();
        }
    }
}
