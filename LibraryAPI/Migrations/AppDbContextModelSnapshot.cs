﻿// <auto-generated />
using LibraryAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibraryAPI.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AvaliableForLoan")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Published")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            Author = "J.R.R. Tolkien",
                            AvaliableForLoan = true,
                            Description = "En episk fantasyberättelse om kampen mellan gott och ont.",
                            Genre = "Fantasy",
                            Published = 1954,
                            Title = "Sagan om Ringen"
                        },
                        new
                        {
                            BookId = 2,
                            Author = "J.K. Rowling",
                            AvaliableForLoan = true,
                            Description = "Harry Potter upptäcker att han är en trollkarl och börjar på Hogwarts skola för häxkonster och trolldom.",
                            Genre = "Fantasy",
                            Published = 1997,
                            Title = "Harry Potter och De Vises Sten"
                        },
                        new
                        {
                            BookId = 3,
                            Author = "Herman Melville",
                            AvaliableForLoan = true,
                            Description = "Berättelsen om kapten Ahab och hans jakt på den vita valen, Moby Dick.",
                            Genre = "Äventyr",
                            Published = 1851,
                            Title = "Moby Dick"
                        },
                        new
                        {
                            BookId = 4,
                            Author = "Charles Dickens",
                            AvaliableForLoan = true,
                            Description = "En föräldralös pojke försöker överleva i det viktorianska London.",
                            Genre = "Klassiker",
                            Published = 1837,
                            Title = "Oliver Twist"
                        },
                        new
                        {
                            BookId = 5,
                            Author = "Miguel de Cervantes",
                            AvaliableForLoan = true,
                            Description = "En adelsman som blivit galen på grund av riddarromaner ger sig ut för att återuppliva riddartiden.",
                            Genre = "Klassiker",
                            Published = 1605,
                            Title = "Don Quijote"
                        },
                        new
                        {
                            BookId = 6,
                            Author = "F. Scott Fitzgerald",
                            AvaliableForLoan = false,
                            Description = "En berättelse om rikedom, kärlek och sorg i 1920-talets USA.",
                            Genre = "Klassiker",
                            Published = 1925,
                            Title = "Den store Gatsby"
                        },
                        new
                        {
                            BookId = 7,
                            Author = "Mary Shelley",
                            AvaliableForLoan = true,
                            Description = "En ung vetenskapsman skapar en levande varelse, med oväntade konsekvenser.",
                            Genre = "Gotisk skräck",
                            Published = 1818,
                            Title = "Frankenstein"
                        },
                        new
                        {
                            BookId = 8,
                            Author = "Bram Stoker",
                            AvaliableForLoan = true,
                            Description = "Greve Dracula försöker flytta från Transsylvanien till England och sprida vampyrens förbannelse.",
                            Genre = "Skräck",
                            Published = 1897,
                            Title = "Dracula"
                        },
                        new
                        {
                            BookId = 9,
                            Author = "George Orwell",
                            AvaliableForLoan = false,
                            Description = "En man kämpar mot ett totalitärt samhälle som styrs av övervakning och propaganda.",
                            Genre = "Dystopi",
                            Published = 1949,
                            Title = "1984"
                        },
                        new
                        {
                            BookId = 10,
                            Author = "Aldous Huxley",
                            AvaliableForLoan = true,
                            Description = "En dystopisk framtid där samhället kontrolleras genom teknik och genetisk manipulation.",
                            Genre = "Dystopi",
                            Published = 1932,
                            Title = "Brave New World"
                        },
                        new
                        {
                            BookId = 11,
                            Author = "Leo Tolstoy",
                            AvaliableForLoan = false,
                            Description = "En komplex kärlekshistoria som utspelar sig i den ryska aristokratins värld.",
                            Genre = "Klassisk litteratur",
                            Published = 1877,
                            Title = "Anna Karenina"
                        },
                        new
                        {
                            BookId = 12,
                            Author = "Fjodor Dostojevskij",
                            AvaliableForLoan = true,
                            Description = "En ung man som begår mord och brottas med skuld och moral.",
                            Genre = "Filosofisk roman",
                            Published = 1866,
                            Title = "Brott och Straff"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
