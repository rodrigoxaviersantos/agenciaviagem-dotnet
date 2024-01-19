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

        // POST api/Usuario
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

        // GET api/Usuario/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioEntity>> GetUsuarioById(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado!");
            }

            return Ok(usuario);
        }

        
            // PUT api/Usuario/{id}
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateUsuario(int id, [FromBody] UsuarioEntity updatedUsuario)
            {
                var usuario = await _context.Usuario.FindAsync(id);

                if (usuario == null)
                {
                    return NotFound("Usuário não encontrado!");
                }

                // Update properties
                usuario.Name = updatedUsuario.Name;
                usuario.Cpf = updatedUsuario.Cpf;
                usuario.Email = updatedUsuario.Email;
                usuario.Senha = updatedUsuario.Senha;

                await _context.SaveChangesAsync();

                return Ok("Usuário atualizado com sucesso!");
            }

            // DELETE api/Usuario/{id}
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteUsuario(int id)
            {
                var usuario = await _context.Usuario.FindAsync(id);

                if (usuario == null)
                {
                    return NotFound("Usuário não encontrado!");
                }

                _context.Usuario.Remove(usuario);
                await _context.SaveChangesAsync();

                return Ok("Usuário excluído com sucesso!");
            }
        }

    }
