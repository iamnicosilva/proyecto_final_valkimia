using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace TorneoTenis.API.Models.Response
{
    public class JugadorResponse
    {
        //[JsonPropertyName("name")]
        public string Nombre { get; set; }
        //[JsonPropertyName("surname")]
        public string Apellido { get; set; }

        [Range(0, 100)]
        public int Habilidad { get; set; }

        [Range(0, 100)]
        public int Fuerza { get; set; }

        [Range(0, 100)]
        public int Velocidad { get; set; }

        [Range(0, 100)]
        public int Reaccion { get; set; }

        public bool EsHombre { get; set; }

    }
}
