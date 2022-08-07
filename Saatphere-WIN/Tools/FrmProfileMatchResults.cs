using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using Microsoft.Office.Interop.Word;

namespace Saatphere_WIN.Tools
{
    public partial class FrmProfileMatchResults : Form
    {
        bool withAddress = false;
        public int row = 0;
        public int col = 0;
        int customerBiodataID = 0;
        SaatphereWIN.DAL.DataTypes.SearchFields searchFields = new SaatphereWIN.DAL.DataTypes.SearchFields();
        DataSet dstExcelExport = new DataSet();

        public FrmProfileMatchResults(SaatphereWIN.DAL.DataTypes.SearchFields SearchFields, int CustomerBiodataID, bool WithAddress = false, bool SearchAll = false)
        {
            InitializeComponent();
            searchFields = SearchFields;

            withAddress = WithAddress;
            customerBiodataID = CustomerBiodataID;

            Cursor.Current = Cursors.WaitCursor;
            if(SearchAll)
            {
                BindDataAdvanceSearch(SearchFields);
            }
            else
            {
                BindDataMemAdvanceSearch();
            }
            
            Cursor.Current = Cursors.Arrow;            
        }

        private void BindDataAdvanceSearch(SaatphereWIN.DAL.DataTypes.SearchFields SearchFields)
        {
            #region SaatpheredBSearch
            //If the customer for whom system is searching is a Paid Member then include the residenail address field as well
            string showResidentialAddress = string.Empty; //this includes the phone numbers and email address also
            if (withAddress)
            {
                showResidentialAddress = ", ResidentialAddress'Address', ContactDetail.Telephone1'Phone 1', ContactDetail.Telephone2'Phone 2', ContactDetail.EmailUser'Email Address1',biodata.Email'Email Address2',Biodata.Biodata_Email2'Email Address3',  ContactDetail.mobile'Mobile' ";
            }


            string heightfrom = SearchFields.HeightFrom.Replace(".","");
            string heightto = SearchFields.HeightTo.Replace(".","");
            //string heightfrom = SearchFields.HeightFrom.Replace("\"", "").Replace("'", "").Replace(".", "");
            //string heightto = SearchFields.HeightTo.Replace("\"", "").Replace("'", "").Replace(".", "");
            //string heightfrom = SearchFields.HeightFrom.Replace("\"", ".").Replace("'", "");
            //string heightto = SearchFields.HeightTo.Replace("\"", ".").Replace("'", "");

            string gender = SearchFields.Gender;
            string agefrom = SearchFields.AgeFrom;
            string ageto = SearchFields.AgeTo;
            string annualincomefrom = SearchFields.AnnualIncomeFrom;
            string annualincometo = SearchFields.AnnualIncomeTo;
            string occupation = SearchFields.Occupation;
            string maritialstatus = SearchFields.MaritalStatus;
            string diet = SearchFields.Diet;
            //string noofchildren = SearchFields.NoofChildren;
            string manglik = SearchFields.Manglik;
            string caste = SearchFields.Caste;
            string religion = SearchFields.Religion;
            string country = SearchFields.Country;
            string city = SearchFields.City;
            string education = SearchFields.Education;
            string candlocation = SearchFields.CandidateLocation;
            string castenobar = SearchFields.CasteNoBar;
            string motherTongue = SearchFields.Mothertongue;
            string state = SearchFields.State;
            string withPicture = SearchFields.WithPicture.ToString();
            string candidateLocation = SearchFields.CandidateLocation; //8/25/2014

            //Value correction to search the multiple values
            if(education!=null)
                education = "'" + education.Replace(",", "','") + "'";

            if(city != null)
                city = "'" + city.Replace(",", "','") + "'";

            if(religion != null)
                religion = "'" + religion.Replace(",", "','") + "'";

            if(motherTongue != null)
            motherTongue = "'" + motherTongue.Replace(",", "','") + "'";

            if(candidateLocation != null)
                candidateLocation = "'" + candidateLocation.Replace(",", "','") + "'";

            if(occupation != null)
                occupation = "'" + occupation.Replace(",", "','") + "'";

            if(state != null)
                state = "'" + state.Replace(",", "','") + "'";

            if(caste != null)    
                caste = "'" + caste.Replace(",", "','") + "'";

            if(diet!= null)
                diet = "'" + diet.Replace(",", "','") + "'";

            if (candlocation != null)
                candlocation = "'" + candlocation.Replace(",", "','") + "'";

            SqlConnection conn = new SqlConnection(SaatphereWIN.DAL.Global.SaatphereCon);
            conn.Open();

            DataSet dset = new DataSet();

            if (gender == "Dosen't Matter" & heightfrom == "Dosen't Matter" & heightto == "Dosen't Matter" & agefrom == "Dosen't Matter" & ageto == "Dosen't Matter" & annualincomefrom == "Dosen't Matter" & annualincometo == "Dosen't Matter" & occupation == "Dosen't Matter" & maritialstatus == "Dosen't Matter" & diet == "Dosen't Matter" & caste == "Dosen't Matter" & religion == "Dosen't Matter" & country == "Dosen't Matter" & city == "Dosen't Matter" & candlocation == "Dosen't Matter" & education == "Dosen't Matter" & state == "Dosen't Matter")
            {
                SqlDataAdapter adas1 = new SqlDataAdapter(comm1);
                DataSet dset1 = new DataSet();
                adas1.Fill(dset1);
                dgrdProfileMatchResults.DataSource = dset1.Tables[0];
            }
            else
            {
                if (heightfrom != "Dosen't Matter" & heightto != "Dosen't Matter")
                {

                }

                if (heightfrom == "Dosen't Matter" & heightto != "Dosen't Matter")
                {
                    //sqlstring = (sqlstring + " and REPLACE(replace(replace(Height, '\"',''),'''',''), '.','') = " + heightto);
                    //sqlstring = (sqlstring + " and replace(replace(Height, '\"','.'),'''','') = " + heightto);
                    //sqlstring = (sqlstring + " and convert(float, height) = " + heightto + " and height <> 'NULL' and height <> '--Select--' and height <> ''");
                    sqlstring = (sqlstring + " and convert(float, replace(height, '.','')) <= " + heightto + " and height <> 'NULL' and height <> '--Select--' and height <> ''");

                }

                if (heightfrom != "Dosen't Matter" & heightto == "Dosen't Matter")
                {
                    //sqlstring = sqlstring + " and REPLACE(replace(replace(Height, '\"',''),'''',''), '.','') = " + heightfrom;
                    //sqlstring = sqlstring + " and replace(replace(Height, '\"','.'),'''','') = " + heightfrom;
                    //sqlstring = sqlstring + " and convert(float, height) = " + heightfrom + " and height <> 'NULL' and height <> '--Select--' and height <> ''";
                    sqlstring = sqlstring + " and convert(float, replace(height, '.','')) >= " + heightfrom + " and height <> 'NULL' and height <> '--Select--' and height <> ''";

                }

                if (occupation != null)
                {
                    if (occupation != "'Dosen't Matter'" && occupation != "")
                    {
                        sqlstring = sqlstring + " and occupation IN (" + occupation + ")";
                    }
                }

                if (maritialstatus == string.Empty)
                {
                    sqlstring = sqlstring + " and martialstatus = 'UnMarried'";
                }
                else if (maritialstatus != "Dosen't Matter" && maritialstatus != "True")
                {
                    sqlstring = sqlstring + " and martialstatus = '" + maritialstatus + "'";
                }

                if (diet != null)
                {
                    if (diet != "Dosen't Matter")
                    {
                        sqlstring = sqlstring + " and diet in (" + diet + ")";
                    }
                }

                //if (noofchildren != "Dosen't Matter")
                //{
                //    sqlstring = sqlstring + " and numberofchildren='" + noofchildren + "'";
                //}

                if (manglik != "Dosen't Matter")
                {
                    sqlstring = sqlstring + " and manglik = '" + manglik + "'";
                }

                if (state != null)
                {
                    if (state != "'Dosen't Matter'" && state != "")
                    {
                        sqlstring = sqlstring + " and state IN (" + state + ")";
                    }
                }

                if (caste != null)
                {
                    if (caste != "'Dosen't Matter'" && caste != "")
                    {
                        sqlstring = sqlstring + " and caste IN(" + caste + ")";
                    }
                }

                if (religion != null)
                {
                    if (religion != "'Dosen't Matter'" && religion != "")
                    {
                        sqlstring = sqlstring + " and religion IN(" + religion + ")";
                    }
                }

                if (country != "Dosen't Matter")
                {
                    sqlstring = sqlstring + " and country ='" + country + "'";
                }

                if (city != null)
                {
                    if (city != "Dosen't Matter" && city.Length > 0)
                    {
                        sqlstring = sqlstring + " and cityofresidence in (" + city + ")";
                    }
                }

                if (candlocation != null)
                {
                    if (candlocation != "Dosen't Matter" && candlocation.Length > 0)
                    {
                        sqlstring = sqlstring + " and biodata_candidatelocation in (" + candlocation + ")";
                    }
                }

                if (education != null)
                {
                    if (education != "'Dosen't Matter'" && education != "")
                    {
                        sqlstring = sqlstring + " and educationstatus IN (" + education + ")";
                    }
                }


                if (annualincomefrom != "Dosen't Matter" & annualincometo != "Dosen't Matter")
                {
                    sqlstring = sqlstring + " and convert(int,annualincome) BETWEEN "+ annualincomefrom +" and " + annualincometo + " and annualincome <> 'Dosen''t Matter' and annualincome <> '--Select--' ";
                }  

                if (annualincomefrom == "Dosen't Matter" & annualincometo != "Dosen't Matter")
                {
                    sqlstring = sqlstring + " and convert(int,annualincome) = " + annualincometo + " and annualincome <> 'Dosen''t Matter' and annualincome <> '--Select--' ";

                }
                if (annualincomefrom != "Dosen't Matter" & annualincometo == "Dosen't Matter")
                {
                    sqlstring = sqlstring + " and convert(int,annualincome) = " + annualincomefrom + " and annualincome <> 'Dosen''t Matter' and annualincome <> '--Select--' ";

                }
                if (annualincomefrom != "Dosen't Matter" & annualincometo != "Dosen't Matter")
                {
                    sqlstring = sqlstring.ToString();
                }

                if (agefrom != "Dosen't Matter" && ageto != "Dosen't Matter")
                {
                    sqlstring = sqlstring + " and Age BETWEEN "+ agefrom +" and " + ageto;
                }
                else if (agefrom != "Dosen't Matter" && ageto == "Dosen't Matter")
                {
                    sqlstring = sqlstring + " and Age >= " + agefrom;

                }
                else if (agefrom == "Dosen't Matter" && ageto != "Dosen't Matter")
                {
                    sqlstring = sqlstring + " and Age <= " + ageto;
                }

                if (castenobar != "Doesn't Matter" && castenobar != "")
                {
                    sqlstring = sqlstring + " and castenobar = '" + castenobar + "'";
                }

                if (motherTongue != null)
                {
                    if (motherTongue != "'Dosen't Matter'" && motherTongue != "")
                    {
                        sqlstring = sqlstring + " and Mothertongue IN (" + motherTongue + ")";
                    }
                }

                if (withPicture == "True")
                {
                    sqlstring = sqlstring + " and convert(varchar,Photograph) NOT IN ('', 'Not Avaliable') and Photograph IS NOT NULL";
                }
                
                //Added by Kanchan Kakalia, Date: 13/03/2013
                //Reason, If Internal Visibility is NO, biodata shouldnt be visible in searching
                sqlstring = sqlstring + " and (biodata_visibleinside != 'False' OR biodata_visibleinside IS NULL)";


                //It is taking "order by SNO" again in the mid and hence producing error, as a trick we will remove it if it is coming in between
                //of the query, and will place it in the last
                if (sqlstring.Contains("order by Convert(int, rowidbiodata) desc"))
                {
                    sqlstring = sqlstring.Replace("order by Convert(int, rowidbiodata) desc", "");
                    sqlstring = sqlstring + " order by Convert(int, rowidbiodata) desc";
                }


                if (!sqlstring.Contains("order by Convert(int, rowidbiodata) desc"))
                {
                    sqlstring = sqlstring + " order by Convert(int, rowidbiodata) desc";
                }

                //Replaces the gender
                sqlstring = sqlstring.Replace("@gender", "'" + gender + "'");

                SqlCommand comm = new SqlCommand(sqlstring, conn);

                SqlDataAdapter adas = new SqlDataAdapter(comm);
                adas.Fill(dset);
                dstExcelExport = dset; //excel export

                dgrdProfileMatchResults.DataSource = dset.Tables[0];
            }
            #endregion

            //Get the profiles from Shreeshaadi Database
           #region ShreeshaadidBSearch
           
            string SS_heightfrom = SearchFields.HeightFrom;
            string SS_heightto = SearchFields.HeightTo;
            string SS_gender = SearchFields.Gender;
            string SS_agefrom = SearchFields.AgeFrom;
            string SS_ageto = SearchFields.AgeTo;
            string SS_annualincomefrom = SearchFields.AnnualIncomeFrom;
            string SS_annualincometo = SearchFields.AnnualIncomeTo;
            string SS_occupation = SearchFields.Occupation;
            string SS_maritialstatus = SearchFields.MaritalStatus;
            string SS_diet = SearchFields.Diet;
            //string SS_noofchildren = SearchFields.NoofChildren;
            string SS_manglik = SearchFields.Manglik;
            string SS_caste = SearchFields.Caste;
            string SS_religion = SearchFields.Religion;
            string SS_country = SearchFields.Country;
            string SS_city = SearchFields.City;
            string SS_education = SearchFields.Education;
            string SS_candlocation = SearchFields.CandidateLocation;
            string SS_castenobar = SearchFields.CasteNoBar;
            string SS_motherTongue = SearchFields.Mothertongue;
            string SS_state = SearchFields.State;
            string SS_withPicture = SearchFields.WithPicture.ToString();

            SqlConnection SS_conn = new SqlConnection(SaatphereWIN.DAL.Global.ShreeshaadiCon);

            //if (SS_gender == "Dosen't Matter" & SS_heightfrom == "Dosen't Matter" & SS_heightto == "Dosen't Matter" & SS_agefrom == "Dosen't Matter" & SS_ageto == "Dosen't Matter" & SS_annualincomefrom == "Dosen't Matter" & SS_annualincometo == "Dosen't Matter" & SS_occupation == "Dosen't Matter" & SS_maritialstatus == "Dosen't Matter" & SS_diet == "Dosen't Matter" & SS_noofchildren == "Dosen't Matter" & SS_caste == "Dosen't Matter" & SS_religion == "Dosen't Matter" & SS_country == "Dosen't Matter" & SS_city == "Dosen't Matter" & SS_candlocation == "Dosen't Matter" & SS_education == "Dosen't Matter" & SS_state == "Dosen't Matter")
            //{
            //}
            //else
            //{
            //    //Height
            //    //------------------------------------------------------------------------------------------------
            //    if (SS_heightfrom != "Dosen't Matter" & SS_heightto != "Dosen't Matter")
            //    {
            //        SS_sqlstring = (SS_sqlstring + " and UserDetails_Height between @heightfrom and @heightto");
            //    }

            //    if (SS_heightfrom == "Dosen't Matter" & SS_heightto != "Dosen't Matter")
            //    {
            //        SS_sqlstring = (SS_sqlstring + " and UserDetails_Height = @heightto");
            //    }

            //    if (SS_heightfrom != "Dosen't Matter" & SS_heightto == "Dosen't Matter")
            //    {
            //        SS_sqlstring = SS_sqlstring + " and UserDetails_Height=@heightfrom";

            //    }
            //    //------------------------------------------------------------------------------------------------


            //    //Occupation
            //    //------------------------------------------------------------------------------------------------
            //    if (SS_occupation != "'Dosen't Matter'" && SS_occupation != "")
            //    {
            //        SS_sqlstring = SS_sqlstring + " and UserDetails_occupation IN (" + new SaatphereWIN.DAL.Shreeshaadi.clsSelect().GetDropChoiceCIDFromString(SS_occupation) + ")";
            //    }
            //    //------------------------------------------------------------------------------------------------

            //    //Marital Status
            //    //------------------------------------------------------------------------------------------------
            //    if (SS_maritialstatus == string.Empty)
            //    {
            //        SS_sqlstring = SS_sqlstring + " and UserDetails_maritalstatus = 'UnMarried'";
            //        //Session["MaritialStatus"] = "True";//To prevent it to add on nextpage
            //    }
            //    else if (SS_maritialstatus != "Dosen't Matter" && SS_maritialstatus != "True")
            //    {
            //        SS_sqlstring = SS_sqlstring + " and UserDetails_maritalstatus = @martialstatus";
            //    }
            //    //------------------------------------------------------------------------------------------------

            //    if (SS_diet != "Dosen't Matter")
            //    {
            //        SS_sqlstring = SS_sqlstring + " and UserDetails_diet = @diet";
            //    }

            //    if (SS_noofchildren != "Dosen't Matter")
            //    {
            //        SS_sqlstring = SS_sqlstring + " and UserDetails_Children = @noc";
            //    }

            //    if (SS_manglik != "Dosen't Matter")
            //    {
            //        SS_sqlstring = SS_sqlstring + " and UserDetails_manglik = @manglik";
            //    }
            //    if (SS_state != "'Dosen't Matter'" && SS_state != "")
            //    {
            //        SS_sqlstring = SS_sqlstring + " and UserDetails_state IN (SELECT State_cid from dbo.States where state_name = '+ SS_state +')";
            //    }

            //    if (SS_caste != "'Dosen't Matter'" && SS_caste != "")
            //    {
            //        SS_sqlstring = SS_sqlstring + " and UserDetails_caste IN(" + new SaatphereWIN.DAL.Shreeshaadi.clsSelect().GetDropChoiceCIDFromString(SS_caste) + ")";
            //    }
            //    if (SS_religion != "'Dosen't Matter'" && SS_religion != "")
            //    {
            //        SS_sqlstring = SS_sqlstring + " and UserDetails_religion IN(" + new SaatphereWIN.DAL.Shreeshaadi.clsSelect().GetReligionCIDFromString(SS_religion) + ")";
            //    }
            //    if (SS_country != "Dosen't Matter")
            //    {
            //        SS_sqlstring = SS_sqlstring + " and USers_countryCID = @country";
            //    }
            //    if (SS_city != "Dosen't Matter" && SS_city.Length > 0)
            //    {
            //        SS_sqlstring = SS_sqlstring + " and Users.Users_City in (" + SS_city + ")";
            //    }
            //    if (SS_candlocation != "Dosen't Matter" && SS_candlocation.Length > 0)
            //    {
            //        SS_sqlstring = SS_sqlstring + " and biodata_candidatelocation in (" + SS_candlocation + ")";
            //    }
            //    if (SS_education != "'Dosen't Matter'" && SS_education != "")
            //    {
            //        SS_sqlstring = SS_sqlstring + " and UserDetails_education IN (" + new SaatphereWIN.DAL.Shreeshaadi.clsSelect().GetDropChoiceCIDFromString(SS_education) + ")";
            //    }

            //    if (SS_annualincomefrom != "Dosen't Matter" & SS_annualincometo != "Dosen't Matter")
            //    {
            //        SS_sqlstring = SS_sqlstring + " and UserDetails_AnnualIncome BETWEEN @annualincomefrom and @annualincometo";
            //    }

            //    if (SS_annualincomefrom == "Dosen't Matter" & SS_annualincometo != "Dosen't Matter")
            //    {
            //        SS_sqlstring = SS_sqlstring + " and UserDetails_AnnualIncome = @annualincometo";

            //    }
            //    if (SS_annualincomefrom != "Dosen't Matter" & SS_annualincometo == "Dosen't Matter")
            //    {
            //        SS_sqlstring = SS_sqlstring + " and UserDetails_AnnualIncome = @annualincomefrom";

            //    }
            //    if (SS_annualincomefrom != "Dosen't Matter" & SS_annualincometo != "Dosen't Matter")
            //    {
            //        SS_sqlstring = SS_sqlstring.ToString();
            //    }

            //    if (SS_agefrom != "Dosen't Matter" && SS_ageto != "Dosen't Matter")
            //    {
            //        SS_sqlstring = SS_sqlstring + " and (Year(Getdate()) - Year(UserDetails_DateofBirth)) BETWEEN @agefrom and @ageto";
            //    }
            //    else if (SS_agefrom != "Dosen't Matter" && SS_ageto == "Dosen't Matter")
            //    {
            //        SS_sqlstring = SS_sqlstring + " and (Year(Getdate()) - Year(UserDetails_DateofBirth)) >= @agefrom";

            //    }
            //    else if (SS_agefrom == "Dosen't Matter" && SS_ageto != "Dosen't Matter")
            //    {
            //        SS_sqlstring = SS_sqlstring + " and (Year(Getdate()) - Year(UserDetails_DateofBirth)) <= @ageto";
            //    }

            //    if (SS_castenobar != "Dosen't Matter" && SS_castenobar != "")
            //    {
            //        SS_sqlstring = SS_sqlstring + " and UserDetails_castenobar = @castenobar";
            //    }

            //    if (SS_motherTongue != "'Dosen't Matter'" && SS_motherTongue != "")
            //    {
            //        SS_sqlstring = SS_sqlstring + " and UserDetails_Mothertongue IN (" + new SaatphereWIN.DAL.Shreeshaadi.clsSelect().GetDropChoiceCIDFromString(SS_motherTongue) + ")";
            //    }

            //    if (SS_withPicture == "True")
            //    {
            //        SS_sqlstring = SS_sqlstring + " and convert(varchar,UserDetails_ProfilePic) NOT IN ('', 'Not Avaliable') and UserDetails_ProfilePic IS NOT NULL";
            //    }

            //    //It is taking "order by SNO" again in the mid and hence producing error, as a trick we will remove it if it is coming in between
            //    //of the query, and will place it in the last
            //    if (SS_sqlstring.Contains("order by Convert(int, Users.Users_CID) desc"))
            //    {
            //        SS_sqlstring = SS_sqlstring.Replace("order by Convert(int, Users.Users_CID) desc", "");
            //        SS_sqlstring = SS_sqlstring + " order by Convert(int, Users.Users_CID) desc";
            //    }


            //    if (!SS_sqlstring.Contains("order by Convert(int, Users.Users_CID) desc"))
            //    {
            //        SS_sqlstring = SS_sqlstring + " order by Users.Users_CID desc";
            //    }

            //    //Replaces the gender
            //    SS_sqlstring = SS_sqlstring.Replace("@gender", "'" + gender + "'");

            //    SqlCommand SS_comm = new SqlCommand(SS_sqlstring, SS_conn);

            //    SS_comm.Parameters.AddWithValue("@gender", new SaatphereWIN.DAL.Shreeshaadi.clsSelect().GetDropChoiceCIDFromString(SS_gender));
            //    SS_comm.Parameters.AddWithValue("@heightfrom", new SaatphereWIN.DAL.Shreeshaadi.clsSelect().GetHeadingIDforHeight(SS_heightfrom.ToString()));
            //    SS_comm.Parameters.AddWithValue("@heightto", new SaatphereWIN.DAL.Shreeshaadi.clsSelect().GetHeadingIDforHeight(SS_heightto.ToString()));
            //    SS_comm.Parameters.AddWithValue("@martialstatus", new SaatphereWIN.DAL.Shreeshaadi.clsSelect().GetHeadingIDforHeight(SS_maritialstatus.ToString()));
            //    SS_comm.Parameters.AddWithValue("@diet", new SaatphereWIN.DAL.Shreeshaadi.clsSelect().GetDropChoiceCIDFromString(SS_diet.ToString()));
            //    SS_comm.Parameters.AddWithValue("@manglik", new SaatphereWIN.DAL.Shreeshaadi.clsSelect().GetHeadingIDforManglik(SS_manglik));
            //    SS_comm.Parameters.AddWithValue("@religion", new SaatphereWIN.DAL.Shreeshaadi.clsSelect().GetDropChoiceCIDFromString(SS_religion));
            //    SS_comm.Parameters.AddWithValue("@country", SS_country.ToString());
            //    SS_comm.Parameters.AddWithValue("@annualincomefrom", new SaatphereWIN.DAL.Shreeshaadi.clsSelect().GetDropChoiceCIDFromString(SS_annualincomefrom.ToString()));
            //    SS_comm.Parameters.AddWithValue("@annualincometo", new SaatphereWIN.DAL.Shreeshaadi.clsSelect().GetDropChoiceCIDFromString(SS_annualincometo.ToString()));
            //    SS_comm.Parameters.AddWithValue("@noc", SS_noofchildren.ToString());
            //    SS_comm.Parameters.AddWithValue("@agefrom", SS_agefrom.ToString());
            //    SS_comm.Parameters.AddWithValue("@ageto", SS_ageto.ToString());
            //    SS_comm.Parameters.AddWithValue("@castenobar", new SaatphereWIN.DAL.Shreeshaadi.clsSelect().GetDropChoiceCIDFromString(SS_castenobar));
            //    SS_comm.Parameters.AddWithValue("@mothertongue", new SaatphereWIN.DAL.Shreeshaadi.clsSelect().GetDropChoiceCIDFromString(SS_motherTongue));

            //    SqlDataAdapter SS_adas = new SqlDataAdapter(SS_comm);
            //    DataSet SS_dset = new DataSet();
            //    SS_adas.Fill(SS_dset);

            //    dset.Merge(SS_dset);
            //    dgrdProfileMatchResults.DataSource = dset.Tables[0];

            //    if (SS_conn.State == ConnectionState.Open)
            //    {
            //        SS_conn.Close();
            //    }

            //}
            #endregion
        }

