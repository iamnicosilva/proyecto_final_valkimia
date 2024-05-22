using TorneoTenis.API.Mappers;
using TorneoTenis.API.Models.Request;
using TorneoTenis.API.Models.Response;
using TorneoTenis.API.Repository;
using TorneoTenis.API.Services.Interfaces;
using TorneoTenis.API.Repository.CommonQuerys.Interfaces;
using TorneoTenis.API.Models.DTO;
using escuela.API.Exceptions;

namespace TorneoTenis.API.Services
{
    public class JugadorService : IJugadorService
    {
        private readonly TorneoTenisContext _torneoTenisContext;
        private readonly IJugadorRepository _jugadorRepository;
        private readonly IGeneroRepository _generoRepository;

        public JugadorService(TorneoTenisContext torneoTenisContex,
            IJugadorRepository jugadorRepository,
            IGeneroRepository generoRepository)
        {
            _torneoTenisContext = torneoTenisContex;
            _jugadorRepository = jugadorRepository;
            _generoRepository = generoRepository;
        }
        private async Task VerificarJugador(JugadorRequest jugador, int IdGenero)
        {
            var PotencialJugadorDuplicado_Id = await _jugadorRepository
                .ObtenerIdPorNombreYApellido(jugador.Nombre, jugador.Apellido);

            if (PotencialJugadorDuplicado_Id != 0)
                throw new BadRequestException("Error al agregar jugador", "Este Jugador ya está registrado");

            var nuevoJugadorAAgregar = jugador.ToJugador(IdGenero);

            _torneoTenisContext.Add(nuevoJugadorAAgregar);
        }

        public async Task AgregarJugador(JugadorRequest nuevoJugador, int IdGenero)
        {
           
            await VerificarJugador(nuevoJugador, IdGenero);

            await _torneoTenisContext.SaveChangesAsync();
        }

        public async Task AgregarJugadorDesdeLista(List<JugadorRequest> nuevosJugadores, int IdGenero)
        {

            foreach (var jugador  in nuevosJugadores)
            {
                await VerificarJugador(jugador, IdGenero);
            }

            await _torneoTenisContext.SaveChangesAsync();
        }

        public async Task<JugadorResponse> BuscarJugador(string nombre, string apellido)
        {

            var JugadorEspecífico = await _jugadorRepository
                .ObtenerJugadorPorNombreYApellido(nombre, apellido);

            if (JugadorEspecífico == null || JugadorEspecífico.Eliminado)
                throw new BadRequestException("Problema con buscar jugador","El jugador no se encuentra");

            var Genero = await _generoRepository.ObtenerNombrePorId(JugadorEspecífico.IdGenero);

            var response = JugadorEspecífico.ToJugadorResponse(Genero);

            return response;

        }

        public async Task ActualizarJugador(JugadorUpdateRequest JugadorActualizado, string nombre, string apellido)
        {

            var JugadorEspecífico = await _jugadorRepository
                .ObtenerJugadorPorNombreYApellido(nombre, apellido);

            if (JugadorEspecífico == null)
                throw new BadRequestException("Problema al actualizar jugador","El jugador no se encuentra");

            var PotencialJugadorDuplicado_Id = await _jugadorRepository
                .ObtenerIdPorNombreYApellido(JugadorActualizado.Nombre, JugadorActualizado.Apellido);

            if (PotencialJugadorDuplicado_Id != 0)
                throw new BadRequestException("Problema al actualizar jugador","Este nombre ya esta registrado");

            JugadorEspecífico.ToJugadorUpdate(JugadorActualizado);

            await _torneoTenisContext.SaveChangesAsync();
        }

        public async Task EliminarJugador(JugadorDTO jugador)
        {
            var JugadorEspecífico = await _jugadorRepository
                .ObtenerJugadorPorNombreYApellido(jugador.Nombre, jugador.Apellido);

            if (JugadorEspecífico == null || JugadorEspecífico.Eliminado)
                throw new BadRequestException("Problema al eliminar jugador","El jugador no se encuentra");

            JugadorEspecífico.ToJugadorDelete();

            await _torneoTenisContext.SaveChangesAsync();
        }

        
        public async Task<List<JugadorResponse>> BuscarJugadores()
        {
            var Jugadores = await _jugadorRepository.ObtenerTodosLosJugadores();
                        
            var generoDiccionario = await _generoRepository.ObtenerDiccionarioDeNombresDeGeneros();

            var response = Jugadores.Select(j => j.ToJugadorResponse(generoDiccionario[j.IdGenero])).ToList();

            return response;
        }

    }
}
