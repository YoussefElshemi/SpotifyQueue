using Core.Models;
using Core.ValueObjects;
using Infrastructure.Models;

namespace Infrastructure.Mappers;

public static class AlbumMapper
{
    public static Album Map(AlbumDto albumDto)
    {
        return new Album
        {
            Href = new Uri(albumDto.Href),
            Id = new AlbumId(albumDto.Id),
            Images = albumDto.Images.Select(albumImage => new Image
            {
                Width = new ImageWidth(albumImage.Width),
                Height = new ImageHeight(albumImage.Height),
                Url = new Uri(albumImage.Url)
            }).ToList(),
            Name = new AlbumName(albumDto.Name),
            Uri = new AlbumUri(albumDto.Uri),
            ExternalUrl = new Uri(albumDto.ExternalUrl.Spotify)
        };
    }
}