using System.Web.Mvc;
using AutoMapper;
using Gallery.Core;
using Gallery.Core.Domain;
using Gallery.Web.Models;

namespace Gallery.Web.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IClient _client;

        public AlbumController(IClient client)
        {
            _client = client;
        }

        public ActionResult List()
        {
            _client.GetDefaultGallery();
            return View();
        }
        public ActionResult View(string id)
        {
            var album = _client.GetAlbum(id);
            var model = Mapper.Map<Album, AlbumModel>(album);
            return View(model);
        }
    }
}