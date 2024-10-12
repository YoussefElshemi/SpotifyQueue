using Core.Interfaces.Services;
using Core.ValueObjects;
using FastEndpoints;
using Presentation.Models;

namespace Presentation.Endpoints;

public class Shuffle(
    ISpotifyService spotifyService) : Endpoint<ShuffleRequestDto>
{
    public override void Configure()
    {
        Post("/player/shuffle");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ShuffleRequestDto playRequestDto, CancellationToken ct)
    {
        await spotifyService.ShuffleAsync(new ShuffleState(playRequestDto.State));
    }
}