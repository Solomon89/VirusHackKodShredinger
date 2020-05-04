using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VirusHackKodShredinger.Repository;

namespace VirusHackKodShredinger.Controllers
{
    public class SchedulesController : Controller
    {
        private readonly ApplicationContext _context;

        public SchedulesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Schedules
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.Schedules.Include(s => s.People).Include(s => s.Subject);
            return View(await applicationContext.ToListAsync());
        }

        // GET: Schedules/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules
                .Include(s => s.People)
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // GET: Schedules/Create
        public IActionResult Create()
        {
            ViewData["PeopleId"] = new SelectList(_context.Peoples, "Id", nameof(People.Name));
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", nameof(Subject.Name));
            return View();
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PeopleId,SubjectId,DateTime,Note")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PeopleId"] = new SelectList(_context.Peoples, "Id", nameof(People.Name), schedule.PeopleId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", nameof(Subject.Name), schedule.SubjectId);
            return View(schedule);
        }

        // GET: Schedules/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            ViewData["PeopleId"] = new SelectList(_context.Peoples, "Id", nameof(People.Name), schedule.PeopleId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", nameof(Subject.Name), schedule.SubjectId);
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,PeopleId,SubjectId,DateTime,Note")] Schedule schedule)
        {
            if (id != schedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleExists(schedule.Id))
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
            ViewData["PeopleId"] = new SelectList(_context.Peoples, "Id", nameof(People.Name), schedule.PeopleId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", nameof(Subject.Name), schedule.SubjectId);
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules
                .Include(s => s.People)
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleExists(long id)
        {
            return _context.Schedules.Any(e => e.Id == id);
        }
    }
}
