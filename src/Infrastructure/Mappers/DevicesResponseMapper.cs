using Core.Models;
using Core.ValueObjects;
using Infrastructure.Models;

namespace Infrastructure.Mappers;

public static class DevicesResponseMapper
{
    public static DevicesResponse Map(DevicesResponseDto devicesResponseDto)
    {
        return new DevicesResponse
        {
            Devices = devicesResponseDto.Devices.Select(device => new Device
            {
                Id = new DeviceId(device.Id),
                IsActive = new IsActive(device.IsActive),
                IsPrivateSession = new IsPrivateSession(device.IsPrivateSession),
                IsRestricted = new IsRestricted(device.IsRestricted),
                Name = new DeviceName(device.Name),
                Type = new DeviceType(device.Type),
                VolumePercent = new VolumePercent(device.VolumePercent),
                SupportsVolume = new SupportsVolume(device.SupportsVolume)
            }).ToList()
        };
    }
}