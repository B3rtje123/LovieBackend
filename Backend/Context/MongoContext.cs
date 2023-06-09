namespace Lovie.Context;


public interface IMongoContext
{
    IMongoDatabase Database { get; }
    IMongoCollection<User> UserCollection { get; }
}

public class MongoContext : IMongoContext
{
    private readonly MongoClient _client;
    private readonly IMongoDatabase _database;

    private readonly DatabaseSettings _settings;

    public IMongoClient Client
    {
        get
        {
            return _client;
        }
    }
    public IMongoDatabase Database => _database;

    public MongoContext(IOptions<DatabaseSettings> dbOptions)
    {
        _settings = dbOptions.Value;
        _client = new MongoClient(_settings.ConnectionString);
        _database = _client.GetDatabase(_settings.DatabaseName);
    }

    public IMongoCollection<User> UserCollection
    {
        get
        {
            return _database.GetCollection<User>(_settings.UserCollection);
        }
    }
}