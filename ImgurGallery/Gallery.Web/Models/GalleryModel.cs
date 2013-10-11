using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gallery.Web.Models
{
    public abstract class BaseGalleryModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }

    public class GalleryImageModel : BaseGalleryModel
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public string Section { get; set; }

        public string Link { get; set; }

        public string Thumbnail
        {
            get
            {
                return Link.Insert(Link.Length-4,"s");
            }
        }
    }

    public class GalleryAlbumModel : BaseGalleryModel
    {
        public string CoverImageId { get; set; }

        public string Link { get; set; }

        public string Thumbnail
        {
            get
            {
                return string.Format("http://i.imgur.com/{0}s.jpg", CoverImageId);
            }
        }
    }
}