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

        //CREATE PARTIDO:
        [HttpPost]
        [Route("/crearPartido")]
        public async Task AgregarPartido(PartidoRequest nuevoPartido)
        {
            await _partidoService.AgregarPartido(nuevoPartido);

        }


        //READ PARTIDO:
        [HttpGet]
        [Route("/obtenerPartido/{id}")]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType(typeof(<Partido>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> BuscarPartido(int id)
        {
            var partido = await _partidoService.BuscarPartido(id);
            return Ok(partido);

        }

        //UPDATE PARTIDO:
        [HttpPut]
        [Route("/actualizarPartido/{id}")]
        public async Task ActualizarPartido(int id, PartidoRequest nuevoPartido)
        {
            await _partidoService.ActualizarPartido(id, nuevoPartido);
        }

        //DELETE PARTIDO:
        [HttpPut]
        [Route("/eliminarPartido/{id}")]
        public async Task EliminarPartido(int id)
        {
            await _partidoService.EliminarPartido(id);
        }

        //READ TODOS LOS PARTIDOS:
        [HttpGet]
        [Route("/obtenerTodosLosPartidos")]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType(typeof(<Partido>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> BuscarPartidos()
        {
            var partido = await _partidoService.BuscarPartidos();
            return Ok(partido);

        }

    }
}