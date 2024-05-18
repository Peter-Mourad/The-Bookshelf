using LibraryManagementWebApplication.Interfaces;
using LibraryManagementWebApplication.Models;
using LibraryManagementWebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementWebApplication.Controllers
{
    public class BookController : Controller
    {

        private readonly IBookRepository _repository;
        private readonly IPhotoService _photoService;
        public BookController(IBookRepository repository, IPhotoService photoService)
        {
            _repository = repository;
            _photoService = photoService;
        }
        public async Task<IActionResult> Index()
        {
            var books = await _repository.GetAll();
            return View(books);
        }

        public async Task<IActionResult> Details(int id)
        {
            var book = await _repository.GetByIdAsync(id);
            return View(book);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookViewModel createBookViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["ValidationError"] = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
                return View();
            }
            var uploadImageResult = await _photoService.AddPhotoAsync(createBookViewModel.Image);
            var book = new Book
            {
                Name = createBookViewModel.Name,
                Author = createBookViewModel.Author,
                Publisher = createBookViewModel.Publisher,
                Category = createBookViewModel.Category,
                Price = createBookViewModel.Price,
                Image = uploadImageResult.Url.ToString(),
                Rating = createBookViewModel.Rating,
                PagesCount = createBookViewModel.PagesCount,
                InStock = createBookViewModel.InStock
            };
            _repository.Add(book);
            return RedirectToAction("Index", "Book");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var book = await _repository.GetByIdAsync(id);
            var bookViewModel = new EditBookViewModel
            {
                Name = book.Name,
                Author = book.Author,
                Publisher = book.Publisher,
                Category = book.Category,
                Url = book.Image,
                Price = book.Price,
                Rating= book.Rating,
                PagesCount = book.PagesCount,
                InStock = book.InStock
            };
            return View(bookViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditBookViewModel editBookViewModel, int id)
        {
            if (!ModelState.IsValid)
            {
                TempData["ValidationError"] = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
                return View();
            }

            if (editBookViewModel.Url != null)
                await _photoService.DeletePhotoAsync(editBookViewModel.Url);
            var uploadPhotoResult = await _photoService.AddPhotoAsync(editBookViewModel.Image);
            var editedBook = new Book
            {
                Id = id,
                Name = editBookViewModel.Name,
                Author = editBookViewModel.Author,
                Publisher = editBookViewModel.Publisher,
                Category = editBookViewModel.Category,
                Image = uploadPhotoResult.Url.ToString(),
                Price = editBookViewModel.Price,
                Rating = editBookViewModel.Rating,
                PagesCount = editBookViewModel.PagesCount,
                InStock = editBookViewModel.InStock
            };
            var res = _repository.Update(editedBook);
            return RedirectToAction("Index", "Book");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var book = await _repository.GetByIdAsync(id);
            if (book == null)
                return View("Error 404 Not Found!");
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _repository.GetByIdAsync(id);
            _repository.Delete(book);
            return RedirectToAction("Index", "Book");
        }
    }
}