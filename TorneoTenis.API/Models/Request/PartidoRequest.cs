using TorneoTenis.API.Models.Entities;

namespace TorneoTenis.API.Models.Request
{
    public class PartidoRequest
    {
        public int Etapa { get; set; }
        public DateOnly Fecha { get; set; }
        public int IdGanador { get; set; }
        public int IdPerdedor { get; set; }
        public int IdTorneo { get; set; }
    }
}
