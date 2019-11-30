using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EscolaDRS.Web.Models;

namespace EscolaDRS.Web.Controllers
{
    public class AlunosController : Controller
    {
        private readonly ProjetoContext _context;

        public AlunosController(ProjetoContext context)
        {
            _context = context;
        }

        // GET: Alunos
        public async Task<IActionResult> Index()
        {
            var projetoContext = _context.Aluno.Include(a => a.Escola);
            return View(await projetoContext.ToListAsync());
        }

        // GET: Alunos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno
                .Include(a => a.Escola)
                .FirstOrDefaultAsync(m => m.IdAluno == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // GET: Alunos/Create
        public IActionResult Create()
        {
            ViewData["IdEscola"] = new SelectList(_context.Escola, "IdEscola", "NomeEscola");
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAluno,NomeAluno,DataNascimento,IdEscola")] Aluno aluno)
        {
            ViewData["IdEscola"] = new SelectList(_context.Escola, "IdEscola", "NomeEscola", aluno.IdEscola);
            if (ModelState.IsValid)
            {
                try
                {
                    if (aluno.Validar(this._context.Aluno))
                    {
                        _context.Add(aluno);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Retorno = ex.Message;
                    return View(aluno);
                }
            }
            return View(aluno);
        }

        // GET: Alunos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            ViewData["IdEscola"] = new SelectList(_context.Escola, "IdEscola", "NomeEscola", aluno.IdEscola);
            return View(aluno);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAluno,NomeAluno,DataNascimento,IdEscola")] Aluno aluno)
        {
            if (id != aluno.IdAluno)
            {
                return NotFound();
            }

            ViewData["IdEscola"] = new SelectList(_context.Escola, "IdEscola", "NomeEscola", aluno.IdEscola);

            if (ModelState.IsValid)
            {
                try
                {
                    if (aluno.Validar(this._context.Aluno.Where(a => a.IdAluno != aluno.IdAluno)))
                    {
                        _context.Update(aluno);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(aluno.IdAluno))
                        return NotFound();
                    else
                        throw;
                }
                catch (Exception ex)
                {
                    ViewBag.Retorno = ex.Message;
                    return View(aluno);
                } 
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        // GET: Alunos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno
                .Include(a => a.Escola)
                .FirstOrDefaultAsync(m => m.IdAluno == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluno = await _context.Aluno.FindAsync(id);
            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoExists(int id)
        {
            return _context.Aluno.Any(e => e.IdAluno == id);
        }
    }
}
