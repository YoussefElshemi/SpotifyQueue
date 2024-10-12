using Core.Interfaces.Services;
using Core.ValueObjects;
using FastEndpoints;
using Presentation.Models;

namespace Presentation.Endpoints;

public class Repeat(
    ISpotifyService spotifyService) : Endpoint<RepeatRequestDto>
{
    public override void Configure()
    {
        Post("/player/repeat");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RepeatRequestDto playRequestDto, CancellationToken ct)
    {
        await spotifyService.RepeatAsync(new RepeatState(playRequestDto.State));
    }
}