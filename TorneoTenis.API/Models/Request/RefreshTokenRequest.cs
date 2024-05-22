using System.ComponentModel.DataAnnotations;

namespace TorneoTenis.API.Models.Request
{
    public class RefreshTokenRequest
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
