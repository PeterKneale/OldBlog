using System.Web.Mvc;
using ExtendingJsonResult.Code;

namespace ExtendingJsonResult.Controllers
{
    public class BaseController : Controller
    {
        // This simplifies the creation of the json data result class
        protected internal virtual CustomJsonResult CustomJson(object json = null, bool allowGet = true)
        {
            return new CustomJsonResult(json)
            {
                JsonRequestBehavior = allowGet ? JsonRequestBehavior.AllowGet : JsonRequestBehavior.DenyGet
            };
        }
    }
}
