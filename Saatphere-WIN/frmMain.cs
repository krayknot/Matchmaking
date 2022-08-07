using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace Saatphere_WIN
{
    public partial class frmMain : Form
    {
        public int selectedBiodataId;

        public frmMain()
        {
            InitializeComponent();

            this.Text = Resource.ResourceManager.GetString("BusinessName");
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1)
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            catch (Exception)
            {
                
                //throw;
            }

            try
            {
                Environment.Exit(-1);
            }
            catch (Exception)
            {                
                throw;
            }           
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmCustomerMaster("").ShowDialog();
        }

        private void GetPendingAutomatchList()
        {
            //lstPendingProfiles.DataSource = new SaatphereWIN.DAL.Automatch.clsSelect().GetAutomatchProfiles();
            dgrdPendingProfiles.DataSource = new SaatphereWIN.DAL.Automatch.ClsSelect().GetAutomatchProfiles();
            dgrdPendingProfiles.Columns[0].Visible = false;
            dgrdPendingProfiles.Columns[1].HeaderText = "Pending Profiles";
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Thread t = new Thread(new ThreadStart(CreateXML));
            t.Start();

            //List of last created biodatas
            //dgrdLastBiodatas.DataSource = new SaatphereWIN.DAL.User.clsSelect().GetLastBiodata().Tables[0];

            toolStripStatusLblCurrentUser.Text = SaatphereWIN.DAL.Global.LoginUser;
            timer2_Tick(sender, e); //Load the notifications

            CheckVersion();
            GetPendingAutomatchList();

            Cursor.Current = Cursors.Arrow;

            //chartProfilesCount.Series["BiodataCount"].Points.AddXY("Ajay", "10000");
            //chartProfilesCount.Series["BiodataCount"].Points.AddXY("Ramesh", "8000");
            //chartProfilesCount.Series["BiodataCount"].Points.AddXY("Ankit", "7000");
            //chartProfilesCount.Series["BiodataCount"].Points.AddXY("Gurmeet", "10000");
            //chartProfilesCount.Series["BiodataCount"].Points.AddXY("Suresh", "8500");
            //chart title  
            chartProfilesCount.Titles.Add("Biodata Count Status");

            chartProfilesCount.DataSource = new SaatphereWIN.DAL.Membership.ClsSelect().Chart_GetBiodataCount().Tables[0];
            chartProfilesCount.Series["BiodataCount"].XValueMember = "Count";
            chartProfilesCount.Series["BiodataCount"].YValueMembers = "Date";
            chartProfilesCount.DataBind();

            chartPie.DataSource = new SaatphereWIN.DAL.Membership.ClsSelect().Chart_GetBiodataCount().Tables[0];
            chartPie.Series["BiodataCount"].XValueMember = "Count";
            chartPie.Series["BiodataCount"].YValueMembers = "Date";
            chartPie.DataBind();

            chartBars.DataSource = new SaatphereWIN.DAL.Membership.ClsSelect().Chart_GetBiodataCount().Tables[0];
            chartBars.Series["BiodataCount"].XValueMember = "Count";
            chartBars.Series["BiodataCount"].YValueMembers = "Date";
            chartBars.DataBind();
        }

        private void CheckVersion()
        {
            try
            {
                string folderInfo = Application.CommonAppDataPath;

                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(SaatphereWIN.DAL.Constants.FtpUsername, SaatphereWIN.DAL.Constants.FtpPassword);
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string text = reader.ReadToEnd();
                response.Close();


                //Download the Features file
                requestFeatures.Method = WebRequestMethods.Ftp.DownloadFile;
                requestFeatures.Credentials = new NetworkCredential(SaatphereWIN.DAL.Constants.FtpUsername, SaatphereWIN.DAL.Constants.FtpPassword);
                FtpWebResponse responseFeatures = (FtpWebResponse)requestFeatures.GetResponse();
                StreamReader readerFeature = new StreamReader(responseFeatures.GetResponseStream());
                string textFeature = readerFeature.ReadToEnd();
                response.Close();

                string moreInfo = "\nFor more information please contact krayknot below - \nEmail - krayknot@gmail.com, contact@krayknot.com\nPhone - 91-9503177442";
                if (SaatphereWIN.DAL.Constants.ApplicationVersion < Convert.ToDecimal(text))
                {
                    MessageBox.Show("There is new version available to download with the following features - \n" + textFeature + moreInfo, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in checking and downloading new Version.\nYou can Download the updates, if available, from Help>Check for Updates", "Information - Saatphere", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }            
        }


        private void CreateXML()
        {
            new frmCreateXMLs().ShowDialog();
        }

        private void upgradeRenewMembershipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmUpgradeMembership().ShowDialog();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            new frmUpgradeMembership().ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripTime.Text = DateTime.Now.ToLongDateString() + " | " + DateTime.Now.ToShortTimeString() ;

            //Get the notifications
            //try
            //{
            //    //1. Update Age - Read xml and show in the listbox
            //    DataSet dstNotify = new DataSet();
            //    dstNotify.Tables.Add("notify");
            //    dstNotify.Tables[0].Columns.Add("Message");

            //    if (File.Exists("Notifications//" +SaatphereWIN.DAL.Global.UpdateAgeXML))
            //    {
            //        dstNotify.ReadXml("Notifications//" + SaatphereWIN.DAL.Global.UpdateAgeXML);

            //        lstNotifications.Items.Add(dstNotify.Tables[0].Rows[0]["Message"].ToString());

            //        //Delete the file
            //        File.Delete("Notifications//" + SaatphereWIN.DAL.Global.UpdateAgeXML);
            //    }
            //}
            //catch (Exception)
            //{
                
            //    //throw;
            //}



        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            new frmCustomerMaster("").ShowDialog();
        }

        private void dataImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SaatphereDataImport.Form1().ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            new frmComplaintsAdd(0).ShowDialog();
        }

        private void addComplaintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmComplaintsAdd(0).ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            new frmSearch().ShowDialog();
        }

        private void searchBiodatasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmSearch().ShowDialog();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmOptions().ShowDialog();
        }

        private void updateLocalRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmUpdateLocalRecord().ShowDialog();
        }

        private void dataExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmDataExportStep1().ShowDialog();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Environment.Exit(-1);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmAbout().ShowDialog();
        }

        private void addExecutiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Franchisee.FrmExecutiveAdd().ShowDialog();
        }

        private void autoMatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmAutoMatch().ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            new frmAutoMatch().ShowDialog();
        }

        private void addCityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Masters.FrmAddCity().ShowDialog();
        }

        private void updateAgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Tools.FrmUpdateAge().ShowDialog();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //Create the notification xml, that will contain the notifications
            //DataSet dstNotifications = new DataSet();
            //dstNotifications.Tables.Add("Notify");
            //dstNotifications.Tables[0].Columns.Add("ITEM");
            
            //Follow up notifications
            //DataSet dstFollowups = new DataSet();
            //string customerName = string.Empty;

            //dstFollowups = new SaatphereWIN.DAL.Complaints.clsSelect().GetFollowUpbyId(new SaatphereWIN.DAL.Franchisee.clsSelect().GetExecutiveIdFromName(SaatphereWIN.DAL.Global.LoginUser));

            //if (dstFollowups.Tables.Count > 0)
            //{
            //    for (int i = 0; i <= dstFollowups.Tables[0].Rows.Count - 1; i++)
            //    {
            //        customerName = new SaatphereWIN.DAL.Complaints.clsSelect().GetCustomerNamefromFollowUpId(Convert.ToInt32(dstFollowups.Tables[0].Rows[i]["FollowUp_CID"]));
            //        lstNotifications.Items.Add(customerName + "=" + dstFollowups.Tables[0].Rows[i]["FollowUp_CID"]);
            //    }
            //}

            //if (dstNotifications.Tables.Count > 0)
            //{
            //    lstNotifications.DataSource = dstNotifications.Tables[0];
            //}
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmComplaintList().ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            new frmCustomerMaster("ENQUIRY").ShowDialog();
        }

        private void lstNotifications_DoubleClick(object sender, EventArgs e)
        {
            //string message = lstNotifications.Text;

            //string[] strFollowup = message.Split('=');
            //new frmFollowUp(Convert.ToInt32(strFollowup[1])).ShowDialog();

            //MessageBox.Show(message);
        }

        private void uploadPhotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Masters.FrmMultipleProfilePicUpload().ShowDialog();
        }

        private void remindersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Reminders.frmSelectCustomer().ShowDialog();
        }

        private void resetFranchiseesPasswordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Tools.FrmResetPassword().ShowDialog();
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Tools.FrmUpdateSaatphereWin().ShowDialog();
        }

        private void activaeProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmUpgradeMembership().ShowDialog();
        }

        private void calenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Tools.FrmCalender().ShowDialog();
        }

        private void reportsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Tools.FrmCalendarReports().ShowDialog();
        }

        private void deleteProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Tools.FrmCalender_DeletefromQueue().ShowDialog();
        }

        private void showAllReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Financial.FrmDsrShowAllReport().ShowDialog();
        }

        private void searchReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Financial.FrmDsrSearchReport().ShowDialog();
        }

        private void addNewRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Financial.FrmDsrAddNewRecord().ShowDialog();
        }

        private void dSRAddNewRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Financial.FrmDsrAddNewRecord().ShowDialog();
        }

        private void biodataToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new frmCustomerMaster("").ShowDialog();
        }

        private void bioDataToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void biodataApprovalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void unRegProfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void membershipToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void successfulRishteyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newspaperAdvertisementToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sendWelcomeEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Tools.FrmSendWelcomeEmail().ShowDialog();
        }

        private void editDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmSearch().ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            new frmSearch().ShowDialog();
        }

        private void btnCreateProfile_Click(object sender, EventArgs e)
        {
            new frmCustomerMaster("").ShowDialog();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            new Customer.FrmAddCustomer().ShowDialog();
        }

        private void addCustomerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Customer.FrmAddCustomer().ShowDialog();
        }

        private void assignCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Customer.FrmAssignCustomer().ShowDialog();
        }

        private void advanceSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Tools.FrmProfileMatchSearchProfileAdvanceSearch().ShowDialog();
        }

        private void importCustomersFromExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Customer.FrmUploadCustomers().ShowDialog();
        }

        private void addDSRExecutiveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Financial.FrmDsrExecutiveAdd().ShowDialog();
        }

        private void editDeleteExecutiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Financial.FrmDsrExecutiveEditDelete().ShowDialog();
        }

        private void searchAndSendProfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Tools.FrmProfileMatchSearchProfiles().ShowDialog();
        }

        private void sendDirectProfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Tools.FrmProfileMatchSearchProfileAdvanceSearch().ShowDialog();
        }

        private void btnSendProfile_Click(object sender, EventArgs e)
        {
            new Tools.FrmProfileMatchSearchProfiles().ShowDialog();
        }

        private void bulkEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new BulkEmail.frmUploadFiles().ShowDialog();
        }

        private void btnAutoMatch_Click(object sender, EventArgs e)
        {
            new frmAutoMatch().ShowDialog();

            //StartAutoMatch();
        }

        [Obsolete]
        private void StartAutoMatch()
        {
            //Collect the data to process
            //If there is any non processed profile id in the table then it will not load more profiles in that table
            ThrowStatus("Preparing the mailing list...");
            if (new SaatphereWIN.DAL.Automatch.ClsCommon().GetNotProcessedProfilesCount() < 1)
                new SaatphereWIN.DAL.Automatch.ClsCommon().CollectDatatoProcess();

            ThrowStatus("Mailing list has generated.");
            //int counttoProcess = new SaatphereWIN.DAL.Automatch.clsCommon().GetDataCount();

            ThrowStatus("Getting profiles list to process.");
            DataSet dstProfilestoProcess = new DataSet();
            dstProfilestoProcess = new SaatphereWIN.DAL.Automatch.ClsCommon().GetProfilestoProcess();

            ThrowStatus("Profile sending starting...");
            //if (lblTotalRecords.InvokeRequired)
            //{
            //    lblTotalRecords.Invoke(new MethodInvoker(delegate
            //    {
            //        lblTotalRecords.Text = "Total Records: " +  (dstProfilestoProcess.Tables[0].Rows.Count - 1).ToString();
            //        lblTotalRecords.Refresh();
            //    }));
            //}

            for (int i = 0; i <= dstProfilestoProcess.Tables[0].Rows.Count - 1; i++)
            {
                Thread.Sleep(2000);
                Automatch(dstProfilestoProcess.Tables[0].Rows[i]["automatch_profileid"].ToString());

                //new SaatphereWIN.DAL.Automatch.clsCommon().UpdateProfileSendStatus(dstProfilestoProcess.Tables[0].Rows[i]["automatch_profileid"].ToString());
                ThrowStatus(dstProfilestoProcess.Tables[0].Rows[i]["automatch_profileid"].ToString());
            }

            ThrowStatus("Finished.");
            //MessageBox.Show(counttoProcess.ToString());
        }
        
        private void ThrowStatus(string MessagetoThrow)
        {
            //if (lstAutomatch.InvokeRequired)
            //{
            //    lstAutomatch.Invoke(new MethodInvoker(delegate
            //    {
            //        lstAutomatch.Items.Add(MessagetoThrow);
            //        lstAutomatch.SelectedIndex = lstAutomatch.Items.Count - 1;
            //        lstAutomatch.Refresh();
            //    }));
            //}
        }

        private void Automatch(string BiodataID)
        {
            new SaatphereWIN.DAL.Automatch.ClsCommon().UpdateProfileSendStatus(BiodataID);

            #region AutoMatch starts
            ThrowStatus("Biodata: " + BiodataID);
            ThrowStatus("Process started at: " + DateTime.Now.ToString());

            //Update the screen tracker   
            //if (lblCurrentRecord.InvokeRequired)
            //{
            //    lblCurrentRecord.Invoke(new MethodInvoker(delegate
            //    {
            //        lblCurrentRecord.Text = "Current Record: " + new SaatphereWIN.DAL.Automatch.clsCommon().GetProcessedAutomatch().ToString();
            //        lblCurrentRecord.Refresh();
            //    }));
            //}

            //Initialize the variables and collect the values
            //---------------------------------------------------------------------------------------------------------------------------
            int biodataCID = Convert.ToInt32(BiodataID.Trim());
            int biodataCount = 1;

            DataSet dstOutput = new DataSet();
            string profileContainerTemplate = string.Empty;
            string profileContainerFilled = string.Empty;
            string saatphereTemplate = string.Empty;

            string officeAddress = string.Empty;
            //---------------------------------------------------------------------------------------------------------------------------

            //Fetch the Customer's Preferred Partner Details, provide message if not found.
            //---------------------------------------------------------------------------------------------------------------------------
            SaatphereWIN.DAL.DataTypes.PreferredPartner preferredPartnerDetails = new SaatphereWIN.DAL.DataTypes.PreferredPartner();
            preferredPartnerDetails = new SaatphereWIN.DAL.Membership.ClsSelect().GetPreferredPartnerDetailsfromBiodataCID(biodataCID);

            if (preferredPartnerDetails.PreferredPartnerBiodataCid == 0)
            {
                ThrowStatus("No Preferred partner details found. Operation Failed");
                //btnSend.Enabled = true;
            }
            else
            {
                //Collect the values
                bool isPaidMember = new SaatphereWIN.DAL.Membership.ClsSelect().IsPaidMember(biodataCID);

                if (isPaidMember)
                {
                    ThrowStatus("Paid Member = True");
                    if (new SaatphereWIN.DAL.Membership.ClsSelect().IsMembershipExpired(biodataCID))
                    {
                        ThrowStatus("MembershipExpired = True");
                        try
                        {
                            dstOutput = new SaatphereWIN.DAL.User.ClsSelect().BindDataAdvanceSearchWithoutAddress(preferredPartnerDetails, biodataCount, BiodataID);

                        }
                        catch (Exception)
                        {

                            //throw;
                        }
                        profileContainerTemplate = SaatphereWIN.DAL.HTML.HtmlStrings.ProfileContainerWithOutAddress; //Original Template
                    }
                    else
                    {
                        ThrowStatus("MembershipExpired = False");
                        try
                        {
                            dstOutput = new SaatphereWIN.DAL.User.ClsSelect().BindDataAdvanceSearchWithAddress(preferredPartnerDetails, biodataCount, BiodataID);

                        }
                        catch (Exception)
                        {

                            //throw;
                        }

                        profileContainerTemplate = SaatphereWIN.DAL.HTML.HtmlStrings.ProfileContainerWithAddress; //Original Template
                    }
                }
                else
                {
                    ThrowStatus("Paid Member = False");

                    try
                    {
                        dstOutput = new SaatphereWIN.DAL.User.ClsSelect().BindDataAdvanceSearchWithoutAddress(preferredPartnerDetails, biodataCount, BiodataID);

                    }
                    catch (Exception)
                    {

                        //throw;
                    }

                    profileContainerTemplate = SaatphereWIN.DAL.HTML.HtmlStrings.ProfileContainerWithOutAddress; //Original Template
                }

                if (dstOutput.Tables.Count > 0)
                {
                    if (dstOutput.Tables[0].Rows.Count > 0)
                    {
                        ThrowStatus("Collected profiles. Arranging in Template.");

                        profileContainerFilled = string.Empty; //The one with the replaced values

                        for (int i = 0; i <= dstOutput.Tables[0].Rows.Count - 1; i++)
                        {
                            //Set office address
                            if (dstOutput.Tables[0].Rows[i]["franchiseeusername"].ToString() == "andherioffice" || dstOutput.Tables[0].Rows[i]["franchiseeusername"].ToString() == "14")
                                officeAddress = SaatphereWIN.DAL.Global.MumbaiAndheriOfficeAddress;
                            else if (dstOutput.Tables[0].Rows[i]["franchiseeusername"].ToString() == "jaipuroffice" || dstOutput.Tables[0].Rows[i]["franchiseeusername"].ToString() == "3")
                                officeAddress = SaatphereWIN.DAL.Global.JaipurOfficeAddress;
                            if (dstOutput.Tables[0].Rows[i]["franchiseeusername"].ToString() == "mumbaioffice" || dstOutput.Tables[0].Rows[i]["franchiseeusername"].ToString() == "10")
                                officeAddress = SaatphereWIN.DAL.Global.MumbaiBorivaliOfficeAddress;
                            if (dstOutput.Tables[0].Rows[i]["franchiseeusername"].ToString() == "puneoffice" || dstOutput.Tables[0].Rows[i]["franchiseeusername"].ToString() == "15")
                                officeAddress = SaatphereWIN.DAL.Global.PuneOfficeAddress;


                            profileContainerFilled = profileContainerFilled + profileContainerTemplate;

                            profileContainerFilled = profileContainerFilled.Replace("{ImageSource}", dstOutput.Tables[0].Rows[i]["photograph"].ToString());
                            profileContainerFilled = profileContainerFilled.Replace("{Name}", dstOutput.Tables[0].Rows[i]["name"].ToString());
                            profileContainerFilled = profileContainerFilled.Replace("{City}", dstOutput.Tables[0].Rows[i]["city"].ToString());
                            profileContainerFilled = profileContainerFilled.Replace("{Caste}", dstOutput.Tables[0].Rows[i]["caste"].ToString());
                            profileContainerFilled = profileContainerFilled.Replace("{Education}", dstOutput.Tables[0].Rows[i]["educationstatus"].ToString());
                            profileContainerFilled = profileContainerFilled.Replace("{Occupation}", dstOutput.Tables[0].Rows[i]["occupation"].ToString());
                            profileContainerFilled = profileContainerFilled.Replace("{Religion}", dstOutput.Tables[0].Rows[i]["religion"].ToString());
                            profileContainerFilled = profileContainerFilled.Replace("{Country}", dstOutput.Tables[0].Rows[i]["country"].ToString());
                            profileContainerFilled = profileContainerFilled.Replace("{Age}", dstOutput.Tables[0].Rows[i]["age"].ToString());

                            //The following fields are not coming in the profile without address , hence it is covered under try...catch block
                            if (isPaidMember)
                            {
                                try
                                {
                                    profileContainerFilled = profileContainerFilled.Replace("{Height}", dstOutput.Tables[0].Rows[i]["height"].ToString());
                                    profileContainerFilled = profileContainerFilled.Replace("{Email}", dstOutput.Tables[0].Rows[i]["email"].ToString());
                                    profileContainerFilled = profileContainerFilled.Replace("{Email2}", dstOutput.Tables[0].Rows[i]["biodata_email2"].ToString());
                                    profileContainerFilled = profileContainerFilled.Replace("{Residence}", dstOutput.Tables[0].Rows[i]["residenceno"].ToString());
                                    profileContainerFilled = profileContainerFilled.Replace("{Mobile}", dstOutput.Tables[0].Rows[i]["mobile"].ToString());
                                    profileContainerFilled = profileContainerFilled.Replace("{Address}", dstOutput.Tables[0].Rows[i]["residentialaddress"].ToString());
                                    profileContainerFilled = profileContainerFilled.Replace("{MembershipType}", dstOutput.Tables[0].Rows[i]["membershiptype"].ToString());
                                    profileContainerFilled = profileContainerFilled.Replace("{ContactPerspn}", dstOutput.Tables[0].Rows[i]["contactpersonname"].ToString());

                                }
                                catch (Exception)
                                {
                                }
                            }
                        }

                        saatphereTemplate = System.IO.File.ReadAllText("Templates//ProfileMatch//Template1//andherioffice.html");

                        saatphereTemplate = saatphereTemplate.Replace("$$PROFILES$$", profileContainerFilled);
                        saatphereTemplate = saatphereTemplate.Replace("$$USERPROFILE$$", new SaatphereWIN.DAL.User.ClsSelect().GetCandidateNameFromBiodataId(biodataCID));

                        //Set the address based on the branch like mumbaioffice, jaipuroffice etc.
                        saatphereTemplate = saatphereTemplate.Replace("$$OFFICEADDRESS$$", officeAddress);


                        ThrowStatus("Preparing Profiles sent log.");
                        for (int i = 0; i <= dstOutput.Tables[0].Rows.Count - 1; i++)
                        {
                            //checking if same (own) profile is choice id(Some time clients wants to see her/his profiles), then shld not counted in remainder
                            if ((dstOutput.Tables[0].Rows[i]["id"].ToString() != BiodataID))
                            {
                                //checking if choice id is already in FavoriteCustomer or not, if yes then it shld not counted in remainder
                                if (!new SaatphereWIN.DAL.Membership.ClsSelect().GetAlreadyTakenDetails(biodataCID, Convert.ToInt32(dstOutput.Tables[0].Rows[i]["id"].ToString().Replace("#", ""))))
                                {
                                    new SaatphereWIN.DAL.Membership.ClsInsert().InsertProfileSentLog(Convert.ToInt32(biodataCID), Convert.ToInt32(dstOutput.Tables[0].Rows[i]["id"].ToString().Replace("#", "")));
                                }
                            }
                        }
                    }
                }

                if (dstOutput.Tables.Count > 0)
                {
                    if (dstOutput.Tables[0].Rows.Count > 0)
                    {
                        string gridviewEmailString = profileContainerFilled;
                        string toUser = "Admin";

                        string receiver = string.Empty;
                        string receiver2 = string.Empty;

                        receiver = new SaatphereWIN.DAL.User.ClsSelect().GetEmailFromBiodataId(biodataCID);
                        receiver2 = "";

                        if (new SaatphereWIN.DAL.User.ClsSelect().GetEmailUnsubscribeStatus(biodataCID) != true)
                        {
                            //Create a log entry

                            //clsInsert insert = new clsInsert();
                            int receiverID = biodataCID;
                            string recieverEmail = receiver;
                            string recieverEmail2 = receiver2;
                            DateTime profileSendDate = DateTime.Now;
                            int sentProfileCID = 0;

                            if (dstOutput.Tables[0].Rows.Count < 1)
                            {
                                MessageBox.Show("There is an Error in Mail Sending.\nPlease try again to send the Email./nIf error persists contact to Administrator.");
                            }
                            else
                            {
                                for (int i = 0; i <= dstOutput.Tables[0].Rows.Count - 1; i++)
                                {
                                    //checking if same (own) profile is choice id(Some time clients wants to see her/his profiles), then shld not counted in remainder
                                    if (Convert.ToInt32(dstOutput.Tables[0].Rows[i]["id"].ToString().Replace("#", "")) != biodataCID)
                                    {
                                        new SaatphereWIN.DAL.Membership.ClsInsert().InsertProfileMatchLog(receiverID, recieverEmail, recieverEmail2, profileSendDate, Convert.ToInt32(dstOutput.Tables[0].Rows[i]["id"].ToString().Replace("#", "")));
                                    }
                                }
                            }

                            string emailFrom = SaatphereWIN.DAL.Global.BiodataSendEmailFrom;

                            new SaatphereWIN.DAL.ClsCommon().SendMailfromSaatphere(emailFrom, "Saatphere: Profile Match", receiver, preferredPartnerDetails.PreferredPartnerBiodataCid.ToString(), "Matched Profiles", saatphereTemplate, "");
                            ThrowStatus(new SaatphereWIN.DAL.Automatch.ClsCommon().GetProcessedAutomatch().ToString());
                        }
                        else
                        {
                            ThrowStatus("Email Unsubscript Status = True. Operation Failed");
                        }
                    }
                }
                else
                {
                    ThrowStatus("ERROR: Profiles list is empty. Operation Failed");
                }
            }
            ThrowStatus("Profiles has sent successfully. Operation Success");
            #endregion
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            new Tools.FrmCalender().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new frmTestConnection().ShowDialog();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            new Masters.FrmMultipleProfilePicUpload().ShowDialog();
        }

        private void addOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lstPendingProfiles_DoubleClick(object sender, EventArgs e)
        {
            //string selectedProfileID = lstPendingProfiles.Text;

            //new frmAutomatchPendingProfiles(selectedProfileID).ShowDialog();
        }

        private void dgrdPendingProfiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string selectedProfileID = dgrdPendingProfiles.Rows[e.RowIndex].Cells[1].Value.ToString();

            new frmAutomatchPendingProfiles(selectedProfileID).ShowDialog();
            GetPendingAutomatchList();
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            

        }

        private void openProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://admin.peopleonegroup.com/saatphere/searchbiodata.aspx?biodataid=" + selectedBiodataId.ToString());
        }

        private void dgrdPendingProfiles_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                //Select the row first
                //var hti = dgrdResults.HitTest(Cursor.Position.X, Cursor.Position.Y);
                //dgrdResults.ClearSelection();
                //dgrdResults.Rows[hti.RowIndex].Selected = true;

                
                contextPendingAutomatch.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void dgrdPendingProfiles_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    dgrdPendingProfiles.CurrentCell = dgrdPendingProfiles.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    // Can leave these here - doesn't hurt
                    dgrdPendingProfiles.Rows[e.RowIndex].Selected = true;
                    dgrdPendingProfiles.Focus();

                    selectedBiodataId = Convert.ToInt32(dgrdPendingProfiles.Rows[e.RowIndex].Cells[1].Value);

                }
                catch (Exception)
                {

                }
            }
        }
    }
}
