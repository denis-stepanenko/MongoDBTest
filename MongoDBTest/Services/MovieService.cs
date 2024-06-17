using MongoDB.Driver;
using MongoDBTest.Models;

namespace MongoDBTest.Services
{
    public class MovieService
    {
        private readonly IMongoCollection<Movie> _collection;

        public MovieService()
        {
            var mongoClient = new MongoClient("mongodb://root:example@localhost/?retryWrites=true&w=majority");

            var mongoDatabase = mongoClient.GetDatabase("test");

            _collection = mongoDatabase.GetCollection<Movie>("movies");
        }

        public async Task<List<Movie>> GetAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<Movie?> GetAsync(string id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Movie item) =>
            await _collection.InsertOneAsync(item);

        public async Task UpdateAsync(Movie item) =>
            await _collection.ReplaceOneAsync(x => x.Id == item.Id, item);

        public async Task RemoveAsync(string id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);
    }
}