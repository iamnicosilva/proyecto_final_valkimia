using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using TorneoTenis.API.Models.Request;
using TorneoTenis.API.Services.Autentication.Interfaces;
using TorneoTenis.API.Services.Interfaces;

namespace TorneoTenis.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ICustomAuthenticationService _authenticationService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsuarioController(IUsuarioService usuarioService, ICustomAuthenticationService customAuthenticationService)
        {
            _usuarioService = usuarioService;
            _authenticationService = customAuthenticationService;
        }

        [HttpPost]
        [Route("CrearUsuario")]
        public async Task<IActionResult> CreateUserAsync(UsuarioRequest usuarioRequest)
        {
            await _usuarioService.CreateUserAsync(usuarioRequest);
            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync(UsuarioRequest usuarioRequest)
        {
            var userValidado = await _usuarioService.ValidateUserAsync(usuarioRequest);

            var token = _authenticationService.GenerateToken(userValidado);

            await _authenticationService.UpdateRefreshToken(userValidado, token.RefreshToken);

            return Ok(token);
        }

        [HttpPost]
        [Route("RefreshToken")]
        public async Task<IActionResult> RefreshTokenAsync(RefreshTokenRequest refreshToken)
        {
            var userFromDb = await _usuarioService.GetUserByRefreshTokenAsync(refreshToken.RefreshToken);

            if (userFromDb == null)
                return Unauthorized($"No existe usuario con el {refreshToken.RefreshToken} ingresado");

            if (userFromDb.RefreshTokenExpiration.HasValue)
            {
                if (!_authenticationService.ValidateRefreshToken(userFromDb))
                    return Unauthorized("El token de refresco ha expirado");
            }

            var token = _authenticationService.GenerateToken(userFromDb);

            if (token == null)
                return Unauthorized("No se pudo generar el token");

            await _authenticationService.UpdateRefreshToken(userFromDb, token.RefreshToken);

            return Ok(token);
        }
    }
}
