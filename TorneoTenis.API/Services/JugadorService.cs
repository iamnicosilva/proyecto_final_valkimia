using Microsoft.EntityFrameworkCore;
using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Mappers;
using TorneoTenis.API.Models.Request;
using TorneoTenis.API.Models.Response;
using TorneoTenis.API.Repository;
using TorneoTenis.API.Services.Interfaces;

namespace TorneoTenis.API.Services
{
    public class JugadorService : IJugadorService
    {
        private readonly TorneoTenisContext _torneoTenisContext;

        public JugadorService(TorneoTenisContext torneoTenisContex)
        {
            _torneoTenisContext = torneoTenisContex;
        }

        public async Task AgregarJugador(JugadorRequest nuevoJugador)
        {
            var potencialJugadorDuplicado = await _torneoTenisContext.Set<Jugador>()
                                            .Where(a => a.Nombre == nuevoJugador.Nombre)
                                            .Where(a => a.Apellido == nuevoJugador.Apellido)
                                            .FirstOrDefaultAsync();

            if (potencialJugadorDuplicado != null)
                throw new Exception("Este Jugador ya esta registrado");

            var nuevoJugadorAAgregar = nuevoJugador.ToJugador();

            _torneoTenisContext.Add(nuevoJugadorAAgregar);

            await _torneoTenisContext.SaveChangesAsync();
        }


        public async Task<JugadorResponse> BuscarJugador(string nombre, string apellido)
        {

            // ESTO SE DEBE PASAR A UN SERVICIO BUSCAR_JUGADOR_POR_ID:

            var JugadorEspecífico = await _torneoTenisContext.Set<Jugador>()
                                    .Where(a => a.Nombre == nombre && a.Apellido == apellido)
                                    .FirstOrDefaultAsync();


            if (JugadorEspecífico == null || JugadorEspecífico.Eliminado) 
                throw new Exception("El jugador no se encuentra");
            // fin

            var response = JugadorEspecífico.ToJugadorResponse();

            return response;
            
        }


        public async Task ActualizarJugador(int id,JugadorRequest JugadorActualizado)
        {

            var jugadorExistente = await _torneoTenisContext.Set<Jugador>()
                        .Where(a => a.Id == id).FirstOrDefaultAsync();

            if (jugadorExistente == null || jugadorExistente.Eliminado)
            {
                throw new Exception("El jugador no se encuentra");
            }

            jugadorExistente.ToJugadorUpdate(JugadorActualizado);

            await _torneoTenisContext.SaveChangesAsync();
        }

        public async Task EliminarJugador(int id)
        {

            var jugadorExistente = await _torneoTenisContext.Set<Jugador>()
                        .Where(a => a.Id == id).FirstOrDefaultAsync();

            if (jugadorExistente == null || jugadorExistente.Eliminado)
            {
                throw new Exception("El jugador no se encuentra");
            }

            jugadorExistente.ToJugadorDelete();

            await _torneoTenisContext.SaveChangesAsync();
        }


        public async Task<List<JugadorResponse>> BuscarJugadores()
        {

            var Jugadores = await _torneoTenisContext.Set<Jugador>()
                                            .Where(a =>a.Eliminado == false).ToListAsync();

            var response = Jugadores.Select(j => j.ToJugadorResponse()).ToList();
            
            return response;

        }






        //private readonly TorneoTenisContext _TorneoTenisContext;
        //public List<JugadorWithTorneoResponse> GetAllJugadorWithTorneo(string torneo)
        //{
        //throw new NotImplementedException();
        //}

    }
}
