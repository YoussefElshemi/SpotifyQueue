using System.Text.Json.Serialization;

namespace Infrastructure.Models;

public record DevicesResponseDto
{
    [JsonPropertyName("devices")]
    public required DeviceDto[] Devices { get; init; } = [];
}