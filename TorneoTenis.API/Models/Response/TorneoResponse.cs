using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace TorneoTenis.API.Models.Response
{
    public class TorneoResponse
    {
        //[JsonPropertyName("name")]
        public string Nombre { get; set; }
        //[JsonPropertyName("surname")]
        public int Anio { get; set; }

    }
}
