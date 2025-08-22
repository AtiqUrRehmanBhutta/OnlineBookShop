using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookShop.Data;
using OnlineBookShop.Data.Services;
using OnlineBookShop.Models;

namespace OnlineBookShop.Controllers
{
    public class AuthorController : Controller
    {
        private readonly AppDbContext _context;

        private readonly IAuthorService _authorService;
        public AuthorController(AppDbContext context, IAuthorService authorService)
        {
            _context = context;
            _authorService = authorService;
        }
        public async Task<IActionResult> Index()
        {
            var authors = await _authorService.GetAllAuthors();
            return View(authors);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Author author)
        {
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                await _authorService.AddAuthor(author);
                return RedirectToAction("Index");
            }
            return View(author);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return View("NotFound");
            }
            return View(author);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                await _authorService.UpdateAuthor(author);
                return RedirectToAction("Index");
            }
            return View(author);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            return author == null ? View("NotFound") : View(author);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return View("NotFound");
            }
            await _authorService.DeleteAuthor(author);
            return RedirectToAction("Index");
        }
    }
}
