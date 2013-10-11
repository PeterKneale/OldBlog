using System.Collections.Generic;
using System.Linq;

namespace Gallery.Web.Models
{
    public class AlbumModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<ImageModel> Images { get; set; }

        public ImageModel FirstImage
        {
            get { return Images.First(); }
        }
    }


    
}