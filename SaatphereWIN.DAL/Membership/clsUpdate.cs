using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SaatphereWIN.DAL.DBClass;

namespace SaatphereWIN.DAL.Membership
{
    public class clsUpdate
    {
        public void UpdateQueueRecord(int ProfileID, string Status, DateTime ProfileSendDate)
        {
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.ProfileSends.Where(a => a.ProfileSend_CID.Equals(ProfileID)).SingleOrDefault();
            if (query != null)
            {
                query.ProfileSend_Status = Status;
                query.ProfileSend_SendDate = ProfileSendDate;
                saatphere.SubmitChanges();
            }
            saatphere.Dispose();
        }

        public void UpdateDatetoTomorow(int ProfileCID)
        {
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.ProfileSends.Where(a => a.ProfileSend_CID.Equals(ProfileCID)).SingleOrDefault();
            if (query != null)
            {
                query.ProfileSend_SendDate = Convert.ToDateTime(query.ProfileSend_SendDate.ToString()).AddDays(1);
                saatphere.SubmitChanges();
            }
            saatphere.Dispose();
        }

        public void UpdateValidityLeft(int ProfileID)
        {
            SqlConnection con = new SqlConnection(DAL.Global.SaatphereCon);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
