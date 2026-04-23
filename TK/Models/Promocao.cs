namespace TK.Models
{
    public class Promocao
    {
        public int Id { get; set; }

        public string Titulo { get; set; }
        public string Descricao { get; set; }

        public string Destino { get; set; }

        public string ImagemUrl { get; set; }

        public bool Ativa { get; set; } = true;
    }
}
