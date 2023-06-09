using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
//added MVC
builder.Services.AddMvc(o => o.EnableEndpointRouting = false);
// Add in the service Localization
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("uz-UZ"),
        new CultureInfo("en-US"),

        new CultureInfo("ru-RU")
};
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
});
builder.Services.AddControllersWithViews()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();

var app = builder.Build();
app.UseStaticFiles();
app.UseRequestLocalization();
app.UseMvcWithDefaultRoute();
app.MapGet("/", () => "Hello World!");

app.Run();




