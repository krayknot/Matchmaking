using System;
using System.Data;
using System.Data.SqlClient;   

namespace Reminders
{
    public class ClsCommon : IReminder 
    {
        public SqlConnection ConSource = new SqlConnection("Connection Timeout= 200;Data Source=208.91.198.174;Initial Catalog=saatphereDB;User Id=saat22156lg;Password=PherE234pd;");

        public static string UserId = string.Empty;
        public static string PendingDate = string.Empty;

        public static string DateofView = string.Empty;
        public static int FranchiseeId = 0;

        public void OpenConnectionSource()
        {
            if (ConSource.State == ConnectionState.Closed)
            {
                ConSource.Open(); 
            }
        }

        public void CloseConnectionSource()
        {
            if (ConSource.State == ConnectionState.Open)
            {
                ConSource.Close();
            }
        }

        public DataSet GetCustomerList(string startLetter)
        {
            var query = "select rowidbiodata[ID], (Firstname + ' ' + middlename + ' ' + surname)[Name], Gender, CityofResidence[City], Email from biodata 	where (firstname like '"+ startLetter.ToUpper() +"%' or firstname like '"+ startLetter.ToLower() +"%') and FranchiseeUsername='"+ ClsCommon.FranchiseeId.ToString() +"'";
            var dad = new SqlDataAdapter(query, ConSource.ConnectionString);
            var dst = new DataSet();
            dad.Fill(dst);
            return dst;
        }

        public DataSet GetCustomerHistory(string userId)
        {
            //string query = "Select DateoffinalView'Date', count(dateoffinalview)'Count' from finalview where substring(UserID, 2, len(UserID)) = '" + userID + "' group by DateoffinalView";
            var query = "Select DateoffinalView'Date',  (select Count(*) from (Select distinct(viewid) from finalview where substring(UserID, 2, len(UserID)) = '" + UserId + "' and DateoffinalView = f.DateoffinalView group by viewid) as abc)'Count'  from finalview as f where substring(UserID, 2, len(UserID)) = '" + UserId + "' group by dateoffinalview, DateoffinalView order by dateoffinalview desc";
            
            //string query = "Select * from finalview where substring(UserID, 2, len(UserID)) = '" + userID + "'";
            var dad = new SqlDataAdapter(query, ConSource.ConnectionString);
            var dst = new DataSet();
            dad.Fill(dst);
            return dst;
        }

        public DataSet SearchCustomer(string customerId, string customerName)
        {
            string query;
            if (customerId != string.Empty)
            {
                query = "select rowidbiodata[ID], (Firstname + ' ' + middlename + ' ' + surname)[Name], Gender, CityofResidence[City], Email from biodata where Rowidbiodata = '" + customerId + "'";                
            }
            else
            {
                query = "select rowidbiodata[ID], (Firstname + ' ' + middlename + ' ' + surname)[Name], Gender, CityofResidence[City], Email from biodata where (Upper(firstname) like '%" + customerName.ToUpper() + "%' or Upper(middlename) like '%" + customerName.ToUpper() + "%' or upper(surname) like '%" + customerName.ToLower() + "%')";
            }
                       
            var dad = new SqlDataAdapter(query, ConSource);
            var dst = new DataSet();
            dad.Fill(dst);
            return dst;
        }

        public DataSet GetCustomerHistoryDetails(string userId, string mDate)
        {
            string query = "Select distinct(substring(Viewid,2,len(viewid)))'Customer ID' from finalview where substring(UserID, 2, len(UserID)) = '" + userId + "' and dateoffinalview = '" + mDate + "'";

            //string query = "Select ((select Upper(substring(firstname,1,1)) from biodata where rowidbiodata = ViewID) + ViewID)'Customer ID' from finalview where substring(UserID, 2, len(UserID)) = '" + userID + "' and dateoffinalview = '" + mDate + "'";
            //string query = "Select * from finalview where substring(UserID, 2, len(UserID)) = '" + userID + "'";
            var dad = new SqlDataAdapter(query, ConSource);
            var dst = new DataSet();
            dad.Fill(dst);
            return dst;
        }

        public DataSet GetPreviousPendingPofiles()
        {
            //string query = "select Convert(varchar,(Substring(firstname,1,1)) + Convert(varchar,rowidbiodata))'Customer ID', Convert(varchar,Firstname)'First Name', Convert(varchar,Surname)'Last Name', Convert(varchar,Mobile)'Mobile', Convert(varchar,Residenceno)'Residence No', Convert(varchar,officeno)'Office No' from biodata where (membershiptype <> 'Registered' and membershiptype is not null and LEN(membershiptype) > 0) and (getdate() > convert(datetime,StartDate) AND getdate() < convert(datetime,LastDate)) and rowidbiodata not in (select Substring(userid,2,len(userid)) from finalview) and FranchiseeUsername='3' order by rowidbiodata desc";
            //Modified: kshitij.19 jan 2010
            //string query = "select pending_customerid'Customer Id', pending_firstname'First Name', pending_lastname'Last Name', pending_mobile'Mobile', pending_residenceno'Residence No', pending_officeNo'Officeno', Convert(varchar,pending_Date,101)'Date Pending' from saatphereuser.pending";

            var query = "select pending_customerid'Customer Id', pending_firstname'First Name', pending_lastname'Last Name', pending_mobile'Mobile', pending_residenceno'Residence No', pending_officeNo'Officeno', Convert(varchar,pending_Date,101)'Date Pending' from saatphereuser.pending where Convert(datetime,pending_Date)  > getdate() - 15 and Convert(datetime,pending_Date) < getdate()";
            
            //string query = "Select * from finalview where substring(UserID, 2, len(UserID)) = '" + userID + "'";
            var dad = new SqlDataAdapter(query, ConSource);
            var dst = new DataSet();
            dad.Fill(dst);
            return dst;
        }

