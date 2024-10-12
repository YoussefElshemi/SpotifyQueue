﻿using Core.Models;
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
            Item = ItemDtoMapper.Map(stateResponse.Item)
        };
    }
}