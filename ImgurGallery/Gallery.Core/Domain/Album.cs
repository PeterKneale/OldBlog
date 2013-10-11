using System.Collections.Generic;
using Newtonsoft.Json;

namespace Gallery.Core.Domain
{
    public class Album
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "images")]
        public IEnumerable<Image> Images { get; set; }
    }
}