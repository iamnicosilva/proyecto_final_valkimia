using System.ComponentModel.DataAnnotations;

namespace TorneoTenis.API.Models.Request
{
    public class UsuarioRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
