using System.Collections.Generic;
using Newtonsoft.Json;

namespace Gallery.Core.Responses
{
    public class ListResponse<T>
    {
        [JsonProperty(PropertyName = "data")]
        public IEnumerable<T> Data { get; set; }
        public bool Success { get; set; }
        public int Status { get; set; }
    }
}
