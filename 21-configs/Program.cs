/*
Multiple environments

appsettings.json holds default values, inherited and possibly overwritten by config
files of the form appsettings.<environment>.json.

Related environment variables:
    DOTNET_ENVIRONMENT
    ASPNETCORE_ENVIRONMENT

Properties/launchSettings.json
    Settings in this development-only configuration file override the system's variables

Changing the value of ASPNETCORE_ENVIRONMENT in launchSettings.json determines which
appsettings configuration is used.

Source:
    https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments?view=aspnetcore-6.0

Andre Zunino <neyzunino@gmail.com>
20 May 2022
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (IConfiguration configuration) =>
{
    var title = configuration["ApplicationTitle"];
    var description = configuration["ApplicationDescription"];

    return $"Title: {title}\nDescription: {description}";
});

app.Run();
