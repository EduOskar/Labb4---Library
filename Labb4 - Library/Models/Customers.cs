
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb4___Library.Models
{
    public class Customers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("First Name")]
        public string CustomerFirstName { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Last Name")]
        public string CustomersLastName { get; set; }
        [Required]
        [StringLength(150)]
        public string Email { get; set; }
        [Required]
        [StringLength(maximumLength: 11, MinimumLength = 11, ErrorMessage ="Phonenumber need to be 11 digits")]
        public string PhoneNumber { get; set; }
        public string ImgURL { get; set; }

     
    }
}
