namespace Gallery.Web.Models
{
    public class ImageModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string Link { get; set; }

        public string Thumbnail
        {
            get
            {
                return Link.Replace(".jpg", "t.jpg");
            }
        }
    }
}