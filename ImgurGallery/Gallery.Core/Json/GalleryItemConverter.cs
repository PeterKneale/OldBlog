using System;
using Gallery.Core.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gallery.Core.Json
{
    public class GalleryItemConverter : JsonCreationConverter<GalleryItem>
    {
        protected override GalleryItem Create(Type objectType, JObject jObject)
        {
            if(IsAlbum(jObject))
                return new GalleryItemAlbum();
            return new GalleryItemImage();
        }

        private static bool IsAlbum(JObject jObject)
        {
            return jObject["is_album"].Value<bool>();
        }
    }
}