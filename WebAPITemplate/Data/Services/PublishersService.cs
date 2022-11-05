using WebAPITemplate.Data.Models;
using WebAPITemplate.Data.ViewModels;

namespace WebAPITemplate.Data.Services
{
    public class PublishersService
    {
        //injection
        private readonly AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };

            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }
    }
}
