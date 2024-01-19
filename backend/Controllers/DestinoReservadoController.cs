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
    public class DestinoReservadoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DestinoReservadoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // CRUD ...

        // POST api/DestinoReservado
        [HttpPost]
        public async Task<IActionResult> CreateDestinoReservado([FromBody] CreateUpdateDestinoReservadoDto dto)
        {
            try
            {
                var usuario = await GetUsuarioById(dto.UsuarioId);
                var destino = await GetDestinoById(dto.DestinoId);

                if (usuario == null || destino == null)
                {
                    return BadRequest("Usuário ou Destino inválido. Certifique-se de que ambos existem.");
                }

                var destinoReservado = new DestinoReservadoEntity
                {
                    Usuario = usuario,
                    Destino = destino,
                  /*  DateCheckin = dto.DateCheckin,
                    DateCheckout = dto.DateCheckout,*/
                    NumeroAdultos = dto.NumeroAdultos,
                    NumeroCriancas = dto.NumeroCriancas
                };

                _context.DestinoReservado.Add(destinoReservado);
                await _context.SaveChangesAsync();

                return Ok("Destino Reservado salvo com sucesso!");
            }
            catch (Exception ex)
            {
                // Lidando com exceções
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno no servidor");
            }
        }

        private async Task<UsuarioEntity> GetUsuarioById(int usuarioId)
        {
            return await _context.Usuario.FindAsync(usuarioId);
        }

        private async Task<DestinoEntity> GetDestinoById(int destinoId)
        {
            return await _context.Destino.FindAsync(destinoId);
        }


        // GET api/DestinoReservado/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CreateUpdateDestinoReservadoDto>> GetDestinoReservadoById(int id)
        {
            try
            {
                var destinoReservado = await _context.DestinoReservado
                    .Include(dr => dr.Usuario)
                    .Include(dr => dr.Destino)
                    .FirstOrDefaultAsync(dr => dr.Id == id);

                if (destinoReservado == null)
                {
                    return NotFound($"Destino Reservado com ID {id} não encontrado.");
                }

                var result = MapDestinoReservadoEntityToDto(destinoReservado);

                // Formatted data 
                result.DateCheckinFormatted = destinoReservado.DateCheckin.ToString("yyyy-MM-dd");
                result.DateCheckoutFormatted = destinoReservado.DateCheckout.ToString("yyyy-MM-dd");


                return Ok(result);
            }
            catch (Exception ex)
            {
                // Lidando com exceções
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno no servidor");
            }
        }

        private CreateUpdateDestinoReservadoDto MapDestinoReservadoEntityToDto(DestinoReservadoEntity destinoReservadoEntity) => new CreateUpdateDestinoReservadoDto
        {
            Id = destinoReservadoEntity.Id,
            UsuarioId = destinoReservadoEntity.UsuarioId,
            DestinoId = destinoReservadoEntity.DestinoId,
            /*DateCheckin = destinoReservadoEntity.DateCheckin,
            DateCheckout = destinoReservadoEntity.DateCheckout,*/
            NumeroAdultos = destinoReservadoEntity.NumeroAdultos,
            NumeroCriancas = destinoReservadoEntity.NumeroCriancas,
            DateCheckinFormatted = destinoReservadoEntity.DateCheckin.ToString("yyyy-MM-dd"),
            DateCheckoutFormatted = destinoReservadoEntity.DateCheckout.ToString("yyyy-MM-dd"),

        };
    }
}
        