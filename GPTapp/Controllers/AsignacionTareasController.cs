using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GPTapp.Models;

namespace GPTapp.Controllers
{
    public class AsignacionTareasController : Controller
    {
        private readonly GestionProyectosTareasDBContext _context;

        public AsignacionTareasController(GestionProyectosTareasDBContext context)
        {
            _context = context;
        }

        // GET: AsignacionTareas
        public async Task<IActionResult> Index()
        {
              return _context.AsignacionTareas != null ? 
                          View(await _context.AsignacionTareas.ToListAsync()) :
                          Problem("Entity set 'GestionProyectosTareasDBContext.AsignacionTareas'  is null.");
        }

        // GET: AsignacionTareas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AsignacionTareas == null)
            {
                return NotFound();
            }

            var asignacionTarea = await _context.AsignacionTareas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asignacionTarea == null)
            {
                return NotFound();
            }

            return View(asignacionTarea);
        }

        // GET: AsignacionTareas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AsignacionTareas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TareaId,UsuarioId,EstadoProyecto,FechaAsignacion,FechaLimite")] AsignacionTarea asignacionTarea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignacionTarea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(asignacionTarea);
        }

        // GET: AsignacionTareas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AsignacionTareas == null)
            {
                return NotFound();
            }

            var asignacionTarea = await _context.AsignacionTareas.FindAsync(id);
            if (asignacionTarea == null)
            {
                return NotFound();
            }
            return View(asignacionTarea);
        }

        // POST: AsignacionTareas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TareaId,UsuarioId,EstadoProyecto,FechaAsignacion,FechaLimite")] AsignacionTarea asignacionTarea)
        {
            if (id != asignacionTarea.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignacionTarea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignacionTareaExists(asignacionTarea.Id))
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
            return View(asignacionTarea);
        }

        // GET: AsignacionTareas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AsignacionTareas == null)
            {
                return NotFound();
            }

            var asignacionTarea = await _context.AsignacionTareas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asignacionTarea == null)
            {
                return NotFound();
            }

            return View(asignacionTarea);
        }

        // POST: AsignacionTareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AsignacionTareas == null)
            {
                return Problem("Entity set 'GestionProyectosTareasDBContext.AsignacionTareas'  is null.");
            }
            var asignacionTarea = await _context.AsignacionTareas.FindAsync(id);
            if (asignacionTarea != null)
            {
                _context.AsignacionTareas.Remove(asignacionTarea);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignacionTareaExists(int id)
        {
          return (_context.AsignacionTareas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
