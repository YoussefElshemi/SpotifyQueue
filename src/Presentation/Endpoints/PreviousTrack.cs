using Core.Interfaces.Services;
using FastEndpoints;

namespace Presentation.Endpoints;

public class PreviousTrack(
    ISpotifyService spotifyService) : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("/player/previous");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await spotifyService.PreviousTrackAsync();
    }
}