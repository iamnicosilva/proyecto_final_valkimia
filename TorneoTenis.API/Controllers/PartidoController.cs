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

        public PartidoController( IPartidoService partidoService )
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
        public async Task <IActionResult> BuscarPartido(int id)
        {
            var partido = await _partidoService.BuscarPartido(id);
            return Ok(partido);

        }

        //UPDATE PARTIDO:
        [HttpPut]
        [Route("/actualizarPartido/{id}")]
        public async Task ActualizarPartido(int id,PartidoRequest nuevoPartido)
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


        //IActionResult Post([FromBody] PartidoRequest partidoRequest)












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
