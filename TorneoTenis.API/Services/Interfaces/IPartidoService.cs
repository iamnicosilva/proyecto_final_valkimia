using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Models.Request;
using TorneoTenis.API.Models.Response;

namespace TorneoTenis.API.Services.Interfaces
{
    public interface IPartidoService
    {
        Task CrearPartido(PartidoRequest nuevoPartido);
        Task<PartidoResponse> BuscarPartido(string torneo, int anio, int etapa);
        Task<List<PartidoResponse>> BuscarPartidos();
        Task<List<PartidoResponse>> BuscarPartidosPorTorneo(string nombreTorneo, int anioTroneo);
        Task<List<PartidoResponse>> BuscarPartidosPorJugador(string nombreJugador, string apellidoJugador);
    }
}
