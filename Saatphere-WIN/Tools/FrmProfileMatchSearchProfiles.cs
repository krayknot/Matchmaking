using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Saatphere_WIN.Tools
{
    public partial class FrmProfileMatchSearchProfiles : Form
    {
        public FrmProfileMatchSearchProfiles()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            int profileID = Convert.ToInt32(txtProfileID.Text);
            DataSet dst = new DataSet();   

            SaatphereWIN.DAL.DataTypes.SearchResults searchResults = new SaatphereWIN.DAL.DataTypes.SearchResults();

            if (dst.Tables[0].Rows.Count > 0)
            {
                searchResults.Id = dst.Tables[0].Rows[0]["ID"].ToString();
                searchResults.Name = dst.Tables[0].Rows[0]["Name"].ToString();
                searchResults.Gender = dst.Tables[0].Rows[0]["Gender"].ToString();
                searchResults.State = dst.Tables[0].Rows[0]["State"].ToString();
                searchResults.Caste = dst.Tables[0].Rows[0]["Caste"].ToString();
                searchResults.Photograph = dst.Tables[0].Rows[0]["Photograph"].ToString();
                searchResults.MotherTongue = dst.Tables[0].Rows[0]["MotherTongue"].ToString();
                searchResults.Religion = dst.Tables[0].Rows[0]["Religion"].ToString();
                searchResults.Email = dst.Tables[0].Rows[0]["Email"].ToString();
                searchResults.Qualification = dst.Tables[0].Rows[0]["qualification"].ToString();
                searchResults.Dob = dst.Tables[0].Rows[0]["dob"].ToString();
                searchResults.Height = dst.Tables[0].Rows[0]["height"].ToString();
                searchResults.Occupation = dst.Tables[0].Rows[0]["occupation"].ToString();
                searchResults .CastenoBar= dst.Tables[0].Rows[0]["castenobar"].ToString();
                searchResults.MaritalStatus= dst.Tables[0].Rows[0]["martialstatus"].ToString();
                searchResults.Age = dst.Tables[0].Rows[0]["Age"].ToString();
                searchResults.Email2 = dst.Tables[0].Rows[0]["Biodata_Email2"].ToString();

            }
            else
            {
                MessageBox.Show("No record found.", "Information", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

            Cursor.Current = Cursors.Arrow;
        }

        private void txtProfileID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Return)
            {
                btnSearch_Click(sender, e);
            }
        }
    }
}
