using Core.Models;
using Core.ValueObjects;
using Infrastructure.Models;

namespace Infrastructure.Mappers;

public static class RefreshTokenResponseMapper
{
    public static RefreshTokenResponse Map(RefreshTokenResponseDto refreshTokenResponseDto)
    {
        return new RefreshTokenResponse
        {
            AccessToken = new AccessToken(refreshTokenResponseDto.AccessToken),
            ExpiresIn = new ExpiresIn(refreshTokenResponseDto.ExpiresIn),
        };
    }
}