        public FrmProfileMatchResults(string Query, int CustomerBiodataID = 0)
        {
            InitializeComponent();

            customerBiodataID = CustomerBiodataID;
            Cursor.Current = Cursors.WaitCursor;
            BindData(true, Query);
            Cursor.Current = Cursors.Arrow;
        }

        private void BindData(bool LatestProfilesFirst, string Query)
        {
            string sqlQuery = Query;

            if (LatestProfilesFirst == true)
            {
                sqlQuery = sqlQuery.Replace("newid()", "Biodata.Rowidbiodata desc");
            }

            dstExcelExport = new SaatphereWIN.DAL.ClsCommon().GetDatasetonSQLQuery(sqlQuery);
            dgrdProfileMatchResults.DataSource = dstExcelExport.Tables[0];
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void frmProfileMatchResults_Load(object sender, EventArgs e)
        {
            dgrdProfileMatchResults.Columns[5].Visible = false;
            lblFranchisee.Text = SaatphereWIN.DAL.Global.Frusername;

            if(customerBiodataID != 0)

            lblRecordCount.Text = "Total Records: " + dgrdProfileMatchResults.Rows.Count.ToString();

            //If WithAddress = false then Export to Word button will be disabled.
            //There is no provision of sending profiles in Word for unpaid members
            if (!withAddress)
            {
                btnPdf.Enabled = false;
                lblMessageExporttoWord.Visible = true;
            }
        }

        public void BindDataMemAdvanceSearch()
        {
            SaatphereWIN.DAL.DataTypes.SearchFields SearchFields = new SaatphereWIN.DAL.DataTypes.SearchFields();
            SearchFields = searchFields;

            //If the customer for whom system is searching is a Paid Member then include the residenail address field as well
            string showResidentialAddress = string.Empty; //this includes the phone numbers and email address also
            if (withAddress)
            {
                showResidentialAddress = ", ResidentialAddress'Address', ContactDetail.Telephone1'Phone 1', ContactDetail.Telephone2'Phone 2', ContactDetail.EmailUser'Email Address',biodata.Email'Email Address2',Biodata.Biodata_Email2'Email Address3', ContactDetail.mobile'Mobile' ";
            }

            //string sqlstring = "select (CASE WHEN biodata.membershiptype <> 'Registered' THEN Convert(varchar, biodata.Rowidbiodata) + '#' ELSE Convert(varchar, biodata.rowidbiodata) END)'ID', (convert(varchar, biodata.FirstName))'Name', biodata.Gender, biodata.CityofResidence'City', biodata.Caste, biodata.EducationStatus'Education Status', biodata.Occupation, biodata.Religion, biodata.Country, biodata.Age, biodata.MartialStatus'Marital Status', biodata.Height, biodata.AnnualIncome'Annual Income', biodata.Biodata_CandidateLocation'Candidate Location', Biodata_EducationDetails'Education Details', Biodata_OccupationDetails'Occupation Details' from userlogin inner join contactdetail on contactdetail.contactdetailrowid = userlogin.actualrowid inner join biodata on biodata.rowidbiodata = userlogin.actualrowid where biodata.gender = @gender and biodata.status = 'Active' and Biodata.MembershipType <> 'Registered'";

            string heightfrom = SearchFields.HeightFrom.Replace(".", ""); 
            string heightto = SearchFields.HeightTo.Replace(".", ""); 
            string gender = SearchFields.Gender;
            string agefrom = SearchFields.AgeFrom;
            string ageto = SearchFields.AgeTo;
            string annualincomefrom = SearchFields.AnnualIncomeFrom;
            string annualincometo = SearchFields.AnnualIncomeTo;
            string occupation = SearchFields.Occupation;
            string maritialstatus = SearchFields.MaritalStatus;
            string diet = SearchFields.Diet;
            //string noofchildren = SearchFields.NoofChildren;
            string manglik = SearchFields.Manglik;
            string caste = SearchFields.Caste;
            string religion = SearchFields.Religion;
            string country = SearchFields.Country;
            string city = SearchFields.City;
            string education = SearchFields.Education;
            string candlocation = SearchFields.CandidateLocation;
            string castenobar = SearchFields.CasteNoBar;
            string motherTongue = SearchFields.Mothertongue;
            string state = SearchFields.State;
            string withPicture = SearchFields.WithPicture.ToString();                      

            SqlConnection conn = new SqlConnection(SaatphereWIN.DAL.Global.SaatphereCon);
            conn.Open();

            DataSet dset = new DataSet();

            if (gender == "Dosen't Matter" & heightfrom == "Dosen't Matter" & heightto == "Dosen't Matter" & agefrom == "Dosen't Matter" & ageto == "Dosen't Matter" & annualincomefrom == "Dosen't Matter" & annualincometo == "Dosen't Matter" & occupation == "Dosen't Matter" & maritialstatus == "Dosen't Matter" & diet == "Dosen't Matter" & caste == "Dosen't Matter" & religion == "Dosen't Matter" & country == "Dosen't Matter" & city == "Dosen't Matter" & candlocation == "Dosen't Matter" & education == "Dosen't Matter" & state == "Dosen't Matter")
            {
                SqlDataAdapter adas1 = new SqlDataAdapter(comm1);
                DataSet dset1 = new DataSet();
                adas1.Fill(dset1);
                dgrdProfileMatchResults.DataSource = dset1.Tables[0];
            }
            else
            {

                if (heightfrom != null && heightfrom.Length > 0 && heightfrom != "Dosen't Matter" & heightto != null && heightto != "Dosen't Matter")
                {
                    //if (heightfrom.Contains("'"))
                    //    heightfrom = heightfrom.Replace("'", "''");

                    //if (heightto.Contains("'"))
                    //    heightto = heightto.Replace("'", "''");

                    sqlstring = (sqlstring + " and convert(float, replace(height, '.','')) between " + heightfrom + " and " + heightto + " and height <> 'NULL' and height <> '--Select--' and height <> ''");

                    //sqlstring = (sqlstring + " and convert(float, replace(height, '.','')) between " + heightfrom + " and " + heightto );
                }

                if (heightfrom != null && heightfrom == "Dosen't Matter" & heightto != null && heightto.Length > 0 && heightto != "Dosen't Matter")
                {
                    //if (heightfrom.Contains("'"))
                    //    heightfrom = heightfrom.Replace("'", "''");

                    //if (heightto.Contains("'"))
                    //    heightto = heightto.Replace("'", "''");

                    sqlstring = (sqlstring + " and convert(float, replace(height, '.','')) <= " + heightto + " and height <> 'NULL' and height <> '--Select--' and height <> ''");

                    //sqlstring = (sqlstring + " and convert(decimal, Replace(replace(Height,'''' ,''),'\"','.')) = Replace(replace('" + heightto + "','\"' ,''),'''','.')");
                }

                if (heightfrom != null && heightfrom.Length > 0 && heightfrom != "Dosen't Matter" & heightto != null && heightto == "Dosen't Matter")
                {
                    //if (heightfrom.Contains("'"))
                    //    heightfrom = heightfrom.Replace("'", "''");

                    //if (heightto.Contains("'"))
                    //    heightto = heightto.Replace("'", "''");

                    sqlstring = (sqlstring + " and convert(float, replace(height, '.','')) >= " + heightfrom + " and height <> 'NULL' and height <> '--Select--' and height <> ''");

                    //sqlstring = sqlstring + " and convert(decimal, Replace(replace(Height,'''' ,''),'\"','.'))= Replace(replace('" + heightfrom + "','\"' ,''),'''','.')";
                }

                if (occupation!=null && occupation != "Dosen't Matter" && occupation != "")
                {
                    sqlstring = sqlstring + " and occupation IN ('" + occupation + "')";
                }

                if (maritialstatus == string.Empty)
                {
                    sqlstring = sqlstring + " and martialstatus = 'UnMarried'";
                    //Session["MaritialStatus"] = "True";//To prevent it to add on nextpage
                }
                else if (maritialstatus != "Dosen't Matter" && maritialstatus != "True")
                {
                    sqlstring = sqlstring + " and martialstatus = '" + maritialstatus + "'";
                }

                if (diet!=null && diet != "Dosen't Matter")
                {
                    sqlstring = sqlstring + " and diet = '" + diet + "'";
                }

                //if (noofchildren != null && noofchildren != "Dosen't Matter" && noofchildren != "")
                //{
                //    if (noofchildren == "0" || noofchildren == "")
                //    {
                //        sqlstring = sqlstring + " and numberofchildren= '" + noofchildren + "'";
                //    }
                //}

                if (manglik != "Dosen't Matter")
                {
                    sqlstring = sqlstring + " and manglik = '" + manglik+"'";

                }
                if (state != null && state != "Dosen't Matter" && state != "")
                {
                    sqlstring = sqlstring + " and state IN ('" + state + "')";
                }

                if (caste != null && caste != "Dosen't Matter" && caste != "")
                {
                    sqlstring = sqlstring + " and caste IN('" + caste + "')";
                }
                if (religion!=null && religion != "Dosen't Matter" && religion != "")
                {
                    sqlstring = sqlstring + " and religion IN('" + religion + "')";
                }
                if (country != null && country !="" && country != "Dosen't Matter")
                {
                    sqlstring = sqlstring + " and country = '" + country + "'";

                }
                if (city != null && city != "Dosen't Matter" && city.Length > 0)
                {
                    sqlstring = sqlstring + " and cityofresidence in ('" + city + "')";
                }
                if (candlocation != null && candlocation != "Dosen't Matter" && candlocation.Length > 0)
                {
                    sqlstring = sqlstring + " and biodata_candidatelocation in ('" + candlocation + "')";
                }
                if (education!=null && education != "'Dosen't Matter'" && education != "")
                {
                    sqlstring = sqlstring + " and educationstatus IN ('" + education + "')";
                }

                if (annualincomefrom != "Dosen't Matter" & annualincometo != "Dosen't Matter")
                {
                    sqlstring = sqlstring + " and convert(int,annualincome) BETWEEN " + annualincomefrom + " and " + annualincometo + " and annualincome <> 'Dosen''t Matter' and annualincome <> '--Select--' ";
                }

                if (annualincomefrom == "Dosen't Matter" & annualincometo != "Dosen't Matter")
                {
                    sqlstring = sqlstring + " and convert(int,annualincome) = " + annualincometo + " and annualincome <> 'Dosen''t Matter' and annualincome <> '--Select--' ";

                }
                if (annualincomefrom != "Dosen't Matter" & annualincometo == "Dosen't Matter")
                {
                    sqlstring = sqlstring + " and convert(int,annualincome) = " + annualincomefrom + " and annualincome <> 'Dosen''t Matter' and annualincome <> '--Select--' ";

                }
                if (annualincomefrom != "Dosen't Matter" & annualincometo != "Dosen't Matter")
                {
                    sqlstring = sqlstring.ToString();
                }

                if (agefrom != "Dosen't Matter" && ageto != "Dosen't Matter")
                {
                    sqlstring = sqlstring + " and Age BETWEEN " + agefrom + " and " + ageto;
                }
                else if (agefrom != "Dosen't Matter" && ageto == "Dosen't Matter")
                {
                    sqlstring = sqlstring + " and Age >= " + agefrom;
                }
                else if (agefrom == "Dosen't Matter" && ageto != "Dosen't Matter")
                {
                    sqlstring = sqlstring + " and Age <= " + ageto;
                }

                if (castenobar != "Doesn't Matter" && castenobar != "")
                {
                    sqlstring = sqlstring + " and castenobar = '" + castenobar + "'";
                }

                if (motherTongue != null && motherTongue != "'Dosen't Matter'" && motherTongue != "")
                {
                    sqlstring = sqlstring + " and Mothertongue IN ('" + motherTongue + "')";
                }

                if (withPicture == "True")
                {
                    sqlstring = sqlstring + " and convert(varchar,Photograph) NOT IN ('', 'Not Avaliable') and Photograph IS NOT NULL";
                }

                //Reason, If Internal Visibility is NO, biodata shouldnt be visible in searching
                //sqlstring = sqlstring + " and (biodata_visibleinside in('True', NULL))";

                //It is taking "order by SNO" again in the mid and hence producing error, as a trick we will remove it if it is coming in between
                //of the query, and will place it in the last
                if (sqlstring.Contains("order by Convert(int, rowidbiodata) desc"))
                {
                    sqlstring = sqlstring.Replace("order by Convert(int, rowidbiodata) desc", "");
                    sqlstring = sqlstring + " order by Convert(int, rowidbiodata) desc";
                }


                if (!sqlstring.Contains("order by Convert(int, rowidbiodata) desc"))
                {
                    sqlstring = sqlstring + " order by Convert(int, rowidbiodata) desc";
                }

                //Replaces the gender
                sqlstring = sqlstring.Replace("@gender", "'" + SearchFields.Gender + "'");

                SqlCommand comm = new SqlCommand(sqlstring, conn);
                SqlDataAdapter adas = new SqlDataAdapter(comm);
                adas.Fill(dset);

                dstExcelExport = dset;
                dgrdProfileMatchResults.DataSource = dset.Tables[0];

            }
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        private void dgrdProfileMatchResults_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SaatphereWIN.DAL.DataTypes.SearchResults searchResults = new SaatphereWIN.DAL.DataTypes.SearchResults();

            searchResults.Age = dgrdProfileMatchResults.Rows[row].Cells["Age"].Value.ToString() + " yrs.";
            searchResults.Caste = dgrdProfileMatchResults.Rows[row].Cells["caste"].Value.ToString();
            searchResults.City = dgrdProfileMatchResults.Rows[row].Cells["city"].Value.ToString();
            searchResults.Country = dgrdProfileMatchResults.Rows[row].Cells["country"].Value.ToString();
            searchResults.EducationStatus = dgrdProfileMatchResults.Rows[row].Cells["education status"].Value.ToString();
            searchResults.Gender = dgrdProfileMatchResults.Rows[row].Cells["gender"].Value.ToString();
            searchResults.Id = dgrdProfileMatchResults.Rows[row].Cells["id"].Value.ToString();
            searchResults.Name = new SaatphereWIN.DAL.ClsCommon().RemoveHtmlTag(dgrdProfileMatchResults.Rows[row].Cells["name"].Value.ToString());
            searchResults.Occupation = dgrdProfileMatchResults.Rows[row].Cells["occupation"].Value.ToString();
            searchResults.Photograph = dgrdProfileMatchResults.Rows[row].Cells["photograph"].Value.ToString();
            searchResults.Religion = dgrdProfileMatchResults.Rows[row].Cells["religion"].Value.ToString();


            new FrmProfileDetails(searchResults, customerBiodataID, this).Show();
            //frmProfileDetails profileDetails = new frmProfileDetails(searchResults, customerBiodataID);
            //if (profileDetails.ShowDialog(this) == DialogResult.OK)
            //{
            //    lstSelectedProfiles.Items.Add(profileDetails.getSelectedProfileID);
            //}
            //profileDetails.Close();
            //profileDetails.Dispose();


        }

        private void dgrdProfileMatchResults_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            col = e.ColumnIndex;
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= dgrdProfileMatchResults.Rows.Count - 1; i++)
            {

                searchResults.Age = dgrdProfileMatchResults.Rows[i].Cells["Age"].Value.ToString() + " yrs.";
                searchResults.Caste = dgrdProfileMatchResults.Rows[i].Cells["caste"].Value.ToString();
                searchResults.City = dgrdProfileMatchResults.Rows[i].Cells["city"].Value.ToString();
                searchResults.Country = dgrdProfileMatchResults.Rows[i].Cells["country"].Value.ToString();
                searchResults.EducationStatus = dgrdProfileMatchResults.Rows[i].Cells["educationstatus"].Value.ToString();
                searchResults.Gender = dgrdProfileMatchResults.Rows[i].Cells["gender"].Value.ToString();
                searchResults.Id = dgrdProfileMatchResults.Rows[i].Cells["id"].Value.ToString();
                searchResults.Name = new SaatphereWIN.DAL.ClsCommon().RemoveHtmlTag(dgrdProfileMatchResults.Rows[i].Cells["name"].Value.ToString());
                searchResults.Occupation = dgrdProfileMatchResults.Rows[i].Cells["occupation"].Value.ToString();
                searchResults.Photograph = dgrdProfileMatchResults.Rows[i].Cells["photograph"].Value.ToString();
                searchResults.Religion = dgrdProfileMatchResults.Rows[i].Cells["religion"].Value.ToString();

                new FrmProfileDetails(searchResults, customerBiodataID, this).Show();
            }
        }

