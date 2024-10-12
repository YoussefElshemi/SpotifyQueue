using Core.Models;
using Core.ValueObjects;

namespace Core.Interfaces.Services;

public interface ISpotifyClient
{
    Task<AuthenticationResponse> AuthenticateAsync(Code code);
    Task<RefreshTokenResponse> RefreshTokenAsync(RefreshToken refreshToken);
    Task<SearchResponse> SearchAsync(SearchRequest searchRequest, AccessToken accessToken);
    Task<DevicesResponse> GetDevicesAsync(AccessToken accessToken);
    Task<QueueResponse> GetQueueAsync(AccessToken accessToken);
    Task AddTrackAsync(TrackUri trackUri, AccessToken accessToken);
    Task NextTrackAsync(AccessToken accessToken);
    Task PreviousTrackAsync(AccessToken accessToken);
    Task PlayTrackAsync(TrackUri trackUri, AccessToken accessToken);
    Task PlayAsync(AccessToken accessToken);
    Task PauseAsync(AccessToken accessToken);
    Task<StateResponse> GetStateAsync(AccessToken accessToken);
    Task ShuffleAsync(ShuffleState shuffleState, AccessToken accessToken);
    Task RepeatAsync(RepeatState repeatState, AccessToken accessToken);
}