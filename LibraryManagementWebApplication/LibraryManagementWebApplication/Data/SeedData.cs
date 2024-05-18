using LibraryManagementWebApplication.Models;
using LibraryManagementWebApplication.Data.Enum;
using Microsoft.AspNetCore.Identity;

namespace LibraryManagementWebApplication.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
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
                            Rating = 4.4F,
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
                            Rating = 4.5F,
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
                            Rating = 4.8F,
                            PagesCount = 352,
                            InStock = true
                        }
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRoles(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                // Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if (!await roleManager.RoleExistsAsync("Admin"))
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                if (!await roleManager.RoleExistsAsync("User"))
                    await roleManager.CreateAsync(new IdentityRole("User"));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                string email = "admin@admin.com";
                string password = "Admin.202";
                if(await userManager.FindByEmailAsync(email)==null)
                {
                    var user = new User
                    {
                        Email = email,
                        UserName = "admin",
                        EmailConfirmed = true,
                    };
                    
                    await userManager.CreateAsync(user, password);
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}
