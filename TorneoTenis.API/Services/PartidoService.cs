using TorneoTenis.API.Mappers;
using TorneoTenis.API.Models.Request;
using TorneoTenis.API.Models.Response;
using TorneoTenis.API.Repository;
using TorneoTenis.API.Services.Interfaces;
using TorneoTenis.API.Repository.CommonQuerys.Interfaces;
using TorneoTenis.API.Models.Entities;
using escuela.API.Exceptions;

namespace TorneoTenis.API.Services
{
    public class PartidoService : IPartidoService
    {
        private readonly TorneoTenisContext _torneoTenisContext;
        private readonly ITorneoRepository _torneoRepository;
        private readonly IJugadorRepository _jugadorRepository;
        private readonly IPartidoRepository _partidoRepository;


        public PartidoService(TorneoTenisContext torneoTenisContex, 
            ITorneoRepository torneoRepository, IJugadorRepository jugadorRepository, 
            IPartidoRepository partidoRepository)
        {
            _torneoTenisContext = torneoTenisContex;
            _torneoRepository = torneoRepository;
            _jugadorRepository = jugadorRepository;
            _partidoRepository = partidoRepository;
        }

        public async Task CrearPartido(PartidoRequest nuevoPartido)
        {
            var potencialPartidoDuplicado_Id = await _partidoRepository
                .BuscarIdPorTorneoYEtapa(nuevoPartido.IdTorneo, nuevoPartido.Etapa);

            if (potencialPartidoDuplicado_Id != 0)
                throw new BadRequestException("Problema al registrar un partido", 
                    "Se intenta sobreescribir una etapa de torneo");

            var Fecha = DateTime.Now;

            var nuevoPartidoAAgregar = nuevoPartido.ToPartido(Fecha);

            _torneoTenisContext.Add(nuevoPartidoAAgregar);

            await _torneoTenisContext.SaveChangesAsync();
        }


        public async Task<PartidoResponse> BuscarPartido(string torneo, int anio, int etapa)
        {
            var IdTorneo = await _torneoRepository.ObtenerIdPorNombreYAnio(torneo, anio);
            var PartidoEspecífico = await _partidoRepository.BuscarPartidoPorTorneoYEtapa(IdTorneo,etapa);

            if (PartidoEspecífico == null)
                throw new BadRequestException("Problema al buscar partido", "El partido no se encuentra");

            return await MapPartidoToResponse(PartidoEspecífico);
        }

        public async Task<List<PartidoResponse>> BuscarPartidos()
        {
            var Partidos = await _partidoRepository.BuscarTodosLosPartidos();

            var PartidosResponse = new List<PartidoResponse>();

            foreach (var partido in Partidos)
            {
                PartidosResponse.Add(await MapPartidoToResponse(partido));
            }

             return PartidosResponse;
        }


        public async Task<List<PartidoResponse>> BuscarPartidosPorTorneo(string nombreTorneo, int anioTroneo)
        {
            var TorneoId = await _torneoRepository
                .ObtenerIdPorNombreYAnio(nombreTorneo, anioTroneo);

            if (TorneoId == 0) 
                throw new BadRequestException("Problema al Buscar partido", "El torneo no se encuentra"); 

            var Partidos = await _partidoRepository.BuscarPartidosPorTorneoId(TorneoId);

            var PartidosResponse = new List<PartidoResponse>();

            foreach (var partido in Partidos)
            {
                PartidosResponse.Add(await MapPartidoToResponse(partido));
            }

            return PartidosResponse;
        }

        public async Task<List<PartidoResponse>> BuscarPartidosPorJugador(string nombreJugador, string apellidoJugador)
        {
            var JugadorId = await _jugadorRepository
                .ObtenerIdPorNombreYApellido(nombreJugador, apellidoJugador);

            if (JugadorId == 0)
                throw new BadRequestException("Problema al buscar partidos", "El jugador no se encuentra"); 

            var Partidos = await _partidoRepository.BuscarPartidosPorJugadorId(JugadorId);

            var PartidosResponse = new List<PartidoResponse>();

            foreach (var partido in Partidos)
            {
                PartidosResponse.Add(await MapPartidoToResponse(partido));
            }

            return PartidosResponse;
        }

        private async Task<PartidoResponse> MapPartidoToResponse(Partido partido)
        {
            var ganador = await _jugadorRepository.ObtenerJugadorPorId(partido.IdGanador);
            var perdedor = await _jugadorRepository.ObtenerJugadorPorId(partido.IdPerdedor);
            var ganadorDTO = ganador.ToJugadorDTO();
            var perdedorDTO = perdedor.ToJugadorDTO();

            return partido.ToPartidoResponse(ganadorDTO, perdedorDTO);
        }
    }
}
