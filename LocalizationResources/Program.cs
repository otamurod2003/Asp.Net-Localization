using LocalizationResources.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped<ICarRepository, CarRepository>(provider=> new CarRepository(connectionString));
app.MapGet("/", () => "Hello World!");

app.Run();
