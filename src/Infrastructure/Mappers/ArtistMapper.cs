using Core.Models;
using Core.ValueObjects;
using Infrastructure.Models;

namespace Infrastructure.Mappers;

public static class ArtistMapper
{
    public static Artist Map(ArtistDto artistDto)
    {
        return new Artist
        {
            ExternalUrl = new Uri(artistDto.ExternalUrl.Spotify),
            Href = new Uri(artistDto.Href),
            Id = new ArtistId(artistDto.Id),
            Name = new ArtistName(artistDto.Name),
            Uri = new ArtistUri(artistDto.Uri)
        };
    }
}