using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LabbLinq.Data;
using LabbLinq.Models;

namespace LabbLinq.Controllers
{
    public class SchoolConnectionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SchoolConnectionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SchoolConnections
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SchoolConnections.Include(s => s.Courses).Include(s => s.StudentClasses).Include(s => s.Students).Include(s => s.Teachers);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SchoolConnections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SchoolConnections == null)
            {
                return NotFound();
            }

            var schoolConnection = await _context.SchoolConnections
                .Include(s => s.Courses)
                .Include(s => s.StudentClasses)
                .Include(s => s.Students)
                .Include(s => s.Teachers)
                .FirstOrDefaultAsync(m => m.SchoolConnectionId == id);
            if (schoolConnection == null)
            {
                return NotFound();
            }

            return View(schoolConnection);
        }

        // GET: SchoolConnections/Create
        public IActionResult Create()
        {
            ViewBag.FK_CourseId = new SelectList(_context.Courses, "FK_CourseId", "FK_CourseId");
            ViewBag.FK_StudentClassId = new SelectList(_context.StudentClasses, "FK_StudentClassId", "FK_StudentClassId");
            ViewBag.FK_StudentId = new SelectList(_context.Students, "FK_StudentId", "FK_StudentId");
            ViewBag.FK_TeacherId = new SelectList(_context.Teachers, "FK_TeacherId", "FK_TeacherId");
            return View();
        }

        // POST: SchoolConnections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SchoolConnectionId,FK_TeacherId,FK_StudentId,FK_CourseId,FK_StudentClassId")] SchoolConnection schoolConnection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schoolConnection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FK_CourseId"] = new SelectList(_context.Courses, "FK_CourseId", "FK_CourseId", schoolConnection.FK_CourseId);
            ViewData["FK_StudentClassId"] = new SelectList(_context.StudentClasses, "FK_StudentClassId", "FK_StudentClassId", schoolConnection.FK_StudentClassId);
            ViewData["FK_StudentId"] = new SelectList(_context.Students, "FK_StudentId", "FK_StudentId", schoolConnection.FK_StudentId);
            ViewData["FK_TeacherId"] = new SelectList(_context.Teachers, "FK_TeacherId", "FK_TeacherId", schoolConnection.FK_TeacherId);
            return View(schoolConnection);
        }

        // GET: SchoolConnections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SchoolConnections == null)
            {
                return NotFound();
            }

            var schoolConnection = await _context.SchoolConnections.FindAsync(id);
            if (schoolConnection == null)
            {
                return NotFound();
            }
            ViewData["FK_CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", schoolConnection.FK_CourseId);
            ViewData["FK_StudentClassId"] = new SelectList(_context.StudentClasses, "StudentClassId", "StudentClassId", schoolConnection.FK_StudentClassId);
            ViewData["FK_StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", schoolConnection.FK_StudentId);
            ViewData["FK_TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "FirstName", schoolConnection.FK_TeacherId);
            return View(schoolConnection);
        }

        // POST: SchoolConnections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SchoolConnectionId,FK_TeacherId,FK_StudentId,FK_CourseId,FK_StudentClassId")] SchoolConnection schoolConnection)
        {
            if (id != schoolConnection.SchoolConnectionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schoolConnection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchoolConnectionExists(schoolConnection.SchoolConnectionId))
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
            ViewData["FK_CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", schoolConnection.FK_CourseId);
            ViewData["FK_StudentClassId"] = new SelectList(_context.StudentClasses, "StudentClassId", "StudentClassId", schoolConnection.FK_StudentClassId);
            ViewData["FK_StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", schoolConnection.FK_StudentId);
            ViewData["FK_TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "FirstName", schoolConnection.FK_TeacherId);
            return View(schoolConnection);
        }

        // GET: SchoolConnections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SchoolConnections == null)
            {
                return NotFound();
            }

            var schoolConnection = await _context.SchoolConnections
                .Include(s => s.Courses)
                .Include(s => s.StudentClasses)
                .Include(s => s.Students)
                .Include(s => s.Teachers)
                .FirstOrDefaultAsync(m => m.SchoolConnectionId == id);
            if (schoolConnection == null)
            {
                return NotFound();
            }

            return View(schoolConnection);
        }

        // POST: SchoolConnections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SchoolConnections == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SchoolConnections'  is null.");
            }
            var schoolConnection = await _context.SchoolConnections.FindAsync(id);
            if (schoolConnection != null)
            {
                _context.SchoolConnections.Remove(schoolConnection);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchoolConnectionExists(int id)
        {
          return (_context.SchoolConnections?.Any(e => e.SchoolConnectionId == id)).GetValueOrDefault();
        }
    }
}
