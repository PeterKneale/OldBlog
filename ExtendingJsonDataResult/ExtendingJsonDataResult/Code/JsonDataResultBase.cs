using System.IO;
using System.Text;
using System.Web.Mvc;
using System.Web.UI;

namespace ExtendingJsonDataResult.Code
{
    public class JsonDataResultBase : JsonResult
    {
        protected string RenderPartialAsString(ControllerContext context, string viewName, object model)
        {
            var controller = context.Controller;

            var partialView = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);

            var stringBuilder = new StringBuilder();
            using (var stringWriter = new StringWriter(stringBuilder))
            {
                using (var htmlWriter = new HtmlTextWriter(stringWriter))
                {
                    controller.ViewData.Model = model;
                    var viewContext = new ViewContext(
                        controller.ControllerContext, 
                        partialView.View, 
                        controller.ViewData, 
                        new TempDataDictionary(), 
                        htmlWriter);
                    partialView.View.Render(viewContext, htmlWriter);
                }
            }
            return stringBuilder.ToString();
        }
    }
}