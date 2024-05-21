using LibraryManagementWebApplication.Data.Enum;
using LibraryManagementWebApplication.Models;

namespace LibraryManagementWebApplication.Interfaces
{
    public interface IBookRepository
    {
        Task <IEnumerable<Book>> GetAll();
        Task<Book> GetByIdAsync(int id);
        Task<IEnumerable<Book>> Search(string searchString);
        Task<IEnumerable<Book>> GetBooksInRangePrice(float minPrice, float maxPrice);
        Task<IEnumerable<Book>> GetBooksByCategory(Category category);
        bool Add(Book book);
        bool Update(Book book);
        bool Delete(Book book);
        bool Save();
    }
}
