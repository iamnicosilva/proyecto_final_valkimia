using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Models.Request;
using TorneoTenis.API.Models.Response;
using TorneoTenis.API.Models.Response.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace TorneoTenis.API.Mappers
{
    public static class PartidoMapper
    {
        public static Partido ToPartido(this PartidoRequest partidoRequest)
        {
            return new Partido
            {
                Etapa = partidoRequest.Etapa,
                Fecha = new DateOnly(partidoRequest.Anio,partidoRequest.Mes,partidoRequest.Dia),
                DescripcionGanador = partidoRequest.DescripcionGanador,
                IdGanador = partidoRequest.IdGanador,
                IdPerdedor = partidoRequest.IdPerdedor,
                IdTorneo = partidoRequest.IdTorneo

            };
        }

        public static PartidoResponse ToPartidoResponse(this Partido partido)
        {
            return new PartidoResponse
            {
                Etapa = partido.Etapa,
                Fecha = partido.Fecha,
                DescripcionGanador = partido.DescripcionGanador,
                IdGanador = partido.IdGanador,
                IdPerdedor = partido.IdPerdedor,
                IdTorneo = partido.IdTorneo

            };
        }

        public static Partido ToPartidoUpdate(this Partido partidoExistente, PartidoRequest partidoRequest)
        {
            partidoExistente.Etapa = partidoRequest.Etapa;
            partidoExistente.Fecha = new DateOnly(partidoRequest.Anio, partidoRequest.Mes, partidoRequest.Dia);
            partidoExistente.DescripcionGanador = partidoRequest.DescripcionGanador;
            partidoExistente.IdGanador = partidoRequest.IdGanador;
            partidoExistente.IdPerdedor = partidoRequest.IdPerdedor;
            partidoExistente.IdTorneo = partidoRequest.IdTorneo;

            return partidoExistente;
        }

        public static Partido ToPartidoDelete(this Partido partidoExistente)
        {
            partidoExistente.Eliminado = true;

            return partidoExistente;
        }
    }
}
