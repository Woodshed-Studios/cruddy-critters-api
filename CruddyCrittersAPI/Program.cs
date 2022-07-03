using CruddyCrittersAPI.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

ConfigureRoutes(app);

app.Run();

/// <summary>
/// Configure the services for dependency injection and configuration
/// </summary>
void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    services.AddSignalR();
}

/// <summary>
/// Configure the routes for the http(s) endpoints. Currently:
/// - Health
/// </summary>
void ConfigureRoutes(WebApplication app)
{
    app.MapControllers();
    app.MapHub<LobbyHub>("/lobbyhub");
}
