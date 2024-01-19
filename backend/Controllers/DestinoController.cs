using backend.Context;
using backend.Dtos;
using backend.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public DestinoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // CRUD 

        // Create 
        [HttpPost]
        public async Task<IActionResult> CreateDestino([FromBody] CreateUpdateDestinoDto dto)
        {
            var newDestino = new DestinoEntity()
            {
                Name = dto.Name,
                Descricao = dto.Descricao,
                Preco = dto.Preco,
            };

            await _context.Destino.AddAsync(newDestino);
            await _context.SaveChangesAsync();

            return Ok("Destino salvo com sucesso!");
        }


        // GET api/Destino/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<DestinoEntity>> GetDestinoById(int id)
        {
            var destino = await _context.Destino.FindAsync(id);

            if (destino == null)
            {
                return NotFound("Destino não encontrado!");
            }

            return Ok(destino);
        }

        // PUT api/Destino/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDestino(int id, [FromBody] DestinoEntity updatedDestino)
        {
            var destino = await _context.Destino.FindAsync(id);

            if (destino == null)
            {
                return NotFound("Destino não encontrado!");
            }

            // Update properties
            destino.Name = updatedDestino.Name;
            destino.Descricao = updatedDestino.Descricao;
            destino.Preco = updatedDestino.Preco;

            await _context.SaveChangesAsync();

            return Ok("Destino atualizado com sucesso!");
        }

        // DELETE api/Destino/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDestino(int id)
        {
            var destino = await _context.Destino.FindAsync(id);

            if (destino == null)
            {
                return NotFound("Destino não encontrado!");
            }

            _context.Destino.Remove(destino);
            await _context.SaveChangesAsync();

            return Ok("Destino excluído com sucesso!");
        }
    }

}
