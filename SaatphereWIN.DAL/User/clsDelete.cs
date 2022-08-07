using System.Linq;
using SaatphereWIN.DAL.DBClass;

namespace SaatphereWIN.DAL.User
{
   public class ClsDelete
    {
       public void DeleteTemp1()
       {
           var saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
           var query = saatphere.temp1s.ToList();
           saatphere.temp1s.DeleteAllOnSubmit(query);
           saatphere.SubmitChanges();
           saatphere.Dispose();
       }
    }
}
