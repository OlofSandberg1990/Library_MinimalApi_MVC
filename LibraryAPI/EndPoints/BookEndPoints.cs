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

            app.MapPost("/api/book", CreateBook).WithName("CreateBook").Accepts<CreateAndUpdateBookDTO>("application/json").Produces(201).Produces(400);

            app.MapPut("/api/book", UpdateBook).WithName("UpdateBook").Accepts<CreateAndUpdateBookDTO>("application/json").Produces<CreateAndUpdateBookDTO>(200).Produces(400);

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

            //Kontrollerar om det redan finns en bok med den titeln i databasen
            if (_bookRepo.GetBookByTitleAsync(bookCreateDto.Title).GetAwaiter().GetResult() != null)
            {
                response.ErrorMessages.Add("Book title already exists in the database");
                return Results.BadRequest(response);
            }

            //Annars mappas och skapas boken för att sedan läggas till i databasen och skicka en lyckad response
            Book book = _mapper.Map<Book>(bookCreateDto);
            await _bookRepo.CreateAsync(book);
            await _bookRepo.SaveAsync();
            BookDTO bookDTO = _mapper.Map<BookDTO>(book);

            response.Result = bookDTO;
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.OK;

            return Results.Ok(response);

        }

        private static async Task<IResult> UpdateBook(IBookRepository _bookRepo, IMapper _mapper, CreateAndUpdateBookDTO bookDto)
        {
            APIResponse response = new() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

            await _bookRepo.UpdateAsync(_mapper.Map<Book>(bookDto));
            await _bookRepo.SaveAsync();

            response.Result = _mapper.Map<CreateAndUpdateBookDTO>(await _bookRepo.GetBookByIdAsync(bookDto.BookId));
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
    }
}
