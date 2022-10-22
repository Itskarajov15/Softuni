using Library.Contracts;
using Library.Data;
using Library.Data.Entities;
using Library.Models.Books;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext context;

        public BookService(LibraryDbContext context)
        {
            this.context = context;
        }

        public async Task AddBookAsync(AddBookViewModel model)
        {
            var book = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                CategoryId = model.CategoryId,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating
            };

            await this.context.Books.AddAsync(book);
            await this.context.SaveChangesAsync();
        }

        public async Task AddToCollectionAsync(int bookId, string userId)
        {
            var user = await this.context
                .Users
                .Where(u => u.Id == userId)
                .Include(u => u.ApplicationUsersBooks)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid User ID");
            }

            var book = await this.context.Books.FirstOrDefaultAsync(b => b.Id == bookId);

            if (book == null)
            {
                throw new ArgumentException("Invalid Book ID");
            }

            if (!user.ApplicationUsersBooks.Any(ub => ub.BookId == bookId))
            {
                user.ApplicationUsersBooks.Add(new ApplicationUserBook
                {
                    ApplicationUserId = userId,
                    BookId = bookId
                });

                await this.context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BookViewModel>> GetAllAsync()
        {
            var books = await this.context
                .Books
                .Select(b => new BookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Category = b.Category.Name,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating 
                })
                .ToListAsync();

            return books;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
            => await this.context
                         .Categories
                         .ToListAsync();

        public async Task<IEnumerable<MineBookViewModel>> GetMineAsync(string userId)
        {
            var user = await this.context
                .Users
                .Where(u => u.Id == userId)
                .Include(u => u.ApplicationUsersBooks)
                .ThenInclude(ub => ub.Book)
                .ThenInclude(ub => ub.Category)
                .FirstOrDefaultAsync();

            return user.ApplicationUsersBooks
                .Select(ub => new MineBookViewModel
                {
                    Id = ub.BookId,
                    Author = ub.Book.Author,
                    Category = ub.Book.Category.Name,
                    Description = ub.Book.Description,
                    ImageUrl = ub.Book.ImageUrl,
                    Rating = ub.Book.Rating,
                    Title = ub.Book.Title
                })
                .ToList();
        }

        public async Task RemoveFromCollectionAsync(int bookId, string userId)
        {
            var user = await this.context
                .Users
                .Where(u => u.Id == userId)
                .Include(u => u.ApplicationUsersBooks)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid User ID");
            }

            var book = user.ApplicationUsersBooks.FirstOrDefault(b => b.BookId == bookId);

            if (book != null)
            {
                user.ApplicationUsersBooks.Remove(book);
                await this.context.SaveChangesAsync();
            }
        }
    }
}