using Core.Interfaces.Services;
using FastEndpoints;

namespace Presentation.Endpoints;

public class NextTrack(
    ISpotifyService spotifyService) : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("/player/next");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await spotifyService.NextTrackAsync();
    }
}