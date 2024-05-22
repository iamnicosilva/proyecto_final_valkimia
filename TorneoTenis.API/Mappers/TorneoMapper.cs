using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Models.Request;
using TorneoTenis.API.Models.Response;
using TorneoTenis.API.Models.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace TorneoTenis.API.Mappers
{
    public static class TorneoMapper
    {
        public static Torneo ToTorneo(this TorneoDTO torneoDTO, int idGenero)
        {
            return new Torneo
            {
                Nombre = torneoDTO.Nombre,
                Anio = torneoDTO.Anio,
                IdGenero = idGenero
            };
        }




        public static TorneoResponse ToTorneoResponse(this List<PartidoResponse> partidosResponses, string nombre, int anio )
        {
            return new TorneoResponse
            {
                Nombre = nombre,
                Anio = anio,
                Fixture = partidosResponses
            };
        }

        public static TorneoRequestExistentes NuevosToTorneoExistentes(this TorneoRequestNuevos torneoRequest)
        {
            return new TorneoRequestExistentes
            {
                Torneo = torneoRequest.Torneo,
                Jugadores = torneoRequest.Jugadores.Select(j => new JugadorDTO
                {
                    Nombre = j.Nombre,
                    Apellido = j.Apellido
                }).ToList()
            };

        }

        public static TorneoWithGeneroDTO ToTorneoWithGeneroDTO(this Torneo torneo, string genero)
        {
            return new TorneoWithGeneroDTO
            {
                Nombre = torneo.Nombre,
                Anio = torneo.Anio,
                Genero = genero
            };
        }




        public static Torneo ToTorneoDelete(this Torneo torneoExistente)
        {
            torneoExistente.Eliminado = true;

            return torneoExistente;
        }
    }
}
