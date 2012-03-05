using System.Collections.Generic;
using System.Web.Mvc;

namespace ExtendingJsonResult.Code
{
    struct HtmlPartial
    {
        public string Name;
        public object Model;
    }

    public class JsonAndMultiHtmlResult : JsonAndHtmlResult
    {
        public JsonAndMultiHtmlResult(object json)
        {
            _json = json;
            _partials = new Dictionary<string, HtmlPartial>();
            _results = new Dictionary<string, string>();
        }

        private readonly object _json;
        private readonly IDictionary<string, HtmlPartial> _partials;
        private readonly IDictionary<string, string> _results;

        public JsonAndMultiHtmlResult WithHtml(string key, string partialViewName = null, object model = null)
        {
            _partials.Add(key, new HtmlPartial { Name = partialViewName, Model = model });
            return this;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            foreach (var partial in _partials)
            {
                var html = RenderPartialAsString(context, partial.Value.Name, partial.Value.Model);
                _results.Add(partial.Key, html);
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
                    HtmlData = _results,
                    JsonData = _json
                };
            }
        }
    }
}