namespace Lovie.Repository;

public interface IUserRepository{
    Task<List<User>> GetAllUsers();
    Task<User> AddUser(User user);
}

public class UserRepository : IUserRepository
{
    private readonly IMongoContext _context;
    public UserRepository(IMongoContext context)
    {
        _context = context;
    }
    public async Task<User> AddUser(User user)
    {
        await _context.UserCollection.InsertOneAsync(user);
        return user;
    }

    public async Task DeleteUsers(string id)
    {
        await _context.UserCollection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _context.UserCollection.Find(_ => true).ToListAsync();
    }
}