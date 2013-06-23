using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ExtendingJsonResult.Code;
using ExtendingJsonResult.Models;

namespace ExtendingJsonResult.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Demo()
        {
            // Load Data
            var allCars = Core.ListAll();
            var randomCars = Core.RandomTwo();
            var total = allCars.Count() + randomCars.Count();

            // Create Model Object
            var model1 = AutoMapper.Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(allCars);
            var model2 = AutoMapper.Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(randomCars);

            // Create the json Data object
            var json = new { Total = total, Time = DateTime.Now.ToString("h:mm:ss:fff") };

            // Return Json and Multiple Html Partials in one request!
            return CustomJson(json)
                .WithHtml("_ListHorizontal", model1)
                .WithHtml("_ListVertical", model1)
                .WithHtml("_ListCommaSeperated", model2);
        }
    }
}
