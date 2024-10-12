using Core.Models;
using Core.ValueObjects;
using Infrastructure.Models;

namespace Infrastructure.Mappers;

public static class AuthenticationResponseMapper
{
    public static AuthenticationResponse Map(AuthenticationResponseDto authenticationResponseDto)
    {
        return new AuthenticationResponse
        {
            AccessToken = new AccessToken(authenticationResponseDto.AccessToken),
            RefreshToken = new RefreshToken(authenticationResponseDto.RefreshToken),
            ExpiresIn = new ExpiresIn(authenticationResponseDto.ExpiresIn),
        };
    }
}