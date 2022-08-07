using System.Linq;
using SaatphereWIN.DAL.DBClass;

namespace SaatphereWIN.DAL.Masters
{
    public class ClsInsert
    {
        public string  InsertCity(string cityName)
        {
            var response = string.Empty;

            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var selectQuery = saatphere.groupmasters.Where(a => a.catageory.Equals("City") && a.value.ToLower().Equals(cityName.ToLower())).ToList();
            if (selectQuery.Count < 1)
            {
                var insertQuery = new groupmaster
                {
                    catageory = "City",
                    value = cityName,
                    GroupMaster_Active = true
                };
                saatphere.groupmasters.InsertOnSubmit(insertQuery);
                saatphere.SubmitChanges();

                response = "Record added successfully.";
            }
            else
            {
                response = "Record already exists.";
            }
            saatphere.Dispose();
            return response;
        }

    }
}
