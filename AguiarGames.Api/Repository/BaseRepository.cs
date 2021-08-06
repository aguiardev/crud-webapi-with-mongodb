using MongoDB.Driver;

namespace AguiarGames.Api.Repository
{
    public class BaseRepository<T>
    {
        protected readonly IMongoCollection<T> _collection;

        public BaseRepository(
            string connectionString, string databaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

            _collection = database.GetCollection<T>(collectionName);
        }
    }
}