using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Models.Request;
using TorneoTenis.API.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TorneoTenis.API.Services.Interfaces;
using TorneoTenis.API.Models.DTO;

namespace TorneoTenis.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TorneoController : ControllerBase
    {
        private readonly ITorneoService _torneoService;

        public TorneoController(ITorneoService torneoService )
        {
            _torneoService = torneoService;
        }

        // CREAR TORNEO MASCULINO COMPLETO CON JUGADORES EXISTENTES
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(JugadorResponse), (int)HttpStatusCode.OK)]
        [Route("/TorneoMasculinoDeRegistrados")]
        public async Task<JugadorResponse> CrearTorneoMasculinoDeRegistrados(TorneoRequestExistentes TorneoRequest)
        {
            var ganador = await _torneoService.CrearTorneo(TorneoRequest, 2);
            return ganador;
           
        }

        // CREAR TORNEO FEMENINO COMPLETO CON JUGADORAS EXISTENTES
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(JugadorResponse), (int)HttpStatusCode.OK)]
        [Route("/TorneoFemeninoDeRegistradas")]
        public async Task<JugadorResponse> CrearTorneoFemeninoDeRegistradas(TorneoRequestExistentes TorneoRequest)
        {
            var ganador = await _torneoService.CrearTorneo(TorneoRequest, 1);
            return ganador;

        }

        //CREAR TORNEO MASCULINO COMPLETO CREANDO JUGADORES
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(JugadorResponse), (int)HttpStatusCode.OK)]
        [Route("/TorneoMasculinoNuevosJugadores")]
        public async Task<JugadorResponse> CrearTorneoMasculinoDeNuevos(TorneoRequestNuevos TorneoRequest)
        {
            var ganador = await _torneoService.RegistrarJugadoresYCrearTorneo(TorneoRequest, 2);
            return ganador;

        }

        //CREAR TORNEO FEMENINO COMPLETO CREANDO JUGADORAS
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(JugadorResponse), (int)HttpStatusCode.OK)]
        [Route("/TorneoFemeninoNuevasJugadoras")]
        public async Task<JugadorResponse> CrearTorneoFemeninoDeNuevas(TorneoRequestNuevos TorneoRequest)
        {
            var ganadora = await _torneoService.RegistrarJugadoresYCrearTorneo(TorneoRequest, 1);
            return ganadora;

        }


        //READ TORNEO:
        [HttpGet]
        [Route("/obtener/{nombre}/{anio}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(List<TorneoResponse>), (int)HttpStatusCode.OK)]
        public async Task <IActionResult> BuscarTorneo(string nombre, int anio)
        {
            var torneo = await _torneoService.BuscarTorneo(nombre, anio);
            return Ok(torneo);

        }


        //DELETE TORNEO:
        [HttpPut]
        [Route("/eliminar/")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task EliminarTorneo(TorneoDTO torneo)
        {
            await _torneoService.EliminarTorneo(torneo);
        }

        //READ TODOS LOS TORNEOES:
        [HttpGet]
        [Route("/obtenerTodos")]
        [ProducesResponseType(typeof(List<TorneoWithGeneroDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> BuscarTorneos()
        {
            var torneos = await _torneoService.BuscarTorneos();

            return Ok(torneos);

        }




    }
}
