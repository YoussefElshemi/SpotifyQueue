﻿using Core.Interfaces.Services;
using FastEndpoints;
using Presentation.Mappers;
using Presentation.Models;

namespace Presentation.Endpoints;

public class Recommendations(
    ISpotifyService spotifyService) : Endpoint<RecommendationsRequestDto, RecommendationsResponseDto>
{
    public override void Configure()
    {
        Get("/recommendations");
        Options(x => x.CacheOutput(p => p.Expire(TimeSpan.FromSeconds(300))));
        AllowAnonymous();
    }

    public override async Task HandleAsync(RecommendationsRequestDto recommendationsRequestDto, CancellationToken ct)
    {
        var recommendationsRequest = RecommendationsRequestMapper.Map(recommendationsRequestDto);

        var recommendationsResponse = await spotifyService.GetRecommendationsAsync(recommendationsRequest);

        var recommendationsResponseDto = RecommendationsResponseDtoMapper.Map(recommendationsResponse);

        await SendAsync(recommendationsResponseDto, cancellation: ct);
    }
}