using Core.Models;
using Infrastructure.Models;

namespace Infrastructure.Mappers;

public static class QueueResponseMapper
{
    public static QueueResponse Map(QueueResponseDto queueResponseDto)
    {
        return new QueueResponse
        {
            CurrentlyPlaying = queueResponseDto.CurrentlyPlaying is null ? null : ItemMapper.Map(queueResponseDto.CurrentlyPlaying),
            Queue = queueResponseDto.Queue.Select(ItemMapper.Map).ToList()
        };
    }
}