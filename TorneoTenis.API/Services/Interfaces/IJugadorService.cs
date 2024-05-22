using TorneoTenis.API.Models.DTO;
using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Models.Request;
using TorneoTenis.API.Models.Response;

namespace TorneoTenis.API.Services.Interfaces
{
    public interface IJugadorService
    {
        Task AgregarJugador(JugadorRequest Jugador, int IdGenero);
        Task AgregarJugadorDesdeLista(List<JugadorRequest> nuevosJugadores, int IdGenero);
        Task <JugadorResponse> BuscarJugador(string Nombre, string Apellido);
        Task ActualizarJugador(JugadorUpdateRequest JugadorActualizado, string Nombre, string Apellido);
        Task EliminarJugador(JugadorDTO Jugador);
        Task <List<JugadorResponse>> BuscarJugadores();
    }
}
