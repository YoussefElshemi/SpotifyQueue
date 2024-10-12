using Core.Models;
using Infrastructure.Models;

namespace Infrastructure.Mappers;

public static class DevicesResponseMapper
{
    public static DevicesResponse Map(DevicesResponseDto devicesResponseDto)
    {
        return new DevicesResponse
        {
            Devices = devicesResponseDto.Devices.Select(DeviceMapper.Map).ToList()
        };
    }
}