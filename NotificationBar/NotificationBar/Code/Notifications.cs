using System.Collections.Generic;
using System.Web.Mvc;

namespace NotificationBar.Code
{
    public class Notifications
    {
        private const string DictionaryName = "NOTIFICATIONS";
        private IList<Notification> _notifications;

        public Notifications(TempDataDictionary tempDataDictionary)
        {
            if (!tempDataDictionary.ContainsKey(DictionaryName))
            {
                tempDataDictionary[DictionaryName] = new List<Notification>();
            }
            _notifications = tempDataDictionary[DictionaryName] as IList<Notification>;
        }

        public IEnumerable<Notification> Current
        {
            get { return _notifications; }
        }

        public void Add(Status status, string message)
        {
            _notifications.Add(new Notification{Status = status, Message = message});
        }
    }
}