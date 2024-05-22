using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Models.Request;
using TorneoTenis.API.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TorneoTenis.API.Services.Interfaces;
using TorneoTenis.API.Models.DTO;
using System.Collections.Generic;

namespace TorneoTenis.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JugadorController : ControllerBase
    {
        private readonly IJugadorService _jugadorService;

        public JugadorController( IJugadorService jugadorService )
        {
            _jugadorService = jugadorService;
        }

        //CREATE JUGADOR:
        [HttpPost]
        [Route("/crearJugadorHombre")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task AgregarJugadorHombre(JugadorRequest nuevoJugador)
        {
            await _jugadorService.AgregarJugador(nuevoJugador, 2);

        }
        //CREATE JUGADORA:
        [HttpPost]
        [Route("/crearJugadoraMujer")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task AgregarJugadoraMujer(JugadorRequest nuevaJugadora)
        {
            await _jugadorService.AgregarJugador(nuevaJugadora, 1);

        }

        //CREATE JUGADORES DESDE LISTA:
        [HttpPost]
        [Route("/crearJugadoresHombresDesdeLista")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task AgregarJugadoresHombres(List<JugadorRequest> nuevosJugadores)
        {
            await _jugadorService.AgregarJugadorDesdeLista(nuevosJugadores, 2);

        }
        //CREATE JUGADORAS DESDE LISTA:
        [HttpPost]
        [Route("/crearJugadorasMujeresDesdeLista")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task AgregarJugadorasMujeres(List<JugadorRequest> nuevasJugadoras)
        {
            await _jugadorService.AgregarJugadorDesdeLista(nuevasJugadoras, 1);

        }


        //READ JUGADOR:
        [HttpGet]
        [Route("/obtenerJugador/{nombre}/{apellido}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(JugadorResponse), (int) HttpStatusCode.OK)]
        public async Task <IActionResult> BuscarJugador([FromRoute] string nombre, [FromRoute] string apellido)
        {
            var jugador = await _jugadorService.BuscarJugador(nombre , apellido);
            return Ok(jugador);

        }

        //UPDATE JUGADOR:
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Route("/actualizarJugador/{nombre}/{apellido}")]
        public async Task ActualizarJugador([FromRoute] string nombre, [FromRoute] string apellido, JugadorUpdateRequest Jugador)
        {
            await _jugadorService.ActualizarJugador(Jugador, nombre, apellido);
        }

        //DELETE JUGADOR:
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Route("/eliminarJugador/")]
        public async Task EliminarJugador(JugadorDTO jugador)
        {
            await _jugadorService.EliminarJugador(jugador);
        }

        //READ TODOS LOS JUGADORES:
        [HttpGet]
        [Route("/obtenerTodosLosJugadores")]
        [ProducesResponseType(typeof(List<JugadorResponse>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> BuscarJugadores()
        {
            var jugadores = await _jugadorService.BuscarJugadores();
            return Ok(jugadores);

        }

        //CREAR JUGADORES A PARTIR DE UNA LISTA
    }
}
