using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Book.Data.DTO;
using My_Book.Data.Model;

namespace My_Book.Data.Services
{
    //note: we have to add builder.Services.AddTransient<BookService>(); in Program.cs class
    public class BookService
    {

        private AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }


        //public async Task<IQueryable<Book>> GetAllBook()
        //{
        //    var allBookList = await _context.Books.ToListAsync();
        //    var allIquerable = allBookList.AsQueryable();
        //    return allIquerable;
        //}
        public async Task<IQueryable<BookWithAuthorDTO>> GetAllBook()
        {
            var allBookList = await _context.Books.Select(book => new BookWithAuthorDTO
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                Publisher = book.Publisher.Name,
                AuthorName = book.Book_Authors.Select(x => x.Author.FullName).ToList(),
            }).ToListAsync();
            var allIquerable = allBookList.AsQueryable();
            return (IQueryable<BookWithAuthorDTO>)allIquerable;
        }




        // if use FirstAsync method it will return exception However FirstOrDefaultAsync will return null if Book object is not found.
        //  public async Task<Book?> GetOneBook(int Id) => await _context.Books.FirstOrDefaultAsync(x => x.Id == Id);

        public async Task<BookWithAuthorDTO?> GetOneBook(int Id)
        {
            var _bookWithAuthorDTO = await _context.Books.Where(x => x.Id == Id).Select(book => new BookWithAuthorDTO
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                Publisher = book.Publisher.Name,
                AuthorName = book.Book_Authors.Select(x => x.Author.FullName).ToList(),
            }).FirstOrDefaultAsync();

            return _bookWithAuthorDTO;
        }
        public async Task<Book> AddBook(BookDTO bookDTO)
        {
            var _book = new Book()
            {
                Title = bookDTO.Title,
                Description = bookDTO.Description,
                IsRead = bookDTO.IsRead,
                DateRead = bookDTO.IsRead ? bookDTO.DateRead.Value : null,
                Rate = bookDTO.IsRead ? bookDTO.Rate.Value : null,
                Genre = bookDTO.Genre,
                CoverUrl = bookDTO.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = bookDTO.PublisherId,
            };
            //Add the _book object to Books Table
            await _context.Books.AddAsync(_book);
            //Save changes to the database
            await _context.SaveChangesAsync();

            //When the user input the Authors IDs in the swagger or postman, this block will run to input the Book and Author data in Book_Author Table
            foreach (var id in bookDTO.AuthorsIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,  // get the ID from _book and assign to the BookId property in Book_Author Table
                    AuthorId = id,     // get the IDs from bookDTO and assign to the AuthorId property in Author Table
                };
                //Add the _book_author object to Books_Author Table
                await _context.Books_Authors.AddAsync(_book_author);
                await _context.SaveChangesAsync();
            }
            return _book;
        }

        public async Task<Book?> UpdateBook(int _bookId, BookDTO book)
        {
            var _book = await _context.Books.FirstOrDefaultAsync(x => x.Id == _bookId);

            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.DateRead.Value;
                _book.Rate = book.Rate.Value;
                _book.Genre = book.Genre;
                _book.CoverUrl = book.CoverUrl;

                _context.Entry(_book).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return _book;
            }
            return null;

        }


        public async Task<Book?> DeleteBook(int _bookId)
        {
            var _book = await _context.Books.FirstOrDefaultAsync(x => x.Id == _bookId);

            if (_book != null)
            {
                _context.Books.Remove(_book);
                await _context.SaveChangesAsync();
                return _book;
            }
            return null;
        }
    }
}
