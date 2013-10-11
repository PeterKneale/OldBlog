using Newtonsoft.Json;

namespace Gallery.Core.Domain
{
    public class Image
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        
        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }

        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }

        [JsonProperty(PropertyName = "section")]
        public string Section { get; set; }

        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }
    }
}