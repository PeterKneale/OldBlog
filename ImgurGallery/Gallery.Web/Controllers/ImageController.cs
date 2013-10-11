using System.Web.Mvc;
using AutoMapper;
using Gallery.Core;
using Gallery.Core.Domain;
using Gallery.Web.Models;

namespace Gallery.Web.Controllers
{
    public class ImageController : Controller
    {
        private readonly IClient _client;

        public ImageController(IClient client)
        {
            _client = client;
        }

        public ActionResult View(string id)
        {
            var image = _client.GetImage(id);
            var model = Mapper.Map<Image, ImageModel>(image);
            return View(model);
        }
    }
}
