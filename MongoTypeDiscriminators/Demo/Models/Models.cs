using AutoMapper;
using Demo.Code;

namespace Demo.Models
{
    public class VehicleViewModel
    {
        public string MaximumSpeed { get; set; }
    }

    public class CarViewModel : VehicleViewModel
    {
        public int MaximumPassengers { get; set; } 
    }

    public class TruckViewModel : VehicleViewModel
    {
        public string MaximumLoad { get; set; }
    }

    public class VehicleMappings
    {
        public static void Start()
        {
            Mapper.CreateMap<Vehicle, VehicleViewModel>()
                .ForMember( dst => dst.MaximumSpeed, 
                            opt => opt.MapFrom(src => FormatSpeed(src.MaximumSpeed)))
                .Include<Car, CarViewModel>()
                .Include<Truck, TruckViewModel>();

            Mapper.CreateMap<Car, CarViewModel>();
            
            Mapper.CreateMap<Truck, TruckViewModel>()
                .ForMember( dst => dst.MaximumLoad, 
                            opt => opt.MapFrom(src => FormatLoad(src.MaximumLoad)));
        }

        public static string FormatSpeed(int speed)
        {
            return string.Format("{0} km/h", speed);
        }

        public static string FormatLoad(int load)
        {
            return string.Format("{0} kg", load);
        }
    }
}