﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProEquipos.Data;
using ProEquipos.Models;

namespace ProEquipos.Controllers
{
    public class JugadorsController : Controller
    {
        private readonly ProEquiposContext _context;

        public JugadorsController(ProEquiposContext context)
        {
            _context = context;
        }

        // GET: Jugadors
        // GET: Jugadors
        public async Task<IActionResult> Index(string searchString)
        {
            var jugadores = _context.Jugador.Include(j => j.Equipo).AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                jugadores = jugadores.Where(j => j.Equipo.Nombre.Contains(searchString));
            }

            return View(await jugadores.ToListAsync());
        }


        // GET: Jugadors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugador
                .Include(j => j.Equipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jugador == null)
            {
                return NotFound();
            }

            return View(jugador);
        }

        // GET: Jugadors/Create
        public IActionResult Create()
        {
            ViewData["IdEquipo"] = new SelectList(_context.Set<Equipo>(), "Id", "Nombre");
            return View();
        }

        // POST: Jugadors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Posicion,Edad,IdEquipo")] Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jugador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEquipo"] = new SelectList(_context.Set<Equipo>(), "Id", "Id", jugador.IdEquipo);
            return View(jugador);
        }

        // GET: Jugadors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugador.FindAsync(id);
            if (jugador == null)
            {
                return NotFound();
            }
            ViewData["IdEquipo"] = new SelectList(_context.Set<Equipo>(), "Id", "Id", jugador.IdEquipo);
            return View(jugador);
        }

        // POST: Jugadors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Posicion,Edad,IdEquipo")] Jugador jugador)
        {
            if (id != jugador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jugador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JugadorExists(jugador.Id))
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
            ViewData["IdEquipo"] = new SelectList(_context.Set<Equipo>(), "Id", "Id", jugador.IdEquipo);
            return View(jugador);
        }

        // GET: Jugadors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugador
                .Include(j => j.Equipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jugador == null)
            {
                return NotFound();
            }

            return View(jugador);
        }

        // POST: Jugadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jugador = await _context.Jugador.FindAsync(id);
            if (jugador != null)
            {
                _context.Jugador.Remove(jugador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JugadorExists(int id)
        {
            return _context.Jugador.Any(e => e.Id == id);
        }
    }
}
