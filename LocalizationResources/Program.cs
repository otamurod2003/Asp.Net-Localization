using LocalizationResources.Models;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Localization;
using System.Globalization;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
//Localization resource path
builder.Services.AddLocalization(options => options.ResourcesPath = "Recources");
builder.Services.AddControllersWithViews()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();
//connected to database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped<ICarRepository, CarRepository>(provider => new CarRepository(connectionString));
builder.Services.AddScoped<IViewLocalizer, ViewLocalizer>();


builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en"),
        new CultureInfo("uz"),
        new CultureInfo("ru")
    };

    options.DefaultRequestCulture = new RequestCulture("uz");
    options.SupportedUICultures = supportedCultures;
});


var app = builder.Build();
app.UseStaticFiles();
app.UseRequestLocalization();
app.UseMvcWithDefaultRoute();
app.Run();
