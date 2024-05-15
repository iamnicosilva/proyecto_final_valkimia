using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Models.Request;
using TorneoTenis.API.Models.Response;
using TorneoTenis.API.Models.Response.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace TorneoTenis.API.Mappers
{
    public static class TorneoMapper
    {
        public static Torneo ToTorneo(this TorneoManualRequest torneoRequest)
        {
            return new Torneo
            {
                Nombre = torneoRequest.Nombre,
                Anio = torneoRequest.Anio

            };
        }

        public static Torneo ToTorneoCompleto(this TorneoCompletoRequest torneoRequest, bool EsTorneoMasculino)
        {
            return new Torneo
            {
                Nombre = torneoRequest.NuevoTorneo.Nombre,
                Anio = torneoRequest.NuevoTorneo.Anio,
                EsTorneoMasculino = EsTorneoMasculino

            };
        }




        public static TorneoResponse ToTorneoResponse(this Torneo torneo)
        {
            return new TorneoResponse
            {
                Nombre = torneo.Nombre,
                Anio = torneo.Anio

            };
        }

        public static Torneo ToTorneoUpdate(this Torneo torneoExistente, TorneoManualRequest torneoRequest)
        {
            torneoExistente.Nombre = torneoRequest.Nombre;
            torneoExistente.Anio = torneoRequest.Anio;

            return torneoExistente;
        }

        public static Torneo ToTorneoDelete(this Torneo torneoExistente)
        {
            torneoExistente.Eliminado = true;

            return torneoExistente;
        }
    }
}
