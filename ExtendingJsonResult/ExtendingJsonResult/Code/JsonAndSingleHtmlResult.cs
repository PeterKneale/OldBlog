using System.Web.Mvc;

namespace ExtendingJsonResult.Code
{
    public class JsonAndSingleHtmlResult : JsonAndHtmlResult
    {
        public JsonAndSingleHtmlResult(object json)
        {
            _json = json;
        }

        private string _html;
        private readonly object _json;

        private string _partialViewName;
        private object _partialViewModel;

        public JsonAndSingleHtmlResult WithHtml(string partialViewName = null, object model = null)
        {
            // Store the names of the partials for later use
            _partialViewName = partialViewName;
            _partialViewModel = model;
            return this;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (!string.IsNullOrEmpty(_partialViewName))
            {
                _html = RenderPartialAsString(context, _partialViewName, _partialViewModel);
            }
            base.Data = Data;
            base.ExecuteResult(context);
        }

        public new object Data
        {
            get
            {
                return new
                {
                    HtmlData = _html,
                    JsonData = _json
                };
            }
        }
    }
}