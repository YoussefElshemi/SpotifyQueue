using Core.Models;
using Presentation.Models;

namespace Presentation.Mappers;

public static class StateResponseDtoMapper
{
    public static StateResponseDto Map(StateResponse stateResponse)
    {
        return new StateResponseDto
        {
            ProgressMs = stateResponse.ProgressMs,
            IsPlaying = stateResponse.IsPlaying,
            ShuffleState = stateResponse.ShuffleState,
            RepeatState = stateResponse.RepeatState,
            Device = DeviceDtoMapper.Map(stateResponse.Device),
            Item = ItemDtoMapper.Map(stateResponse.Item)
        };
    }
}