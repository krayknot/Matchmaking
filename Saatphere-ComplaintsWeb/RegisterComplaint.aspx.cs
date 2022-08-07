using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegisterComplaint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                //BindComplaintType();
            }
            catch (Exception)
            {
                Response.Write("Services are stopped temporarily due to maintenance. Please contact vendor or wait for sometime");
            }
        }
    }

    private void BindComplaintType()
    {
        //drpComplaintType.DataSource = new SaatphereWIN.DAL.Complaints.clsSelect().GetComplaintTypes();
        //drpComplaintType.DataTextField = "value";
        //drpComplaintType.DataValueField = "Groupmaster_CID";
        //drpComplaintType.DataBind();
    }
    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            SaatphereWIN.DAL.DataTypes.Complaint complaintDetails = new SaatphereWIN.DAL.DataTypes.Complaint();
            complaintDetails.Complaint_Active = true;
            complaintDetails.Complaint_CreatedBy = SaatphereWIN.DAL.Global.WebAnonymousUser;
            complaintDetails.Complaint_CustomerProfileID = Convert.ToInt32(txtBiodataID.Text.Trim());
            complaintDetails.Complaint_DateCreated = DateTime.Now;
            complaintDetails.Complaint_Remarks = txtComplaintDetails.Text.Trim();
            complaintDetails.Complaint_Type = 0;// Convert.ToInt32(drpComplaintType.SelectedValue);
            complaintDetails.Complaint_ContactName = txtContactName.Text;
            complaintDetails.Complaint_ContactNumber = txtContactNumber.Text;
            complaintDetails.Complaint_Status = "Assigned";

            new SaatphereWIN.DAL.Complaints.clsInsert().InsertComplaint(complaintDetails);
            string lastComplaintID = new SaatphereWIN.DAL.Complaints.clsSelect().GetLastComplaintId().ToString();

            Session["TicketNumber"] = lastComplaintID;
            new SaatphereWIN.DAL.clsCommon().SendMailfromSaatphere("conact@saatphere.com", "Saatphere - Complaints", "dralokarora@gmail.com", "Saatphere Administrator", "New Complaint Registered", "New Complaint - " + lastComplaintID, "");

            //Send mail to the ProfileID holder
            string profileEmail = new SaatphereWIN.DAL.User.clsSelect().GetEmailFromBiodataId(complaintDetails.Complaint_CustomerProfileID);
            //new SaatphereWIN.DAL.clsCommon().SendMailfromSaatphere("contact@saatphere.com", "Saatphere - Complaints", profileEmail, "Saatphere Administrator", "New Complaint Registered", "New Complaint - " + lastComplaintID, "");

            Response.Redirect("ComplaintMessages.aspx", false);
        }
        catch (Exception)
        {
            Response.Write("Services are stopped temporarily due to maintenance. Please contact vendor or wait for sometime");
        }
    }
}