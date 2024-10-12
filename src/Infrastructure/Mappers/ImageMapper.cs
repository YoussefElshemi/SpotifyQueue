using Core.Models;
using Core.ValueObjects;
using Infrastructure.Models;

namespace Infrastructure.Mappers;

public static class ImageMapper
{
    public static Image Map(ImageDto imageDto)
    {
        return new Image
        {
            Width = new ImageWidth(imageDto.Width),
            Height = new ImageHeight(imageDto.Height),
            Url = new Uri(imageDto.Url)
        };
    }
}