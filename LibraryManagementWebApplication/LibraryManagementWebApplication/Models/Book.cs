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
        public string Image {  get; set; }
        public Category Category { get; set; }
        [Range(0, float.MaxValue, ErrorMessage = "Please enter valid Price number")]
        public float Price { get; set; }
        [Range(0,10F, ErrorMessage = "Please enter valid rating")]
        public float Rating { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Pages count number")]
        public int PagesCount { get; set; }
        public bool InStock { get; set; }
    }
}
