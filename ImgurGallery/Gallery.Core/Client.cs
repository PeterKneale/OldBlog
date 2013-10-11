using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Gallery.Core.Domain;
using Gallery.Core.Json;
using Gallery.Core.Responses;
using Newtonsoft.Json;

namespace Gallery.Core
{
    public interface IClient
    {
        Image GetImage(string id);
        Album GetAlbum(string id);
        GalleryItemImage GetGalleryImage(string id);
        GalleryItemAlbum GetGalleryAlbum(string id);
        IEnumerable<GalleryItem> GetDefaultGallery();
    }

    public class Client : IClient
    {
        private readonly IClientSettings _settings;
        
        public Client(IClientSettings settings)
        {
            _settings = settings;
        }

        public IEnumerable<GalleryItem> GetDefaultGallery()
        {
            var url = string.Format("{0}/gallery/hot/viral/1.json?showViral=bool", _settings.EndPoint);
            return GetList<GalleryItem>(url, new GalleryItemConverter());
        }

        public GalleryItemImage GetGalleryImage(string id)
        {
            var url = string.Format("{0}/gallery/image/{1}.json", _settings.EndPoint, id);
            return GetSingle<GalleryItemImage>(url);
        }

        public GalleryItemAlbum GetGalleryAlbum(string id)
        {
            var url = string.Format("{0}/gallery/album/{1}.json", _settings.EndPoint, id);
            return GetSingle<GalleryItemAlbum>(url);
        }

        public Image GetImage(string id)
        {
            var url = string.Format("{0}/image/{1}.json", _settings.EndPoint, id);
            return GetSingle<Image>(url);
        }

        public Album GetAlbum(string id)
        {
            var url = string.Format("{0}/album/{1}.json", _settings.EndPoint, id);
            return GetSingle<Album>(url);
        }

        private IEnumerable<T> GetList<T>(string url, JsonConverter converter = null)
        {
            var client = new WebClient();
            client.Headers["Authorization"] = "Client-ID " + _settings.ClientId;
            var json = client.DownloadString(new Uri(url));
            var converters = new List<JsonConverter>();
            if (converter != null)
            {
                converters.Add(converter);
            }
            return JsonConvert.DeserializeObject<ListResponse<T>>(json, converters.ToArray()).Data;
        }

        private T GetSingle<T>(string url)
        {
            var client = new WebClient();
            client.Headers["Authorization"] = "Client-ID " + _settings.ClientId;
            var json = client.DownloadString(new Uri(url));
            return JsonConvert.DeserializeObject<SingleResponse<T>>(json).Data;
        }
    }
}