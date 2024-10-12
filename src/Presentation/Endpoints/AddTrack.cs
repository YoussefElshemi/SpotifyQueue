using Core.Interfaces.Services;
using Core.ValueObjects;
using FastEndpoints;
using Presentation.Models;

namespace Presentation.Endpoints;

public class AddTrack(
    ISpotifyService spotifyService) : Endpoint<AddTrackRequestDto>
{
    public override void Configure()
    {
        Put("/queue");
        AllowAnonymous();
    }

    public override async Task HandleAsync(AddTrackRequestDto addTrackRequestDto, CancellationToken ct)
    {
        await spotifyService.AddTrackAsync(new TrackUri(addTrackRequestDto.TrackUri));
    }
}