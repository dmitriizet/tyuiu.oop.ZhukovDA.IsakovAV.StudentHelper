using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tyuiu.oop.ZhukovDA.IsakovAV.StudentHelper.DataModels;

namespace tyuiu.oop.ZhukovDA.IsakovAV.StudentHelper.Controllers
{
    public class HelpersController : Controller
    {
        private readonly MyDBContext _context;

        public HelpersController(MyDBContext context)
        {
            _context = context;
        }

        // GET: Helpers
        public async Task<IActionResult> Index()
        {
              return _context.Helpers != null ? 
                          View(await _context.Helpers.ToListAsync()) :
                          Problem("Entity set 'MyDBContext.Helpers'  is null.");
        }

        // GET: Helpers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Helpers == null)
            {
                return NotFound();
            }

            var helper = await _context.Helpers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (helper == null)
            {
                return NotFound();
            }

            return View(helper);
        }

        // GET: Helpers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Helpers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Subject,Duration")] Helper helper)
        {
            if (ModelState.IsValid)
            {
                _context.Add(helper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(helper);
        }

        // GET: Helpers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Helpers == null)
            {
                return NotFound();
            }

            var helper = await _context.Helpers.FindAsync(id);
            if (helper == null)
            {
                return NotFound();
            }
            return View(helper);
        }

        // POST: Helpers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Subject,Duration")] Helper helper)
        {
            if (id != helper.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(helper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HelperExists(helper.Id))
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
            return View(helper);
        }

        // GET: Helpers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Helpers == null)
            {
                return NotFound();
            }

            var helper = await _context.Helpers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (helper == null)
            {
                return NotFound();
            }

            return View(helper);
        }

        // POST: Helpers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Helpers == null)
            {
                return Problem("Entity set 'MyDBContext.Helpers'  is null.");
            }
            var helper = await _context.Helpers.FindAsync(id);
            if (helper != null)
            {
                _context.Helpers.Remove(helper);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HelperExists(int id)
        {
          return (_context.Helpers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
