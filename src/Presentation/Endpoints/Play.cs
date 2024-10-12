using Core.Interfaces.Services;
using Core.ValueObjects;
using FastEndpoints;
using Presentation.Models;

namespace Presentation.Endpoints;

public class Play(
    ISpotifyService spotifyService) : Endpoint<PlayRequestDto>
{
    public override void Configure()
    {
        Post("/player/play");
        AllowAnonymous();
    }

    public override async Task HandleAsync(PlayRequestDto playRequestDto, CancellationToken ct)
    {
        if (playRequestDto.TrackUri is not null)
        {
            await spotifyService.PlayTrackAsync(new TrackUri(playRequestDto.TrackUri));
        }
        else
        {
            await spotifyService.PlayAsync();
        }
    }
}