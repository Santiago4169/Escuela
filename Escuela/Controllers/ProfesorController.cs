using Business.Interfaces;
using Core.ModelsView;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Escuela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private readonly IProfesorServices _iprofesor;

        public ProfesorController(IProfesorServices iprofesor)
        {
            _iprofesor = iprofesor;
        }
        // GET: api/<ProfesorController>
        [HttpGet]

        public async Task<ActionResult> Get()
        {
            try
            {
                var ListServicio = _iprofesor.ConsultarServicies();
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

        // GET api/<ProfesorController>/5
        [HttpGet("{id}")]

        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var profesor = _iprofesor.ConsultarPorCodigo(id);

                if (profesor == null)
                    return NotFound();

                return Ok(profesor);
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

        // POST api/<ProfesorController>
        [HttpPost]

        public async Task<IActionResult> Post([FromBody] ProfesorView ProfesorNuevo)
        {
            try
            {
                _iprofesor.Agregar(ProfesorNuevo);
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

        // PUT api/<ProfesorController>/5
        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, [FromBody] ProfesorView ProfesorEditar)
        {
            try
            {
                _iprofesor.Editar(id, ProfesorEditar);
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

        // DELETE api/<ProfesorController>/5
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _iprofesor.Eliminar(id);
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
