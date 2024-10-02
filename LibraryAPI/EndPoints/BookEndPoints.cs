using AutoMapper;
using LibraryAPI.Models;
using LibraryAPI.Models.DTOs;
using LibraryAPI.Service;

namespace LibraryAPI.EndPoints
{
    public static class BookEndPoints
    {
        public static void ConfigurationBookEndPoints(this WebApplication app)
        {
            app.MapGet("/api/books", GetAllBooks).WithName("GetBooks").Produces<APIResponse>();

            app.MapGet("/api/book/{id:int}", GetBook).WithName("GetBook").Produces<APIResponse>();
            app.MapGet("/api/book/title/{title}", GetBookByTitle).WithName("GetBookByTitle").Produces<APIResponse>();

            app.MapPost("/api/book", CreateBook).WithName("CreateBook").Accepts<CreateAndUpdateBookDTO>("application/json").Produces(201).Produces(400);

            app.MapPut("/api/book/{id:int}", UpdateBook)
                    .WithName("UpdateBook")
                    .Accepts<CreateAndUpdateBookDTO>("application/json")
                    .Produces<CreateAndUpdateBookDTO>(200)
                    .Produces(400);

            app.MapDelete("/api/book/{id:int}", DeleteBook).WithName("DeleteBook");
        }

        private static async Task<IResult> GetAllBooks(IBookRepository _bookRepo)
        {
            APIResponse response = new APIResponse();

            response.Result = await _bookRepo.GetAllBooksAsync();
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.OK;

            return Results.Ok(response);
        }

        private static async Task<IResult> GetBook(IBookRepository _bookRepo, int id)
        {
            APIResponse response = new APIResponse();


            var book = await _bookRepo.GetBookByIdAsync(id);

            //Skapar en lyckad respons om en bok kunde hittas
            if (book != null)
            {

                response.Result = await _bookRepo.GetBookByIdAsync(id);
                response.IsSuccess = true;
                response.StatusCode = System.Net.HttpStatusCode.OK;
                return Results.Ok(response);

            }

            //Skapar en false respons om bok inte kunde hittas
            else
            {
                response.IsSuccess = false;
                response.ErrorMessages.Add($"Book with Id {id} could not be found in the database");
                response.StatusCode = System.Net.HttpStatusCode.NotFound;

                return Results.NotFound(response);
            }
        }


        private static async Task<IResult> CreateBook(IBookRepository _bookRepo, IMapper _mapper, CreateAndUpdateBookDTO bookCreateDto)
        {
            APIResponse response = new() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

            // Mappa DTO till Book-modellen, BookId skapas automatiskt av databasen
            Book book = _mapper.Map<Book>(bookCreateDto);
            await _bookRepo.CreateAsync(book);
            await _bookRepo.SaveAsync();

            // Mappa tillbaka till DTO för att returnera som respons
            BookDTO bookDTO = _mapper.Map<BookDTO>(book);

            response.Result = bookDTO;
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.OK;

            return Results.Ok(response);
        }

        private static async Task<IResult> UpdateBook(IBookRepository _bookRepo, IMapper _mapper, int id, CreateAndUpdateBookDTO bookDto)
        {
            APIResponse response = new() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

            // Validera att boken finns i databasen
            var bookFromDb = await _bookRepo.GetBookByIdAsync(id);
            if (bookFromDb == null)
            {
                response.ErrorMessages.Add("Book could.");
                return Results.NotFound(response);
            }

            // Uppdatera bokens värden
            bookFromDb.Title = bookDto.Title;
            bookFromDb.Author = bookDto.Author;
            bookFromDb.Published = bookDto.Published;
            bookFromDb.Genre = bookDto.Genre;
            bookFromDb.Description = bookDto.Description;
            bookFromDb.AvaliableForLoan = bookDto.AvaliableForLoan;

            await _bookRepo.UpdateAsync(bookFromDb);
            await _bookRepo.SaveAsync();

            response.Result = _mapper.Map<CreateAndUpdateBookDTO>(bookFromDb);
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.OK;

            return Results.Ok(response);
        }


        private static async Task<IResult> DeleteBook(IBookRepository _bookRepo, int id)
        {
            APIResponse response = new() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

            //Hämtar boken som ska tas bort från databasen
            Book bookToDelete = await _bookRepo.GetBookByIdAsync(id);

            //Om den hittar en bok skapas och retuneras ett positivt svar
            if (bookToDelete != null)
            {
                await _bookRepo.DeleteAsync(bookToDelete);
                await _bookRepo.SaveAsync();
                response.IsSuccess = true;
                response.StatusCode = System.Net.HttpStatusCode.NoContent;
                return Results.Ok(response);
            } else
            {
                response.ErrorMessages.Add("Invalid ID");
                return Results.BadRequest(response);
            }

        }

        private static async Task<IResult> GetBookByTitle(IBookRepository _bookRepo, string title)
        {
            APIResponse response = new();

            var book = await _bookRepo.GetBookByTitleAsync(title);

            if (book != null)
            {
                response.Result = book;
                response.IsSuccess = true;
                response.StatusCode = System.Net.HttpStatusCode.OK;
                return Results.Ok(response);
            } else
            {
                response.IsSuccess = false;
                response.ErrorMessages.Add($"Book with title '{title}' could not be found in the database");
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                return Results.NotFound(response);
            }
        }
    }
}
