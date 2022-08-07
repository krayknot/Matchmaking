using System.Linq;
using System.Data.SqlClient;

namespace SaatphereWIN.DAL.Franchisee
{
    public class ClsUpdate
    {
        public void DeactivateDsrExecutive(int dsrExecutiveId)
        {
            //Updating the record by not using LINQ query due to facing errors via LINQ updation
            string query = Global.UpdateSaatphereDsrExecutive.Replace("{DSRID}", dsrExecutiveId.ToString());
            SqlConnection con = new SqlConnection(DAL.Global.SaatphereCon);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateDsrExecutive(DAL.DataTypes.DsrExecutive dsrExecutiveDetails)
        {
            DAL.DBClass.dcSaatphereDataContext saatphere = new DBClass.dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.Saatphere_DSRExecutiveNames.SingleOrDefault(a => a.DSR_ID.Equals(dsrExecutiveDetails.DsrId));
            if (query != null)
            {
                query.DSR_Active = true;
                query.DSR_ExecutiveName = dsrExecutiveDetails.DsrExecutiveName;
                query.DSR_Executive
                    
                    = dsrExecutiveDetails.DsrExecutivePassword;
                query.DSR_Franchisee = dsrExecutiveDetails.DsrFranchisee;
                saatphere.SubmitChanges();
            }
            saatphere.Dispose();    
        }

        public void UpdateFranchiseePassword(string franchiseeName, string password)
        {
            var con = new SqlConnection(SaatphereWIN.DAL.Global.SaatphereCon);
            var cmd = new SqlCommand(Global.SaatphereFranchiseeUpdatepassword.Replace("{PASSWORD}", password).Replace("{USERNAME}", franchiseeName), con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
