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
            var allProducts = Core.ListAll();
            var randomProducts = Core.RandomTwo();
            var total = allProducts.Count() + randomProducts.Count();

            // Create Model Objects
            var model1 = AutoMapper.Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(allProducts);
            var model2 = AutoMapper.Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(randomProducts);

            // Create the json  object
            var json = new { Total = total, Time = DateTime.Now.ToString("h:mm:ss:fff") };

            // Return Json and Multiple Html Partials in one request!
            return CustomJson(json)
                .WithHtml("_ListHorizontal", model1)
                .WithHtml("_ListVertical", model1)
                .WithHtml("_ListCommaSeperated", model2);
        }
    }
}
