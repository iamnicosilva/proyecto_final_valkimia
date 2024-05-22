using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Models.DTO;

namespace TorneoTenis.API.Models.Request
{
    public class PartidoRequest
    {
        public int IdGanador { get; set; }
        public int IdPerdedor { get; set; }
        public int IdTorneo { get; set; }
        public int Etapa { get; set; }

    }

}
