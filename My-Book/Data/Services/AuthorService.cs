using Microsoft.EntityFrameworkCore;
using My_Book.Data.DTO;
using My_Book.Data.Model;

namespace My_Book.Data.Services
{
    public class AuthorService
    {
        private AppDbContext _context;

        public AuthorService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<Author> AddAuthor(AuthorDTO author)
        {
            var _author = new Author()
            {
               FullName = author.FullName,
            };

            await _context.Authors.AddAsync(_author);
            await _context.SaveChangesAsync();
            return _author;
        }

        public async Task<AuthorWithBooksDTO> GetAuthorWithBook(int authorId)
        {
            var _author = await _context.Authors.Where(a => a.Id == authorId)
                 .Select(a => new AuthorWithBooksDTO
                 {
                    AuthorId = a.Id,
                    FullName=a.FullName,
                    BookNames = a.Book_Authors.Select(ba => ba.Book.Title).ToList(),
                 }).FirstOrDefaultAsync();

            return _author;
        }


    }
}