        public DataSet GetTodaysPendingPofiles()
        {
            //string query = "select * from biodata where (membershiptype <> 'Registered' and membershiptype is not null and LEN(membershiptype) > 0) and rowidbiodata not in (select Substring(userid,2,len(userid)) from finalview) and (startdate = convert(varchar,Getdate() ,101) or startdate = convert(varchar,Getdate() -15 ,101)) and FranchiseeUsername='" + clsCommon.franchiseeId.ToString() + "' order by rowidbiodata desc ";
            //string query = "Select * from finalview where substring(UserID, 2, len(UserID)) = '" + userID + "'";
            var query = "select Convert(varchar,(Substring(firstname,1,1)) + Convert(varchar,rowidbiodata))'Customer ID', Convert(varchar,Firstname)'First Name', Convert(varchar,Surname)'Last Name', Convert(varchar,Mobile)'Mobile', Convert(varchar,Residenceno)'Residence No', Convert(varchar,officeno)'Office No'  from biodata where (day(convert(varchar,getdate(),101)) = day(Convert(datetime,StartDate) + 15) OR day(convert(varchar,getdate(),101)) = day((Convert(datetime,StartDate) + 15) + 15)) AND (getdate() > convert(datetime,StartDate) AND getdate() < convert(datetime,LastDate)) and FranchiseeUsername='" + ClsCommon.FranchiseeId.ToString() + "' order by rowidbiodata desc ";
            var dad = new SqlDataAdapter(query, ConSource.ConnectionString);
            var dst = new DataSet();
            dad.Fill(dst);
            InsertPendingDetails();

            return dst;            
        }

        public bool IsUserAuthenticated(string userName, string passWord)
        {
            var flag = false;

            var query = "select * from franchiseeloginmaster where lower(FranchiseeUserName) = lower('" + userName + "') and lower(FranchiseePassword) = ('" + passWord + "')";
            var dad = new SqlDataAdapter(query, ConSource);
            var dst = new DataSet();
            dad.Fill(dst);
            if (dst.Tables[0].Rows.Count > 0)
            {
                flag = true;
            }
            return flag;
        }

        public int GetFranchiseeId(string framchiseeUserName)
        {
            var id = 0;

            var query = "select FRRowId from franchiseeloginmaster where lower(FranchiseeUserName) = lower('" + framchiseeUserName + "')";
            var dad = new SqlDataAdapter(query, ConSource.ConnectionString);
            var dst = new DataSet();
            dad.Fill(dst);
            if (dst.Tables[0].Rows.Count > 0)
            {
                id = Convert.ToInt32( dst.Tables [0].Rows[0]["FRRowId"]);
            }
            return id;
        }

        public void InsertPendingDetails()
        {
            var query = "insert into saatphereuser.pending (Pending_CustomerID, Pending_FirstName, Pending_Lastname, " +
                            "Pending_Mobile, Pending_ResidenceNo, Pending_OfficeNo, Pending_Date) " +
                            "(select Convert(varchar,(Substring(firstname,1,1)) + Convert(varchar,rowidbiodata))'Customer ID', " + 
                            "Convert(varchar,Firstname)'First Name', Convert(varchar,Surname)'Last Name', Convert(varchar,Mobile)'Mobile', " +
                            "Convert(varchar,Residenceno)'Residence No', Convert(varchar,officeno)'Office No', getdate() " +
                            "from biodata where (day(convert(varchar,getdate(),101)) = day(Convert(datetime,StartDate) + 15) " +
                            "OR day(convert(varchar,getdate(),101)) = day((Convert(datetime,StartDate) + 15) + 15)) " +
                            "AND (getdate() > convert(datetime,StartDate) AND getdate() < convert(datetime,LastDate)) " +
                            "and FranchiseeUsername='" + ClsCommon.FranchiseeId.ToString() + "' and " +
                            "Convert(varchar,(Substring(firstname,1,1)) + Convert(varchar,rowidbiodata)) not in " +
                            "(select Pending_CustomerID from saatphereuser.pending where convert(varchar,Pending_Date,101) = convert(varchar,getdate(),101)))";
            var cmd = new SqlCommand(query, ConSource);
            ConSource.Open();
            cmd.ExecuteNonQuery();
            ConSource.Close();
        }

        public void DeletePendingEntry()
        {
            var query = "delete from saatphereuser.pending where pending_customerid = '" + ClsCommon.UserId + "' and convert(varchar, pending_date,101) = '" + ClsCommon.PendingDate + "'";
            var cmd = new SqlCommand(query, ConSource);
            ConSource.Open();
            cmd.ExecuteNonQuery();
            ConSource.Close();         

        }
    }
}
