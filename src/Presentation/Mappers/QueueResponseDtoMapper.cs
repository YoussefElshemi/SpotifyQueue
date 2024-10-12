using Core.Models;
using Presentation.Models;

namespace Presentation.Mappers;

public static class QueueResponseDtoMapper
{
    public static QueueResponseDto Map(QueueResponse queueResponse)
    {
        return new QueueResponseDto
        {
            CurrentlyPlaying = queueResponse.CurrentlyPlaying is null ? null : ItemDtoMapper.Map(queueResponse.CurrentlyPlaying),
            Queue = queueResponse.Queue.Select(ItemDtoMapper.Map).ToList()
        };
    }
}