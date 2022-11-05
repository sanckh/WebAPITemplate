using WebAPITemplate.Data.Models;

namespace WebAPITemplate.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "Go Ask Alice",
                        Description = "The harrowing true story of a teenager's descent into the seductive world of drugs.",
                        Genre = "Fiction",
                        isRead = true,
                        DateRead = DateTime.Now,
                        Rating = 4,
                        CoverUrl = "Placeholder",
                        DateAdded = DateTime.Now  
                    },

                    new Book()
                    {
                        Title = "Jay's Journal",
                        Description = "Jay thought he could handle anything. The first time he took drugs was for fun. But what started as an escape quickly spiraled into a haze of addiction.",
                        Genre = "Fiction",
                        isRead = true,
                        DateRead = DateTime.Now,
                        Rating = 4,
                        CoverUrl = "Placeholder",
                        DateAdded = DateTime.Now
                    }

                    );

                    context.SaveChanges();
                }
            }
        }
    }
}
