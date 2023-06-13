using Labb4___Library.Data;
using Labb4___Library.Models;
using Labb4___Library.Service.IService;
using Microsoft.EntityFrameworkCore;

namespace Labb4___Library.Service
{
    public class BookLoansService : IBookLoanService
    {
        private readonly ApplicationDbContext _context;
        public BookLoansService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddBookLoan(BookLoans newLoan)
        {
            newLoan.Loaned = DateTime.Now.AddDays(30);
            newLoan.IsLoaned = false;
            await _context.BookLoans.AddAsync(newLoan);
            await SaveAsync();
        }
        public async Task<bool> MarkReturned(int? id)
        {
            var book = await _context.BookLoans
                .Where(x => x.BookLoanId == id)
                .SingleOrDefaultAsync();
            if (book == null) return false;
            book.IsLoaned = true;
            book.IsReturned = DateTime.Now;
            var save = await _context.SaveChangesAsync();
            return save == 1;
        }

        public async Task CreateAsync(Customers entity)
        {
            await _context.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<Customers> FindAsync(int? id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<List<Customers>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customers> GetAsync(int? id)
        {
            return await _context.Customers.FirstOrDefaultAsync(c=>c.CustomerId == id);
        }

       

        public async Task RemoveAsync(Customers entity)
        {
            _context.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customers entity)
        {
            _context.Update(entity);
            await SaveAsync();
        }
    }
}
