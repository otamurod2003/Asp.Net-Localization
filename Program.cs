using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
//added MVC
builder.Services.AddMvc(o => o.EnableEndpointRouting = false);

// Add in the service Localization
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources" );
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("uz-UZ"),
        new CultureInfo("ru-RU")
};
    options.DefaultRequestCulture = new RequestCulture("uz-UZ");
    options.SupportedCultures = supportedCultures;
});
builder.Services.AddControllersWithViews()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();

var app = builder.Build();
app.UseFileServer();
app.UseRequestLocalization();
app.UseMvcWithDefaultRoute();
app.MapGet("/", () => "Hello World!");

app.Run();




