using Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Repository
{
    public interface IBooks
    {
        Task<List<Books>> GetAllBooks();
        Task<int> AddBook(Books books);

        Task UpdateBook(Books books);
        Task<List<BookViewModel>> Details();
    }
}
