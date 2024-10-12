using Core.ValueObjects;

namespace Core.Models;

public record Device
{
    public required DeviceId Id { get; init; }
    public required IsActive IsActive { get; init; }
    public required IsPrivateSession IsPrivateSession { get; init; }
    public required IsRestricted IsRestricted { get; init; }
    public required DeviceName Name { get; init; }
    public required DeviceType Type { get; init; }
    public required VolumePercent VolumePercent { get; init; }
    public required SupportsVolume SupportsVolume { get; init; }
}