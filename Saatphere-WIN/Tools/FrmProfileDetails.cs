using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Microsoft.Office.Interop.Word;

namespace Saatphere_WIN.Tools
{
    public partial class FrmProfileDetails : Form
    {
        int receiverID = 0;
        string userImagePath = string.Empty;
        SaatphereWIN.DAL.DataTypes.Biodata biodataDetails = new SaatphereWIN.DAL.DataTypes.Biodata();


        //public string getSelectedProfileID { get; set; }

        FrmProfileMatchResults frmCallingForm;

        public FrmProfileDetails(SaatphereWIN.DAL.DataTypes.SearchResults SearchResults, int CustomerProfileID, FrmProfileMatchResults CallingForm = null)
        {
            InitializeComponent();
            frmCallingForm = CallingForm;
            searchResults = SearchResults;
            receiverID = CustomerProfileID;
            
            Cursor.Current = Cursors.WaitCursor;            

            lblFranchisee.Text = SaatphereWIN.DAL.Global.Frusername;

            //Get biodata as well as contact details
            //SaatphereWIN.DAL.DataTypes.Biodata biodataDetails = new SaatphereWIN.DAL.DataTypes.Biodata();

            if (searchResults != null)
            {
            }
            else
            {
            }

            try
            {
                WebClient wc = new WebClient();
                wc.Headers.Add("user-agent", "Only a test!");

                byte[] bytes = wc.DownloadData(userImagePath);
                MemoryStream ms = new MemoryStream(bytes);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                pictUserImage.Image = img;
                pictUserImage.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch (Exception)
            {
                //throw;
            }

            lblId.Text = biodataDetails.RowIdBiodata.ToString();
            lblAge.Text = biodataDetails.Age;
            lblName.Text = biodataDetails.FirstName;
            lblGender.Text = biodataDetails.Gender;
            lblHeight.Text = biodataDetails.Height;
            lblComplexion.Text = biodataDetails.Complextion;
            lblbodyType.Text = biodataDetails.BodyType;
            lblDiet.Text = biodataDetails.Diet;

            lblFatherOccupation.Text = biodataDetails.AboutFather;
            lblMotherOccupation.Text = biodataDetails.AboutMother;
            lblBrotherOccupation.Text = biodataDetails.BrotherDetails;
            lblSisterOccupation.Text = biodataDetails.SisterDetails;

            lblDateofBirth.Text = biodataDetails.DateofBirth;
            lblTimeofBirth.Text = biodataDetails.TimeofBirthH;
            lblPlaceofBirth.Text = biodataDetails.PlaceofBirth;
            lblManglik.Text = biodataDetails.Manglik;

            lblReligion.Text = biodataDetails.Religion;
            lblCaste.Text = biodataDetails.Caste;
            lblSubCaste.Text = biodataDetails.SubCaste;
            lblGotra.Text = biodataDetails.Gotra;
            lblMotherTongue.Text = biodataDetails.Mothertongue;

            lblEducation.Text = biodataDetails.Status;
            lblOccupation.Text = biodataDetails.Occupation;
            lblAnnualIncome.Text = biodataDetails.AnnualIncome;

            lblCity.Text = biodataDetails.CityofResidence;
            lblState.Text = "";
            lblCountry.Text = biodataDetails.Country;

            lblMoreAboutMyself.Text = biodataDetails.MoreaboutCandidate;

            lblAboutCandidateFamily.Text = biodataDetails.AboutCandidateFamily;

            lblEducationDetails.Text = biodataDetails.EducationDetails;
            lblOccupationDetails.Text = biodataDetails.OccupationDetails;
            lblFatherDetails.Text = biodataDetails.FatherDetails;
            lblMotherDetails.Text = biodataDetails.MotherDetails;

            //=============================================================================================
            //Married | Unmarried Brothers 
            //=============================================================================================
            //string brotherMarried, brotherUnmarried = string.Empty;
            if ((biodataDetails.MarriedBrothers.Trim() != string.Empty) && (biodataDetails.MarriedBrothers.Trim() != "0") && (biodataDetails.MarriedBrothers.Trim() != "--"))
            {
                biodataDetails.MarriedBrothers = biodataDetails.MarriedBrothers + " (Married)";
            }
            else
            {
                biodataDetails.MarriedBrothers = string.Empty;
            }

            if ((biodataDetails.UnmarriedBrother.Trim() != string.Empty) && (biodataDetails.UnmarriedBrother.Trim() != "0") && (biodataDetails.UnmarriedBrother.Trim() != "--"))
            {
                biodataDetails.UnmarriedBrother = biodataDetails.UnmarriedBrother + " (Unmarried)";
            }
            else
            {
                biodataDetails.UnmarriedBrother = string.Empty;
            }

            if ((biodataDetails.MarriedBrothers.Trim() != string.Empty) && (biodataDetails.UnmarriedBrother.Trim() != string.Empty) && (biodataDetails.MarriedBrothers.Trim() != "--"))
            {
                lblBrotherDetails.Text = biodataDetails.MarriedBrothers + ", " + biodataDetails.UnmarriedBrother;
            }
            else
            {
                lblBrotherDetails.Text = biodataDetails.MarriedBrothers + " " + biodataDetails.UnmarriedBrother;
            }
            //=============================================================================================

            //=============================================================================================
            //Married | Unmarried Sisters 
            //=============================================================================================
            if ((biodataDetails.MarriedSister.Trim() != string.Empty) && (biodataDetails.MarriedSister.Trim() != "0") && (biodataDetails.MarriedSister.Trim() != "--"))
            {
                biodataDetails.MarriedSister = biodataDetails.MarriedSister + " (Married)";
            }
            else
            {
                biodataDetails.MarriedSister = string.Empty;
            }

            if ((biodataDetails.UnmarriedSister.Trim() != string.Empty) && (biodataDetails.UnmarriedSister.Trim() != "0") && (biodataDetails.UnmarriedSister.Trim() != "--"))
            {
                biodataDetails.UnmarriedSister = biodataDetails.UnmarriedSister + " (Unmarried)";
            }
            else
            {
                biodataDetails.UnmarriedSister = string.Empty;
            }

            if ((biodataDetails.MarriedSister.Trim() != string.Empty) && (biodataDetails.UnmarriedSister.Trim() != string.Empty) && (biodataDetails.MarriedSister.Trim() != "--"))
            {
                lblSisterDetails.Text = biodataDetails.MarriedSister + ", " + biodataDetails.UnmarriedSister;
            }
            else
            {
                lblSisterDetails.Text = biodataDetails.MarriedSister + " " + biodataDetails.UnmarriedSister;
            }
            //=============================================================================================    
            
            //lblBrotherDetails.Text = biodataDetails.BrotherDetails;
            //lblSisterDetails.Text = biodataDetails.SisterDetails;

            lblOtherDetails.Text = biodataDetails.CandidateOtherDetails;
            lblPrefferedPartner.Text = biodataDetails.ExpectedPartner;

            lblCandidateName.Text = biodataDetails.FirstName;
            lblCandidateLocation.Text = biodataDetails.CandidateLocation;
            lblAddress.Text = biodataDetails.ResidentialAddress;
            lblContactNo1.Text = biodataDetails.ResidenceNo;
            lblContactNo2.Text = biodataDetails.OfficeNo;
            lblMobileNo.Text = biodataDetails.Mobile;
            lblEmail.Text = biodataDetails.Email + "," + biodataDetails.Email2;

            Cursor.Current = Cursors.Arrow;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProfileDetails_Load(object sender, EventArgs e)
        {
            txtReceiver.Text = new SaatphereWIN.DAL.User.ClsSelect().GetEmailFromBiodataId(receiverID);
            HideInformationforExpiredMembershipReceiver();
        }

        private void HideInformationforExpiredMembershipReceiver()
        {
            //If the user for whom the profile is getting searched, has no membership then the Address detaill will be invisible
            if (new SaatphereWIN.DAL.Membership.ClsSelect().IsMembershipExpired(receiverID))
            {
                label78.Visible = false;
                lblAddress.Visible = false;
                label69.Visible = false;
                lblContactNo2.Visible = false;
                label67.Visible = false;
                lblContactNo1.Visible = false;
                label8.Visible = false;
                lblMobileNo.Visible = false;
                label81.Visible = false;
                lblEmail.Visible = false;

                btnExporttoWord.Enabled = false;
                lblMessageExporttoWord.Visible = true;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Current = Cursors.WaitCursor;

            string franchiseeName = lblFranchisee.Text;//  SaatphereWIN.DAL.Global.frusername;

            //Read the Email Template
            //------------------------------------------------------------------------
            string templateContent = System.IO.File.ReadAllText("Templates//ProfileMatch//Template1//" + franchiseeName + ".html");
            //string templateUserContent = System.IO.File.ReadAllText(Server.MapPath("Templates//ProfileMatch//UserInfo.htm"));

            //Validation for not to send any Empty Email
            //-----------------------------------------------------------------------------------------
            //if (dtlSelected.Items.Count > 0)
            //{
                string gridviewEmailString = SaatphereWIN.DAL.Global.TemplateProfilesWithoutAddress ;//getHTML(dtlSelected);

                gridviewEmailString = gridviewEmailString.Replace("{name}", searchResults.Name);
                gridviewEmailString = gridviewEmailString.Replace("{educationstatus}", searchResults.EducationStatus);
                gridviewEmailString = gridviewEmailString.Replace("{occupation}", searchResults.Occupation);
                gridviewEmailString = gridviewEmailString.Replace("{religion}", searchResults.Religion);
                gridviewEmailString = gridviewEmailString.Replace("{country}", searchResults.Country);
                gridviewEmailString = gridviewEmailString.Replace("{profileid}", searchResults.Id);
                gridviewEmailString = gridviewEmailString.Replace("{caste}", searchResults.Caste);
                gridviewEmailString = gridviewEmailString.Replace("{city}", searchResults.City);

                gridviewEmailString = gridviewEmailString.Replace("{viewmoredetails}", "<a href='" + viewMoreDetails + "'>View more Details</a>");
                gridviewEmailString = gridviewEmailString.Replace("{image}", "<img alt='' src='" + searchResults.Photograph + "' />" );

                //string toUser = txtReceiver.Text;
                string toUser = "Admin";

                string receiver = string.Empty;
                string receiver2 = string.Empty;
                //if (txtReceiver.Text.Length > 0)
                //{
                receiver = txtReceiver.Text;
                //}
                //else
                //{
                //receiver2 = txtEmail.Text;
                //}

                //templateUserContent = templateUserContent.Replace("$$CustomerID$$", Session["ID"].ToString());
                //templateUserContent = templateUserContent.Replace("$$Name$$", Session["uName"].ToString());
                //templateUserContent = templateUserContent.Replace("$$City$$", Session["state"].ToString());
                //templateUserContent = templateUserContent.Replace("$$Caste$$", Session["caste"].ToString());
                //templateUserContent = templateUserContent.Replace("$$Photo$$", Session["photo"].ToString());
                templateContent = templateContent.Replace("$$text$$", txtMessage.Text);
                templateContent = templateContent.Replace("$$Regards$$", "");
                templateContent = templateContent.Replace("$$USERPROFILE$$", searchResults.Name + "&nbsp;&nbsp;(ID-&nbsp;" + searchResults.Id + ")");
                templateContent = templateContent.Replace("$$PROFILES$$", gridviewEmailString);
                templateContent = templateContent.Replace("{UNSUBSCRIBE}", SaatphereWIN.DAL.Global.SaatphereUrl + "/unsubscribe/Unsubscribe.aspx?Email=" + receiver);


                if (! new SaatphereWIN.DAL.User.ClsSelect().GetEmailUnsubscribeStatus(Convert.ToInt32(searchResults.Id.Replace("#",""))))
                {
                    //Create a log entry
                    //SaatPhere.DAL.clsInsert insert = new SaatPhere.DAL.clsInsert();
                    //int receiverID = Convert.ToInt32(Session["ID"]);
                    string recieverEmail = receiver;
                    string recieverEmail2 = receiver2;
                    DateTime profileSendDate = DateTime.Now;
                    int sentProfileCID = 0;

                    //if (Session["UserIDs"] == null)
                    //{
                    //    Session["_MESSAGEHEADING"] = "There is an Error in Mail Sending.";
                    //    Session["_MESSAGEBODY"] = "Please try again to send the Email./nIf error persists contact to Administrator.";
                    //    Response.Redirect("Saatphere_MessagePage.aspx", true);
                    //    Response.End();
                    //}
                    //else
                    //{
                    //    string[] strArray = Session["UserIDs"].ToString().Split(',');

                    //    for (int i = 0; i <= strArray.GetUpperBound(0) - 1; i++)
                    //    {
                           new SaatphereWIN.DAL.User.ClsInsert().InsertProfileMatchLog(receiverID, recieverEmail, recieverEmail2, profileSendDate, Convert.ToInt32(searchResults.Id.Replace("#","")));
                    //    }
                    //}


                    //Sends mail to the User
                    new SaatphereWIN.DAL.ClsCommon().SendMailfromSaatphere("Saatphere Matrimonial Services", "Saatphere: Profile Match", receiver, searchResults.Name, "Matched Profiles", templateContent);
                    
                    //added by kanchan 28 Jul 2013
                    //reason: sending profiles on receivers another email also.
                    //==================================================================
                    new SaatphereWIN.DAL.ClsCommon().SendMailfromSaatphere("Saatphere Matrimonial Services", "Saatphere: Profile Match", receiver2, searchResults.Name, "Matched Profiles", templateContent);
                    //==================================================================
                    

                }
                else
                {
                }
            //}
            //else
            //{
            //}

                Cursor.Current = Cursors.Arrow;
                frmCallingForm.BindDataMemAdvanceSearch();
                this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            frmCallingForm.lstSelectedProfiles.Items.Add(lblId.Text);
            this.Close();
        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void cmbImageMode_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void cmbImageMode_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void cmbImageMode_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void cmbImageMode_TextChanged(object sender, EventArgs e)
        {
            if (cmbImageMode.Text == "Normal")
            {
                pictUserImage.SizeMode = PictureBoxSizeMode.Normal;
            }
            else if (cmbImageMode.Text == "StretchImage")
            {
                pictUserImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (cmbImageMode.Text == "AutoSize")
            {
                pictUserImage.SizeMode = PictureBoxSizeMode.AutoSize;
            }
            else if (cmbImageMode.Text == "CenterImage")
            {
                pictUserImage.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            else if (cmbImageMode.Text == "Zoom")
            {
                pictUserImage.SizeMode = PictureBoxSizeMode.Zoom;
            }
            pictUserImage.Refresh();
        }

        private void cmbImageMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictUserImage_DoubleClick(object sender, EventArgs e)
        {
            new FrmPhotoDetails(userImagePath).ShowDialog();
        }

        private void groupBox10_Enter(object sender, EventArgs e)
        {

        }

        private void lblFatherDetails_DoubleClick(object sender, EventArgs e)
        {
            ShowDetails(lblFatherDetails.Text);
        }

        private void ShowDetails(string Message)
        {
            MessageBox.Show(Message, "Information - Profile Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblMotherDetails_DoubleClick(object sender, EventArgs e)
        {
            ShowDetails(lblMotherDetails.Text);
        }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }

        private void lblEmail_DoubleClick(object sender, EventArgs e)
        {
            ShowDetails(lblEmail.Text);
        }

        private void lblMobileNo_DoubleClick(object sender, EventArgs e)
        {
            ShowDetails(lblMobileNo.Text);
        }

        private void lblContactNo1_DoubleClick(object sender, EventArgs e)
        {
            ShowDetails(lblContactNo1.Text);
        }

        private void lblContactNo2_DoubleClick(object sender, EventArgs e)
        {
            ShowDetails(lblContactNo2.Text);
        }

        private void lblBrotherDetails_Click(object sender, EventArgs e)
        {

        }

        private void btnExporttoWord_Click(object sender, EventArgs e)
        {
            //read the html file that will get imported in the word
            //string profileHTML = File.ReadAllText("Templates//WordProfiles//structure_white_blue//Profiles.html");

            string profileHTML = File.ReadAllText("Templates//WordProfiles//structure_white_blue//profileContent.html");
            string profiles = File.ReadAllText("Templates//WordProfiles//structure_white_blue//Profiles.html");

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

            profileHTML = profileHTML.Replace("{imagesource}", userImagePath);
            profiles = profiles.Replace("{profiletable}", profileHTML);

            string tempFileHTML = Path.GetTempFileName() + ".html";  //Path.GetTempPath() + Guid.NewGuid()  + ".html";

            if (File.Exists(tempFileHTML))
                File.Delete(tempFileHTML);

            File.WriteAllText(tempFileHTML, profiles);

            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string exportPath = folderBrowserDialog1.SelectedPath + "/" + receiverID.ToString() + ".pdf";

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
                object fileFormat = WdSaveFormat.wdFormatPDF;
                wordDoc.SaveAs(ref saveto, ref fileFormat, ref oMissing, ref oMissing, ref oMissing,
                                   ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                   ref oMissing, ref oMissing, ref oMissing, ref oallowsubstitution, ref oMissing,
                                   ref oMissing);

                wordDoc.Close();

                MessageBox.Show("Profile has exported to Word successfully at the location:\n" + exportPath, "Information - Saatphere", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }

        private void lblMessageExporttoWord_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You cannot export profiles for Unpaid Members.", "Information - Saatphere", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
