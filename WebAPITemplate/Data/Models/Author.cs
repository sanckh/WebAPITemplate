namespace WebAPITemplate.Data.Models
{
    public class Author
    {
        //many to many example. Many books, many authors
        public int Id { get; set; }
        public string FullName { get; set; }


        //navigation props
        public List<Book_Author> Book_Authors { get; set; }
    }
}
