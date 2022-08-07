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
    public partial class frmActivityLog : Form
    {
        int id = 0; //any id
        string type = string.Empty; // type of id
        public frmActivityLog(int ID, string TypeofID)
        {
            InitializeComponent();
            id = ID;
            type = TypeofID;
        }

        private void frmActivityLog_Load(object sender, EventArgs e)
        {
            DataSet dstActivity = new DataSet();

            if (type == "ACTIVITYID")
            {
            }

            //dstActivity = new SaatphereWIN.DAL.Complaints.clsSelect().GetActivityByProfileId(profileID);
            dgrdActivities.DataSource = dstActivity.Tables[0];
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
