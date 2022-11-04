using Microsoft.EntityFrameworkCore;
using WebAPITemplate.Data.Models;

namespace WebAPITemplate.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //Db Tables
        public DbSet<Book> Books { get; set; }
    }
}
