using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Models.Request;
using TorneoTenis.API.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TorneoTenis.API.Services.Interfaces;

namespace TorneoTenis.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PartidoController : ControllerBase
    {
        private readonly IPartidoService _partidoService;

        public PartidoController(IPartidoService partidoService)
        {
            _partidoService = partidoService;
        }

        //READ TODOS LOS PARTIDOS:
        [HttpGet]
        [Route("/obtenerTodosLosPartidos")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof( List< PartidoResponse >), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> BuscarPartidos()
        {
            var partidos = await _partidoService.BuscarPartidos();
            return Ok(partidos);

        }

        //READ PARTIDO ESPECIFICO:
        [HttpGet]
        [Route("/obtenerPartidoEspecifico/{NombreDeTorneo}/{Etapa}/{Anio}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof( PartidoResponse ), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> BuscarPartidos([FromRoute] string NombreDeTorneo, [FromRoute] int Etapa, [FromRoute] int Anio)
        {
            var partido = await _partidoService.BuscarPartido(NombreDeTorneo,Etapa,Anio);

            return Ok(partido);

        }

        //PARTIDOS WITH TORNEO:
        [HttpGet]
        [Route("/PartidosPorTorneo/{nombreTorneo}/{anioTroneo}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof( List<PartidoResponse> ), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> BuscarPartidosPorTorneo([FromRoute] string nombreTorneo, [FromRoute] int anioTroneo)
        {
            var partidos = await _partidoService.BuscarPartidosPorTorneo(nombreTorneo, anioTroneo);

            return Ok(partidos);

        }

        //PARTIDOS WITH JUGADOR:
        [HttpGet]
        [Route("/PartidosPorJugador/{nombreJugador}/{apellidoJugador}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(List<PartidoResponse>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> BuscarPartidosPorJugador([FromRoute] string nombreJugador, [FromRoute] string apellidoJugador)
        {
            var partidos = await _partidoService.BuscarPartidosPorJugador(nombreJugador, apellidoJugador);

            return Ok(partidos);

        }

    }
}