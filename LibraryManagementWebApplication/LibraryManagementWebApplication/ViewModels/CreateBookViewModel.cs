using LibraryManagementWebApplication.Data.Enum;
using LibraryManagementWebApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebApplication.ViewModels
{
    public class CreateBookViewModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string? Publisher { get; set; }
        public IFormFile Image { get; set; }
        public Category Category { get; set; }
        [Range(0, float.MaxValue, ErrorMessage = "Enter a valid price")]
        public float Price { get; set; }
        [Range(0, 5F, ErrorMessage = "Enter a valid rating")]
        public float Rating { get; set; }
        public int PagesCount { get; set; }
        public bool InStock { get; set; }
    }
}
