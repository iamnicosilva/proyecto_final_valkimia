using TorneoTenis.API.Models.Response.DTO;
using TorneoTenis.API.Models.Request;

namespace TorneoTenis.API.Models.Request
{
    public class TorneoCompletoRequest
    {
        public TorneoRequest NuevoTorneo { get; set; }


        public List<JugadorDTO> Jugadores { get; set; }
    }


}
