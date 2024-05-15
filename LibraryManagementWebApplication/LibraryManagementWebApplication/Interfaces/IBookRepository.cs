using LibraryManagementWebApplication.Models;

namespace LibraryManagementWebApplication.Interfaces
{
    public interface IBookRepository
    {
        Task <IEnumerable<Book>> GetAll();
        Task<Book> GetByIdAsync(int id);
        bool Add(Book book);
        bool Update(Book book);
        bool Delete(Book book);
        bool Save();
    }
}
