using Core.Interfaces.Services;
using Core.ValueObjects;
using FastEndpoints;
using Presentation.Models;

namespace Presentation.Endpoints;

public class Volume(
    ISpotifyService spotifyService) : Endpoint<VolumeRequestDto>
{
    public override void Configure()
    {
        Post("/player/volume");
        AllowAnonymous();
    }

    public override async Task HandleAsync(VolumeRequestDto volumeRequestDto, CancellationToken ct)
    {
        await spotifyService.SetVolumeAsync(new VolumePercent(volumeRequestDto.Volume));
    }
}