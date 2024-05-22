using TorneoTenis.API.Models.Entities;

namespace TorneoTenis.API.Services.Auxiliares.Interfaces
{
    public interface IDefinirGanadorService
    {
        (Jugador ganador, Jugador perdedor) ElegirGanador(Jugador jugador1, Jugador jugador2);
    }
}
