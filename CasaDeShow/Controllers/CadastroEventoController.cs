using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CasaDeShow.Data;
using CasaDeShow.Models;

namespace CasaDeShow.Controllers
{
    public class CadastroEventoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CadastroEventoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CadastroEvento
        public async Task<IActionResult> Index()
        {
            ViewBag.CasaDeShow = _context.Casadeshow.ToList();
            return View(await _context.Evento.ToListAsync());
        }

        // GET: CadastroEvento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Evento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }
            ViewBag.CasaDeShow = _context.Casadeshow.ToList();
            return View(evento);
        }

        // GET: CadastroEvento/Create
        public IActionResult Create()
        {
            if (_context.Casadeshow.Count() == 0)
            {
                TempData["ErroCasa"]="Necessário ter casa de show para cadastrar evento";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.CasaDeShow = _context.Casadeshow.ToList();
                return View();
            }
        }

        // POST: CadastroEvento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeEvento,Capacidade,Data,ValorIngresso,GeneroMusica,CasadeshowId")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(evento);
                await _context.SaveChangesAsync();

                ViewBag.CasaDeShow = _context.Casadeshow.ToList();

                return RedirectToAction(nameof(Index));
            }
            ViewBag.CasaDeShow = _context.Casadeshow.ToList();
            return View(evento);
        }

        // GET: CadastroEvento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Evento.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            ViewBag.CasaDeShow = _context.Casadeshow.ToList();
            return View(evento);
        }

        // POST: CadastroEvento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeEvento,Capacidade,Data,ValorIngresso,GeneroMusica,CasadeshowId")] Evento evento)
        {
            if (id != evento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoExists(evento.Id))
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
            ViewBag.CasaDeShow = _context.Casadeshow.ToList();
            return View(evento);
        }

        // GET: CadastroEvento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Evento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // POST: CadastroEvento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evento = await _context.Evento.FindAsync(id);
            _context.Evento.Remove(evento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventoExists(int id)
        {
            return _context.Evento.Any(e => e.Id == id);
        }
    }
}
