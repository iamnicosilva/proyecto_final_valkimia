using Microsoft.EntityFrameworkCore;
using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Mappers;
using TorneoTenis.API.Models.Request;
using TorneoTenis.API.Models.Response;
using TorneoTenis.API.Repository;
using TorneoTenis.API.Services.Interfaces;

namespace TorneoTenis.API.Services
{
    public class PartidoService : IPartidoService
    {
        private readonly TorneoTenisContext _torneoTenisContext;

        public PartidoService(TorneoTenisContext torneoTenisContex)
        {
            _torneoTenisContext = torneoTenisContex;
        }

        public async Task AgregarPartido(PartidoRequest nuevoPartido)
        {
            var potencialPartidoDuplicado = await _torneoTenisContext.Set<Partido>()
                                            .Where(a => a.IdTorneo == nuevoPartido.IdTorneo)
                                            .Where(a => a.Etapa == nuevoPartido.Etapa)
                                            .FirstOrDefaultAsync();

            if (potencialPartidoDuplicado != null)
                throw new Exception("Este Partido ya esta registrado");

            var nuevoPartidoAAgregar = nuevoPartido.ToPartido();

            _torneoTenisContext.Add(nuevoPartidoAAgregar);

            await _torneoTenisContext.SaveChangesAsync();
        }


        public async Task<PartidoResponse> BuscarPartido(int id)
        {

            // ESTO SE DEBE PASAR A UN SERVICIO BUSCAR_JUGADOR_POR_ID:

            var PartidoEspecífico = await _torneoTenisContext.Set<Partido>()
                                    .Where(a =>a.Id == id).FirstOrDefaultAsync();

            if (PartidoEspecífico == null || PartidoEspecífico.Eliminado) 
                throw new Exception("El partido no se encuentra");
            // fin

            var response = PartidoEspecífico.ToPartidoResponse();

            return response;
            
        }


        public async Task ActualizarPartido(int id,PartidoRequest PartidoActualizado)
        {

            var partidoExistente = await _torneoTenisContext.Set<Partido>()
                        .Where(a => a.Id == id).FirstOrDefaultAsync();

            if (partidoExistente == null || partidoExistente.Eliminado)
            {
                throw new Exception("El partido no se encuentra");
            }

            partidoExistente.ToPartidoUpdate(PartidoActualizado);

            await _torneoTenisContext.SaveChangesAsync();
        }

        public async Task EliminarPartido(int id)
        {

            var partidoExistente = await _torneoTenisContext.Set<Partido>()
                        .Where(a => a.Id == id).FirstOrDefaultAsync();

            if (partidoExistente == null || partidoExistente.Eliminado)
            {
                throw new Exception("El partido no se encuentra");
            }

            partidoExistente.ToPartidoDelete();

            await _torneoTenisContext.SaveChangesAsync();
        }


        public async Task<List<PartidoResponse>> BuscarPartidos()
        {

            var Partidos = await _torneoTenisContext.Set<Partido>()
                                            .Where(a =>a.Eliminado == false).ToListAsync();

            var response = Partidos.Select(j => j.ToPartidoResponse()).ToList();
            
            return response;

        }






        //private readonly TorneoTenisContext _TorneoTenisContext;
        //public List<PartidoWithTorneoResponse> GetAllPartidoWithTorneo(string torneo)
        //{
        //throw new NotImplementedException();
        //}

    }
}
