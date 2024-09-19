using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 1,
                    Title = "Sagan om Ringen",
                    Author = "J.R.R. Tolkien",
                    Published = 1954,
                    Genre = "Fantasy",
                    Description = "En episk fantasyberättelse om kampen mellan gott och ont.",
                    AvaliableForLoan = true
                },
                new Book
                {
                    BookId = 2,
                    Title = "Harry Potter och De Vises Sten",
                    Author = "J.K. Rowling",
                    Published = 1997,
                    Genre = "Fantasy",
                    Description = "Harry Potter upptäcker att han är en trollkarl och börjar på Hogwarts skola för häxkonster och trolldom.",
                    AvaliableForLoan = true
                },
                new Book
                {
                    BookId = 3,
                    Title = "Moby Dick",
                    Author = "Herman Melville",
                    Published = 1851,
                    Genre = "Äventyr",
                    Description = "Berättelsen om kapten Ahab och hans jakt på den vita valen, Moby Dick.",
                    AvaliableForLoan = true
                },
                new Book
                {
                    BookId = 4,
                    Title = "Oliver Twist",
                    Author = "Charles Dickens",
                    Published = 1837,
                    Genre = "Klassiker",
                    Description = "En föräldralös pojke försöker överleva i det viktorianska London.",
                    AvaliableForLoan = true
                },
                new Book
                {
                    BookId = 5,
                    Title = "Don Quijote",
                    Author = "Miguel de Cervantes",
                    Published = 1605,
                    Genre = "Klassiker",
                    Description = "En adelsman som blivit galen på grund av riddarromaner ger sig ut för att återuppliva riddartiden.",
                    AvaliableForLoan = true
                },
                new Book
                {
                    BookId = 6,
                    Title = "Den store Gatsby",
                    Author = "F. Scott Fitzgerald",
                    Published = 1925,
                    Genre = "Klassiker",
                    Description = "En berättelse om rikedom, kärlek och sorg i 1920-talets USA.",
                    AvaliableForLoan = false
                },
                
                new Book
                {
                    BookId = 7,
                    Title = "Frankenstein",
                    Author = "Mary Shelley",
                    Published = 1818,
                    Genre = "Gotisk skräck",
                    Description = "En ung vetenskapsman skapar en levande varelse, med oväntade konsekvenser.",
                    AvaliableForLoan = true
                },
                new Book
                {
                    BookId = 8,
                    Title = "Dracula",
                    Author = "Bram Stoker",
                    Published = 1897,
                    Genre = "Skräck",
                    Description = "Greve Dracula försöker flytta från Transsylvanien till England och sprida vampyrens förbannelse.",
                    AvaliableForLoan = true
                },
                new Book
                {
                    BookId = 9,
                    Title = "1984",
                    Author = "George Orwell",
                    Published = 1949,
                    Genre = "Dystopi",
                    Description = "En man kämpar mot ett totalitärt samhälle som styrs av övervakning och propaganda.",
                    AvaliableForLoan = false
                },
                new Book
                {
                    BookId = 10,
                    Title = "Brave New World",
                    Author = "Aldous Huxley",
                    Published = 1932,
                    Genre = "Dystopi",
                    Description = "En dystopisk framtid där samhället kontrolleras genom teknik och genetisk manipulation.",
                    AvaliableForLoan = true
                },
                new Book
                {
                    BookId = 11,
                    Title = "Anna Karenina",
                    Author = "Leo Tolstoy",
                    Published = 1877,
                    Genre = "Klassisk litteratur",
                    Description = "En komplex kärlekshistoria som utspelar sig i den ryska aristokratins värld.",
                    AvaliableForLoan = false
                },
                new Book
                {
                    BookId = 12,
                    Title = "Brott och Straff",
                    Author = "Fjodor Dostojevskij",
                    Published = 1866,
                    Genre = "Filosofisk roman",
                    Description = "En ung man som begår mord och brottas med skuld och moral.",
                    AvaliableForLoan = true
                }
            );
        }
    }
}
