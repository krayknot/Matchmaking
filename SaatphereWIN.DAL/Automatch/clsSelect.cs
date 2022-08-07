using SaatphereWIN.DAL.DBClass;
using System.Collections.Generic;
using System.Linq;

namespace SaatphereWIN.DAL.Automatch
{
    public class ClsSelect
    {
        public List<decimal?> GetAutomatchProfiles()
        {
            var saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon); //For local version
            return saatphere.AutoMatchPaidMembers.Select(a => a.AutoMatchPaidMembers_ProfileID).ToList();
        }
    }
}
