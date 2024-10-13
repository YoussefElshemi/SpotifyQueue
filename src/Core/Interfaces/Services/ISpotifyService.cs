using Core.Models;
using Core.ValueObjects;

namespace Core.Interfaces.Services;

public interface ISpotifyService
{
    Task AuthenticateAsync(Code code);
    Task RefreshTokenAsync(RefreshToken refreshToken);
    Task<DevicesResponse> GetDevicesAsync();
    Task<StateResponse?> GetStateAsync();
    Task<SearchResponse> SearchAsync(SearchRequest searchRequest);
    Task<QueueResponse?> GetQueueAsync();
    Task AddTrackAsync(TrackUri trackUri);
    Task NextTrackAsync();
    Task PreviousTrackAsync();
    Task PlayTrackAsync(TrackUri trackUri);
    Task PlayAsync();
    Task PauseAsync();
    Task ShuffleAsync(ShuffleState shuffleState);
    Task RepeatAsync(RepeatState repeatState);
    Task SetVolumeAsync(VolumePercent volumePercent);
    Task SeekAsync(ProgressMs progressMs);
}