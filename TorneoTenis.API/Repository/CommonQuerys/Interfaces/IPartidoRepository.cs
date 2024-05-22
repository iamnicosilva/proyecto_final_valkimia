using TorneoTenis.API.Models.Entities;

namespace TorneoTenis.API.Repository.CommonQuerys.Interfaces
{
    public interface IPartidoRepository
    {
        Task<List<Partido>> BuscarPartidosPorJugadorId(int jugadorId);
        Task<List<Partido>> BuscarTodosLosPartidos();
        Task<List<Partido>> BuscarPartidosPorTorneoId(int torneoId);
        Task<int> BuscarIdPorTorneoYEtapa(int torneoId, int etapa);
        Task<Partido> BuscarPartidoPorTorneoYEtapa(int torneoId, int etapa);
    }

}
