using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookShop.Data;
using OnlineBookShop.Data.Services;
using OnlineBookShop.Models;

namespace OnlineBookShop.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisherService;
        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }
        public async Task<IActionResult> Index()
        {
            // This action will return a view that lists all publishers
            var publishers = await _publisherService.GetAllPublishers(); // Fetching all publishers from the database
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
                await _publisherService.AddPublisher(publisher);
                return RedirectToAction("Index");
            }
            return View(publisher); // Return the edit view with the publisher data
        }

        public async Task<IActionResult> Edit(int id)
        {
            var publisher = await _publisherService.GetPublisherById(id); // Finding the publisher by id
            if (publisher == null)
            {
                return View("NotFound"); // If publisher not found, return 404
            }
            return View(publisher); // Return the edit view with the publisher data
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                await _publisherService.UpdatePublisher(publisher);
                return RedirectToAction("Index"); // Redirecting to the Index action
            }
            return View(publisher); // If model state is invalid, return the same view with the publisher data
        }

        public async Task<IActionResult> Delete(int id)
        {
            var publisher = await _publisherService.GetPublisherById(id); // Finding the publisher by id
            if (publisher == null)
            {
                return View("NotFound"); // If publisher not found, return 404
            }
            return View(publisher);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var publisher = await _publisherService.GetPublisherById(id); // Finding the publisher by id
            if (publisher == null)
            {
                return View("NotFound"); // If publisher not found, return 404
            }
            await _publisherService.DeletePublisher(publisher); // Deleting the publisher from the database
            return RedirectToAction("Index"); // Redirecting to the Index action
        }

    }
}
