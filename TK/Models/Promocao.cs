
    namespace TK.Models
    {
        public class Promocao
        {
            public int Id { get; set; }
            public string Titulo { get; set; }
            public string Descricao { get; set; }
            public string Destino { get; set; }
            public string Origem { get; set; }
            public string ImagemUrl { get; set; }
            public DateTime DataIda { get; set; }
            public DateTime DataVolta { get; set; }
            public bool VooDireto { get; set; }
            public bool AllInclusive { get; set; }
            public decimal Preco { get; set; }
            public int Parcelas { get; set; } = 12;
            public bool Ativa { get; set; } = true;
        }
    }

