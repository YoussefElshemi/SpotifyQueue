namespace Presentation.Models;

public record DevicesResponseDto
{
    public required DeviceDto[] Devices { get; init; } = [];
}