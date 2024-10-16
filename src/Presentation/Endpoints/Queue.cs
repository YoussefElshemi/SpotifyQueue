﻿using Core.Interfaces.Services;
using FastEndpoints;
using Presentation.Mappers;
using Presentation.Models;

namespace Presentation.Endpoints;

public class Queue(
    ISpotifyService spotifyService) : EndpointWithoutRequest<QueueResponseDto>
{
    public override void Configure()
    {
        Get("/queue");
        Options(x => x.CacheOutput(p => p.Expire(TimeSpan.FromMilliseconds(500))));
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var queueResponse = await spotifyService.GetQueueAsync();

        var queueResponseDto = QueueResponseDtoMapper.Map(queueResponse!);

        await SendAsync(queueResponseDto, cancellation: ct);
    }
}