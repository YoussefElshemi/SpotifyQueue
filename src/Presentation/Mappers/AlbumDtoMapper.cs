using Core.Models;
using Presentation.Models;

namespace Presentation.Mappers;

public static class AlbumDtoMapper
{
    public static AlbumDto Map(Album album)
    {
        return new AlbumDto
            {
            Href = album.Href.ToString(),
            Id = album.Id,
            Images = album.Images.Select(ImageDtoMapper.Map).ToList(),
            Name = album.Name,
            Uri = album.Uri.ToString(),
            ExternalUrl = album.ExternalUrl.ToString()
        };
    }
}