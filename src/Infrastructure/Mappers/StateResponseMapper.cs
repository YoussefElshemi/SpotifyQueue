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
            ShuffleState = new ShuffleState(stateResponseDto.ShuffleState),
            RepeatState = new RepeatState(stateResponseDto.RepeatState),
            Device = DeviceMapper.Map(stateResponseDto.Device),
            Item = ItemMapper.Map(stateResponseDto.Item)
        };
    }
}