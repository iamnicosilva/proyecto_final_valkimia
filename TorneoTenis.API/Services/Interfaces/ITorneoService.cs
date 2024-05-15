using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Models.Request;
using TorneoTenis.API.Models.Response;
using TorneoTenis.API.Models.Response.DTO;

namespace TorneoTenis.API.Services.Interfaces
{
    public interface ITorneoService
    {
        Task AgregarTorneo(TorneoRequest nuevoTorneo);
        Task<TorneoResponse> BuscarTorneo(int id);
        Task ActualizarTorneo(int id, TorneoRequest TorneoActualizado);
        Task EliminarTorneo(int id);
        Task<List<TorneoResponse>> BuscarTorneos();
        Task AgregarTorneoCompleto(TorneoRequest nuevoTorneo, List<JugadorDTO> jugadores);
    }
}
