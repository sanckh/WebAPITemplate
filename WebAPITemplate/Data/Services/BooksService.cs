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

        public void AddBookWithAuthors(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                Genre = book.Genre,
                isRead = book.isRead,
                DateRead = book.DateRead,
                Rating = book.Rating,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherId
            };

            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach (var id in book.AuthorIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };
                _context.Book_Authors.Add(_book_author);
                _context.SaveChanges();
            }
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

        public Book UpdateBookById(int bookId, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if(_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.DateRead = book.isRead ? book.DateRead.Value : null;
                _book.Genre = book.Genre;
                _book.isRead = book.isRead;
                _book.Rating = book.isRead ? book.Rating.Value : null;
                _book.CoverUrl = book.CoverUrl;

                _context.SaveChanges();
            }

            return _book;
        }

        public void DeleteBookById(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if (_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }
    }
}
