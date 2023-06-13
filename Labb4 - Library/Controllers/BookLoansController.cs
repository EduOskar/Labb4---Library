using Labb4___Library.Data;
using Labb4___Library.Models;
using Labb4___Library.Service;
using Labb4___Library.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Labb4___Library.Controllers
{
    public class BookLoansController : Controller
    {
        private readonly IBookLoanService _bookLoansService;
        private readonly ApplicationDbContext _context;

        public BookLoansController(IBookLoanService bookLoansService, ApplicationDbContext context)
        {
            _bookLoansService = bookLoansService;
            _context = context;
        } public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;



            var ListContext = from c in _context.BookLoans.Include(bi => bi.Customers).Include(bo=>bo.Books).OrderBy(l => l.IsLoaned) select c;
            if (!string.IsNullOrEmpty(searchString))
            {
                ListContext = ListContext.Where(c => c.Books.Title.Contains(searchString)
                                             || c.Books.Author.Contains(searchString)
                                             || c.Customers.CustomerFirstName.Contains(searchString)
                                             || c.Customers.CustomersLastName.Contains(searchString)
                                             || c.Customers.Email.Contains(searchString));
            }
            return View(await ListContext.ToListAsync());
        }
        //Create
        public IActionResult Create()
        {
            ViewData["FKBookId"] = new SelectList(_context.BookItems, "BookId", "Title");
            ViewData["FKCustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerFirstName", "CustomersLastName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddLoan(BookLoans bookloan)
        {
            await _bookLoansService.AddBookLoan(bookloan);
            if (bookloan == null)
            {
                return BadRequest("Could not get loan");
            }
            return RedirectToAction("Index", "BookLoans");
        }
        //MARKRETURNED
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkReturned(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Customers");
            }
            var succesful = await _bookLoansService.MarkReturned(id);
            if (!succesful)
            {
                return BadRequest("Could not mark book as returned");
            }
            return RedirectToAction(nameof(Index));
        }



    }
}
