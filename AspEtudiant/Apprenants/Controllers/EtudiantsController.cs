using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Apprenants.Data;
using Apprenants.Models;
using Microsoft.AspNetCore.Authorization;

namespace Apprenants.Controllers
{
    public class EtudiantsController : Controller
    {
      
        private readonly ApplicationDbContext _context;

        public EtudiantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Etudiants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Etudiants.ToListAsync());
        }
        // GET: Etudiants/Recherche
        public IActionResult ShowSearchForm()
        {
            return View();
        }
        // Post: Etudiants/Result
        public async Task<IActionResult> ShowSearchResult(String SearchPhrase)
        {
            return View("Index", await _context.Etudiants.Where(J =>J.prenom.Contains(SearchPhrase)) .ToListAsync());
        }

        // GET: Etudiants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etudiants = await _context.Etudiants
                .FirstOrDefaultAsync(m => m.id == id);
            if (etudiants == null)
            {
                return NotFound();
            }

            return View(etudiants);
        }

        // GET: Etudiants/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Etudiants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nom,prenom,CIN,Adress")] Etudiants etudiants)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etudiants);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(etudiants);
        }

        // GET: Etudiants/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etudiants = await _context.Etudiants.FindAsync(id);
            if (etudiants == null)
            {
                return NotFound();
            }
            return View(etudiants);
        }

        // POST: Etudiants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 

        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nom,prenom,CIN,Adress")] Etudiants etudiants)
        {
            if (id != etudiants.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   

                    _context.Update(etudiants);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtudiantsExists(etudiants.id))
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
            return View(etudiants);
        }

        // GET: Etudiants/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etudiants = await _context.Etudiants
                .FirstOrDefaultAsync(m => m.id == id);
            if (etudiants == null)
            {
                return NotFound();
            }

            return View(etudiants);
        }

        // POST: Etudiants/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var etudiants = await _context.Etudiants.FindAsync(id);
            _context.Etudiants.Remove(etudiants);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtudiantsExists(int id)
        {
            return _context.Etudiants.Any(e => e.id == id);
        }
    }
}
