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
    public partial class FrmSendWelcomeEmail : Form
    {
        public FrmSendWelcomeEmail()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                string body = string.Empty;
                string email = txtEmail.Text.Trim();
                string name = txtName.Text.Trim();

                body = System.IO.File.ReadAllText("Templates\\WelcomeEmail\\" + cmbLocation.SelectedValue.ToString() + ".html");
                body = body.Replace("$$name$$", txtName.Text);
                body = body.Replace("$$id$$", txtMembershipID.Text);

                body = body.Replace("$$membershiptype$$", cmbMembershipType.SelectedItem.ToString());
                body = body.Replace("$$startdate$$", dtStartDate.Text);


            }
            catch (Exception ex)
            {
                
                throw ex;
            }
 
            Cursor.Current = Cursors.Arrow;

            MessageBox.Show("Welcome email has sent successfully.", "Confirmation - Saatphere", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
        }

        private void frmSendWelcomeEmail_Load(object sender, EventArgs e)
        {
            BindUsers();
        }

        private void BindUsers()
        {
            BindingSource m_bindResults = new BindingSource();

            cmbLocation.DataSource = m_bindResults;
            cmbLocation.DisplayMember = "Value";
            cmbLocation.ValueMember = "key";

            cmbLocation.SelectedValue = SaatphereWIN.DAL.Global.LoginUser;
        }
    }
}
