using Microsoft.AspNetCore.Identity;

namespace LibraryManagementWebApplication.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public ICollection<Book> BorrowedBooks { get; set; }
    }
}
