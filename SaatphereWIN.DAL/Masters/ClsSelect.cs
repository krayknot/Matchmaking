using System.Data;
using System.Configuration;

namespace SaatphereWIN.DAL.Masters
{
    public class ClsSelect
    {
        public DataSet GetMotherTongueItems()
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.SqlMothertongueItems);
        }

        public DataSet GetMaritalStatusItems()
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.SqlMaritalstatusItems);
        }


        public DataSet GetReligionItems()
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.SqlReligionItems);
        }

        public DataSet GetCasteItems()
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.SqlCasteItems);
        }

        public DataSet GetAnnualIncomeItems()
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.SqlAnnualincomeItems);
        }

        public DataSet GetDietItems()
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.SqlDietItems);
        }

        public DataSet GetCityofResidenceItems()
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.SqlCityofresidenceItems);
        }

        public DataSet GetOccupationItems()
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.SqlOccupationItems);
        }

        public DataSet GetEducationItems()
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.SqlEducationItems);
        }

        public DataSet GetFranchiseeList()
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.SqlFranchiseelist);
        }

        public DataSet GetManglikItems()
        {
            return  new ClsCommon().GetDatasetonSQLQuery(Global.SqlManglikItems);
        }

        public DataSet GetStateItems()
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.SqlStateItems);
        }

        public DataSet GetCountrytems()
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.SqlCountryItems);
        }

        public DataSet GetAgeItems()
        {
            return new ClsCommon().GetDatasetonSQLQuery(Global.SqlAgeItems);
        }

        public DataSet GetCityfromGroupMaster()
        {
            string mode =  ConfigurationManager.AppSettings["CityListSource"].ToLower();
            string xmlPath = "xml\\City.xml";

            DataSet dst = new DataSet();
            if (mode == "xml")
            {
                dst.ReadXml(xmlPath);   
            }
            else if (mode == "db")
            {
                dst = new ClsCommon().GetDatasetonSQLQuery(Global.Getcityfromgroupmaster, DAL.Global.SaatphereCon);
            }
            return dst;
        }

        public DataSet GetStatefromGroupMaster()
        {
            var mode = ConfigurationManager.AppSettings["StateListSource"].ToLower();
            var xmlPath = "xml\\State.xml";

            DataSet dst = new DataSet();
            if (mode == "xml")
            {
                dst.ReadXml(xmlPath);
            }
            else if (mode == "db")
            {
                dst = new ClsCommon().GetDatasetonSQLQuery(Global.Getstatefromgroupmaster, DAL.Global.SaatphereCon);
            }
            return dst;
        }

        public DataSet GetList(string value)
        {
            var dst = new DataSet();
            switch (value)
            {
                case "city":
                    dst = new ClsCommon().GetDatasetonSQLQuery(Global.SqlCitieslist);
                    break;
                case "Religion":
                    dst = new ClsCommon().GetDatasetonSQLQuery(Global.SqlReligionlist);
                    break;
                case "Caste":
                    dst = new ClsCommon().GetDatasetonSQLQuery(Global.SqlCastelist);
                    break;
                case "Education":
                    dst = new ClsCommon().GetDatasetonSQLQuery(Global.SqlEducationlist);
                    break;
                case "BodyType":
                    dst = new ClsCommon().GetDatasetonSQLQuery(Global.SqlBodytypelist);
                    break;
                case "AboutFather":
                    dst = new ClsCommon().GetDatasetonSQLQuery(Global.SqlAboutfatherlist);
                    break;
                case "Occupation":
                    dst = new ClsCommon().GetDatasetonSQLQuery(Global.SqlOccupationlist);
                    break;
                case "AnnualIncome":
                    dst = new ClsCommon().GetDatasetonSQLQuery(Global.SqlAnnualincomelist);
                    break;
                case "MotherTongue":
                    dst = new ClsCommon().GetDatasetonSQLQuery(Global.SqlMothertonguelist);
                    break;
                case "Diet":
                    dst = new ClsCommon().GetDatasetonSQLQuery(Global.SqlDietlist);
                    break;
                case "FranchiseeName":
                    dst = new ClsCommon().GetDatasetonSQLQuery(Global.SqlFranchiseenamelist);
                    break;
                case "MaritalStatus":
                    dst.Tables.Add("MaritalStatus");
                    dst.Tables["MaritalStatus"].Columns.Add("value");
                    dst.Tables["MaritalStatus"].Rows.Add("Divorced");
                    dst.Tables["MaritalStatus"].Rows.Add("Married");
                    dst.Tables["MaritalStatus"].Rows.Add("Unmarried");
                    dst.Tables["MaritalStatus"].Rows.Add("Widowed");
                    dst.Tables["MaritalStatus"].Rows.Add("Separated");
                    break;
            }

            return dst;
        }
    }
}
