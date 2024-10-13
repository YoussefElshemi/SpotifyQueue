using System.Net.Http.Headers;
using System.Text.Json;
using System.Web;
using Core.Configs;
using Core.Interfaces.Services;
using Core.Models;
using Core.ValueObjects;
using Infrastructure.Mappers;
using Infrastructure.Models;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services;

public class SpotifyClient(
    HttpClient client,
    IOptions<AppConfig> config) : ISpotifyClient
{
    public async Task<AuthenticationResponse> AuthenticateAsync(Code code)
    {
        var url = $"{config.Value.SpotifyAuthConfig.BaseUrl}{config.Value.SpotifyAuthConfig.AuthenticationPath}";
        var requestData = new Dictionary<string, string>
        {
            { "grant_type", "authorization_code" },
            { "code", code },
            { "redirect_uri", config.Value.SpotifyAuthConfig.RedirectUri }
        };

        var authenticationString = $"{config.Value.SpotifyAuthConfig.ClientId}:{config.Value.SpotifyAuthConfig.ClientSecret}";
        var token = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authenticationString));

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(url),
            Content = new FormUrlEncodedContent(requestData),
            Headers =
            {
                Authorization = new AuthenticationHeaderValue("Basic", token)
            }
        };

        var response = await client.SendAsync(request);
        var content  = await response.Content.ReadAsStringAsync();
        var authenticationResponseDto = JsonSerializer.Deserialize<AuthenticationResponseDto>(content)!;

        return AuthenticationResponseMapper.Map(authenticationResponseDto);
    }

    public async Task<RefreshTokenResponse> RefreshTokenAsync(RefreshToken refreshToken)
    {
        var url = $"{config.Value.SpotifyAuthConfig.BaseUrl}{config.Value.SpotifyAuthConfig.AuthenticationPath}";
        var requestData = new Dictionary<string, string>
        {
            { "grant_type", "refresh_token" },
            { "refresh_token", refreshToken},
            { "client_id", config.Value.SpotifyAuthConfig.ClientId }
        };

        var authenticationString = $"{config.Value.SpotifyAuthConfig.ClientId}:{config.Value.SpotifyAuthConfig.ClientSecret}";
        var token = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authenticationString));

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(url),
            Content = new FormUrlEncodedContent(requestData),
            Headers =
            {
                Authorization = new AuthenticationHeaderValue("Basic", token)
            }
        };

        var response = await client.SendAsync(request);
        var content  = await response.Content.ReadAsStringAsync();
        var refreshTokenResponseDto = JsonSerializer.Deserialize<RefreshTokenResponseDto>(content)!;

        return RefreshTokenResponseMapper.Map(refreshTokenResponseDto);
    }

    public async Task<SearchResponse> SearchAsync(SearchRequest searchRequest, AccessToken accessToken)
    {
        var url = $"{config.Value.SpotifyConfig.BaseUrl}{config.Value.SpotifyConfig.SearchPath}";
        var query = HttpUtility.ParseQueryString(string.Empty);
        query.Add("q", searchRequest.SearchQuery);
        query.Add("type", string.Join(',', searchRequest.Types).ToLower());

        if (searchRequest.Limit.HasValue)
        {
            query.Add("limit", searchRequest.Limit.Value.ToString());
        }

        if (searchRequest.Offset.HasValue)
        {
            query.Add("offset", searchRequest.Offset.Value.ToString());
        }

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"{url}?{query}"),
            Headers =
            {
                Authorization = new AuthenticationHeaderValue("Bearer", accessToken)
            }
        };

        var response = await client.SendAsync(request);
        var content  = await response.Content.ReadAsStringAsync();
        var searchResponseDto = JsonSerializer.Deserialize<SearchResponseDto>(content)!;

        return SearchResponseMapper.Map(searchResponseDto);
    }

    public async Task<DevicesResponse> GetDevicesAsync(AccessToken accessToken)
    {
        var url = $"{config.Value.SpotifyConfig.BaseUrl}{config.Value.SpotifyConfig.DevicesPath}";
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url),
            Headers =
            {
                Authorization = new AuthenticationHeaderValue("Bearer", accessToken)
            }
        };

        var response = await client.SendAsync(request);
        var content  = await response.Content.ReadAsStringAsync();
        var devicesResponseDto = JsonSerializer.Deserialize<DevicesResponseDto>(content)!;

        return DevicesResponseMapper.Map(devicesResponseDto);
    }

    public async Task<QueueResponse> GetQueueAsync(AccessToken accessToken)
    {
        var url = $"{config.Value.SpotifyConfig.BaseUrl}{config.Value.SpotifyConfig.QueuePath}";
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url),
            Headers =
            {
                Authorization = new AuthenticationHeaderValue("Bearer", accessToken)
            }
        };

        var response = await client.SendAsync(request);
        var content  = await response.Content.ReadAsStringAsync();
        var queueResponseDto = JsonSerializer.Deserialize<QueueResponseDto>(content)!;

        return QueueResponseMapper.Map(queueResponseDto);
    }

    public async Task AddTrackAsync(TrackUri trackUri, AccessToken accessToken)
    {
        var url = $"{config.Value.SpotifyConfig.BaseUrl}{config.Value.SpotifyConfig.QueuePath}";

        var query = HttpUtility.ParseQueryString(string.Empty);
        query.Add("uri", trackUri);

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri($"{url}?{query}"),
            Headers =
            {
                Authorization = new AuthenticationHeaderValue("Bearer", accessToken)
            }
        };

        await client.SendAsync(request);
    }

    public async Task NextTrackAsync(AccessToken accessToken)
    {
        var url = $"{config.Value.SpotifyConfig.BaseUrl}{config.Value.SpotifyConfig.NextTrackPath}";

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(url),
            Headers =
            {
                Authorization = new AuthenticationHeaderValue("Bearer", accessToken)
            }
        };

        await client.SendAsync(request);
    }

    public async Task PreviousTrackAsync(AccessToken accessToken)
    {
        var url = $"{config.Value.SpotifyConfig.BaseUrl}{config.Value.SpotifyConfig.PreviousTrackPath}";

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(url),
            Headers =
            {
                Authorization = new AuthenticationHeaderValue("Bearer", accessToken)
            }
        };

        await client.SendAsync(request);
    }

    public async Task PlayTrackAsync(TrackUri trackUri, AccessToken accessToken)
    {
        var url = $"{config.Value.SpotifyConfig.BaseUrl}{config.Value.SpotifyConfig.PlayPath}";
        var requestData = new Dictionary<string, string[]>
        {
            { "uris", [trackUri] }
        };

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Put,
            RequestUri = new Uri(url),
            Content = new StringContent(JsonSerializer.Serialize(requestData)),
            Headers =
            {
                Authorization = new AuthenticationHeaderValue("Bearer", accessToken)
            }
        };

        await client.SendAsync(request);
    }

    public async Task PlayAsync(AccessToken accessToken)
    {
        var url = $"{config.Value.SpotifyConfig.BaseUrl}{config.Value.SpotifyConfig.PlayPath}";

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Put,
            RequestUri = new Uri(url),
            Headers =
            {
                Authorization = new AuthenticationHeaderValue("Bearer", accessToken)
            }
        };

        await client.SendAsync(request);
    }

    public async Task PauseAsync(AccessToken accessToken)
    {
        var url = $"{config.Value.SpotifyConfig.BaseUrl}{config.Value.SpotifyConfig.PausePath}";

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Put,
            RequestUri = new Uri(url),
            Headers =
            {
                Authorization = new AuthenticationHeaderValue("Bearer", accessToken)
            }
        };

        await client.SendAsync(request);
    }

    public async Task<StateResponse> GetStateAsync(AccessToken accessToken)
    {
        var url = $"{config.Value.SpotifyConfig.BaseUrl}{config.Value.SpotifyConfig.StatePath}";

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url),
            Headers =
            {
                Authorization = new AuthenticationHeaderValue("Bearer", accessToken)
            }
        };

        var response = await client.SendAsync(request);
        var content  = await response.Content.ReadAsStringAsync();
        var stateResponseDto = JsonSerializer.Deserialize<StateResponseDto>(content)!;

        return StateResponseMapper.Map(stateResponseDto);
    }

    public async Task ShuffleAsync(ShuffleState shuffleState, AccessToken accessToken)
    {
        var url = $"{config.Value.SpotifyConfig.BaseUrl}{config.Value.SpotifyConfig.ShufflePath}";

        var query = HttpUtility.ParseQueryString(string.Empty);
        query.Add("state", shuffleState);

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Put,
            RequestUri = new Uri($"{url}?{query}"),
            Headers =
            {
                Authorization = new AuthenticationHeaderValue("Bearer", accessToken)
            }
        };

        await client.SendAsync(request);
    }

    public async Task RepeatAsync(RepeatState repeatState, AccessToken accessToken)
    {
        var url = $"{config.Value.SpotifyConfig.BaseUrl}{config.Value.SpotifyConfig.RepeatPath}";

        var query = HttpUtility.ParseQueryString(string.Empty);
        query.Add("state", repeatState);

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Put,
            RequestUri = new Uri($"{url}?{query}"),
            Headers =
            {
                Authorization = new AuthenticationHeaderValue("Bearer", accessToken)
            }
        };

        await client.SendAsync(request);
    }

    public async Task SetVolumeAsync(VolumePercent volumePercent, AccessToken accessToken)
    {
        var url = $"{config.Value.SpotifyConfig.BaseUrl}{config.Value.SpotifyConfig.VolumePath}";

        var query = HttpUtility.ParseQueryString(string.Empty);
        query.Add("volume_percent", volumePercent.ToString());

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Put,
            RequestUri = new Uri($"{url}?{query}"),
            Headers =
            {
                Authorization = new AuthenticationHeaderValue("Bearer", accessToken)
            }
        };

        await client.SendAsync(request);
    }

    public async Task SeekAsync(ProgressMs progressMs, AccessToken accessToken)
    {
        var url = $"{config.Value.SpotifyConfig.BaseUrl}{config.Value.SpotifyConfig.SeekPath}";

        var query = HttpUtility.ParseQueryString(string.Empty);
        query.Add("position_ms", progressMs.ToString());

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Put,
            RequestUri = new Uri($"{url}?{query}"),
            Headers =
            {
                Authorization = new AuthenticationHeaderValue("Bearer", accessToken)
            }
        };

        await client.SendAsync(request);
    }

    public async Task<RecommendationsResponse> GetRecommendationsAsync(RecommendationsRequest recommendationsRequest, AccessToken accessToken)
    {
        var url = $"{config.Value.SpotifyConfig.BaseUrl}{config.Value.SpotifyConfig.RecommendationsPath}";

        var query = HttpUtility.ParseQueryString(string.Empty);
        query.Add("seed_tracks", recommendationsRequest.ItemId);
        if (recommendationsRequest.Limit.HasValue)
        {
            query.Add("limit", recommendationsRequest.Limit.Value.ToString());
        }

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"{url}?{query}"),
            Headers =
            {
                Authorization = new AuthenticationHeaderValue("Bearer", accessToken)
            }
        };

        var response = await client.SendAsync(request);
        var content  = await response.Content.ReadAsStringAsync();
        var recommendationsResponseDto = JsonSerializer.Deserialize<RecommendationResponseDto>(content)!;

        return RecommendationResponseMapper.Map(recommendationsResponseDto);
    }

    public async Task TransferPlaybackAsync(DeviceId deviceId, AccessToken accessToken)
    {
        var url = $"{config.Value.SpotifyConfig.BaseUrl}{config.Value.SpotifyConfig.TransferPlaybackPath}";
        var requestData = new Dictionary<string, string[]>
        {
            { "device_ids", [deviceId] }
        };

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Put,
            RequestUri = new Uri(url),
            Content = new StringContent(JsonSerializer.Serialize(requestData)),
            Headers =
            {
                Authorization = new AuthenticationHeaderValue("Bearer", accessToken)
            }
        };

        await client.SendAsync(request);
    }
}