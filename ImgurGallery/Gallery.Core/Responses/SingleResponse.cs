using Newtonsoft.Json;

namespace Gallery.Core.Responses
{
    public class SingleResponse<T>
    {
        [JsonProperty(PropertyName = "data")]
        public T Data { get; set; }
        public bool Success { get; set; }
        public int Status { get; set; }
    }
}