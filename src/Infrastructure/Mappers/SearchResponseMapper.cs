using Core.Models;
using Core.ValueObjects;
using Infrastructure.Models;

namespace Infrastructure.Mappers;

public class SearchResponseMapper
{
    public static SearchResponse Map(SearchResponseDto searchResponseDto)
    {
        return new SearchResponse
        {
            Offset = new Offset(searchResponseDto.Tracks.Offset),
            Limit = new Limit(searchResponseDto.Tracks.Limit),
            Total = new Total(searchResponseDto.Tracks.Total),
            Items = searchResponseDto.Tracks.Items.Select(ItemMapper.Map).ToList()
        };
    }
}