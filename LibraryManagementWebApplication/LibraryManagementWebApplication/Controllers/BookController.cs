﻿using LibraryManagementWebApplication.Interfaces;
using LibraryManagementWebApplication.Models;
using LibraryManagementWebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementWebApplication.Controllers
{
    public class BookController : Controller
    {

        private readonly IBookRepository _repository;
        public BookController(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var books = await _repository.GetAll();
            return View(books);
        }

        public async Task<IActionResult> Details(int id)
        {
            var book = await _repository.GetByIdAsync(id);
            Console.WriteLine(book);
            return View(book);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateBookViewModel createBookViewModel)
        {
            var book = new Book
            {
                Name = createBookViewModel.Name,
                Author = createBookViewModel.Author,
                Publisher = createBookViewModel.Publisher,
                Category = createBookViewModel.Category,
                Price = createBookViewModel.Price,
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
                Price = book.Price,
                PagesCount = book.PagesCount,
                InStock = book.InStock
            };
            return View(bookViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditBookViewModel editBookViewModel, int id)
        {
            var editedBook = new Book
            {
                Id = id,
                Name = editBookViewModel.Name,
                Author = editBookViewModel.Author,
                Publisher = editBookViewModel.Publisher,
                Category = editBookViewModel.Category,
                Price = editBookViewModel.Price,
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