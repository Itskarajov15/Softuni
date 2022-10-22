using Library.Data.Entities;
using Library.Models.Books;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookViewModel>> GetAllAsync();

        Task<IEnumerable<MineBookViewModel>> GetMineAsync(string userId);

        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task AddBookAsync(AddBookViewModel model);

        Task AddToCollectionAsync(int bookId, string userId);

        Task RemoveFromCollectionAsync(int bookId, string userId);
    }
}