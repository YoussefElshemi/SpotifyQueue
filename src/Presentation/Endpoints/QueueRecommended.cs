using Core.Interfaces.Services;
using Core.ValueObjects;
using FastEndpoints;
using Presentation.Mappers;
using Presentation.Models;

namespace Presentation.Endpoints;

public class QueueRecommended(
    ISpotifyService spotifyService) : Endpoint<RecommendationsRequestDto>
{
    public override void Configure()
    {
        Post("/queue/recommended");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RecommendationsRequestDto recommendationsRequestDto, CancellationToken ct)
    {
        var recommendationsRequest = RecommendationsRequestMapper.Map(recommendationsRequestDto);
        await spotifyService.QueueRecommendedAsync(recommendationsRequest);
    }
}