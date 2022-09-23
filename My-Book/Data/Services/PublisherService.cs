using Microsoft.EntityFrameworkCore;
using My_Book.Data.DTO;
using My_Book.Data.Model;

namespace My_Book.Data.Services
{
    public class PublisherService
    {
        private AppDbContext _context;
        public PublisherService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Publisher> AddPublisher(PublisherDTO publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name,
            };
            await _context.Publishers.AddAsync(_publisher);
            await _context.SaveChangesAsync();
            return _publisher;
        }


        public async Task<PublisherWithBookAndAuthorDTO> GetPublisherWithBookAndAuthor(int PubId)
        {
            var _publisher = await _context.Publishers.Where(p => p.Id == PubId)
                .Select(p => new PublisherWithBookAndAuthorDTO
                {
                    PublisherName = p.Name,
                    Book_Authors_List = p.Books.Select(x => new BookwithAuthor
                    {
                        Bookname = x.Title,
                        BookAuthors = x.Book_Authors.Select(x => x.Author.FullName).ToList()
                    }).ToList()
                }).FirstOrDefaultAsync();
            return _publisher;
        }


    }
}
