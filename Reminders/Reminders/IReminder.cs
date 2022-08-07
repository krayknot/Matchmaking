using System.Data; 

namespace Reminders
{
    interface IReminder
    {
        void OpenConnectionSource();
        void CloseConnectionSource();
        DataSet GetCustomerList(string startLetter);



    }
}
