using Microsoft.EntityFrameworkCore;
using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Repository.CommonQuerys.Interfaces;

namespace TorneoTenis.API.Repository.CommonQuerys
{

    public class TorneoRepository : ITorneoRepository
    {
        private readonly TorneoTenisContext _context;

        public TorneoRepository(TorneoTenisContext context)
        {
            _context = context;
        }

        public async Task<int> ObtenerIdPorNombreYAnio(string nombreTorneo, int anioTorneo)
        {
            return await _context.Set<Torneo>()
                                            .Where(a => a.Nombre == nombreTorneo &&
                                            a.Anio == anioTorneo)
                                            .Select(a => a.Id)
                                            .FirstOrDefaultAsync();
        }

        public async Task<Torneo> ObtenerTorneoPorNombreYAnio(string nombreTorneo, int anioTorneo)
        {
            return await _context.Set<Torneo>()
                                            .Where(a => a.Nombre == nombreTorneo &&
                                            a.Anio == anioTorneo)
                                            .FirstOrDefaultAsync();
        }

        public async Task<List<Torneo>> ObtenerTodosLosTorneos()
        {
            return await _context.Set<Torneo>().ToListAsync();
        }
    }
}
