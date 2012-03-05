using System.Web.Mvc;
using ExtendingJsonDataResult.Code;

namespace ExtendingJsonDataResult.Controllers
{
    public class BaseController : Controller
    {
        // This simplifies the creation of the json data result class
        protected internal virtual SingleJsonDataResult JsonData(object json = null, bool allowGet = false)
        {
            return new SingleJsonDataResult(json)
            {
                JsonRequestBehavior = allowGet ? JsonRequestBehavior.AllowGet : JsonRequestBehavior.DenyGet
            };
        }

        // This simplifies the creation of the json data result class
        protected internal virtual MultiJsonDataResult MultiJsonData(object json = null, bool allowGet = false)
        {
            return new MultiJsonDataResult(json)
            {
                JsonRequestBehavior = allowGet ? JsonRequestBehavior.AllowGet : JsonRequestBehavior.DenyGet
            };
        }
    }
}
