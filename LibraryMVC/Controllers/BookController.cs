using LibraryAPI.Models.DTOs;
using LibraryMVC.Models;
using LibraryMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LibraryMVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> BookIndex()
        {
            List<BookDTO> list = new List<BookDTO>();

            var response = await _bookService.GetAllBooks<ResponseDTO>();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<BookDTO>>(Convert.ToString(response.Result));
            }
            
            return View(list);
        }

        public async Task<IActionResult> BookDetails(int id)
        {
            BookDTO bookDTO = new BookDTO();
            var response = await _bookService.GetBookById<ResponseDTO>(id);

            if (response != null && response.IsSuccess)
            {
                BookDTO model = JsonConvert.DeserializeObject<BookDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return View();
        }


        //Metod för att bara hämta och visa vyn
        public async Task<IActionResult> BookCreate()
        {
            return View();
        }


        //Metod för att fylla i formulär till en ny bok
        [HttpPost]
        public async Task<IActionResult> BookCreate(BookDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _bookService.CreateBookAsync<ResponseDTO>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(BookIndex));
                }
            }
            return View(model);
        }


        public async Task<IActionResult> UpdateBook(int bookId)
        {
            var response = await _bookService.GetBookById<ResponseDTO>(bookId);

            //Hämtar bokens aktuella data och fyller i den i formuläret
            if (response != null && response.IsSuccess)
            {
                BookDTO model = JsonConvert.DeserializeObject<BookDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBook(BookDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _bookService.UpdateBookAsync<ResponseDTO>(model);

                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(BookIndex));
                }
            }
            return View(model);
        }


        public async Task<IActionResult> DeleteBook(int bookId)
        {
            var response = await _bookService.GetBookById<ResponseDTO>(bookId);

            //Retunerar en vy där man får bekräfta borttagning av bok
            if (response != null && response.IsSuccess)
            {
                BookDeleteDTO model = JsonConvert.DeserializeObject<BookDeleteDTO>(Convert.ToString(response.Result));

                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBook(BookDeleteDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _bookService.DeleteBookAsync<ResponseDTO>(model.BookId);

                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(BookIndex));
                }
            }
            return RedirectToAction(nameof(BookIndex));
        }
    }
}
