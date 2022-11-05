namespace WebAPITemplate.Data.Models
{
    public class Book_Author
    {
        //many to many example, many books many authors. This model is our join model

        public int Id { get; set; }

        //navigation props for book and author
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }

    }
}
