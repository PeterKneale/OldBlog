using Newtonsoft.Json;

namespace Gallery.Core.Domain
{
    public abstract class GalleryItem
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }

    public class GalleryItemImage : GalleryItem
    {
        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }

        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }

        [JsonProperty(PropertyName = "section")]
        public string Section { get; set; }

        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }
    }

    public class GalleryItemAlbum : GalleryItem
    {
        [JsonProperty(PropertyName = "cover")]
        public string CoverImageId { get; set; }

        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }
    }
}