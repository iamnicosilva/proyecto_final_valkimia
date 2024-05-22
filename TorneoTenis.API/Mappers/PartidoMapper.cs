using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Models.Request;
using TorneoTenis.API.Models.Response;
using TorneoTenis.API.Models.DTO;


namespace TorneoTenis.API.Mappers
{
    public static class PartidoMapper
    {
        public static Partido ToPartido(this PartidoRequest partidoRequest, DateTime fecha)
        {
            return new Partido
            {
                IdTorneo = partidoRequest.IdTorneo,
                Etapa = partidoRequest.Etapa,
                IdGanador = partidoRequest.IdGanador,
                IdPerdedor = partidoRequest.IdPerdedor,
                Fecha = fecha

            };
        }



        public static PartidoRequest ToPartidoRequest(this int idTorneo, int etapa, int idGanador, int idPerdedor)
        {
            return new PartidoRequest
            {
                IdTorneo = idTorneo,
                Etapa = etapa,
                IdGanador = idGanador,
                IdPerdedor = idPerdedor

            };
        }


        public static PartidoResponse ToPartidoResponse(this Partido partido, JugadorDTO ganador, JugadorDTO perdedor)
        {

            return new PartidoResponse
            {
                Partido = new PartidoDTO
                {
                    Etapa = partido.Etapa,
                    Fecha = partido.Fecha,
                },
                Ganador = new JugadorDTO
                {
                    Nombre = ganador.Nombre,
                    Apellido = ganador.Apellido
                },
                Perdedor = new JugadorDTO
                {
                    Nombre = perdedor.Nombre,
                    Apellido = perdedor.Apellido
                }
            };
        }

    }
}
