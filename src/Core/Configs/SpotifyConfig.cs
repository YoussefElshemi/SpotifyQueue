namespace Core.Configs;

public record SpotifyConfig
{
    public string DeviceWhitelist { get; init; } = null!;
    public string BaseUrl { get; init; } = null!;
    public string SearchPath { get; init; } = null!;
    public string DevicesPath { get; init; } = null!;
    public string QueuePath { get; init; } = null!;
    public string NextTrackPath { get; init; } = null!;
    public string PreviousTrackPath { get; init; } = null!;
    public string PlayPath { get; init; } = null!;
    public string PausePath { get; init; } = null!;
    public string StatePath { get; init; } = null!;
}