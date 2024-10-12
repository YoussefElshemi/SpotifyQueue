using Core.Models;
using Presentation.Models;

namespace Presentation.Mappers;

public static class ImageDtoMapper
{
    public static ImageDto Map(Image image)
    {
        return new ImageDto
        {
            Width = image.Width,
            Height = image.Height,
            Url = image.Url.ToString()
        };
    }
}