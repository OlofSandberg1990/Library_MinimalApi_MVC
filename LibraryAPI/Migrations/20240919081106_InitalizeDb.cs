using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitalizeDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Published = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvaliableForLoan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "AvaliableForLoan", "Description", "Genre", "Published", "Title" },
                values: new object[,]
                {
                    { 1, "J.R.R. Tolkien", true, "En episk fantasyberättelse om kampen mellan gott och ont.", "Fantasy", 1954, "Sagan om Ringen" },
                    { 2, "J.K. Rowling", true, "Harry Potter upptäcker att han är en trollkarl och börjar på Hogwarts skola för häxkonster och trolldom.", "Fantasy", 1997, "Harry Potter och De Vises Sten" },
                    { 3, "Herman Melville", true, "Berättelsen om kapten Ahab och hans jakt på den vita valen, Moby Dick.", "Äventyr", 1851, "Moby Dick" },
                    { 4, "Charles Dickens", true, "En föräldralös pojke försöker överleva i det viktorianska London.", "Klassiker", 1837, "Oliver Twist" },
                    { 5, "Miguel de Cervantes", true, "En adelsman som blivit galen på grund av riddarromaner ger sig ut för att återuppliva riddartiden.", "Klassiker", 1605, "Don Quijote" },
                    { 6, "F. Scott Fitzgerald", false, "En berättelse om rikedom, kärlek och sorg i 1920-talets USA.", "Klassiker", 1925, "Den store Gatsby" },
                    { 7, "Mary Shelley", true, "En ung vetenskapsman skapar en levande varelse, med oväntade konsekvenser.", "Gotisk skräck", 1818, "Frankenstein" },
                    { 8, "Bram Stoker", true, "Greve Dracula försöker flytta från Transsylvanien till England och sprida vampyrens förbannelse.", "Skräck", 1897, "Dracula" },
                    { 9, "George Orwell", false, "En man kämpar mot ett totalitärt samhälle som styrs av övervakning och propaganda.", "Dystopi", 1949, "1984" },
                    { 10, "Aldous Huxley", true, "En dystopisk framtid där samhället kontrolleras genom teknik och genetisk manipulation.", "Dystopi", 1932, "Brave New World" },
                    { 11, "Leo Tolstoy", false, "En komplex kärlekshistoria som utspelar sig i den ryska aristokratins värld.", "Klassisk litteratur", 1877, "Anna Karenina" },
                    { 12, "Fjodor Dostojevskij", true, "En ung man som begår mord och brottas med skuld och moral.", "Filosofisk roman", 1866, "Brott och Straff" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
