using Microsoft.EntityFrameworkCore;
using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Repository.CommonQuerys.Interfaces;

namespace TorneoTenis.API.Repository.CommonQuerys
{
    public class JugadorRepository : IJugadorRepository
    {
        private readonly TorneoTenisContext _context;

        public JugadorRepository(TorneoTenisContext context)
        {
            _context = context;
        }

        public async Task<int> ObtenerIdPorNombreYApellido(string nombre, string apellido)
        {
            return await _context.Set<Jugador>()
                                 .Where(a => a.Nombre == nombre && a.Apellido == apellido)
                                 .Select(a => a.Id)
                                 .FirstOrDefaultAsync();
        }

        public async Task<Jugador> ObtenerJugadorPorNombreYApellido(string nombre, string apellido)
        {
            return await _context.Set<Jugador>()
                                 .Where(a => a.Nombre == nombre && a.Apellido == apellido)
                                 .FirstOrDefaultAsync();
        }

        public async Task<List<Jugador>> ObtenerTodosLosJugadores()
        {
            return await _context.Set<Jugador>()
                                 .Where(a => a.Eliminado == false).ToListAsync();
        }

        public async Task<Jugador> ObtenerJugadorPorId(int Id)
        {
            return await _context.Set<Jugador>()
                                 .Where(a => a.Id == Id)
                                 .FirstOrDefaultAsync();
        }
    }

    
}
