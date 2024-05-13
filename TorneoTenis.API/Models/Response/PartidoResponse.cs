using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace TorneoTenis.API.Models.Response
{
    public class PartidoResponse
    {
        public int Etapa { get; set; }
        public DateOnly Fecha { get; set; }
        public int IdGanador { get; set; }
        public int IdPerdedor { get; set; }
        public int IdTorneo { get; set; }
        public string DescripcionGanador { get; set; }

    }
}
