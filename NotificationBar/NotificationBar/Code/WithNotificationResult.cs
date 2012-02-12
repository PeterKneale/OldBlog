using System.Web.Mvc;

namespace NotificationBar.Code
{
    /// <summary>
    /// Custom action result that adds a notification to the notifications class.
    /// </summary>
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
}