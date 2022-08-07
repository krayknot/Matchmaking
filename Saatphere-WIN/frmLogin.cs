using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Reflection;
using Microsoft.Office.Interop.Word;
using System.Resources;

namespace Saatphere_WIN
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool authenticateResult = false;

            string username = txtUsername.Text.Trim() ;//cmbUsernames.Text.Trim();
            string 
                
                
                
                = txtPassword.Text.Trim();
            string franchisee = username; // cmbFranchisees.Text.Trim();
            string body = string.Empty;
            string error = string.Empty;

            if (username.Length < 1)
            {
                error = error + "- Username is mandatory.\n";                
            }

            if (password.Length < 1)
            {
                error = error + "- Password is mandatory.\n";
            }

            if (error.Length > 0)
            {
                error = "There is error(s): \n\n" + error;
                MessageBox.Show(error, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    if (cmbLoginAs.Text == "Administrator")
                    {

                        SaatphereWIN.DAL.Global.FrRowId = "A";
                        SaatphereWIN.DAL.Global.CheckLogin = "adminlogin";
                        SaatphereWIN.DAL.Global.Checkvalidate = "707";
                        SaatphereWIN.DAL.Global.MessageforFav = "adminlogin";
                        SaatphereWIN.DAL.Global.LoginMessage = "adminlogin";
                        SaatphereWIN.DAL.Global.LoginUser = username;
                    }
                    else if (cmbLoginAs.Text == "Customer")
                    {

                        SaatphereWIN.DAL.Global.LoginUser = cmbUsernames.Text.ToString();
                        SaatphereWIN.DAL.Global.CheckLogin = "customerlogin";
                        SaatphereWIN.DAL.Global.Checkvalidate = "C707";
                        SaatphereWIN.DAL.Global.LoginMessage = "customerlogin";
                        SaatphereWIN.DAL.Global.MessageforFav = "Customerlogin";
                        SaatphereWIN.DAL.Global.Customerviewbylogin = username;
                    }
                    else if (cmbLoginAs.Text == "Franchisee")
                    {

                        SaatphereWIN.DAL.Global.Checkvalidate = "F707";
                        SaatphereWIN.DAL.Global.CheckLogin = cmbFranchisees.SelectedText ;//"Franchiseelogin";
                        SaatphereWIN.DAL.Global.MessageforFav = "Franchiseelogin";
                        SaatphereWIN.DAL.Global.LoginMessage = "franchiseelogin";
                        SaatphereWIN.DAL.Global.Frusername = franchisee;
                        SaatphereWIN.DAL.Global.FrRowId = new SaatphereWIN.DAL.User.ClsSelect().GetFranchiseeRowIDfromUsername(username).ToString();
                        SaatphereWIN.DAL.Global.LoginUser = txtUsername.Text.Trim() ;// cmbUsernames.Text.ToString();

                        //Set the Franchisee rowid for the Reminders solution as well
                        Reminders.ClsCommon.FranchiseeId = Convert.ToInt32(SaatphereWIN.DAL.Global.FrRowId);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }                

                if (authenticateResult == true)
                {
                    if (chkRememberMe.CheckState == CheckState.Checked)
                    {
                        new SaatphereWIN.DAL.ClsCommon().Write("SaatPhereUsername", cmbUsernames.Text);
                        new SaatphereWIN.DAL.ClsCommon().Write("SaatPherePassword", txtPassword.Text);
                    }
                                                            
                    this.Hide();
                    new frmMain().ShowDialog();
                }
                else
                {
                    MessageBox.Show("Either Username or Password is Incorrect", "Credentials", MessageBoxButtons.OK);
                }
            }            
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(-1);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbLoginAs.Focus();
            }
        }

        private void cmbLoginAs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void BindFranchisees()
        {
            cmbFranchisees.DataSource = new SaatphereWIN.DAL.Franchisee.ClsSelect().GetFranchisees().Tables[0];
            cmbFranchisees.DisplayMember = "FranchiseeUsername";
            cmbFranchisees.ValueMember = "FRRowID";
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //jaipuroffice 
            //1IEjH
            //
            InitializeDialog();
            CheckAdminRights();            



            string version = SaatphereWIN.DAL.Constants.ApplicationVersion.ToString();
            lblVersion.Text = "Version: " + version + " | 10.45 am - 07-5-2016";
            
            //try
            //{
            //    DateTimeFormatInfo di = new DateTimeFormatInfo();
            //    di.FullDateTimePattern = "dddd, dd MMMM yyyy HH:mm:ss";
            //    lblDI.Text = "DateTimePattern: " + di.FullDateTimePattern;
            //}
            //catch (Exception ex)
            //{
            //    lblDI.Text = "DateTimePattern: " + ex.Message;
            //}            
            
            //MessageBox.Show(di.FullDateTimePattern);

            ////if (new SaatphereWIN.DAL.clsCommon().Read("SaatPhereUsername") != null)
            ////{
            ////    cmbUsernames.Text = new SaatphereWIN.DAL.clsCommon().Read("SaatPhereUsername").ToString();
            ////    chkRememberMe.CheckState = CheckState.Checked;
            ////}

            ////if (new SaatphereWIN.DAL.clsCommon().Read("SaatPherePassword") != null)
            ////{
            ////    txtPassword.Text = new SaatphereWIN.DAL.clsCommon().Read("SaatPherePassword").ToString();
            ////    chkRememberMe.CheckState = CheckState.Checked;
            ////}

            //cmbLoginAs.SelectedItem = "Franchisee";

            //BindFranchisees(); //Load Franchisees
        }

        private void InitializeDialog()
        {
            //ResourceManager rm = new ResourceManager("Resource.resx", Assembly.GetExecutingAssembly());

            lblHeading.Text = Resource.ResourceManager.GetString("ApplicationName");   

        }

        /// <summary>
        /// To save the credentials in Registry, we need to save them in the Registry. Check primarily whether the user has such rights or not.
        /// </summary>
        private void CheckAdminRights()
        {
            //Check Admin rights by writing a dummy value in registry

            if(new SaatphereWIN.DAL.ClsCommon().Write("SaatPhereUsername", cmbUsernames.Text).Contains("denied"))
            {
                new MessageBoxes.FrmPermissionDialog().ShowDialog();
            }
        }


        private void cmbFranchisees_Click(object sender, EventArgs e)
        {

        }

        private void cmbFranchisees_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void cmbFranchisees_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet dst = new DataSet();
                dst = new SaatphereWIN.DAL.Franchisee.ClsSelect().GetExecutivesfromFranchiseeId(Convert.ToInt32(cmbFranchisees.SelectedValue));

                if (dst.Tables.Count > 0)
                {
                    cmbUsernames.DataSource = dst.Tables[0];
                    cmbUsernames.DisplayMember = "Executive_Name";
                    cmbUsernames.ValueMember = "Executive_CID";
                }
            }
            catch (Exception)
            {
                
                //throw;
            }

        }

        private void cmbFranchisees_MouseLeave(object sender, EventArgs e)
        {

        }

        private void cmbUsernames_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void cmbFranchisees_Leave(object sender, EventArgs e)
        {
            
        }

        private void btnShreeshaadi_Click(object sender, EventArgs e)
        {
            //new Shreeshaadi_WIN.frmMain().ShowDialog();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document wordDoc = new Microsoft.Office.Interop.Word.Document();
            Object oMissing = System.Reflection.Missing.Value;
            wordDoc = word.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            word.Visible = false;
            Object filepath = "c:\\page.html";
            Object confirmconversion = System.Reflection.Missing.Value;
            Object readOnly = false;
            Object saveto = "d:\\doc.pdf";
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
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
