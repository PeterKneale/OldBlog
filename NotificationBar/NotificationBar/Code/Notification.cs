using System.Collections.Generic;
using System.Web.Mvc;

namespace NotificationBar.Code
{

    public static class NotificationExtensions
    {
        // Used within actions to add Notifications to results 
        public static ActionResult WithNotification(this ActionResult actionResult, Status status, string message)
        {
            return new WithNotificationResult(actionResult, status, message);
        }

        // Used to hold retrieve the notifications from tempdata
        public static Notifications Notifications(this ControllerBase controller)
        {
            return new Notifications(controller.TempData);
        }

        // Used within Views to get the notifications from temp data
        public static Notifications Notifications(this HtmlHelper htmlHelper)
        {
            return new Notifications(htmlHelper.ViewContext.TempData);
        }
    }

    public class WithNotificationResult : ActionResult
    {
        private readonly ActionResult _result;
        private readonly Status _status;
        private readonly string _message;

        public WithNotificationResult(ActionResult result, Status status, string message)
        {
            _result = result;
            _status = status;
            _message = message;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            // Add the notification
            context.Controller.Notifications().Add(_status, _message);
            
            // Continue with execution
            _result.ExecuteResult(context);
        }
    }

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

    public class Notification
    {
        public Status Status { get; set; }

        public string Message { get; set; }
    }

    public enum Status
    {
        Error, Warning, Success
    }
}