using MongoDB.Driver;

namespace orderApi.Repositories
{
    public class DbRepository
    {
        public MongoClient client;

        public IMongoDatabase db;

        public DbRepository()
        {
            client = new MongoClient("mongodb://127.0.0.1:27017");

            db = client.GetDatabase("shopDbFabrizioGelsi");
        }
    }
}
