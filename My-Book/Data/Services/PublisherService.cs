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



    }
}
