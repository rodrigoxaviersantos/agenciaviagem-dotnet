namespace backend.Dtos
{
    public class CreateUpdateUsuarioDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
