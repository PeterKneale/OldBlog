using System.Configuration;
using MongoDB.Driver;

namespace Demo.Code
{
    public class MongoRepository<T> where T : BaseEntity
    {
        internal MongoDatabase Database { get; set; }

        public MongoRepository(string collectionName)
        {
            Database = MongoDatabaseHelper.GetMongoDatabase();
            Collection = Database.GetCollection<T>(collectionName);
        }

        public MongoCollection<T> Collection { get; private set; }
    } 

    public static class MongoDatabaseHelper
    {
        public static MongoDatabase GetMongoDatabase()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Mongo"].ConnectionString;
            var connection = new MongoConnectionStringBuilder(connectionString);
            var server = MongoServer.Create(connection);
            return server.GetDatabase(connection.DatabaseName);
        }
    }
}