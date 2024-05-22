using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TorneoTenis.API.Models.DTO;

namespace TorneoTenis.API.Models.Response
{
    public class PartidoResponse
    {
        public PartidoDTO Partido { get; set; }
        public JugadorDTO Ganador { get; set; }
        public JugadorDTO Perdedor { get; set; }

    }
}
