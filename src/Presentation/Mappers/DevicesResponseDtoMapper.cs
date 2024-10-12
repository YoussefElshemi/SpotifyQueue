using Core.Models;
using Presentation.Models;

namespace Presentation.Mappers;

public static class DevicesResponseDtoMapper
{
    public static DevicesResponseDto Map(DevicesResponse devicesResponse)
    {
        return new DevicesResponseDto
        {
            Devices = devicesResponse.Devices.Select(DeviceDtoMapper.Map).ToArray()
        };
    }
}