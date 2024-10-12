namespace Presentation.Models;

public record DeviceDto
{
    public required string Id { get; init; }
    public required bool IsActive { get; init; }
    public required bool IsPrivateSession { get; init; }
    public required bool IsRestricted { get; init; }
    public required string Name { get; init; }
    public required string Type { get; init; }
    public required int VolumePercent { get; init; }
    public required bool SupportsVolume { get; init; }
}