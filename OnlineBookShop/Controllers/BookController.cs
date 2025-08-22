using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using OnlineBookShop.Data;
using OnlineBookShop.Models;

namespace OnlineBookShop.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDbContext _context;
        public BookController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            // This action will return a view that lists all books
            var books = await _context.Books.ToListAsync(); // Fetching all books from the database
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
                _context.Books.Add(book); // Adding the new book to the database
                await _context.SaveChangesAsync(); // Saving changes to the database
                return RedirectToAction("Index"); // Redirecting to the Index action
            }
            return View(book); // If model state is invalid, return the same view with the book data
        }

        public async Task<IActionResult> Edit(int id)
        {
            var book = await _context.Books.FindAsync(id);
           
            if (book == null)
            {
                return NotFound(); // If book not found, return 404
            }
            return View(book); // Return the edit view with the book data
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Book book)
        {
            ModelState.Remove("Publisher"); // Correctly removing the Publisher field from model state using its string key
            if (ModelState.IsValid)
            {
                _context.Books.Update(book); // Updating the book in the database
                await _context.SaveChangesAsync(); // Saving changes to the database
                return RedirectToAction("Index"); // Redirecting to the Index action
            }
            return View(book); // If model state is invalid, return the same view with the book data
        }
        public async Task<IActionResult> Delete()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _context.Books.FindAsync(id); // Finding the book by id
            if (book == null)
            {
                return NotFound(); // If book not found, return 404
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
