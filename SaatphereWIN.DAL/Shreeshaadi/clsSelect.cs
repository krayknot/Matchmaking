using System;
using System.Linq;

namespace SaatphereWIN.DAL.Shreeshaadi
{
    public class ClsSelect
    {
        public int GetDropChoiceCidFromString(string dropChoiceString)
        {
            int response = 0;

            DBClass.dcShreeshaadiDataContext shreeshaadi = new DBClass.dcShreeshaadiDataContext(Global.ShreeshaadiCon);
            var query = shreeshaadi.DropChoices.SingleOrDefault(a => a.DropChoices_Title.Equals(dropChoiceString) && a.DropChoices_Head.Equals(20) && a.DropChoices_Active.Equals(true));
            if (query != null)
            {
                response = Convert.ToInt32(query.DropChoices_CID);
            }
            return response;
        }

        public string GetHeadingIDforManglik(string stringHeading)
        {
            int response = 0;

            DBClass.dcShreeshaadiDataContext shreeshaadi = new DBClass.dcShreeshaadiDataContext(Global.ShreeshaadiCon);
            var query = shreeshaadi.DropChoices.SingleOrDefault(a => a.DropChoices_Title.Equals(stringHeading) && a.DropChoices_Head.Equals(42));
            if (query != null)
            {
                response = Convert.ToInt32(query.DropChoices_CID);
            }
            return response.ToString();
        }

        public string GetHeadingIDforHeight(string stringHeading)
        {
            int response = 0;

            DBClass.dcShreeshaadiDataContext shreeshaadi = new DBClass.dcShreeshaadiDataContext(Global.ShreeshaadiCon);
            var query = shreeshaadi.DropChoices.SingleOrDefault(a => a.DropChoices_Title.ToLower().Equals(stringHeading) && a.DropChoices_Active.Equals(true));
            if (query != null)
            {
                response = Convert.ToInt32(query.DropChoices_CID);
            }
            return response.ToString();
        }

        public int GetReligionCidFromString(string dropChoiceString)
        {
            int response = 0;

            DBClass.dcShreeshaadiDataContext shreeshaadi = new DBClass.dcShreeshaadiDataContext(Global.ShreeshaadiCon);
            var query = shreeshaadi.DropChoices.SingleOrDefault(a => a.DropChoices_Title.Equals(dropChoiceString.Replace("'", "")) && a.DropChoices_Head.Equals(11) && a.DropChoices_Active.Equals(true));
            if (query != null)
            {
                response = Convert.ToInt32(query.DropChoices_CID);
            }
            return response;
        }

    }
}
