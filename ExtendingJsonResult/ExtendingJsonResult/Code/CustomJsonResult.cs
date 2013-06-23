using System.Collections.Generic;
using System.Web.Mvc;

namespace ExtendingJsonResult.Code
{
    public class CustomJsonResult : JsonResult
    {
        public CustomJsonResult(object json)
        {
            _json = json;
            _partials = new List<KeyValuePair<string, object>>();
            _results = new List<string>();
        }

        private readonly object _json;
        private readonly IList<KeyValuePair<string, object>> _partials;
        private readonly IList<string> _results;

        public CustomJsonResult WithHtml(string partialViewName = null, object model = null)
        {
            _partials.Add(new KeyValuePair<string, object>(partialViewName, model));
            return this;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            foreach (var partial in _partials)
            {
                var html = RenderHelper.RenderPartialToString(context, partial.Key, partial.Value);
                _results.Add(html);
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
                    Html = _results,
                    Json = _json
                };
            }
        }
    }
}