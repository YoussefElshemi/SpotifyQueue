using Core.Models;
using Core.ValueObjects;

namespace Core.Interfaces.Services;

public interface ISpotifyService
{
    Task AuthenticateAsync(Code code);
    Task RefreshTokenAsync(RefreshToken refreshToken);
    Task<SearchResponse> SearchAsync(SearchRequest searchRequest);
    Task<DevicesResponse> GetDevicesAsync();
    Task<QueueResponse> GetQueueAsync();
    Task AddTrackAsync(TrackUri trackUri);
    Task NextTrackAsync();
    Task PreviousTrackAsync();
    Task PlayAsync();
    Task PauseAsync();
}