using System;
using System.Linq;
using System.Data;

namespace SaatphereWIN.DAL.Franchisee
{
    public class ClsSelect
    {
        public DataSet GetDsrCustomers()
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.GetDsrCustomers);
        }

        public DataSet GetDsrExecutiveFromId(int dsrExecutiveId)
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.GetDsrExecutiveFromId.Replace("{DSRID}", dsrExecutiveId.ToString()));
        }

        public DataSet GetDsrfromDatesExecutive(DateTime fromDate, DateTime toDate, string executiveName)
        {
           return new ClsCommon().GetDatasetonSQLQuery(Global.GetDsrfromDatesExecutive.Replace("{FROMDATE}", fromDate.ToString("MM/dd/yyyy")).Replace("{TODATE}", toDate.ToString("MM/dd/yyyy")).Replace("{EXECUTIVE}", executiveName));
        }

        public DataSet GetDsrfromDatesFranchisee(DateTime fromDate, DateTime toDate, string franchiseeName)
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.GetDsrfromDatesFranchisee.Replace("{FROMDATE}", fromDate.ToString("MM/dd/yyyy")).Replace("{TODATE}", toDate.ToString("MM/dd/yyyy")).Replace("{FRANCHISEE}", franchiseeName));
        }

        public DataSet GetDsrExecutives(string franchiseeName)
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.GetDsrExecutives.Replace("{FNAME}", franchiseeName.ToString()), DAL.Global.SaatphereCon);
        }

        public string GetExecutiveNamefromId(int executiveId)
        {
            string response = string.Empty;

            DBClass.dcSaatphereDataContext saatphere = new DBClass.dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.Executives.SingleOrDefault(a => a.Executive_CID.Equals(executiveId));
            if (query != null)
            {
                response = Convert.ToString(query.Executive_Name);
            }
            saatphere.Dispose();
            return response;
        }

        public int GetExecutiveIdFromName(string executiveName)
        {
            var response = 0;

            DBClass.dcSaatphereDataContext saatphere = new DBClass.dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.Executives.SingleOrDefault(a => a.Executive_Name.Trim().Equals(executiveName.Trim()));
            if (query != null)
            {
                response = Convert.ToInt32(query.Executive_CID);
            }
            saatphere.Dispose();

            return response;
        }

        public DataSet GetExecutivesfromFranchiseeId(int franchiseeId)
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.GetExecutivesfromFranchiseeId.Replace("{FRANCHISEEID}", franchiseeId.ToString()), DAL.Global.SaatphereCon);
        }

        public DataSet GetFranchisees()
        {            
            return new ClsCommon().GetDatasetonSQLQuery(Global.GetFranchisees, DAL.Global.SaatphereCon);            
        }

        public DataSet GetExecutives()
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.Getexecutives, DAL.Global.SaatphereCon);
        }

        public int GetFranchiseeActualRowIdfromFranchiseeUsername(string franchiseeUserName)
        {
            var dst = new DataSet();
            var response = 0;

            dst = new ClsCommon().GetDatasetonSQLQuery(Global.Getfranchiseerowidfromfranchiseeusername.Replace("{FRANCHISEENAME}", franchiseeUserName), DAL.Global.SaatphereCon);
            response = Convert.ToInt32(dst.Tables[0].Rows[0]["FrRowID"]);

            return response;
        }

        public bool IsExecutiveExist(string executiveUsername)
        {
            bool response = false;

            DBClass.dcSaatphereDataContext saatphere = new DBClass.dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = saatphere.Executives.SingleOrDefault(a => a.Executive_Name.ToLower().Trim().Equals(executiveUsername.ToLower().Trim()));
            if (query != null)
            {
                response = true;
            }
            saatphere.Dispose();
            return response;
        }
    }
}
