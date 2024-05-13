using LibraryManagementWebApplication.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementWebApplication.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string? Publisher { get; set; }
        public Category Category { get; set; }
        public float Price { get; set; }
        public int PagesCount { get; set; }
        public bool InStock { get; set; }
    }
}
