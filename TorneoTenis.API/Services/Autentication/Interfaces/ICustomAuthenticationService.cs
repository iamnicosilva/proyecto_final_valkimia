using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Models.Response;

namespace TorneoTenis.API.Services.Autentication.Interfaces
{
    public interface ICustomAuthenticationService
    {
        TokenResponse GenerateToken(Usuario usuario);
        bool ValidateRefreshToken(Usuario usuario);
        Task UpdateRefreshToken(Usuario userFromDB, string refreshToken);
    }
}
