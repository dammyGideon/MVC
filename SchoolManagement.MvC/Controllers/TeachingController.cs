using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.MvC.Data;

namespace SchoolManagement.MvC.Controllers
{
    public class TeachingController : Controller
    {
        private readonly SchoolManagementDbContext _context;

        public TeachingController(SchoolManagementDbContext context)
        {
            _context = context;
        }

        // GET: Teaching
        public async Task<IActionResult> Index()
        {
            return View(await _context.NoTeachingStaffs.ToListAsync());
        }

        // GET: Teaching/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noTeachingStaff = await _context.NoTeachingStaffs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (noTeachingStaff == null)
            {
                return NotFound();
            }

            return View(noTeachingStaff);
        }

        // GET: Teaching/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teaching/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Dob")] NoTeachingStaff noTeachingStaff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(noTeachingStaff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(noTeachingStaff);
        }

        // GET: Teaching/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noTeachingStaff = await _context.NoTeachingStaffs.FindAsync(id);
            if (noTeachingStaff == null)
            {
                return NotFound();
            }
            return View(noTeachingStaff);
        }

        // POST: Teaching/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Dob")] NoTeachingStaff noTeachingStaff)
        {
            if (id != noTeachingStaff.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(noTeachingStaff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoTeachingStaffExists(noTeachingStaff.Id))
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
            return View(noTeachingStaff);
        }

        // GET: Teaching/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noTeachingStaff = await _context.NoTeachingStaffs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (noTeachingStaff == null)
            {
                return NotFound();
            }

            return View(noTeachingStaff);
        }

        // POST: Teaching/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var noTeachingStaff = await _context.NoTeachingStaffs.FindAsync(id);
            if (noTeachingStaff != null)
            {
                _context.NoTeachingStaffs.Remove(noTeachingStaff);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoTeachingStaffExists(int id)
        {
            return _context.NoTeachingStaffs.Any(e => e.Id == id);
        }
    }
}
