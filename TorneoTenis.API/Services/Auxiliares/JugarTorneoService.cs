using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Services.Auxiliares.Interfaces;
using TorneoTenis.API.Mappers;
using TorneoTenis.API.Services.Interfaces;

namespace TorneoTenis.API.Services.Auxiliares
{
    public class JugarTorneoService : IJugarTorneoService
    {
        private readonly IDefinirGanadorService _definirGanadorService;
        private readonly IPartidoService _partidoService;
        public JugarTorneoService( IDefinirGanadorService definirGanadorService,
            IPartidoService partidoService)
        {
            _definirGanadorService = definirGanadorService;
            _partidoService = partidoService;
        }

        public async Task<Jugador?> JugarRondasDeTorneo(List<Jugador> jugadoresDelTorneo, int idTorneo, int etapa)
        {

            // Validar que haya más de un jugador en la lista
            if (jugadoresDelTorneo.Count <= 1)
            {
                if (jugadoresDelTorneo.Count == 1)
                {
                    // Si solo queda un jugador, ese jugador es el ganador del torneo
                    return jugadoresDelTorneo[0];
                }
                else
                {
                    // Si no hay jugadores, hubo un error en la cantidad y no se puede determinar un ganador
                    return null;
                }
            }


            var ganadores = new List<Jugador>();

            for (int i = 0; i < jugadoresDelTorneo.Count; i += 2)
            {
                var jugador1 = jugadoresDelTorneo[i];
                var jugador2 = jugadoresDelTorneo[i + 1];


                //ESTO ES PARTE DE CREAR PARTIDO - COMIENZO
                // Elegir el ganador y el perdedor del partido
                var ganadorYPerdedor = _definirGanadorService.ElegirGanador(jugador1, jugador2);

                Console.WriteLine($"Etapa: {etapa}");

                // Registrar el partido
                var partido = idTorneo.ToPartidoRequest(etapa, 
                    ganadorYPerdedor.ganador.Id, ganadorYPerdedor.perdedor.Id);

                await _partidoService.CrearPartido(partido);

                etapa --;
                //FIN

                // Agregar el ganador a la lista de ganadores
                ganadores.Add(ganadorYPerdedor.ganador);
                // CALCULAR NUEVA ETAPA PARA PROX ITERACION
            }

            // Llamar recursivamente para la siguiente ronda
            return await JugarRondasDeTorneo(ganadores, idTorneo, etapa);

        }
    }
}
