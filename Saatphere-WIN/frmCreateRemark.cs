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
    public partial class frmCreateRemark : Form
    {
        string type = string.Empty;
        string profileId = string.Empty;
        string franchisee = string.Empty;
        string executive = string.Empty;

        public frmCreateRemark(string Type, string ProfileID, string Franchisee, string Executive)
        {
            InitializeComponent();

            type = Type;
            profileId = ProfileID;
            franchisee = Franchisee;
            executive = Executive;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string type = txtType.Text;
            int profileID = Convert.ToInt32( txtProfileId.Text);
            int franchisee = Convert.ToInt32( txtFranchisee.Text);
            string executive = txtExecutive.Text;
            string remark = txtRemark.Text;

            SaatphereWIN.DAL.DataTypes.Activity activityDetails = new SaatphereWIN.DAL.DataTypes.Activity();
            activityDetails.ActivityActive = true;
            activityDetails.ActivityDateTime = DateTime.Now;
            activityDetails.ActivityDetails = remark;
            activityDetails.ActivityExecutive = executive;
            activityDetails.ActivityFranchiseeId = franchisee;
            activityDetails.ActivityProfileId = profileID;
            activityDetails.ActivityType = type;


            MessageBox.Show("Details has saved successfully.", "Information - Saatphere", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void frmCreateRemark_Load(object sender, EventArgs e)
        {
            txtType.Text = type;
            txtProfileId.Text= profileId;
            txtFranchisee.Text=  franchisee;
            txtExecutive.Text=  executive ;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
