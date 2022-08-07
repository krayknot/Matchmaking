using System.Data;
using System.Linq;

namespace SaatphereWIN.DAL.Automatch
{
    public class ClsCommon : DAL.ClsCommon
    {
        public void CollectDatatoProcess()
        {
            ExecuteQuery(Global.GetDatatoProcess);
        }

        public int GetProcessedAutomatch()
        {
            var saatphere = new DBClass.dcSaatphereDataContext(DAL.Global.SaatphereCon);
            return saatphere.Automatches.Count(a => a.Automatch_Status != null);
        }

        public int GetTotalAutomatchCount()
        {
            var saatphere = new DBClass.dcSaatphereDataContext(DAL.Global.SaatphereCon);
            return saatphere.Automatches.Count();
        }

        public int GetNotProcessedProfilesCount()
        {
            var saatphere = new DBClass.dcSaatphereDataContext(DAL.Global.SaatphereCon);
            return  saatphere.Automatches.Count(a => a.Automatch_Status == null);
        }

        public int GetDataCount()
        {
            var saatphere = new DBClass.dcSaatphereDataContext(DAL.Global.SaatphereCon);
            return saatphere.Automatches.Count();
        }

        public DataSet GetProfilestoProcess()
        {
            return GetDatasetonSQLQuery(Global.GetProfilestoProcess);
        }

        public void UpdateProfileSendStatus(string biodataId)
        {
            var saatphere = new DBClass.dcSaatphereDataContext(DAL.Global.SaatphereCon);

            var query = saatphere.Automatches.SingleOrDefault(a => a.Automatch_ProfileID == biodataId && a.Automatch_Status == null);
            if(query !=null)
            {
                query.Automatch_Status = "DONE";
                saatphere.SubmitChanges();
            }
            saatphere.Dispose();
        }
    }
}
