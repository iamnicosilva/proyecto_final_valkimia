using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Mappers;
using TorneoTenis.API.Models.Request;
using TorneoTenis.API.Models.Response;
using TorneoTenis.API.Repository;
using TorneoTenis.API.Services.Interfaces;
using TorneoTenis.API.Repository.CommonQuerys.Interfaces;
using TorneoTenis.API.Services.Auxiliares.Interfaces;
using TorneoTenis.API.Models.DTO;
using escuela.API.Exceptions;

namespace TorneoTenis.API.Services
{
    public class TorneoService : ITorneoService
    {
        private readonly TorneoTenisContext _torneoTenisContext;
        private readonly ITorneoRepository _torneoRepository;
        private readonly IJugadorRepository _jugadorRepository;
        private readonly IPartidoRepository _partidoRepository;
        private readonly IGeneroRepository _generoRepository;
        private readonly IJugarTorneoService _jugarTorneoService;
        private readonly IJugadorService _jugadorService;
        

        public TorneoService(TorneoTenisContext torneoTenisContex, 
            ITorneoRepository torneoRepository, IJugadorRepository jugadorRepository,
            IPartidoRepository partidoRepository, IGeneroRepository generoRepository,
            IJugarTorneoService jugarTorneoService, IJugadorService jugadorService)
        {
            _torneoTenisContext = torneoTenisContex;
            _torneoRepository = torneoRepository;
            _jugadorRepository = jugadorRepository;
            _partidoRepository = partidoRepository;
            _generoRepository = generoRepository;
            _jugarTorneoService = jugarTorneoService;
            _jugadorService = jugadorService;
        }


        public async Task<TorneoResponse> BuscarTorneo(string nombre,int anio)
        {
            var TorneoId = await _torneoRepository
                .ObtenerIdPorNombreYAnio(nombre, anio);

            if (TorneoId == 0) 
                throw new BadRequestException("Problema al buscar torneo","El torneo no se encuentra");

            var PartidosDelTorneo = await _partidoRepository.BuscarPartidosPorTorneoId(TorneoId);

            //MAQUETADO DE RESPONSE

            var Fixture = new List<PartidoResponse>();

            foreach (var partido in PartidosDelTorneo)
            {
                var ganador = await _jugadorRepository.ObtenerJugadorPorId(partido.IdGanador);
                var perdedor = await _jugadorRepository.ObtenerJugadorPorId(partido.IdPerdedor);
                var ganadorDTO = ganador.ToJugadorDTO();
                var perdedorDTO = perdedor.ToJugadorDTO();

                Fixture.Add(partido.ToPartidoResponse(ganadorDTO, perdedorDTO));
            }

            var response = Fixture.ToTorneoResponse(nombre,anio);

            return response;
            
        }


        public async Task EliminarTorneo(TorneoDTO torneo)
        {

            var TorneoEspecifico = await _torneoRepository
                .ObtenerTorneoPorNombreYAnio(torneo.Nombre, torneo.Anio);

            if (TorneoEspecifico == null || TorneoEspecifico.Eliminado)
                throw new BadRequestException("Problema al eliminar torneo","El torneo no se encuentra");

            TorneoEspecifico.ToTorneoDelete();

            await _torneoTenisContext.SaveChangesAsync();
        }


        public async Task<List<TorneoWithGeneroDTO>> BuscarTorneos()
        {

            var Torneos = await _torneoRepository.ObtenerTodosLosTorneos();

            var generoDiccionario = await _generoRepository.ObtenerDiccionarioDeDescripcionesDeGeneros();

            var response = Torneos.Select(j => j.ToTorneoWithGeneroDTO(generoDiccionario[j.IdGenero])).ToList();
            
            return response;

        }


        public async Task<JugadorResponse> CrearTorneo(TorneoRequestExistentes TorneoRequest, int IdGenero)
        {

            ////////////////////VERIFICACIONES:

            var JugadoresDelTorneo = await VerificarYArmarLista(TorneoRequest, IdGenero);

            ////////////////////DESARROLLO:

            var nuevoTorneoAAgregar = TorneoRequest.Torneo.ToTorneo(IdGenero);

            _torneoTenisContext.Add(nuevoTorneoAAgregar);
            await _torneoTenisContext.SaveChangesAsync();

            var IdTorneo = nuevoTorneoAAgregar.Id;

            int etapaInicial = JugadoresDelTorneo.Count - 1;

            // INICIAR EL TORNEO
            var torneo = await _jugarTorneoService.JugarRondasDeTorneo(JugadoresDelTorneo, IdTorneo, etapaInicial);

            if (torneo == null) 
                throw new BadRequestException("Error en el torneo", "No se pudo conseguir el ganador");

            var generoDiccionario = await _generoRepository.ObtenerDiccionarioDeNombresDeGeneros();

            var ganador = torneo.ToJugadorResponse(generoDiccionario[IdGenero]);

            return ganador;

        }

        public async Task<JugadorResponse> RegistrarJugadoresYCrearTorneo(TorneoRequestNuevos torneoRequest, int IdGenero)
        {
            await _jugadorService.AgregarJugadorDesdeLista(torneoRequest.Jugadores, IdGenero);

            var torneoExistentes = torneoRequest.NuevosToTorneoExistentes();

            return await CrearTorneo(torneoExistentes, IdGenero);
        }

        private async Task<List<Jugador>> VerificarYArmarLista(TorneoRequestExistentes TorneoRequest, int IdGenero)
        {
            // VERIFICAR QUE EL TORNEO NO ESTÉ YA EN LA DB
            var potencialTorneoDuplicadoId = await _torneoRepository
                .ObtenerIdPorNombreYAnio(TorneoRequest.Torneo.Nombre, TorneoRequest.Torneo.Anio);

            if (potencialTorneoDuplicadoId != 0)
                throw new BadRequestException("Problema al crear torneo", "Este Torneo ya está registrado");

            // VERIFICAR LA CANTIDAD DE JUGADORES
            var CantidadDeJugadores = TorneoRequest.Jugadores.Count();
            if (CantidadDeJugadores == 0 || (CantidadDeJugadores & (CantidadDeJugadores - 1)) != 0)
                throw new BadRequestException("Problema al crear torneo", "La cantidad de participantes no es válida (Debe ser potencia de 2)");

            // ARMAR LA LISTA DE JUGADORES Y VERIFICAR GENERO
            List<Jugador> JugadoresDelTorneo = new List<Jugador>();
            HashSet<string> jugadoresUnicos = new HashSet<string>();

            foreach (var i in TorneoRequest.Jugadores)
            {
                var JugadorEspecifico = await _jugadorRepository
                    .ObtenerJugadorPorNombreYApellido(i.Nombre, i.Apellido);

                if (JugadorEspecifico == null)
                    throw new BadRequestException("Problema al crear torneo", $"No se encuentra el registro de {i.Nombre} {i.Apellido}");
                if (JugadorEspecifico.IdGenero != IdGenero)
                    throw new BadRequestException("Problema al crear torneo", $"El género del torneo no es compatible con {i.Nombre} {i.Apellido}");

                var jugadorKey = $"{JugadorEspecifico.Nombre} {JugadorEspecifico.Apellido}";
                if (jugadoresUnicos.Contains(jugadorKey))
                    throw new BadRequestException("Problema al crear torneo", $"El jugador {i.Nombre} {i.Apellido} está duplicado en el torneo");

                jugadoresUnicos.Add(jugadorKey);
                JugadoresDelTorneo.Add(JugadorEspecifico);
            }

            return JugadoresDelTorneo;
        }

    }
}
