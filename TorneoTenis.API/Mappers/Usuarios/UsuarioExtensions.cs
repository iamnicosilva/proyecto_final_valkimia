using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Models.Request;

namespace TorneoTenis.API.Mappers.Usuarios
{
    public static class UsuarioExtensions
    {
        public static Usuario ToUsuario(this UsuarioRequest usuarioRequest)
        {
            return new Usuario
            {
                Username = usuarioRequest.Username,
                Password = usuarioRequest.Password
            };
        }
    }
}
