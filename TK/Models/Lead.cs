namespace TK.Models
{
    public class Lead
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public int QuantidadePessoas { get; set; }
        public bool TemCriancas { get; set; }

        public string Destino { get; set; }
        public string Origem { get; set; }

        public DateTime? DataViagem { get; set; }
        public int? QuantidadeDias { get; set; }

        public string Telefone { get; set; }

        public string OrigemContato { get; set; } // "Chat" ou "Promocao"
        public string Promocao { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}