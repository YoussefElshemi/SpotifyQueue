using Core.Enums;
using Core.Models;
using Core.ValueObjects;
using Presentation.Models;

namespace Presentation.Mappers;

public static class SearchRequestDtoMapper
{
    public static SearchRequest Map(SearchRequestDto searchRequestDto)
    {
        return new SearchRequest
        {
            SearchQuery = new SearchQuery(searchRequestDto.SearchQuery),
            Types = [SearchType.Track],
            Limit = searchRequestDto.Limit.HasValue ? new Limit(searchRequestDto.Limit.Value) : null,
            Offset = searchRequestDto.Offset.HasValue ? new Offset(searchRequestDto.Offset.Value) : null
        };
    }
}