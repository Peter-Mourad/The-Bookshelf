using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebApplication.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Address1 { get; set; }
        public string? Address2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public string PostalCode { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
