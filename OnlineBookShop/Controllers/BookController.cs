using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using OnlineBookShop.Data;
using OnlineBookShop.Data.Services;
using OnlineBookShop.Models;

namespace OnlineBookShop.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        public async Task<IActionResult> Index()
        {
            // This action will return a view that lists all books
            var books = await _bookService.GetAllBooks(); // Fetching all books from the database
            return View(books);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            ModelState.Remove("Id");
            ModelState.Remove("Publisher");
            if (ModelState.IsValid)
            {
                await _bookService.AddBook(book); // Adding the new book to the database
                return RedirectToAction("Index"); // Redirecting to the Index action
            }
            return View(book); // If model state is invalid, return the same view with the book data
        }

        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.GetBookById(id);
            if (book == null)
            {
                return View("NotFound"); // If book not found, return 404
            }
            return View(book); // Return the edit view with the book data
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Book book)
        {
            ModelState.Remove("Publisher"); // Correctly removing the Publisher field from model state using its string key
            if (ModelState.IsValid)
            {
                await _bookService.UpdateBook(book); // Updating the book in the database
                return RedirectToAction("Index"); // Redirecting to the Index action
            }
            return View(book); // If model state is invalid, return the same view with the book data
        }
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookService.GetBookById(id); // Finding the book by id
            if (book == null)
            {
                return View("NotFound"); // If book not found, return 404
            }
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var book = await _bookService.GetBookById(id); // Finding the book by id
            if (book == null)
            {
                return View("NotFound"); // If book not found, return 404
            }
            await _bookService.DeleteBook(book); // Deleting the book from the database
           
            return RedirectToAction("Index");
        }
    }
}
