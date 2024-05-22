using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TorneoTenis.API.Configuration;
using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Models.Response;
using TorneoTenis.API.Repository;
using TorneoTenis.API.Services.Autentication.Interfaces;




namespace TorneoTenis.API.Services.Autentication
{
    public class CustomAuthenticationService : ICustomAuthenticationService
    {
        private readonly CustomAuthenticationOptions _authenticationOptions;
        private readonly TorneoTenisContext _torneoTenisContext;

        public CustomAuthenticationService(IOptions<CustomAuthenticationOptions> authenticationOptions, TorneoTenisContext torneoTenisContext)
        {
            _authenticationOptions = authenticationOptions.Value;
            _torneoTenisContext = torneoTenisContext;
        }

        public TokenResponse GenerateToken(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException("usuario");

            var claims = new List<Claim>()
            {
                new Claim("Id", usuario.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Username),
                new Claim(JwtRegisteredClaimNames.GivenName, usuario.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationOptions.Key));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expDate = DateTime.UtcNow.AddMinutes(_authenticationOptions.Expiration);

            var expRefrestokenDate = DateTime.UtcNow.AddMinutes(_authenticationOptions.RefreshTokenExpiration);

            var token = new JwtSecurityToken(
                issuer: _authenticationOptions.Issuer,
                audience: _authenticationOptions.Audience,
                claims: claims,
                expires: expDate,
                signingCredentials: credentials
            );

            return new TokenResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpirationToken = expDate,
                RefreshToken = GenerateRefreshToken(),
                RefreshTokenExpiration = expRefrestokenDate
            };
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public bool ValidateRefreshToken(Usuario usuario)
        {
            return usuario.RefreshTokenExpiration > DateTime.UtcNow;
        }

        public async Task UpdateRefreshToken(Usuario userFromDB, string refreshToken)
        {
            userFromDB.RefreshToken = refreshToken;
            userFromDB.RefreshTokenExpiration = DateTime.UtcNow.AddMinutes(_authenticationOptions.RefreshTokenExpiration);

            _torneoTenisContext.Update(userFromDB);
            await _torneoTenisContext.SaveChangesAsync();
        }
    }
}
