namespace backend.Entities
{
    public class DestinoReservado
    {
        public int Id { get; set; }
        public UsuarioEntity Usuario { get; set; }
        public DestinoEntity Destino { get; set; }
        public DateTime DateCheckin { get; set; }
        public DateTime DateCheckout { get; set;}
        public int NumeroAdultos { get; set; }
        public int NumeroCriancas { get; set; }
}
}
