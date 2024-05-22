using Microsoft.EntityFrameworkCore;
using TorneoTenis.API.Mappers.Usuarios;
using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Models.Request;
using TorneoTenis.API.Repository;
using TorneoTenis.API.Services.Autentication.Interfaces;
using TorneoTenis.API.Services.Interfaces;

namespace TorneoTenis.API.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly TorneoTenisContext _torneoTenisContext;
        private readonly IEncryptionService _encryptionService;

        public UsuarioService(TorneoTenisContext torneoTenisContext, IEncryptionService encryptionService)
        {
            _torneoTenisContext = torneoTenisContext;
            _encryptionService = encryptionService;
        }

        public async Task CreateUserAsync(UsuarioRequest usuarioRequest)
        {
            var usuario = await _torneoTenisContext.Set<Usuario>()
                .FirstOrDefaultAsync(u => u.Username.Equals(usuarioRequest.Username));

            if (usuario != null)
                throw new Exception($"El usuario {usuarioRequest.Username} ya existe");

            Usuario newUsuario = usuarioRequest.ToUsuario();

            newUsuario.Password = _encryptionService.Encrypt(usuarioRequest.Password);

            _torneoTenisContext.Add(newUsuario);

            await _torneoTenisContext.SaveChangesAsync();
        }

        public async Task<Usuario> GetUserByRefreshTokenAsync(string refreshToken)
        {
            var user = await _torneoTenisContext.Set<Usuario>()
                .FirstOrDefaultAsync(u => u.RefreshToken.Equals(refreshToken));

            return user;
        }

        public async Task<Usuario> ValidateUserAsync(UsuarioRequest usuarioRequest)
        {
            var passEncypted = _encryptionService.Encrypt(usuarioRequest.Password);

            var user = await _torneoTenisContext.Set<Usuario>()
                .FirstOrDefaultAsync(u => u.Username.Equals(usuarioRequest.Username) &&
                u.Password.Equals(passEncypted));

            if (user == null)
                throw new Exception("Credenciales no validas");

            return user;
        }
    }
}
