using CP.Main.Models;
using MongoDB.Driver;

namespace CP.Main.Services
{
    public class MongoDbService
    {
        private readonly IMongoCollection<User> _usersCollection;

        public MongoDbService()
        {
            var connectionString = "mongodb+srv://admin:admin@communitypulse187.zhfzzkg.mongodb.net/?retryWrites=true&w=majority&appName=CommunityPulse187";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("event_app");
            _usersCollection = database.GetCollection<User>("users");
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _usersCollection.Find(_ => true).ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(string userId)
        {
            return await _usersCollection.Find(u => u.UserId == userId).FirstOrDefaultAsync();
        }

        // Add more methods as needed (Insert, Update, Delete)
    }
}
