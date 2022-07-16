using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCBooktopia.Data;
using MVCBooktopia.Models;

namespace MVCBooktopia.Controllers
{
    [Authorize]
    public class AluguelModelsController : Controller
    {
        private readonly MVCBooktopiaContext _context;

        public AluguelModelsController(MVCBooktopiaContext context)
        {
            _context = context;
        }

        // GET: AluguelModels
        public async Task<IActionResult> Index()
        {
              return _context.AlugueisModel != null ? 
                          View(await _context.AlugueisModel.ToListAsync()) :
                          Problem("Entity set 'MVCBooktopiaContext.AluguelModel'  is null.");
        }

        // GET: AluguelModels
        public async Task<IActionResult> Devolvidos()
        {
            return _context.AlugueisModel != null ?
                        View(await _context.AlugueisModel.ToListAsync()) :
                        Problem("Entity set 'MVCBooktopiaContext.AluguelModel'  is null.");
        }

        // GET: AluguelModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.AlugueisModel == null)
            {
                return NotFound();
            }

            var aluguelModel = await _context.AlugueisModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluguelModel == null)
            {
                return NotFound();
            }

            return View(aluguelModel);
        }

        // GET: AluguelModels/Create
        public IActionResult Create()
        {
            var clientes = _context.ClientesModel.ToList();
            ViewData["ClienteId"] = new SelectList(clientes, "Id", "Nome");
            var livros = _context.LivrosModel.ToList();
            ViewData["LivroId"] = new SelectList(livros, "Id", "Titulo");           
            return View();
        }

        // POST: AluguelModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AluguelModel aluguelModel)
        {
            
            aluguelModel.Id = Guid.NewGuid();
            _context.Add(aluguelModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: AluguelModels/Edit/5
        public async Task<IActionResult> Devolver(Guid? id)
        {
            if (id == null || _context.AlugueisModel == null)
            {
                return NotFound();
            }

            var aluguelModel = await _context.AlugueisModel.FindAsync(id);
            if (aluguelModel == null)
            {
                return NotFound();
            }
            return View(aluguelModel);
        }

        // POST: AluguelModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Devolver(Guid id, AluguelModel aluguelModel)
        {
            if (id != aluguelModel.Id)
            {
                return NotFound();
            }

            try
            {
                aluguelModel.Devolvido = true;
                aluguelModel.DataDevolucao = DateTime.Now;
                TimeSpan diasCorridos = (TimeSpan)(aluguelModel.DataDevolucao - aluguelModel.DataAluguel);
                if (diasCorridos.Days > 10)
                {
                    int diasPassados = diasCorridos.Days - 10;
                    aluguelModel.Multa =(decimal) 1.00 * diasPassados;
                }
                else
                {
                    aluguelModel.Multa = 0;
                }
                var livro = _context.LivrosModel.Find(aluguelModel.LivroId);
                decimal valorLivro = livro.Valor;
                aluguelModel.ValorTotal = valorLivro + aluguelModel.Multa;                
               
                _context.Update(aluguelModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AluguelModelExists(aluguelModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
            //return View(aluguelModel);
        }

        // GET: AluguelModels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.AlugueisModel == null)
            {
                return NotFound();
            }

            var aluguelModel = await _context.AlugueisModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluguelModel == null)
            {
                return NotFound();
            }

            return View(aluguelModel);
        }

        // POST: AluguelModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.AlugueisModel == null)
            {
                return Problem("Entity set 'MVCBooktopiaContext.AluguelModel'  is null.");
            }
            var aluguelModel = await _context.AlugueisModel.FindAsync(id);
            if (aluguelModel != null)
            {
                _context.AlugueisModel.Remove(aluguelModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool AluguelModelExists(Guid id)
        {
          return (_context.AlugueisModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }        
    }
}
