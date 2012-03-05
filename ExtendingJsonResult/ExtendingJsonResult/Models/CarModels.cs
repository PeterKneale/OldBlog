using ExtendingJsonResult.Code;

namespace ExtendingJsonResult.Models
{
    public class CarViewModel
    {
        // This is mapped from the field of the same name on the domain object
        public string Description { get; set; }
    }

    public class ModelMappings
    {
        
        public static void Start()
        {
            // Add the mapping between a car object and its view model. This is called by Global.Ascx at startup
            AutoMapper.Mapper.CreateMap<Car, CarViewModel>();
        }
    }
}