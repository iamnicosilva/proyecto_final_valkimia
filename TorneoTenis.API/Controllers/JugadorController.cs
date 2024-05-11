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
    public class JugadorController : ControllerBase
    {
        private readonly IJugadorService _jugadorService;

        public JugadorController( IJugadorService jugadorService )
        {
            _jugadorService = jugadorService;
        }

        //CREATE JUGADOR:
        [HttpPost]
        [Route("")]
        public async Task AgregarJugador(JugadorRequest nuevoJugador)
        {
            await _jugadorService.AgregarJugador(nuevoJugador);

        }


        //READ JUGADOR:
        [HttpGet]
        [Route("/{id}")]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType(typeof(<Jugador>), (int)HttpStatusCode.OK)]
        public async Task <IActionResult> BuscarJugador(int id)
        {
            var jugador = await _jugadorService.BuscarJugador(id);
            return Ok(jugador);

        }

        //UPDATE JUGADOR:
        [HttpPut]
        [Route("/{id}")]
        public async Task ActualizarJugador(int id,JugadorRequest nuevoJugador)
        {
            await _jugadorService.ActualizarJugador(id, nuevoJugador);
        }

        //DELETE JUGADOR:
        [HttpPut]
        [Route("/delete/{id}")]
        public async Task EliminarJugador(int id)
        {
            await _jugadorService.EliminarJugador(id);
        }


        //IActionResult Post([FromBody] JugadorRequest jugadorRequest)












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
