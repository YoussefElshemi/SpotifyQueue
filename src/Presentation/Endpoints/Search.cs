using Core.Interfaces.Services;
using FastEndpoints;
using Presentation.Mappers;
using Presentation.Models;

namespace Presentation.Endpoints;

public class Search(
    ISpotifyService spotifyService) : Endpoint<SearchRequestDto, SearchResponseDto>
{
    public override void Configure()
    {
        Post("/search");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SearchRequestDto searchRequestDto, CancellationToken ct)
    {
        var searchRequest = SearchRequestDtoMapper.Map(searchRequestDto);

        var searchResponse = await spotifyService.SearchAsync(searchRequest);

        var searchResponseDto = SearchResponseDtoMapper.Map(searchResponse!);

        await SendAsync(searchResponseDto, cancellation: ct);
    }
}