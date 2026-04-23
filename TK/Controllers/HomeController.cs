using System;
using Microsoft.AspNetCore.Mvc;
using TK.Data;
using TK.Models;
public class HomeController : Controller
{
    private readonly TKContext _context;

    public HomeController(TKContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var promocoes = _context.Promocao 
            .Where(p => p.Ativa)
            .ToList();

        return View(promocoes); // ✅ agora não é null
    }
}