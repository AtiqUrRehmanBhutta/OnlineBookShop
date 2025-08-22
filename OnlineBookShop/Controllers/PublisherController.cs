using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookShop.Data;
using OnlineBookShop.Models;

namespace OnlineBookShop.Controllers
{
    public class PublisherController : Controller
    {
        private readonly AppDbContext _context;
        public PublisherController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            // This action will return a view that lists all publishers
            var publishers = await _context.Publishers.ToListAsync(); // Fetching all publishers from the database
            return View(publishers);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Publisher publisher)
        {
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                await _context.Publishers.AddAsync(publisher);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publisher); // Return the edit view with the publisher data
        }

        public async Task<IActionResult> Edit(int id)
        {
            var publisher = await _context.Publishers.FindAsync(id); // Finding the publisher by id
            if (publisher == null)
            {
                return NotFound(); // If publisher not found, return 404
            }
            return View(publisher); // Return the edit view with the publisher data
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                _context.Publishers.Update(publisher); // Updating the publisher in the database
                await _context.SaveChangesAsync(); // Saving changes to the database
                return RedirectToAction("Index"); // Redirecting to the Index action
            }
            return View(publisher); // If model state is invalid, return the same view with the publisher data
        }

        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var publisher = await _context.Publishers.FindAsync(id); // Finding the publisher by id
            if (publisher == null)
            {
                return NotFound(); // If publisher not found, return 404
            }
            _context.Publishers.Remove(publisher); // Removing the publisher from the database
            _context.SaveChanges(); // Saving changes to the database
            return RedirectToAction("Index"); // Redirecting to the Index action
        }

    }
}
