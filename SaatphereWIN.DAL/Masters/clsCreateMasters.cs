using System.Data;

namespace SaatphereWIN.DAL.Masters
{
    public class ClsCreateMasters
    {
        public void CreateXml(DataSet xmlData, string xmlFileName)
        {
            xmlData.WriteXml(xmlFileName);
        }
    }
}
