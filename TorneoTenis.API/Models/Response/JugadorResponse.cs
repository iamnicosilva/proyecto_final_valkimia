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

        public int Habilidad { get; set; }

        public int Fuerza { get; set; }

        public int Velocidad { get; set; }

        public int Reaccion { get; set; }

        public string Genero { get; set; }
    }
}
