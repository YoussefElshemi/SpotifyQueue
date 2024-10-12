using System.Security.Authentication;
using Core.Configs;
using Core.Interfaces.Services;
using Core.Models;
using Core.ValueObjects;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Core.Services;

public class SpotifyService(
    ISpotifyClient spotifyClient,
    IMemoryCache memoryCache,
    IOptions<AppConfig> config) : ISpotifyService
{
    public async Task AuthenticateAsync(Code code)
    {
        var authenticationResponse = await spotifyClient.AuthenticateAsync(code);
        CacheTokens(authenticationResponse);
    }

    public async Task RefreshTokenAsync(RefreshToken refreshToken)
    {
        var refreshTokenResponse = await spotifyClient.RefreshTokenAsync(refreshToken);
        CacheTokens(refreshTokenResponse);
    }

    public async Task<SearchResponse> SearchAsync(SearchRequest searchRequest)
    {
        var accessToken = await GetAccessTokenAsync();
        var searchResponse = await spotifyClient.SearchAsync(searchRequest, accessToken);

        return searchResponse;
    }

    public async Task<DevicesResponse> GetDevicesAsync()
    {
        var accessToken = await GetAccessTokenAsync();
        var devicesResponse = await spotifyClient.GetDevicesAsync(accessToken);

        return devicesResponse;
    }

    public async Task<QueueResponse> GetQueueAsync()
    {
        var accessToken = await GetAccessTokenAsync();
        var queueResponse = await spotifyClient.GetQueueAsync(accessToken);

        return queueResponse;
    }

    public async Task AddTrackAsync(TrackUri trackUri)
    {
        var accessToken = await GetAccessTokenAsync();

        if (string.IsNullOrWhiteSpace(config.Value.SpotifyConfig.DeviceWhitelist))
        {
            await spotifyClient.AddTrackAsync(trackUri, accessToken);
            return;
        }

        var devicesResponse = await spotifyClient.GetDevicesAsync(accessToken);
        var activeDevice = devicesResponse.Devices.FirstOrDefault(x => x.IsActive);

        if (activeDevice == null)
        {
            throw new InvalidOperationException("No active device found.");
        }

        if (activeDevice.Name == config.Value.SpotifyConfig.DeviceWhitelist)
        {
            await spotifyClient.AddTrackAsync(trackUri, accessToken);
            return;
        }

        throw new UnauthorizedAccessException($"Active device '{activeDevice.Name}' is not whitelisted.");
    }

    public async Task NextTrackAsync()
    {
        var accessToken = await GetAccessTokenAsync();
        await spotifyClient.NextTrackAsync(accessToken);
    }

    public async Task PreviousTrackAsync()
    {
        var accessToken = await GetAccessTokenAsync();
        await spotifyClient.PreviousTrackAsync(accessToken);
    }

    public async Task PlayAsync()
    {
        var accessToken = await GetAccessTokenAsync();
        await spotifyClient.PlayAsync(accessToken);
    }

    public async Task PauseAsync()
    {
        var accessToken = await GetAccessTokenAsync();
        await spotifyClient.PauseAsync(accessToken);
    }


    private async Task<AccessToken> GetAccessTokenAsync()
    {
        if (memoryCache.TryGetValue("AccessToken", out AccessToken accessToken))
        {
            return accessToken;
        }

        if (memoryCache.TryGetValue("RefreshToken", out RefreshToken refreshToken))
        {
            var authenticationResponse = await spotifyClient.RefreshTokenAsync(refreshToken);
            CacheTokens(authenticationResponse);

            return authenticationResponse.AccessToken;
        }

        throw new AuthenticationException();
    }

    private void CacheTokens(AuthenticationResponse authenticationResponse)
    {
        memoryCache.Set("AccessToken", authenticationResponse.AccessToken,
            DateTimeOffset.UtcNow.AddSeconds(authenticationResponse.ExpiresIn));
        memoryCache.Set("RefreshToken", authenticationResponse.RefreshToken);
    }

    private void CacheTokens(RefreshTokenResponse refreshTokenResponse)
    {
        memoryCache.Set("AccessToken", refreshTokenResponse.AccessToken,
            DateTimeOffset.UtcNow.AddSeconds(refreshTokenResponse.ExpiresIn));
    }
}