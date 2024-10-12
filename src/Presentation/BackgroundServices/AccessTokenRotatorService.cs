using Core.Interfaces.Services;
using Core.ValueObjects;
using Microsoft.Extensions.Caching.Memory;

namespace Presentation.BackgroundServices;

public class AccessTokenRotatorService(
    IServiceScopeFactory scopeFactory) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = scopeFactory.CreateScope();
                var spotifyService = scope.ServiceProvider.GetRequiredService<ISpotifyService>();
                var memoryCache = scope.ServiceProvider.GetRequiredService<IMemoryCache>();

                if (memoryCache.TryGetValue("AccessToken", out _)) continue;
                if (memoryCache.TryGetValue("RefreshToken", out RefreshToken refreshToken))
                {
                    await spotifyService.RefreshTokenAsync(refreshToken);
                }
            }
            finally
            {
                await Task.Delay(100, stoppingToken);
            }
        }
    }
}