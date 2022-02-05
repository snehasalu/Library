using Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repository
{
    public class BookRepo : IBooks
    {

        private readonly libContext _context;

        public BookRepo(libContext contaxt)
        {
            _context = contaxt;

        }

        public async Task<int> AddBook(Books books)
        {
            if (_context != null)
            {
                await _context.Books.AddAsync(books);
                await _context.SaveChangesAsync();
                return books.Bookid;
            }
            return 0;
        }

        public async Task<List<BookViewModel>> Details()
        {
            return await (
                    from g in _context.Genre
                    from b in _context.Books
                    where g.Gid == b.Bookid
                    select new BookViewModel
                    {
                        Bookid = b.Bookid,
                        Bookname = b.Bookname,
                        Gid = g.Gid,
                        Genre1 = g.Genre1
                    }).ToListAsync();
        }
        public async Task<List<Books>> GetAllBooks()
        {
            if (_context != null)
                return await _context.Books.ToListAsync();
            else
                return null;
        }

        public async Task UpdateBook(Books books)
        {
            if (_context != null)
            {
                _context.Entry(books).State = EntityState.Modified;
                _context.Books.Update(books);
                await _context.SaveChangesAsync();
            }
        }


    }
}
