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

    public async Task<DevicesResponse> GetDevicesAsync()
    {
        var accessToken = await GetAccessTokenAsync();
        var devicesResponse = await spotifyClient.GetDevicesAsync(accessToken);

        return devicesResponse;
    }

    public async Task<SearchResponse> SearchAsync(SearchRequest searchRequest)
    {
        var accessToken = await GetAccessTokenAsync();
        var searchResponse = await spotifyClient.SearchAsync(searchRequest, accessToken);

        return searchResponse;
    }

    public async Task<QueueResponse?> GetQueueAsync()
    {
        var accessToken = await GetAccessTokenAsync();
        if (await CheckDeviceWhitelistAsync(accessToken))
        {
            var queueResponse = await spotifyClient.GetQueueAsync(accessToken);
            return queueResponse;
        }

        return null;
    }

    public async Task AddTrackAsync(TrackUri trackUri)
    {
        var accessToken = await GetAccessTokenAsync();
        if (await CheckDeviceWhitelistAsync(accessToken))
        {
            await spotifyClient.AddTrackAsync(trackUri, accessToken);
        }
    }

    public async Task NextTrackAsync()
    {
        var accessToken = await GetAccessTokenAsync();
        if (await CheckDeviceWhitelistAsync(accessToken))
        {
            await spotifyClient.NextTrackAsync(accessToken);
        }
    }

    public async Task PreviousTrackAsync()
    {
        var accessToken = await GetAccessTokenAsync();
        if (await CheckDeviceWhitelistAsync(accessToken))
        {
            await spotifyClient.PreviousTrackAsync(accessToken);
        }
    }

    public async Task PlayTrackAsync(TrackUri trackUri)
    {
        var accessToken = await GetAccessTokenAsync();
        if (await CheckDeviceWhitelistAsync(accessToken))
        {
            await spotifyClient.PlayTrackAsync(trackUri, accessToken);
        }
    }

    public async Task PlayAsync()
    {
        var accessToken = await GetAccessTokenAsync();
        if (await CheckDeviceWhitelistAsync(accessToken))
        {
            await spotifyClient.PlayAsync(accessToken);
        }
    }

    public async Task PauseAsync()
    {
        var accessToken = await GetAccessTokenAsync();
        if (await CheckDeviceWhitelistAsync(accessToken))
        {
            await spotifyClient.PauseAsync(accessToken);
        }
    }

    public async Task<StateResponse?> GetStateAsync()
    {
        var accessToken = await GetAccessTokenAsync();
        if (await CheckDeviceWhitelistAsync(accessToken))
        {
            var stateResponse =  await spotifyClient.GetStateAsync(accessToken);
            return stateResponse;
        }

        return null;
    }

    public async Task ShuffleAsync(ShuffleState shuffleState)
    {
        var accessToken = await GetAccessTokenAsync();
        if (await CheckDeviceWhitelistAsync(accessToken))
        {
            await spotifyClient.ShuffleAsync(shuffleState, accessToken);
        }
    }

    public async Task RepeatAsync(RepeatState repeatState)
    {
        var accessToken = await GetAccessTokenAsync();
        if (await CheckDeviceWhitelistAsync(accessToken))
        {
            await spotifyClient.RepeatAsync(repeatState, accessToken);
        }
    }

    public async Task SetVolumeAsync(VolumePercent volumePercent)
    {
        var accessToken = await GetAccessTokenAsync();
        if (await CheckDeviceWhitelistAsync(accessToken))
        {
            await spotifyClient.SetVolumeAsync(volumePercent, accessToken);
        }
    }

    public async Task SeekAsync(ProgressMs progressMs)
    {
        var accessToken = await GetAccessTokenAsync();
        if (await CheckDeviceWhitelistAsync(accessToken))
        {
            await spotifyClient.SeekAsync(progressMs, accessToken);
        }
    }

    public async Task<RecommendationsResponse> GetRecommendationsAsync(RecommendationsRequest recommendationsRequest)
    {
        var accessToken = await GetAccessTokenAsync();
        var recommendationsResponse = await spotifyClient.GetRecommendationsAsync(recommendationsRequest, accessToken);

        return recommendationsResponse;
    }

    public async Task QueueRecommendedAsync(RecommendationsRequest recommendationsRequest)
    {
        var accessToken = await GetAccessTokenAsync();
        if (await CheckDeviceWhitelistAsync(accessToken))
        {
            var recommendationResponse = await spotifyClient.GetRecommendationsAsync(recommendationsRequest, accessToken);
            List<Task> tasks = [];

            foreach (var recommendation in recommendationResponse.Items)
            {
                var task = spotifyClient.AddTrackAsync(new TrackUri(recommendation.Uri), accessToken);
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);
        }
    }

    public async Task TransferPlaybackAsync(DeviceId deviceId)
    {
        var accessToken = await GetAccessTokenAsync();
        await spotifyClient.TransferPlaybackAsync(deviceId, accessToken);
    }

    private async Task<bool> CheckDeviceWhitelistAsync(AccessToken accessToken)
    {
        var devicesResponse = await spotifyClient.GetDevicesAsync(accessToken);
        var activeDevice = devicesResponse.Devices.FirstOrDefault(x => x.IsActive);

        if (string.IsNullOrWhiteSpace(config.Value.SpotifyConfig.DeviceWhitelist))
        {
            if (activeDevice is not null)
            {
                return true;
            }

            var device = devicesResponse.Devices.FirstOrDefault();
            if (device is null)
            {
                return false;
            }

            await TransferPlaybackAsync(device.Id);
            return true;
        }

        var whitelistedDevice = devicesResponse.Devices.FirstOrDefault(x => x.Name == config.Value.SpotifyConfig.DeviceWhitelist);
        if (whitelistedDevice is null)
        {
            return false;
        }

        if (whitelistedDevice.IsActive)
        {
            return true;
        }

        if (activeDevice is null)
        {
            await TransferPlaybackAsync(whitelistedDevice.Id);
            return true;
        }

        return false;
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