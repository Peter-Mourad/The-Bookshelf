using LibraryManagementWebApplication.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebApplication.ViewModels
{
    public class EditBookViewModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string? Publisher { get; set; }
        public IFormFile Image { get; set; }    
        public string? Url { get; set; }
        public Category Category { get; set; }
        public float Price { get; set; }
        [Range(0, 5F, ErrorMessage = "Enter valid Rating")]
        public float Rating { get; set; }
        public int PagesCount { get; set; }
        public bool InStock { get; set; }
    }
}
