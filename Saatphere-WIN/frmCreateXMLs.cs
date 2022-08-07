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
    public partial class frmCreateXMLs : Form
    {
        public frmCreateXMLs()
        {
            InitializeComponent();
        }

        private void frmCreateXMLs_Load(object sender, EventArgs e)
        {
            this.Hide();
            //Creates the XMLs
            string xmlFolder = "TemporaryXML\\";
            new SaatphereWIN.DAL.Masters.ClsCreateMasters().CreateXml(SaatphereWIN.DAL.Membership.ClsSelect.GetMemberships(), xmlFolder + "Memberships.xml");
            new SaatphereWIN.DAL.Masters.ClsCreateMasters().CreateXml(new SaatphereWIN.DAL.Masters.ClsSelect().GetMotherTongueItems(), xmlFolder + "MotherTongue.xml");
            new SaatphereWIN.DAL.Masters.ClsCreateMasters().CreateXml(new SaatphereWIN.DAL.Masters.ClsSelect().GetMaritalStatusItems(), xmlFolder + "MaritalStatus.xml");
            new SaatphereWIN.DAL.Masters.ClsCreateMasters().CreateXml(new SaatphereWIN.DAL.Masters.ClsSelect().GetReligionItems(), xmlFolder + "Religion.xml");
            new SaatphereWIN.DAL.Masters.ClsCreateMasters().CreateXml(new SaatphereWIN.DAL.Masters.ClsSelect().GetCasteItems(), xmlFolder + "Caste.xml");
            new SaatphereWIN.DAL.Masters.ClsCreateMasters().CreateXml(new SaatphereWIN.DAL.Masters.ClsSelect().GetAnnualIncomeItems(), xmlFolder + "AnnualIncome.xml");
            new SaatphereWIN.DAL.Masters.ClsCreateMasters().CreateXml(new SaatphereWIN.DAL.Masters.ClsSelect().GetDietItems(), xmlFolder + "Diet.xml");
            new SaatphereWIN.DAL.Masters.ClsCreateMasters().CreateXml(new SaatphereWIN.DAL.Masters.ClsSelect().GetStateItems(), xmlFolder + "State.xml");
            new SaatphereWIN.DAL.Masters.ClsCreateMasters().CreateXml(new SaatphereWIN.DAL.Masters.ClsSelect().GetCityofResidenceItems(), xmlFolder + "CityofResidence.xml");
            new SaatphereWIN.DAL.Masters.ClsCreateMasters().CreateXml(new SaatphereWIN.DAL.Masters.ClsSelect().GetOccupationItems(), xmlFolder + "Occupation.xml");
            new SaatphereWIN.DAL.Masters.ClsCreateMasters().CreateXml(new SaatphereWIN.DAL.Masters.ClsSelect().GetEducationItems(), xmlFolder + "Education.xml");
            new SaatphereWIN.DAL.Masters.ClsCreateMasters().CreateXml(new SaatphereWIN.DAL.Masters.ClsSelect().GetManglikItems(), xmlFolder + "Manglik.xml");
            new SaatphereWIN.DAL.Masters.ClsCreateMasters().CreateXml(new SaatphereWIN.DAL.Masters.ClsSelect().GetAgeItems(), xmlFolder + "Age.xml");



            this.Close();
        }

        private void CreateXML(DataSet XMLData, string XMLFileName)
        {
            XMLData.WriteXml(XMLFileName);
        }


    }
}
