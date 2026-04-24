using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TK.Data;
using TK.Models;
using System.IO;

namespace TK.Controllers
{
    public class PromocaosController : Controller
    {
        private readonly TKContext _context;

        public PromocaosController(TKContext context)
        {
            _context = context;
        }

        // GET: Promocaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Promocao.ToListAsync());
        }

        // GET: Promocaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var promocao = await _context.Promocao
                .FirstOrDefaultAsync(m => m.Id == id);

            if (promocao == null) return NotFound();

            return View(promocao);
        }

        // GET: Promocaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Promocaos/Create
        [HttpPost]
        public async Task<IActionResult> Create(Promocao promocao, IFormFile imagem)
        {
            if (imagem != null)
            {
                var nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(imagem.FileName);
                var caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens/promocoes", nomeArquivo);

                using (var stream = new FileStream(caminho, FileMode.Create))
                {
                    await imagem.CopyToAsync(stream);
                }

                promocao.ImagemUrl = "/imagens/promocoes/" + nomeArquivo;
            }

            _context.Add(promocao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Promocaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var promocao = await _context.Promocao.FindAsync(id);

            if (promocao == null) return NotFound();

            return View(promocao);
        }

        // POST: Promocaos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descricao,Destino,Origem,ImagemUrl,DataIda,DataVolta,VooDireto,AllInclusive,Preco,Parcelas,Ativa")] Promocao promocao, IFormFile imagem)
        {
            if (id != promocao.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    // Se enviou nova imagem, substitui
                    if (imagem != null)
                    {
                        var nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(imagem.FileName);
                        var caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens/promocoes", nomeArquivo);

                        using (var stream = new FileStream(caminho, FileMode.Create))
                        {
                            await imagem.CopyToAsync(stream);
                        }

                        promocao.ImagemUrl = "/imagens/promocoes/" + nomeArquivo;
                    }

                    _context.Update(promocao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromocaoExists(promocao.Id)) return NotFound();
                    else throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(promocao);
        }

        // GET: Promocaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var promocao = await _context.Promocao
                .FirstOrDefaultAsync(m => m.Id == id);

            if (promocao == null) return NotFound();

            return View(promocao);
        }

        // POST: Promocaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promocao = await _context.Promocao.FindAsync(id);

            if (promocao != null)
            {
                _context.Promocao.Remove(promocao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromocaoExists(int id)
        {
            return _context.Promocao.Any(e => e.Id == id);
        }
    }
}