using System.Web.Mvc;
using ExtendingJsonResult.Code;

namespace ExtendingJsonResult.Controllers
{
    public class BaseController : Controller
    {
        // This simplifies the creation of the json data result class
        protected internal virtual JsonAndSingleHtmlResult JsonAndSingleHtml(object json = null, bool allowGet = true)
        {
            return new JsonAndSingleHtmlResult(json)
            {
                JsonRequestBehavior = allowGet ? JsonRequestBehavior.AllowGet : JsonRequestBehavior.DenyGet
            };
        }

        // This simplifies the creation of the json data result class
        protected internal virtual JsonAndMultiHtmlResult JsonAndMultiHtml(object json = null, bool allowGet = true)
        {
            return new JsonAndMultiHtmlResult(json)
            {
                JsonRequestBehavior = allowGet ? JsonRequestBehavior.AllowGet : JsonRequestBehavior.DenyGet
            };
        }
    }
}
