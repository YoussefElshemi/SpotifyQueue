using Core.Models;
using Core.ValueObjects;
using Infrastructure.Models;

namespace Infrastructure.Mappers;

public static class ItemMapper
{
    public static Item Map(ItemDto itemDto)
    {
        return new Item
        {
            Id = new ItemId(itemDto.Id),
            Album = AlbumMapper.Map(itemDto.Album),
            Artists = itemDto.Artists.Select(ArtistMapper.Map).ToList(),
            Images = itemDto.Images.Select(ImageMapper.Map).ToList(),
            DurationMs = new Duration(itemDto.DurationMs),
            Name = new ItemName(itemDto.Name),
            Href = new Uri(itemDto.Href),
            ExternalUrl = new Uri(itemDto.ExternalUrl.Spotify),
            PreviewUrl = itemDto.PreviewUrl is null ? null : new Uri(itemDto.PreviewUrl),
            Uri = new ItemUri(itemDto.Uri)
        };
    }
}