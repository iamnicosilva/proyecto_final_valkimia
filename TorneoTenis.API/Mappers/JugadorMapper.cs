using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Models.Request;
using TorneoTenis.API.Models.Response;
using TorneoTenis.API.Models.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace TorneoTenis.API.Mappers
{
    public static class JugadorMapper
    {
        public static Jugador ToJugador(this JugadorRequest jugadorRequest, int IdGenero)
        {
            return new Jugador
            {
                Nombre = jugadorRequest.Nombre,
                Apellido = jugadorRequest.Apellido,
                Habilidad = jugadorRequest.Habilidad,
                Fuerza = jugadorRequest.Fuerza,
                Velocidad = jugadorRequest.Velocidad,
                Reaccion = jugadorRequest.Reaccion,
                IdGenero = IdGenero
            };
        }

        public static JugadorResponse ToJugadorResponse(this Jugador jugador, string genero)
        {
            return new JugadorResponse
            {
                Nombre = jugador.Nombre,
                Apellido = jugador.Apellido,
                Habilidad = jugador.Habilidad,
                Fuerza = jugador.Fuerza,
                Velocidad = jugador.Velocidad,
                Reaccion = jugador.Reaccion,
                Genero = genero
            };
        }

        public static Jugador ToJugadorUpdate(this Jugador jugadorExistente, JugadorUpdateRequest jugadorRequest)
        {
            jugadorExistente.Nombre = jugadorRequest.Nombre;
            jugadorExistente.Apellido = jugadorRequest.Apellido;
            jugadorExistente.Habilidad = jugadorRequest.Habilidad;
            jugadorExistente.Fuerza = jugadorRequest.Fuerza;
            jugadorExistente.Velocidad = jugadorRequest.Velocidad;
            jugadorExistente.Reaccion = jugadorRequest.Reaccion;

            return jugadorExistente;
        }

        public static Jugador ToJugadorDelete(this Jugador jugadorExistente)
        {
            jugadorExistente.Eliminado = true;

            return jugadorExistente;
        }

        public static JugadorDTO ToJugadorDTO(this Jugador jugador)
        {
            return new JugadorDTO
            {
                Nombre = jugador.Nombre,
                Apellido = jugador.Apellido
            };
        }

        public static JugadorDTO JugadorRequestToJugadorDTO(this JugadorRequest jugador)
        {
            return new JugadorDTO
            {
                Nombre = jugador.Nombre,
                Apellido = jugador.Apellido
            };
        }
    }
}
