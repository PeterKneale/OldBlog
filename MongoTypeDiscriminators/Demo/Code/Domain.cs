using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Demo.Code
{
    /// <summary>
    /// Base class for all mongo entities.
    /// </summary>
    public abstract class BaseEntity
    {
        public ObjectId Id
        {
            get;
            set;
        }
    }
    
    /// <summary>
    /// Base class for all types of vehicles
    /// BsonKnownTypes: The mongo serialiser and deserialiser require this.
    /// </summary>
    [BsonKnownTypes(typeof(Truck), typeof(Car))]
    public abstract class Vehicle : BaseEntity
    {
        public int MaximumSpeed { get; set; }
    }

    public class Truck : Vehicle
    {
        public int MaximumLoad { get; set; }
    }

    public class Car : Vehicle
    {
        public int MaximumPassengers{ get; set; }
    }

}