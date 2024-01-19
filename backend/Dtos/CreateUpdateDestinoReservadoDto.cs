using backend.Entities;

namespace backend.Dtos
{
    public class CreateUpdateDestinoReservadoDto
    {
       
        public int Id { get; set; }
        public int UsuarioId { get; set; } 
        public int DestinoId { get; set; }
        public int NumeroAdultos { get; set; }
        public int NumeroCriancas { get; set; }
        public string DateCheckinFormatted { get;  set; }
        public string DateCheckoutFormatted { get; set; }
        
    }
}