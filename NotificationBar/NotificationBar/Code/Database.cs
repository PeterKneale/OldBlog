using System.Collections.Generic;
using System.Linq;

namespace NotificationBar.Code
{
    public class Database
    {
        private static readonly List<Car> Cars;

        static Database()
        {
            Cars = new List<Car>();
            Cars.Add(new Car { Id = 1, Make = "Toyota Corola", Year = 1991 });
            Cars.Add(new Car { Id = 2, Make = "Toyota Celica", Year = 1992 });
            Cars.Add(new Car { Id = 3, Make = "Ford Falcon", Year = 1995 });
            Cars.Add(new Car { Id = 4, Make = "Ford Laser", Year = 1992 });
            Cars.Add(new Car { Id = 5, Make = "Honda Jazz", Year = 1993 });
            Cars.Add(new Car { Id = 6, Make = "Mitsubishi Nimbus", Year = 1998 });
        }

        public static int Add(string make, int year)
        {
            var id = Cars.Count == 0 ? 1 : Cars.Max(c => c.Id) + 1;
            var car = new Car { Id = id, Make = make, Year = year };
            Cars.Add(car);
            return car.Id;
        }

        public static void Update(int id, string make, int year)
        {
            var car = Read(id);
            car.Make = make;
            car.Year = year;
        }

        public static void Delete(int id)
        {
            Cars.Remove(Read(id));
        }

        public static Car Read(int id)
        {
            return Cars.Single(c => c.Id == id);
        }

        public static IEnumerable<Car> List()
        {
            return Cars;
        }
    }
}