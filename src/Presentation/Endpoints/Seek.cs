using Core.Interfaces.Services;
using Core.ValueObjects;
using FastEndpoints;
using Presentation.Models;

namespace Presentation.Endpoints;

public class Seek(
    ISpotifyService spotifyService) : Endpoint<SeekRequestDto>
{
    public override void Configure()
    {
        Post("/player/seek");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SeekRequestDto seekRequestDto, CancellationToken ct)
    {
        await spotifyService.SeekAsync(new ProgressMs(seekRequestDto.ProgressMs));
    }
}