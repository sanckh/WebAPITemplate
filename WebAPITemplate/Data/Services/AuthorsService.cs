using WebAPITemplate.Data.Models;
using WebAPITemplate.Data.ViewModels;

namespace WebAPITemplate.Data.Services
{
    public class AuthorsService
    {
        //injection
        private readonly AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVM book)
        {
            var _author = new Author()
            {
                FullName = book.FullName
            };

            _context.Authors.Add(_author);
            _context.SaveChanges();
        }
    }
}
