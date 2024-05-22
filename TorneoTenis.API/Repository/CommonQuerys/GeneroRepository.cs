using Microsoft.EntityFrameworkCore;
using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Repository.CommonQuerys.Interfaces;

namespace TorneoTenis.API.Repository.CommonQuerys
{

    public class GeneroRepository : IGeneroRepository
    {
        private readonly TorneoTenisContext _context;

        public GeneroRepository(TorneoTenisContext context)
        {
            _context = context;
        }

        public async Task<string> ObtenerNombrePorId(int Id)
        {
            return await _context.Set<Genero>()
                                            .Where(a => a.Id == Id)
                                            .Select(a => a.Nombre)
                                            .FirstOrDefaultAsync();
        }


        public async Task<Dictionary<int, string>> ObtenerDiccionarioDeNombresDeGeneros()
        {
            var Generos = await  _context.Set<Genero>().ToListAsync();

            return Generos.ToDictionary(g => g.Id, g => g.Nombre);
            
        }

        public async Task<Dictionary<int, string>> ObtenerDiccionarioDeDescripcionesDeGeneros()
        {
            var Generos = await _context.Set<Genero>().ToListAsync();

            return Generos.ToDictionary(g => g.Id, g => g.Descripcion);

        }

    }
}
