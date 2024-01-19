using System.Globalization;

namespace backend.Dtos
{
    public class CreateUpdateDestinoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descricao { get; set; }
        public float Preco { get; set; }       
        public int DestinoId { get; internal set; }

    }
}


