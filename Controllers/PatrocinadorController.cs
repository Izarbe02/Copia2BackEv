using Microsoft.AspNetCore.Mvc;
using dosEvAPI.Service;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dosEvAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatrocinadorController : ControllerBase
    {
        private readonly IPatrocinadorService _servicePatrocinador;

        public PatrocinadorController(IPatrocinadorService service)
        {
            _servicePatrocinador = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Patrocinador>>> GetPatrocinadores()
        {
            var patrocinadores = await _servicePatrocinador.GetAllAsync();
            return Ok(patrocinadores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patrocinador>> GetPatrocinador(int id)
        {
            var patrocinador = await _servicePatrocinador.GetByIdAsync(id);
            if (patrocinador == null)
            {
                return NotFound();
            }
            return Ok(patrocinador);
        }

        [HttpPost]
        public async Task<ActionResult<Patrocinador>> CreatePatrocinador(Patrocinador patrocinador)
        {
            await _servicePatrocinador.AddAsync(patrocinador);
            return CreatedAtAction(nameof(GetPatrocinador), new { id = patrocinador.Id }, patrocinador);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatrocinador(int id, Patrocinador updatedPatrocinador)
        {
            var existingPatrocinador = await _servicePatrocinador.GetByIdAsync(id);
            if (existingPatrocinador == null)
            {
                return NotFound();
            }

            existingPatrocinador.Nombre = updatedPatrocinador.Nombre;
            existingPatrocinador.Descripcion = updatedPatrocinador.Descripcion;
            existingPatrocinador.Logo = updatedPatrocinador.Logo;
            existingPatrocinador.Contacto = updatedPatrocinador.Contacto;
            existingPatrocinador.IdOrganizador = updatedPatrocinador.IdOrganizador;

            await _servicePatrocinador.UpdateAsync(existingPatrocinador);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatrocinador(int id)
        {
            var patrocinador = await _servicePatrocinador.GetByIdAsync(id);
            if (patrocinador == null)
            {
                return NotFound();
            }
            await _servicePatrocinador.DeleteAsync(id);
            return NoContent();
        }
    }
}
