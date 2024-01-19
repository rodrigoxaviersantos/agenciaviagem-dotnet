namespace backend.Entities
{
    public class UsuarioEntity
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        // Relacionamento com DestinoReservado
        public ICollection<DestinoReservadoEntity> DestinoReservados { get; set; } 

    }
}
