using LibraryManagementWebApplication.Data;
using LibraryManagementWebApplication.Data.Enum;
using LibraryManagementWebApplication.Interfaces;
using LibraryManagementWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementWebApplication.Repository
{
    public class BookRepository : IBookRepository
    {
        public readonly AppDbContext _context;
        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Add(Book book)
        {
            _context.Add(book);
            return Save();
        }

        public bool Delete(Book book)
        {
            _context.Remove(book);
            return Save();
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByCategory(Category category)
        {
            return await _context.Books.Where(book => book.Category == category).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksInRangePrice(float minPrice, float maxPrice)
        {
            return await _context.Books.Where(book => book.Price >= minPrice && book.Price <= maxPrice).ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(book => book.Id == id);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }

        public async Task<IEnumerable<Book>> Search(string searchString)
        {
            return await _context.Books.Where(book => book.Name.ToLower().Contains(searchString.ToLower())
            || book.Author.ToLower().Contains(searchString.ToLower())).ToListAsync();
        }

        public bool Update(Book book)
        {
            _context.Update(book);
            return Save();
        }
    }
}