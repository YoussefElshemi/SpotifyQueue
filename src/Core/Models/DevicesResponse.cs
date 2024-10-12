namespace Core.Models;

public record DevicesResponse
{
    public required List<Device> Devices { get; init; } = [];
}