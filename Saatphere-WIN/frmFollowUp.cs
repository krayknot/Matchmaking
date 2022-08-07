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
    public partial class frmFollowUp : Form
    {
        int followUpID = 0;
        int activityID = 0;

        string type = "FOLLOW-UP";
        string profileID = "";
        string franchiseeID = "";
        string executive = "";

        public frmFollowUp(int FollowUpID)
        {
            InitializeComponent();
            followUpID = FollowUpID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFollowUp_Load(object sender, EventArgs e)
        {
            DataSet dst = new DataSet();

            txtDate.Text = dst.Tables[0].Rows[0]["FollowUp_DateTime"].ToString();
            txtCreatedBy.Text = new SaatphereWIN.DAL.Franchisee.ClsSelect().GetExecutiveNamefromId(Convert.ToInt32(dst.Tables[0].Rows[0]["FollowUp_CreatedBy"]));

            activityID = Convert.ToInt32(dst.Tables[0].Rows[0]["FollowUp_ActivityCID"].ToString());

            DataSet dstActivity = new DataSet();

            lblLastRemark.Text = dstActivity.Tables[0].Rows[0]["Activity_Details"].ToString();

            type = "FOLLOW-UP";
            profileID = dstActivity.Tables[0].Rows[0]["Activity_ProfileID"].ToString();
            franchiseeID = dstActivity.Tables[0].Rows[0]["Activity_FranchiseeID"].ToString();
            executive = dstActivity.Tables[0].Rows[0]["Activity_Executive"].ToString();
        }

        private void btnActivity_Click(object sender, EventArgs e)
        {
            //DataSet dstActivity = new DataSet();
            //dstActivity = new SaatphereWIN.DAL.Complaints.clsSelect().GetActivityByActivityId(activityID);

            //lblLastRemark.Text = dstActivity.Tables[0].Rows[0]["Activity_Details"].ToString();

            //new frmActivityLog(activityID, "ACTIVITYID").ShowDialog();
        }

        private void btnCreateRemark_Click(object sender, EventArgs e)
        {
            new frmCreateRemark(type, profileID, franchiseeID, executive).ShowDialog();
        }     
    }
}
