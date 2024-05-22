using System.ComponentModel.DataAnnotations;

namespace TorneoTenis.API.Models.Request
{
    public class JugadorRequest
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(100, ErrorMessage = "El apellido no puede exceder los 100 caracteres.")]
        public string Apellido { get; set; }

        [Range(0, 100, ErrorMessage = "La habilidad debe estar entre 0 y 100.")]
        public int Habilidad { get; set; }

        [Range(0, 100, ErrorMessage = "La fuerza debe estar entre 0 y 100.")]
        public int Fuerza { get; set; }

        [Range(0, 100, ErrorMessage = "La velocidad debe estar entre 0 y 100.")]
        public int Velocidad { get; set; }

        [Range(0, 100, ErrorMessage = "La reacción debe estar entre 0 y 100.")]
        public int Reaccion { get; set; }
    }

    public class JugadorUpdateRequest
    {
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; }

        [StringLength(100, ErrorMessage = "El apellido no puede exceder los 100 caracteres.")]
        public string Apellido { get; set; }

        [Range(0, 100, ErrorMessage = "La habilidad debe estar entre 0 y 100.")]
        public int Habilidad { get; set; }

        [Range(0, 100, ErrorMessage = "La fuerza debe estar entre 0 y 100.")]
        public int Fuerza { get; set; }

        [Range(0, 100, ErrorMessage = "La velocidad debe estar entre 0 y 100.")]
        public int Velocidad { get; set; }

        [Range(0, 100, ErrorMessage = "La reacción debe estar entre 0 y 100.")]
        public int Reaccion { get; set; }
    }

}
