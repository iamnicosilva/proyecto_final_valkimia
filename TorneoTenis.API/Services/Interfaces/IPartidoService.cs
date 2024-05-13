using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Models.Request;
using TorneoTenis.API.Models.Response;

namespace TorneoTenis.API.Services.Interfaces
{
    public interface IPartidoService
    {
        //Task<IEnumerable<AlumnoWithMateriasResponse>> GetAllAlumnosWithMaterias(int idAula);
        Task AgregarPartido(PartidoRequest nuevoPartido);
        Task <PartidoResponse> BuscarPartido(int id);
        Task ActualizarPartido(int id, PartidoRequest PartidoActualizado);
        Task EliminarPartido(int id);
        Task <List<PartidoResponse>> BuscarPartidos();
    }
}
