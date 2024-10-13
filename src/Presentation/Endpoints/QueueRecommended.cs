using Core.Interfaces.Services;
using Core.ValueObjects;
using FastEndpoints;
using Presentation.Models;

namespace Presentation.Endpoints;

public class QueueRecommended(
    ISpotifyService spotifyService) : Endpoint<QueueRecommendedRequestDto>
{
    public override void Configure()
    {
        Post("/queue/recommended");
        AllowAnonymous();
    }

    public override async Task HandleAsync(QueueRecommendedRequestDto queueRecommendedRequestDto, CancellationToken ct)
    {
        await spotifyService.QueueRecommendedAsync(new ItemId(queueRecommendedRequestDto.ItemId));
    }
}