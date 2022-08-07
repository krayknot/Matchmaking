using System;
using SaatphereWIN.DAL.DBClass;


namespace SaatphereWIN.DAL.Franchisee
{
    public class ClsInsert
    {
        public void InsertDsrExecutive(SaatphereWIN.DAL.DataTypes.DsrExecutive dsrExecutiveDetails)
        {
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(SaatphereWIN.DAL.Global.SaatphereCon);
            var query = new Saatphere_DSRExecutiveName
            {
                DSR_DateCreated = DateTime.Now,
                DSR_ExecutiveName = dsrExecutiveDetails.DsrExecutiveName,
                DSR_Executive
                = dsrExecutiveDetails.DsrExecutivePassword,
                DSR_Franchisee = dsrExecutiveDetails.DsrFranchisee,
                DSR_Status = true,
                DSR_Active = true
            };
            saatphere.Saatphere_DSRExecutiveNames.InsertOnSubmit(query);
            saatphere.SubmitChanges();
            saatphere.Dispose();
        }

        public void InsertDsr(DataTypes.SaatphereDsr dsrDetails)
        {
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon); //For local version
            var query = new Saatphere_DSR
            {
                DSR_ActiveStatus = true,
                DSR_Amount = dsrDetails.DsrAmount,
                DSR_Candidatename = dsrDetails.DsrCandidatename,
                DSR_Date = dsrDetails.DsrDate,
                DSR_Datecreated = DateTime.Now,
                DSR_Executivename = dsrDetails.DsrExecutivename,
                DSR_Franchisee = dsrDetails.DsrFranchisee,
                DSR_Membershiptype = dsrDetails.DsrMembershiptype,
                DSR_Mode = dsrDetails.DsrMode,
                DSR_Phoneno = dsrDetails.DsrPhoneno,
                DSR_Profileid = dsrDetails.DsrProfileid,
                DSR_Status = dsrDetails.DsrStatus
            };
            saatphere.Saatphere_DSRs.InsertOnSubmit(query);
            saatphere.SubmitChanges();
            saatphere.Dispose();
        }

        public void InsertExecutive(DataTypes.Executive executiveDetails)
        {
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(SaatphereWIN.DAL.Global.SaatphereCon);
            var query = new Executive
            {                
               Executive_Active = true,
               Executive_DateCreated = DateTime.Now,
               Executive_FranchiseeCID = executiveDetails.ExecutiveFranchiseeCid,
               Executive_Name = executiveDetails.ExecutiveName,
               Executive_Username = executiveDetails.ExecutiveUsername,
               Executive_Password = executiveDetails.ExecutivePassword
            };
            saatphere.Executives.InsertOnSubmit(query);
            saatphere.SubmitChanges();
            saatphere.Dispose();
        }

        public void InsertFranAccount(decimal amount, int customerId, int franchiseeId, string loginMessage, string activity)
        {       
            amount = amount / 2;
            string amts;
            amts = Convert.ToString(Math.Round(amount, 2));

            string franchiseeID = string.Empty;
            if (loginMessage == "franchiseelogin")
            {
                franchiseeID = franchiseeId.ToString();
            }
            else
            {
                franchiseeID = franchiseeId.ToString();
            }

            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = new FranAccount
            {
                ActDate = DateTime.Now,
                Activity = activity,
                AmountDed = Convert.ToDouble(amts),
                AmountRec = 0,
                CustomerID = customerId.ToString(),
                FranID = franchiseeID
            };

            saatphere.FranAccounts.InsertOnSubmit(query);
            saatphere.SubmitChanges();
            saatphere.Dispose();
        }

        public void InsertFranAccount(DAL.DataTypes.Franchisee franchiseeDetails)
        {           
            dcSaatphereDataContext saatphere = new dcSaatphereDataContext(DAL.Global.SaatphereCon);
            var query = new FranAccount
            {
                Activity = franchiseeDetails.Activity,
                AmountDed = franchiseeDetails.AmountDed,
                AmountRec = franchiseeDetails.AmountRec,
                CustomerID = franchiseeDetails.CustomerId,
                FranID = franchiseeDetails.FranId
            };

            saatphere.FranAccounts.InsertOnSubmit(query);
            saatphere.SubmitChanges();
            //saatphere.Transaction.Commit();

            saatphere.Dispose();
        }
    }
}
