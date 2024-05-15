using LibraryManagementWebApplication.Data.Enum;

namespace LibraryManagementWebApplication.ViewModels
{
    public class EditBookViewModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string? Publisher { get; set; }
        public Category Category { get; set; }
        public float Price { get; set; }
        public int PagesCount { get; set; }
        public bool InStock { get; set; }
    }
}
