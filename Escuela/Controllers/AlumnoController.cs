using Business.Interfaces;
using Core.ModelsView;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Escuela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly IAlumnoServices _ialumno;

        public AlumnoController(IAlumnoServices ialumno)
        {
            _ialumno = ialumno;
        }
        // GET: api/<AlumnoController>
        [HttpGet]

        public async Task<ActionResult> Get()
        {
            try
            {
                var ListServicio = _ialumno.ConsultarServicies();
                return Ok(ListServicio);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<AlumnoController>/5
        [HttpGet("{id}")]

        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var alumno = _ialumno.ConsultarPorCodigo(id);

                if (alumno == null)
                    return NotFound(); // devolver NotFound si el alumno no se encuentra

                return Ok(alumno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<AlumnoController>
        [HttpPost]

        public async Task<IActionResult> Post([FromBody] AlumnoView AlumnoNuevo)
        {
            try
            {
                _ialumno.Agregar(AlumnoNuevo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<AlumnoController>/5
        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, [FromBody] AlumnoView AlumnoEditar)
        {
            try
            {
                _ialumno.Editar(id, AlumnoEditar);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<AlumnoController>/5
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _ialumno.Eliminar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //public void Delete(int id)
        //{
        //}
    }
}
