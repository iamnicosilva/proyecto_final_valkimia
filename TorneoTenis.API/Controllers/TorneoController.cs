using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Models.Request;
using TorneoTenis.API.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TorneoTenis.API.Services.Interfaces;
using TorneoTenis.API.Models.Response.DTO;

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

        //CREATE TORNEO:
        [HttpPost]
        [Route("/crear")]
        public async Task AgregarTorneo(TorneoRequest nuevoTorneo)
        {
            await _torneoService.AgregarTorneo(nuevoTorneo);

        }


        //READ TORNEO:
        [HttpGet]
        [Route("/obtener/{id}")]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType(typeof(<Torneo>), (int)HttpStatusCode.OK)]
        public async Task <IActionResult> BuscarTorneo(int id)
        {
            var torneo = await _torneoService.BuscarTorneo(id);
            return Ok(torneo);

        }

        //UPDATE TORNEO:
        [HttpPut]
        [Route("/actualizar/{id}")]
        public async Task ActualizarTorneo(int id,TorneoRequest nuevoTorneo)
        {
            await _torneoService.ActualizarTorneo(id, nuevoTorneo);
        }

        //DELETE TORNEO:
        [HttpPut]
        [Route("/eliminar/{id}")]
        public async Task EliminarTorneo(int id)
        {
            await _torneoService.EliminarTorneo(id);
        }

        //READ TODOS LOS TORNEOES:
        [HttpGet]
        [Route("/obtenerTodos")]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType(typeof(<Torneo>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> BuscarTorneos()
        {
            var torneo = await _torneoService.BuscarTorneos();
            return Ok(torneo);

        }


        //IActionResult Post([FromBody] TorneoRequest torneoRequest)

        //AUTOCOMPLETAR TORNEO (TOMA LOS JUGADORES Y TE ARMA TODO)
        [HttpPost]
        [Route("/crearTorneoCompleto")]
        public async Task AgregarTorneoCompleto(TorneoCompletoRequest torneoCompleto)
        {
            await _torneoService.AgregarTorneoCompleto(torneoCompleto);

        }





        [HttpPost]
        [Route("/crearTorneoCompletoTest")]
        public async Task AgregarTorneoCompletoTest(List<JugadorDTO> jugadores)
        {
            await _torneoService.AgregarTorneoCompletoTest(jugadores);


        }


        //AGREGAR ENDPOINTS CON CONSULTAS VARIAS (TORNEO POR AÑO, POR JUGADOR, POR TIPO DE TORNEO, ETC)









        //[HttpGet]
        //[Route("GetAllDocentesWithMaterias/{materia}")]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType(typeof(List<DocenteWithMateriaResponse>),(int)HttpStatusCode.OK)]
        //public IActionResult GetAllDocentesWithMaterias(string materia)
        //{
        //    return Ok();
        //}




        //[HttpGet]
        //[Route("Persona/{id}")]
        //public IActionResult Get(int id)
        //{
        //    // TRAER UN ALUMNO ESPECIFICO DE LA DB
        //    //var AlumnoEspecifico = ListaAlumnos.FirstOrDefault(a => a.Id == id);

        //    return Ok();
        //}




        //[HttpPut]
        //[Route("Alumno/{id}")]
        //public IActionResult Put(int id, [FromBody] PersonaRequest alumnoRequest)
        //{
        //    //BUSCAR EN LA DB EL ALUMNO ESPECIFICO Y ACTUALIZAR SUS DATOS

        //    var AlumnoEspecifico = ListaAlumnos.FirstOrDefault(a => a.Id == id);

        //    AlumnoEspecifico.Nombre = alumnoRequest.Nombre;
        //    AlumnoEspecifico.Apellido = alumnoRequest.Apellido;
        //    AlumnoEspecifico.DNI = alumnoRequest.DNI;

        //    return Ok(ListaAlumnos);
        //}

        //[HttpDelete]
        //[Route("Alumno/{id}")]
        //public IActionResult Delete(int id)
        //{
        //    //BUSCAR EN LA DB EL ALUMNO ESPECIFICO Y ELIMINARLO (CAMBIAR A TRUE SU ATRIBUTO ELIMINADO)

        //    var AlumnoEspecifico = ListaAlumnos.FirstOrDefault(a => a.Id == id);

        //    AlumnoEspecifico.Eliminado = true;

        //    return Ok(ListaAlumnos);
        //}
    }
}
