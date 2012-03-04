using System.Collections.Generic;
using MongoDB.Driver.Builders;

namespace Demo.Code
{
    public class Services
    {
        private readonly MongoRepository<Vehicle> _vehicleRepository;
        private const string TypeDiscriminatorField = "_t";
        public Services()
        {
            _vehicleRepository = new MongoRepository<Vehicle>("Vehicles");
        }

        public IEnumerable<Vehicle> ListVehicles()
        {
            return _vehicleRepository.Collection.FindAll();
        }

        public IEnumerable<Truck> ListTrucks()
        {
            // "_t" EQUALS "Truck"
            var query = Query.EQ(TypeDiscriminatorField, typeof(Truck).Name);
            return _vehicleRepository.Collection.FindAs<Truck>(query);
        }

        public IEnumerable<Car> ListCars()
        {
            // "_t" EQUALS "Car"
            var query = Query.EQ(TypeDiscriminatorField, typeof(Car).Name);
            return _vehicleRepository.Collection.FindAs<Car>(query);
        }

        public void CreateCar(int maximumSpeed, int maximumPassengers)
        {
            var car = new Car
                            {
                                MaximumSpeed = maximumSpeed,
                                MaximumPassengers = maximumPassengers
                            };
            _vehicleRepository.Collection.Save(car);
        }

        public void CreateTruck(int maximumSpeed, int maximumLoad)
        {
            var truck = new Truck
                                {
                                    MaximumSpeed = maximumSpeed,
                                    MaximumLoad = maximumLoad
                                };
            _vehicleRepository.Collection.Save(truck);
        }
    }
}