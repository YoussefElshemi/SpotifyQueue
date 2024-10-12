using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Web;
using Core.Configs;
using Core.Interfaces.Services;
using Core.Services;
using FastEndpoints;
using FastEndpoints.Swagger;
using Infrastructure.Services;
using Presentation.BackgroundServices;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration.AddEnvironmentVariables().Build();
builder.Services.AddSingleton<IConfiguration>(config);
builder.Services.AddOptions<AppConfig>().BindConfiguration(nameof(AppConfig));

var appConfig = new AppConfig();
config.GetSection(nameof(AppConfig)).Bind(appConfig);

builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMemoryCache();
builder.Services.AddHostedService<AccessTokenRotatorService>();
builder.Services.AddHttpClient<ISpotifyClient, SpotifyClient>();
builder.Services.AddScoped<ISpotifyService, SpotifyService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseFastEndpoints();
app.UseSwaggerGen();

var query = HttpUtility.ParseQueryString(string.Empty);
query.Add("response_type", "code");
query.Add("client_id", appConfig.SpotifyAuthConfig.ClientId);
query.Add("scope", appConfig.SpotifyAuthConfig.Scope);
query.Add("redirect_uri", appConfig.SpotifyAuthConfig.RedirectUri);
OpenUrl($"{appConfig.SpotifyAuthConfig.BaseUrl}{appConfig.SpotifyAuthConfig.AuthorizePath}?{query}");

app.Run();

void OpenUrl(string url)
{
    try
    {
        Process.Start(url);
    }
    catch
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            Process.Start("xdg-open", url);
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            Process.Start("open", url);
        }
        else
        {
            throw;
        }
    }
}