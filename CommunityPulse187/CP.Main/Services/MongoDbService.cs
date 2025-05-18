using CP.Main.Models;
using MongoDB.Driver;

namespace CP.Main.Services
{
    public class MongoDbService
    {
        private readonly IMongoCollection<User> _usersCollection;
        private readonly IMongoCollection<Event> _eventsCollection;
        private readonly IMongoCollection<UserEvent> _userEventsCollection;

        public MongoDbService()
        {
            var connectionString = "mongodb+srv://admin:admin@communitypulse187.zhfzzkg.mongodb.net/?retryWrites=true&w=majority&appName=CommunityPulse187";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("event_app");
            _usersCollection = database.GetCollection<User>("users");
            _eventsCollection = database.GetCollection<Event>("events");
            _userEventsCollection = database.GetCollection<UserEvent>("user_events");
        }

        // User
        public async Task<List<User>> GetUsersAsync()
        {
            return await _usersCollection.Find(_ => true).ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(string userId)
        {
            return await _usersCollection.Find(u => u.UserId == userId).FirstOrDefaultAsync();
        }

        // Events
        public async Task<List<Event>> GetEventsAsync()
        {
            return await _eventsCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Event?> GetEventByIdAsync(string eventId)
        {
            return await _eventsCollection.Find(e => e.EventId == eventId).FirstOrDefaultAsync();
        }

        // UserEvents
        public async Task<List<UserEvent>> GetUserEventsAsync()
        {
            return await _userEventsCollection.Find(_ => true).ToListAsync();
        }

        public async Task<List<UserEvent>> GetUserEventsByUserIdAsync(string userId)
        {
            return await _userEventsCollection.Find(ue => ue.UserId == userId).ToListAsync();
        }

        public async Task<List<UserEvent>> GetUserEventsByEventIdAsync(string eventId)
        {
            return await _userEventsCollection.Find(ue => ue.EventId == eventId).ToListAsync();
        }
    }
}
