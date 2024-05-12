using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Models.Request;
using TorneoTenis.API.Models.Response;
using TorneoTenis.API.Models.Response.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;


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

        public static JugadorResponse ToJugadorResponse(this Jugador jugador)
        {
            return new JugadorResponse
            {
                Nombre = jugador.Nombre,
                Apellido = jugador.Apellido,
                Habilidad = jugador.Habilidad,
                Fuerza = jugador.Fuerza,
                Velocidad = jugador.Velocidad,
                Reaccion = jugador.Reaccion,
                EsHombre = jugador.EsHombre

            };
        }

        public static Jugador ToJugadorUpdate(this Jugador jugadorExistente, JugadorRequest jugadorRequest)
        {
            jugadorExistente.Nombre = jugadorRequest.Nombre;
            jugadorExistente.Apellido = jugadorRequest.Apellido;
            jugadorExistente.Habilidad = jugadorRequest.Habilidad;
            jugadorExistente.Fuerza = jugadorRequest.Fuerza;
            jugadorExistente.Velocidad = jugadorRequest.Velocidad;
            jugadorExistente.Reaccion = jugadorRequest.Reaccion;
            jugadorExistente.EsHombre = jugadorRequest.EsHombre;

            return jugadorExistente;
        }

        public static Jugador ToJugadorDelete(this Jugador jugadorExistente)
        {
            jugadorExistente.Eliminado = true;

            return jugadorExistente;
        }
    }
}
