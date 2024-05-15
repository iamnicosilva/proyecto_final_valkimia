using TorneoTenis.API.Models.Entities;

namespace TorneoTenis.API.Services.Auxiliares
{
    public static class ElegirGanadorAuxiliar
    {
        public static (Jugador ganador, Jugador perdedor) ElegirGanador(Jugador jugador1, Jugador jugador2)
        {
            //
            //LOGICA PARA COMPARAR JUGADORES
            //
            var ganador = jugador2;
            var perdedor = jugador1;
            return (ganador, perdedor);
        }
    }
}
