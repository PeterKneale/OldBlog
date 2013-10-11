using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Gallery.Core;
using Gallery.Core.Domain;
using Gallery.Web.Models;

namespace Gallery.Web.Controllers
{
    public class HomeController : Controller
    {
       private readonly IClient _client;

       public HomeController(IClient client)
        {
            _client = client;
        }

        public ActionResult Index()
        {
            var data = _client.GetDefaultGallery();
            var model = Mapper.Map<IEnumerable<GalleryItem>, IEnumerable<BaseGalleryModel>>(data);
            return View(model);
        }

    }
}
