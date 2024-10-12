using Core.Models;
using Core.ValueObjects;
using Infrastructure.Models;

namespace Infrastructure.Mappers;

public static class StateResponseMapper
{
    public static StateResponse Map(StateResponseDto stateResponseDto)
    {
        return new StateResponse
        {
            ProgressMs = new ProgressMs(stateResponseDto.ProgressMs),
            IsPlaying = new IsPlaying(stateResponseDto.IsPlaying),
            Item = ItemMapper.Map(stateResponseDto.Item)
        };
    }
}