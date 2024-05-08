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









        //private readonly TorneoTenisContext _TorneoTenisContext;
        //public List<JugadorWithTorneoResponse> GetAllJugadorWithTorneo(string torneo)
        //{
        //throw new NotImplementedException();
        //}

    }
}
