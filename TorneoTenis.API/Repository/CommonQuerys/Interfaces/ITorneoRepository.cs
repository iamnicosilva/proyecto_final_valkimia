using TorneoTenis.API.Models.Entities;

namespace TorneoTenis.API.Repository.CommonQuerys.Interfaces
{
    public interface ITorneoRepository
    {
        Task<int> ObtenerIdPorNombreYAnio(string nombreTorneo, int anioTorneo);
        Task<Torneo> ObtenerTorneoPorNombreYAnio(string nombreTorneo, int anioTorneo);
        Task<List<Torneo>> ObtenerTodosLosTorneos();
    }

}
