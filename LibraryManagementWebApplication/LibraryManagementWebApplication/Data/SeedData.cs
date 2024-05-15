using LibraryManagementWebApplication.Models;
using LibraryManagementWebApplication.Data.Enum;

namespace LibraryManagementWebApplication.Data
{
    public class Seed
    {
        public static void seedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //Books
                if(!context.Books.Any())
                {
                    context.Books.AddRange(new List<Book>()
                    {
                        new Book()
                        {
                            Name = "Hamlet",
                            Author = "William shakespeare",
                            Publisher = "Simon & Schuster",
                            Category = Category.Drama,
                            Price = 399.99F,
                            PagesCount = 104,
                            InStock = true
                        },
                        new Book()
                        {
                            Name = "It",
                            Author = "Stephen King",
                            Publisher = "viking",
                            Category = Category.Horror,
                            Price = 299F,
                            PagesCount = 1134,
                            InStock = true
                        },
                        new Book()
                        {
                            Name = "The longest day",
                            Author = "Cornelius Ryan",
                            Publisher = "Simon & Schuster",
                            Category = Category.History,
                            Price = 513F,
                            PagesCount = 352,
                            InStock = true
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
