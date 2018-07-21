using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SingleHack.Models;

namespace SingleHack.Controllers
{
    public class MatchersController : Controller
    {
        private readonly SingleHackContext _context;

        public MatchersController(SingleHackContext context)
        {
            _context = context;
        }

        // GET: Matchers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Matcher.ToListAsync());
        }

        // GET: Matchers/Details/5
        public async Task<IActionResult> Details()
        {
            return View(await _context.Matcher.ToListAsync());
        }

        // GET: Matchers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Matchers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        public string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Password")] Matcher matcher)
        {
            if (ModelState.IsValid)
            {
                matcher.Code = RandomString(5);
                _context.Add(matcher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(matcher);
        }

        // GET: Matchers/Edit/5
        public async Task<IActionResult> Edit()
        {
            return View();
        }

        // POST: Matchers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Password,Code")] Matcher matcher)
        {
            if (id != matcher.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matcher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatcherExists(matcher.ID))
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
            return View(matcher);
        }

        // GET: Matchers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matcher = await _context.Matcher
                .SingleOrDefaultAsync(m => m.ID == id);
            if (matcher == null)
            {
                return NotFound();
            }

            return View(matcher);
        }

        // POST: Matchers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matcher = await _context.Matcher.SingleOrDefaultAsync(m => m.ID == id);
            _context.Matcher.Remove(matcher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatcherExists(int id)
        {
            return _context.Matcher.Any(e => e.ID == id);
        }
    }
}
