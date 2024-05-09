using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Models.Request;
using TorneoTenis.API.Models.Response;

namespace TorneoTenis.API.Services.Interfaces
{
    public interface IJugadorService
    {
        //Task<IEnumerable<AlumnoWithMateriasResponse>> GetAllAlumnosWithMaterias(int idAula);
        Task AgregarJugador(JugadorRequest nuevoJugador);
        Task <Jugador> BuscarJugador(int id);
    }
}
