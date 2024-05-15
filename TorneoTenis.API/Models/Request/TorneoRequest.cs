using TorneoTenis.API.Models.Response.DTO;

namespace TorneoTenis.API.Models.Request
{
    public class TorneoManualRequest
    {
        public string Nombre { get; set; }
        public int Anio { get; set; }
        public bool EsTorneoMasculino { get; set; }

    }

    public class TorneoRequest
    {
        public string Nombre { get; set; }
        public int Anio { get; set; }

    }



    public class TorneoCompletoRequest
    {
        public TorneoRequest NuevoTorneo { get; set; }


        public List<JugadorDTO> Jugadores { get; set; }
    }


}
