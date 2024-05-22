using TorneoTenis.API.Models.Entities;

namespace TorneoTenis.API.Services.Auxiliares.Interfaces
{
    public interface IJugarTorneoService
    {
        Task<Jugador?> JugarRondasDeTorneo(List<Jugador> jugadoresDelTorneo, int idTorneo, int etapaInicial);
    }
}
