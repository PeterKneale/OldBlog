using System.ComponentModel.DataAnnotations;
using NotificationBar.Code;

namespace NotificationBar.Models
{
    public class CarEditModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "What make is this car?")]
        public string Make { get; set; }

        [Required(ErrorMessage = "What year was this car made?")]
        public int Year { get; set; }
    }

    public class CarCreateModel
    {
        [Required(ErrorMessage = "What make is this car?")]
        public string Make { get; set; }

        [Required(ErrorMessage = "What year was this car made?")]
        public int Year { get; set; }
    }

    public class CarViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public class ModelMappings
    {
        public static void Start()
        {
            AutoMapper.Mapper.CreateMap<Car, CarViewModel>()
                .ForMember(dst => dst.Description, opt => opt.MapFrom(GetDescription)); // Map the description from the make and model using the below method

            AutoMapper.Mapper.CreateMap<Car, CarEditModel>(); // Make and model are mapped automatically as they are the same name
        }

        private static string GetDescription(Car car)
        {
            return string.Format("{0} ({1})", car.Make, car.Year);
        }
    }
}