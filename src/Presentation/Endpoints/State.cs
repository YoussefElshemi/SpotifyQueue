using Core.Interfaces.Services;
using FastEndpoints;
using Presentation.Mappers;
using Presentation.Models;

namespace Presentation.Endpoints;

public class State(
    ISpotifyService spotifyService) : EndpointWithoutRequest<StateResponseDto>
{
    public override void Configure()
    {
        Get("/player");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var stateResponse = await spotifyService.GetStateAsync();

        var stateResponseDto = StateResponseDtoMapper.Map(stateResponse);

        await SendAsync(stateResponseDto, cancellation: ct);
    }
}