using Core.Interfaces.Services;
using FastEndpoints;
using Presentation.Mappers;
using Presentation.Models;

namespace Presentation.Endpoints;

public class Devices(
    ISpotifyService spotifyService) : EndpointWithoutRequest<DevicesResponseDto>
{
    public override void Configure()
    {
        Get("/devices");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var devicesResponse = await spotifyService.GetDevicesAsync();

        var devicesResponseDto = DevicesResponseDtoMapper.Map(devicesResponse);

        await SendAsync(devicesResponseDto, cancellation: ct);
    }
}