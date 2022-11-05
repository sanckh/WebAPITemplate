using WebAPITemplate.Data.Models;
using WebAPITemplate.Data.ViewModels;

namespace WebAPITemplate.Data.Services
{
    public class BooksService
    {
        private readonly AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Genre = book.Genre,
                isRead = book.isRead,
                DateRead = book.DateRead,
                Rating = book.Rating,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now
            };

            _context.Books.Add(_book);
            _context.SaveChanges();
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
            //can also use public List<Book> GetAllBooks() => _context.Books.ToList();
        }

        public Book GetBookById(int bookId)
        {
            return _context.Books.FirstOrDefault(n => n.Id == bookId);
        }
    }
}
