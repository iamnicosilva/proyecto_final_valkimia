using Azure;
using Microsoft.EntityFrameworkCore;
using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Repository.CommonQuerys.Interfaces;

namespace TorneoTenis.API.Repository.CommonQuerys
{

    public class PartidoRepository : IPartidoRepository
    {
        private readonly TorneoTenisContext _context;

        public PartidoRepository(TorneoTenisContext context)
        {
            _context = context;
        }


        public async Task<List<Partido>> BuscarPartidosPorJugadorId(int jugadorId)
        {
            return await _context.Set<Partido>()
                                 .Where(a => a.IdGanador == jugadorId || a.IdPerdedor == jugadorId)
                                 .ToListAsync();
        }

        public async Task<int> BuscarIdPorTorneoYEtapa(int torneoId, int etapa)
        {
            return await _context.Set<Partido>()
                                 .Where(a => a.IdTorneo == torneoId &&
                                 a.Etapa == etapa).Select(a => a.Id)
                                 .FirstOrDefaultAsync();
        }

        public async Task<Partido> BuscarPartidoPorTorneoYEtapa(int torneoId, int etapa)
        {
            return await _context.Set<Partido>()
                                 .Where(a => a.IdTorneo == torneoId &&
                                 a.Etapa == etapa).FirstOrDefaultAsync();
        }

        public async Task<List<Partido>> BuscarPartidosPorTorneoId(int torneoId)
        {
            return await _context.Set<Partido>()
                                 .Where(a => a.IdTorneo == torneoId).ToListAsync();
        }

        public async Task<List<Partido>> BuscarTodosLosPartidos()
        {
            return await _context.Set<Partido>()
                                 .ToListAsync();
        }
    }
}
