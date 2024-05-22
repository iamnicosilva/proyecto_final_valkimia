using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Models.Request;

namespace TorneoTenis.API.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> ValidateUserAsync(UsuarioRequest usuarioRequest);
        Task CreateUserAsync(UsuarioRequest usuarioRequest);
        Task<Usuario> GetUserByRefreshTokenAsync(string refreshToken);
    }
}
