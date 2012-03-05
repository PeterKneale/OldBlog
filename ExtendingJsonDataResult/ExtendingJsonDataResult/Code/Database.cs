using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtendingJsonResult.Code
{
    public class Database
    {
        private static readonly List<Car> _cars;

        static Database()
        {
            _cars = new List<Car>();
            _cars.Add(new Car { Id = 1, Description = "Toyota Celica" });
            _cars.Add(new Car { Id = 2, Description = "Ford Falcon" });
            _cars.Add(new Car { Id = 3, Description = "Honda Jazz" });
            _cars.Add(new Car { Id = 4, Description = "Mitsubishi Nimbus" });
        }

        public static int Add(string description)
        {
            var id = _cars.Count == 0 ? 1 : _cars.Max(c => c.Id) + 1;
            var car = new Car { Id = id, Description = description };
            _cars.Add(car);
            return car.Id;
        }
        public static void Update(int id, string description)
        {
            Read(id).Description = description;
        }
        public static void Delete(int id)
        {
            _cars.Remove(Read(id));
        }
        public static Car Read(int id)
        {
            return _cars.Single(c => c.Id == id);
        }

        public static IEnumerable<Car> ListAllCars()
        {
            return _cars;
        }
        public static IEnumerable<Car> ListRandomCars()
        {
            int random = new Random().Next(4);
            return _cars.Take(random);
        }
    }
}