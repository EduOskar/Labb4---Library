using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Labb4___Library.Data;
using Labb4___Library.Models;

namespace Labb4___Library.Controllers
{
    public class BookItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookItems
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var books = from c in _context.BookItems select c;
            if (!string.IsNullOrEmpty(searchString))
            {
                books = books.Where(c => c.Title.Contains(searchString)
                                             || c.Description.Contains(searchString)
                                             || c.Author.Contains(searchString));
            }

            return View(await books.AsNoTracking().ToListAsync());
        }

        // GET: BookItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookItems == null)
            {
                return NotFound();
            }

            var bookItems = await _context.BookItems
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (bookItems == null)
            {
                return NotFound();
            }

            return View(bookItems);
        }

        // GET: BookItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,Title,Description,Author,Quantity")] BookItems bookItems)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookItems);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookItems);
        }

        // GET: BookItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookItems == null)
            {
                return NotFound();
            }

            var bookItems = await _context.BookItems.FindAsync(id);
            if (bookItems == null)
            {
                return NotFound();
            }
            return View(bookItems);
        }

        // POST: BookItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,Title,Description,Author,Quantity")] BookItems bookItems)
        {
            if (id != bookItems.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookItems);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookItemsExists(bookItems.BookId))
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
            return View(bookItems);
        }

        // GET: BookItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookItems == null)
            {
                return NotFound();
            }

            var bookItems = await _context.BookItems
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (bookItems == null)
            {
                return NotFound();
            }

            return View(bookItems);
        }

        // POST: BookItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookItems == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BookItems'  is null.");
            }
            var bookItems = await _context.BookItems.FindAsync(id);
            if (bookItems != null)
            {
                _context.BookItems.Remove(bookItems);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookItemsExists(int id)
        {
          return _context.BookItems.Any(e => e.BookId == id);
        }
    }
}
