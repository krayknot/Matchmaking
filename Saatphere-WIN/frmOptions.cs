using Microsoft.Win32;
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
    public partial class frmOptions : Form
    {
        public frmOptions()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isValid = false;

            if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                MessageBox.Show("Password and Confirm password should match");
            }
            else if (txtGmailPassword.Text.Trim() != txtGmailConfirmPassword.Text.Trim())
            {
                MessageBox.Show("Gmail Password and Confirm password should match");
            }
            else
            {
                isValid = true;
            }


            if(isValid)
            {
                //Email address settings
                //RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\SaatphereEmailDetails");
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("PROFILESENDINGEMAIL");
                key.SetValue("EmailAddress", txtEmailAddress.Text);
                key.SetValue("Password", txtPassword.Text);

                key.SetValue("GmailEmailAddress", txtGmailEmail.Text);
                key.SetValue("GmailPassword", txtGmailPassword.Text);

                key.Close();

                //Database connection settings


                //Email preference setting
                Microsoft.Win32.RegistryKey keyEmailPreference = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("EMAILPREFERENCE");
                if (rdbGoogle.Checked)
                {
                    keyEmailPreference.SetValue("EmailSender", "Google");
                }

                if (rdbPOG.Checked)
                {
                    keyEmailPreference.SetValue("EmailSender", "PeopleOneGroup");
                }

                keyEmailPreference.Close();
            }
            
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("PROFILESENDINGEMAIL");
                string emailAddress = key.GetValue("EmailAddress").ToString();
                string password = key.GetValue("Password").ToString();
                
                string gmailEmailAddress = key.GetValue("GmailEmailAddress").ToString();
                string gmailPassword = key.GetValue("GmailPassword").ToString();


                txtEmailAddress.Text = emailAddress;
                txtPassword.Text = password;
                txtConfirmPassword.Text = password;

                txtGmailEmail.Text = gmailEmailAddress;
                txtGmailPassword.Text = gmailPassword;
                txtGmailConfirmPassword.Text = gmailPassword;

            }
            catch (Exception)
            {
                //throw;
            }

            try
            {
                Microsoft.Win32.RegistryKey keyEmailPreference = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("EMAILPREFERENCE");
                string emailSender = keyEmailPreference.GetValue("EmailSender").ToString();

                if(emailSender == "Google")
                {
                    rdbGoogle.Checked = true;
                }
                else if (emailSender == "PeopleOneGroup")
                {
                    rdbPOG.Checked = true;
                }    
            }
            catch (Exception)
            {
                //throw;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
