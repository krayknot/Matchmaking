using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using SaatphereWIN.DAL.Masters;

namespace Saatphere_WIN
{
    public partial class frmCustomerDetails : Form
    {
        int rowId = 0;
        string frusername = string.Empty;
        int frid = 0;
        string frowid = string.Empty;

        public frmCustomerDetails(SaatphereWIN.DAL.DataTypes.Biodata BioDataDetails)
        {
            InitializeComponent();
            biodataDetails = BioDataDetails;
        }
        
        /// <summary>
        /// This method will be called at the time of Editing biodata
        /// </summary>
        /// <param name="BiodataID"></param>
        public frmCustomerDetails(int BiodataID, bool ComingFromCustomerMaster = false, SaatphereWIN.DAL.DataTypes.CustomerMaster CustomerMasterDetails = null)
        {
            InitializeComponent();

            Cursor.Current = Cursors.WaitCursor;

            //Get biodata details here
            #region Start Details
            DataSet dstBiodata = new DataSet();
            //SaatphereWIN.DAL.DataTypes.Biodata BiodataDetails = new SaatphereWIN.DAL.DataTypes.Biodata();    

            biodataDetails.CityofResidence = dstBiodata.Tables[0].Rows[0]["CityofResidence"].ToString(); 
            biodataDetails.Country= dstBiodata.Tables[0].Rows[0]["Country"].ToString(); 
            biodataDetails.Email= dstBiodata.Tables[0].Rows[0]["Email"].ToString(); 
            biodataDetails.ResidentialAddress= dstBiodata.Tables[0].Rows[0]["ResidentialAddress"].ToString(); 
            biodataDetails.PinCode= dstBiodata.Tables[0].Rows[0]["Pincode"].ToString(); 
            biodataDetails.ResidenceNo= dstBiodata.Tables[0].Rows[0]["ResidenceNo"].ToString(); 
            biodataDetails.Mobile= dstBiodata.Tables[0].Rows[0]["Mobile"].ToString(); 
            biodataDetails.Email2= dstBiodata.Tables[0].Rows[0]["Biodata_Email2"].ToString(); 
            biodataDetails.FirstName= dstBiodata.Tables[0].Rows[0]["Firstname"].ToString(); 

            biodataDetails.RowIdBiodata = (int)dstBiodata.Tables[0].Rows[0]["RowIDBioData"];
            biodataDetails.SurName = dstBiodata.Tables[0].Rows[0]["Surname"].ToString(); 
            biodataDetails.MiddleName=dstBiodata.Tables[0].Rows[0]["MiddleName"].ToString() ; 
            biodataDetails.Gender=dstBiodata.Tables[0].Rows[0]["Gender"].ToString() ; 
            biodataDetails.DateofBirth=dstBiodata.Tables[0].Rows[0]["DateofBirth"].ToString() ; 
            biodataDetails.CityofResidence=dstBiodata.Tables[0].Rows[0]["CityofResidence"].ToString() ; 
            biodataDetails.Country= dstBiodata.Tables[0].Rows[0]["Country"].ToString() ; 
            biodataDetails.Email=dstBiodata.Tables[0].Rows[0]["Email"].ToString() ; 

            biodataDetails.ResidentialAddress=dstBiodata.Tables[0].Rows[0]["ResidentialAddress"].ToString() ; 
            biodataDetails.PinCode= dstBiodata.Tables[0].Rows[0]["Pincode"].ToString() ; 
            biodataDetails.ResidenceNo=dstBiodata.Tables[0].Rows[0]["Residenceno"].ToString() ; 
            biodataDetails.OfficeNo=dstBiodata.Tables[0].Rows[0]["Officeno"].ToString() ; 
            biodataDetails.Mobile=dstBiodata.Tables[0].Rows[0]["Mobile"].ToString() ; 
            biodataDetails.BiodataCreatedBy=dstBiodata.Tables[0].Rows[0]["Biodatacreatedby"].ToString() ; 
            biodataDetails.MaritalStatus=dstBiodata.Tables[0].Rows[0]["Martialstatus"].ToString() ;
            biodataDetails.MarriedBrothers=dstBiodata.Tables[0].Rows[0]["Marriedbrothers"].ToString() ;
            biodataDetails.UnmarriedBrother=dstBiodata.Tables[0].Rows[0]["Unmarriedbrother"].ToString() ;
            biodataDetails.MarriedSister=dstBiodata.Tables[0].Rows[0]["Marriedsister"].ToString() ;
            biodataDetails.UnmarriedSister=dstBiodata.Tables[0].Rows[0]["Unmarriedsister"].ToString() ;
            biodataDetails.NumberofChildren=dstBiodata.Tables[0].Rows[0]["Numberofchildren"].ToString() ;
            biodataDetails.PlaceofBirth=dstBiodata.Tables[0].Rows[0]["Placeofbirth"].ToString() ;
            biodataDetails.EducationStatus=dstBiodata.Tables[0].Rows[0]["Educationstatus"].ToString() ;
            biodataDetails.Complextion=dstBiodata.Tables[0].Rows[0]["Complxtion"].ToString() ; 
            biodataDetails.AboutMother=dstBiodata.Tables[0].Rows[0]["Aboutmother"].ToString() ;
            biodataDetails.AboutFather= dstBiodata.Tables[0].Rows[0]["Aboutfather"].ToString() ; 
                
            biodataDetails.Occupation=dstBiodata.Tables[0].Rows[0]["Occupation"].ToString() ;
            biodataDetails.BodyType=dstBiodata.Tables[0].Rows[0]["Bodytype"].ToString() ; 
            biodataDetails.Diet=dstBiodata.Tables[0].Rows[0]["Diet"].ToString() ; 
            biodataDetails.Manglik=dstBiodata.Tables[0].Rows[0]["Manglik"].ToString() ; 
            biodataDetails.Religion=dstBiodata.Tables[0].Rows[0]["Religion"].ToString() ;
            biodataDetails.Caste=dstBiodata.Tables[0].Rows[0]["Caste"].ToString() ;
            biodataDetails.Mothertongue=dstBiodata.Tables[0].Rows[0]["Mothertongue"].ToString() ;
            biodataDetails.Hearaboutus=dstBiodata.Tables[0].Rows[0]["Hearaboutus"].ToString() ;
            biodataDetails.MoreaboutCandidate= dstBiodata.Tables[0].Rows[0]["Moreaboutcandidate"].ToString() ;
            biodataDetails.ExpectedPartner=dstBiodata.Tables[0].Rows[0]["Expectedpartner"].ToString() ; 
            biodataDetails.Remark=dstBiodata.Tables[0].Rows[0]["Remark"].ToString() ; 
            biodataDetails.PhysicallyChallenged=dstBiodata.Tables[0].Rows[0]["Phusicallychallenged"].ToString() ; 
            biodataDetails.FirstName=dstBiodata.Tables[0].Rows[0]["Firstname"].ToString() ; 
            biodataDetails.Height=dstBiodata.Tables[0].Rows[0]["Height"].ToString() ;

            biodataDetails.BiodataLocality= dstBiodata.Tables[0].Rows[0]["Biodata_Locality"].ToString();
            biodataDetails.BloodGroup = dstBiodata.Tables[0].Rows[0]["Biodata_BloodGroup"].ToString();


            try
            {
                biodataDetails.BiodataNriAcceptable = Convert.ToBoolean(dstBiodata.Tables[0].Rows[0]["Biodata_NRIAcceptable"]);
            }
            catch (Exception)
            {                
            }
            

            try
            {
                biodataDetails.BiodataWeight = Convert.ToDecimal(dstBiodata.Tables[0].Rows[0]["Biodata_Weight"]);
            }
            catch (Exception)
            {
                //throw;
            }      
            
            biodataDetails.Gotra=dstBiodata.Tables[0].Rows[0]["Gotra"].ToString() ; 
            biodataDetails.AnnualIncome=dstBiodata.Tables[0].Rows[0]["AnnualIncome"].ToString() ;
            biodataDetails.TimeofBirthH=dstBiodata.Tables[0].Rows[0]["TimeofBirthh"].ToString() ;
            biodataDetails.TimeofBirthM=dstBiodata.Tables[0].Rows[0]["TimeofBirthm"].ToString() ; 
            biodataDetails.CitypCode=dstBiodata.Tables[0].Rows[0]["Citypcode"].ToString() ; 
            biodataDetails.OfficepCode=dstBiodata.Tables[0].Rows[0]["Officepcode"].ToString() ;
                    
            biodataDetails.Age=dstBiodata.Tables[0].Rows[0]["Age"].ToString() ; 

            biodataDetails.Email2=dstBiodata.Tables[0].Rows[0]["Biodata_Email2"].ToString() ;
            biodataDetails.MotherDetails=dstBiodata.Tables[0].Rows[0]["Biodata_Motherdetails"].ToString() ;
            biodataDetails.FatherDetails=dstBiodata.Tables[0].Rows[0]["Biodata_Fatherdetails"].ToString() ; 
            biodataDetails.EducationDetails=dstBiodata.Tables[0].Rows[0]["Biodata_Educationdetails"].ToString() ;
            biodataDetails.OccupationDetails=dstBiodata.Tables[0].Rows[0]["Biodata_Occupationdetails"].ToString() ;
            biodataDetails.BrotherDetails= dstBiodata.Tables[0].Rows[0]["Biodata_Brotherdetails"].ToString();
            biodataDetails.SisterDetails=dstBiodata.Tables[0].Rows[0]["Biodata_Sisterdetails"].ToString(); 
            biodataDetails.SubCaste=dstBiodata.Tables[0].Rows[0]["subcaste"].ToString() ; 
            biodataDetails.CandidateLocation=dstBiodata.Tables[0].Rows[0]["Biodata_CandidateLocation"].ToString() ;
            biodataDetails.SentBy=dstBiodata.Tables[0].Rows[0]["Biodata_SentBy"].ToString() ;
            biodataDetails.ReceivedMode= dstBiodata.Tables[0].Rows[0]["Biodata_ReceivedMode"].ToString() ; 
            biodataDetails.ReceivedOn=dstBiodata.Tables[0].Rows[0]["Biodata_ReceivedOn"].ToString() ;
            biodataDetails.HoroscopeMatchingRequirement = dstBiodata.Tables[0].Rows[0]["Biodata_HoroscopeMatchingRequirement"].ToString();
            biodataDetails.Source = dstBiodata.Tables[0].Rows[0]["biodata_source"].ToString();
            biodataDetails.BloodGroup = dstBiodata.Tables[0].Rows[0]["biodata_bloodgroup"].ToString();
            biodataDetails.CastenoBar = dstBiodata.Tables[0].Rows[0]["CastenoBar"].ToString();

            try
            {
                biodataDetails.Executive = Convert.ToInt32(dstBiodata.Tables[0].Rows[0]["Biodata_Executive"]);
            }
            catch (Exception)
            {           
                //No exception handling , not required
                //throw;
            }
            

            if (!Convert.IsDBNull(dstBiodata.Tables[0].Rows[0]["biodata_visibleoutside"]))
            {
                biodataDetails.VisibleOutside = Convert.ToBoolean(dstBiodata.Tables[0].Rows[0]["biodata_visibleoutside"]);
            }

            if (!Convert.IsDBNull(dstBiodata.Tables[0].Rows[0]["biodata_visibleinside"]))
            {
                biodataDetails.VisibleInside = Convert.ToBoolean(dstBiodata.Tables[0].Rows[0]["biodata_visibleinside"]);
            }

            //Check if the user is coming from the CustomerMaster form, it happens when user first edits the customermaster infromation
            //replace the customer details information with the customer master information
            if (ComingFromCustomerMaster)
            {
                if (MessageBox.Show("Would you like to take values from Customer Master details into Customer Details?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    //biodataDetails.ResidentialAddress = CustomerMasterDetails.Address1;
                    //CustomerMasterDetails.Address2 = txtAddress2.Text.Trim();
                    biodataDetails.CityofResidence = CustomerMasterDetails.City;
                    biodataDetails.Country = CustomerMasterDetails.Country;
                    biodataDetails.Email =  CustomerMasterDetails.Email;
                    biodataDetails.Email2 = CustomerMasterDetails.Email2;
                    biodataDetails.Mobile =  CustomerMasterDetails.Mobile;
                    //biodataDetails.nam CustomerMasterDetails.Name = txtName.Text.Trim();
                    //biodataDetails CustomerMasterDetails.Phone1 = txtPhone1.Text.Trim();
                    //CustomerMasterDetails.Phone2 = txtPhone2.Text.Trim();
                    biodataDetails.PinCode =  CustomerMasterDetails.PinCode;
                }
            }



            #endregion         
            
            #region Preferred partner details
            preferredPartner = new SaatphereWIN.DAL.User.ClsSelect().GetPreferredPartnerDetails(BiodataID);

            #endregion

            Cursor.Current = Cursors.Default;

            btnSave.Visible = false;
            btnEditBiodata.Visible = true;

            this.Text = "Customer Details - " + BiodataID.ToString() + " | Created By: " + biodataDetails.BiodataCreatedBy;

            //biodataDetails = BioDataDetails;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmCustomerDetails_Load(object sender, EventArgs e)
        {
            #region Drop Down Bindings
            BindDropDowns();
            BindDataAge();
            BindDataState();
            BindDataManglik();
            BindExecutive();            

            #endregion

            #region Load Profile for Editing Purpose
            if (SaatphereWIN.DAL.Global.LoginMessage == "franchiseelogin")
            {
                frusername = SaatphereWIN.DAL.Global.Frusername.ToString();
            }

            cmbCity.Text = biodataDetails.CityofResidence;
            cmbCountry.Text = biodataDetails.Country;
            txtEmail1.Text = biodataDetails.Email;
            txtResidentialAddress.Text = biodataDetails.ResidentialAddress;
            txtPinCode.Text = biodataDetails.PinCode;
            txtResiTelNo.Text = biodataDetails.ResidenceNo;
            txtMobileNo.Text = biodataDetails.Mobile;
            txtEmail2.Text = biodataDetails.Email2;
            txtName.Text = biodataDetails.FirstName;

            #region Collecting Values Biodata
            //SaatphereWIN.DAL.DataTypes.Biodata BiodataDetails = new SaatphereWIN.DAL.DataTypes.Biodata();
            txtLastName.Text = biodataDetails.SurName;
            txtName.Text = biodataDetails.FirstName;
            txtMiddleName.Text = biodataDetails.MiddleName;
            cmbGender.Text = biodataDetails.Gender;

            cmbHeight.Text = biodataDetails.Height;
            txtWeight.Text = biodataDetails.BiodataWeight.ToString();

            //string height  = string.Empty;
            if (biodataDetails.Height == null)
            {
                //height = biodataDetails.Height.Replace('"', ' ').Trim();
                cmbHeight.Text = "5.1";
            }
                       

            //label66.Text = biodataDetails.DateofBirth;
            if (biodataDetails.DateofBirth != null && biodataDetails.DateofBirth.Length > 0)
            {
                try
                {
                    txtDOB.Value = DateTime.ParseExact(biodataDetails.DateofBirth, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    //TODO
                    //throw;
                }
                
            }

            txtBirthPlace.Text = biodataDetails.PlaceofBirth;
            cmbCity.Text = biodataDetails.CityofResidence;
            txtResidentialAddress.Text = biodataDetails.ResidentialAddress;
            cmbCountry.Text = biodataDetails.Country;
            txtResiTelNo.Text = biodataDetails.ResidenceNo;
            txtOfficeTelNo.Text = biodataDetails.OfficeNo;
            txtEmail1.Text = biodataDetails.Email;
            txtPinCode.Text = biodataDetails.PinCode;
            txtMobileNo.Text = biodataDetails.Mobile;
            txtCreatedBy.Text = biodataDetails.BiodataCreatedBy;
            cmbMaritalStatus.Text = biodataDetails.MaritalStatus;
            txtBroMarried.Text = biodataDetails.MarriedBrothers;
            txtBroUnMarried.Text = biodataDetails.UnmarriedBrother;
            txtSistersMarried.Text = biodataDetails.MarriedSister;
            txtSistersUnMarried.Text = biodataDetails.UnmarriedSister;
            txtBroChildrens.Text = biodataDetails.NumberofChildren;
            cmbEducationStatus.Text = biodataDetails.EducationStatus;
            cmbComplexion.Text = biodataDetails.Complextion;
            cmbAboutMother.Text = biodataDetails.AboutMother;
            cmbAboutFather.Text = biodataDetails.AboutFather;
            cmbBodyType.Text = biodataDetails.BodyType;
            cmbPhysicallyChallenged.Text = biodataDetails.PhysicallyChallenged;
            txtTOBHour.Text = biodataDetails.TimeofBirthH;
            txtTOBMinute.Text = biodataDetails.TimeofBirthM;
            cmbOccupation.Text = biodataDetails.Occupation;
            cmbAnnualIncome.Text = biodataDetails.AnnualIncome;
            cmbReligion.Text = biodataDetails.Religion;
            cmbCaste.Text = biodataDetails.Caste;
            txtGotra.Text = biodataDetails.Gotra;
            cmbManglik.Text = biodataDetails.Manglik;
            cmbMotherTongue.Text = biodataDetails.Mothertongue;
            cmbDiet.Text = biodataDetails.Diet;
            cmbHearAboutUs.Text = biodataDetails.Hearaboutus;
            txtExpectedPartner.Text = biodataDetails.ExpectedPartner;
            txtMoreAboutCandidate.Text = biodataDetails.MoreaboutCandidate;
            txtRemark.Text = biodataDetails.Remark;

            txtSubCaste.Text = biodataDetails.SubCaste;
            cmbCasteNoBar.Text = biodataDetails.CastenoBar;
            txtCandidateLocation.Text = biodataDetails.CandidateLocation;
            txtBiodataSentBy.Text = biodataDetails.SentBy;
            txtReceivedMode.Text = biodataDetails.ReceivedMode;

            if (biodataDetails.ReceivedOn != null && biodataDetails.ReceivedOn.Length > 0)
            {
                try
                {
                    txtReceivedOn.Text = DateTime.ParseExact(biodataDetails.ReceivedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString();
                }
                catch (Exception)
                {
                    //TODO
                    //throw;
                }

            }

            //txtReceivedOn.Text = biodataDetails.ReceivedOn;
            txtBloodGroup.Text = biodataDetails.BloodGroup;
            cmbHoroscopeMatched.Text = biodataDetails.HoroscopeMatchingRequirement;
            txtEducationDetails.Text = biodataDetails.EducationDetails;
            txtOccupationDetails.Text = biodataDetails.OccupationDetails;
            txtFatherDetails.Text = biodataDetails.FatherDetails;
            txtMotherDetails.Text = biodataDetails.MotherDetails;
            txtSisterDetails.Text = biodataDetails.SisterDetails;
            txtBrotherDetails.Text = biodataDetails.BrotherDetails;
            txtCandidateOtherDetails.Text = biodataDetails.CandidateOtherDetails;
            txtEmail2.Text = biodataDetails.Email2;
            txtBiodataSource.Text = biodataDetails.Source;

            txtMoreAboutCandidate.Text = biodataDetails.MoreaboutCandidate;
            txtAboutCandidateFamily.Text = biodataDetails.AboutCandidateFamily;
            txtExpectedPartner.Text = biodataDetails.ExpectedPartner;
            txtBiodataSource.Text = biodataDetails.Source;
            txtBloodGroup.Text = biodataDetails.BloodGroup;
            cmbCasteNoBar.Text = biodataDetails.CastenoBar;

            txtLocality.Text = biodataDetails.BiodataLocality;
            chkNRIAcceptable.CheckState = biodataDetails.BiodataNriAcceptable ? CheckState.Checked : CheckState.Unchecked;

            if (!biodataDetails.VisibleOutside)
            {
                cmbExternalProfileVisibility.Text = "No";
            }
            else if (biodataDetails.VisibleOutside)
            {
                cmbExternalProfileVisibility.Text = "Yes";
            }

            if (!biodataDetails.VisibleInside)
            {
                cmbInternalProfileVisibility.Text = "No";
            }
            else if (biodataDetails.VisibleInside)
            {
                cmbInternalProfileVisibility.Text = "Yes";
            }

            try
            {
                txtAge.Text = (DateTime.Now.Year - DateTime.ParseExact(biodataDetails.DateofBirth, "dd/MM/yyyy", CultureInfo.InvariantCulture).Year).ToString();
            }
            catch (Exception)
            {
                //   throw;
            }   
            #endregion

            #region Collecting values for PReffered partner
            cmbAgeFrom.Text = preferredPartner.PreferredPartnerAgeFrom;
            cmbAgeTo.Text = preferredPartner.PreferredPartnerAgeTo;
            cmbHeightFrom.Text = preferredPartner.PreferredPartnerHeightFrom;
            cmbHeightTo.Text = preferredPartner.PreferredPartnerHeightTo;

            if (preferredPartner.PreferredPartnerReligion != null)
            {
                if (!cmbPReligion.Items.Contains(preferredPartner.PreferredPartnerReligion))
                {
                    cmbPReligion.DataSource = GetFilteredDataset(cmbPReligion, preferredPartner.PreferredPartnerReligion).Tables[0];
                    cmbPReligion.ValueMember = "value";
                    cmbPReligion.DisplayMember = "value";
                    cmbReligion.Text = preferredPartner.PreferredPartnerReligion;
                }
            }
            cmbPReligion.Text = preferredPartner.PreferredPartnerReligion;

            if (preferredPartner.PreferredPartnerCaste != null)
            {
                if (!cmbPCaste.Items.Contains(preferredPartner.PreferredPartnerCaste))
                {
                    cmbPCaste.DataSource = GetFilteredDataset(cmbPCaste, preferredPartner.PreferredPartnerCaste).Tables[0];
                    cmbPCaste.ValueMember = "value";
                    cmbPCaste.DisplayMember = "value";
                    cmbPCaste.Text = preferredPartner.PreferredPartnerCaste;
                }
            }
            cmbPCaste.Text = preferredPartner.PreferredPartnerCaste;

            cmbPCasteNoBar.Text = preferredPartner.PreferredPartnerCasteNoBar;

            if (preferredPartner.PreferredPartnerEducation != null)
            {
                if (!cmbPEducation.Items.Contains(preferredPartner.PreferredPartnerEducation))
                {
                    cmbPEducation.DataSource = GetFilteredDataset(cmbPEducation, preferredPartner.PreferredPartnerEducation).Tables[0];
                    cmbPEducation.ValueMember = "value";
                    cmbPEducation.DisplayMember = "value";
                    cmbPEducation.Text = preferredPartner.PreferredPartnerEducation;
                }
            }
            cmbPEducation.Text = preferredPartner.PreferredPartnerEducation;

            if (preferredPartner.PreferredPartnerOccupation != null)
            {
                if (!cmbPOccupation.Items.Contains(preferredPartner.PreferredPartnerOccupation))
                {
                    cmbPOccupation.DataSource = GetFilteredDataset(cmbPOccupation, preferredPartner.PreferredPartnerOccupation).Tables[0];
                    cmbPOccupation.ValueMember = "value";
                    cmbPOccupation.DisplayMember = "value";
                    cmbPOccupation.Text = preferredPartner.PreferredPartnerOccupation;
                }
            }
            cmbPOccupation.Text = preferredPartner.PreferredPartnerOccupation;

            if (preferredPartner.PreferredPartnerIncome != null)
            {
                if (!cmbPIncome.Items.Contains(preferredPartner.PreferredPartnerIncome))
                {
                    cmbPIncome.DataSource = GetFilteredDataset(cmbPOccupation, preferredPartner.PreferredPartnerIncome).Tables[0];
                    cmbPIncome.ValueMember = "value";
                    cmbPIncome.DisplayMember = "value";
                    cmbPIncome.Text = preferredPartner.PreferredPartnerIncome;
                }
            }
            cmbPIncome.Text = preferredPartner.PreferredPartnerIncome;

            if (preferredPartner.PreferredPartnerCountry != null)
            {
                if (!cmbPCountry.Items.Contains(preferredPartner.PreferredPartnerCountry))
                {
                    cmbPCountry.DataSource = GetFilteredDataset(cmbPCountry, preferredPartner.PreferredPartnerCountry).Tables[0];
                    cmbPCountry.ValueMember = "value";
                    cmbPCountry.DisplayMember = "value";
                    cmbPCountry.Text = preferredPartner.PreferredPartnerCountry;
                }
            }
            cmbPCountry.Text = preferredPartner.PreferredPartnerCountry;

            if (preferredPartner.PreferredPartnerState != null)
            {
                if (!cmbPState.Items.Contains(preferredPartner.PreferredPartnerState))
                {
                    cmbPState.DataSource = GetFilteredDataset(cmbPState, preferredPartner.PreferredPartnerState).Tables[0];
                    cmbPState.ValueMember = "value";
                    cmbPState.DisplayMember = "value";
                    cmbPState.Text = preferredPartner.PreferredPartnerState;
                }
            }
            cmbPState.Text = preferredPartner.PreferredPartnerState;

            if (preferredPartner.PreferredPartnerCity != null)
            {
                if (!cmbPCity.Items.Contains(preferredPartner.PreferredPartnerCity))
                {
                    cmbPCity.DataSource = GetFilteredDataset(cmbPCity, preferredPartner.PreferredPartnerCity).Tables[0];
                    cmbPCity.ValueMember = "value";
                    cmbPCity.DisplayMember = "value";
                    cmbPCity.Text = preferredPartner.PreferredPartnerCity;
                }
            }
            cmbPCity.Text = preferredPartner.PreferredPartnerCity;

            if (preferredPartner.PreferredPartnerCandidateLocation != null)
            {
                if (!cmbPCandidateLocation.Items.Contains(preferredPartner.PreferredPartnerCandidateLocation))
                {
                    cmbPCandidateLocation.DataSource = GetFilteredDataset(cmbPCandidateLocation, preferredPartner.PreferredPartnerCandidateLocation).Tables[0];
                    cmbPCandidateLocation.ValueMember = "value";
                    cmbPCandidateLocation.DisplayMember = "value";
                    cmbPCandidateLocation.Text = preferredPartner.PreferredPartnerCandidateLocation;
                }
            }
            cmbPCandidateLocation.Text = preferredPartner.PreferredPartnerCandidateLocation;

            if (preferredPartner.PreferredPartnerMangalik != null)
            {
                if (!cmbPManglik.Items.Contains(preferredPartner.PreferredPartnerMangalik))
                {
                    cmbPManglik.DataSource = GetFilteredDataset(cmbPManglik, preferredPartner.PreferredPartnerMangalik).Tables[0];
                    cmbPManglik.ValueMember = "value";
                    cmbPManglik.DisplayMember = "value";
                    cmbPManglik.Text = preferredPartner.PreferredPartnerMangalik;
                }
            }
            cmbPManglik.Text = preferredPartner.PreferredPartnerMangalik;

            if (preferredPartner.PreferredPartnerMotherTongue != null)
            {
                if (!cmbPMotherTongue.Items.Contains(preferredPartner.PreferredPartnerMotherTongue))
                {
                    cmbPMotherTongue.DataSource = GetFilteredDataset(cmbPMotherTongue, preferredPartner.PreferredPartnerMotherTongue).Tables[0];
                    cmbPMotherTongue.ValueMember = "value";
                    cmbPMotherTongue.DisplayMember = "value";
                    cmbPMotherTongue.Text = preferredPartner.PreferredPartnerMotherTongue;
                }
            }
            cmbPMotherTongue.Text = preferredPartner.PreferredPartnerMotherTongue;


            if (preferredPartner.PreferredPartnerMaritalStatus != null)
            {
                if (!cmbPMaritalStatus.Items.Contains(preferredPartner.PreferredPartnerMaritalStatus))
                {
                    cmbPMaritalStatus.DataSource = GetFilteredDataset(cmbPMaritalStatus, preferredPartner.PreferredPartnerMaritalStatus).Tables[0];
                    cmbPMaritalStatus.ValueMember = "value";
                    cmbPMaritalStatus.DisplayMember = "value";
                    cmbPMaritalStatus.Text = preferredPartner.PreferredPartnerMaritalStatus;
                }
            }
            cmbPMaritalStatus.Text = preferredPartner.PreferredPartnerMaritalStatus;

            

            #endregion

            #endregion
        }

        private DataSet GetFilteredDataset(ComboBox ComboboxControl, string ExplicitValue)
        {
            DataSet dstTemp = new DataSet();
            dstTemp.Tables.Add("Temp");
            dstTemp.Tables[0].Columns.Add("value");

            for (int i = 0; i <= ComboboxControl.Items.Count - 1; i++)
            {
            }
            dstTemp.Tables[0].Rows.Add(ExplicitValue);
            return dstTemp;
        }

        private void BindDataManglik()
        {
            ClsSelect select = new ClsSelect();
            cmbPManglik.DisplayMember = "value";
            cmbPManglik.ValueMember = "value";
        }

        private void BindExecutive()
        {            
            cmbExecutive.DataSource = new SaatphereWIN.DAL.Franchisee.ClsSelect().GetExecutives().Tables[0];
            cmbExecutive.DisplayMember = "Executive_Name";
            cmbExecutive.ValueMember = "Executive_CID";
        }

        private void BindDataAge()
        {
            ClsSelect select = new ClsSelect();
            cmbAgeFrom.DataSource = select.GetAgeItems().Tables[0];
            cmbAgeFrom.DisplayMember = "value";
            cmbAgeFrom.ValueMember = "value";

            cmbAgeTo.DataSource = select.GetAgeItems().Tables[0];
            cmbAgeTo.DisplayMember = "value";
            cmbAgeTo.ValueMember = "value";
        }

        private void BindDataState()
        {
            ClsSelect select = new ClsSelect();
            cmbPState.DataSource = select.GetStateItems().Tables[0];
            cmbPState.DisplayMember = "value";
            cmbPState.ValueMember = "value";
        }

        private void BindCountry()
        {
            ClsSelect select = new ClsSelect();
            cmbPState.DataSource = select.GetCountrytems().Tables[0];
            cmbPState.DisplayMember = "value";
            cmbPState.ValueMember = "value";
        }

        private void BindDropDowns()
        {
            //SaatphereWIN.DAL.Masters.clsSelect db = new SaatphereWIN.DAL.Masters.clsSelect();

            //Bind City List
            cmbCity.DataSource = db.GetList("city").Tables[0];
            cmbCity.DisplayMember = "value";
            cmbCity.ValueMember = "value";
            cmbCity.SelectedText = biodataDetails.CityofResidence;

            //Preferred Partner
            cmbPCity.DataSource = db.GetList("city").Tables[0];
            cmbPCity.DisplayMember = "value";
            cmbPCity.ValueMember = "value";

            cmbPCandidateLocation.DataSource = db.GetList("city").Tables[0];
            cmbPCandidateLocation.DisplayMember = "value";
            cmbPCandidateLocation.ValueMember = "value";

            //Bind Religion List
            cmbReligion.DataSource = db.GetList("Religion").Tables[0];
            cmbReligion.DisplayMember = "value";
            cmbReligion.ValueMember = "value";

            //Preferred PArtner 
            cmbPReligion.DataSource = db.GetList("Religion").Tables[0];
            cmbPReligion.DisplayMember = "value";
            cmbPReligion.ValueMember = "value";
            cmbPReligion.Refresh();

            //Bind Case List
            cmbCaste.DataSource = db.GetList("Caste").Tables[0];
            cmbCaste.DisplayMember = "value";
            cmbCaste.ValueMember = "value";
            
            //Preferred Partner Caste
            cmbPCaste.DataSource = db.GetList("Caste").Tables[0];
            cmbPCaste.DisplayMember = "value";
            cmbPCaste.ValueMember = "value";

            cmbEducationStatus.DataSource = db.GetList("Education").Tables[0];
            cmbEducationStatus.DisplayMember = "value";
            cmbEducationStatus.ValueMember = "value";

            //Preferred Partner
            cmbPEducation.DataSource = db.GetList("Education").Tables[0];
            cmbPEducation.DisplayMember = "value";
            cmbPEducation.ValueMember = "value";

            cmbBodyType.DataSource = db.GetList("BodyType").Tables[0];
            cmbBodyType.DisplayMember = "value";
            cmbBodyType.ValueMember = "value";

            cmbAboutFather.DataSource = db.GetList("AboutFather").Tables[0];
            cmbAboutFather.DisplayMember = "value";
            cmbAboutFather.ValueMember = "value";

            cmbOccupation.DataSource = db.GetList("Occupation").Tables[0];
            cmbOccupation.DisplayMember = "value";
            cmbOccupation.ValueMember = "value";

            //Preferred PArtner
            cmbPOccupation.DataSource = db.GetList("Occupation").Tables[0];
            cmbPOccupation.DisplayMember = "value";
            cmbPOccupation.ValueMember = "value";

            cmbAnnualIncome.DataSource = db.GetList("AnnualIncome").Tables[0];
            cmbAnnualIncome.DisplayMember = "value";
            cmbAnnualIncome.ValueMember = "value";
            cmbAnnualIncome.Text = "Dosen't Matter";

            //Preferred PArtner
            cmbPIncome.DataSource = db.GetList("AnnualIncome").Tables[0];
            cmbPIncome.DisplayMember = "value";
            cmbPIncome.ValueMember = "value";

            cmbMotherTongue.DataSource = db.GetList("MotherTongue").Tables[0];
            cmbMotherTongue.DisplayMember = "value";
            cmbMotherTongue.ValueMember = "value";

            cmbPMotherTongue.DataSource = db.GetList("MotherTongue").Tables[0];
            cmbPMotherTongue.DisplayMember = "value";
            cmbPMotherTongue.ValueMember = "value";

            cmbDiet.DataSource = db.GetList("Diet").Tables[0];
            cmbDiet.DisplayMember = "value";
            cmbDiet.ValueMember = "value";

            //cmbFranchiseeName.DataSource = db.GetList("FranchiseeName").Tables[0];
            //cmbFranchiseeName.DisplayMember = "franchiseeusername";
            //cmbFranchiseeName.ValueMember = "franchiseeusername";

            //Bind City List
            txtCandidateLocation.DataSource = db.GetList("city").Tables[0];
            txtCandidateLocation.DisplayMember = "value";
            txtCandidateLocation.ValueMember = "value";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CollectValues()
        {
            //SaatphereWIN.DAL.DataTypes.Biodata BiodataDetails = new SaatphereWIN.DAL.DataTypes.Biodata();
            biodataDetails.SurName = txtLastName.Text;
            biodataDetails.FirstName = txtName.Text;
            biodataDetails.MiddleName = txtMiddleName.Text;
            biodataDetails.Gender = cmbGender.Text;
            biodataDetails.Height = cmbHeight.Text;
            biodataDetails.DateofBirth = txtDOB.Text;
            biodataDetails.PlaceofBirth = txtBirthPlace.Text;
            biodataDetails.CityofResidence = cmbCity.Text;
            biodataDetails.ResidentialAddress = txtResidentialAddress.Text;
            biodataDetails.Country = cmbCountry.Text;
            biodataDetails.ResidenceNo = txtResiTelNo.Text;
            biodataDetails.OfficeNo = txtOfficeTelNo.Text;
            biodataDetails.Email = txtEmail1.Text;
            biodataDetails.PinCode = txtPinCode.Text;
            biodataDetails.Mobile = txtMobileNo.Text;
            biodataDetails.BiodataCreatedBy = txtCreatedBy.Text;
            biodataDetails.MaritalStatus = cmbMaritalStatus.Text;
            biodataDetails.MarriedBrothers = txtBroMarried.Text;
            biodataDetails.UnmarriedBrother = txtBroUnMarried.Text;
            biodataDetails.MarriedSister = txtSistersMarried.Text;
            biodataDetails.UnmarriedSister = txtSistersUnMarried.Text;
            biodataDetails.NumberofChildren = txtBroChildrens.Text;
            biodataDetails.EducationStatus = cmbEducationStatus.Text;
            biodataDetails.Complextion = cmbComplexion.Text;
            biodataDetails.AboutMother = cmbAboutMother.Text;
            biodataDetails.AboutFather = cmbAboutFather.Text;
            biodataDetails.BodyType = cmbBodyType.Text;
            biodataDetails.PhysicallyChallenged = cmbPhysicallyChallenged.Text;
            biodataDetails.TimeofBirthH = txtTOBHour.Text;
            biodataDetails.TimeofBirthM = txtTOBMinute.Text;
            biodataDetails.Occupation = cmbOccupation.Text;
            biodataDetails.AnnualIncome = cmbAnnualIncome.Text;
            biodataDetails.Religion = cmbReligion.Text;
            biodataDetails.Caste = cmbCaste.Text;
            biodataDetails.Gotra = txtGotra.Text;
            biodataDetails.Manglik = cmbManglik.Text;
            biodataDetails.Mothertongue = cmbMotherTongue.Text;
            biodataDetails.Diet = cmbDiet.Text;
            biodataDetails.Hearaboutus = cmbHearAboutUs.Text;
            biodataDetails.ExpectedPartner = txtExpectedPartner.Text;
            biodataDetails.MoreaboutCandidate = txtMoreAboutCandidate.Text;
            biodataDetails.Remark = txtRemark.Text;
            //biodataDetails.Photograph = Session["strphotograph"].ToString();
            //biodataDetails.Status = cmbs;
            biodataDetails.FranchiseeUserName = "";
            //biodataDetails.Membershiptype = ddlmembership.SelectedValue;
            biodataDetails.SubCaste = txtSubCaste.Text.Trim();
            biodataDetails.CastenoBar = cmbCasteNoBar.Text;
            biodataDetails.CandidateLocation = txtCandidateLocation.Text;
            biodataDetails.SentBy = txtBiodataSentBy.Text;
            biodataDetails.ReceivedMode = txtReceivedMode.Text;
            biodataDetails.ReceivedOn = txtReceivedOn.Text;
            biodataDetails.VisibleOutside = cmbExternalProfileVisibility.Text == "Yes" ? true : false;
            biodataDetails.BloodGroup = txtBloodGroup.Text;
            biodataDetails.HoroscopeMatchingRequirement = cmbHoroscopeMatched.Text;
            biodataDetails.EducationDetails = txtEducationDetails.Text;
            biodataDetails.OccupationDetails = txtOccupationDetails.Text;
            biodataDetails.FatherDetails = txtFatherDetails.Text;
            biodataDetails.MotherDetails = txtMotherDetails.Text;
            biodataDetails.SisterDetails = txtSisterDetails.Text;
            biodataDetails.BrotherDetails = txtBrotherDetails.Text;
            biodataDetails.CandidateOtherDetails = txtCandidateOtherDetails.Text;
            biodataDetails.Email2 = txtEmail2.Text;
            biodataDetails.VisibleInside = cmbInternalProfileVisibility.Text == "Yes" ? true : false;
            biodataDetails.Source = txtBiodataSource.Text;
            //biodataDetails.RowIdBiodata = rowId;
            biodataDetails.MoreaboutCandidate = txtMoreAboutCandidate.Text;
            biodataDetails.AboutCandidateFamily = txtAboutCandidateFamily.Text.Trim();
            biodataDetails.ExpectedPartner = txtExpectedPartner.Text;
            biodataDetails.Executive = Convert.ToInt32(cmbExecutive.SelectedValue);
            biodataDetails.BiodataLocality = txtLocality.Text;
            biodataDetails.BiodataNriAcceptable = chkNRIAcceptable.Checked ? true : false;
            biodataDetails.BiodataWeight = Convert.ToDecimal(txtWeight.Text);
            biodataDetails.BiodataLocality = txtLocality.Text;
            biodataDetails.BiodataNriAcceptable = chkNRIAcceptable.CheckState == CheckState.Checked? true: false;

            try
            {
                txtAge.Text = (DateTime.Now.Year - Convert.ToDateTime(txtDOB.Text).Year).ToString();
            }
            catch (Exception)
            {
                //   throw;
            }

            //biodataDetails.Age = agestr;

            biodataDetails.Age = txtAge.Text;

            DateTime date1 = DateTime.Now;
            biodataDetails.UpdateDate = String.Format("{0:d}", date1);

            string franchiseeID = string.Empty;
            if (SaatphereWIN.DAL.Global.LoginMessage == "franchiseelogin")
            {
                //franchiseeID = frid.ToString();
                biodataDetails.FranchiseeUserName = frid.ToString();
            }
            else
            {
                //franchiseeID = frowid.ToString();
                biodataDetails.FranchiseeUserName = frowid.ToString();
            }

            CollectPreferredPartnerValues();
            
        }

        private void CollectPreferredPartnerValues()
        {
            //Preferred Partner Details
            preferredPartner.PreferredPartnerActive = true;
            preferredPartner.PreferredPartnerAgeFrom = cmbAgeFrom.Text;
            preferredPartner.PreferredPartnerAgeTo = cmbAgeTo.Text;
            preferredPartner.PreferredPartnerBiodataCid = biodataDetails.RowIdBiodata;
            preferredPartner.PreferredPartnerCandidateLocation = cmbPCandidateLocation.Text;
            preferredPartner.PreferredPartnerCaste = cmbPCaste.Text;
            preferredPartner.PreferredPartnerCasteNoBar = cmbPCasteNoBar.Text;
            preferredPartner.PreferredPartnerCity = cmbPCity.Text;
            preferredPartner.PreferredPartnerCountry = cmbPCountry.Text;
            preferredPartner.PreferredPartnerCreatedBy = biodataDetails.RowIdBiodata;
            preferredPartner.PreferredPartnerDateCreated = DateTime.Now;
            preferredPartner.PreferredPartnerEducation = cmbPEducation.Text;
            preferredPartner.PreferredPartnerHeightFrom = cmbHeightFrom.Text;
            preferredPartner.PreferredPartnerHeightTo = cmbHeightTo.Text;
            preferredPartner.PreferredPartnerIncome = cmbPIncome.Text;
            preferredPartner.PreferredPartnerMangalik = cmbPManglik.Text;
            preferredPartner.PreferredPartnerOccupation = cmbPOccupation.Text;
            preferredPartner.PreferredPartnerReligion = cmbPReligion.Text;
            preferredPartner.PreferredPartnerState = cmbPState.Text;
            preferredPartner.PreferredPartnerMaritalStatus = cmbPMaritalStatus.Text;
            preferredPartner.PreferredPartnerMotherTongue = cmbPMotherTongue.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                CollectValues();
                                                
                    SaatphereWIN.DAL.Global.Frusername.ToString());
                //new SaatphereWIN.DAL.User.clsUpdate().EditCustomerDetails(BiodataDetails);

                //Save the Preferred Partner Details
                //------------------------------------------------------------------------------------
                //------------------------------------------------------------------------------------

                MessageBox.Show("Profile has created successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor.Current = Cursors.Default;
                this.Close();  
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error.\n" + ex.Message + "\nPlease retry...", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
            }
                     
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == tabControl1.TabPages.Count - 1)
            {
                btnSave.Enabled = true;
            }
        }

        
        private void txtDOB_KeyPress(object sender, KeyPressEventArgs e)
        {
                   
        }

        private void txtAge_Click(object sender, EventArgs e)
        {
            try
            {
                txtAge.Text = (DateTime.Now.Year - Convert.ToDateTime(txtDOB.Text).Year).ToString();
            }
            catch (Exception)
            {
                //   throw;
            }    
        }

        private void btnEditBiodata_Click(object sender, EventArgs e)
        {
            CollectValues();

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                txtAge.Text = (DateTime.Now.Year - Convert.ToDateTime(txtDOB.Text).Year).ToString();
            }
            catch (Exception)
            {
                //   throw;
            }

            //new SaatphereWIN.DAL.User.clsUpdate().EditCustomerDetails(BiodataDetails);



            if (MessageBox.Show("Profile has updated successfully.\nUpdate local copy?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There are Exceptions: " + ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //throw;
                }
                
                MessageBox.Show("Local Profile has updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Cursor.Current = Cursors.Default;
            this.Close();  

        }

        private void txtDOB_MouseLeave(object sender, EventArgs e)
        {
            txtAge_Click(sender, e);
        }

        private void btnReligion_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            DataSet dstReligion = new DataSet();
            dstReligion = db.GetList("Religion");
            string selectedReligion = string.Empty;

            using (var form = new frmMultipleSelection(dstReligion))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    selectedReligion = form.ReturnValues;            //values preserved after close
                }
            }
            cmbPReligion.Text = selectedReligion;
        }

        private void btnCaste_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            DataSet dstCaste = new DataSet();
            dstCaste = db.GetList("Caste");
            string selectedReligion = string.Empty;

            using (var form = new frmMultipleSelection(dstCaste))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    selectedReligion = form.ReturnValues;            //values preserved after close
                }
            }
            cmbPCaste.Text = selectedReligion;
        }

        private void btnEducation_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            DataSet dstEducation = new DataSet();
            dstEducation = db.GetList("Education");
            string selectedReligion = string.Empty;

            using (var form = new frmMultipleSelection(dstEducation))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    selectedReligion = form.ReturnValues;            //values preserved after close
                }
            }
            cmbPEducation.Text = selectedReligion;
        }

        private void btnOccupation_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            DataSet dstOccupation = new DataSet();
            dstOccupation = db.GetList("Occupation");
            string selectedReligion = string.Empty;

            using (var form = new frmMultipleSelection(dstOccupation))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    selectedReligion = form.ReturnValues;            //values preserved after close
                }
            }
            cmbPOccupation.Text = selectedReligion;
        }

        private void btnIncome_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            DataSet dstIncome = new DataSet();
            dstIncome = db.GetList("AnnualIncome");
            string selectedReligion = string.Empty;

            using (var form = new frmMultipleSelection(dstIncome))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    selectedReligion = form.ReturnValues;            //values preserved after close
                }
            }
            cmbPIncome.Text = selectedReligion;
        }

        private void btnCountry_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            DataSet dstCountry = new DataSet();
            dstCountry = new SaatphereWIN.DAL.Masters.ClsSelect().GetCountrytems();
            string selectedReligion = string.Empty;

            using (var form = new frmMultipleSelection(dstCountry))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    selectedReligion = form.ReturnValues;            //values preserved after close
                }
            }
            cmbPCountry.Text = selectedReligion;
        }

        private void btnState_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            DataSet dstState = new DataSet();
            dstState = new SaatphereWIN.DAL.Masters.ClsSelect().GetStateItems();
            string selectedReligion = string.Empty;

            using (var form = new frmMultipleSelection(dstState))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    selectedReligion = form.ReturnValues;            //values preserved after close
                }
            }
            cmbPState.Text = selectedReligion;
        }

        private void btnCity_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            DataSet dstCity = new DataSet();
            dstCity = db.GetList("city");
            string selectedReligion = string.Empty;

            using (var form = new frmMultipleSelection(dstCity))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    selectedReligion = form.ReturnValues;            //values preserved after close
                }
            }
            cmbPCity.Text = selectedReligion;
        }

        private void btnCandidateLocation_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            DataSet dstCandidateLocation = new DataSet();
            dstCandidateLocation = db.GetList("city");
            string selectedReligion = string.Empty;

            using (var form = new frmMultipleSelection(dstCandidateLocation))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    selectedReligion = form.ReturnValues;            //values preserved after close
                }
            }
            cmbPCandidateLocation.Text = selectedReligion;
        }

        private void btnManglik_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            DataSet dstManglik = new DataSet();
            dstManglik = new SaatphereWIN.DAL.Masters.ClsSelect().GetManglikItems();
            string selectedReligion = string.Empty;

            using (var form = new frmMultipleSelection(dstManglik))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    selectedReligion = form.ReturnValues;            //values preserved after close
                }
            }
            cmbPManglik.Text = selectedReligion;
        }


        private void btnTotal_Click(object sender, EventArgs e)
        {

            //To get the opposite gender search so that, male will get female profiles and female will get male profiles
            //----------------------------------------------------------------------------------------------------------------------------------
            string gender = new SaatphereWIN.DAL.User.ClsSelect().GetGenderfromActualRowId(biodataDetails.RowIdBiodata);
            if (gender == "Male")
                gender = "Female";
            else if (gender == "Female")
                gender = "Male";
            //----------------------------------------------------------------------------------------------------------------------------------
            
            //Age Filter
            if (cmbAgeFrom.Text.Length > 0 && cmbAgeTo.Text.Length > 0)
            {
                query = query + " and convert(int, Age) >= " + cmbAgeFrom.Text + " and convert(int, Age) <= " + cmbAgeTo.Text;
            }
           
            //Height Filter
            if (cmbHeightFrom.Text.Trim().Length > 0 && cmbHeightTo.Text.Trim().Length > 0)
            {
                //query = query + " and  replace(replace(replace(height,'''',''),'\"',''),'.','') >= " + cmbHeightFrom.Text.Replace("'", "").Replace('"', ' ').Trim() + " and replace(replace(replace(height,'''',''),'\"',''),'.','') <= " + cmbHeightTo.Text.Replace("'", "").Replace('"', ' ').Trim();
                query = query + " and  Convert(float, height) >= " + cmbHeightFrom.Text.Replace("'", "").Replace('"', ' ').Trim() + " and convert(float, height) <= " + cmbHeightTo.Text.Replace("'", "").Replace('"', ' ').Trim();
            }


            //Religion
            if (cmbPReligion.Text.Length > 0)
            {
                query = query + " and Religion in ('" + cmbPReligion.Text.Replace(",", "','") + "')";
            }

            //Caste
            if (cmbPCaste.Text.Length > 0)
            {
                query = query + " and Caste in ('" + cmbPCaste.Text.Replace(",", "','") + "')";
            }

            //Caste No Bar
            if (cmbPCasteNoBar.Text.Length > 0)
            {
                query = query + " and castenobar in ('" + cmbPCasteNoBar.Text.Replace(",", "','") + "')";
            }

            //Education
            if (cmbPEducation.Text.Length > 0)
            {
                query = query + " and educationstatus in ('" + cmbPEducation.Text.Replace(",", "','") + "')";
            }

            //Occupation
            if (cmbPOccupation.Text.Length > 0)
            {
                query = query + " and occupation in ('" + cmbPOccupation.Text.Replace(",", "','") + "')";
            }

            //Income
            if (cmbPIncome.Text.Length > 0)
            {
                query = query + " and annualincome in ('" + cmbPIncome.Text.Replace(",", "','") + "')";
            }

            //Country
            if (cmbPCountry.Text.Length > 0)
            {
                query = query + " and country in ('" + cmbPCountry.Text.Replace(",", "','") + "')";
            }

            //State
            if (cmbPState.Text.Length > 0)
            {
                query = query + " and ContactDetail.State in ('" + cmbPState.Text.Replace(",", "','") + "')";
            }

            //City
            if (cmbPCity.Text.Length > 0)
            {
                query = query + " and cityofresidence in ('" + cmbPCity.Text.Replace(",", "','") + "')";
            }

            //Mangalik
            if (cmbPManglik.Text.Length > 0)
            {
                query = query + " and manglik in ('" + cmbPManglik.Text.Replace(",", "','") + "')";
            }


            //Candidate Location
            if (cmbPCandidateLocation.Text.Length > 0)
            {
                query = query + " and cityofresidence in ('" + cmbPCandidateLocation.Text.Replace(",", "','") + "')";
            }

            //Candidate Mother Tongue
            if (cmbPMotherTongue.Text.Length > 0)
            {
                query = query + " and mothertongue in ('" + cmbPMotherTongue.Text.Replace(",", "','") + "')";
            }

            //Candidate Marital Status
            if (cmbPMaritalStatus.Text.Length > 0)
            {
                query = query + " and martialstatus in ('" + cmbPMaritalStatus.Text.Replace(",", "','") + "')";
            }

            //query = query + " inner join contactdetail on biodata.rowidbiodata = contactdetail.contactdetailrowid";

            int profileCount = new SaatphereWIN.DAL.User.ClsSelect().GetProfileCountonQuery(query);
            btnTotal.Text = "Result(s): " + profileCount.ToString();

        }

        private void btnMaritalStatus_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            DataSet dstMaritalStatus = new DataSet();

            //Create the Marital status list explicitly as there is no list defined in the database


            dstMaritalStatus = db.GetList("MaritalStatus");
            string selectedMaritalStatus = string.Empty;

            using (var form = new frmMultipleSelection(dstMaritalStatus))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    selectedMaritalStatus = form.ReturnValues;            //values preserved after close
                }
            }
            cmbPMaritalStatus.Text = selectedMaritalStatus;
        }

        private void btnMotherTongue_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            DataSet dstMotherTongue = new DataSet();
            dstMotherTongue = db.GetList("MotherTongue");
            string selectedMotherTongue = string.Empty;

            using (var form = new frmMultipleSelection(dstMotherTongue))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    selectedMotherTongue = form.ReturnValues;            //values preserved after close
                }
            }
            cmbPMotherTongue.Text = selectedMotherTongue;
        }

        private void txtWeight_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void btnBrowsePhoto_Click(object sender, EventArgs e)
        {

        }
    }
}
