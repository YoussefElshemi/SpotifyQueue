using System.Text.Json.Serialization;

namespace Infrastructure.Models;

public record DeviceDto
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("is_active")]
    public required bool IsActive { get; init; }

    [JsonPropertyName("is_private_session")]
    public required bool IsPrivateSession { get; init; }

    [JsonPropertyName("is_restricted")]
    public required bool IsRestricted { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("type")]
    public required string Type { get; init; }

    [JsonPropertyName("volume_percent")]
    public required int VolumePercent { get; init; }

    [JsonPropertyName("supports_volume")]
    public required bool SupportsVolume { get; init; }
}