using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FriendlyDateTime.Code.Domain;
using FriendlyDateTime.Models;

namespace FriendlyDateTime.Controllers
{
    public class AuctionController : Controller
    {
        //
        // GET: /Demo/

        public ActionResult Index()
        {
            var auctions = Code.Services.AuctionService.GetAuctions();
            var model = AutoMapper.Mapper.Map<IEnumerable<Auction>, IEnumerable<AuctionViewModel>>(auctions);
            return View(model);
        }

    }
}
