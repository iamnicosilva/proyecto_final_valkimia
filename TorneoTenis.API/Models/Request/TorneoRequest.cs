using System.ComponentModel.DataAnnotations;
using TorneoTenis.API.Models.DTO;
using TorneoTenis.API.Models.Entities;

namespace TorneoTenis.API.Models.Request
{

    public class TorneoRequestExistentes
    {
        [Required(ErrorMessage = "El torneo es obligatorio.")]
        public TorneoDTO Torneo { get; set; }

        [Required(ErrorMessage = "La lista de jugadores es obligatoria.")]
        [MinLength(2, ErrorMessage = "Debe haber al menos dos participantes.")]
        public List<JugadorDTO> Jugadores { get; set; }
    }

    public class TorneoRequestNuevos
    {
        [Required(ErrorMessage = "El torneo es obligatorio.")]
        public TorneoDTO Torneo { get; set; }

        [Required(ErrorMessage = "La lista de jugadores es obligatoria.")]
        [MinLength(2, ErrorMessage = "Debe haber al menos dos participantes.")]
        public List<JugadorRequest> Jugadores { get; set; }
    }


}
