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
        public ActionResult SingleDemo()
        {
            return View();
        }

        public ActionResult MultiDemo()
        {
            return View();
        }

        public JsonResult SingleResultDemo()
        {
            // Load Data
            var cars = Database.ListAllCars();
            var total = cars.Count();

            // Create Model Object
            var model = AutoMapper.Mapper.Map<IEnumerable<Car>, IEnumerable<CarViewModel>>(cars);

            // Create the json Data object
            var json = new {Total = total, Time = DateTime.Now.ToString("h:mm:ss:fff")};
            
            // Return Json and Html in one request!
            return JsonAndSingleHtml(json)
                .WithHtml("_CarList", model);
        }

        public JsonResult MultiResultDemo()
        {
            // Load Data
            var allCars = Database.ListAllCars();
            var randomCars = Database.ListRandomCars();
            var total = allCars.Count() + randomCars.Count();

            // Create Model Object
            var model1 = AutoMapper.Mapper.Map<IEnumerable<Car>, IEnumerable<CarViewModel>>(allCars);
            var model2 = AutoMapper.Mapper.Map<IEnumerable<Car>, IEnumerable<CarViewModel>>(randomCars);

            // Create the json Data object
            var json = new { Total = total, Time = DateTime.Now.ToString("h:mm:ss:fff") };

            // Return Json and Multiple Html Partials in one request!
            return JsonAndMultiHtml(json)
                .WithHtml("All", "_CarList", model1)
                .WithHtml("Random", "_FancyCarList", model2);
        }
    }
}
