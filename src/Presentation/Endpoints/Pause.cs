using Core.Interfaces.Services;
using Core.ValueObjects;
using FastEndpoints;
using Presentation.Models;

namespace Presentation.Endpoints;

public class Pause(
    ISpotifyService spotifyService) : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("/player/pause");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await spotifyService.PauseAsync();
    }
}