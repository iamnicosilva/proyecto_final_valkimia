using TorneoTenis.API.Models.Entities;

namespace TorneoTenis.API.Repository.CommonQuerys.Interfaces
{
    public interface IJugadorRepository
    {
        Task<int> ObtenerIdPorNombreYApellido(string nombre, string apellido);
        Task<Jugador> ObtenerJugadorPorNombreYApellido(string nombre, string apellido);
        Task<List<Jugador>> ObtenerTodosLosJugadores();
        Task<Jugador> ObtenerJugadorPorId(int Id);
    }

}
