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
    public class LivroModelsController : Controller
    {
        private readonly MVCBooktopiaContext _context;

        public LivroModelsController(MVCBooktopiaContext context)
        {
            _context = context;
        }

        // GET: LivroModels
        public async Task<IActionResult> Index()
        {
              return _context.LivrosModel != null ? 
                          View(await _context.LivrosModel.ToListAsync()) :
                          Problem("Entity set 'MVCBooktopiaContext.LivroModel'  is null.");
        }

        // GET: LivroModels
        public async Task<IActionResult> Desativados()
        {
            return _context.LivrosModel != null ?
                        View(await _context.LivrosModel.ToListAsync()) :
                        Problem("Entity set 'MVCBooktopiaContext.LivroModel'  is null.");
        }

        // GET: LivroModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.LivrosModel == null)
            {
                return NotFound();
            }

            var livroModel = await _context.LivrosModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livroModel == null)
            {
                return NotFound();
            }

            return View(livroModel);
        }

        // GET: LivroModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LivroModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LivroModel livroModel)
        {
            livroModel.Id = Guid.NewGuid();
            livroModel.Ativo = true;
            _context.Add(livroModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: LivroModels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.LivrosModel == null)
            {
                return NotFound();
            }

            var livroModel = await _context.LivrosModel.FindAsync(id);
            if (livroModel == null)
            {
                return NotFound();
            }
            return View(livroModel);
        }

        // POST: LivroModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, LivroModel livroModel)
        {
            if (id != livroModel.Id)
            {
                return NotFound();
            }
            try
            {
                _context.Update(livroModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivroModelExists(livroModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private bool LivroModelExists(Guid id)
        {
          return (_context.LivrosModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // GET: LivroModels/Edit/5
        public async Task<IActionResult> Desativar(Guid? id)
        {
            if (id == null || _context.LivrosModel == null)
            {
                return NotFound();
            }

            var livroModel = await _context.LivrosModel.FindAsync(id);
            if (livroModel == null)
            {
                return NotFound();
            }
            return View(livroModel);
        }

        // POST: LivroModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Desativar(Guid id, LivroModel livroModel)
        {
            if (id != livroModel.Id)
            {
                return NotFound();
            }
            try
            {
                livroModel.Ativo = false;
                _context.Update(livroModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivroModelExists(livroModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }


        // GET: LivroModels/Edit/5
        public async Task<IActionResult> Reativar(Guid? id)
        {
            if (id == null || _context.LivrosModel == null)
            {
                return NotFound();
            }

            var livroModel = await _context.LivrosModel.FindAsync(id);
            if (livroModel == null)
            {
                return NotFound();
            }
            return View(livroModel);
        }

        // POST: LivroModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reativar(Guid id, LivroModel livroModel)
        {
            if (id != livroModel.Id)
            {
                return NotFound();
            }
            try
            {
                livroModel.Ativo = true;
                _context.Update(livroModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivroModelExists(livroModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
