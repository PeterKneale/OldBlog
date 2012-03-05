using System.Web.Mvc;
using ExtendingJsonResult.Code;

namespace ExtendingJsonResult.Controllers
{
    public class BaseController : Controller
    {
        // This simplifies the creation of the json data result class
        protected internal virtual JsonAndSingleHtmlResult JsonData(object json = null, bool allowGet = false)
        {
            return new JsonAndSingleHtmlResult(json)
            {
                JsonRequestBehavior = allowGet ? JsonRequestBehavior.AllowGet : JsonRequestBehavior.DenyGet
            };
        }

        // This simplifies the creation of the json data result class
        protected internal virtual JsonAndMultiHtmlResult MultiJsonData(object json = null, bool allowGet = false)
        {
            return new JsonAndMultiHtmlResult(json)
            {
                JsonRequestBehavior = allowGet ? JsonRequestBehavior.AllowGet : JsonRequestBehavior.DenyGet
            };
        }
    }
}
