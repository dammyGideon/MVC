using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.MvC.Data;

namespace SchoolManagement.MvC.controllers
{
    public class EntrollmentController : Controller
    {
        private readonly SchoolManagementDbContext _context;

        public EntrollmentController(SchoolManagementDbContext context)
        {
            _context = context;
        }

        // GET: Entrollment
        public async Task<IActionResult> Index()
        {
            var schoolManagementDbContext = _context.Entrollments.Include(e => e.Class).Include(e => e.Student);
            return View(await schoolManagementDbContext.ToListAsync());
        }

        // GET: Entrollment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrollment = await _context.Entrollments
                .Include(e => e.Class)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entrollment == null)
            {
                return NotFound();
            }

            return View(entrollment);
        }

        // GET: Entrollment/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id");
            return View();
        }

        // POST: Entrollment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentId,ClassId,Grade")] Entrollment entrollment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id", entrollment.ClassId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", entrollment.StudentId);
            return View(entrollment);
        }

        // GET: Entrollment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrollment = await _context.Entrollments.FindAsync(id);
            if (entrollment == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id", entrollment.ClassId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", entrollment.StudentId);
            return View(entrollment);
        }

        // POST: Entrollment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,ClassId,Grade")] Entrollment entrollment)
        {
            if (id != entrollment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntrollmentExists(entrollment.Id))
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
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id", entrollment.ClassId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", entrollment.StudentId);
            return View(entrollment);
        }

        // GET: Entrollment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrollment = await _context.Entrollments
                .Include(e => e.Class)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entrollment == null)
            {
                return NotFound();
            }

            return View(entrollment);
        }

        // POST: Entrollment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entrollment = await _context.Entrollments.FindAsync(id);
            if (entrollment != null)
            {
                _context.Entrollments.Remove(entrollment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntrollmentExists(int id)
        {
            return _context.Entrollments.Any(e => e.Id == id);
        }
    }
}
