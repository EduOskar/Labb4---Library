using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb4___Library.Models
{
    public class BookLoans
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? BookLoanId { get; set; }
        //ForeignKeys
        [ForeignKey("Customers")]
        public int? FKCustomerId { get; set; }
        public Customers? Customers { get; set; }
        [ForeignKey("Books")]
        public int? FkBookId { get; set; }
        public BookItems? Books { get; set; }
        //End of foreignKeys
        public DateTime Loaned { get; set; } = DateTime.UtcNow.Date;
        public DateTime IsReturned { get; set; } = DateTime.UtcNow.Date.AddDays(14);
        public Boolean IsLoaned { get; set; }
    }
}