        private void dgrdProfileMatchResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgrdProfileMatchResults_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void selectProfieToSendToolStripMenuItem_Click(object sender, EventArgs e)
        {          


            if (!lstSelectedProfiles.Items.Contains(dgrdProfileMatchResults.Rows[row].Cells[0].Value.ToString()))
            {
                lstSelectedProfiles.Items.Add(dgrdProfileMatchResults.Rows[row].Cells[0].Value.ToString());
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(lstSelectedProfiles);
            selectedItems = lstSelectedProfiles.SelectedItems;

            if (lstSelectedProfiles.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    lstSelectedProfiles.Items.Remove(selectedItems[i]);
            }
        }

        private void SendProfiles(string ReceiverEmailAddress)
        {
            Cursor.Current = Cursors.WaitCursor;

            string franchiseeName = lblFranchisee.Text;
            string searchValue = string.Empty;
            string gridviewEmailString = string.Empty;// SaatphereWIN.DAL.Global.Template_ProfilesWithoutAddress;//getHTML(dtlSelected);
            string finalEmailBody = string.Empty;
            string profileIDsCollection = string.Empty;
            DateTime profileSendDate = DateTime.Now;
            string contact = string.Empty;
            


            //Read the Email Template
            //------------------------------------------------------------------------
            string templateContent = System.IO.File.ReadAllText("Templates//ProfileMatch//Template1//" + franchiseeName + ".html");

            if (lstSelectedProfiles.Items.Count > 0)
            {
                ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(lstSelectedProfiles);
                selectedItems = lstSelectedProfiles.SelectedItems;

                if (lstSelectedProfiles.SelectedIndex != -1)
                {
                    for (int i = selectedItems.Count - 1; i >= 0; i--)
                    {
                        dgrdProfileMatchResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        foreach (DataGridViewRow row in dgrdProfileMatchResults.Rows)
                        {
                            if (row.Cells[0].Value.ToString().Equals(selectedItems[i]))
                            {
                                gridviewEmailString = SaatphereWIN.DAL.Global.TemplateProfilesWithoutAddress;

                                gridviewEmailString = gridviewEmailString.Replace("{name}", row.Cells["name"].Value.ToString());
                                gridviewEmailString = gridviewEmailString.Replace("{educationstatus}", row.Cells["education status"].Value.ToString());
                                gridviewEmailString = gridviewEmailString.Replace("{occupation}", row.Cells["occupation"].Value.ToString());
                                gridviewEmailString = gridviewEmailString.Replace("{religion}", row.Cells["religion"].Value.ToString());
                                gridviewEmailString = gridviewEmailString.Replace("{country}", row.Cells["country"].Value.ToString());
                                gridviewEmailString = gridviewEmailString.Replace("{profileid}", row.Cells["ID"].Value.ToString());
                                gridviewEmailString = gridviewEmailString.Replace("{caste}", row.Cells["caste"].Value.ToString());
                                gridviewEmailString = gridviewEmailString.Replace("{city}", row.Cells["city"].Value.ToString());
                                string viewMoreDetails = "http://admin.peopleonegroup.com/PROFILEMATCH/biodatafinal.aspx?biodataid=" + row.Cells["id"].Value.ToString() + "-" + (Convert.ToInt32(row.Cells["id"].Value.ToString().Replace("#", "")) + 1000).ToString() + row.Cells["name"].Value.ToString();
                                gridviewEmailString = gridviewEmailString.Replace("{viewmoredetails}", "<a href='" + viewMoreDetails + "'>View more Details</a>");
                                gridviewEmailString = gridviewEmailString.Replace("{image}", "<img alt='' src='" + row.Cells["photograph"].Value.ToString() + "' />");
                                                               
                                try
                                {
                                    gridviewEmailString = gridviewEmailString.Replace("{contact}", row.Cells["Phone 1"].Value.ToString() + " , " + row.Cells["Phone 2"].Value.ToString() + " , " + row.Cells["Mobile"].Value.ToString());
                                    gridviewEmailString = gridviewEmailString.Replace("{emailaddress1}", row.Cells["Email Address1"].Value.ToString());
                                    gridviewEmailString = gridviewEmailString.Replace("{emailaddress2}", row.Cells["Email Address2"].Value.ToString());
                                    gridviewEmailString = gridviewEmailString.Replace("{emailaddress3}", row.Cells["Email Address3"].Value.ToString());
                                    gridviewEmailString = gridviewEmailString.Replace("{contactpersonname}", row.Cells["Contact Person Name"].Value.ToString());
                                }
                                catch (Exception)
                                {
                                    gridviewEmailString = gridviewEmailString.Replace("{contact}", "");
                                    gridviewEmailString = gridviewEmailString.Replace("{emailaddress1}", "");
                                    gridviewEmailString = gridviewEmailString.Replace("{emailaddress2}", "");
                                    gridviewEmailString = gridviewEmailString.Replace("{emailaddress3}", "");
                                    gridviewEmailString = gridviewEmailString.Replace("{contactpersonname}", "");
                                    //throw;
                                }                               

                                try //As of now we dont have mechanism to handle the null 
                                {
                                    gridviewEmailString = gridviewEmailString.Replace("{address}", row.Cells["Address"].Value.ToString());
                                }
                                catch (Exception)
                                {
                                    gridviewEmailString = gridviewEmailString.Replace("{address}", "");
                                }

                                //initialize variables
                                contact = string.Empty;

                                finalEmailBody = finalEmailBody + gridviewEmailString;
                                profileIDsCollection += row.Cells["ID"].Value.ToString() + ",";
                            }
                        }
                    }
                }

                string toUser = "Admin";
                string receiver = txtReceiver.Text;
                string receiver2 = string.Empty;
                receiver = ReceiverEmailAddress;

                templateContent = templateContent.Replace("$$text$$", txtMessage.Text);
                templateContent = templateContent.Replace("$$Regards$$", "");
                templateContent = templateContent.Replace("$$USERPROFILE$$", customerName + "&nbsp;&nbsp;(ID-&nbsp;" + (customerBiodataID.ToString() == "0"? "Guest": customerBiodataID.ToString()) + ")");
                templateContent = templateContent.Replace("$$PROFILES$$", finalEmailBody);
                templateContent = templateContent.Replace("{UNSUBSCRIBE}", SaatphereWIN.DAL.Global.SaatphereUrl + "/unsubscribe/Unsubscribe.aspx?Email=" + receiver);
                
                //Log the Ids of which the Addresses are sending so that the following could get capture
                //1. Number of times the Addresses have sent to the customer. etc
                //----------------------------------------------------------------------------------------
                string[] strArray = profileIDsCollection.Split(',') ;

                for (int i = 0; i <= strArray.GetUpperBound(0) - 1; i++)
                {
                    //checking if same (own) profile is choice id(Some time clients wants to see her/his profiles), then shld not counted in remainder
                    if ((Convert.ToInt32(strArray[i].Replace("#",""))) != customerBiodataID)
                    {
                        //checking if choice id is already in FavoriteCustomer or not, if yes then it shld not counted in remainder
                        {
                        }
                    }
                }


                //Tracks the profiles sent to the user, this also works in the Reminder functionality
                //---------------------------------------------------------------------------------------------------------------------------------------------------------
                string[] profilesCollection = profileIDsCollection.Split(',');
                for (int i = 0; i <= profilesCollection.GetUpperBound(0) - 1; i++)
                {
                    profileSendDate = DateTime.Now;
                }
                //---------------------------------------------------------------------------------------------------------------------------------------------------------

                //Sends mail to the User
                if (receiver.Length > 0)
                {
                }
                else
                {
                    //MessageBox.Show("Profiles sent failure. No Receiver email found.", "Information - Profile Sent failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("There are no profiles selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Cursor.Current = Cursors.Arrow;
        }

        private void SendProfilestoPDF()
        {
            Cursor.Current = Cursors.WaitCursor;

            string franchiseeName = lblFranchisee.Text;
            string searchValue = string.Empty;
            string gridviewEmailString = string.Empty;// SaatphereWIN.DAL.Global.Template_ProfilesWithoutAddress;//getHTML(dtlSelected);
            string finalEmailBody = string.Empty;
            string profileIDsCollection = string.Empty;

            DateTime profileSendDate = DateTime.Now;
            string profilesHTML = string.Empty;
            SaatphereWIN.DAL.DataTypes.Biodata biodataDetails = new SaatphereWIN.DAL.DataTypes.Biodata();

            //Read the Email Template
            //------------------------------------------------------------------------
            //string profileHTML = File.ReadAllText("Templates//WordProfiles//structure_white_blue//profileContent.html");
            string profiles = File.ReadAllText("Templates//WordProfiles//structure_white_blue//Profiles.html");

            string profileContent = string.Empty;

            if (lstSelectedProfiles.Items.Count > 0)
            {
                ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(lstSelectedProfiles);
                selectedItems = lstSelectedProfiles.SelectedItems;

                if (lstSelectedProfiles.SelectedIndex != -1)
                {
                    for (int i = selectedItems.Count - 1; i >= 0; i--)
                    {
                        //MessageBox.Show(selectedItems[i].ToString());

                    }
                }

                profiles = profiles.Replace("{profiletable}", profileContent); //profiles is the html template and profilehtml is the table containing data

                string receiverID = customerBiodataID.ToString();
                string tempFileHTML = Path.GetTempFileName() ;// Path.GetTempPath() + Guid.NewGuid() + ".html";

                if (File.Exists(tempFileHTML))
                    File.Delete(tempFileHTML);

                File.WriteAllText(tempFileHTML, profiles);                

                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string exportPath = folderBrowserDialog1.SelectedPath + "/" + receiverID.ToString() + ".doc";

                    Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
                    Microsoft.Office.Interop.Word.Document wordDoc = new Microsoft.Office.Interop.Word.Document();
                    Object oMissing = System.Reflection.Missing.Value;
                    wordDoc = word.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                    word.Visible = false;
                    Object filepath = tempFileHTML;
                    Object confirmconversion = System.Reflection.Missing.Value;
                    Object readOnly = false;
                    Object saveto = exportPath;
                    Object oallowsubstitution = System.Reflection.Missing.Value;

                    wordDoc = word.Documents.Open(ref filepath, ref confirmconversion, ref readOnly, ref oMissing,
                                                      ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                      ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                      ref oMissing, ref oMissing, ref oMissing, ref oMissing);

                    object fileFormat = WdSaveFormat.wdFormatDocument;
                    wordDoc.SaveAs(ref saveto, ref fileFormat, ref oMissing, ref oMissing, ref oMissing,
                                       ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                       ref oMissing, ref oMissing, ref oMissing, ref oallowsubstitution, ref oMissing,
                                       ref oMissing);
                    wordDoc.Close();

                    MessageBox.Show("Profile has exported to Word successfully at the location:\n" + exportPath, "Information - Saatphere", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



                //string[] strArray = profileIDsCollection.Split(',');

                //for (int i = 0; i <= strArray.GetUpperBound(0) - 1; i++)
                //{
                //    //checking if same (own) profile is choice id(Some time clients wants to see her/his profiles), then shld not counted in remainder
                //    if ((Convert.ToInt32(strArray[i].Replace("#", ""))) != customerBiodataID)
                //    {
                //        //checking if choice id is already in FavoriteCustomer or not, if yes then it shld not counted in remainder
                //        if (!new SaatphereWIN.DAL.Membership.clsSelect().GetAlreadyTakenDetails(customerBiodataID, Convert.ToInt32(strArray[i].Replace("#", ""))))
                //        {
                //            new SaatphereWIN.DAL.Membership.clsInsert().InsertProfileSentLog(customerBiodataID, Convert.ToInt32(strArray[i].Replace("#", "")));
                //        }
                //    }
                //}

                ////Tracks the profiles sent to the user, this also works in the Reminder functionality
                ////---------------------------------------------------------------------------------------------------------------------------------------------------------
                //string[] profilesCollection = profileIDsCollection.Split(',');
                //for (int i = 0; i <= profilesCollection.GetUpperBound(0) - 1; i++)
                //{
                //    profileSendDate = DateTime.Now;
                //    new SaatphereWIN.DAL.User.clsInsert().InsertProfileMatchLog(0, receiver, "", profileSendDate, Convert.ToInt32(profilesCollection[i].Replace("#", "")));
                //}
                ////---------------------------------------------------------------------------------------------------------------------------------------------------------
            }
            else
            {
                MessageBox.Show("There are no profiles selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Cursor.Current = Cursors.Arrow;
        }

        private string SetProfileHTMLData(SaatphereWIN.DAL.DataTypes.Biodata biodataDetails)
        {
            string profileHTML = File.ReadAllText("Templates//WordProfiles//structure_white_blue//profileContent.html"); ;

            profileHTML = profileHTML.Replace("{id}", biodataDetails.RowIdBiodata.ToString());
            profileHTML = profileHTML.Replace("{age}", biodataDetails.Age.ToString());
            profileHTML = profileHTML.Replace("{name}", biodataDetails.FirstName.ToString());
            profileHTML = profileHTML.Replace("{gender}", biodataDetails.Gender.ToString());
            profileHTML = profileHTML.Replace("{height}", biodataDetails.Height.ToString());
            profileHTML = profileHTML.Replace("{complexion}", biodataDetails.Complextion.ToString());
            profileHTML = profileHTML.Replace("{bodytype}", biodataDetails.BodyType.ToString());
            profileHTML = profileHTML.Replace("{diet}", biodataDetails.Diet.ToString());

            profileHTML = profileHTML.Replace("{city}", biodataDetails.CityofResidence.ToString());
            //profileHTML = profileHTML.Replace("{state}", biodataDetails.State.ToString());
            profileHTML = profileHTML.Replace("{country}", biodataDetails.Country.ToString());
            profileHTML = profileHTML.Replace("{clocation}", biodataDetails.CandidateLocation.ToString());
            profileHTML = profileHTML.Replace("{dateofbirth}", biodataDetails.DateofBirth.ToString());
            profileHTML = profileHTML.Replace("{timeofbirth}", biodataDetails.TimeofBirthH + " : " + biodataDetails.TimeofBirthM);
            profileHTML = profileHTML.Replace("{placeofbirth}", biodataDetails.PlaceofBirth.ToString());
            profileHTML = profileHTML.Replace("{manglik}", biodataDetails.Manglik.ToString());

            profileHTML = profileHTML.Replace("{religion}", biodataDetails.Religion.ToString());
            profileHTML = profileHTML.Replace("{caste}", biodataDetails.Caste.ToString());
            profileHTML = profileHTML.Replace("{subcaste}", biodataDetails.SubCaste.ToString());
            profileHTML = profileHTML.Replace("{gotra}", biodataDetails.Gotra.ToString());
            profileHTML = profileHTML.Replace("{mothertongue}", biodataDetails.Mothertongue.ToString());
            profileHTML = profileHTML.Replace("{education}", biodataDetails.EducationStatus.ToString());
            profileHTML = profileHTML.Replace("{occupation}", biodataDetails.Occupation.ToString());
            profileHTML = profileHTML.Replace("{annualincome}", biodataDetails.AnnualIncome.ToString());

            profileHTML = profileHTML.Replace("{fatheroccupation}", biodataDetails.AboutFather.ToString());
            profileHTML = profileHTML.Replace("{motheroccupation}", biodataDetails.AboutMother.ToString());
            profileHTML = profileHTML.Replace("{brotheroccupation}", biodataDetails.BrotherDetails.ToString());
            profileHTML = profileHTML.Replace("{sisterocupation}", biodataDetails.SisterDetails.ToString());

            //profileHTML = profileHTML.Replace("{preferredpartner}", biodataDetails.PreferredPartner.ToString());
            profileHTML = profileHTML.Replace("{aboutmyfamily}", biodataDetails.RowIdBiodata.ToString());
            profileHTML = profileHTML.Replace("{occupatondetails}", biodataDetails.AboutCandidateFamily.ToString());
            profileHTML = profileHTML.Replace("{moreaboutmyself}", biodataDetails.MoreaboutCandidate.ToString());
            profileHTML = profileHTML.Replace("{educationdetails}", biodataDetails.EducationDetails.ToString());

            profileHTML = profileHTML.Replace("{fatherdetails}", biodataDetails.FatherDetails.ToString());
            profileHTML = profileHTML.Replace("{motherdetails}", biodataDetails.MotherDetails.ToString());
            profileHTML = profileHTML.Replace("{sisterdetails}", biodataDetails.SisterDetails.ToString());
            profileHTML = profileHTML.Replace("{brotherdetails}", biodataDetails.BrotherDetails.ToString());
            profileHTML = profileHTML.Replace("{otherdetails}", biodataDetails.CandidateOtherDetails.ToString());

            profileHTML = profileHTML.Replace("{candidatename}", biodataDetails.FirstName.ToString());
            profileHTML = profileHTML.Replace("{candidatelocation}", biodataDetails.CandidateLocation.ToString());
            profileHTML = profileHTML.Replace("{address}", biodataDetails.ResidentialAddress.ToString());
            profileHTML = profileHTML.Replace("{contactno1}", biodataDetails.ResidenceNo.ToString());
            profileHTML = profileHTML.Replace("{contactno2}", biodataDetails.OfficeNo.ToString());
            profileHTML = profileHTML.Replace("{mobileno}", biodataDetails.Mobile.ToString());
            profileHTML = profileHTML.Replace("{email}", biodataDetails.Email.ToString() + " , " + biodataDetails.Email2.ToString());

            string userImagePath = string.Empty;

            if (biodataDetails.Photograph.Length > 0)
            {
                userImagePath = SaatphereWIN.DAL.Global.BiodataImagePathPrefix + biodataDetails.Photograph.Substring(0, 1) + "-Images/" + biodataDetails.Photograph;
                profileHTML = profileHTML.Replace("{imagesource}", userImagePath);
            }

            return profileHTML;
        }

        private void dgrdProfileMatchResults_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    row = e.RowIndex;
                    col = e.ColumnIndex;

                    dgrdProfileMatchResults.CurrentCell = dgrdProfileMatchResults.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dgrdProfileMatchResults.Rows[e.RowIndex].Selected = true;
                    dgrdProfileMatchResults.Focus();
                }
                catch (Exception)
                {
                }
            }
        }

        private void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            string recordsCounttoExport = txtExportRecordCount.Text.Trim();
            if (recordsCounttoExport.Length > 0)
            {
                int n;
                if (int.TryParse(recordsCounttoExport, out n))
                {
                    try
                    {
                        FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                        if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            string backupPath = folderBrowserDialog1.SelectedPath;
                            string fileName = "SaatphereExportData_" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;

                            BackupExcelSeparateSheet(dstExcelExport, backupPath, fileName , Convert.ToInt32(recordsCounttoExport));
                            MessageBox.Show("Data has exported successfully.\nFilename: " + backupPath + fileName, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public void BackupExcelSeparateSheet(DataSet ExportDataset, string destination, string TableName, int RowCount)
        {
            Cursor.Current = Cursors.WaitCursor;

            bool dataError = false;

            DataSet dstTemp = new DataSet();

            //if grid has less rows than the specified count then it will try to export another row, which is not there
            if (ExportDataset.Tables[0].Rows.Count <= RowCount)
                RowCount = ExportDataset.Tables[0].Rows.Count;

            try
            {
                dstTemp = ExportDataset;

                //Remove Photograph column as per the business logic
                if (dstTemp.Tables[0].Columns.Contains("Photograph"))
                {
                    dstTemp.Tables[0].Columns.Remove("Photograph");
                }

            }
            catch (Exception)
            {
                dataError = true;
            }

            if (File.Exists(destination + "\\" + TableName + ".xls"))
                File.Delete(destination + "\\" + TableName + ".xls");

            //si Excel, 
            //créer un classeur avec un nom de table EmployeeData. La table a different champs
            //string tableName = string.Empty;
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + destination + "\\" + TableName + ".xls; Extended Properties='Excel 8.0;HDR=YES'"; ;
            conn.Open();

            if (dataError == false)
            {
                if (dstTemp.Tables.Count > 0)
                {
                    //extraire les colonnes de la table de données
                    string cols = string.Empty;
                    for (int i = 0; i <= dstTemp.Tables[0].Columns.Count - 1; i++)
                    {
                        cols = cols + "[" + dstTemp.Tables[0].Columns[i].ColumnName.ToString() + "] varchar(255), ";
                    }
                    cols = cols.Substring(0, cols.Length - 2);

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();

                    //extraire les colonnes de la table source
                    string colsDest = string.Empty;
                    string colsValues = string.Empty;
                    string fieldValue = string.Empty;

                    for (int i = 0; i <= dstTemp.Tables[0].Columns.Count - 1; i++)
                    {
                        colsDest = colsDest + "left([" + dstTemp.Tables[0].Columns[i].ColumnName.ToString() + "],255) , ";
                    }
                    colsDest = colsDest.Substring(0, colsDest.Length - 2);

                    //Insérez l'enregistrement de la table
                    //for (int rowData = 0; rowData <= dstTemp.Tables[0].Rows.Count - 1; rowData++)
                    for (int rowData = 0; rowData <= RowCount - 1; rowData++)
                    {
                        for (int colData = 0; colData <= dstTemp.Tables[0].Columns.Count - 1; colData++)
                        {
                            fieldValue = dstTemp.Tables[0].Rows[rowData][colData].ToString();
                            if (fieldValue.Contains(""))
                            {
                                fieldValue = string.Empty;
                            }

                            if (fieldValue.Length >= 250)
                            {
                                try
                                {
                                    colsValues = colsValues + "'" + fieldValue.Substring(1, 250).Replace("'", "''") + "',";
                                }
                                catch (Exception)
                                {

                                }
                            }
                            else
                            {
                                colsValues = colsValues + "'" + fieldValue.Replace("'", "''") + "',";
                            }

                        }
                        colsValues = colsValues.Substring(0, colsValues.Length - 1);

                        cmd.CommandText = "INSERT INTO [" + TableName + "] values (" + colsValues + ")";
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {

                        }

                        colsValues = string.Empty;
                    }
                }
            }
            else
            {

            }
            conn.Close();
            Cursor.Current = Cursors.Default;
        }

        private void btnSelectMultipleProfiles_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgrdProfileMatchResults.SelectedRows)
            {               
                if (!lstSelectedProfiles.Items.Contains(r.Cells[0].Value.ToString()))
                {
                    lstSelectedProfiles.Items.Add(r.Cells[0].Value.ToString());
                }
            }
            dgrdProfileMatchResults.ClearSelection();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string receiver = txtReceiver.Text.Trim();
            if(receiver.Length > 0)
            {
                if(receiver.Contains(",")) //means there are multiple email ids separated by comma
                {
                    string[] strEmailArray = receiver.Split(',');

                    for (int i = 0; i<= strEmailArray.GetUpperBound(0); i++)
                    {
                    }
                }
                else
                {
                }
                MessageBox.Show("Selected profiles has sent successfully.", "Information - Profile Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Receiver email id is mandatory.", "Error: Cannot send profiles", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for(int i=0;i<= lstSelectedProfiles.Items.Count -1;i ++)
                lstSelectedProfiles.SetSelected(i, true);
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
        }

        private void lblMessageExporttoWord_DoubleClick(object sender, EventArgs e)
        {

        }

        private void lblMessageExporttoWord_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You cannot export profiles for Unpaid Members.", "Information - Saatphere", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
