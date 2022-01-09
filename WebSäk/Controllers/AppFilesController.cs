using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSäk.Data;
using WebSäk.Models;

namespace WebSäk.Controllers
{
    public class AppFilesController : Controller
    {
        private readonly WebSäkContext _context;

        public AppFilesController(WebSäkContext context)
        {
            _context = context;
        }

        // GET: AppFiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.AppFile.ToListAsync());
        }

        // GET: AppFiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appFile = await _context.AppFile
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appFile == null)
            {
                return NotFound();
            }

            return View(appFile);
        }

        // GET: AppFiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppFiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UntrustedName,TimeStamp,Size,Content")] AppFile appFile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appFile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appFile);
        }

        // GET: AppFiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appFile = await _context.AppFile.FindAsync(id);
            if (appFile == null)
            {
                return NotFound();
            }
            return View(appFile);
        }

        // POST: AppFiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UntrustedName,TimeStamp,Size,Content")] AppFile appFile)
        {
            if (id != appFile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appFile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppFileExists(appFile.Id))
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
            return View(appFile);
        }

        // GET: AppFiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appFile = await _context.AppFile
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appFile == null)
            {
                return NotFound();
            }

            return View(appFile);
        }

        // POST: AppFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appFile = await _context.AppFile.FindAsync(id);
            _context.AppFile.Remove(appFile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppFileExists(int id)
        {
            return _context.AppFile.Any(e => e.Id == id);
        }
    }
}
