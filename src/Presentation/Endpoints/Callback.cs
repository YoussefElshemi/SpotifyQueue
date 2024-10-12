using Core.Interfaces.Services;
using Core.ValueObjects;
using FastEndpoints;

namespace Presentation.Endpoints;

public class Callback(
    ISpotifyService spotifyService) : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/callback");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var code = Query<string>("code")!;
        await spotifyService.AuthenticateAsync(new Code(code));

        await SendOkAsync(ct);
    }
}
