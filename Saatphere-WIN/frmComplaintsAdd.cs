using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Saatphere_WIN
{
    public partial class frmComplaintsAdd : Form
    {
        int complaintID = 0;
        public frmComplaintsAdd(int ComplaintID)
        {
            InitializeComponent();
            complaintID = ComplaintID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BindExecutive()
        {
            DataSet dstExecutives = new DataSet();
            cmbExecutive.DataSource = dstExecutives.Tables[0];
            cmbExecutive.DisplayMember = "Executive_Name";
            cmbExecutive.ValueMember = "Executive_CID";

            DataSet dstPostedByExecutives = new DataSet();
            cmbExecutivePostedBy.DataSource = dstPostedByExecutives.Tables[0];
            cmbExecutivePostedBy.DisplayMember = "Executive_Name";
            cmbExecutivePostedBy.ValueMember = "Executive_CID";
        }

        private void frmComplaintsAdd_Load(object sender, EventArgs e)
        {
            BindExecutive();

            if (complaintID > 0)
            {
                DataSet dstComplaint = new DataSet();

                txtCaseID.Text = complaintID.ToString();
                cmbStatus.Text = dstComplaint.Tables[0].Rows[0]["Complaint_Status"].ToString();
                txtComplaint.Text = dstComplaint.Tables[0].Rows[0]["Complaint_Remarks"].ToString();
                txtProfileID.Text = dstComplaint.Tables[0].Rows[0]["Complaint_CustomerProfileID"].ToString();

                txtBiodataId.Text = dstComplaint.Tables[0].Rows[0]["Complaint_CustomerProfileID"].ToString();
                txtSourceName.Text = dstComplaint.Tables[0].Rows[0]["Complaint_ContactName"].ToString();
                txtSourceContactNo.Text = dstComplaint.Tables[0].Rows[0]["Complaint_ContactNumber"].ToString();
                cmbExecutive.Text = dstComplaint.Tables[0].Rows[0]["Complaint_Executive"].ToString();

                //txtCandidateName.Text = dstComplaint.Tables[0].Rows[0][""].ToString();
                //txtContactNumber.Text = dstComplaint.Tables[0].Rows[0][""].ToString();
                //txtEmailAddress.Text = dstComplaint.Tables[0].Rows[0][""].ToString();

                tabControl1.Enabled = true;
                tabControl2.Enabled = true;
                btnTagging.Enabled = true;

                txtBiodataId.Enabled = false;
                txtSourceName.Enabled = false;
                txtSourceContactNo.Enabled = false;
                txtComplaint.Enabled = false;
                //txtProfileID.Enabled = true;
                //txtCandidateName.Enabled = true;
                //txtContactNumber.Enabled = true;
                //txtEmailAddress.Enabled = true;
                //txtRemarks.Enabled = true;
            }
            else
            {
                txtBiodataId.Enabled = true;
                txtSourceName.Enabled = true;
                txtSourceContactNo.Enabled = true;
                txtComplaint.Enabled = true;
                cmbStatus.Text = "Assigned";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaatphereWIN.DAL.DataTypes.Complaint complaintDetails = new SaatphereWIN.DAL.DataTypes.Complaint();
            if (tabControl1.Enabled == false)
            {
                //If this is the fresh complaint from the Saatphere windows version                
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    
                    complaintDetails.ComplaintActive = true;
                    complaintDetails.ComplaintCreatedBy = SaatphereWIN.DAL.Global.WebAnonymousUser;
                    complaintDetails.ComplaintCustomerProfileId = Convert.ToInt32(txtBiodataId.Text.Trim());
                    complaintDetails.ComplaintDateCreated = DateTime.Now;
                    complaintDetails.ComplaintRemarks = txtComplaint.Text.Trim();
                    complaintDetails.ComplaintType = 0;// Convert.ToInt32(drpComplaintType.SelectedValue);
                    complaintDetails.ComplaintContactName = txtSourceName.Text;
                    complaintDetails.ComplaintContactNumber = txtSourceContactNo.Text;
                    complaintDetails.ComplaintStatus = cmbStatus.Text;

                    string lastComplaintID = new SaatphereWIN.DAL.Complaints.ClsSelect().GetLastComplaintId().ToString();

                    new SaatphereWIN.DAL.ClsCommon().SendMailfromSaatphere("conact@saatphere.com", "Saatphere - Complaints", "dralokarora@gmail.com", "Saatphere Administrator", "New Complaint Registered", "New Complaint - " + lastComplaintID, "");

                    //Send mail to the ProfileID holder
                    //new SaatphereWIN.DAL.clsCommon().SendMailfromSaatphere("contact@saatphere.com", "Saatphere - Complaints", profileEmail, "Saatphere Administrator", "New Complaint Registered", "New Complaint - " + lastComplaintID, "");

                    MessageBox.Show("Complaint / Ticket number is: " + lastComplaintID, "Complaints - Saatphere", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cursor.Current = Cursors.Arrow;
                }
                catch (Exception ex)
                {
                    throw ex;
                    //Response.Write("Services are stopped temporarily due to maintenance. Please contact vendor or wait for sometime");
                }
            }
            else
            {
                string activityDetails = txtRemarks.Text;
                int franchiseeID = Convert.ToInt32(SaatphereWIN.DAL.Global.FrRowId);
                int profileID = Convert.ToInt32(txtProfileID.Text);
                string executive = cmbExecutivePostedBy.Text;
                string status = cmbStatus.Text;
                string assignedExecutive = cmbExecutive.Text;

                complaintDetails.ComplaintStatus = status;
                complaintDetails.ComplaintExecutive = assignedExecutive;
                complaintDetails.ComplaintCid = complaintID;


                MessageBox.Show("Details saved successfully.", "Information - Saatphere", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRemarks.Text = string.Empty;
            }
        }

        private void btnTagging_Click(object sender, EventArgs e)
        {
            //new frmActivityLog(Convert.ToInt32(txtBiodataId.Text)).ShowDialog();
        }
    }
}
