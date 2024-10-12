using Core.Models;
using Presentation.Models;

namespace Presentation.Mappers;

public static class ArtistDtoMapper
{
    public static ArtistDto Map(Artist artist)
    {
        return new ArtistDto
        {
            ExternalUrl = artist.ExternalUrl.ToString(),
            Href = artist.Href.ToString(),
            Id = artist.Id,
            Name = artist.Name,
            Uri = artist.Uri.ToString()
        };
    }
}