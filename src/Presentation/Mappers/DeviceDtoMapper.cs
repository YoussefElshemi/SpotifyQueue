using Core.Models;
using Presentation.Models;

namespace Presentation.Mappers;

public static class DeviceDtoMapper
{
    public static DeviceDto Map(Device device)
    {
        return new DeviceDto
        {
            Id = device.Id,
            IsActive = device.IsActive,
            IsPrivateSession = device.IsPrivateSession,
            IsRestricted = device.IsRestricted,
            Name = device.Name,
            Type = device.Type,
            VolumePercent = device.VolumePercent,
            SupportsVolume = device.SupportsVolume
        };
    }
}