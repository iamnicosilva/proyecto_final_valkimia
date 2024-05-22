using escuela.API.Exceptions;
using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Models.Request;
using TorneoTenis.API.Repository;
using TorneoTenis.API.Services.Auxiliares.Interfaces;


namespace TorneoTenis.API.Services.Auxiliares
{
    public class DefinirGanadorService : IDefinirGanadorService
    {
        public (Jugador ganador, Jugador perdedor) ElegirGanador(Jugador jugador1, Jugador jugador2)
        {
            // LA HABILIDAD PESA 50% MÁS
            var SkillsJugador1 = jugador1.Habilidad * 1.5;
            var SkillsJugador2 = jugador2.Habilidad * 1.5;
            var ganador = jugador1;
            var perdedor = jugador2;

            if (jugador1.IdGenero == 2 && jugador2.IdGenero == 2)
            {
                // PARTIDO MASCULINO
                SkillsJugador1 += jugador1.Fuerza + jugador1.Velocidad;
                SkillsJugador2 += jugador2.Fuerza + jugador2.Velocidad;
            }
            else if (jugador1.IdGenero == 1 && jugador2.IdGenero == 1)
            {
                // PARTIDO FEMENINO
                SkillsJugador1 += jugador1.Reaccion;
                SkillsJugador2 += jugador2.Reaccion;
            }
            else
            {
                throw new BadRequestException("Error al generar un partido", "Los géneros son inválidos");
            }

            // VALIDAR SI SE SACAN 15% DE VENTAJA Y ASIGNAR GANADOR
            if (SkillsJugador1 * 1.15 < SkillsJugador2)
            {
                ganador = jugador2;
                perdedor = jugador1;
            }
            else if (SkillsJugador2 * 1.15 < SkillsJugador1)
            {
                ganador = jugador1;
                perdedor = jugador2;
            }
            else
            {
                // SI NO SE SACAN 15% DE VENTAJA, APLICAR LA SUERTE ALEATORIAMENTE
                var random = new Random();
                var jugadorGanadorSuerte = random.Next(1, 3); // Generar un número aleatorio entre 1 y 2
                if (jugadorGanadorSuerte == 1)
                {
                    ganador = jugador1;
                    perdedor = jugador2;
                }
                else
                {
                    ganador = jugador2;
                    perdedor = jugador1;
                }
            }

            return (ganador, perdedor);
        }

    }

}
