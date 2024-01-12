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

    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // CRUD 

        // Create 
        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] CreateUpdateUsuarioDto dto)
        {
            var newUsuario = new UsuarioEntity()
            {
                Name = dto.Name,
                Cpf = dto.Cpf,
                Email = dto.Email,
                Senha = dto.Senha,
            };

            await _context.Usuario.AddAsync(newUsuario);
            await _context.SaveChangesAsync();

            return Ok("Usuário salvo com sucesso!");
        }

        // Read 
        [HttpGet]
        public async Task<ActionResult<List<UsuarioEntity>>> GetAllUsuario()
        {
            var usuario = await _context.Usuario.ToListAsync();
            return Ok(usuario);
        }
        [HttpGet]
        [Route("{id}")]

        public async Task<ActionResult<UsuarioEntity>> GetUsuarioByID([FromRoute] long id)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(x => x.Id == id);
            if (usuario == null)
            {
                return NotFound("Usuário não Encontrado!");

            }

            return Ok(usuario);
        }


        // Update 
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUsuario([FromRoute] long id, [FromBody] CreateUpdateUsuarioDto dto)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync (q => q.Id == id);

            if (usuario == null)
            {
                return NotFound("Usuário não Encontrado");
            }

            usuario.Name = dto.Name;
            usuario.Cpf = dto.Cpf;
            usuario.Email = dto.Email;
            usuario.Senha = dto.Senha;

            await _context.SaveChangesAsync();

            return Ok("Usuário atualizado com Sucesso");
            
        }

        // Delete 
        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> DeleUsuario([FromRoute] long id)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(q => q.Id == id);
            if(usuario == null)
            {
                return NotFound("Usuário não encontrado!");
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return Ok("Usuário excluído com Sucesso!"); 
        }


    }
}