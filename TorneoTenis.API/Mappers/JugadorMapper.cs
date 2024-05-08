using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Models.Request;
using TorneoTenis.API.Models.Response;
using TorneoTenis.API.Models.Response.DTO;


namespace TorneoTenis.API.Mappers
{
    public static class JugadorMapper
    {
        public static Jugador ToJugador(this JugadorRequest jugadorRequest)
        {
            return new Jugador
            {
                Nombre = jugadorRequest.Nombre,
                Apellido = jugadorRequest.Apellido,
                Habilidad = jugadorRequest.Habilidad,
                Fuerza = jugadorRequest.Fuerza,
                Velocidad = jugadorRequest.Velocidad,
                Reaccion = jugadorRequest.Reaccion,
                EsHombre = jugadorRequest.EsHombre
                
            };
        }

    }
}
