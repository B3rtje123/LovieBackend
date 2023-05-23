var builder = WebApplication.CreateBuilder(args);

// Database settings
var settings = builder.Configuration.GetSection("MongoConnection");
builder.Services.Configure<DatabaseSettings>(settings);

// interfaces
builder.Services.AddTransient<IMongoContext, MongoContext>();

// repositories
builder.Services.AddTransient<IUserRepository, UserRepository>();

// services



var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/users", async (IUserRepository userRepository) => {
    List<User> userList = await userRepository.GetAllUsers();
    return userList;
});

app.Run("http://localhost:5000");
