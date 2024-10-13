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
        Get("/search");
        Options(x => x.CacheOutput(p => p.Expire(TimeSpan.FromSeconds(300))));
        AllowAnonymous();
    }

    public override async Task HandleAsync(SearchRequestDto searchRequestDto, CancellationToken ct)
    {
        var searchRequest = SearchRequestDtoMapper.Map(searchRequestDto);

        var searchResponse = await spotifyService.SearchAsync(searchRequest);

        var searchResponseDto = SearchResponseDtoMapper.Map(searchResponse);

        await SendAsync(searchResponseDto, cancellation: ct);
    }
}