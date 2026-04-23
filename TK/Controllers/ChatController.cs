using Microsoft.AspNetCore.Mvc;
using TK.Models;

public class ChatController : Controller
{
    [HttpPost]
    public IActionResult ResponderIA([FromBody] dynamic req)
    {
        string resposta = "Claro! Posso te ajudar com isso 😊 Mas antes, preciso entender melhor sua viagem.";

        return Json(new { resposta });
    }

  
}

