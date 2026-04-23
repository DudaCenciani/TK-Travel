namespace TK.Models
{
    public class ChatMensagem
    {
        public int Id { get; set; }

        public string UsuarioMensagem { get; set; }
        public string BotResposta { get; set; }

        public DateTime Data { get; set; } = DateTime.Now;
    }
}
