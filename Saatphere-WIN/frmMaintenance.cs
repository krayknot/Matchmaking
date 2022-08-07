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
    public partial class frmMaintenance : Form
    {
        public frmMaintenance()
        {
            InitializeComponent();
        }

        private void btnUpdateSearchXML_Click(object sender, EventArgs e)
        {
            DataSet dstXML = new DataSet();
            dstXML = new SaatphereWIN.DAL.ClsMaintenance().GetSearchSourceMale();
            dstXML.WriteXml("D://SearchXMLMale.xml");

            dstXML = new SaatphereWIN.DAL.ClsMaintenance().GetSearchSourceMale();
            dstXML.WriteXml("D://SearchXMLFemale.xml");

            //religion
            dstXML = new SaatphereWIN.DAL.ClsMaintenance().GetReligion();
            dstXML.WriteXml("D://Religion.xml");


            //caste
            dstXML = new SaatphereWIN.DAL.ClsMaintenance().GetCaste();
            dstXML.WriteXml("D://Caste.xml");


            //state
            dstXML = new SaatphereWIN.DAL.ClsMaintenance().GetState();
            dstXML.WriteXml("D://State.xml");


            //mother tongue
            dstXML = new SaatphereWIN.DAL.ClsMaintenance().GetMotherTongue();
            dstXML.WriteXml("D://MotherTongue.xml");
        }
    }
}
