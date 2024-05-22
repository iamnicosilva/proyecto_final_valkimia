using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace TorneoTenis.API.Models.Response
{
    public class TorneoResponse
    {
        public string Nombre { get; set; }
        public int Anio { get; set; }
        public List<PartidoResponse> Fixture { get; set; }

    }
}
