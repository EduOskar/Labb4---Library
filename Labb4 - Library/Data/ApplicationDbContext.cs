using Labb4___Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb4___Library.Data
{
    public class ApplicationDbContext : DbContext
    {
        internal int custId = 1;
        internal int bookId = 1;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BookItems> BookItems { get; set; }
        public DbSet<BookLoans> BookLoans { get; set; }
        public DbSet<Customers> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>().HasData(
                    new Customers
                    {
                        CustomerId = 1,
                        CustomerFirstName = "Oskar",
                        CustomersLastName = "Åhling",
                        Email = "Oskar@Mail.com",
                        PhoneNumber = "070-2138149",
                        ImgURL = ""
                    },
                    new Customers
                    {
                        CustomerId = 2,
                        CustomerFirstName = "Ina",
                        CustomersLastName = "Nilsson",
                        Email = "Ina@Mail.com",
                        PhoneNumber = "070-2138150",
                        ImgURL = ""
                    },
                     new Customers
                     {
                         CustomerId = 3,
                         CustomerFirstName = "Bamse",
                         CustomersLastName = "Bomsisson",
                         Email = "Bomse@Mail.com",
                         PhoneNumber = "070-0909090",
                         ImgURL = ""
                     }
                );
            modelBuilder.Entity<BookItems>().HasData(
                       new BookItems
                       {
                           BookId = 1,
                           Title = "Song of ice and fire",
                           Author = "George RR Martin",
                           Description = "Fantasybook about ice and fire",
                           Quantity = 4,
                       },
                       new BookItems
                       {
                           BookId = 2,
                           Title = "Lord of the rings",
                           Author = "Tolkien",
                           Description = "Fantasybook about Gandalf mostly",
                           Quantity = 3,
                       },
                       new BookItems
                       {
                           BookId = 3,
                           Title = "Story of the two towers",
                           Author = "Tolkien",
                           Description = "Fantasybook about Gandalf mostly",
                           Quantity = 3,
                       },
                       new BookItems
                       {
                           BookId = 4,
                           Title = "Return of the king",
                           Author = "Tolkien",
                           Description = "Fantasybook about Gandalf mostly",
                           Quantity = 3,
                       },
                       new BookItems
                       {
                           BookId = 5,
                           Title = "Marley and Me",
                           Author = "John Grogan",
                           Description = "My life with the craziest dog ever as a companion",
                           Quantity = 2,
                       },
                         new BookItems
                         {
                             BookId = 6,
                             Title = "Pablo Escobar Memoirs",
                             Author = "Sebastian Marroquin",
                             Description = "Pablo Escobars life and death",
                             Quantity = 1,
                         });


        }


    }


}
