using Labb4___Library.Models;

namespace Labb4___Library.Service.IService
{
    public interface IBookLoanService
    {
        Task<List<Customers>> GetAllAsync();
        Task<Customers> GetAsync(int? id);
        Task CreateAsync(Customers entity);
        Task UpdateAsync(Customers entity);
        Task RemoveAsync(Customers entity);
        Task AddBookLoan(BookLoans entity);
        Task<Boolean> MarkReturned(int? id);
        Task<Customers> FindAsync(int? id);
        Task SaveAsync();

    }
}
