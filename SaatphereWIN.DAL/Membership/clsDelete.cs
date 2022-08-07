using System.Linq;
using SaatphereWIN.DAL.DBClass;

namespace SaatphereWIN.DAL.Membership
{
    public class ClsDelete
    {
        public void DeletePreviousProfileSendEntry(int profileId)
        {
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.ProfileSends.Where(a => a.ProfileSend_RowIDBioData.Equals(profileId)).ToList();
            saatphere.ProfileSends.DeleteAllOnSubmit(query);
            saatphere.SubmitChanges();
            saatphere.Dispose();
        }
    }
}
