using Core.Models;
using Presentation.Models;

namespace Presentation.Mappers;

public static class ItemDtoMapper
{
    public static ItemDto Map(Item item)
    {
        return new ItemDto
        {
            Id = item.Id,
            Album = AlbumDtoMapper.Map(item.Album),
            Artists = item.Artists.Select(ArtistDtoMapper.Map).ToList(),
            DurationMs = item.DurationMs,
            Href = item.Href.ToString(),
            Name = item.Name,
            ExternalUrl = item.ExternalUrl.ToString(),
            PreviewUrl = item.PreviewUrl?.ToString(),
            Uri = item.Uri.ToString(),
            Images = item.Images.Select(ImageDtoMapper.Map).ToList()
        };
    }
}